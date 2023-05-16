






double epsilon = 1e-6; // Dokładność wyniku
double root;


Console.WriteLine("-+-+-+-[ METODA BISEKCJI ]-+-+-+-");
double a = -10.0;   // Początkowy przedział
double b = 10.0;    // Końcowy przedział
root = MetodaBisekcji(a, b, epsilon);
Console.WriteLine("Przyblizony wynik pierwiastka: " + root);
Console.WriteLine();


Console.WriteLine("-+-+-+-[ METODA NEWTONA ]-+-+-+-");
double x0 = -1.0;
double x = MetodaNewtona(x0, epsilon);
Console.WriteLine("Przyblizony wynik pierwiastka: " + root);
Console.WriteLine();


Console.WriteLine("-+-+-+-[ METODA SIECZNYCH ]-+-+-+-");
x0 = 0.0; // Początkowe przybliżenie x0
double x1 = 1.0; // Początkowe przybliżenie x1
int maximumIteration = 1000; // Maksymalna liczba iteracji
root = MetodaSiecznych(x0, x1, epsilon, maximumIteration);
if (!double.IsNaN(root))
{
    Console.WriteLine("Przyblizony wynik pierwiastka: " + root);
}
else
{
    Console.WriteLine("Nie można obliczyć przybliżonego wyniku pierwiastka.");
}
Console.WriteLine();


Console.ReadKey();








// Równanie funkcji f(x)
static double f(double x)
{
    return Math.Sin(x * x - x + 1.0 / 3.0) + x / 2.0;
}


// Pochodna funkcji f(x)
static double df(double x)
{
    return 2.0 * x * Math.Cos(x * x - x + 1.0 / 3.0) + 1.0 / 2.0;
}


static double MetodaBisekcji(double a, double b, double epsilon)
{
    if (f(a) * f(b) >= 0)
    {
        Console.WriteLine("Funkcja nie spełnia warunków dla metody bisekcji.");
        return 0.0;
    }

    double c = a;
    while ((b - a) >= epsilon)
    {
        c = (a + b) / 2.0;

        if (f(c) == 0.0)
            break;

        if (f(c) * f(a) < 0)
            b = c;
        else
            a = c;
    }

    return c;
}


static double MetodaNewtona(double x0, double epsilon)
{
    double x = x0;
    double fx = f(x);
    double dfx = df(x);

    while (Math.Abs(fx) > epsilon)
    {
        x = x - fx / dfx;
        fx = f(x);
        dfx = df(x);
    }

    return x;
}


static double MetodaSiecznych(double x0, double x1, double epsilon, int maximumIteration)
{
    double x2, fx0, fx1, fx2;

    for (int i = 0; i < maximumIteration; i++)
    {
        fx0 = f(x0);
        fx1 = f(x1);

        if (Math.Abs(fx1 - f(fx0)) < epsilon)
        {
            Console.WriteLine($"Przybliżony wynik pierwiastka został obliczony po {i + 1} iteracjach.");
            return x1;
        }

        x2 = x1 - (fx1 * (x1 - x0)) / (fx1 - fx0);
        fx2 = f(x2);

        if (Math.Abs(fx2) < epsilon)
        {
            Console.WriteLine($"Przybliżony wynik pierwiastka został obliczony po {i + 1} iteracjach.");
            return x2;
        }

        x0 = x1;
        x1 = x2;
    }

    Console.WriteLine($"Przybliżony wynik pierwiastka nie został znaleziony. Wykonano { maximumIteration} iteracji.");
    return double.NaN; 
}




