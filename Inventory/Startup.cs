using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    public IConfigurationRoot Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
    }

    public void Configure(IApplicationBuilder app)
    {
      app.UseDeveloperExceptionPage();
      app.UseRouting();
      app.UseEndpoints(routes =>{
        routes.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
      });
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("<h1>Hello World!</h1>");
      });
    }
  }
    public static class DBConfiguration
    {
      public static string ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=Accounts_And_Inventories;";
    }
}