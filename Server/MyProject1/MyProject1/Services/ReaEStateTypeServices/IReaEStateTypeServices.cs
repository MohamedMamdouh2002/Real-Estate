
using MyProject.Models.realstates;

namespace MyProject.Services.ReaEStateTypeServices
{
    public interface IReaEStateTypeServices
    {
        Task<IEnumerable<RealEStateType>> GetAll();
        Task<RealEStateType> GetById(int id);
        Task<RealEStateType> Add(RealEStateType realEStateType);
        RealEStateType Update(RealEStateType realEStateType);
        RealEStateType Delete(RealEStateType realEStateType);
    }
}
