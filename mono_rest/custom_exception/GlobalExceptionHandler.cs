namespace custom_exception;
//@ExceptionHandler 같은 거
public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }
    //IExceptionHandler가 인터페이스라 이거를 포함함
    async ValueTask<bool> IExceptionHandler.TryHandleAsync(
        HttpContext httpContext, //에러가 터진 요청과 응답
        Exception exception, //실제로 터진 에러
        CancellationToken cancellationToken //요청이 취소되었는지 확인하는 용도
        )
    {
        //예외찍기
        _logger.LogError(exception, "exception : {Message}", exception.Message);
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
            Detail = exception.Message
        };
        if (showStackTrace)
        {
            
        }
        //내가 추가로 만든 CustomCode를 problemDetails에 추가
        problemDetails.Extensions.Add("CustomCode", customCode);

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}