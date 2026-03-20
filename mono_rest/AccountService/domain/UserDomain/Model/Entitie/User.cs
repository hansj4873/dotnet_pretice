namespace AccountService.Domain.UserDomain;

public class User
{
    //기본키
    public long Sq { get; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string BasicAddr { get; set; } = string.Empty;
    public string DetailAddr { get; set; } = string.Empty;
    public string Post { get; set; } = string.Empty; //우편번호
    public string Id { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    //날짜 데이터
    public DateTime Birthday { get; set; }
    public DateTime JoinDt { get; set; }
    public DateTime? WithdrawDt { get; set; }
    public DateTime AgreeDt { get; set; }
    //Enum값
    public UserGender Gender { get; set; }
    public UserRole Role { get; set; } = UserRole.USER;
    public UserStatus Status { get; set; } = UserStatus.NORMAL;
    public long Point { get; set; }
    public long? CompanySq { get; set; }
}