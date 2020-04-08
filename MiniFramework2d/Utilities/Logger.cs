using System;
using System.Diagnostics;
using System.IO;

namespace MiniFramework2d.Utilities
{
    public static class Logger
    {
        public static void Log(string lines)
        {
            string path = Configuration.LogPath;
            VerifyDir(path);
            string fileName = Configuration.LogFileName;
            try
            {
                StreamWriter file = new StreamWriter(path + fileName, true);
                file.WriteLine(DateTime.Now + ": " + lines);
                file?.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Something went wrong at Logger.Log({lines})");
                Console.WriteLine(e);
            }
        }

        private static void VerifyDir(string path)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                if (!dir.Exists)
                {
                    dir.Create();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Something went wrong at Logger.VerifyDir({path})");
                Console.WriteLine(e);
            }
        }
    }
}
