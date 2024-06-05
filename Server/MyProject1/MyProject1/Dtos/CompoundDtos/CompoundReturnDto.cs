

using MyProject.Models.RealStates;
using MyProject1.Dtos.Amenities;
using MyProject1.Models.RealStates;

namespace MyProject1.Dtos.CompoundDtos
{
    public class CompoundReturnDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Goverment { get; set; }
        public string? Area { get; set; }
        public int? MaxPrice { get; set; }
        public int? MinPrice { get; set; }
        public string? DeveloperName { get; set; }
        public int? DeveloperId { get; set; }
        public string? MasterPlanURL { get; set; }
        public string? Message { get; set; }
        public int RealEstateCount { get; set; }
        public string? DeveloperLogo { get; set; }

        public IEnumerable<PaymentPlanForCompound>? paymentPlans { get; set; }
        public IEnumerable<double>? Percentage { get; set; }
        public IEnumerable<int>? Years { get; set; }
        public IEnumerable<AmenitieReturnInCompoundDto>? amenities { get; set; }


    }
}
