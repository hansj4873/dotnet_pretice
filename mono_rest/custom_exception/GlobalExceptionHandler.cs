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
        //필요한 변수 선언
        int statusCode = StatusCodes.Status500InternalServerError;
        string title = "InternalServerError";
        string customCode = "SY-500";
        //Exception 확인
        if(exception is CustomException customException)
        {
            //맞으면 변수 변환
            statusCode = customException.StatusCode;
            title = "ServiceError";
            customCode = customException.CustomCode;
        }
        //이거 국제 규격이라고 함
        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = exception.Message
        };
        //내가 추가로 만든 CustomCode를 problemDetails에 추가
        problemDetails.Extensions.Add("CustomCode", customCode);

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
        
        return true;
    }
}