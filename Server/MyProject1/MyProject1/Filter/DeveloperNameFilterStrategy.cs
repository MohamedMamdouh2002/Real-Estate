using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class DeveloperNameFilterStrategy : IFilterStrategy
    {

        private readonly string? _developerName;

        public DeveloperNameFilterStrategy(string? developerName)
        {
            _developerName = developerName;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(x => x.DeveloperName.ToLower().Contains(_developerName.ToLower()));
        }
        public bool CanApply(RealEStateFilter filter)
        {
            return !string.IsNullOrWhiteSpace(filter.DeveloperName);
        }
    }
}

