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

            var result = await db.StringSetAsync("setKey", "setValue");
            Console.WriteLine(result);

            var redisValue = await db.StringGetAsync("setKey");
            var redisValueObject = redisValue.Box();

            Console.WriteLine(redisValueObject);

            ISubscriber sub = redis.GetSubscriber();
            sub.Subscribe("messages").OnMessage(async channelMessage => {
                await Task.Delay(1000);
                Console.WriteLine(channelMessage.Message);
            });

            await sub.PublishAsync("messages", "hello");
        }
    }
}
