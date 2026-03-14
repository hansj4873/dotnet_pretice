namespace AccountService.Domain.UserDomain;

public static class UserMapper
{
    public static UserResponse ToResponse(this User account)
    {
        return new UserResponse(
            account.Id, 
            account.Name
            );
    }
}