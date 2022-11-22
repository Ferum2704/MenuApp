using Common;
using FluentMigrator;
using FluentMigrator.Runner;
using System.Reflection;

namespace MenuItemService.Persistency.Migrations.Migration_202211181220
{
    [Migration(202211181220)]
    public class Migration_202211181220 : BaseScriptMigration
    {
        public Migration_202211181220() : base("Migration_202211181220/Example.sql") { }
    }
}
