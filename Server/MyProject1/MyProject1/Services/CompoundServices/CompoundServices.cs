
using MyProject1.Models;
using MyProject.Models.RealStates;
using Microsoft.EntityFrameworkCore;
using MyProject1.Services.ImageServices;
using MyProject1.Dtos.CompoundDtos;
using AutoMapper;
using MyProject1.Models.RealStates;
using Microsoft.EntityFrameworkCore.Internal;
using MyProject1.Dtos.Amenities;
using Microsoft.IdentityModel.Tokens;
using MyProject.Services.DeveloperSerices;
using Humanizer;
using MyProject1.Services.CompoundImagesServices;

namespace MyProject.Services.CompoundServices
{
    public class CompoundServices : ICompoundServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IImageServices<Compound> _imageServices;
        private readonly IMapper _mapper;
        private readonly IDeveloperServices _developerServices;
        private readonly ICompoundImageServices _compoundImageServices;



        public CompoundServices(ApplicationDbContext context, IImageServices<Compound> imageServices, IMapper mapper, IDeveloperServices developerServices = null, ICompoundImageServices compoundImageServices = null)
        {
            _context = context;
            _imageServices = imageServices;
            _mapper = mapper;
            _developerServices = developerServices;
            _compoundImageServices = compoundImageServices;
        }

        public async Task<Compound> Add(CompoundDto dto)
        {
            var compound = _mapper.Map<Compound>(dto);
            _imageServices.SetImage(compound, dto.MasterPlan);
            _developerServices.ChangeNumberOfProjectsInDeveloper(dto.DeveloperId);
            await _context.AddAsync(compound);
            await _context.SaveChangesAsync();
            if (dto.Images != null)
            {
                await _compoundImageServices.AddCompoundImages(dto.Images, compound);
            }
            return compound;
        }


        public Compound Delete(Compound compound)
        {
            _context.Remove(compound);
            _context.SaveChanges();
            return compound;
        }

        public IEnumerable<CompoundReturnDto> GetAll()
        {
            var data =
                    (from compound in _context.Compounds
                     join compoundAmenities in _context.CompoundAmenities
                     on compound.Id equals compoundAmenities.CompoundId into compoundAmenitie
                     select new CompoundReturnDto

                     {
                         Id = compound.Id,
                         Area = compound.Area,
                         Description = compound.Description,
                         DeveloperId = compound.DeveloperId,
                         Goverment = compound.Goverment,
                         MasterPlanURL = "https://localhost:7203" + compound.MasterPlanURL,
                         Name = compound.Name,
                         DeveloperLogo = "https://localhost:7203" + compound.Developer.LogoURL,
                         RealEstateCount = compound.RealEstateConut,
                         DeveloperName = compound.Developer.Name,
                         MaxPrice = compound.ReaEState.Select(r => r.Price).Max(),
                         MinPrice = compound.ReaEState.Select(r => r.Price).Min(),
                         paymentPlans = compound.paymentPlans,
                         amenities = compound.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                         {
                             Name = p.Name,
                             Id = p.Id,
                             ImgURL = "https://localhost:7203" + p.ImgURL,
                         }),
                     }).AsEnumerable();
            return (data);
        }

        public async Task<IEnumerable<CompoundReturnDto>> GetByCompoundName(string compoundName)
        {
            var result = await _context.Compounds.Include(d => d.Developer).Include(r => r.ReaEState)
                .Where(k => k.Name.ToLower().Contains(compoundName)).Select(k => new CompoundReturnDto
                {
                    Id = k.Id,
                    Area = k.Area,
                    Description = k.Description,
                    DeveloperId = k.DeveloperId,
                    Goverment = k.Goverment,
                    MasterPlanURL = "https://localhost:7203" + k.MasterPlanURL,
                    Name = k.Name,
                    RealEstateCount = k.RealEstateConut,
                    DeveloperLogo = "https://localhost:7203" + k.Developer.LogoURL,

                    DeveloperName = k.Developer.Name,
                    MaxPrice = k.ReaEState.Select(r => r.Price).Max(),
                    MinPrice = k.ReaEState.Select(r => r.Price).Min(),
                    paymentPlans = k.paymentPlans,
                    amenities = k.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                    {
                        Name = p.Name,
                        Id = p.Id,
                        ImgURL = "https://localhost:7203" + p.ImgURL,
                    }),
                }).ToListAsync();
            return result;
        }

        public async Task<IEnumerable<CompoundReturnDto>> GetByDeveloperId(int DeveloperId)
        {
            var compounds = _context.Compounds.Where(k => k.DeveloperId == DeveloperId)
                .Include(d => d.Developer).Include(r => r.ReaEState)
                .Select(k => new CompoundReturnDto
                {
                    Id = k.Id,
                    Area = k.Area,
                    Description = k.Description,
                    DeveloperId = k.DeveloperId,
                    Goverment = k.Goverment,
                    MasterPlanURL = "https://localhost:7203" + k.MasterPlanURL,
                    Name = k.Name,
                    RealEstateCount = k.RealEstateConut,
                    DeveloperLogo = "https://localhost:7203" + k.Developer.LogoURL,

                    DeveloperName = k.Developer.Name,
                    MaxPrice = k.ReaEState.Select(r => r.Price).Max(),
                    MinPrice = k.ReaEState.Select(r => r.Price).Min(),
                    paymentPlans = k.paymentPlans,
                    amenities = k.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                    {
                        Name = p.Name,
                        Id = p.Id,
                        ImgURL = "https://localhost:7203" + p.ImgURL,
                    }),
                }).AsEnumerable();
            return compounds;
        }

        public async Task<IEnumerable<CompoundReturnDto>> GetByDeveloperName(string DeveloperName)
        {
            var result = await _context.Compounds
                  .Where(k => k.Developer.Name.ToLower().Contains(DeveloperName))
                  .Include(d => d.Developer).Include(r => r.ReaEState)
                  .Select(k => new CompoundReturnDto
                  {
                      Id = k.Id,
                      Area = k.Area,
                      Description = k.Description,
                      DeveloperId = k.DeveloperId,
                      Goverment = k.Goverment,
                      MasterPlanURL = "https://localhost:7203" + k.MasterPlanURL,
                      Name = k.Name,
                      RealEstateCount = k.RealEstateConut,
                      DeveloperLogo = "https://localhost:7203" + k.Developer.LogoURL,

                      DeveloperName = k.Developer.Name,
                      MaxPrice = k.ReaEState.Select(r => r.Price).Max(),
                      MinPrice = k.ReaEState.Select(r => r.Price).Min(),
                      paymentPlans = k.paymentPlans,
                      amenities = k.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                      {
                          Name = p.Name,
                          Id = p.Id,
                          ImgURL = "https://localhost:7203" + p.ImgURL,
                      }),
                  }).ToListAsync();
            return result;
        }

        public async Task<CompoundReturnWithImagesDto> GetByIdReturnDto(int CompoundId)
        {
            var compound1 = _context.Compounds.Include(c => c.CompoundImages).SingleOrDefault(p => p.Id == CompoundId);
            var compound = await _context.Compounds
                .Include(d => d.Developer).Include(c => c.CompoundImages)
                 .Select(k => new CompoundReturnWithImagesDto
                 {
                     Id = k.Id,
                     Area = k.Area,
                     Description = k.Description,
                     DeveloperId = k.DeveloperId,
                     Goverment = k.Goverment,
                     MasterPlanURL = "https://localhost:7203" + k.MasterPlanURL,
                     Name = k.Name,
                     RealEstateCount = k.RealEstateConut,
                     DeveloperLogo = "https://localhost:7203" + k.Developer.LogoURL,

                     DeveloperName = k.Developer.Name,
                     MaxPrice = k.ReaEState.Select(r => r.Price).Max(),
                     MinPrice = k.ReaEState.Select(r => r.Price).Min(),
                     paymentPlans = k.paymentPlans,
                     amenities = k.CompoundAmenities.Select(a => a.Amenities).Select(p => new AmenitieReturnInCompoundDto
                     {
                         Name = p.Name,
                         Id = p.Id,
                         ImgURL = "https://localhost:7203" + p.ImgURL,
                     }),
                     CompoundImages = k.CompoundImages.Select(l => new CompoundImageDto
                     {
                         Id = l.Id,
                         CompoundId = l.CompoundId,
                         ImageUrl = "https://localhost:7203" + l.ImgURL,
                     }),
                 }).SingleOrDefaultAsync(x => x.Id == CompoundId);


            return compound;
        }

        public Compound GetById(int CompoundId)
        {
            var compound = _context.Compounds
                .Include(d => d.Developer)
                .SingleOrDefault(x => x.Id == CompoundId);
            return compound;
        }


        public async Task<CompoundReturnWithImagesDto> Update(int id, CompoundDto dto)
        {

            var compound = GetById(id);
            if (compound == null)
                return new CompoundReturnWithImagesDto { };


            if (dto.MasterPlan != null)
            {
                _imageServices.SetImage(compound, dto.MasterPlan);
            }
            if (!dto.Name.IsNullOrEmpty())
            {
                compound.Name = dto.Name;
            }
            if (!dto.Description.IsNullOrEmpty())
            {
                compound.Description = dto.Description;
            }
            if (!dto.Area.IsNullOrEmpty())
            {
                compound.Area = dto.Area;
            }


            _context.Update(compound);
            await _context.SaveChangesAsync();
            var compound1 = await GetByIdReturnDto(id);
            return compound1;
        }
        public void ChangeRealEstateCountInCompound(int compoundId)
        {
            Compound compound = GetById(compoundId);
            if (compound != null)
            {
                compound.RealEstateConut++;
                _context.Update(compound);
                _context.SaveChanges();
            }

        }
    }
}
