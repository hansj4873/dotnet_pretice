namespace account_service.Controllers;
/*
[ApiController] (어트리뷰트)
-자동 모델 바인딩 강화
-자동 400 응답 (유효성 실패 시)
-파라미터 바인딩 추론
-ProblemDetails 자동 생성

ApiController + ControllerBase상속 == RestController
Route == RequestMapping
*/
[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
    //이거 생성자 주입 readonly== final
    private readonly HelloWorldService _helloWorldService;

    public HelloWorldController(HelloWorldService helloWorldService)
    {
        _helloWorldService = helloWorldService;
    }
    //IActionResult == ResponseEntity
    [HttpGet]
    public IActionResult HelloWorld()
    {
        var msg = _helloWorldService.GetHelloWorld();
        return Ok(new { msg });
    }
}