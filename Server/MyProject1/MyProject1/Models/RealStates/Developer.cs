using MyProject.Models.RealStates;

namespace MyProject1.Models.RealStates
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Description { get; set; }
        public string LogoURL { get; set; }
        public byte NumberOfProjects { get; set; }
        public ICollection<Compound>? compounds { get; set; }

    }
}
