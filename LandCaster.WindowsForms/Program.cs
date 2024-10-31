using LandCaster.DAL;
using LandCaster.BLL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using LandCaster.Entitites.Entities;


namespace LandCaster.WindowsForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {  // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            var frmLogin = host.Services.GetRequiredService<FrmLogin>();
            Application.Run(frmLogin);
        }
        static IHostBuilder CreateHostBuilder()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseSqlServer(connectionString);
                        options.UseSqlServer(connectionString, sqlServer => sqlServer.UseNetTopologySuite());

                    });
                    services.RegisterBLLDependencies(context.Configuration);
                    services.AddTransient<FrmLogin>();
                    //services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    //         .AddEntityFrameworkStores<ApplicationDbContext>();


                });
        }
    }
}