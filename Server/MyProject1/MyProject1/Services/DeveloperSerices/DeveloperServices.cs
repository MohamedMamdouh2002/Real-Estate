using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyProject1.Dtos.DeveloperDto;
using MyProject1.Models;
using MyProject1.Models.RealStates;
using MyProject1.Services.ImageServices;

namespace MyProject.Services.DeveloperSerices
{
    public class DeveloperServices : IDeveloperServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IImageServices<Developer> _imageServices;

        public DeveloperServices(ApplicationDbContext context, IMapper mapper, IImageServices<Developer> imageServices)
        {
            _context = context;
            _mapper = mapper;
            _imageServices = imageServices;
        }

        public async Task<Developer> Add(DeveloperDto dto)
        {
            var developer = _mapper.Map<Developer>(dto);
            _imageServices.SetImage(developer, dto.Logo);

            await _context.AddAsync(developer);
            await _context.SaveChangesAsync();
            return developer;
        }

        public Developer Delete(Developer Developer)
        {
            _context.Remove(Developer);
            _context.SaveChanges();
            return Developer;
        }

        public async Task<IEnumerable<Developer>> GetAll()
        {
            return await _context.Developers.Include(p => p.compounds).ToListAsync();
        }

        public Developer GetById(int DeveloperId)
        {
            return _context.Developers.SingleOrDefault(k => k.Id == DeveloperId);
        }

        public async Task<IEnumerable<Developer>> GetByName(string DeveloperName)
        {

            return await _context.Developers.Where(p => p.Name.ToLower().Contains(DeveloperName)).ToListAsync();
        }

        public async Task<Developer> Update(DeveloperDto dto)
        {
            var developer = _mapper.Map<Developer>(dto);
            _imageServices.SetImage(developer, dto.Logo);

            _context.Update(developer);
            await _context.SaveChangesAsync();
            return developer;
        }
        public void ChangeNumberOfProjectsInDeveloper(int developerId)
        {
            Developer developer = GetById(developerId);
            if (developer != null)
            {
                developer.NumberOfProjects++;
                _context.Update(developer);
                _context.SaveChanges();
            }
        }
    }
}