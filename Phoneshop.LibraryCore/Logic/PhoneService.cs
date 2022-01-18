
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Phoneshop.Bussiness.Logic.Extensions;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Objects;


namespace Phoneshop.Bussiness.Logic
{
    public class PhoneService : IPhoneService
    {

        private readonly IRepository<Phone> phoneRepository;
        private readonly IBrandService brandService;
        private readonly IGenericRepository<Phone> gphoneRepository;
        private readonly IGenericRepository<Brand> gbrandRepository;

        public PhoneService(IRepository<Phone> phoneRepository, IBrandService brandService, IGenericRepository<Phone> gphoneRepository, IGenericRepository<Brand> gbrandRepository)
        {
            this.phoneRepository = phoneRepository;
            this.brandService = brandService;
            this.gphoneRepository = gphoneRepository;
            this.gbrandRepository = gbrandRepository;
            phoneRepository.Mapper = PhoneMapper;
        }


        public Phone Get(int id)
        {
            if (id <= 0) return null;

            return gphoneRepository.GetById(id);
        }

        public IEnumerable<Phone> Get()
        {
            gbrandRepository.GetAll();
            return gphoneRepository.GetAll();
        }

        public IEnumerable<Phone> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentNullException(nameof(query));

            
            gbrandRepository.GetAll();
            

            return gphoneRepository.GetAll().Where(x => x.FullName.Contains(query));
        }


        public Phone Create(Phone phone)
        {
            var found = gphoneRepository.GetAll().SingleOrDefault(x => x.FullName == phone.FullName);

            if (found != null)
                throw new Exception($"Phone {phone.Brand.Name} - {phone.Type} already exists");

            var brand = brandService.GetOrCreate(phone.Brand.Name);

            gphoneRepository.Insert(phone);
            gphoneRepository.Save();

            return phone;
        }

        public List<Phone> Create(List<Phone> phones)
        {
            foreach (var item in phones)
                Create(item);

            return phones;
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException(nameof(id));

            gphoneRepository.DeleteById(id);
            gphoneRepository.Save();
        }

        [ExcludeFromCodeCoverage]
        public Phone PhoneMapper(SqlDataReader reader)
        {
            return new Phone()
            {
                Id = reader.GetInt("Id"),
                BrandId = reader.GetInt("brandid"),
                Description = reader.GetString("Description"),
                Price = reader.GetDouble("price"),
                Stock = reader.GetInt("stock"),
                Type = reader.GetString("Type"),
                Brand = new Brand
                {
                    Id = reader.GetInt("BrandsId"),
                    Name = reader.GetString("BrandName")
                }
            };
        }
    }
}
