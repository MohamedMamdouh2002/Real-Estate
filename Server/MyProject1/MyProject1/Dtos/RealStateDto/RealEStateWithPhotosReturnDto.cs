using MyProject.Models.realstates;
using MyProject.Models.RealStates;

namespace MyProject1.Dtos.RealStateDto
{
    public class RealEStateWithPhotosReturnDto
    {
        public RealEState realEState;
        public IEnumerable<Photo>? photos;
    }
}
