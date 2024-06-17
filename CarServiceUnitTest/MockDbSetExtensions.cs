using Cars.Database.Database;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace CarServiceUnitTest;

public static class MockDbSetExtensions
{
    public static void SetupDbSet<T>(this Mock<DbSet<T>> mockSet, List<T> data) where T : class
    {
        var queryable = data.AsQueryable();
        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());
    }

    public static void SetupDbSet<T>(this Mock<DatabaseContext> mockContext, List<T> data) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();
        mockSet.SetupDbSet(data);
        mockContext.Setup(c => c.Set<T>()).Returns(mockSet.Object);
    }
}