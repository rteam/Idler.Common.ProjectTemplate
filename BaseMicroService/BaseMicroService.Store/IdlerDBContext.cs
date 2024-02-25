#if (Example)
using BaseMicroService.Domain;
#endif
using Idler.Common.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BaseMicroService.Store;

public class IdlerDBContext: CoreDBContext
{
    public IdlerDBContext()
    {
    }

    public IdlerDBContext(DbContextOptions<IdlerDBContext> options)
        : base(options)
    {
    }
    public IConfiguration Configuration { get; set; }
#if (Example)
    public DbSet<Test> Tests { get; set; }
#endif
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = this.Configuration.GetConnectionString("IdlerDBContext");
        if (connectionString.IsEmpty())
            connectionString =
                "Server=serverip;Database=dbname;User ID=user;Password=password";//开发或生产环境链接字符串
#if (SQLServer)
        optionsBuilder.UseSqlServer(connectionString);
#elif (MySQL)
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
#endif
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
    }
}