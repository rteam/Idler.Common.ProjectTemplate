using Idler.Common.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BaseMicroService.Store;

public class DatabaseFactory : IDbContextFactory
{
    public DatabaseFactory(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    private IConfiguration Configuration { get; set; }

    private CoreDBContext _coreDbContext;
    public virtual CoreDBContext Get()
    {
        return new IdlerDBContext() { Configuration = this.Configuration };
    }

    public virtual void Dispose()
    {
        if (this._coreDbContext != null)
            this._coreDbContext.Dispose();
    }


    public virtual CoreDBContext Instance()
    {
        if (this._coreDbContext == null)
            this._coreDbContext = new IdlerDBContext() { Configuration = this.Configuration };

        return this._coreDbContext;
    }
}