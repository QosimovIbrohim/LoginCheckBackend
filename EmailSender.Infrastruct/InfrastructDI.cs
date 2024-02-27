using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Infrastruct.Persistence;
using EmailSender.Infrastruct.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Infrastruct
{
    public static class InfrastructDI
    {
        public static IServiceCollection AddDbAppContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(ops =>
            {
                ops.UseNpgsql(configuration.GetConnectionString(""));
            });
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            return services;
        }
    }
}
