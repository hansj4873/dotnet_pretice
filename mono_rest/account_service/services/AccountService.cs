namespace account_service.Services;

public class AccountService
{
    private readonly List<Account> _accounts = new();
    private int _nextId = 1;
    //내부에서 쓰는 객체반환 함수
    private Account FindAccountById(int id)
    {
         return _accounts.FirstOrDefault(a => a.Id == id) ?? 
         throw AccountNotFound.NotFound("id");
    }
    //생성
    public AccountResponse CreateAccount(CreateAccountRequest request)
    {
        var account = new Account(_nextId++, request.name);
        
        _accounts.Add(account);

        return account.ToResponse();
    }
    //id기반 단일 탐색
    public AccountResponse? GetAccount(int id)
    {
        //null이면 null을 아니면 ToResponse하라는 뜻
        //return FindAccountById(id)?.ToResponse();
        return FindAccountById(id).ToResponse();
    }
    //전체 탐색
    public List<AccountResponse> GetAccounts()
    {
        return _accounts.Select(a => a.ToResponse()).ToList();
    }
    //수정
    public AccountResponse UpdateAccount(int id, UpdateAccountRequest request)
    {
        var account = FindAccountById(id);
        account.Name = request.name;
        return account.ToResponse();
    }
    //삭제
    public void DeleteAccount(int id)
    {
        var account = FindAccountById(id);
        _accounts.Remove(account);
    }
}
