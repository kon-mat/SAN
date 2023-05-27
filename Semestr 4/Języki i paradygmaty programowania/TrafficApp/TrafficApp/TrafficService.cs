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
            CreateStreets();
            CreateVehicles();
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
            Streets.Add(new Street(1, "Pabianicka", GetDistrictByName("Śródmieście"), new List<(int, int)>() {
                    ( 88, 196 ),
                    ( 94, 165 ), }));
            Streets.Add(new Street(2, "Kościuszki", GetDistrictByName("Śródmieście"), new List<(int, int)>() {
                    ( 94, 165 ),
                    ( 97, 139 ), }));
            Streets.Add(new Street(3, "Okrzei", GetDistrictByName("Osiedle Okrzei"), new List<(int, int)>() {
                    ( 97, 139 ),
                    ( 106, 139 ),
                    ( 107, 134 ),
                    ( 176, 72 ),
                    ( 180, 72 ), }));
            Streets.Add(new Street(4, "Stanisława Staszica", GetDistrictByName("Osiedle Słoneczne"), new List<(int, int)>() {
                    ( 180, 72 ),
                    ( 179, 38 ), }));
            Streets.Add(new Street(5, "Armii Krajowej", GetDistrictByName("Edwardów"), new List<(int, int)>() {
                    ( 179, 38 ),
                    ( 111, 6 ), }));
            Streets.Add(new Street(6, "Aleja Kardynała Wyszyńskiego", GetDistrictByName("Osiedle Dolnośląskie"), new List<(int, int)>() {
                    ( 111, 6 ),
                    ( 22, 5 ),
                    ( 13, 36 ),
                    ( 13, 95 ), }));
            Streets.Add(new Street(7, "Aleja Włókniarzy", GetDistrictByName("Czapliniec"), new List<(int, int)>() {
                    ( 13, 95 ),
                    ( 12, 132 ),
                    ( 10, 140 ),
                    ( 17, 177 ), }));
            Streets.Add(new Street(8, "Sienkiewicza", GetDistrictByName("Śródmieście"), new List<(int, int)>() {
                    ( 17, 177 ),
                    ( 37, 193 ),
                    ( 88, 196 ), }));
            Streets.Add(new Street(9, "Czapliniecka", GetDistrictByName("Czapliniec"), new List<(int, int)>() {
                    ( 17, 177 ),
                    ( 68, 119 ), }));
            Streets.Add(new Street(10, "Rotmistrza Witolda Pileckiego", GetDistrictByName("Osiedle Kopernika"), new List<(int, int)>() {
                    ( 68, 119 ),
                    ( 97, 134 ),
                    ( 97, 139 ), }));
            Streets.Add(new Street(11, "Lipowa", GetDistrictByName("Osiedle Dolnośląskie"), new List<(int, int)>() {
                    ( 68, 119 ),
                    ( 13, 95 ), }));
            Streets.Add(new Street(12, "Wojska Polskiego", GetDistrictByName("Osiedle Dolnośląskie"), new List<(int, int)>() {
                    ( 68, 119 ),
                    ( 91, 89 ),
                    ( 111, 6 ), }));
        }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public void CreateVehicles()
        {
            Random random = new Random();
            for ( int i = 1; i < 6; i++ )
            {
                Vector3 randomPosition;
                bool uniqueLocation = true;
                do
                {
                    Street randomStreet = GetStreetById(random.Next(1, Streets.Count + 1));
                    (int, int) randomStreetLocation = randomStreet.Coordinates[random.Next(randomStreet.Coordinates.Count())];
                    randomPosition = new Vector3(randomStreetLocation.Item1, randomStreetLocation.Item2);
                    foreach (Vehicle vehicle in Vehicles)
                        if (uniqueLocation)
                            uniqueLocation = vehicle.Position == randomPosition ? false : true;
                } while (!uniqueLocation);

                Vehicles.Add(new Vehicle(i, $"EBE{random.Next(1000, 9999)}", 1, randomPosition));
            }
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
