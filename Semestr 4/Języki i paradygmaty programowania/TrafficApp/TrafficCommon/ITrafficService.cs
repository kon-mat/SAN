using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficCommon
{
    public interface ITrafficService
    {
        public List<District> Districts { get; set; }
        public List<Street> Streets { get; set; }
        public List<Vehicle> Vehicles { get; set; }

        public void CreateDistricts();
        public void CreateStreets();
        public void CreateVehicles();

        public District GetDistrictById(int id);
        public District GetDistrictByName(string name);
        public IEnumerable<District> GetTheMostCrowdedDistricts();
        public IEnumerable<District> GetTheLeastCrowdedDistricts();
        public Street GetStreetById(int id);
        public Street GetStreetByName(string name);
        public IEnumerable<Street> GetTheMostCrowdedStreets();
        public IEnumerable<Street> GetTheLeastCrowdedStreets();
        public Vehicle GetVehicleByRegistration(string registration);

    }
}
