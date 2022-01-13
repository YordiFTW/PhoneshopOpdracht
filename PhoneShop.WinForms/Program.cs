using Microsoft.Extensions.DependencyInjection;

using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Bussiness.Logic;
using Phoneshop.Bussiness.Logic.Repositories;
using Microsoft.Extensions.Hosting;
using Phoneshop.Domain;
using Phoneshop.Domain.Objects;

namespace Phoneshop.WinForms
{


    internal static class Program
    {
       

        [STAThread]

        

        static void Main(string[] args)
        {
            var builder = CreateHostBuilder(args).Build();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Application.Run(builder.Services.GetRequiredService<PhoneOverview>());

        }

       


        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddDbContext<PhoneShopDbContext>(options =>
                    options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PhoneShopDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;"));
                services.AddScoped<IPhoneService, PhoneService>();
                services.AddScoped<IBrandService, BrandService>();

                services.AddScoped<IGenericRepository<Brand>, GenericRepository<Brand>>();
                services.AddScoped<IGenericRepository<Phone>, GenericRepository<Phone>>();

                services.AddScoped(typeof(IRepository<>), typeof(AdoRepository<>));
                services.AddScoped<IXmlService, XmlService>();

                services.AddScoped<PhoneOverview>();

            });
    }
}
