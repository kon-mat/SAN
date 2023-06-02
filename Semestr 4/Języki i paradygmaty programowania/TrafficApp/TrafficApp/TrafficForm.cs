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
            report += GenerateVehiclesReport(false);
            return report;
        }

        private string GenerateVehiclesReport(bool move)
        {
            string report = "";
            foreach (Vehicle vehicle in trafficService.Vehicles)
                report += "\n\r" + vehicle.GenerateReport() + "\n\r";
            return report;
        }






        private void moveBtn_Click(object sender, EventArgs e)
        {
            string report = "";
            foreach (Vehicle vehicle in trafficService.Vehicles)
                report += vehicle.Move();
            
            reportText.Text = report;
        }



        
    }
}
