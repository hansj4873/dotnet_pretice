namespace AccountService.Domain.UserDomain;

public class User
{
    public int Id { get; set; }

    //required = 없으면 개체 생성 안됨
    public required string Name { get; set; }

    //required가 붙은 걸 다 초기화 했다고 컴파일러한테 알리는 어트리뷰트
    [SetsRequiredMembers]
    public User(int id, string name)
    {
        Id = id;
        Name = name;
    }
}