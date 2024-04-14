using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoyalLibrary.Domain.Repositories.Interface;
using RoyalLibrary.Domain.Repositories.Interface.Book;
using RoyalLibrary.Infrastructure.Data.Context;
using RoyalLibrary.Infrastructure.Data.Repositories.Cars;


namespace RoyalLibrary.CrossCutting.IoC
{
    public static class Bootstrapper
    {
        public static IServiceCollection ConfiguraInjecaoDependencia(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddTransient<IBookRepository, BookRepository>();

            services.AddMvc().AddJsonOptions(c => c.JsonSerializerOptions.PropertyNamingPolicy = null);            

            services.AddTransient<IContext>(d => new DapperContext(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
