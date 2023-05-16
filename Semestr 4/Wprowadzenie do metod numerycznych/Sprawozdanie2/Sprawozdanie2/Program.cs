
double[] xWartości = { -2, 0, 1, 3 };
double[] yWartości = { -34, 0, -1, -9 };
double hKrok = 0.2;
double startPrzedział = -2;
double koniecPrzedział = 3;


Console.WriteLine("Tablicowanie wielomianu W(x) dla punktów pośrednich:");
Console.WriteLine("-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-");
Console.WriteLine("x\t\tW(x)");

for (double x = startPrzedział; x <= koniecPrzedział; x += hKrok)
{
    double wynik = Tablicowanie(x, xWartości, yWartości);
    Console.WriteLine($"{Math.Round(x,3)}\t\t{Math.Round(wynik,3)}");
}

Console.ReadLine();
    

static double Tablicowanie(double x, double[] xWartości, double[] yWartości)
{
    double wynik = 0;
    int n = xWartości.Length;

    for (int i = 0; i < n; i++)
    {
        double wartość = yWartości[i];
        for (int j = 0; j < n; j++)
        {
            if (j != i)
            {
                wartość *= (x - xWartości[j]) / (xWartości[i] - xWartości[j]);
            }
        }
        wynik += wartość;
    }

    return wynik;
}



