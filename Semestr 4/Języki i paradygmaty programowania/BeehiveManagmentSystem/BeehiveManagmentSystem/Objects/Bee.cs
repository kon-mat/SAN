using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Objects
{
    abstract class Bee
    {
        private int _weight;

        public Bee(int weight)
        {
            _weight = weight;
        }
        
        public int Weight { get { return _weight; } }

        public virtual int ShiftsLeft { get { return 0; } }

        public virtual double GetHoneyConsumption()
        {
            double consumption;
            if (ShiftsLeft == 0)
                consumption = 7.5;
            else
                consumption = ShiftsLeft + 9;
            if (_weight > 150)
                consumption *= 1.35;
            return consumption;
        }
    }
}
