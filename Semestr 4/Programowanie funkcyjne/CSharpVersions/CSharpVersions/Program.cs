

for (int i = 0; i <= 20; i++)
{
    double numberToSqrt = double.TryParse(Console.ReadLine(), out double y) ? y : 0;

    double z = Zadanie2Pierwiastek(numberToSqrt);

    Console.WriteLine($"Pierwiastek 3 stopnia z liczby {numberToSqrt} wynosi : {z}");
}

Console.ReadKey();










static double Zadanie2Pierwiastek(double num)
{
    double x0 = num / 3; // przybliżenie początkowe
    double x1 = (2 * x0 + num / (x0 * x0)) / 3; // pierwsza iteracja

    while (Math.Abs(x1 - x0) > 0.000001) // warunek stopu
    {
        x0 = x1;
        x1 = (2 * x0 + num / (x0 * x0)) / 3;
    }

    return x1;
}



