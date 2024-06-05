using Microsoft.EntityFrameworkCore;
using MyProject.Models.realstates;
using MyProject1.Models;

namespace MyProject.Services.ReaEStateTypeServices
{
    public class ReaEStateTypeServices : IReaEStateTypeServices
    {
        private readonly ApplicationDbContext _context;

        public ReaEStateTypeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RealEStateType> Add(RealEStateType realEStateType)
        {
            await _context.AddAsync(realEStateType);
            _context.SaveChanges();
            return realEStateType;
        }

        public RealEStateType Delete(RealEStateType realEStateType)
        {
            _context.Remove(realEStateType);
            _context.SaveChanges();
            return realEStateType;
        }

        public async Task<IEnumerable<RealEStateType>> GetAll() => await _context.RealEStateTypes.ToListAsync();

        public async Task<RealEStateType> GetById(int id)
        {
            return await _context.RealEStateTypes.SingleOrDefaultAsync(p => p.Id == id);
        }

        public RealEStateType Update(RealEStateType realEStateType)
        {
            _context.Update(realEStateType);
            _context.SaveChanges();
            return realEStateType;
        }
    }
}
