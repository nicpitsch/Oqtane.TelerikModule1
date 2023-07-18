using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;
using My.Module.TelerikModule1.Models;

namespace My.Module.TelerikModule1.Services
{
    public class TelerikModule1Service : ServiceBase, ITelerikModule1Service, IService
    {
        public TelerikModule1Service(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("TelerikModule1");

        public async Task<List<Models.TelerikModule1>> GetTelerikModule1sAsync(int ModuleId)
        {
            List<Models.TelerikModule1> TelerikModule1s = await GetJsonAsync<List<Models.TelerikModule1>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId));
            return TelerikModule1s.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.TelerikModule1> GetTelerikModule1Async(int TelerikModule1Id, int ModuleId)
        {
            return await GetJsonAsync<Models.TelerikModule1>(CreateAuthorizationPolicyUrl($"{Apiurl}/{TelerikModule1Id}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.TelerikModule1> AddTelerikModule1Async(Models.TelerikModule1 TelerikModule1)
        {
            return await PostJsonAsync<Models.TelerikModule1>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, TelerikModule1.ModuleId), TelerikModule1);
        }

        public async Task<Models.TelerikModule1> UpdateTelerikModule1Async(Models.TelerikModule1 TelerikModule1)
        {
            return await PutJsonAsync<Models.TelerikModule1>(CreateAuthorizationPolicyUrl($"{Apiurl}/{TelerikModule1.TelerikModule1Id}", EntityNames.Module, TelerikModule1.ModuleId), TelerikModule1);
        }

        public async Task DeleteTelerikModule1Async(int TelerikModule1Id, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{TelerikModule1Id}", EntityNames.Module, ModuleId));
        }
    }
}
