using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpVersions
{
    public class Funkcyjne2
    {
        Dictionary<long, long> FibResults;

        public Funkcyjne2()
        {
            FibResults = new Dictionary<long, long>();
        }





        // ==================[ Zadanie 1 ]==================
        // Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.

        public void SquareDiff_1(int n)
        {
            int sumOfSquares = Enumerable.Range(1, n).Select(x => x * x).Sum();
            int squareOfSum = (int)Math.Pow(Enumerable.Range(1, n).Sum(), 2);
            int difference = squareOfSum - sumOfSquares;
            Console.WriteLine($"Rozwiązanie zadania dla liczby {n} wynosi {difference}");
        }













        // ==================[ Zadanie 2. ]==================
        /*
            a.Wzór na pierwiastek sześcienny - zaimplementować
            b.Przebieg procedury Herona uzależnić od Epsilon
            c.Przebieg procedury Herona uzależnić od N (ilości kroków)
        */

        // A

        public double CubeRoot_2A(double x)
        {
            return Iterate_2A(1, x, x);
        }

        // funkcja iteracyjna
        private double Iterate_2A(double guess, double x, double prevGuess)
        {
            if (LowerThanEpsilon_2A(guess, prevGuess))
            {   // nasz wynik spełnia wymagania
                return guess;
            }
            else
            {
                // wynik nie spełnia wymagań, więc podajemy w parametrze kolejne przybliżenie i wykonujemy metodę rekruencyjnie
                double nextGuess = ((2 * guess) + (x / (guess * guess))) / 3;
                return Iterate_2A(nextGuess, x, guess);
            }
        }

        private bool LowerThanEpsilon_2A(double guess, double prevGuess)
        {
            double epsilon = 0.000001;    // epsilon
            // (Aktualne przybliżenie - poprzednie przybliżenie) < epsilon, to zwraca true - wynik jest wystarczający
            return Math.Abs(guess - prevGuess) < epsilon;
        }




        // B

        public double CubeRoot_2B(double x, double epsilon)
        {
            return Iterate_2B(1, x, x, epsilon);
        }

        private double Iterate_2B(double guess, double x, double prevGuess, double epsilon)
        {
            if (LowerThanEpsilon_2B(guess, prevGuess, epsilon))
            {  
                return guess;
            }
            else
            {
                double nextGuess = ((2 * guess) + (x / (guess * guess))) / 3;
                return Iterate_2B(nextGuess, x, guess, epsilon);
            }
        }

        private bool LowerThanEpsilon_2B(double guess, double prevGuess, double epsilon)
        {
            return Math.Abs(guess - prevGuess) < epsilon;
        }




        // C

        public double CubeRoot_2C(double x, int steps)
        {
            return Iterate_2C(1, x, steps);
        }

        private double Iterate_2C(double guess, double x, int steps)
        {
            if (steps == 1)
            {
                return guess;
            }
            else
            {
                // rekurencyjne wywołanie metody z parametrem steps - 1
                double nextGuess = ((2 * guess) + (x / (guess * guess))) / 3;
                return Iterate_2C(nextGuess, x, steps - 1);
            }
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


        // A

        public long FibSteps_3A(long number)
        {
            // FibSteps(n) = 1                          dla n < 2
            // FibSteps(n) = fib(n-1) + fib(n-2) + 1    dla n => 2
            if (number < 2)
                return 1;
            else
                return FibSteps_3A(number - 1) + FibSteps_3A(number - 2) + 1;
        }




        // B

        // Wykorzystujemy słownik, aby wcześniej obliczone wartości zwracać z niego
        public long FibIterative_3B(long number)
        {
            if (!FibResults.ContainsKey(number))
            {
                if (number < 2)
                    FibResults.Add(number, number);
                else
                    FibResults.Add(number, FibIterative_3B(number - 1) + FibIterative_3B(number - 2));
            }
            return FibResults[number];
        }




        // C

        public ulong FibRecur_3C(ulong number)
        {
            if (number == 0)
                return number;
            if (number <= 2)
                return 1;
            return FibAdd(1, 1, number);
        }

        public ulong FibAdd(ulong lower, ulong higher, ulong number)
        {
            if (number == 3)
                return lower + higher;
            else
                return FibAdd(higher, lower + higher, number - 1);
        }










        // ==================[ Zadanie 4.. ]==================
        /*
            Zbiór potęgowy (ang. powerset)
            Napisać procedurę, która przyjmuje kolekcję elementów (lista, wektor, zbiór) i generuje zbiór potęgowy dla tej kolekcji. Zbiór potęgowy to zbiór wszystkich podzbiorów danego zbioru łącznie ze zbiorem pustym.

            (powerset [1 2 3]) => ([] [1] [2] [3] [1 2] [1 3] [2 3] [1 2 3])
        */


        public  List<List<int>> CreatePowerSet_4(List<int> collection)
        {
            if (collection.Count == 0)
            {
                // jeżeli parametr == zbiór pusty
                // zwracany jest zbiór zawierający wyłącznie zbiór pusty
                return new List<List<int>> { new List<int>() };
            }
            else
            {
                // rozdzielamy kolekcję na jej pierwszy element oraz pozostałe elementy (wykorzystujemy funkcję Skip)
                int firstElement = collection[0];
                List<int> restOfElements = collection.Skip(1).ToList();

                // wywołujemy funkcję rekurencyjnie, aby z pozostałych elementów stworzyć zbiór potęgowy
                List<List<int>> powerSetOfRest = CreatePowerSet_4(restOfElements);

                // dodajemy pierwszy element do każdego podzbioru w zbiorze potęgowym pozostałych elementów
                // (w każdym kolejnym wywołaniu funkcji elementem pierwszym jest kolejna liczba z kolekcji podanej w parametrze)
                List<List<int>> powerSetWithFirst = powerSetOfRest.Select(subset => new List<int>(subset) { firstElement }).ToList();

                // zbiór potęgowy pozostałych elementów zostaje połączony ze zbiorem potęgowym zawierającym pierwszy element
                return powerSetOfRest.Concat(powerSetWithFirst).ToList();
            }
        }

        public void DisplayPowerset(List<List<int>> powerSet)
        {
            foreach (List<int> subset in powerSet)
                Console.WriteLine("{ " + string.Join(", ", subset) + " }");
        }











        // ==================[ Zadanie 4.. ]==================

        /*
            a. Zrealizuj pierwiastek sześcienny z wykorzystaniem average-damp oraz FIXED-POINT
            b. Zrealizuj pierwiastek sześcienny z wykorzystaniem Newtons-method
            c. Niech f i g będą dwoma funkcjami jednoargumentowymi. Złożenie f z g jest określone jako funkcja x -> f(g(x)). Zdefiniuj procedurę złóż implementującą złożenie funkcji. Przykładowo: ((złóż kwadrat inc) 6) => 49
            d. Jeśli f jest funkcją jednoargumentową określoną na liczbach oraz n jest dowolną liczbą naturalną, to n-krotnym złożeniem funkcji f nazywamy funkcję, której wartością jest wynik n-krotnego zastosowania funkcji f: x -> f(f( … (f(x)) …)) Napisz procedurę realizującą n-krotne złożenie funkcji f wykorzystując rozwiązanie z punktu c.
         */









        /*
        In this implementation, we define a function CubicRoot that takes a single argument x, which is the number we want to find the cubic root of. The function then defines two helper functions: averageDamp and fixedPoint.

The averageDamp function takes a damping factor alpha and returns another function that takes a value y and applies the average-damp formula to it using x and alpha.

The fixedPoint function takes a function f and an initial guess firstGuess and applies the fixed-point algorithm to f using the initial guess to find the value that f converges to.

Finally, we call fixedPoint with averageDamp(0.5) (which gives us a function that applies the average-damp formula with a damping factor of 0.5) and an initial guess of 1 to find the cubic root of x.

Note that this implementation uses lambdas and recursion to achieve a functional programming style without variables.The tryGuess function is a recursive lambda function that uses tail recursion to avoid creating new stack frames.
        */

        public double CubicRoot(double x)
        {
            Func<double, double> averageDamp = alpha => y => (2 * y + x / (y * y)) / 3;
            Func<Func<double, double>, double, double> fixedPoint = (f, firstGuess) =>
            {
                Func<double, double> tryGuess = null;
                tryGuess = lastGuess =>
                {
                    var nextGuess = f(lastGuess);
                    return Math.Abs(nextGuess - lastGuess) < 0.0001 ? nextGuess : tryGuess(nextGuess);
                };
                return tryGuess(firstGuess);
            };

            return fixedPoint(averageDamp(0.5), 1);
        }









    }
}
