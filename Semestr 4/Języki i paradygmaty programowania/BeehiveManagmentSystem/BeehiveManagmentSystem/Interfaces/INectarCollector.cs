using BeehiveManagmentSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Interfaces
{
    internal interface INectarCollector
    {
        public double Nectar { get; }
        public double NectarLimit { get; }
        public bool Overloaded { get; }

        public bool FindFlowers();
        public double GatherNectar(double nectar);
        public double ReturnToHive();
        public string CollectNectar(bool lastShift);
    }
}
