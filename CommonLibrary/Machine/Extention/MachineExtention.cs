using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CommonLibrary.Machine.Service;

namespace CommonLibrary.Machine
{
    public static class MachineExtention
    {
        public static IHostApplicationBuilder AddMachineService(this IHostApplicationBuilder builder, string dbConnectionStringName = "DefaultConnection")
        {
            builder.Services.AddDbContextFactory<MachineDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString(dbConnectionStringName));
            });
            builder.Services.AddSingleton<IMachineService, MachineService>();
            builder.Services.AddHostedService<MachineInitHostingService>();
            builder.Services.AddLocalization();
            return builder;
        }
    }
}
