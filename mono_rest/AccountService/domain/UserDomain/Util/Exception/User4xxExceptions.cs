namespace AccountService.Domain.UserDomain;

public class UserNotFound : UserException
{
    public UserNotFound(string message)
    : base(message, StatusCodes.Status404NotFound) { }

    public static UserNotFound NotFound(string notFoundValue)
    {
        return new UserNotFound(notFoundValue + " is not found");
    }
}

public class AccountBadRequest : UserException
{
    public AccountBadRequest(string message)
    : base(message, StatusCodes.Status400BadRequest) { }
}