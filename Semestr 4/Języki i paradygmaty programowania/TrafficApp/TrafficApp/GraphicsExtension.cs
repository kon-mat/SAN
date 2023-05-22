using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApp
{
    public static class GraphicsExtension
    {
        private static float _height;

        public static void SetParameters(this System.Drawing.Graphics g, float height)
        {
            _height = height;
        }

        public static void SetTransform(this System.Drawing.Graphics g)
        {
            g.PageUnit = System.Drawing.GraphicsUnit.Millimeter;
            g.TranslateTransform(0, _height);
            g.ScaleTransform(1.0F, -1.0F);
        }

        public static void DrawPoint(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Point point)
        {
            g.SetTransform();
            System.Drawing.PointF p = point.Position.ToPointF;
            g.DrawEllipse(pen, p.X - 0.5F, p.Y - 0.5F, 1, 1);
            g.ResetTransform();
        }

        public static void DrawLine(this System.Drawing.Graphics g, System.Drawing.Pen pen, Entities.Line line)
        {
            g.SetTransform();
            g.DrawLine(pen, line.StartPoint.ToPointF, line.EndPoint.ToPointF);
            g.ResetTransform();
        }
    }
}
