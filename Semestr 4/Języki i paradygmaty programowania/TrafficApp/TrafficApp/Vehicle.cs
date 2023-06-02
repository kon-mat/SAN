using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficApp
{
    public class Vehicle : IMover
    {
        private readonly int _id;
        private readonly string _registration;
        private readonly int _speed;
        private int _direction;
        private Vector3 _position;
        private Vector3 _destination;
        private TrafficService _trafficService;

        public Vehicle(int id, string registration, int speed, int direction, Vector3 position, Vector3 destination, TrafficService trafficService)
        {
            _id = id;
            _registration = registration;
            _speed = speed;
            Direction = direction;
            _position = position;
            _destination = destination;
            _trafficService = trafficService;
        }

        public int Id { get { return _id; } }
        public string Registration { get { return _registration; } }
        public int Speed { get { return _speed; } }

        public int Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                if (value == -1 || value == 0 || value == 1)
                    _direction = value;
            }
        }

        public Vector3 Position { get { return _position; } }
        public Vector3 Destination { get { return _destination; } }
        public List<Vector3> CurrentRoad { get { return _trafficService.GetStreetByPosition(_position).Coordinates; } }
        public int PositionIndexOfRoad { get { return CurrentRoad.FindIndex(c => c == _position); } }
        public bool DestinationReached 
        { 
            get 
            {
                return PositionIndexOfRoad + _direction >= 0
                    && PositionIndexOfRoad + _direction < CurrentRoad.Count() ? false : true;
            } 
        }

        public string GenerateReport()
        {
            string report = $"\r\nSzczegóły pojazdu o rejestracji: {Registration}\r\n";
            report += $"   • Aktualnie znajduje się na: {CurrentLocationName()}   ({_position.X}, {_position.Y})\r\n";
            report += $"   • Zmierza do:\r\n" +
                      $"       {_trafficService.GetCrossroadByPosition(_destination).Name}   ({_destination.X}, {_destination.Y})\r\n";
            report += $"   • Pozostała ilość ruchów do celu: {MovesLeftToDestination()}";

            return report;
        }

        public string CurrentLocationName()
        {
            List<Vector3> crossroadsLocationsList = new List<Vector3>(_trafficService.Crossroads.Select(c => c.Position).ToList());
            if (crossroadsLocationsList.Contains(_position))
                return _trafficService.GetCrossroadByPosition(_position).Name;
            return _trafficService.GetStreetByPosition(_position).Name;
        }

        public int MovesLeftToDestination()
        {
            Street currentStreet = _trafficService.GetStreetByPosition(_position);
            if (currentStreet == null)
                return 0;
            int destinationIndex =
                _destination == currentStreet.StartCoord ? -1 
                : _destination == currentStreet.EndCoord ? currentStreet.Coordinates.Count() + 1 
                : 0;
            int currentPositionIndex = currentStreet.Coordinates.FindIndex(c => c == _position);

            return Math.Abs(destinationIndex - currentPositionIndex);
        }
        
        public string Move()
        {
            string report = GenerateReport() + "\r\n";
            if (DestinationReached)
            {
                report += $"Cel został osiągnięty!\r\n";
                report += $"Nowy cel: {SetNewDestination().Name}\r\n";
            }
            else // Fakt, że DestinationReached = false, oznacza, że następny ruch mieści się w zakresie drogi
            {
                Vector3 nextPosition = CurrentRoad[PositionIndexOfRoad + _direction];
                bool movePossible = !_trafficService.Vehicles
                    .Where(v => _trafficService.CoordsEqual(v.Position, nextPosition))
                    .Any(vh => vh.Direction == _direction);

                if (movePossible)
                {   
                    _position = CurrentRoad[PositionIndexOfRoad + _direction];
                    report += "Wykonano ruch w kierunku celu\r\n";
                }
                else
                    report += "Ruch niemożliwy, ponieważ przed samochodem stoi inny pojazd\r\n";
            }

            return report;
        }

        public Crossroad SetNewDestination()
        {
            Random random = new Random();
            List<Street> nextStreets = _trafficService.GetCrossroadByPosition(_destination).Streets
                .Where(s => s != _trafficService.GetStreetByPosition(_position)).ToList();

            Street nextStreet = nextStreets.Count() == 1 ? nextStreets[0] 
                : nextStreets[random.Next(nextStreets.Count())];

            if (_trafficService.CoordsEqual(nextStreet.StartCoord, _destination))
            {
                Direction = 1;
                _destination = nextStreet.EndCoord;
                _position = nextStreet.Coordinates.First();
            }
            else if (_trafficService.CoordsEqual(nextStreet.EndCoord, _destination))
            {
                Direction = -1;
                _destination = nextStreet.StartCoord;
                _position = nextStreet.Coordinates.Last();
            }

            return _trafficService.GetCrossroadByPosition(_destination);
        }

    }
}
