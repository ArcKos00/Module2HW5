using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LoggerLogic
{
    public class ConfigService
    {
        public static string Service()
        {
            if (!File.Exists("config.json"))
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(Directory.GetCurrentDirectory() + "\\Logs\\"));
            }

            var path = (string)JsonConvert.DeserializeObject(File.ReadAllText("config.json"));
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }
    }
}
