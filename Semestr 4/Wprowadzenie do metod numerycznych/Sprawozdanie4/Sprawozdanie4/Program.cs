using Sprawozdanie4;
using System.Diagnostics.Metrics;

MetodaProtokatow mp = new MetodaProtokatow();
MetodaTrapezow mt = new MetodaTrapezow();
MetodaParabol mpa = new MetodaParabol();
MetodaMonteCarlo mmc = new MetodaMonteCarlo();
//Obliczenia wykonać dla:
// a = -4 b = 4
// N = 10, 100, 2000, 20000

for (int i = 1; i < 5; i++)
{
    Console.WriteLine();
    Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
    Console.WriteLine($"Wykonanie funkcji numer {i}:");

    Console.WriteLine("Dolna granica przedziału (a):");
    double a = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Górna granica przedziału (b):");
    double b = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Liczba podprzedziałów (N):");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Console.WriteLine("-+-+-[METODA PROSTOKĄTÓW]-+-+-");
    mp.Oblicz(a, b, n);

    Console.WriteLine("-+-+-[METODA TRAPEZÓW]-+-+-");
    mt.Oblicz(a, b, n);

    Console.WriteLine("-+-+-[METODA PARABOL]-+-+-");
    mpa.Oblicz(a, b, n);

    Console.WriteLine("-+-+-[METODA MONTE CARLO]-+-+-");
    mmc.Oblicz(a, b, n);


}










Console.ReadKey();





