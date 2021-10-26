using System.Threading.Tasks;
using StackExchange.Redis;

namespace RedisIO.Services
{
    public interface IRedisIOService
    {
        public Task<bool> AddAsync(RedisKey key, RedisValue value);

        public Task<RedisValue> GetAsync(RedisKey key);
    }
}
