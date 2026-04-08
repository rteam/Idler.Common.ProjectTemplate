using Idler.Common.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BaseMicroService.Store;

public class DatabaseFactory : IDbContextFactory
{
    public DatabaseFactory(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    private CoreDBContext? _coreDbContext;
    public virtual CoreDBContext Get()
    {
        return new IdlerDBContext() { Configuration = this.Configuration };
    }

    public virtual void Dispose()
    {
        this._coreDbContext?.Dispose();
        this._coreDbContext = null;
    }


    public virtual CoreDBContext Instance()
    {
        this._coreDbContext ??= new IdlerDBContext() { Configuration = this.Configuration };
        return this._coreDbContext;
    }
}
