using MyProject.Models.realstates;
using MyProject.Services.RealEStatesServices;
using MyProject1.Services.CompareRealEstatesServices;

namespace MyProject1.Services.CompareRealEstates
{
    public class CompareRealEstatesServices : ICompareRealEstatesServices
    {
        private readonly IRealEStateServices _realEStateServices;

        public CompareRealEstatesServices(IRealEStateServices realEStateServices)
        {
            _realEStateServices = realEStateServices;
        }

        public async Task<List<RealEState>> Compare(List<string> properties, 
            int realEstate1Id, int realEstate2Id, int realEstate3Id)
        {
            var realEstate1 = await _realEStateServices.GetById(realEstate1Id);
            var realEstate2 = await _realEStateServices.GetById(realEstate2Id);
            var realEstate3 = await _realEStateServices.GetById(realEstate3Id);
            List<RealEState> maxRealEstates = new List<RealEState>();
            foreach (string property in properties)
            {
                RealEState maxRealEstate = FindMaxProperty(realEstate1, realEstate2, realEstate3, property);
                maxRealEstates.Add(maxRealEstate);
            }
            return maxRealEstates;
        }
        private RealEState FindMaxProperty(RealEState realEstate1, RealEState realEstate2, RealEState realEstate3, string property)
        {
            RealEState maxRealEstate = null;
            switch (property)
            {
                case "price":
                    maxRealEstate = (realEstate1.Price >= realEstate2.Price && realEstate1.Price >= realEstate3.Price) ? realEstate1 :
                                    (realEstate2.Price >= realEstate1.Price && realEstate2.Price >= realEstate3.Price) ? realEstate2 :
                                    realEstate3;
                    break;
                case "bua":
                    maxRealEstate = (realEstate1.BUA >= realEstate2.BUA && realEstate1.BUA >= realEstate3.BUA) ? realEstate1 :
                                    (realEstate2.BUA >= realEstate1.BUA && realEstate2.BUA >= realEstate3.BUA) ? realEstate2 :
                                    realEstate3;
                    break;
                case "bedrooms":
                    maxRealEstate = (realEstate1.Bedrooms >= realEstate2.Bedrooms && realEstate1.Bedrooms >= realEstate3.Bedrooms) ? realEstate1 :
                                    (realEstate2.Bedrooms >= realEstate1.Bedrooms && realEstate2.Bedrooms >= realEstate3.Bedrooms) ? realEstate2 :
                                    realEstate3;
                    break;
                case "bathrooms":
                    maxRealEstate = (realEstate1.Bathtrooms >= realEstate2.Bathtrooms && realEstate1.Bathtrooms >= realEstate3.Bathtrooms) ? realEstate1 :
                                    (realEstate2.Bathtrooms >= realEstate1.Bathtrooms && realEstate2.Bathtrooms >= realEstate3.Bathtrooms) ? realEstate2 :
                                    realEstate3;
                    break;
               
                default:
                    Console.WriteLine($"Invalid property: {property}");
                    break;
            }

            return maxRealEstate;
        }
    }
}

