
using Microsoft.EntityFrameworkCore;
using MyProject1.Dtos.DeveloperDto;
using MyProject1.Models.RealStates;

namespace MyProject.Services.DeveloperSerices
{
    public interface IDeveloperServices
    {
        Task<IEnumerable<Developer>> GetAll();
        Developer GetById(int DeveloperId);
        Task<IEnumerable<Developer>> GetByName(string Developername);
        Task<Developer> Add(DeveloperDto dto);
        Task<Developer> Update(DeveloperDto dto);
        Developer Delete(Developer Developer);
        void ChangeNumberOfProjectsInDeveloper(int developerId);

    }
}
