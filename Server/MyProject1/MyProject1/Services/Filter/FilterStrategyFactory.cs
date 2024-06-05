using MyProject.Services.RealEStatesServices;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Filter;
using MyProject1.Models;
using static MyProject1.Services.Filter.FilterStrategyFactory;

namespace MyProject1.Services.Filter
{
    public class FilterStrategyFactory : IFilterStrategyFactory
    {
        private readonly IEnumerable<IFilterStrategy> _filterStrategies;

        public FilterStrategyFactory(IEnumerable<IFilterStrategy> filterStrategies)
        {
            _filterStrategies = filterStrategies;
        }
        public IEnumerable<IFilterStrategy> GetFilterStrategies(RealEStateFilter filter)
        {
            var strategies = new List<IFilterStrategy>
            {
                new AreaFilterStrategy(filter.Area),
                new BathRoomsFilterStrategy(filter.Bathtrooms),
                new BedroomsFilterStrategy(filter.Bedrooms),
                new BUAFilterStrategy(filter.BUA),
                new CompoundNameFilterStrategy(filter.CompoundName),
                new DeliveryInFilterStrategy(filter.DeliveryIn),
                new DeveloperNameFilterStrategy(filter.DeveloperName),
                new FinishFilterStrategy(filter.Finish),
                new GardinAreaFilterStrategy(filter.GardienArea),
                new GovernmentFilterStrategy(filter.Government),
                new PriceFilterStrategy(filter.Price),
                new RoofPentHouseFilterStrategy(filter.RoofPentHouse),
                new WithGardinFilterStrategy(filter.WithGardien),
                new WithRoofFilterStrategy(filter.WithRoof)
            };
            return strategies.Where(strategy => strategy.CanApply(filter));
        }


    }
}
