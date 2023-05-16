using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprawozdanie4
{
    public class MetodaParabol
    {
        public void Oblicz(double a, double b, int n)
        {
            //Console.WriteLine("Dolna granica przedziału (a):");
            //double a = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Górna granica przedziału (b):");
            //double b = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Liczba podprzedziałów (N):");
            //int n = Convert.ToInt32(Console.ReadLine());

            double h = (b - a) / n;  // szerokość każdego podprzedziału

            double suma = 0;

            for (int i = 1; i < n; i += 2)
            {
                double x1 = a + i * h;    // lewy punkt paraboli
                double x2 = a + (i + 1) * h;  // środkowy punkt paraboli
                double x3 = a + (i + 2) * h;  // prawy punkt paraboli

                double y1 = Funkcja(x1);  // wartość funkcji w lewym punkcie paraboli
                double y2 = Funkcja(x2);  // wartość funkcji w środkowym punkcie paraboli
                double y3 = Funkcja(x3);  // wartość funkcji w prawym punkcie paraboli

                suma += (h / 3) * (y1 + 4 * y2 + y3);  // dodanie wkładu paraboli do sumy
            }

            double wynik = suma;
            Console.WriteLine("Wartość całki: " + wynik);

            Console.ReadLine();
        }

        // Funkcja do obliczenia całki
        static double Funkcja(double x)
        {
            return 1 / (1 + x * x);
        }


    }
}
