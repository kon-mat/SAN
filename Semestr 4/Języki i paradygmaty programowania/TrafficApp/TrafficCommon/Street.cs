using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TrafficCommon
{
    public class Street
    {
        private readonly int _id;
        private readonly string _name;
        private readonly District _district;
        private readonly List<int[]> _mainCoords;
        private List<int[]> _coordinates;

        public Street(int id, string name, District district, List<int[]> mainCoords)
        {
            _id = id;
            _name = name;
            _district = district;
            _district.Streets.Add(this);
            _mainCoords = mainCoords;
            _coordinates = new List<int[]>();
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string District { get { return _district.Name; } }
        public List<int[]> Coordinates { get { return _coordinates; } }

        public int[] StartCoord { get { return _coordinates.First(); } }
        public int[] EndCoord { get { return _coordinates.Last(); } }

    }
}
