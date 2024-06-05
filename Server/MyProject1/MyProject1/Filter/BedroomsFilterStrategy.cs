using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Services.Filter;

namespace MyProject1.Filter
{
    public class BedroomsFilterStrategy : IFilterStrategy
    {
        private readonly int? _bedRooms;

        public BedroomsFilterStrategy(int? bedRooms)
        {
            _bedRooms = bedRooms;
        }

        public IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query)
        {
            return query.Where(p => p.Bedrooms <= _bedRooms);
        }

        public bool CanApply(RealEStateFilter filter)
        {
            return filter.Bedrooms.HasValue;
        }
    }
}
