namespace account_service.Models.Requests;

public record UpdateAccountRequest(
    int id,
    string name
);