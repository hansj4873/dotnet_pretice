namespace AccountService.Domain.UserDomain;

public class UserService
{
    private readonly List<User> _accounts = new();
    private int _nextId = 1;
    //내부에서 쓰는 객체반환 함수
    private User FindUserById(int id)
    {
        return _accounts.FirstOrDefault(a => a.Id == id) ??
        throw UserNotFound.NotFound("id");
    }
    //생성
    public UserResponse CreateUser(CreateUserRequest request)
    {
        var account = new User(_nextId++, request.name);

        _accounts.Add(account);

        return account.ToResponse();
    }
    //id기반 단일 탐색
    public UserResponse? GetUser(int id)
    {
        //null이면 null을 아니면 ToResponse하라는 뜻
        //return FindAccountById(id)?.ToResponse();
        return FindUserById(id).ToResponse();
    }
    //전체 탐색
    public List<UserResponse> GetUsers()
    {
        return _accounts.Select(a => a.ToResponse()).ToList();
    }
    //수정
    public UserResponse UpdateUser(int id, UpdateUserRequest request)
    {
        var account = FindUserById(id);
        account.Name = request.name;
        return account.ToResponse();
    }
    //삭제
    public void DeleteUser(int id)
    {
        var account = FindUserById(id);
        _accounts.Remove(account);
    }
}
