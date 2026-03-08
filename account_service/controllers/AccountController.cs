namespace account_service.Controllers;

[ApiController]
[Route("account")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;
    //의존성 주입
    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }
    //생성
    [HttpPost]
    public IActionResult CreateAccount(
        [FromBody] CreateAccountRequest request
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
    //모든 account 가져오기
    [HttpGet]
    public IActionResult GetAccounts()
    {
        return Ok(_accountService.GetAccounts());
    }
    //id로 account 하나 가져오기
    [HttpGet("{id}")]
    public IActionResult GetAccount(
        [FromRoute] int id
    )
    {
        return Ok(_accountService.GetAccount(id));
    }
    //id기반 변경(request에 id값이 들어감)
    [HttpPatch]
    public IActionResult UpdateAccount(
        [FromForm] UpdateAccountRequest request
    )
    {
        var account = _accountService.UpdateAccount(request);
        if(account == null)
        {
            return NotFound();
        }
        return Ok(account);
    }
    //id기반 삭제
    [HttpDelete("{id}")]
    public IActionResult DeleteAccount(
        [FromRoute] int id
    )
    {
        if (_accountService.DeleteAccount(id))
        {
            return NoContent();
        }
        return NotFound();
    }
}