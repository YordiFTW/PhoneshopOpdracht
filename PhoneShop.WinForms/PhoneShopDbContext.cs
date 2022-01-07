using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoneshop.Domain.Objects;

namespace Phoneshop.WinForms
{
    public class PhoneShopDbContext : DbContext
    {


        public DbSet<Brand> Brands { get; set; }

        public DbSet<Phone> Phones { get; set; }
    }
}
