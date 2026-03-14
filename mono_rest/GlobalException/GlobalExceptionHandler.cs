namespace GlobalException;
//@ExceptionHandler 같은 거
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    //IExceptionHandler가 인터페이스라 이거를 포함함
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext, //에러가 터진 요청과 응답
        Exception exception, //실제로 터진 에러
        CancellationToken cancellationToken //요청이 취소되었는지 확인하는 용도
        )
    {
        /*
        검색용 id, 로그찾기 부우우울펴어어언해서 씀
        Activity.Current?.Id는 MSA환경에서도 안죽고 이어지는 id
        httpContext.TraceIdentifier는 ASP.NET Core가 http요청마다 부여하는 id
        */
        var exId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
        //Exception 확인, showStackTrace는 스택 트레이스를 보여줄건지 정사는 변수
        var (statusCode, title, customCode, showStackTrace) = exception switch
        {
            //CustomException의 경우
            CustomException ce => (
                ce.StatusCode, 
                "ServiceError", 
                ce.CustomCode
                ,false
                ),
            //400, 405 등 잘못된 요청, 경로 등
            BadHttpRequestException badEx => (
                badEx.StatusCode,
                "SystemError",
                 "SYS-" + badEx.StatusCode.ToString(),
                 false
            ),
            //나머지
            _ => (
                StatusCodes.Status500InternalServerError,
                "InternalServerError",
                "SYS-500",
                true
            )
        };
        //이거 국제 규격이라고 함
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message,
            Instance = httpContext.Request.Path.Value
        };
        //예외찍기
        if (showStackTrace)
        {
            _logger.LogError(
                exception, "{ExId}\n{CustomCode}\n{Path}\n{Message}", 
                exId, customCode, httpContext.Request.Path.Value, exception.Message);
        }
        else
        {
            _logger.LogWarning(
                ">{ExId}\n{CustomCode}\n{Path}\n{Message}", 
                exId, customCode, httpContext.Request.Path.Value, exception.Message);
        }
        //내가 추가로 만든 CustomCode를 problemDetails에 추가
        problemDetails.Extensions.Add("ExId", exId);
        problemDetails.Extensions.Add("CustomCode", customCode);

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}