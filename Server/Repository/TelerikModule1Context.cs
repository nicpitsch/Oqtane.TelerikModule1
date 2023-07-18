using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace My.Module.TelerikModule1.Repository
{
    public class TelerikModule1Context : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.TelerikModule1> TelerikModule1 { get; set; }

        public TelerikModule1Context(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }
    }
}
