using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class DeliveryInFilterStrategy : IFilterStrategy
    {
        private readonly int? _deliveryIn;

        public DeliveryInFilterStrategy(int? deliveryIn)
        {
            _deliveryIn = deliveryIn;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(p => p.DeliveryIn <= _deliveryIn);
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return filter.DeliveryIn.HasValue;
        }
    }
}
