using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Repository;
using Microsoft.Framework.Configuration;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Runtime;
using Business;
using Entities;

namespace WebApplication1
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath);
            builder.AddJsonFile("config.json");
            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();                        

            services.AddInstance<IDbSettings>(new DbSettings() { ConnectionString = Configuration["Data:DefaultConnection:ConnectionString"] });
            services.AddTransient<WebApplication1DbContext>();

            services.AddTransient<IRepository<Despesa>, DespesaRepository>();
            services.AddTransient<IRepository<Receita>, ReceitaRepository>();

            services.AddTransient<IDespesaBusiness, DespesaBusiness>();
            services.AddTransient<IReceitaBusiness, ReceitaBusiness>();            
        }

        public void Configure(IApplicationBuilder app)
        {            
            app.UseMvc(routes => {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
