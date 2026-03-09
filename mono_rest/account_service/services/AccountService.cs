namespace account_service.Services;

public class AccountService
{
    private readonly List<Account> _accounts = new();
    private int _nextId = 1;

    private Account? FindAccountById(int id)
    {
         return _accounts.FirstOrDefault(a => a.Id == id);
    }
    public AccountResponse CreateAccount(CreateAccountRequest request)
    {
        var account = new Account(_nextId++, request.name);
        
        _accounts.Add(account);

        return account.ToResponse();
    }

    public AccountResponse? GetAccount(int id)
    {
        return FindAccountById(id)?.ToResponse();
    }

    public List<AccountResponse> GetAccounts()
    {
        return _accounts.Select(a => a.ToResponse()).ToList();
    }

    public AccountResponse? UpdateAccount(int id, UpdateAccountRequest request)
    {
        var account = FindAccountById(id);
        if(account == null)
        {
            return null;
        }
        account.Name = request.name;
        return account.ToResponse();
    }
    public bool DeleteAccount(int id)
    {
        var account = FindAccountById(id);
        if(account == null)
        {
            return false;
        }
        _accounts.Remove(account);
        return true;
    }
}
