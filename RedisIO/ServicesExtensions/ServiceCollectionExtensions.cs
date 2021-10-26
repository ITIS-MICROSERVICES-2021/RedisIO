using Microsoft.Extensions.DependencyInjection;
using RedisIO.Services;
using StackExchange.Redis;

namespace RedisIO.ServicesExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRedisIO(this IServiceCollection services, string configuration = "localhost")
        {
            var redis = new RedisIOService(configuration);
            services.AddSingleton<IRedisIOService>(redis);
        }
    }
}
