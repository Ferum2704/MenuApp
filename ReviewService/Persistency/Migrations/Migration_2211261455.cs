using FluentMigrator;

namespace ReviewService.Persistency.Migrations
{
    [Migration(2211261455)]
    public class Migration_2211261455 : Migration
    {
        public override void Down()
        {
            Alter.Table("Review").AlterColumn("VisitorId").AsInt32();
        }

        public override void Up()
        {
            Alter.Table("Review").AlterColumn("VisitorId").AsString();
        }
    }
}
