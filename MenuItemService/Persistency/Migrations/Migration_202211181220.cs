using FluentMigrator;
using FluentMigrator.Runner;
using System.Reflection;

namespace MenuItemService.Persistency.Migrations
{
    [Migration(202211181220)]
    public class Migration_202211181220 : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var sqlFiles = assembly.GetManifestResourceNames().
                        Where(file => file.EndsWith(".sql"));
            foreach (var sqlFile in sqlFiles)
            {
                using (Stream stream = assembly.GetManifestResourceStream(sqlFile))
                using (StreamReader reader = new StreamReader(stream))
                {
                    var sqlScript = reader.ReadToEnd();
                    Execute.Sql(sqlScript);
                }
            }
        }
    }
}
