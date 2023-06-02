using System.Collections.Generic;
using System.Linq;

namespace TrafficApp
{
    public class Crossroad
    {
        private readonly int _id;
        private readonly Vector3 _position;
        private readonly List<Street> _streets;

        public Crossroad(int id, Vector3 position, List<Street> streets)
        {
            _id = id;
            _position = position;
            _streets = streets;
        }

        public int Id { get { return _id; } }
        public Vector3 Position { get { return _position; } }
        public List<Street> Streets { get { return _streets; } }

        public void AddStreet(Street street)
        {
            if (!_streets.Contains(street))
                _streets.Add(street);

        }

        public string Name
        {
            get
            {
                string name = "Skrzyżowanie: ";
                foreach (Street street in Streets)
                    name += street == Streets.Last() ? street.Name : $"{street.Name}, ";
                return name;
            }
        }
    }
}
