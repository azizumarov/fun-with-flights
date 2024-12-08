using FWF.Dal.Models;
using FWF.Dal.SqlContext;
using Microsoft.EntityFrameworkCore;

namespace FWF.Dal.Tests
{
    public class FwfContextFactoryTests
    {
        [Fact]
        public void CreateContext_ShouldReturnValidDbContextInstance()
        {
            // Arrange
            var testConnectionString = "Server=(localdb)\\mssqllocaldb;Database=TestDb;Trusted_Connection=True;";
            var factory = new FwfContextFactory(testConnectionString);

            // Act
            var dbContext = factory.CreateContext();

            // Assert
            Assert.NotNull(dbContext);
            Assert.IsType<FwfDbContext>(dbContext);
            Assert.Equal(testConnectionString, dbContext.Database.GetDbConnection().ConnectionString);
        }
        
    }
}