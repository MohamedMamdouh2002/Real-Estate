using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class BathRoomsFilterStrategy : IFilterStrategy
    {
        private readonly int? _bathRooms;

        public BathRoomsFilterStrategy(int? bathRooms)
        {
            _bathRooms = bathRooms;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(p => p.Bathtrooms <= _bathRooms);
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return filter.Bathtrooms.HasValue;
        }
    }
}
