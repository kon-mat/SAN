using CSharpVersions;

Funkcyjne2 f2 = new Funkcyjne2();






//// Zadanie 1 - różnica kwadratu sumy i sumy kwadratów
//int naturalNumbers = 100;
//f2.SquareDiff_1(naturalNumbers);


//// Zadanie 2 - pierwiastek sześcienny
//Console.WriteLine(f2.CubeRoot_2A(28));
//Console.WriteLine(f2.CubeRoot_2B(28, 0.0003));
//Console.WriteLine(f2.CubeRoot_2C(28, 14));


//// Zadanie 3 - Fibbonaci
//Console.WriteLine("kroki dla 10 = " + f2.FibSteps_3A(10));
//Console.WriteLine("n = 10   xn = " + f2.FibIterative_3B(10));
//Console.WriteLine("n = 10000   xn = " + f2.FibRecur_3C(10000));


//// Zadanie 4 - Powerset
//List<int> collection = new List<int> { 1, 2, 3, 4 };
//List<List<int>> powerSet = f2.CreatePowerSet_4(collection);
//Console.WriteLine("Powerset dla kolekcji { 1, 2, 3, 4 } :");
//f2.DisplayPowerset(powerSet);








static List<double> AverageDamp(List<double> values, double alpha)
{
    List<double> smoothedValues = new List<double>();
    double previousValue = values[0];

    for (int i = 0; i < values.Count; i++)
    {
        double currentValue = values[i];
        double smoothedValue = (1 - alpha) * currentValue + alpha * previousValue;
        smoothedValues.Add(smoothedValue);
        previousValue = smoothedValue;
    }

    return smoothedValues;
}








Console.ReadKey();



