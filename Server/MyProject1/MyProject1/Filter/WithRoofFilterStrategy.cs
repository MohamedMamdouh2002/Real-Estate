using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class WithRoofFilterStrategy : IFilterStrategy
    {
        private readonly bool? _withRoof;

        public WithRoofFilterStrategy(bool? withRoof)
        {
            _withRoof = withRoof;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(p => p.WithRoof == _withRoof);
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return filter.WithRoof.HasValue;
        }
    }
}
