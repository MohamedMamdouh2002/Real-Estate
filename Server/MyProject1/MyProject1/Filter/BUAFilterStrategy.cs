using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class BUAFilterStrategy : IFilterStrategy
    {
        private readonly double? _bua;

        public BUAFilterStrategy(double? bua)
        {
            _bua = bua;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(p => p.BUA <= _bua);
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return filter.BUA.HasValue;
        }
    }
}
