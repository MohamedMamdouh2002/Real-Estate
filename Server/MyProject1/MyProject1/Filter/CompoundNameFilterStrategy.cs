using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class CompoundNameFilterStrategy : IFilterStrategy
    {

        private readonly string? _compoundName;

        public CompoundNameFilterStrategy(string? compoundName)
        {
            _compoundName = compoundName;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(x => x.CompoundName.ToLower().Contains(_compoundName.ToLower()));
        }
        public bool CanApply(RealEStateFilter filter)
        {
            return !string.IsNullOrWhiteSpace(filter.CompoundName);
        }
    }
}
