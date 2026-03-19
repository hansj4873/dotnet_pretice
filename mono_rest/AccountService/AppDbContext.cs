namespace AccountService;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    public DbSet<User> Users { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        /*
        일일이 modelBuilder.ApplyConfiguration(new UserConfig())라고 적을 필요 없이
        현재 프로젝트(Assembly)를 싹 뒤져서
        IEntityTypeConfiguration을 상속받은 모든 파일(예: UserConfig)을 찾아 자동으로 적용
        */
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}