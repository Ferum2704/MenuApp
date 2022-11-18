using FluentMigrator;

namespace MenuItemService.Persistency.Migrations
{
    [Migration(202211170915)]
    public class Migration_202211170915 : Migration
    {
        public override void Down()
        {
            Delete.Table("Category");
            Delete.Table("MenuItem");
            Delete.Table("Ingredient");
            Delete.Table("MenuItemIngredient");
        }

        public override void Up()
        {
            Create.Table("Category")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable().Unique()
                .WithColumn("Priority").AsInt32().NotNullable();
            Create.Table("MenuItem")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable().Unique()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("CategoryId").AsGuid().NotNullable().ForeignKey("Category", "Id");
            Create.Table("Ingredient")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Name").AsString().NotNullable().Unique()
                .WithColumn("CaloriesAmount").AsInt32().NotNullable();
            Create.Table("MenuItemIngredient")
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("Weight").AsInt32().Nullable()
                .WithColumn("MenuItemId").AsGuid().NotNullable().ForeignKey("MenuItem", "Id")
                .WithColumn("IngredientId").AsGuid().NotNullable().ForeignKey("Ingredient", "Id");
        }
    }
}
