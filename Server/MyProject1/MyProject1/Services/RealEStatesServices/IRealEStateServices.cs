
using MyProject.Dtos;
using MyProject.Models.realstates;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;

namespace MyProject.Services.RealEStatesServices
{
    public interface IRealEStateServices
    {

        Task<IEnumerable<RealEState>> GetAll();
        Task<IEnumerable<RealEState>> GetByCompoundName(string compoundName);
        Task<IQueryable<RealEState>> GetAllAsQuery();
        Task<IEnumerable<RealEState>> GetByCompound(int CompoundId);
        Task<RealEState> GetById(int id);
        Task<RealEStateReturnDto> Add(SellByAdminDto dto);
        RealEState Update(RealEState realState);
        RealEState Delete(RealEState realState);


    }
}
