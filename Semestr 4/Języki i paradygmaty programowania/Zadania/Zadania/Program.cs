using System;

namespace Zadania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Zadanie 1
            //int totalLetters = 0;
            //Zadanie1 zad1 = new Zadanie1();
            //for (int i = 0; i <= 1000; i++)
            //    totalLetters += zad1.CountLetters(zad1.IntNumberToStringNumber(i));
            //Console.WriteLine(totalLetters);

            // Zadanie 2
            Zadanie2 zad2 = new Zadanie2();
            int biggestChain = 0;
            int biggestChainNumber = 0;
            for (int i = 1; i <= 1000000; i++)
                if (biggestChain < zad2.Collatz(i))
                    (biggestChainNumber, biggestChain) = (i, zad2.Collatz(i));
            Console.WriteLine($"Najwiekszy lancuch to {biggestChain} dla {biggestChainNumber}");




            Console.ReadKey();




        }
    }





}
