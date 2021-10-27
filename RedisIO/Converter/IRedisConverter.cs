namespace RedisIO.Converter
{
    /// <summary>
    /// Interface <c>IRedisConverter</c> is used to convert data before storing in redis.
    /// </summary>
    public interface IRedisConverter
    {
        /// <summary>
        /// Encodes value of type T to string for redis storage
        /// </summary>
        /// <param name="value">Value</param>
        /// <typeparam name="T">Value type</typeparam>
        /// <returns>Encoded string vaule</returns>
        string Encode<T>(T value);

        /// <summary>
        /// Decodes value from string to type T
        /// </summary>
        /// <param name="value">String value</param>
        /// <typeparam name="T">Return type</typeparam>
        /// <returns>Value decoded to type of T</returns>
        T Decode<T>(string value);

    }
}
