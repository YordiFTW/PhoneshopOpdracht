using Microsoft.Extensions.DependencyInjection;

using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Bussiness.Logic;
using Phoneshop.Bussiness.Logic.Repositories;

namespace Phoneshop.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();

            ConfigureServices(services);



            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
                Application.Run(serviceProvider.GetRequiredService<PhoneOverview>());
        }

       


        private static void ConfigureServices(ServiceCollection services)
        {
            

            

            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddSingleton(typeof(IRepository<>), typeof(AdoRepository<>));

            services.AddScoped<PhoneOverview>();
        }
    }
}
