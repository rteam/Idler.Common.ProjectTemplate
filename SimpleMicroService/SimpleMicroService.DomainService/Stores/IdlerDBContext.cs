using Idler.Common.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
#if (Example)
using SimpleMicroService.DomainService.Domains;
#endif
namespace SimpleMicroService.DomainService.Stores;

public class IdlerDBContext : CoreDBContext
{
    public IdlerDBContext()
    {
    }

    public IdlerDBContext(DbContextOptions<IdlerDBContext> options)
        : base(options)
    {
    }

    public IConfiguration? Configuration { get; set; }

#if (Example)
    internal DbSet<Test> Tests { get; set; }
#endif

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? connectionString = this.Configuration?.GetConnectionString("IdlerDBContext");
        if (connectionString.IsEmpty())
            connectionString =
                "Server=serverip;Database=dbname;User ID=user;Password=password"; //开发或生产环境链接字符串
        optionsBuilder.UseNpgsql(connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
