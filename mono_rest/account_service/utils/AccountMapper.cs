namespace account_service.Utils;

public static class AccountMapper
{
    public static AccountResponse ToResponse(this Account account)
    {
        return new AccountResponse(account.Id, account.Name);
    }
}