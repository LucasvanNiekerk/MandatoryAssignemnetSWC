using System;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker worker = new Worker();
            worker.Start();


            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
