using Oqtane.Models;
using Oqtane.Modules;

namespace My.Module.TelerikModule1
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "TelerikModule1",
            Description = "",
            Version = "1.0.0",
            ServerManagerType = "My.Module.TelerikModule1.Manager.TelerikModule1Manager, My.Module.TelerikModule1.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "My.Module.TelerikModule1.Shared.Oqtane",
            PackageName = "My.Module.TelerikModule1" 
        };
    }
}
