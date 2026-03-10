namespace account_service.Utils.Exceptions;

public class AccountNotFound : AccountException
{
    public AccountNotFound(string message) 
    : base(message, StatusCodes.Status404NotFound){}

    public static AccountNotFound NotFound(string notFoundValue)
    {
        return new AccountNotFound(notFoundValue + " is not found");
    }
}

public class AccountBadRequest : AccountException
{
    public AccountBadRequest(string message) 
    : base(message, StatusCodes.Status400BadRequest){}
}