using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficApp
{
    public class Street
    {
        private readonly int _id;
        private readonly string _name;
        private readonly District _district;
        private List<Crossroad> _crossroads;
        private readonly List<Vector3> _mainCoords;
        private List<Vector3> _coordinates;  // Excluding First Coord and End Coord

        public Street(int id, string name, District district, List<Vector3> mainCoords)
        {
            _id = id;
            _name = name;
            _district = district;
            _district.Streets.Add(this);
            _mainCoords = mainCoords;
            _coordinates = CreateStreetCoordinates(_mainCoords);
            _crossroads = new List<Crossroad>();
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string District { get { return _district.Name; } }
        public List<Crossroad> Crossroads { get { return _crossroads; } }
        public List<Vector3> Coordinates { get { return _coordinates; } }
        public List<Vector3> MainCords { get { return _mainCoords; } }

        public Vector3 StartCoord { get { return _mainCoords.First(); } }
        public Vector3 EndCoord { get { return _mainCoords.Last(); } }

        public void AddCrossroad(Crossroad crossroad)
        {
            if (_crossroads.Contains(crossroad))
                if (StartCoord == crossroad.Position)
                    _crossroads.Insert(0, crossroad);
                else if (EndCoord == crossroad.Position)
                    _crossroads.Add(crossroad);
        }

        public List<Vector3> CreateStreetCoordinates(List<Vector3> mainCoords)
        {
            List<Vector3> coordinates = new List<Vector3>();
            if (_mainCoords.Count() >= 2)
            {
                for (int i = 0; i < _mainCoords.Count() - 1; i++)
                    coordinates = coordinates.Concat(BresenhamLine(_mainCoords[i].X, _mainCoords[i].Y, _mainCoords[i + 1].X, _mainCoords[i + 1].Y)).ToList();
                coordinates.RemoveAt(0);
            }

            return coordinates;
        }

        public Vector3 NewCoord(double x, double y)
        {
            return new Vector3(x, y);
        }

        public List<Vector3> BresenhamLine(double x0, double y0, double x1, double y1)
        {
            List<Vector3> linePoints = new List<Vector3>();

            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep)
            {
                // If the line is steep, swap the x and y axes
                (x0, y0) = (y0, x0);
                (x1, y1) = (y1, x1);
            }

            bool swapped = false;
            if (x0 > x1)
            {
                // If the starting point is to the right of the end point, swap them places
                (x0, x1) = (x1, x0);
                (y0, y1) = (y1, y0);
                swapped = true;
            }

            double dx = x1 - x0;
            double dy = Math.Abs(y1 - y0);
            double error = dx / 2;
            double ystep = (y0 < y1) ? 1 : -1;
            double y = y0;

            for (double x = x0; x <= x1; x++)
            {
                // We add a point to the line depending on whether the line is steep or not
                linePoints.Add(steep ? NewCoord(y, x) : NewCoord(x, y));

                error -= dy;
                if (error < 0)
                {
                    y += ystep;
                    error += dx;
                }
            }

            if (swapped)
            {
                linePoints.Reverse(); // We invert the points if we swapped the start and end points
            }

            linePoints.RemoveAt(linePoints.Count - 1);
            return linePoints;
        }

    }
}