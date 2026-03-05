using account_service.Models;

namespace account_service.Services;

public class AccountService
{
    private readonly List<Account> _accounts = new();
    private int _nextId = 1;

    public Account CreateAccount(string name)
    {
        var account = new Account(_nextId, name);
        
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
}
