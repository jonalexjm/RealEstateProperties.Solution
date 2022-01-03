using Moq;
using NUnit.Framework;
using RealEstateProperties.Core.CustomEntities;
using RealEstateProperties.Core.DTOs;
using RealEstateProperties.Core.Entitites;
using RealEstateProperties.Core.Interfaces;
using RealEstateProperties.Core.Interfaces.Repositories;
using RealEstateProperties.Core.Interfaces.Services;
using RealEstateProperties.Core.QueryFilters;
using RealEstateProperties.Infrastructure.Data;
using RealEstateProperties.Infrastructure.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateProperties.UnitTests.Project_Infrastucture.Services
{
    public class PropertyServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

       
        [Test]
        public async Task Verify_PropertyService_Given_Property_Id_Should_Get_Property()
        {
            var fakeProperty = new Property()
            {

                IdProperty = 2,
                Name = "Edificio miraflores",
                Address = "Calle la Primavera",
                Price = 5500000,
                CodeInternal = "0001254fasd",
                Year = 1985,
                IdOwner = 4

            };
       
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.PropertyRepository.GetById(2)).ReturnsAsync(fakeProperty);

            IPropertyService propertyService = new PropertyService(unitOfWorkMock.Object);

            //Act
            var actual = await propertyService.GetProperty(2);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual, fakeProperty);
        }

        [Test]
        public async Task Verify_PropertyService_return_result_When_Apply_filter()
        {
            var fakeProperties = new List<Property>
            {
                new Property 
                {
                    IdProperty = 2,
                    Name = "Edificio miraflores",
                    Address = "Calle la Primavera",
                    Price = 5500000,
                    CodeInternal = "0001254fasd",
                    Year = 1985,
                    IdOwner = 4
                },
                new Property 
                {
                    IdProperty = 3,
                    Name = "Edificio El Prado",
                    Address = "Calle Wave Way",
                    Price = 2589555,
                    CodeInternal = "23454fdfdf",
                    Year = 2018,
                    IdOwner = 1
                },
                new Property
                {
                    IdProperty = 4,
                    Name = "Casa Oriente",
                    Address = "Calle sin sentido",
                    Price = 1000000,
                    CodeInternal = "56dfdfdfdfd",
                    Year = 2020,
                    IdOwner = 3
                }

            };
            var fakePropertiesFilters = fakeProperties.Where(x => x.IdProperty == 2).ToList();

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            IEnumerable<Property> fakePropertiesIEnumerable = fakeProperties;
            unitOfWorkMock.Setup(m => m.PropertyRepository.GetAll()).Returns(fakePropertiesIEnumerable);

            IPropertyService propertyService = new PropertyService(unitOfWorkMock.Object);

            var oPropertyQueryFilter = new PropertyQueryFilter()
            {
                IdProperty = 2,
                PageSize = 10,
                PageNumber = 1
            };

            //PagedList<Property> actualResultPaged = fakePropertyVerify;
            var pagedProperties = PagedList<Property>.Create(fakePropertiesFilters, 1, 10);


            //Act
            var actual = await propertyService.GetAllProperty(oPropertyQueryFilter);

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsNotEmpty(actual);
            Assert.AreEqual(fakePropertiesFilters, actual);



        }
    }

    
}
