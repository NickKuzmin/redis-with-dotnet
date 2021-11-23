using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Redis.DotNet
{
    public class RedisProcessor
    {
        public async Task Run()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(new ConfigurationOptions
            {
                EndPoints = { "localhost:6379" }
            });

            var db = redis.GetDatabase();
            var pong = await db.PingAsync();
            Console.WriteLine(pong);
        }
    }
}
