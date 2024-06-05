
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.Dtos;
using MyProject.Models.realstates;
using MyProject.Services.CompoundServices;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Dtos.RealStateDto;
using MyProject1.Models;
using MyProject1.Services.Shared;
using System.Drawing.Text;

namespace MyProject.Services.RealEStatesServices
{
    public class RealEStateServices : IRealEStateServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ICompoundServices _compoundServices;
        private readonly IMapper _mapper;


        public RealEStateServices(ApplicationDbContext context, ICompoundServices compoundServices, IMapper mapper)
        {
            _context = context;
            _compoundServices = compoundServices;
            _mapper = mapper;
        }

        public async Task<RealEStateReturnDto> Add(SellByAdminDto dto)
        {


            var data = _mapper.Map<RealEState>(dto);
            await _context.RealEStates.AddAsync(data);
            _context.SaveChanges();
            _compoundServices.ChangeRealEstateCountInCompound(dto.CompoundId);
            var RealEstateReturn = _mapper.Map<RealEStateReturnDto>(data);
            return RealEstateReturn;
        }

        public RealEState Delete(RealEState EState)
        {

            _context.Remove(EState);
            _context.SaveChanges();
            return EState;
        }

        public async Task<IEnumerable<RealEState>> GetAll()
        {
            var result = await _context.RealEStates
                .Include(x => x.Compound)
                .ThenInclude(x => x.Developer)
                .ToListAsync();

            return result;

        }
        public async Task<IQueryable<RealEState>> GetAllAsQuery()
        {
            var result = _context.RealEStates
                .Include(x => x.Compound)
                .ThenInclude(x => x.Developer)
                .AsQueryable();

            return result;

        }

        public async Task<IEnumerable<RealEState>> GetByCompound(int compoundId)
        {
            return await _context.RealEStates
                        .Where(r => r.CompoundId == compoundId)
                        .ToListAsync();
        }

        public async Task<IEnumerable<RealEState>> GetByCompoundName(string compoundName)
        {

            var result = await _context.RealEStates.Include(c => c.Compound).ThenInclude(d => d.Developer).Where(p => p.Compound.Name.ToLower().Contains(compoundName)).ToListAsync();

            return result;
        }
        public async Task<RealEState> GetById(int id)
        {
            return await _context.RealEStates.Include(p => p.Payment).SingleOrDefaultAsync(r => r.Id == id);
        }



        public RealEState Update(RealEState EState)
        {
            _context.Update(EState);
            _context.SaveChanges();
            return EState;
        }


    }
}


