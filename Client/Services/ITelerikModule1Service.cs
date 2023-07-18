using System.Collections.Generic;
using System.Threading.Tasks;
using My.Module.TelerikModule1.Models;

namespace My.Module.TelerikModule1.Services
{
    public interface ITelerikModule1Service 
    {
        Task<List<Models.TelerikModule1>> GetTelerikModule1sAsync(int ModuleId);

        Task<Models.TelerikModule1> GetTelerikModule1Async(int TelerikModule1Id, int ModuleId);

        Task<Models.TelerikModule1> AddTelerikModule1Async(Models.TelerikModule1 TelerikModule1);

        Task<Models.TelerikModule1> UpdateTelerikModule1Async(Models.TelerikModule1 TelerikModule1);

        Task DeleteTelerikModule1Async(int TelerikModule1Id, int ModuleId);
    }
}
