namespace account_service.Models.Requests;

public record UpdateAccountRequest(
    [Required]
    string name
);