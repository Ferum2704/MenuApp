using FluentMigrator;

namespace MenuItemService.Persistency.Migrations
{
    [Migration(202211251735)]
    public class Migration_202211251735 : Migration
    {
        public override void Down()
        {
            Delete.Column("Weight").FromTable("MenuItem");
        }

        public override void Up()
        {
            Alter.Table("MenuItem").AddColumn("Weight").AsString().NotNullable().WithDefaultValue(0);
        }
    }
}
