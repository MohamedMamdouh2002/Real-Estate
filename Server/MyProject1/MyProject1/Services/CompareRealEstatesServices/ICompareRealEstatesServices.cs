using MyProject.Models.realstates;

namespace MyProject1.Services.CompareRealEstatesServices
{
    public interface ICompareRealEstatesServices
    {
        public Task<List<RealEState>> Compare(List<string> properties,
                    int realEstate1Id, int realEstate2Id, int realEstate3Id);
    }
}
