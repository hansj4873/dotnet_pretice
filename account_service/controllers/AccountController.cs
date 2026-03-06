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
        [FromBody] UpsertAccountRequest request
    )
    {
        /*
        CreatedAtAction, Created는 201 반환 근데 쓰는 법이 좀 다름 
        근데 나는 CreatedAtAction만 쓸거임, 그러니까 이것만 기억하면 될 듯
        (nameof("함수이름"),
        ("{id}") 있으면 그 값, 없으면 null, // 여기까지 반환할 때 쓰는 url 생성임
        메세지)
        */
        return CreatedAtAction(
            nameof(CreateAccount),
            null,
            _accountService.CreateAccount(request));
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