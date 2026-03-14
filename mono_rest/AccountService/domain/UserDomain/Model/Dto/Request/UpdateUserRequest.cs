namespace AccountService.Domain.UserDomain;

public record UpdateUserRequest(
    [Required]
    string name
);