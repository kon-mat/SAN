using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApp.Entities
{
    public class Line
    {
        private Vector3 _startPoint;
        private Vector3 _endPoint;
        private double _thickness;

        public Line()
            : this(Vector3.Zero, Vector3.Zero)
        {
        }

        public Line(Vector3 start, Vector3 end)
        {
            StartPoint = start;
            EndPoint = end;
            Thickness = 0.0;
        }


        public Vector3 StartPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; }
        }

        public Vector3 EndPoint
        {
            get { return _endPoint; }
            set { _endPoint = value; }
        }

        public double Thickness
        {
            get { return _thickness; }
            set { _thickness = value; }
        }
    }
}
