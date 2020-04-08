using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace TesterLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fs = new FileStream(Environment.GetCommandLineArgs()[1], FileMode.Open, FileAccess.Read, FileShare.ReadWrite | FileShare.Delete))
            using (var reader = new StreamReader(fs))
            {
                while (true)
                {
                    var line = reader.ReadLine();

                    if (!String.IsNullOrWhiteSpace(line)) Console.WriteLine(line);
                    Thread.Sleep(10);
                }
            }
        }
    }
}
