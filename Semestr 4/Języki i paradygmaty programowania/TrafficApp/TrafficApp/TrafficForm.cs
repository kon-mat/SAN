using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrafficApp
{
    public partial class TrafficApp : Form
    {
        private TrafficService trafficService;

        public TrafficApp()
        {
            trafficService = new TrafficService();
            InitializeComponent();
            reportText.Text = GenerateEnvironment();
        }

        private string GenerateEnvironment()
        {
            string report = "Utworzono:\r\n";
            report += $"   • Osiedla:   {trafficService.Districts.Count()}\r\n";
            report += $"   • Ulice:   {trafficService.Streets.Count()}\r\n";
            report += $"   • Skrzyżowania:   {trafficService.Crossroads.Count()}\r\n";
            report += $"   • Pojazdy:   {trafficService.Vehicles.Count()}\r\n";
            report += "\r\n";
            report += GenerateVehiclesReport();
            return report;
        }

        private string GenerateVehiclesReport()
        {
            string report = "";
            foreach (Vehicle vehicle in trafficService.Vehicles)
                report += "\n\r" + vehicle.GenerateReport() + "\n\r";
            return report;
        }





        private void streetBtn_Click(object sender, EventArgs e)
        {
            reportText.Text = GenerateVehiclesReport();

            //string report = "";
            //foreach (Street street in trafficService.Streets)
            //{
            //    if (street.MainCords.Count >= 2)
            //        for (int i = 0; i < street.MainCords.Count() - 1; i++)
            //        {
            //            Vector3 firstPoint = new Vector3(street.MainCords[i].Item1, street.MainCords[i].Item2);
            //            Vector3 secondPoint = new Vector3(street.MainCords[i + 1].Item1, street.MainCords[i + 1].Item2);

            //            _lines.Add(new Entities.Line(firstPoint, secondPoint));
            //        }
            //    report += $"\r\nDodano ulicę: {street.Name}";
            //}

            //reportText.Text = report;
        }

        private void vehicleBtn_Click(object sender, EventArgs e)
        {
            //string report = "";

            //if (trafficService.Vehicles != null)
            //    foreach (Vehicle vehicle in trafficService.Vehicles)
            //    {
            //        for (int i = 0; i < vehicle.BodyPoints.Count() - 1; i++)
            //            _carLines.Add(new Entities.Line(vehicle.BodyPoints[i], vehicle.BodyPoints[i + 1]));
            //        _points.Add(new Entities.Point(vehicle.Wheels.Item1));
            //        _points.Add(new Entities.Point(vehicle.Wheels.Item2));

            //        if (vehicle.SetFirstDestination())
            //            report += $"\r\nUtworzono nowy samochód: {vehicle.Registration}" +
            //                $"\r\n   Cel: {vehicle.Destination.X}, {vehicle.Destination.Y}";
            //    }

            //reportText.Text = report;
        }

        private void moveBtn_Click(object sender, EventArgs e)
        {
            //reportText.Text = trafficService.MoveVehicles();





            //foreach (Vehicle vehicle in trafficService.Vehicles)
            //{
            //    double xDiff = vehicle.Position.X - vehicle.LastPosition.X;
            //    double yDiff = vehicle.Position.Y - vehicle.LastPosition.Y;
            //    foreach (Vector3 bodyPoint in vehicle.BodyPoints)
            //    {
            //        bodyPoint.X += xDiff;
            //        bodyPoint.Y += yDiff;
            //    }
                
            //    // #




        }

        private void beforeMove_Click(object sender, EventArgs e)
        {
            //string report = "";
            //foreach (Vehicle vehicle in trafficService.Vehicles)
            //{
            //    report += $"\r\nSamochód {vehicle.Registration}";
            //    report += $"\r\n   Położenie: {vehicle.Position.X}, {vehicle.Position.Y}";
            //    report += $"\r\n   Ulica: {trafficService.GetStreetByCoordinate(vehicle.Position).Name}";
            //    report += $"\r\n   Kierunek: {vehicle.Direction}";
            //    report += $"\r\n   Cel: {vehicle.Destination.X}, {vehicle.Destination.Y}";

            //    report += $"\r\n-M  CrossroadByPostion - dest: {trafficService.GetCrossroadByPosition(vehicle.Destination).Name}";
            //    report += $"\r\n-M  Get Coord index - na ulicy: {trafficService.GetCoordIndexByCoordinate(vehicle.Position)}";
            //    report += "\r\n";
            //}

            //reportText.Text = report;

        }

        
    }
}
