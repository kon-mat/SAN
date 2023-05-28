using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApp
{
    public class Vehicle : IMover
    {
        private readonly int _id;
        private readonly string _registration;
        private readonly int _speed;
        private int _direction;
        private Vector3 _position;

        public Vehicle(int id, string registration, int speed, int direction, Vector3 position)
        {
            _id = id;
            _registration = registration;
            _speed = speed;
            Direction = direction;
            _position = position;
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
                if (value == -1 || value == 0 || value != 1)
                    _direction = value;
            }
        }

        public Vector3 Position { get { return _position; } }

        public (Vector3, Vector3) Wheels
        {
            get
            {
                return (new Vector3(_position.X - 1, _position.Y), new Vector3(_position.X + 2, _position.Y));
            }
        }

        public List<Vector3> BodyPoints
        {
            get 
            {
                List<Vector3> bodyPoints = new List<Vector3>();
                bodyPoints.Add(new Vector3(_position.X - 2, _position.Y));
                bodyPoints.Add(new Vector3(_position.X - 2, _position.Y + 1));
                bodyPoints.Add(new Vector3(_position.X - 1, _position.Y + 1));
                bodyPoints.Add(new Vector3(_position.X, _position.Y + 2));
                bodyPoints.Add(new Vector3(_position.X + 1, _position.Y + 2));
                bodyPoints.Add(new Vector3(_position.X + 2, _position.Y + 1));
                bodyPoints.Add(new Vector3(_position.X + 3, _position.Y + 1));
                bodyPoints.Add(new Vector3(_position.X + 3, _position.Y + 0));
                bodyPoints.Add(new Vector3(_position.X - 2, _position.Y));

                return bodyPoints;
            }
        }

        public Vector3 NewPosition(int X, int Y)
        {
            return (new Vector3(X, Y) != _position) ? new Vector3(X, Y) : null;
        }


        public void Move()
        {
            /*
             * jesli samochod porusza sie po drodze w okreslonym kierunku
             *      nastepnym punktem jest punkt petli po koordynatach drogi
             *      sprawdz czy na nastepnym punkcie nie znajduje sie inny samochod poruszajacy sie w tym samym kierunku
             *      
             */




        }
    }
}
