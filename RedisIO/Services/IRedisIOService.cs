using System.Threading.Tasks;

namespace RedisIO.Services
{
    /// <summary>
    /// Interface <c>IRedisIOService</c> is used to save and get data from redis database.
    /// </summary>
    public interface IRedisIOService
    {
        /// <summary>
        /// Method <c>AddAsync</c> adds a key value pair to a redis database.
        /// If a pair with current key already exists, rewrites value of that pair.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">Value</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>True if the value was set, false otherwise</returns>
        Task<bool> AddAsync<T>(string key, T value);

        /// <summary>
        /// Method <c>GetAsync</c> gets a value by a key from a redis database.
        /// If a key doesn't exist, returns default value.
        /// </summary>
        /// <param name="key">Key</param>
        /// <typeparam name="T">Value Type</typeparam>
        /// <returns>The value of key, or default when key does not exist.</returns>
        Task<T> GetAsync<T>(string key);
    }
}
