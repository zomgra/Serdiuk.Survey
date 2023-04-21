using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serdiuk.Survey.Application.Common.Interfaces;
using Serdiuk.Survey.Infrastructure.Persistance;

namespace Serdiuk.Survey.Infrastructure
{
    public static class DI
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(c => c.UseInMemoryDatabase("DDEV"));

            services.AddTransient<IAppDbContext, AppDbContext>();

            return services;
        }
    }
}
