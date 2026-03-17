namespace AccountService.Domain.UserDomain;

public class UserException : CustomException
{
    public UserException(string message, int statusCode)
    : base(message, statusCode, "US-" + statusCode.ToString()) { }
}