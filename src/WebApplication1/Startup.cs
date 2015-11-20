using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using System.Globalization;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().ConfigureMvc(options => { options.SerializerSettings.Culture = new CultureInfo("pt-BR"); });

            services.AddInstance<Repository.IDbSettings>(new Repository.DbSettings() { ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\bitbucket\\github\\WebApplication1\\artifacts\\bin\\WebApplication1\\Database\\Database1.mdf;Integrated Security=True;" });
            services.AddTransient<Repository.WebApplication1DbContext>();

            services.AddTransient<Business.IRepository<Entities.Despesa>, Repository.DespesaRepository>();
            services.AddTransient<Business.IRepository<Entities.Receita>, Repository.ReceitaRepository>();

            services.AddTransient<Business.IDespesaBusiness, Business.DespesaBusiness>();
            services.AddTransient<Business.IReceitaBusiness, Business.ReceitaBusiness>();            
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
