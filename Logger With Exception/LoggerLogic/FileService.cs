using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;
using System.Runtime.CompilerServices;

namespace LoggerLogic
{
    public static class FileService
    {
        public static void CreateFiles(DateTime time, string message)
        {
            var count = 7;
            var path = Directory.GetCurrentDirectory() + @"//logs//";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var fileName = time.ToString("hh.mm.ss") + " " + time.ToString("dd.MM.yyyy") + ".txt";
            using (var sw = new StreamWriter(path + fileName, true))
            {
                sw.WriteLine(message);
            }

            CheckCountFiles(path, count);
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

        // GetCurrentDirectory(): получает путь к текущей папке
        // string[] GetFiles(path): получает список файлов в каталоге path
        // public DirectoryInfo (string path);
        // Create(): создает каталог
        // FileInfo[] GetFiles(): получает список файлов в папке в виде массива FileInfo
        // bool Exists: определяет, существует ли каталог

        // string[] files = Directory.GetFiles(dirName, "*.exe");
        // класс DirectoryInfo
        // var directory = new DirectoryInfo(dirName);
        // FileInfo[] files = directory.GetFiles("*.exe");
    }
}
