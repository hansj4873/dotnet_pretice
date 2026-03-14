namespace AccountService.Domain.UserDomain;
public record CreateUserRequest(
    [Required] //꼭 있어야 한다는 소리
    string name
);