namespace MyProject1.Dtos.DeveloperDto
{
    public class DeveloperDto
    { 
        public string? Name { get; set; }
        public string? Owner { get; set; }
        public string? Description { get; set; }
        public IFormFile? Logo { get; set; }
    }
}
