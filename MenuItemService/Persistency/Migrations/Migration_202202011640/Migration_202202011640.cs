using Common;
using FluentMigrator;
using FluentMigrator.Runner;
using System.Reflection;

namespace MenuItemService.Persistency.Migrations.Migration_202211181220
{
    [Migration(202202011640)]
    public class Migration_202202011640 : BaseScriptMigration
    {
        public Migration_202202011640() : base("Migration_202202011640/SetDiscountOnCategory.sql") { }
    }
}
