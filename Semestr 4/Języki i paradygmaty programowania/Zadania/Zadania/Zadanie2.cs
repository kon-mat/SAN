using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Zadania
{
    internal class Zadanie2
    {
        Dictionary<long, int> NumbersChain;

        public Zadanie2()
        {
            NumbersChain = new Dictionary<long, int>();
        }

        public int Collatz(int number)
        {
            int chain = 0;
            long collatzNumber = number;
            while (true)
            {
                if (collatzNumber == 1)
                {
                    if (!NumbersChain.ContainsKey(collatzNumber))
                        NumbersChain.Add(collatzNumber, chain);
                    return chain;
                }

                if (NumbersChain.ContainsKey(collatzNumber))
                    return chain += NumbersChain[collatzNumber];
                collatzNumber = collatzNumber % 2 == 0 ? collatzNumber / 2 : 3 * collatzNumber + 1;
                chain++;
            }
        }

    }
}