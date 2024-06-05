using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class PriceFilterStrategy : IFilterStrategy
    {
        private readonly int? _price;

        public PriceFilterStrategy(int? price)
        {
            _price = price;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(p => p.Price <= _price);
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return filter.Price.HasValue;
        }
    }
}
