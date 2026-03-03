using Microsoft.Extensions.DependencyInjection;
using FluentValidation;

namespace BepopAppServer.Business.Extensions
{
    public static class BusinessRegistration
    {
        public static IServiceCollection ServicesBusinessRegistration(this IServiceCollection services)
        {
            services.Scan(opt =>
                          opt.FromAssemblyOf<BusinessAssembly>()
                          .AddClasses(x => x.Where(t => t.Name.EndsWith("Service")))
                          .AsImplementedInterfaces()
                          .WithScopedLifetime());

            services.AddValidatorsFromAssembly(typeof(BusinessAssembly).Assembly);
            return services;
        }
    }
}
