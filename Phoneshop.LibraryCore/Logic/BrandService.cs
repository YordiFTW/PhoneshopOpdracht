
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
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

            var command = new SqlCommand("SELECT * FROM brands WHERE name = '" + name + "'");

            var result = brandRepository.GetRecord(command);

            if (result == null)
            {
                Create(new Brand { Name = name });
                return GetOrCreate(name);
            }

            return result;
        }

        public Brand GetOrCreate2(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            var result = gbrandRepository.G;

            if (result == null)
            {
                Create(new Brand { Name = name });
                return GetOrCreate(name);
            }

            return result;
        }


        public void Create(Brand brand)
        {
            gbrandRepository.Insert(brand);
            gbrandRepository.Save();
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
