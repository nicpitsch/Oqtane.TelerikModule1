using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace My.Module.TelerikModule1.Migrations.EntityBuilders
{
    public class TelerikModule1EntityBuilder : AuditableBaseEntityBuilder<TelerikModule1EntityBuilder>
    {
        private const string _entityTableName = "MyTelerikModule1";
        private readonly PrimaryKey<TelerikModule1EntityBuilder> _primaryKey = new("PK_MyTelerikModule1", x => x.TelerikModule1Id);
        private readonly ForeignKey<TelerikModule1EntityBuilder> _moduleForeignKey = new("FK_MyTelerikModule1_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public TelerikModule1EntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override TelerikModule1EntityBuilder BuildTable(ColumnsBuilder table)
        {
            TelerikModule1Id = AddAutoIncrementColumn(table,"TelerikModule1Id");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> TelerikModule1Id { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
