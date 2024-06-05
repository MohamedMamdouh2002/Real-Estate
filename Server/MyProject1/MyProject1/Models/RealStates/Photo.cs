using MyProject.Models.realstates;
using System.Text.Json.Serialization;

namespace MyProject.Models.RealStates
{
    public class Photo
    {
        public int Id { get; set; }
        public string ImgURL { get; set; }

        public int RealEStateId { get; set; }

        //Navigation
        [JsonIgnore]
        public RealEState RealEState { get; set; }


    }
}
