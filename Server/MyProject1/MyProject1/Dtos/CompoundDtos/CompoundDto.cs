using System.Text.Json.Serialization;

namespace MyProject1.Dtos.CompoundDtos
{
    public class CompoundDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Goverment { get; set; }
        public string? Area { get; set; }

        public int DeveloperId { get; set; }
        public IFormFile? MasterPlan { get; set; }
        public IEnumerable<IFormFile>? Images { get; set; }
    }
}
