using FluentMigrator;

namespace ReviewService.Persistency.Migrations
{
    [Migration(2211251742)]
    public class Migration_2211251742 : Migration
    {
        public override void Down()
        {
            Delete.Column("VisitorId").FromTable("Review");
        }

        public override void Up()
        {
            Alter.Table("Review").AddColumn("VisitorId").AsInt32().NotNullable();
        }
    }
}
