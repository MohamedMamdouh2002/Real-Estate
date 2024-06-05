namespace MyProject1.Dtos.DeveloperDto
{
    public class DeveloperReturnDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string LogoURL { get; set; }
        public byte NumberOfProjects { get; set; }
    }
}
