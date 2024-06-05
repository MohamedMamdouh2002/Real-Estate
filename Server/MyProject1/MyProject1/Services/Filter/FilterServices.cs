using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProject.Services.RealEStatesServices;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Filter;
using MyProject1.Models;
using MyProject1.Services.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MyProject1.Services.Filter
{
    public class FilterServices : IFilterServices
    {
        private readonly IFilterStrategyFactory _filterStrategyFactory;
        private readonly ApplicationDbContext _context;

        private readonly IRealEStateServices _realEStateServices;
        private readonly IMapper _mapper;
        public FilterServices(IFilterStrategyFactory filterStrategyFactory, IRealEStateServices realEStateServices, ApplicationDbContext context)
        {
            _filterStrategyFactory = filterStrategyFactory;
            _realEStateServices = realEStateServices;
            _context = context;
        }

        public async Task<IEnumerable<RealEStateReturnDto>> Filter(RealEStateFilter filter)
        {


            var query = _context.RealEStates.Include(D => D.RealStatesType).Include(p => p.Compound)
               .Select(d => new RealEStateReturnDto
               {
                   Area = d.Compound.Area,
                   Bathtrooms = d.Bathtrooms,
                   Bedrooms = d.Bedrooms,
                   BUA = d.BUA,
                   CompoundName = d.Compound.Name,
                   DeliveryIn = d.DeliveryIn,
                   Finish = d.Finish,
                   DeveloperName = d.Compound.Developer.Name,
                   GardienArea = d.GardienArea,
                   Government = d.Compound.Goverment,
                   Price = d.Price,
                   RoofPentHouse = d.RoofPentHouse,
                   WithGardien = d.WithGardien,
                   WithRoof = d.WithRoof

               });
            if (filter is not null)
            {
                var filterStrategies = _filterStrategyFactory.GetFilterStrategies(filter);
                foreach (var strategy in filterStrategies)
                {
                    query = strategy.ApplyFilter(query);
                }
            }

            var filteredCars = await query.ToListAsync();
            return filteredCars;
        }
    }
}

