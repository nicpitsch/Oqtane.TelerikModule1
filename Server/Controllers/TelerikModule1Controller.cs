using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Oqtane.Shared;
using Oqtane.Enums;
using Oqtane.Infrastructure;
using My.Module.TelerikModule1.Repository;
using Oqtane.Controllers;
using System.Net;

namespace My.Module.TelerikModule1.Controllers
{
    [Route(ControllerRoutes.ApiRoute)]
    public class TelerikModule1Controller : ModuleControllerBase
    {
        private readonly ITelerikModule1Repository _TelerikModule1Repository;

        public TelerikModule1Controller(ITelerikModule1Repository TelerikModule1Repository, ILogManager logger, IHttpContextAccessor accessor) : base(logger, accessor)
        {
            _TelerikModule1Repository = TelerikModule1Repository;
        }

        // GET: api/<controller>?moduleid=x
        [HttpGet]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public IEnumerable<Models.TelerikModule1> Get(string moduleid)
        {
            int ModuleId;
            if (int.TryParse(moduleid, out ModuleId) && IsAuthorizedEntityId(EntityNames.Module, ModuleId))
            {
                return _TelerikModule1Repository.GetTelerikModule1s(ModuleId);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized TelerikModule1 Get Attempt {ModuleId}", moduleid);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [Authorize(Policy = PolicyNames.ViewModule)]
        public Models.TelerikModule1 Get(int id)
        {
            Models.TelerikModule1 TelerikModule1 = _TelerikModule1Repository.GetTelerikModule1(id);
            if (TelerikModule1 != null && IsAuthorizedEntityId(EntityNames.Module, TelerikModule1.ModuleId))
            {
                return TelerikModule1;
            }
            else
            { 
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized TelerikModule1 Get Attempt {TelerikModule1Id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                return null;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.TelerikModule1 Post([FromBody] Models.TelerikModule1 TelerikModule1)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, TelerikModule1.ModuleId))
            {
                TelerikModule1 = _TelerikModule1Repository.AddTelerikModule1(TelerikModule1);
                _logger.Log(LogLevel.Information, this, LogFunction.Create, "TelerikModule1 Added {TelerikModule1}", TelerikModule1);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized TelerikModule1 Post Attempt {TelerikModule1}", TelerikModule1);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                TelerikModule1 = null;
            }
            return TelerikModule1;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public Models.TelerikModule1 Put(int id, [FromBody] Models.TelerikModule1 TelerikModule1)
        {
            if (ModelState.IsValid && IsAuthorizedEntityId(EntityNames.Module, TelerikModule1.ModuleId) && _TelerikModule1Repository.GetTelerikModule1(TelerikModule1.TelerikModule1Id, false) != null)
            {
                TelerikModule1 = _TelerikModule1Repository.UpdateTelerikModule1(TelerikModule1);
                _logger.Log(LogLevel.Information, this, LogFunction.Update, "TelerikModule1 Updated {TelerikModule1}", TelerikModule1);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized TelerikModule1 Put Attempt {TelerikModule1}", TelerikModule1);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                TelerikModule1 = null;
            }
            return TelerikModule1;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = PolicyNames.EditModule)]
        public void Delete(int id)
        {
            Models.TelerikModule1 TelerikModule1 = _TelerikModule1Repository.GetTelerikModule1(id);
            if (TelerikModule1 != null && IsAuthorizedEntityId(EntityNames.Module, TelerikModule1.ModuleId))
            {
                _TelerikModule1Repository.DeleteTelerikModule1(id);
                _logger.Log(LogLevel.Information, this, LogFunction.Delete, "TelerikModule1 Deleted {TelerikModule1Id}", id);
            }
            else
            {
                _logger.Log(LogLevel.Error, this, LogFunction.Security, "Unauthorized TelerikModule1 Delete Attempt {TelerikModule1Id}", id);
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
        }
    }
}
