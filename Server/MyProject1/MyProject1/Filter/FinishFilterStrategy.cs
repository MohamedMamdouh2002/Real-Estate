using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Dtos.RealStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class FinishFilterStrategy : IFilterStrategy
    {
        private readonly string? _finish;

        public FinishFilterStrategy(string? finish)
        {
            _finish = finish;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(x => x.Finish.ToLower().Contains(_finish.ToLower()));
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return !string.IsNullOrWhiteSpace(filter.Finish);
        }
    }
}
