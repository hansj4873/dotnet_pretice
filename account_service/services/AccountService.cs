namespace account_service.Services;

public class AccountService
{
    private readonly List<Account> _accounts = new();
    private int _nextId = 1;

    public Account CreateAccount(CreateAccountRequest request)
    {
        var account = new Account(_nextId++, request.name);
        
        _accounts.Add(account);

        return account;
    }

    public Account? GetAccount(int id)
    {
        return _accounts.FirstOrDefault(a => a.Id == id);
    }

    public List<Account> GetAccounts()
    {
        return _accounts;
    }

    public Account? UpdateAccount(UpdateAccountRequest request)
    {
        var account = GetAccount(request.id);
        if(account == null)
        {
            return null;
        }
        account.Name = request.name;
        return account;
    }
    public bool DeleteAccount(int id)
    {
        var account = GetAccount(id);
        if(account == null)
        {
            return false;
        }
        _accounts.Remove(account);
        return true;
    }
}
