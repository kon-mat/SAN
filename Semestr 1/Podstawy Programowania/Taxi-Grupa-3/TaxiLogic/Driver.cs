using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiLogic
{
    public class Driver
    {
        public Driver(int id, string car, District currentDistrict)
        {
            Id = id;
            Car = car;
            CurrentDistric = currentDistrict;
            statusAvaible = true;
        }

        public District CurrentDistric;
        public int Id { get; private set; }
        public string Car { get; private set; }
        private bool statusAvaible;
        public bool StatusAvaible
        {
            get { return statusAvaible; }
            set { statusAvaible = value; }
        }

        private int timeToOrderedDistrict;
        public int TimeToOrderedDistrict
        {
            get { return timeToOrderedDistrict; }
            set { timeToOrderedDistrict = value; }
        }
    }
}
