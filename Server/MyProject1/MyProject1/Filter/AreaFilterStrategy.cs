using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class AreaFilterStrategy : IFilterStrategy
    {
        private readonly string? _area;

        public AreaFilterStrategy(string? area)
        {
            _area = area;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(x => x.Area.ToLower().Contains(_area.ToLower()));
        }
        public bool CanApply(RealEStateFilter filter)
        {
            return !string.IsNullOrWhiteSpace(filter.Area);
        }
    }
}
