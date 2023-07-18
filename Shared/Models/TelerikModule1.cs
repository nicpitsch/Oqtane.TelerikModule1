using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace My.Module.TelerikModule1.Models
{
    [Table("MyTelerikModule1")]
    public class TelerikModule1 : IAuditable
    {
        [Key]
        public int TelerikModule1Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
