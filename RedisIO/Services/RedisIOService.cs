using System.Threading.Tasks;
using RedisIO.Converter;
using StackExchange.Redis;

namespace RedisIO.Services
{
    /// <summary>
    /// Class <c>RedisIOService</c> is used to save and get data from redis database.
    /// </summary>
    public class RedisIOService : IRedisIOService
    {
        private readonly IRedisConverter _converter;
        private readonly ConnectionMultiplexer _muxer;

        internal RedisIOService() {}

        public RedisIOService(ConfigurationOptions configuration, IRedisConverter converter)
        {
            _converter = converter;
            _muxer = ConnectionMultiplexer.Connect(configuration);
        }

        /// <inheritdoc cref="IRedisIOService.AddAsync{T}"/>
        public async Task<bool> AddAsync<T>(string key, T value)
        {
            var db = _muxer.GetDatabase();
            return await db.StringSetAsync(key, _converter.Encode(value));
        }

        /// <inheritdoc cref="IRedisIOService.GetAsync{T}"/>
        public async Task<T> GetAsync<T>(string key)
        {
            var db = _muxer.GetDatabase();
            var result = await db.StringGetAsync(key);
            return result.IsNull ? default : _converter.Decode<T>(result);
        }
    }
}




