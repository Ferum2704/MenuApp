using FluentMigrator;
using FluentMigrator.SqlAnywhere;

namespace MenuItemService.Persistency.Migrations
{
    [Migration(202211271135)]
    public class Migration_202211271135 : Migration
    {
        public override void Down()
        {
            Delete.UniqueConstraint("UQ").FromTable("Category").Column("Priority");
        }

        public override void Up()
        {
            Create.UniqueConstraint("UQ").OnTable("Category").Column("Priority").NonClustered();
        }
    }
}
