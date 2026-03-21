using Idler.Common.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CRTVUP.Unify.Common.ShortLink.DomainService.Domains;
namespace CRTVUP.Unify.Common.ShortLink.DomainService.Stores;

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

    internal DbSet<Test> Tests { get; set; }

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
