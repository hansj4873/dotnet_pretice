namespace AccountService.Domain.UserDomain;
/**
* 나중에 dbcontext에 넣을 값
* User의 db조건
*/
public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        //테이블 지정, (테이블명, 스키마명)
        builder.ToTable("user", "account_service");
        //키값 설정 이거 해주면 알아서 자료형 찾아서 매핑함
        builder.HasKey(x => x.Sq);
        builder.Property(x => x.Sq)
        .UseIdentityAlwaysColumn();
        //각 속성 설정
        builder.Property(x => x.Name)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(x => x.Phone)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(x => x.Email)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(x => x.BasicAddr)
        .IsRequired()
        .HasMaxLength(255);

        builder.Property(x => x.DetailAddr)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(x => x.Post)
        .IsRequired()
        .HasMaxLength(20);

        builder.Property(x => x.Id)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(x => x.Password)
        .IsRequired()
        .HasMaxLength(255);

        builder.Property(x => x.Birthday)
        .IsRequired();

        builder.Property(x => x.JoinDt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.WithdrawDt)
        .IsRequired(false);

        builder.Property(x => x.AgreeDt)
        .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.Gender)
        .IsRequired()
        .HasMaxLength(20)
        .HasConversion<string>();

        builder.Property(x => x.Role)
        .HasMaxLength(20)
        .HasDefaultValue(UserRole.USER)
        .HasConversion<string>();

        builder.Property(x => x.Status)
        .HasMaxLength(20)
        .HasDefaultValue(UserStatus.NORMAL)
        .HasConversion<string>();

        builder.Property(x => x.Point)
        .HasDefaultValue(0);

        builder.Property(x => x.CompanySq)
        .IsRequired(false);
        //추가 설정
        builder.HasIndex(x => x.Id).IsUnique();
    }
}