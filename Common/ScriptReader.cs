
namespace Common
{
    public static class ScriptReader
    {
        private static string _path = "./Persistency/SqlFiles/";
        public static string ReadScript(string scriptName)
        {
            string script;
            using (StreamReader sr = new StreamReader(_path+scriptName))
            {
                script = sr.ReadToEnd();
            }
            return script;
        }
    }
}
