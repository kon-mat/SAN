using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprawozdanie4
{
    public class MetodaMonteCarlo
    {
        public void Oblicz(double a, double b, int n)
        {
            //Console.WriteLine("Dolna granica przedziału (a):");
            //double a = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Górna granica przedziału (b):");
            //double b = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Liczba podprzedziałów (N):");
            //int n = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();
            int liczbaPunktowWewnatrz = 0;

            for (int i = 0; i < n; i++)
            {
                double x = random.NextDouble() * (b - a) + a;  // losowy punkt x w przedziale [a, b]
                double y = random.NextDouble();  // losowy punkt y w przedziale [0, 1]

                double f = Funkcja(x);  // wartość funkcji w punkcie x

                if (y <= f)
                    liczbaPunktowWewnatrz++;
            }

            double poleProstokata = (b - a);  // pole prostokąta ograniczającego przedział [a, b] na osi x
            double poleObszaru = (double)liczbaPunktowWewnatrz / n * poleProstokata;  // pole obszaru pod wykresem funkcji

            double wynik = poleObszaru;
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
