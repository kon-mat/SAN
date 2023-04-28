using BeehiveManagmentSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Interfaces
{
    internal interface IQueen
    {
        public bool AddNectarToResources(NectarCollector collector);
        public int ProduceHoney(Worker worker);
    }
}
