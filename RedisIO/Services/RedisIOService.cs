using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisIO.Services
{
    public class RedisIOService : IRedisIOService
    {
        private readonly ConnectionMultiplexer _muxer;

        public RedisIOService(string configuration)
        {
            _muxer = ConnectionMultiplexer.Connect(configuration);
        }

        public async Task<bool> AddAsync(RedisKey key, RedisValue value)
        {
            var db = _muxer.GetDatabase();
            return await db.StringSetAsync(key, value);
        }

        public async Task<RedisValue> GetAsync(RedisKey key)
        {
            var db = _muxer.GetDatabase();
            return await db.StringGetAsync(key);
        }
    }
}
