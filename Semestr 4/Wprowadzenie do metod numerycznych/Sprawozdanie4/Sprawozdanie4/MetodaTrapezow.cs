using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprawozdanie4
{
    public class MetodaTrapezow
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

            for (int i = 0; i < n; i++)
            {
                double x = a + i * h;  // wartość x w punkcie środkowym aktualnego podprzedziału
                double y = Funkcja(x); // wartość funkcji w punkcie x

                suma += y;
            }

            double wynik = (h / 2) * (Funkcja(a) + 2 * suma + Funkcja(b));
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
