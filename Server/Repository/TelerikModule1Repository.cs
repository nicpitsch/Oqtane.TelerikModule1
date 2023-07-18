using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using My.Module.TelerikModule1.Models;

namespace My.Module.TelerikModule1.Repository
{
    public class TelerikModule1Repository : ITelerikModule1Repository, ITransientService
    {
        private readonly TelerikModule1Context _db;

        public TelerikModule1Repository(TelerikModule1Context context)
        {
            _db = context;
        }

        public IEnumerable<Models.TelerikModule1> GetTelerikModule1s(int ModuleId)
        {
            return _db.TelerikModule1.Where(item => item.ModuleId == ModuleId);
        }

        public Models.TelerikModule1 GetTelerikModule1(int TelerikModule1Id)
        {
            return GetTelerikModule1(TelerikModule1Id, true);
        }

        public Models.TelerikModule1 GetTelerikModule1(int TelerikModule1Id, bool tracking)
        {
            if (tracking)
            {
                return _db.TelerikModule1.Find(TelerikModule1Id);
            }
            else
            {
                return _db.TelerikModule1.AsNoTracking().FirstOrDefault(item => item.TelerikModule1Id == TelerikModule1Id);
            }
        }

        public Models.TelerikModule1 AddTelerikModule1(Models.TelerikModule1 TelerikModule1)
        {
            _db.TelerikModule1.Add(TelerikModule1);
            _db.SaveChanges();
            return TelerikModule1;
        }

        public Models.TelerikModule1 UpdateTelerikModule1(Models.TelerikModule1 TelerikModule1)
        {
            _db.Entry(TelerikModule1).State = EntityState.Modified;
            _db.SaveChanges();
            return TelerikModule1;
        }

        public void DeleteTelerikModule1(int TelerikModule1Id)
        {
            Models.TelerikModule1 TelerikModule1 = _db.TelerikModule1.Find(TelerikModule1Id);
            _db.TelerikModule1.Remove(TelerikModule1);
            _db.SaveChanges();
        }
    }
}
