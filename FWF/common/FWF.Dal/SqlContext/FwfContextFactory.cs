using FWF.Dal.Models;
using Microsoft.EntityFrameworkCore;
namespace FWF.Dal.SqlContext
{
    public class FwfContextFactory(string connectionString) : IFwfContextFactory
    {
        public FwfDbContext CreateContext()
        {
            var opt = new DbContextOptionsBuilder<FwfDbContext>().UseSqlServer(connectionString).Options;
            return new FwfDbContext(opt);
        }
    }
}
