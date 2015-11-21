using Business;
using Entities;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Runtime;
using Repository;
using System.Globalization;

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

            var dataDirectory = System.IO.Path.GetFullPath(appEnv.ApplicationBasePath + "\\..\\..\\artifacts\\bin\\WebApplication1\\Database");
            System.AppDomain.CurrentDomain.SetData("DataDirectory", dataDirectory);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().ConfigureMvc(options => { options.SerializerSettings.Culture = new CultureInfo("pt-BR"); });

            services.AddInstance<IDbSettings>(new DbSettings() { ConnectionString = Configuration["Data:DefaultConnection:ConnectionString"] });
            services.AddTransient<Repository.WebApplication1DbContext>();

            services.AddTransient<IRepository<Despesa>, DespesaRepository>();
            services.AddTransient<IRepository<Receita>, ReceitaRepository>();

            services.AddTransient<IDespesaBusiness, DespesaBusiness>();
            services.AddTransient<IReceitaBusiness, ReceitaBusiness>();            
        }

        public void Configure(IApplicationBuilder app)
        { 
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");                
            });            
        }        
    }    
}
