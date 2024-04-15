using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoyalLibrary.Domain.Handlers;
using RoyalLibrary.Domain.Repositories.Interface;
using RoyalLibrary.Domain.Repositories.Interface.Books;
using RoyalLibrary.Infrastructure.Data.Context;
using RoyalLibrary.Infrastructure.Data.Repositories.Books;


namespace RoyalLibrary.CrossCutting.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection DependencyInjectionSetup(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<BookHandler>();

            services.AddMvc().AddJsonOptions(c => c.JsonSerializerOptions.PropertyNamingPolicy = null);            

            services.AddTransient<IContext>(d => new DapperContext(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
