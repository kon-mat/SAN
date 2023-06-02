

namespace TrafficApp
{
    public class Vector3
    {
        private double _x;
        private double _y;
        private double _z;

        public Vector3(double x, double y)
        {
            X = x;
            Y = y;
            Z = 0.0;
        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Z
        {
            get { return _z; }
            set { _z = value; }
        }

        public System.Drawing.PointF ToPointF
        {
            get
            {
                return new System.Drawing.PointF((float)X, (float)Y);
            }
        }

        public static Vector3 Zero
        {
            get { return new Vector3(0.0, 0.0, 0.0); }
        }

    }
}
