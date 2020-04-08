using System;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "RNGesus";  
            Worker worker = new Worker();
            worker.Start();

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
