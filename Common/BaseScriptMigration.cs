using FluentMigrator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class BaseScriptMigration : Migration
    {
        private static string _path = "./Persistency/Migrations/";
        private string _scriptPath;
        public BaseScriptMigration(string scriptPath)
        {
            _scriptPath = scriptPath;
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            string script;
            using (StreamReader sr = new StreamReader(_path + _scriptPath))
            {
                script = sr.ReadToEnd();
            }
            Execute.Sql(script);
        }
    }
}
