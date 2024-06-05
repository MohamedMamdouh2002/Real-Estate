using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class WithGardinFilterStrategy : IFilterStrategy
    {
        private readonly bool? _withGardin;

        public WithGardinFilterStrategy(bool? withGardin)
        {
            _withGardin = withGardin;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(p => p.WithGardien == _withGardin);
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return filter.WithGardien.HasValue;
        }
    }
}
