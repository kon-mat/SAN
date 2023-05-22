using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApp.Entities
{
    public class Point
    {
        private Vector3 _position;
        private double _thickness;

        public Point()
        {
            Position = Vector3.Zero;
            Thickness = 0.0;
        }

        public Point(Vector3 position)
        {
            Position = position;
            Thickness = 0.0;
        }

        public Vector3 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public double Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }
    }
}
