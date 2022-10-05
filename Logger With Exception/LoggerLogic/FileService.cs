using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace LoggerLogic
{
    public static class FileService
    {
        public static async void CreateFiles(DateTime time, string message)
        {
            string? configJson;
            if (!File.Exists("config.json"))
            {
                File.WriteAllText("config.json", JsonConvert.SerializeObject(Directory.GetCurrentDirectory() + "\\Logs\\"));
                configJson = File.ReadAllText("config.json");
            }
            else
            {
                configJson = File.ReadAllText("config.json");
            }

            var path = (string)JsonConvert.DeserializeObject(configJson);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = time.ToString("hh.mm.ss") + " " + time.ToString("dd.MM.yyyy") + ".txt";
            using (var sw = new StreamWriter(path + fileName, true))
            {
                sw.WriteLine(message);
            }

            CheckCountFiles(path, 3);
        }

        public static void CheckCountFiles(string path, int countFiles)
        {
            FileInfo[] info = new DirectoryInfo(path).GetFiles("*.txt");
            if (info.Length > countFiles)
            {
                DateTime[] createTimes = new DateTime[info.Length];
                for (int i = 0; i < info.Length; i++)
                {
                    createTimes[i] = info[i].CreationTime;
                }

                Array.Sort<DateTime>(createTimes);
                for (int i = 0; i < createTimes.Length - countFiles; i++)
                {
                    for (int j = 0; j < info.Length; j++)
                    {
                        if (info[j].CreationTime == createTimes[i])
                        {
                            info[j].Delete();
                        }
                    }
                }
            }
        }
    }
}
