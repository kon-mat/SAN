using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApp
{
    public class TrafficService
    {
        public TrafficService()
        {
            CreateDistricts();
        }

        public List<District> Districts { get; set; } = new List<District>();
        public void CreateDistricts()
        {
            Districts.Add(new District(1, "Śródmieście"));
            Districts.Add(new District(2, "Osiedle Okrzei"));
            Districts.Add(new District(3, "Osiedle Słoneczne"));
            Districts.Add(new District(4, "Edwardów"));
            Districts.Add(new District(5, "Osiedle Dolnośląskie"));
            Districts.Add(new District(6, "Czapliniec"));
            Districts.Add(new District(7, "Osiedle Kopernika"));
        }

        public List<Street> Streets { get; set; } = new List<Street>();
        public void CreateStreets()
        {
            Streets.Add(new Street(1, "Pabianicka", GetDistrictByName("Śródmieście"), new List<int[]>() {
                    new int[] { 88, 196 },
                    new int[] { 94, 165 }, }));
            Streets.Add(new Street(2, "Kościuszki", GetDistrictByName("Śródmieście"), new List<int[]>() {
                    new int[] { 94, 165 },
                    new int[] { 97, 139 }, }));
            Streets.Add(new Street(3, "Okrzei", GetDistrictByName("Osiedle Okrzei"), new List<int[]>() {
                    new int[] { 97, 139 },
                    new int[] { 106, 139 },
                    new int[] { 107, 134 },
                    new int[] { 176, 72 },
                    new int[] { 180, 72 }, }));
            Streets.Add(new Street(4, "Stanisława Staszica", GetDistrictByName("Osiedle Słoneczne"), new List<int[]>() {
                    new int[] { 180, 72 },
                    new int[] { 179, 38 }, }));
            Streets.Add(new Street(5, "Armii Krajowej", GetDistrictByName("Edwardów"), new List<int[]>() {
                    new int[] { 179, 38 },
                    new int[] { 111, 6 }, }));
            Streets.Add(new Street(6, "Aleja Kardynała Wyszyńskiego", GetDistrictByName("Osiedle Dolnośląskie"), new List<int[]>() {
                    new int[] { 111, 6 },
                    new int[] { 22, 5 },
                    new int[] { 13, 36 },
                    new int[] { 13, 95 }, }));
            Streets.Add(new Street(7, "Aleja Włókniarzy", GetDistrictByName("Czapliniec"), new List<int[]>() {
                    new int[] { 13, 95 },
                    new int[] { 12, 132 },
                    new int[] { 10, 140 },
                    new int[] { 17, 177 }, }));
            Streets.Add(new Street(8, "Sienkiewicza", GetDistrictByName("Śródmieście"), new List<int[]>() {
                    new int[] { 17, 177 },
                    new int[] { 37, 193 },
                    new int[] { 88, 196 }, }));
            Streets.Add(new Street(9, "Czapliniecka", GetDistrictByName("Czapliniec"), new List<int[]>() {
                    new int[] { 17, 177 },
                    new int[] { 68, 119 }, }));
            Streets.Add(new Street(10, "Rotmistrza Witolda Pileckiego", GetDistrictByName("Osiedle Kopernika"), new List<int[]>() {
                    new int[] { 68, 119 },
                    new int[] { 97, 134 },
                    new int[] { 97, 139 }, }));
            Streets.Add(new Street(11, "Lipowa", GetDistrictByName("Osiedle Dolnośląskie"), new List<int[]>() {
                    new int[] { 68, 119 },
                    new int[] { 13, 95 }, }));
            Streets.Add(new Street(12, "Wojska Polskiego", GetDistrictByName("Osiedle Dolnośląskie"), new List<int[]>() {
                    new int[] { 68, 119 },
                    new int[] { 91, 89 },
                    new int[] { 111, 6 }, }));
        }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public void CreateVehicles()
        {
            ;
        }

        public District GetDistrictById(int id)
        {
            return Districts.FirstOrDefault(d => d.Id == id);
        }
        public District GetDistrictByName(string name)
        {
            return Districts.FirstOrDefault(d => d.Name == name);
        }
        public IEnumerable<District> GetTheMostCrowdedDistricts()
        {
            return Districts;   // #
        }
        public IEnumerable<District> GetTheLeastCrowdedDistricts()
        {
            return Districts;   // #
        }

        public Street GetStreetById(int id)
        {
            return Streets.FirstOrDefault(s => s.Id == id);
        }
        public Street GetStreetByName(string name)
        {
            return Streets.FirstOrDefault(s => s.Name == name);
        }
        public IEnumerable<Street> GetTheMostCrowdedStreets()
        {
            return Streets; // #
        }
        public IEnumerable<Street> GetTheLeastCrowdedStreets()
        {
            return Streets; // #
        }

        public Vehicle GetVehicleByRegistration(string registration)
        {
            return Vehicles[0]; // #
        }

    }
}
