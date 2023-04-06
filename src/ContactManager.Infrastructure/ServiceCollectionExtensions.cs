using ContactManager.Application.Contacts;
using ContactManager.Infrastructure.Data;
using ContactManager.Infrastructure.Data.ContactReads;
using ContactManager.Infrastructure.Messaging;
using ContactManager.Infrastructure.Messaging.Consumer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManager.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            return services
                .Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.DefaultKey))
                .AddEntityFrameworkDbContext(configuration.GetSection(DatabaseOptions.DefaultKey))
                .AddEntityFrameworkRepositories();
        }

        public static IServiceCollection AddMessagePublisherServices(
                this IServiceCollection services,
                IConfiguration configuration)
        {
            return services
                .Configure<MessagingOptions>(configuration.GetSection(MessagingOptions.DefaultKey))
                .AddScoped<IContactMessagePublisher, ContactMessagePublisher>();
        }

        public static IServiceCollection AddMessageConsumer<TMessageProcessor>(
                this IServiceCollection services,
                IConfiguration configuration) where TMessageProcessor : class, IMessageProcessor
        {
            return services
                .Configure<MessagingOptions>(configuration.GetSection(MessagingOptions.DefaultKey))
                .AddScoped<IMessageProcessor, TMessageProcessor>()
                .AddSingleton<IMessageConsumerService, MessageConsumerService>()
                .AddHostedService<MessageConsumer>();
        }

        private static IServiceCollection AddEntityFrameworkDbContext(
                        this IServiceCollection services,
                        IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                {
                    options.UseSqlServer(configuration["ConnectionString"]);
                });

            return services;
        }

        private static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IContactReadRepository, ContactReadRepository>();

            return services;
        }
    }
}
