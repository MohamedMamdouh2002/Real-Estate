using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Dtos.RealStateDto;
using MyProject1.Filter;

namespace MyProject1.Services.Filter
{
    public interface IFilterStrategy
    {
        bool CanApply(RealEStateFilter filter);
        IQueryable<RealEStateReturnDto> ApplyFilter(IQueryable<RealEStateReturnDto> query);
    }
}
