using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Models;
using Oqtane.Infrastructure;
using Oqtane.Enums;
using Oqtane.Repository;
using My.Module.TelerikModule1.Repository;

namespace My.Module.TelerikModule1.Manager
{
    public class TelerikModule1Manager : MigratableModuleBase, IInstallable, IPortable
    {
        private readonly ITelerikModule1Repository _TelerikModule1Repository;
        private readonly IDBContextDependencies _DBContextDependencies;

        public TelerikModule1Manager(ITelerikModule1Repository TelerikModule1Repository, IDBContextDependencies DBContextDependencies)
        {
            _TelerikModule1Repository = TelerikModule1Repository;
            _DBContextDependencies = DBContextDependencies;
        }

        public bool Install(Tenant tenant, string version)
        {
            return Migrate(new TelerikModule1Context(_DBContextDependencies), tenant, MigrationType.Up);
        }

        public bool Uninstall(Tenant tenant)
        {
            return Migrate(new TelerikModule1Context(_DBContextDependencies), tenant, MigrationType.Down);
        }

        public string ExportModule(Oqtane.Models.Module module)
        {
            string content = "";
            List<Models.TelerikModule1> TelerikModule1s = _TelerikModule1Repository.GetTelerikModule1s(module.ModuleId).ToList();
            if (TelerikModule1s != null)
            {
                content = JsonSerializer.Serialize(TelerikModule1s);
            }
            return content;
        }

        public void ImportModule(Oqtane.Models.Module module, string content, string version)
        {
            List<Models.TelerikModule1> TelerikModule1s = null;
            if (!string.IsNullOrEmpty(content))
            {
                TelerikModule1s = JsonSerializer.Deserialize<List<Models.TelerikModule1>>(content);
            }
            if (TelerikModule1s != null)
            {
                foreach(var TelerikModule1 in TelerikModule1s)
                {
                    _TelerikModule1Repository.AddTelerikModule1(new Models.TelerikModule1 { ModuleId = module.ModuleId, Name = TelerikModule1.Name });
                }
            }
        }
    }
}
