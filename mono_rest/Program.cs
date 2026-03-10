var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//기본 인프라 등록
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//내가 만든 서비스들 등록
builder.Services.AddScoped<HelloWorldService>();
//테스트 상황이라서 안없어지게
builder.Services.AddSingleton<AccountService>();

//예외처리 등록
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
/*
시스템에서 던지는 예외처리를 한번 더 감싸기
options = ApiBehaviorOptions, ApiBehaviorOptions를 builder.Services.Configure로 전달할 건데
InvalidModelStateResponseFactory라는 함수만 내가 정의한 context로 변환하는 것
*/
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var message = "input data invalid";
        throw CustomException.ValidBadRequest(message);
    };
});
var app = builder.Build();

app.UseExceptionHandler();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();