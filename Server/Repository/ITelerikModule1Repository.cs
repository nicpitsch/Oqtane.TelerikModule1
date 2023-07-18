using System.Collections.Generic;
using My.Module.TelerikModule1.Models;

namespace My.Module.TelerikModule1.Repository
{
    public interface ITelerikModule1Repository
    {
        IEnumerable<Models.TelerikModule1> GetTelerikModule1s(int ModuleId);
        Models.TelerikModule1 GetTelerikModule1(int TelerikModule1Id);
        Models.TelerikModule1 GetTelerikModule1(int TelerikModule1Id, bool tracking);
        Models.TelerikModule1 AddTelerikModule1(Models.TelerikModule1 TelerikModule1);
        Models.TelerikModule1 UpdateTelerikModule1(Models.TelerikModule1 TelerikModule1);
        void DeleteTelerikModule1(int TelerikModule1Id);
    }
}
