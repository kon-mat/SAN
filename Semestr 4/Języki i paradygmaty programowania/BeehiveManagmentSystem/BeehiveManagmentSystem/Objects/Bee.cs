using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Object
{
    internal class Bee
    {
        private int _weight;

        public Bee(int weight)
        {
            _weight = weight;
        }

        // Spożycie miodu zależy od liczby zmian pozostałych do zakończenia zadania
        public virtual int ShiftsLeft { get { return 0; } }

        // Każda pszczoła konsumuje miód, więc ta metoda została umieszczona w klasie bazowej
        public virtual double GetHoneyConsumption()
        {
            double consumption;
            if (ShiftsLeft == 0)    // pszczoła aktualnie nie pracuje
                consumption = 7.5;
            else                    // pszczoła aktualnie pracuje
                consumption = ShiftsLeft + 9;
            if (_weight > 150)      // jeżeli pszczoła waży powyżej 150mg, to spożywa więcej miodu
                consumption *= 1.35;
            return consumption;
        }
    }
}
