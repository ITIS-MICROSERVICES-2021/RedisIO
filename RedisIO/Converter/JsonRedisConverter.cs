using Newtonsoft.Json;

namespace RedisIO.Converter
{
    /// <summary>
    /// Class <c>JsonRedisConverter</c> is used to convert data to Json before storing in redis.
    /// </summary>
    public class JsonRedisConverter : IRedisConverter
    {
        /// <summary>
        /// Encodes value of type T to json string for redis storage
        /// </summary>
        /// <param name="value">Value</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>Json string vaule</returns>
        public string Encode<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// Decodes value from Json to type T
        /// </summary>
        /// <param name="value">Json value</param>
        /// <typeparam name="T">Return type</typeparam>
        /// <returns>Value decoded to type of T</returns>
        public T Decode<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
