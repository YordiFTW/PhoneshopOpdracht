using System;
using Phoneshop.Bussiness.Logic;
using Phoneshop.Bussiness.Logic.Repositories;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Objects;

using Xunit;

namespace Phoneshop.Testsss
{
    public class UnitTest1
    {
        private readonly IGenericRepository<Brand> _gbrandRepo;
        private readonly IGenericRepository<Phone> _gphoneRepo;
        private readonly IRepository<Phone> _phoneRepo;
        private readonly IRepository<Brand> _brandRepo;
        private readonly IBrandService brandService;  

        [Fact]
        public void BrandService_Create()
        {
            var brandService = new BrandService(_brandRepo, _gbrandRepo);
            GenericRepository<Brand> brandRepository = new();

            Brand brand = new Brand { Id = 9999, Name = "TestBrand" };

            brandService.Create(brand);

            Assert.Equal(brand, brandRepository.GetById(brand.Id));
        }

        [Fact]
        public void PhoneService_Create()
        {
            var phoneService = new PhoneService(_phoneRepo, brandService, _gphoneRepo, _gbrandRepo);
            GenericRepository<Phone> phoneRepository = new();

            Brand brand = new Brand { Id = 9999, Name = "TestBrand" };
            Phone phone = new Phone { Id = 9999, BrandId = 9999, Brand = brand, Description = "TestDescription", Price = 99, Stock = 99, Type = "TestType" };

            phoneService.Create(phone);

            Assert.Equal(phone, phoneRepository.GetById(brand.Id));
        }
    }
}
