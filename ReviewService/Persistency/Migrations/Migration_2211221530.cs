using FluentMigrator;

namespace ReviewService.Persistency.Migrations
{
    [Migration(2211221530)]
    public class Migration_2211221530 : Migration
    {
        public override void Down()
        {
            Delete.Table("Review");
        }

        public override void Up()
        {
            Create.Table("ReviewItem")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Rating").AsInt32().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("MenuItemId").AsGuid().NotNullable()
                .WithColumn("PostDate").AsDateTime().NotNullable();
        }
    }
}
