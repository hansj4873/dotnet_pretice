namespace account_service.Utils.Exceptions;

public class AccountException : CustomException
{
    public AccountException(string message, int statusCode)
    : base(message, statusCode, "AC-" + statusCode.ToString()) {}
}