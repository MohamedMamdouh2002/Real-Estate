using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class GardinAreaFilterStrategy : IFilterStrategy
    {
        private readonly double? _gardinArea;

        public GardinAreaFilterStrategy(double? gardinArea)
        {
            _gardinArea = gardinArea;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(p => p.GardienArea <= _gardinArea);
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return filter.GardienArea.HasValue;
        }
    }
}
