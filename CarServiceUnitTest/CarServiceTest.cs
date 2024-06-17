using AutoMapper;
using Cars.Database.Database;
using Cars.Database.Entities;
using Cars.Domain.Models;
using Cars.Domain.Parameters;
using Cars.Domain.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;

namespace CarServiceUnitTest;

public class CarServiceTest
{
    private Mock<DatabaseContext> _mockContext;
    private Mock<IMapper> _mockMapper;
    private CarService _carService;

    [SetUp]
    public void Setup()
    {
        _mockContext = new Mock<DatabaseContext>();
        _mockMapper = new Mock<IMapper>();
        _carService = new CarService(_mockContext.Object, _mockMapper.Object);
    }

    [Test]
    public async Task GetAll()
    {
        var cars = new List<Car>
        {
            new Car { Id = 1, Model = "Model 1" },
            new Car { Id = 2, Model = "Model 2" }
        };

        var carModels = new List<CarModel>
        {
            new CarModel { Id = 1, Model = "Model1" },
            new CarModel { Id = 2, Model = "Model2" }
        };

        _mockContext.SetupDbSet(cars);
        _mockMapper.Setup(m => m.Map<List<CarModel>>(It.IsAny<List<Car>>())).Returns(carModels);

        var result = await _carService.GetAll();
        
        Assert.AreEqual(2, result.Count);
        Assert.AreEqual("Model1", result[0].Model);
        Assert.AreEqual("Model2", result[1].Model);
    }

    [Test]
    public async Task Get_ReturnsCarModel_WhenCarExists()
    {
        var car = new Car { Id = 1, Model = "Model1" };
        var carModel = new CarModel { Id = 1, Model = "Model1" };

        _mockContext.SetupDbSet(new List<Car> { car });
        _mockMapper.Setup(m => m.Map<CarModel>(It.IsAny<Car>())).Returns(carModel);

        var result = await _carService.Get(1);
        
        Assert.IsNotNull(result);
        Assert.AreEqual("Model1", result.Model);
    }
    
    [Test]
    public async Task Get_ReturnsNull_WhenCarDoesNoExists()
    {
        var result = await _carService.Get(999);
        
        Assert.IsNull(result);
    }

    [Test]
    public async Task AddCar()
    {
        var createParams = new CarCreateParameters
        {
            Model = "Model1",
            Year = 2020
        };

        _mockContext.Setup(c => c.Cars.AddAsync(It.IsAny<Car>(), It.IsAny<CancellationToken>()))
            .Returns(new ValueTask<EntityEntry<Car>>(Task.FromResult(Mock.Of<EntityEntry<Car>>())));


        // Act
        await _carService.Add(createParams);

        // Assert
        _mockContext.Verify(c => c.Cars.AddAsync(It.IsAny<Car>(), default), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }
    
    [Test]
    public async Task Update_UpdatesCar_WhenCarExists()
    {
        var updateParams = new CarUpdateParameters
        {
            Model = "UpdatedModel",
            Year = 2021
        };

        var car = new Car { Id = 1, Model = "Model1", Year = 2020 };

        _mockContext.SetupDbSet(new List<Car> { car });
        _mockContext.Setup(c => c.Cars.FindAsync(It.IsAny<int>())).ReturnsAsync(car);
        
        await _carService.Update(1, updateParams);
        
        Assert.AreEqual(updateParams.Model, car.Model);
        Assert.AreEqual(updateParams.Year, car.Year);
        _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
    }
}