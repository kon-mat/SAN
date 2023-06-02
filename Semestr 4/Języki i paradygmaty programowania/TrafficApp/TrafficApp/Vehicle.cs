using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficApp
{
    public class Vehicle //: IMover
    {
        private readonly int _id;
        private readonly string _registration;
        private readonly int _speed;
        private int _direction;
        private Vector3 _position;
        private Vector3 _destination;
        private Vector3 _lastPosition;
        private string _report;
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
        public Vector3 LastPosition { get { return _lastPosition; } }

        public string GenerateReport()
        {
            string report = $"\r\nSzczegóły pojazdu o rejestracji: {Registration}\r\n";
            report += $"   • Aktualnie znajduje się na: {CurrentLocationName()}\r\n";
            report += $"   • Zmierza do: {_trafficService.GetCrossroadByPosition(_destination).Name}\r\n";
            report += $"   • Pozostała ilość ruchów do celu: {MovesLeftToDestination()}";
            //report +=;

            return report;
        }

        private string CurrentLocationName()
        {
            List<Vector3> crossroadsLocationsList = new List<Vector3>(_trafficService.Crossroads.Select(c => c.Position).ToList());
            if (crossroadsLocationsList.Contains(_position))
                return _trafficService.GetCrossroadByPosition(_position).Name;
            return _trafficService.GetStreetByPosition(_position).Name;
        }

        private int MovesLeftToDestination()
        {
            Street currentStreet = _trafficService.GetStreetByPosition(_position);
            int destinationIndex =
                _destination == currentStreet.StartCoord ? -1 
                : _destination == currentStreet.EndCoord ? currentStreet.Coordinates.Count() + 1 
                : 0;
            int currentPositionIndex = currentStreet.Coordinates.FindIndex(c => c == _position);

            return Math.Abs(destinationIndex - currentPositionIndex);
        }








        public bool SetPosition(int X, int Y)
        {
            if ((int)Position.X != X && (int)Position.Y != Y)
            {
                _lastPosition = _position;
                _position = new Vector3(X, Y);
                return true;
            }
            return false;
        }





        /*
        public string Move()
        {



            string report = $"\r\nSamochód {Registration}";
            (int, int) nextCoord = _trafficService.GetStreetByCoordinate(_position).Coordinates[_trafficService.GetCoordIndexByCoordinate(_position) + Direction * Speed];

            // Dojechano do celu
            if (nextCoord.Item1 == (int)_destination.X && nextCoord.Item2 == (int)_destination.Y)
            {
                report += $"\r\n   Osiągnięto cel: {Destination.X}, {Destination.Y}";
                if (SetNewDestination())
                    report += $"\r\n   Uworzono nowy cel: {Destination.X}, {Destination.Y}";
                return report;
            }

            // W drodze do celu
            if (SetPosition(nextCoord.Item1, nextCoord.Item2))
            {
                // ## popracować nad poprawnym przemieszczeniem
                // Udało się wykonać ruch
                report += $"\r\n   Przemieszczono z: {_lastPosition.X}, {_lastPosition.Y}";
                report += $"\r\n   Przemieszczono na: {_position.X}, {_position.Y}";
                report += $"\r\n   Aktualny index: {_trafficService.GetCoordIndexByCoordinate(_position)}";
                report += $"\r\n   Index docelowy: {_trafficService.GetCoordIndexByCoordinate(_destination)}";
                report += $"\r\n   Pozostało metrów: {_trafficService.GetCoordIndexByCoordinate(_destination) - _trafficService.GetCoordIndexByCoordinate(_position)}";
            }

            // # sprawdzic czy samochod nie jest przed
            return report;
        }


        /*

        public Street DrawNextStreet()
        {
            Crossroad currentCrossroad = _trafficService.GetCrossroadByPosition(_position);
            List<Street> streetsToDraw = currentCrossroad.Streets;
            Random random = new Random();

            // Remove last street on which the vehicle traveled from streets to draw
            for (int i = 0; i < streetsToDraw.Count(); i++)
                if (streetsToDraw[i].Coordinates.Contains(((int)_lastPosition.X, (int)_lastPosition.Y)))
                {
                    streetsToDraw.RemoveAt(i);
                    break;
                }

            return streetsToDraw.Count() == 1 ? streetsToDraw[0] : streetsToDraw[random.Next(streetsToDraw.Count())];
        }

        public bool SetNewDestination()
        {

            Street nextStreet = DrawNextStreet();
            if (nextStreet.StartCoord == ((int)_position.X, (int)_position.Y))
            {
                _destination = new Vector3(nextStreet.EndCoord.Item1, nextStreet.EndCoord.Item2);
                Direction = 1;
                return true;
            }
            else if (nextStreet.EndCoord == ((int)_position.X, (int)_position.Y))
            {
                _destination = new Vector3(nextStreet.StartCoord.Item1, nextStreet.StartCoord.Item2);
                Direction = -1;
                return true;
            }
            else
            {
                MessageBox.Show("Pojazd nie znajduje się na skrzyżowaniu.");
                return false;
            }
        }

        public bool SetFirstDestination()
        {
            Street currentStreet = _trafficService.GetStreetByCoordinate(_position);
            if (currentStreet == null)
                return false;
            else
            {
                if (Direction == 1)
                    _destination = new Vector3(currentStreet.EndCoord.Item1, currentStreet.EndCoord.Item2);
                else if (Direction == -1)
                    _destination = new Vector3(currentStreet.StartCoord.Item1, currentStreet.StartCoord.Item2);
                else
                    MessageBox.Show($"Direction nie powinna byc rowna 0 dla {this.Registration}");
            }
            return true;


        }

        */


    }
}
