using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class RoofPentHouseFilterStrategy : IFilterStrategy
    {
        private readonly double? _RoofPentHouse;

        public RoofPentHouseFilterStrategy(double? roofPentHouse)
        {
            _RoofPentHouse = roofPentHouse;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(p => p.RoofPentHouse <= _RoofPentHouse);
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return filter.RoofPentHouse.HasValue;
        }
    }
}
