using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficApp
{
    public class TrafficService
    {
        public TrafficService()
        {
            CreateDistricts();
            CreateStreets();
            CreateCorssroads();
            CreateVehicles(30);
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
            Streets.Add(new Street(1, "Pabianicka", GetDistrictByName("Śródmieście"),
                CreateMainCoords(new List<(double, double)>() {
                    ( 88, 196 ),
                    ( 94, 165 ) })));

            Streets.Add(new Street(2, "Kościuszki", GetDistrictByName("Śródmieście"),
                CreateMainCoords(new List<(double, double)>() {
                   ( 94, 165 ),
                   ( 97, 139 ) })));

            Streets.Add(new Street(3, "Okrzei", GetDistrictByName("Osiedle Okrzei"),
                CreateMainCoords(new List<(double, double)>() {
                    ( 97, 139 ),
                    ( 106, 139 ),
                    ( 107, 134 ),
                    ( 176, 72 ),
                    ( 180, 72 ) })));

            Streets.Add(new Street(4, "Stanisława Staszica", GetDistrictByName("Osiedle Słoneczne"),
                 CreateMainCoords(new List<(double, double)>() {
                    ( 180, 72 ),
                    ( 179, 38 ) })));

            Streets.Add(new Street(5, "Armii Krajowej", GetDistrictByName("Edwardów"),
                 CreateMainCoords(new List<(double, double)>() {
                    ( 179, 38 ),
                    ( 111, 6 ) })));

            Streets.Add(new Street(6, "Aleja Kardynała Wyszyńskiego", GetDistrictByName("Osiedle Dolnośląskie"),
                CreateMainCoords(new List<(double, double)>() {
                    ( 111, 6 ),
                    ( 22, 5 ),
                    ( 13, 36 ),
                    ( 13, 95 ) })));

            Streets.Add(new Street(7, "Aleja Włókniarzy", GetDistrictByName("Czapliniec"),
                 CreateMainCoords(new List<(double, double)>() {
                    ( 13, 95 ),
                    ( 12, 132 ),
                    ( 10, 140 ),
                    ( 17, 177 ) })));

            Streets.Add(new Street(8, "Sienkiewicza", GetDistrictByName("Śródmieście"),
                 CreateMainCoords(new List<(double, double)>() {
                    ( 17, 177 ),
                    ( 37, 193 ),
                    ( 88, 196 ) })));

            Streets.Add(new Street(9, "Czapliniecka", GetDistrictByName("Czapliniec"),
                 CreateMainCoords(new List<(double, double)>() {
                    ( 17, 177 ),
                    ( 68, 119 ) })));

            Streets.Add(new Street(10, "Rotmistrza Witolda Pileckiego", GetDistrictByName("Osiedle Kopernika"),
                 CreateMainCoords(new List<(double, double)>() {
                    ( 68, 119 ),
                    ( 97, 134 ),
                    ( 97, 139 ) })));

            Streets.Add(new Street(11, "Lipowa", GetDistrictByName("Osiedle Dolnośląskie"),
                 CreateMainCoords(new List<(double, double)>() {
                    ( 68, 119 ),
                    ( 13, 95 ) })));

            Streets.Add(new Street(12, "Wojska Polskiego", GetDistrictByName("Osiedle Dolnośląskie"),
                 CreateMainCoords(new List<(double, double)>() {
                    ( 68, 119 ),
                    ( 91, 89 ),
                    ( 111, 6 ) })));
        }

        public List<Vector3> CreateMainCoords(List<(double, double)> coordValues)
        {
            List<Vector3> mainCoords = new List<Vector3>();
            foreach (var coordValue in coordValues)
                mainCoords.Add(new Vector3(coordValue.Item1, coordValue.Item2));
            return mainCoords;
        }

        public List<Crossroad> Crossroads { get; set; } = new List<Crossroad>();
        public void CreateCorssroads()
        {
            foreach (Street street in Streets)
                Crossroads.Add(new Crossroad(Crossroads.Count() + 1, street.StartCoord, GetStreetsByPosition(street.StartCoord)));

            foreach (Crossroad crossroad in Crossroads)
                foreach (Street street in GetStreetsByPosition(crossroad.Position))
                    if (street.Crossroads == null || !street.Crossroads.Contains(crossroad))
                        street.AddCrossroad(crossroad);
        }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
        public void CreateVehicles(int numberOfVehicles)
        {
            for (int i = 1; i < numberOfVehicles + 1; i++)
            {
                Street randomStreet;
                Vector3 randomLocation;
                Random random = new Random();
                bool uniqueLocation;

                do
                {
                    randomStreet = GetStreetById(random.Next(1, Streets.Count + 1));
                    randomLocation = randomStreet.Coordinates[random.Next(randomStreet.Coordinates.Count() - 1)];
                    uniqueLocation = true;

                    foreach (Vehicle vehicle in Vehicles)
                        if (vehicle.Position == randomLocation)
                        {
                            uniqueLocation = false;
                            break;
                        }
                } while (!uniqueLocation);

                int randomDirection = random.Next(2) == 0 ? -1 : 1;
                Vehicles.Add(new Vehicle(i, $"EBE{random.Next(1000, 9999)}", 1, randomDirection, randomLocation,
                    randomDirection == 1 ? randomStreet.EndCoord : randomStreet.StartCoord, this));
            }
        }

        public string GenerateCrowdReport()
        {
            Dictionary<District, int> districtsCrowd = GetDistrictsCrowd().OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            Dictionary<Street, int> streetsCrowd = GetStreetsCrowd().OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            string report = "\n\r3 najbardziej zatłoczone dzielnice:\n\r";
            foreach (var district in districtsCrowd.Skip(districtsCrowd.Count() - 3))
                report += $"\n\r   • {district.Value} : {district.Key.Name}\n\r";

            report += "\n\r\n\r3 najmniej zatłoczone dzielnice:\n\r";
            foreach (var district in districtsCrowd.Take(3))
                report += $"\n\r   • {district.Value} : {district.Key.Name}\n\r";

            report += "\n\r";

            report += "\n\r3 najbardziej zatłoczone ulice:\n\r";
            foreach (var street in streetsCrowd.Skip(streetsCrowd.Count() - 3))
                report += $"\n\r   • {street.Value} : {street.Key.Name}\n\r";

            report += "\n\r\n\r3 najmniej zatłoczone ulice:\n\r";
            foreach (var street in streetsCrowd.Take(3))
                report += $"\n\r   • {street.Value} : {street.Key.Name}\n\r";

            return report;
        }


        public District GetDistrictByName(string name)
        {
            return Districts.FirstOrDefault(d => d.Name == name);
        }

        public District GetDistrictByPosition(Vector3 position)
        {
            return GetDistrictByName(GetStreetByPosition(position).District);
        }

        public Street GetStreetById(int id)
        {
            return Streets.FirstOrDefault(s => s.Id == id);
        }

        public Street GetStreetByPosition(Vector3 position)
        {
            foreach (Street street in Streets)
                if (street.Coordinates.Where(c => CoordsEqual(c, position)).Any())
                    return street;
            return null;
        }

        public List<Street> GetStreetsByPosition(Vector3 position)
        {
            return Streets.Where(s => CoordsEqual(s.StartCoord, position) || CoordsEqual(s.EndCoord, position)).ToList();
        }

        public Crossroad GetCrossroadByPosition(Vector3 position)
        {
            return Crossroads.FirstOrDefault(c => c.Position.X == position.X && c.Position.Y == position.Y);
        }

        public bool CoordsEqual(Vector3 firstCoord, Vector3 secondCord)
        {
            return firstCoord.X == secondCord.X && firstCoord.Y == secondCord.Y ? true : false;

        }

        public Dictionary<District, int> GetDistrictsCrowd()
        {
            Dictionary<District, int> districtCrowd = new Dictionary<District, int>();
            foreach (District district in Districts)
                districtCrowd.Add(district, 0);
            foreach (Vehicle vehicle in Vehicles)
                districtCrowd[GetDistrictByPosition(vehicle.Position)]++;

            return districtCrowd;
        }

        public Dictionary<Street, int> GetStreetsCrowd()
        {
            Dictionary<Street, int> streetCrowd = new Dictionary<Street, int>();
            foreach (Street street in Streets)
                streetCrowd.Add(street, 0);
            foreach (Vehicle vehicle in Vehicles)
                streetCrowd[GetStreetByPosition(vehicle.Position)]++;

            return streetCrowd;
        }

    }
}
