using FluentMigrator;

namespace OrderService.Persistency.Migrations
{
    [Migration(202212041830)]
    public class Migration_202212041830 : Migration
    {
        public override void Down()
        {
            Delete.Table("Order");
            Delete.Table("MenuItemOrder");
        }

        public override void Up()
        {
            Create.Table("Order")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("Status").AsString().NotNullable()
                .WithColumn("OrderDate").AsDateTime().NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("VisitorId").AsGuid().NotNullable();
            Create.Table("MenuItemOrder")
                .WithColumn("Id").AsGuid().PrimaryKey().NotNullable()
                .WithColumn("MenuItemId").AsGuid().NotNullable()
                .WithColumn("OrderId").AsGuid().NotNullable().ForeignKey("Order", "Id")
                .WithColumn("Number").AsInt32().NotNullable().WithDefaultValue(1);
        }
    }
}
