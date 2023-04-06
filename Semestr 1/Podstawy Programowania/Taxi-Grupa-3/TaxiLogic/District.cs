using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiLogic
{
    public class District
    {
        public District(int id, string name, int distanceFromTheCenter)
        {
            Id = id;
            Name = name;
            DistanceFromTheCenter = distanceFromTheCenter;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public int DistanceFromTheCenter { get; private set; }

    }
}
