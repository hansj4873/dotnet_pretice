namespace AccountService.Domain.UserDomain;

//알아서 dto랑 json을 비교해서 예외를 던져줌
[ApiController]
[Route("account")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    //의존성 주입
    public UserController(UserService userService)
    {
        _userService = userService;
    }
    /*
    IActionResult는 그냥 범용성 좋은 느낌
    근데 OK생략이 안됨
    ActionResult는 ActionResult<DTO> 느낌으로 지정해서 쓸 수 있음
    근데 OK 생략 가능함
    */
    //생성
    [HttpPost]
    public IActionResult CreateUser(
        [FromBody] CreateUserRequest request
    )
    {
        var account = _userService.CreateUser(request);
        /*
        CreatedAtAction, Created는 201 반환 근데 쓰는 법이 좀 다름 
        근데 나는 CreatedAtAction만 쓸거임, 그러니까 이것만 기억하면 될 듯
        (nameof("함수이름"),
        ("{id}") 있으면 그 값, // 여기까지 반환할 때 쓰는 url 생성임, 조회할 수 있는 url 알려주기용
        메세지)
        */
        return CreatedAtAction(
            nameof(CreateUser),
            new { id = account.id },
            account);
    }
    //모든 account 가져오기
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_userService.GetUsers());
    }
    //id로 account 하나 가져오기
    [HttpGet("{id}")]
    public IActionResult GetUser(
        [FromRoute] int id
    )
    {
        return Ok(_userService.GetUser(id));
    }
    //id기반 변경(request에 id값이 들어감)
    [HttpPatch("{id}")]
    public IActionResult UpdateUser(
        [FromRoute] int id,
        [FromBody] UpdateUserRequest request
    )
    {
        var account = _userService.UpdateUser(id, request);
        return Ok(account);
    }
    //id기반 삭제
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(
        [FromRoute] int id
    )
    {
        _userService.DeleteUser(id);
        return NoContent();
    }
}