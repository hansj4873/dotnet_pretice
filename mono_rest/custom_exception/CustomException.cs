namespace custom_exception;
public class CustomException : Exception
{
    public int StatusCode {get;} 
    public string CustomCode {get;}
    public CustomException(string message, int statusCode, string customCode) : base(message)
    {
        StatusCode = statusCode;
        CustomCode = customCode;
    }
    public static CustomException ValidBadRequest(string message)
    {
        return new CustomException(
            message,
            StatusCodes.Status400BadRequest,
            "SYS-" + StatusCodes.Status400BadRequest.ToString()
        );
    }
}