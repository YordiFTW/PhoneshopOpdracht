using System;
using Moq;
using Phoneshop.Bussiness.Logic;
using Phoneshop.Bussiness.Logic.Repositories;
using Phoneshop.Domain.Interfaces;
using Phoneshop.Domain.Objects;
using Xunit;

namespace Phoneshop.Testsssss
{
    public class UnitTest1
    {
        

        [Fact]
        public void BrandService_Create()
        {
            var brandrepomock = new Mock<IRepository<Brand>>();
            var phonerepomock = new Mock<IRepository<Phone>>();
            var gbrandrepomock = new Mock<IGenericRepository<Brand>>();
            var gphonerepomock = new Mock<IGenericRepository<Phone>>();

            var brandService = new BrandService(brandrepomock.Object, gbrandrepomock.Object);

            Brand brand = new Brand { Id = 9999, Name = "TestBrand" };

            Brand createdbrand = new Brand();

            createdbrand = brandService.Create(brand);

            Assert.Equal(createdbrand, brand);
        }

        [Fact]
        public void BrandService_GetorCreate_NullError()
        {
            var brandrepomock = new Mock<IRepository<Brand>>();
            var phonerepomock = new Mock<IRepository<Phone>>();
            var gbrandrepomock = new Mock<IGenericRepository<Brand>>();
            var gphonerepomock = new Mock<IGenericRepository<Phone>>();


            var brandService = new BrandService(brandrepomock.Object, gbrandrepomock.Object);

            Assert.Throws<ArgumentNullException>(() => brandService.GetOrCreate(""));
        }

        [Fact]
        public void PhoneService_Create()
        {
            var brandrepomock = new Mock<IRepository<Brand>>();
            var phonerepomock = new Mock<IRepository<Phone>>();
            var gbrandrepomock = new Mock<IGenericRepository<Brand>>();
            var gphonerepomock = new Mock<IGenericRepository<Phone>>();

            var brandService = new BrandService(brandrepomock.Object, gbrandrepomock.Object);
            var phoneService = new PhoneService(phonerepomock.Object, brandService, gphonerepomock.Object, gbrandrepomock.Object);

            Brand brand = new Brand { Id = 9999, Name = "TestBrand" };
            Phone phone = new Phone { Brand = brand, BrandId = 9999, Description = "idc", Id = 9999, Price = 10, Stock = 5, Type = "whatever" };
            Phone createdphone = new Phone();


            createdphone = phoneService.Create(phone);

            Assert.Equal(createdphone, phone);
        }

        [Fact]
        public void PhoneService_Get_ReturnNull()
        {
            var brandrepomock = new Mock<IRepository<Brand>>();
            var phonerepomock = new Mock<IRepository<Phone>>();
            var gbrandrepomock = new Mock<IGenericRepository<Brand>>();
            var gphonerepomock = new Mock<IGenericRepository<Phone>>();

            var brandService = new BrandService(brandrepomock.Object, gbrandrepomock.Object);
            var phoneService = new PhoneService(phonerepomock.Object, brandService, gphonerepomock.Object, gbrandrepomock.Object);

            Brand brand = new Brand { Id = 9999, Name = "TestBrand" };
            Phone phone = new Phone { Brand = brand, BrandId = 9999, Description = "idc", Id = 9999, Price = 10, Stock = 5, Type = "whatever" };
            Phone getphone = new Phone();


            getphone = phoneService.Get(0);

            Assert.Null(getphone);
        }

        [Fact]
        public void PhoneService_Search_NullError()
        {
            var brandrepomock = new Mock<IRepository<Brand>>();
            var phonerepomock = new Mock<IRepository<Phone>>();
            var gbrandrepomock = new Mock<IGenericRepository<Brand>>();
            var gphonerepomock = new Mock<IGenericRepository<Phone>>();

            var brandService = new BrandService(brandrepomock.Object, gbrandrepomock.Object);
            var phoneService = new PhoneService(phonerepomock.Object, brandService, gphonerepomock.Object, gbrandrepomock.Object);

            Brand brand = new Brand { Id = 9999, Name = "TestBrand" };
            Phone phone = new Phone { Brand = brand, BrandId = 9999, Description = "idc", Id = 9999, Price = 10, Stock = 5, Type = "whatever" };
            Phone getphone = new Phone();           

            Assert.Throws<ArgumentNullException>(() => phoneService.Search(""));
        }

        [Fact]
        public void PhoneService_Delete_NullError()
        {
            var brandrepomock = new Mock<IRepository<Brand>>();
            var phonerepomock = new Mock<IRepository<Phone>>();
            var gbrandrepomock = new Mock<IGenericRepository<Brand>>();
            var gphonerepomock = new Mock<IGenericRepository<Phone>>();

            var brandService = new BrandService(brandrepomock.Object, gbrandrepomock.Object);
            var phoneService = new PhoneService(phonerepomock.Object, brandService, gphonerepomock.Object, gbrandrepomock.Object);

            Brand brand = new Brand { Id = 9999, Name = "TestBrand" };
            Phone phone = new Phone { Brand = brand, BrandId = 9999, Description = "idc", Id = 9999, Price = 10, Stock = 5, Type = "whatever" };
            Phone getphone = new Phone();

            Assert.Throws<ArgumentNullException>(() => phoneService.Delete(0));
        }

        //[Fact]
        //public void PhoneService_Create()
        //{
        //    var phoneService = new PhoneService(_phoneRepo, brandService, _gphoneRepo, _gbrandRepo);
        //    GenericRepository<Phone> phoneRepository = new();

        //    Brand brand = new Brand { Id = 9999, Name = "TestBrand" };
        //    Phone phone = new Phone { Id = 9999, BrandId = 9999, Brand = brand, Description = "TestDescription", Price = 99, Stock = 99, Type = "TestType" };

        //    phoneService.Create(phone);

        //    Assert.Equal(phone, phoneRepository.GetById(brand.Id));
        //}
    }
}