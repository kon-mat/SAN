using Accessibility;
using BeehiveManagmentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Objects
{
    internal class NectarCollector : Worker, INectarCollector
    {
        private double _nectar = 0;
        private Random _random = new Random();

        public NectarCollector(int weight, List<Job> jobsICanDo, Hive hive) 
            : base(weight, jobsICanDo, hive)
        {
        }

        public double Nectar { get { return _nectar; } }
        public double NectarLimit { get { return 2 * Weight; } }
        public bool Overloaded { get { return _nectar >= NectarLimit ? true : false; } }

        public bool FindFlowers()
        {
            if (_random.Next(1, 11) <= 8)
                return true;
            return false;
        }

        public double GatherNectar(double nectar)
        {
            if (_nectar + nectar > NectarLimit)
                nectar = NectarLimit - _nectar;
            _nectar += nectar;
            return nectar;
        }

        public double ReturnToHive()
        {
            double returnedNectar = _nectar;
            Hive.ReceiveNectar(_nectar);
            _nectar = 0;
            return returnedNectar;
        }

        public string CollectNectar(bool lastShift)
        {
            string report = "";
            if (Overloaded || lastShift)
            {
                double returnedNectar = ReturnToHive();
                report += $"Dostarczyła {returnedNectar} mg nektaru do bazy.";
            }
            else
            {
                if (FindFlowers())
                {
                    double gatheredNectar = GatherNectar(_random.Next(30, 61) * Weight / 50);
                    report += $"Zebrała {gatheredNectar} mg nektaru. Aktualnie posiada {_nectar} mg.";
                }
                else
                    report += $"Nie udało jej się odnaleźć kwiatów do zbiorów nektaru. Aktualnie posiada {_nectar} mg.";
            }
            return report;

        }

    }
}
