using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApp
{
    public class Street
    {
        private readonly int _id;
        private readonly string _name;
        private readonly District _district;
        private readonly List<(int, int)> _mainCoords;
        private List<(int, int)> _coordinates;

        public Street(int id, string name, District district, List<(int, int)> mainCoords)
        {
            _id = id;
            _name = name;
            _district = district;
            _district.Streets.Add(this);
            _mainCoords = mainCoords;
            _coordinates = CreateStreetCoordinates();
    }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string District { get { return _district.Name; } }
        public List<(int, int)> Coordinates { get { return _coordinates; } }
        public List<(int, int)> MainCords { get { return _mainCoords; } }

        public (int, int) StartCoord { get { return _coordinates.First(); } }
        public (int, int) EndCoord { get { return _coordinates.Last(); } }

        public List<(int, int)> CreateStreetCoordinates()
        {
            List<(int, int)> coordinates = new List<(int, int)>();

            if (_mainCoords.Count() >= 2)
            {
                for (int i = 0; i < _mainCoords.Count() - 1; i++)
                {
                    coordinates = coordinates.Concat(BresenhamLine(_mainCoords[i].Item1, _mainCoords[i].Item2, _mainCoords[i + 1].Item1, _mainCoords[i + 1].Item2)).ToList();

                }
                    //coordinates.Concat(BresenhamLine(_mainCoords[i].Item1, _mainCoords[i].Item2, _mainCoords[i + 1].Item1, _mainCoords[i + 1].Item2));
                coordinates.Add(_mainCoords.Last());
            }

            return coordinates;
        }


        public List<(int, int)> BresenhamLine(int x0, int y0, int x1, int y1)
        {
            List<(int, int)> linePoints = new List<(int, int)>();

            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                // Jeśli linia jest stroma, zamieniamy osie x i y
                (x0, y0) = (y0, x0);
                (x1, y1) = (y1, x1);
            }

            bool swapped = false;
            if (x0 > x1)
            {
                // Jeśli punkt początkowy jest na prawo od punktu końcowego, zamieniamy je miejscami
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
                swapped = true;
            }

            int dx = x1 - x0;
            int dy = Math.Abs(y1 - y0);
            int error = dx / 2;
            int ystep = (y0 < y1) ? 1 : -1;
            int y = y0;

            for (int x = x0; x <= x1; x++)
            {
                // Dodajemy punkt do linii w zależności od tego, czy linia jest stroma czy nie
                linePoints.Add(steep ? (y, x) : (x, y));

                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }

            if (swapped)
            {
                linePoints.Reverse(); // Odwracamy punkty, jeśli zamieniliśmy punkty początkowy i końcowy
            }

            linePoints.RemoveAt(linePoints.Count - 1);
            return linePoints;
        }




    }
}