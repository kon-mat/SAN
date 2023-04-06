using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zadania
{
    internal class Zadanie1
    {
        public Dictionary<int, string> NumbersDictionary = new Dictionary<int, string>()
        {
            {0, ""},
            {1, "jeden"},
            {2, "dwa"},
            {3, "trzy"},
            {4, "cztery"},
            {5, "pięć"},
            {6, "sześć"},
            {7, "siedem"},
            {8, "osiem"},
            {9, "dziewięć"},
            {10, "dziesięć"},
            {11, "jedenaście"},
            {12, "dwanaście"},
            {13, "trzynaście"},
            {14, "czternaście"},
            {15, "piętnaście"},
            {16, "szesnaście"},
            {17, "siedemnaście"},
            {18, "osiemnaście"},
            {19, "dziewiętnaście"},
            {20, "dwadzieścia"},
            {30, "trzydzieści"},
            {40, "czterdzieści"},
            {50, "pięćdziesiąt"},
            {60, "sześćdziesiąt"},
            {70, "siedemdziesiąt"},
            {80, "osiemdziesiąt"},
            {90, "dziewięćdziesiąt"},
            {100, "sto"},
            {200, "dwieście"},
            {300, "trzysta"},
            {400, "czterysta"},
            {500, "pięćset"},
            {600, "sześćset"},
            {700, "siedemset"},
            {800, "osiemset"},
            {900, "dziewięćset"},
            {1000, "tysiąc"},
        };

        public string IntNumberToStringNumber(int number)
        {
            return number % 100 == 0 || number == 1000 ? NumbersDictionary[number] : $"{NumbersDictionary[number - number % 100]} {TensToString(number)}";
        }

        public string TensToString(int number)
        {
            return number % 100 <= 20 ? NumbersDictionary[number % 100] : $"{NumbersDictionary[number % 100 - number % 10]} {NumbersDictionary[number % 10]}";
        }

        public int CountLetters(string stringNumber)
        {
            int letters = 0;
            List<string> digits = stringNumber.Split(" ").ToList();
            foreach (string digit in digits)
                letters += digit.Length;
            return letters;
        }
    }
}

