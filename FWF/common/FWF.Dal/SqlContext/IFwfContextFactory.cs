using FWF.Dal.Models;

namespace FWF.Dal.SqlContext
{
    public interface IFwfContextFactory
    {
        FwfDbContext CreateContext();
    }
}
