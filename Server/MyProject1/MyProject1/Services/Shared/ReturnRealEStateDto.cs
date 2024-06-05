using Humanizer;
using Microsoft.EntityFrameworkCore;
using MyProject1.Dtos.RealEStateDto.RealEStateDto;
using MyProject1.Models;

namespace MyProject1.Services.Shared
{
    public class ReturnRealEStateDto
    {
        private readonly ApplicationDbContext _context;



        public ReturnRealEStateDto(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<RealEStateReturnDto>> realEStateReturnDtos()
        {

            var query = _context.RealEStates.Include(D => D.RealStatesType).Include(p => p.Compound).ThenInclude(d => d.Developer)
                .Select(d => new RealEStateReturnDto
                {
                    Area = d.Compound.Area,
                    Bathtrooms = d.Bathtrooms,
                    Bedrooms = d.Bedrooms,
                    BUA = d.BUA,
                    CompoundName = d.Compound.Name,
                    DeliveryIn = d.DeliveryIn,
                    Finish = d.Finish,
                    DeveloperName = d.Compound.Developer.Name,
                    GardienArea = d.GardienArea,
                    Government = d.Compound.Goverment,
                    Price = d.Price,
                    RoofPentHouse = d.RoofPentHouse,
                    WithGardien = d.WithGardien,
                    WithRoof = d.WithRoof

                });

            return query;
        }
    }
}
