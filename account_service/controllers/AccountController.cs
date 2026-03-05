using Microsoft.AspNetCore.Mvc;
using account_service.Services;

namespace account_service.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public IActionResult CreateAccount(
        [FromBody] string name
    )
    {
        return CreatedAtAction(
            nameof(CreateAccount),
            null,
            _accountService.CreateAccount(name));
    }

    [HttpGet]
    public IActionResult GetAccounts()
    {
        return Ok(_accountService.GetAccounts());
    }
    [HttpGet("{id}")]
    public IActionResult GetAccount(
        [FromRoute] int id
    )
    {
        return Ok(_accountService.GetAccount(id));
    }
}