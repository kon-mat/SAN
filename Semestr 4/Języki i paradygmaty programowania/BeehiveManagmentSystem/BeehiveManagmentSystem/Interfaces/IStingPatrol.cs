using BeehiveManagmentSystem.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Interfaces
{
    internal interface IStingPatrol
    {
        public double AttackEnemy();
        public bool SharpenStinger();
        public string DoPatrol();
        public void GrowStinger();

    }
}
