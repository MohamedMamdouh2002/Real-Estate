namespace MyProject.Models.realstates
{
    public class RealEStateType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RealEState> RealStates { get; set; }
    }
}
