using AutoMapper;
using Cars.Database.Database;
using Cars.Database.Entities;
using Cars.Domain.Mapping;
using Cars.Domain.Models;
using Cars.Domain.Parameters;
using Cars.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace CarServiceUnitTest
{
    public class CarServiceTest
    {
        private DatabaseContext _databaseContext;
        private IMapper _mapper;
        private CarService _carService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(databaseName: "CarServiceTestDatabase")
                .Options;
            
            _databaseContext = new DatabaseContext(options);

           // var config = new MapperConfiguration(c => {
             //   c.AddProfile<CarMappingProfile>();
            //});
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Car, CarModel>(); 
            });
            _mapper = config.CreateMapper();

            _carService = new CarService(_databaseContext, _mapper);
        }

        [TearDown]
        public void TearDown()
        {
            _databaseContext.Database.EnsureDeleted();
            _databaseContext.Dispose();
        }

        [Test]
        public async Task GetAll()
        {
            var cars = new List<Car>
            {
                new Car { Id = 1, Model = "Model 1" },
                new Car { Id = 2, Model = "Model 2" }
            };

            await _databaseContext.Cars.AddRangeAsync(cars);
            await _databaseContext.SaveChangesAsync();
            
            var savedCars = await _databaseContext.Cars.ToListAsync();
            Assert.AreEqual(2, savedCars.Count);
        }

        [Test]
        public async Task Get_ReturnsCarModel_WhenCarExists()
        {
            var car = new Car { Id = 1, Model = "Model 1" };

            await _databaseContext.Cars.AddAsync(car);
            await _databaseContext.SaveChangesAsync();
            
            var carFromDb = await _databaseContext.Cars.FindAsync(1);
            Assert.IsNotNull(carFromDb, "Car was not added to the database");

            var result = await _carService.Get(1);

            Assert.IsNotNull(result, "Result from service is null");
            Assert.AreEqual("Model 1", result.Model);
        }
        
        [Test]
        public async Task Get_ReturnsNull_WhenCarDoesNotExist()
        {
            var result = await _carService.Get(999);
            
            Assert.IsNull(result);
        }

        [Test]
        public async Task AddCar()
        {
            var createParams = new CarCreateParameters
            {
                Model = "Model 1",
                Year = 2020
            };

            await _carService.Add(createParams);

            var car = await _databaseContext.Cars.SingleOrDefaultAsync(c => c.Model == "Model 1");
            Assert.IsNotNull(car);
            Assert.AreEqual(2020, car.Year);
        }

        [Test]
        public async Task Update_UpdatesCar_WhenCarExists()
        {
            var car = new Car { Id = 1, Model = "Model 1", Year = 2020 };

            await _databaseContext.Cars.AddAsync(car);
            await _databaseContext.SaveChangesAsync();

            var updateParams = new CarUpdateParameters
            {
                Model = "Updated Model",
                Year = 2021
            };

            await _carService.Update(1, updateParams);

            var updatedCar = await _databaseContext.Cars.FindAsync(1);
            Assert.AreEqual("Updated Model", updatedCar.Model);
            Assert.AreEqual(2021, updatedCar.Year);
        }
    }
}