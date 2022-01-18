using System;
using System.Collections.Generic;
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
        public void BrandService_GetOrCreate()
        {
            var brandrepomock = new Mock<IRepository<Brand>>();
            var phonerepomock = new Mock<IRepository<Phone>>();
            var gbrandrepomock = new Mock<IGenericRepository<Brand>>();
            var gphonerepomock = new Mock<IGenericRepository<Phone>>();

            var brandService = new BrandService(brandrepomock.Object, gbrandrepomock.Object);

            Brand brand = new Brand {  Name = "test" };

            Brand createdbrand = new Brand();

            createdbrand = brandService.GetOrCreate(brand.Name);

            Assert.Equal(createdbrand.Name, brand.Name);
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
        public void PhoneService_GetAll()
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
            IEnumerable<Phone> phones;
            IEnumerable<Phone> expected = new Phone[0];
            phones = phoneService.Get();

            Assert.Equal(expected, phones);
        }

        [Fact]
        public void PhoneService_Search()
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
            IEnumerable<Phone> phones;
            IEnumerable<Phone> expected = new Phone[0];
            phones = phoneService.Search("1");

            Assert.Equal(expected, phones);
        }

        [Fact]
        public void PhoneService_CreatePhones()
        {
            var brandrepomock = new Mock<IRepository<Brand>>();
            var phonerepomock = new Mock<IRepository<Phone>>();
            var gbrandrepomock = new Mock<IGenericRepository<Brand>>();
            var gphonerepomock = new Mock<IGenericRepository<Phone>>();

            var brandService = new BrandService(brandrepomock.Object, gbrandrepomock.Object);
            var phoneService = new PhoneService(phonerepomock.Object, brandService, gphonerepomock.Object, gbrandrepomock.Object);

            Brand brand = new Brand { Id = 9999, Name = "TestBrand" };
            Phone phone1 = new Phone { Brand = brand, BrandId = 9999, Description = "idc", Id = 9999, Price = 10, Stock = 5, Type = "whatever" };
            Phone phone2 = new Phone { Brand = brand, BrandId = 9999, Description = "idc", Id = 9998, Price = 10, Stock = 5, Type = "whatever" };
            Phone getphone = new Phone();
            List<Phone> expected = new List<Phone>(); ;
            List<Phone> phones = new List<Phone>();

            phones.Add(phone1);
            phones.Add(phone2);

            expected = phoneService.Create(phones);

            Assert.Equal(expected, phones);
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