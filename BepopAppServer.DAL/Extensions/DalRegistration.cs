using BepopAppServer.DAL.Context;
using BepopAppServer.DAL.Repositories;
using BepopAppServer.DAL.Repositories.SongRepositories;
using BepopAppServer.DAL.UOF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BepopAppServer.DAL.Extensions
{
    public static class DalRegistration
    {
        public static IServiceCollection ServicesDalRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlConnection"));
            });

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ISongRepository, SongRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
