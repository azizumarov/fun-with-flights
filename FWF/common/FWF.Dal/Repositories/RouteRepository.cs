using AutoMapper;
using FWF.Core.Domain.RepositoryInterfaces;
using FWF.Core.Helpers.QueryHelpers;
using FWF.Dal.Models;
using FWF.Dal.SqlContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Route = FWF.Core.Domain.Models.Route;

namespace FWF.Dal.Repositories
{
    public class RouteRepository(IFwfContextFactory dbFactory, IMapper mapper) : 
            BaseRepository<Route, Dal.Models.Route>(dbFactory, mapper), IRouteRepository
    {
       
    }
}
