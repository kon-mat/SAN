﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficApp
{
    public partial class TrafficApp : Form
    {
        public TrafficApp()
        {
            InitializeComponent();
        }
        private TrafficService trafficService = new TrafficService();
        private List<Entities.Point> _points = new List<Entities.Point>();
        private List<Entities.Line> _lines = new List<Entities.Line>();
        private Vector3 _currentPosition;
        private Vector3 _firstPoint;
        private int _drawIndex = -1;
        private bool _activeDrawing = false;
        private int _clickNum = 1;

        private void drawing_MouseMove(object sender, MouseEventArgs e)
        {
            _currentPosition = PointToCartesian(e.Location);
            pixelCoordsLabel.Text = string.Format("{0}, {1}", e.Location.X, e.Location.Y);
            cartesianCoordsLabel.Text = string.Format("{0,0:F3}, {1,0:F3}", _currentPosition.X, _currentPosition.Y);
            drawing.Refresh();
        }

        // Get screen dpi
        private float DPI
        {
            get
            {
                using (var g = CreateGraphics())
                    return g.DpiX;
            }
        }

        //Convert system point to world point 
        private Vector3 PointToCartesian(Point point)
        {
            return new Vector3(Pixel_to_Mn(point.X), Pixel_to_Mn(drawing.Height - point.Y));
        }

        // Convert pixels to millimeters
        private float Pixel_to_Mn(float pixel)
        {
            return pixel * 25.4F / DPI;
        }

        private void drawing_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_activeDrawing)
                {
                    switch (_drawIndex)
                    {
                        case 0: // point
                            _points.Add(new Entities.Point(_currentPosition));
                            break;
                        case 1: // line
                            switch (_clickNum)
                            {
                                case 1:
                                    _firstPoint = _currentPosition;
                                    _points.Add(new Entities.Point(_currentPosition));
                                    _clickNum++;
                                    break;
                                case 2:
                                    _lines.Add(new Entities.Line(_firstPoint, _currentPosition));
                                    _points.Add(new Entities.Point(_currentPosition));
                                    _firstPoint = _currentPosition;
                                    break;
                            }
                            break;

                    }
                    drawing.Refresh();
                }
            }
        }

        private void drawing_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParameters(Pixel_to_Mn(drawing.Height));
            Pen pen = new Pen(Color.Blue, 0.1F);
            Pen extpen = new Pen(Color.Gray, 0.1F);

            // Draw all points
            if (_points.Count > 0)
            {
                foreach (Entities.Point p in _points)
                {
                    e.Graphics.DrawPoint(new Pen(Color.Red, 0), p);
                }
            }

            // Draw all lines
            if (_lines.Count > 0)
            {
                foreach (Entities.Line l in _lines)
                {
                    e.Graphics.DrawLine(pen, l);
                }
            }
            // Draw line extended
            switch (_drawIndex)
            {
                case 1:
                    if (_clickNum == 2)
                    {
                        Entities.Line line = new Entities.Line(_firstPoint, _currentPosition);
                        e.Graphics.DrawLine(extpen, line);
                    }
                    break;
            }

        }

        private void pointBtn_Click(object sender, EventArgs e)
        {
            _drawIndex = 0;
            _activeDrawing = true;
            drawing.Cursor = Cursors.Cross;
        }

        private void lineBtn_Click(object sender, EventArgs e)
        {
            _drawIndex = 1;
            _activeDrawing = true;
            drawing.Cursor = Cursors.Cross;
        }

        private void streetBtn_Click(object sender, EventArgs e)
        {
            
            foreach (Street street in trafficService.Streets)
            {
                if (street.MainCords.Count >= 2)
                    for (int i = 0; i < street.MainCords.Count() - 1; i++)
                    {
                        Vector3 firstPoint = new Vector3(street.MainCords[i].Item1, street.MainCords[i].Item2);
                        Vector3 secondPoint = new Vector3(street.MainCords[i + 1].Item1, street.MainCords[i + 1].Item2);

                        _lines.Add(new Entities.Line(firstPoint, secondPoint));
                    }   
            }
        }





    }
}
