using MyProject.Models.realstates;
using MyProject.Models.RealStates;
using System.Text.Json.Serialization;

namespace MyProject1.Models.RealStates
{
    public class CompoundImages
    {
        public int Id { get; set; }
        public string ImgURL { get; set; }

        public int CompoundId { get; set; }

        //Navigation
        [JsonIgnore]
        public Compound compound { get; set; }
    }
}
