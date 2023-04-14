using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpVersions
{
    internal class Funkcyjne
    {
        Dictionary<long, long> FibResults;

        public Funkcyjne()
        {
            FibResults = new Dictionary<long, long>();
        }

        public double Zad2ab(double number, double epsilon)
        {
            int i = 0;
            double x0 = number / 3;
            double x1 = (2 * x0 + number / (x0 * x0)) / 3; // pierwsza iteracja
            while (Math.Abs(x1 - x0) > epsilon)
            {
                Console.Write($"{i++}, ");
                x0 = x1;
                x1 = (2 * x0 + number / (x0 * x0)) / 3;
            }
            return x1;
        }

        public double Zad2c(double number, int N)
        {

            double x0 = number / 3;
            double x1 = (2 * x0 + number / (x0 * x0)) / 3; // pierwsza iteracja
            for (int i = 1; i < N; i++)
            {
                x0 = x1;
                x1 = (2 * x0 + number / (x0 * x0)) / 3;
            }
            return x1;
        }

        public long Zad3a(long number, ref long step)
        {
            step++; // Każde wywołanie funkcji jest liczone jako jeden krok

            if (number < 2)
                return number;
            else
                return Zad3a(number - 1, ref step) + Zad3a(number - 2, ref step);

            /*

            fib  n    steps                                         różnica względem fib
            2    1   - 1                                            fib - 1
            3    2   - 3     = 1 + 1 + 1     = g(1) + g(1) + 1      fib
            5    3   - 5     = 3 + 1 + 1     = g(2) + g(1) + 1      fib
            8    4   - 9     = 5 + 3 + 1     = g(3) + g(2) + 1      fib + 1
            13   5   - 15    = 9 + 5 + 1     = g(4) + g(3) + 1      fib + 2
            21   6   - 25    = 15 + 9 + 1    = g(5) + g(4) + 1      fib + 4     
            34   7   - 41    = 25 + 15 + 1   = g(6) + g(5) + 1      fib + 7    
            55   8   - 67    = 41 + 25 + 1   = g(7) + g(6) + 1      fib + 12
            89   9   - 109   = 67 + 41 + 1   = g(8) + g(7) + 1      fib + 20
            144  10  - 177   = 109 + 67 + 1  = g(9) + g(8) + 1      fib + 32
            
             */
        }

        public long Zad3b(long number, ref long step)
        {
            step++; // Każde wywołanie funkcji jest liczone jako jeden krok

            if (!FibResults.ContainsKey(number))
            {
                if (number < 2)
                    FibResults.Add(number, number);
                else
                    FibResults.Add(number, Zad3b(number - 1, ref step) + Zad3b(number - 2, ref step));
            }

            return FibResults[number];
        }

        public List<List<int>> Zad4(List<int> collection)
        {
            collection.Sort();
            Console.Write("Zbiór potęgowy dla zbioru: ");
            DisplayList(collection);
            Console.WriteLine();
            List<List<int>> powerset = new List<List<int>>() { new List<int>() };
            List<int> powersetElement = new List<int>();
            List<int> powersetElementBug = new List<int>();

            if (collection.Count() < 1)
                return powerset;

            // Zbiory jednoelementowe
            for (int i = 0; i < collection.Count(); i++)
                powerset.Add(new List<int>() { collection[i] });

            if (collection.Count() < 2)
                return powerset;

            for (int i = 1; i < collection.Count(); i++)
            {
                powerset = powerset.OrderBy(p => p.Count).ToList();
                int currentPowersetCount = powerset.Count();
                int indexOfFirstLargestCount = powerset.IndexOf(powerset.First(p => p.Count == i));
                if (indexOfFirstLargestCount == 0)
                    indexOfFirstLargestCount = 1;

                for (int j = indexOfFirstLargestCount; j < currentPowersetCount; j++)
                {
                    int indOfLAst = collection.IndexOf(powerset[j].Last());
                    if (indOfLAst != collection.Count() - 1)
                    {
                        for (int k = indOfLAst + 1; k <= collection.Count() - 1; k++)
                        {
                            powerset.Add(new List<int>());
                            foreach (var vals in powerset[j])
                                powerset.Last().Add(vals);

                            powerset.Last().Add(collection[k]);
                        }

                    }

                }

            }

            return powerset;
        }

        public void DisplayPowerset(List<List<int>> powerset)
        {
            for (int i = 0; i < powerset.Count; i++)
            {
                DisplayList(powerset[i]);
                Console.WriteLine();
            }
            
        }

        public void DisplayList(List<int> list)
        {
            Console.Write("{ ");
            foreach (int number in list)
                Console.Write(number + " ");
            Console.Write("}");

        }























        /* Zadania

        Zadanie 2.
            a.Wzór na pierwiastek sześcienny - zaimplementować
            b.Przebieg procedury Herona uzależnić od Epsilon
            c. Przebieg procedury Herona uzależnić od N (ilości kroków)


        Zadanie 3. Dany jest ciąg Fibonacciego
            (defn fib [n] (if (< n 2) n (+ (fib (- n 1)) (fib (- n 2)))))
            a. Wyznaczyć dokładny wzór opisujący ilość kroków niezbędnych do obliczenia (fib n) 
            b. Zaproponować procedurę rekurencyjną fib, która generuje proces iteracyjny 
            c. Zastosować formę (recur …) i policzyć Fib(10000)


        Zadanie 4. Zbiór potęgowy (ang. powerset)
            Napisać procedurę, która przyjmuje kolekcję elementów (lista, wektor, zbiór) i generuje zbiór potęgowy dla tej kolekcji. Zbiór potęgowy to zbiór wszystkich podzbiorów danego zbioru łącznie ze zbiorem pustym.

            (powerset [1 2 3]) => ([] [1] [2] [3] [1 2] [1 3] [2 3] [1 2 3])


        Zadanie 5.
            a. Zrealizuj pierwiastek sześcienny z wykorzystaniem average-damp oraz FIXED-POINT
            b. Zrealizuj pierwiastek sześcienny z wykorzystaniem Newtons-method
            c. Niech f i g będą dwoma funkcjami jednoargumentowymi. Złożenie f z g jest określone jako funkcja x -> f(g(x)). Zdefiniuj procedurę złóż implementującą złożenie funkcji. Przykładowo: ((złóż kwadrat inc) 6) => 49
            d. Jeśli f jest funkcją jednoargumentową określoną na liczbach oraz n jest dowolną liczbą naturalną, to n-krotnym złożeniem funkcji f nazywamy funkcję, której wartością jest wynik n-krotnego zastosowania funkcji f: x -> f(f( … (f(x)) …)) Napisz procedurę realizującą n-krotne złożenie funkcji f wykorzystując rozwiązanie z punktu c.


         */


    }
}
