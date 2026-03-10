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
}