using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animal.infrastructure.Entitys;
using Animal.infrastructure.Interfaces;
using Animal.infrastructure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Animal.infrastructure.Services;

namespace PostgreSQLBD
{
    public static class DIConfiguration
    {
        public static IServiceProvider GetServiceProvider()
        {
            var host = Host.CreateDefaultBuilder().ConfigureServices(services => { 
                services.AddDbContext<AnimalContext>(options => options.UseNpgsql("Host=ep-restless-bush-a8n1a3jt-pooler.eastus2.azure.neon.tech;Database=Animal;Username=Animal_owner;Password=npg_lM2mhEuYW4dN"));
                services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                services.AddScoped<SpecieService>();
                services.AddScoped<AnimalService>();
            }).Build();
            var score = host.Services.CreateScope();
            var serviceProvider = score.ServiceProvider;

            //var myRep = new Repository<Specie>(context);
            return score.ServiceProvider;
        }
    }
}
