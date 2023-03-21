using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SRP.OpenLibrary
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMyLibraryService(
          this IServiceCollection services,
          IConfiguration namedConfigurationSection)
        {
            services.Configure<OpenLibrarySettings>(namedConfigurationSection);
            RegisterDependencies(services);

            return services;
        }

        public static IServiceCollection AddMyLibraryService(
        this IServiceCollection services)
        {
            services.AddTransient((t) => new OpenLibrarySettings());
            RegisterDependencies(services);

            return services;
        }

        private static void RegisterDependencies(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddTransient<IBookFactory, BookFactory>();
            services.AddTransient<IOpenLibraryClient, OpenLibraryClient>();
        }
    }
}