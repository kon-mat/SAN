using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpVersions
{
    public class Funkcyjne2
    {
        List<double> x1List;
        Dictionary<long, long> FibResults;

        public Funkcyjne2()
        {
            FibResults = new Dictionary<long, long>();
        }





        // ==================[ Zadanie 1 ]==================
        // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

        public long[] CreateArray(long n)
        {
            long[] arr = new long[n];
            for (long i = 0; i < n; i++) 
            {
                arr[i] = i + 1;
            }
            return arr;
        }

        public long SumArrayElements(long[] n)
        {
            long[] arr = new long[n.Length];
            arr[0] = 1;
            for (long i = 1; i < n.Length; i++)
            {
                arr[i] = arr[i - 1] + n[i];
            }
            return arr[n.Length - 1];
        }

        public long[] SquareArray(long[] n)
        {
            long[] sqrArr = new long[n.Length];
            for (long i = 0; i < n.Length; i++)
            {
                sqrArr[i] = n[i] * n[i];
            }
            return sqrArr;
        }

        public long SquareSumDiffrence(long n)
        {
            if (n == 0 || n == 1)
                return n;
             return SumArrayElements(CreateArray(n)) * SumArrayElements(CreateArray(n)) - SumArrayElements(SquareArray(CreateArray(n)));

        }






        // ==================[ Zadanie 2. ]==================
        /*
            a.Wzór na pierwiastek sześcienny - zaimplementować
            b.Przebieg procedury Herona uzależnić od Epsilon
            c.Przebieg procedury Herona uzależnić od N (ilości kroków)
        */

        public double CalcX1(double x0, double number)
        {
            return (2 * x0 + number / (x0 * x0)) / 3;
        }

        public double HeronEpsilon(double number, double epsilon)
        {
            x1List = new List<double> { number / 3 };               // x0 początkowe
            x1List.Add(CalcX1(x1List[x1List.Count() - 1], number)); // x1
            while (Math.Abs(x1List[x1List.Count() - 1] - x1List[x1List.Count() - 2]) > epsilon)
                x1List.Add(CalcX1(x1List[x1List.Count() - 1], number));
            return x1List[x1List.Count() - 1];
        }

        public double HeronSteps(double number, int steps)
        {
            x1List = new List<double> { number / 3 };               // x0 początkowe
            x1List.Add(CalcX1(x1List[x1List.Count() - 1], number)); // x1
            for (int i = 1; i < steps; i++)
                x1List.Add(CalcX1(x1List[x1List.Count() - 1], number));
            return x1List[x1List.Count() - 1];
        }








        // ==================[ Zadanie 3. ]==================
        /*
            Dany jest ciąg Fibonacciego
            (defn fib [n] (if (< n 2) n(+ (fib (- n 1)) (fib (- n 2)))))
                a.Wyznaczyć dokładny wzór opisujący ilość kroków niezbędnych do obliczenia(fib n)
                b.Zaproponować procedurę rekurencyjną fib, która generuje proces iteracyjny
                c.Zastosować formę (recur …) i policzyć Fib(10000)
        */

        /*

            fib  n    steps                                         różnica względem fib
            1    1   - 1
            1    2   - 3     = 1 + 1 + 1     = g(1) + g(1) + 1      fib
            2    3   - 5     = 3 + 1 + 1     = g(2) + g(1) + 1      fib- 1                                            fib - 1
            3    4   - 9     = 5 + 3 + 1     = g(3) + g(2) + 1      fib + 1
            5    5   - 15    = 9 + 5 + 1     = g(4) + g(3) + 1      fib + 2
            8    6   - 25    = 15 + 9 + 1    = g(5) + g(4) + 1      fib + 4  
            13   7   - 41    = 25 + 15 + 1   = g(6) + g(5) + 1      fib + 7  
            21   8   - 67    = 41 + 25 + 1   = g(7) + g(6) + 1      fib + 12   
            34   9   - 109   = 67 + 41 + 1   = g(8) + g(7) + 1      fib + 20  
            55   10  - 177   = 109 + 67 + 1  = g(9) + g(8) + 1      fib + 32
            
        */

        public long FibSteps(long number)
        {
            // FibSteps(n) = 1                          dla n < 2
            // FibSteps(n) = fib(n-1) + fib(n-2) + 1    dla n => 2
            if (number < 2)
                return 1;
            else
                return FibSteps(number - 1) + FibSteps(number - 2) + 1;
        }

        public long FibIterative(long number)
        {
            if (!FibResults.ContainsKey(number))
            {
                if (number < 2)
                    FibResults.Add(number, number);
                else
                    FibResults.Add(number, FibIterative(number - 1) + FibIterative(number - 2));
            }
            return FibResults[number];
        }

        public long FibRecur(long number)
        {
            long[] vec = new long[2] { 0, 1 };
            for (int i = 0; i < number; i++)
                (vec[0], vec[1]) = (vec[1], vec[0] + vec[1]);
            return vec[1];
        }







        // ==================[ Zadanie 4.. ]==================
        /*
            Zbiór potęgowy (ang. powerset)
            Napisać procedurę, która przyjmuje kolekcję elementów (lista, wektor, zbiór) i generuje zbiór potęgowy dla tej kolekcji. Zbiór potęgowy to zbiór wszystkich podzbiorów danego zbioru łącznie ze zbiorem pustym.

            (powerset [1 2 3]) => ([] [1] [2] [3] [1 2] [1 3] [2 3] [1 2 3])
        */

        public List<List<int>> CreatePowerset(List<int> collection)
        {
            // Wejściowa kolekcja zostaje posortowana rosnąco
            collection.Sort();

            List<List<int>> powerset = new List<List<int>>() { new List<int>() };   // Powerset ze zbiorem pustym
            List<int> powersetElement = new List<int>();

            // Zbiór pusty
            if (collection.Count() < 1)
                return powerset;

            // Dodanie zbiorów jednoelementowych
            for (int i = 0; i < collection.Count(); i++)
                powerset.Add(new List<int>() { collection[i] });

            // Jeżeli kolekcja wejściowa składa się z jednego elementu, to aktualny powerset zostaje zwrócony
            if (collection.Count() < 2)
                return powerset;

            // Pętla dla kolejnych elementów kolekcji wejściowej (i = 1, czyli drugi element kolekcji)
            // Każda iteracja tworzy podzbiory następnej długości
            for (int i = 1; i < collection.Count(); i++)
            {
                // Powerset zostaje posortowany rosnąco według długości podzbiorów
                powerset = powerset.OrderBy(p => p.Count).ToList();

                // Aktualna wielkość powersetu'u
                int currentPowersetCount = powerset.Count();

                // Indeks pierwszego podzbioru o długości równej i
                int indexOfFirstLargestCount = powerset.IndexOf(powerset.First(p => p.Count == i));

                //if (indexOfFirstLargestCount == 0)
                //    indexOfFirstLargestCount = 1;

                // Pętla przechodząca przez podzbiory o aktualnie największej długości, żeby zamieścić na ich końcu kolejne elementy kolekcji wejściowej
                for (int j = indexOfFirstLargestCount; j < currentPowersetCount; j++)
                {
                    // Zdefiniowanie indeksu ostatniego elementu w aktualnie procesowanym podzbiorze
                    // Do podzbioru dodajemy najmniejszy element z kolekcji, który się jeszcze w nim nie znajduje, dlatego następna pętla zaczyna się od 'indOfLast'
                    int indOfLast = collection.IndexOf(powerset[j].Last());

                    // Jeżeli indeks ostatniego elementu z kolekcji jest ostatnim elementem podzbioru, oznacza to, że wszystkie wartości dla tej długości podzbiorów zostały dodane
                    if (indOfLast != collection.Count() - 1)
                    {
                        // Pętla przechodzi przez wszystkie niedodane jeszcze elementy
                        for (int k = indOfLast + 1; k <= collection.Count() - 1; k++)
                        {
                            // Na koniec powerset'u zostaje dodany pusty podzbiór
                            powerset.Add(new List<int>());

                            // Pętla dodaje wszystkie elementy procesowanego aktualnie podzbioru (jeden z najdłuższych podzbiorów)
                            foreach (var vals in powerset[j])
                                powerset.Last().Add(vals);

                            // Dodanie na koniec powerset'u kolejnego elementu, który jeszcze nie znajduje się w podzbiorze
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





        Zadanie 5.
            a. Zrealizuj pierwiastek sześcienny z wykorzystaniem average-damp oraz FIXED-POINT
            b. Zrealizuj pierwiastek sześcienny z wykorzystaniem Newtons-method
            c. Niech f i g będą dwoma funkcjami jednoargumentowymi. Złożenie f z g jest określone jako funkcja x -> f(g(x)). Zdefiniuj procedurę złóż implementującą złożenie funkcji. Przykładowo: ((złóż kwadrat inc) 6) => 49
            d. Jeśli f jest funkcją jednoargumentową określoną na liczbach oraz n jest dowolną liczbą naturalną, to n-krotnym złożeniem funkcji f nazywamy funkcję, której wartością jest wynik n-krotnego zastosowania funkcji f: x -> f(f( … (f(x)) …)) Napisz procedurę realizującą n-krotne złożenie funkcji f wykorzystując rozwiązanie z punktu c.


         */


    }
}
