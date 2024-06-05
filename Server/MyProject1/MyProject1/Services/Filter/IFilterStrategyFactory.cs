using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Filter;

namespace MyProject1.Services.Filter
{
    public interface IFilterStrategyFactory
    {
        IEnumerable<IFilterStrategy> GetFilterStrategies(RealEStateFilter filter);


    }
}
