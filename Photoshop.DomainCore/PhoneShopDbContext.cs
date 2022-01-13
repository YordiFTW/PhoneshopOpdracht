using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phoneshop.Domain.Objects;

namespace Phoneshop.Domain
{
    public class PhoneShopDbContext : DbContext
    {
        public PhoneShopDbContext(DbContextOptions<PhoneShopDbContext> options)
            : base(options)
        {

        }

        public PhoneShopDbContext()
        {

        }
      

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Phone> Phones { get; set; }
    }
}
