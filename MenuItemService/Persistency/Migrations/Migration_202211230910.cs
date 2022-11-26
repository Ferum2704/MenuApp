using FluentMigrator;

namespace MenuItemService.Persistency.Migrations
{
    [Migration(202211230910)]
    public class Migration_202211230910 : Migration
    {
        public override void Down()
        {
            Delete.Column("PhotoName").FromTable("MenuItem");
        }

        public override void Up()
        {
            Alter.Table("MenuItem").AddColumn("PhotoName").AsString().Nullable();
        }
    }
}
