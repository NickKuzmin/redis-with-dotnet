using System;
using System.Threading.Tasks;

namespace Redis.DotNet.ConsoleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () => await new RedisProcessor().Run()).Wait();
            Console.ReadKey();
        }
    }
}
