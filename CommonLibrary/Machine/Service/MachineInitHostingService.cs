using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary.Machine.Service
{
    public class MachineInitHostingService : BackgroundService
    {
        private readonly IServiceScopeFactory scopeFactory;
        public MachineInitHostingService(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var machineService = scope.ServiceProvider.GetRequiredService<IMachineService>();
                await machineService.InitAllMachinesFromDB();
            }
        }
    }
}
