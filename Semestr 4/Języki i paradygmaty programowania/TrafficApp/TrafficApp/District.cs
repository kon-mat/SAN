using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficApp
{
    public class District
    {
        private readonly int _id;
        private readonly string _name;
        private readonly List<Street> _streets;

        public District(int id, string name)
        {
            _id = id;
            _name = name;
            _streets = new List<Street>();
        }

        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public List<Street> Streets { get { return _streets; } }
    }
}
