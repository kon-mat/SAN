using CSharpVersions;
using System.Diagnostics;

Funkcyjne f = new Funkcyjne();


// Zad2ab
//for (int i = 0; i < 3; i++)
//{
//    Console.Write("Liczba do pierwiastkowania: ");
//    string sNum = Console.ReadLine();
//    Console.Write("Epsilon: ");
//    string sEps = Console.ReadLine();
//    Console.WriteLine($"Pierwiastek szescienny z liczby {sNum} w przyblizeniu do {sEps} wynosi " +
//        $"{f.Zad2ab(double.Parse(sNum), double.Parse(sEps))}");
//    Console.WriteLine();
//}


//// Zad2c
//for (int i = 0; i < 3; i++)
//{
//    Console.Write("Liczba do pierwiastkowania: ");
//    string sNum = Console.ReadLine();
//    Console.Write("Liczba kroków: ");
//    string sN = Console.ReadLine();
//    Console.WriteLine($"Pierwiastek szescienny z liczby {sNum} w {sN} krokach procedury Herona wynosi " +
//        $"{f.Zad2c(double.Parse(sNum), int.Parse(sN))}");
//    Console.WriteLine();
//}


//// Zad3ab
//static void Zad3TimeTestA(Funkcyjne f)
//{
//    long step = 0;
//    Stopwatch stopWatch = new Stopwatch();

//    Console.Write("Liczba do ciągu: ");
//    string sNumber = Console.ReadLine();

//    stopWatch.Restart();    // start czasu
//    Console.WriteLine($"Dla liczby {sNumber}");
//    Console.WriteLine($"Wynik końcowy funkcji A wynosi: {f.Zad3a(int.Parse(sNumber), ref step)}");
//    stopWatch.Stop();
//    Console.WriteLine($"Ilość kroków {step}");

//    TimeSpan ts = stopWatch.Elapsed;

//    // Format and display the TimeSpan value.
//    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
//        ts.Hours, ts.Minutes, ts.Seconds,
//        ts.Milliseconds / 10);
//    Console.WriteLine("RunTime funkcji A: " + elapsedTime);

//}

//static void Zad3TimeTestB(Funkcyjne f)
//{
//    long step = 0;
//    Stopwatch stopWatch = new Stopwatch();

//    Console.Write("Liczba do ciągu: ");
//    string sNumber = Console.ReadLine();

//    stopWatch.Restart();    // start czasu
//    Console.WriteLine($"Dla liczby {sNumber}");
//    Console.WriteLine($"Wynik końcowy funkcji B wynosi: {f.Zad3b(int.Parse(sNumber), ref step)}"); ;
//    stopWatch.Stop();
//    Console.WriteLine($"Ilość kroków {step}");

//    TimeSpan ts = stopWatch.Elapsed;

//    // Format and display the TimeSpan value.
//    string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
//        ts.Hours, ts.Minutes, ts.Seconds,
//        ts.Milliseconds / 10);
//    Console.WriteLine("RunTime funkcji B: " + elapsedTime);
//}

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Funkcja A test {i}");
//    Zad3TimeTestA(f);
//    Console.WriteLine();
//    Console.WriteLine($"Funkcja B test {i}");
//    Zad3TimeTestB(f);
//    Console.WriteLine();
//}













Console.ReadKey();





























































