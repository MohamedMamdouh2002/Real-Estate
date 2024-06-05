using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class GovernmentFilterStrategy : IFilterStrategy
    {
        private readonly string? _government;

        public GovernmentFilterStrategy(string? government)
        {
            _government = government;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(x => x.Government.ToLower().Contains(_government.ToLower()));
        }
        public bool CanApply(RealEStateFilter filter)
        {
            return !string.IsNullOrWhiteSpace(filter.Government);
        }
    }
}
