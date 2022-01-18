
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Phoneshop.Bussiness.Logic.Extensions;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Objects;


namespace Phoneshop.Bussiness.Logic
{
    public class BrandService : IBrandService
    {
        private readonly IRepository<Brand> brandRepository;
        private readonly IGenericRepository<Brand> gbrandRepository;
        
        public BrandService(IRepository<Brand> brandRepository, IGenericRepository<Brand> gbrandRepository)
        {
            this.brandRepository = brandRepository;
            this.gbrandRepository = gbrandRepository;
            this.brandRepository.Mapper = PhoneMapper;
        }


        
        public Brand GetOrCreate(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            Brand result = gbrandRepository.GetAll().SingleOrDefault(x => x.Name == name);

            if (result == null)
            {
               Brand brand = Create(new Brand { Name = name } );
                return brand;
            }

            return result;
        }

        
        public Brand Create(Brand brand)
        {
            gbrandRepository.Insert(brand);
            gbrandRepository.Save();

            return brand;
        }

        [ExcludeFromCodeCoverage]
        public static Brand PhoneMapper(SqlDataReader reader)
        {
            return new()
            {
                Id = reader.GetInt("Id"),
                Name = reader.GetString("Name"),
            };
        }
    }
}
