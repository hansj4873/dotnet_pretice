namespace account_service.Models.Requests;
public record CreateAccountRequest(
    [Required] //꼭 있어야 한다는 소리
    string name
);