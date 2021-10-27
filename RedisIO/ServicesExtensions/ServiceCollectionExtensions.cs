using System;
using Microsoft.Extensions.DependencyInjection;
using RedisIO.Converter;
using RedisIO.Services;
using StackExchange.Redis;

namespace RedisIO.ServicesExtensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Configures redis multiplexer and adds RedisIOService to dependency injection
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <typeparam name="TConverter">Redis converter type</typeparam>
        public static void AddRedisIO<TConverter>(this IServiceCollection services, Action<RedisOptionsBuilder<TConverter>> optionsAction) where TConverter : IRedisConverter
        {
            var builder = new RedisOptionsBuilder<TConverter>();
            optionsAction(builder);
            var converter = builder.Factory.Invoke();
            var redis = new RedisIOService(builder.Configuration, converter);
            services.AddSingleton<IRedisIOService>(redis);
        }

        public static RedisOptionsBuilder<JsonRedisConverter> UseJsonConverter(this RedisOptionsBuilder<JsonRedisConverter> builder)
        {
            builder.UseCustomConverter(() => new JsonRedisConverter());
            return builder;
        }
    }

    public class RedisOptionsBuilder<TConverter>
    {
        public Func<TConverter> Factory;
        public ConfigurationOptions Configuration;

        public RedisOptionsBuilder<TConverter> UseCustomConverter(Func<TConverter> factory)
        {
            Factory = factory;
            return this;
        }

        public RedisOptionsBuilder<TConverter> UseConfiguration(ConfigurationOptions configuration)
        {
            Configuration = configuration;
            return this;
        }
    }
}
