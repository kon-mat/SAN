/*
// -+-+-+-+-+-[ ZADANIE 7.4a ]-+-+-+-+-+-

Console.WriteLine($"[ ZADANIE 7.4a ]\n");

double a = 3; // dolna granica
double b = 5; // górna granica
double epsilon = 1e-4;

double dokladnaWartosc = FunkcjaPierwotna(b) - FunkcjaPierwotna(a);
double przyblizonaWartosc = MetodaTrapezow(a, b, epsilon);

Console.WriteLine("Wartość dokładna: " + dokladnaWartosc);
Console.WriteLine("Wartość przybliżona: " + przyblizonaWartosc);


// Metoda oblicza wartość funkcji podcałkowej log5(x+1) + 3x^2
static double FunkcjaPodcalkowa(double x)
{
    return Math.Log(x + 1, 5) + 3 * Math.Pow(x, 2);
}

// Metoda oblicza wartość funkcji pierwotnej (całkowej) (x + 1) * log5(x + 1) - (x + 1) + x^3.
static double FunkcjaPierwotna(double x)
{
    return (x + 1) * Math.Log(x + 1, 5) - (x + 1) + Math.Pow(x, 3);
}

// Metoda oblicza wartość całki za pomocą wzoru trapezów. Początkowo przyjmuje jeden segment (n=1) i iteracyjnie zwiększa liczbę segmentów, aż różnica między kolejnymi przybliżeniami wartości całki będzie mniejsza niż epsilon
static double MetodaTrapezow(double a, double b, double epsilon)
{
    int n = 1;
    double przyblizonaWartosc = 0;
    double poprzedniaPrzyblizonaWartosc = 0;

    do
    {
        poprzedniaPrzyblizonaWartosc = przyblizonaWartosc;
        double h = (b - a) / n;
        double suma = 0;

        for (int i = 0; i < n; i++)
        {
            double x0 = a + i * h;
            double x1 = a + (i + 1) * h;

            suma += (FunkcjaPodcalkowa(x0) + FunkcjaPodcalkowa(x1)) / 2;
        }

        przyblizonaWartosc = suma * h;
        n *= 2;
    } while (Math.Abs(przyblizonaWartosc - poprzedniaPrzyblizonaWartosc) >= epsilon);

    return przyblizonaWartosc;
}

/*
Kroki algorytmu metody trapezów
1.Podziel przedział całkowania na równo odległe podprzedziały. Im większa liczba podprzedziałów, tym dokładniejsze będzie przybliżenie całki, ale zwiększy się też liczba operacji do wykonania. Dlatego należy znaleźć kompromis pomiędzy dokładnością a efektywnością obliczeń.

2.Oblicz szerokość każdego trapezu, czyli różnicę pomiędzy wartościami końcowymi przedziałów podprzedziałów.

3.Dla każdego podprzedziału oblicz wartości funkcji na końcach przedziału.

4.Oblicz pole trapezu na podstawie szerokości i wysokości (różnica wartości funkcji na końcach przedziału). Można to zrobić, używając wzoru: pole_trapezu = (wysokość_podstawa1 + wysokość_podstawa2) * szerokość / 2.

5.Zsumuj pola wszystkich trapezów, aby otrzymać przybliżoną wartość całki.

6.Otrzymaną sumę podziel przez liczbę podprzedziałów, aby uśrednić wartość całki.
*/


/*










/*
// -+-+-+-+-+-[ ZADANIE 7.3b ]-+-+-+-+-+-

Console.WriteLine($"[ ZADANIE 7.3b ]\n");


double epsilon = 0.0001; // Dokładność wyniku
double pierwiastek;


Console.WriteLine("-+-+-+-[ METODA BISEKCJI ]-+-+-+-");
double a = 1;   // Początkowy przedział
double b = 4;    // Końcowy przedział
pierwiastek = MetodaBisekcji(a, b, epsilon);
Console.WriteLine("Przyblizony wynik pierwiastka: " + pierwiastek);
Console.WriteLine();

Console.WriteLine("-+-+-+-[ METODA NEWTONA ]-+-+-+-");
double x0 = 2;
double x = MetodaNewtona(x0, epsilon);
Console.WriteLine("Przyblizony wynik pierwiastka: " + x);
Console.WriteLine();

Console.ReadKey();




// Równanie funkcji f(x)
static double f(double x)
{
    return 2 * Math.Log(x) - Math.Sin(x);
}


// Pochodna funkcji f(x)
static double df(double x)
{
    return (2 / x) - Math.Cos(x);
}


// Metoda bisekcji znajduje pierwiastek równania w podanym przedziale (1, 4) poprzez iteracyjne dzielenie przedziału na pół, aż wartość funkcji będzie dostatecznie bliska zeru lub przedział będzie dostatecznie mały.
static double MetodaBisekcji(double a, double b, double epsilon)
{
    int liczbaIteracji = 0;

    if (f(a) * f(b) >= 0)
    {
        Console.WriteLine("Funkcja nie spełnia warunków dla metody bisekcji.");
        return 0.0;
    }

    double c = a;
    while ((b - a) >= epsilon)
    {
        liczbaIteracji++;

        c = (a + b) / 2.0;

        if (f(c) == 0.0)
            break;

        if (f(c) * f(a) < 0)
            b = c;
        else
            a = c;
    }

    Console.WriteLine($"Liczba iteracji dla metody bisekcji: {liczbaIteracji}");
    return c;
}


// Metoda Newtona wykorzystuje pochodną funkcji do iteracyjnego poprawiania przybliżenia pierwiastka.
static double MetodaNewtona(double x0, double epsilon)
{
    int liczbaIteracji = 0;
    double x = x0;
    double fx = f(x);
    double dfx = df(x);

    while (Math.Abs(fx) > epsilon)
    {
        liczbaIteracji++;

        x = x - fx / dfx;   // nowy x równy (x - fx) / pochodna fx
        fx = f(x);  // wartość fx dla nowego x
        dfx = df(x);    // wartość pochodnej fx dla nowego x
    }

    Console.WriteLine($"Liczba iteracji dla Metody Newtona: {liczbaIteracji}");
    return x;
}
*/


/*
// -+-+-+-+-+-[ ZADANIE 7.3a ]-+-+-+-+-+-

Console.WriteLine($"[ ZADANIE 7.3a ]\n");

double pierwiastek = RozwiazRownanie();

if (!double.IsNaN(pierwiastek))
{
    Console.WriteLine("Znaleziono pierwiastek: " + pierwiastek);
}
else
{
    Console.WriteLine("Nie znaleziono pierwiastka w podanym przedziale.");
}


static double RozwiazRownanie()
{
    int liczbaIteracji = 0;
    double epsilon = 0.0001; // dokładność
    double dolneOgraniczenie = 1; // dolne ograniczenie przedziału
    double gorneOgraniczenie = 4; // górne ograniczenie przedziału

    double x = dolneOgraniczenie; // zaczynamy od dolnego ograniczenia

    // Program wykorzystuje pętlę while do iteracji przez wartości x w podanym przedziale. Dla każdej wartości x oblicza wartość funkcji 2ln(x) -sin(x) i sprawdza, czy wynik jest dostatecznie bliski zeru (z dokładnością epsilon). Jeśli tak, zwraca wartość x jako pierwiastek. Jeśli nie znaleziono pierwiastka, zwracana jest wartość NaN (Not-a-Number).
    while (x <= gorneOgraniczenie)
    {
        liczbaIteracji++;

        double wynik = 2 * Math.Log(x) - Math.Sin(x);

        if (Math.Abs(wynik) < epsilon) // sprawdzamy, czy wynik jest dostatecznie bliski
        {
            Console.WriteLine($"Liczba iteracji {liczbaIteracji}");
            return x; // zwracamy pierwiastek
        }

        x += epsilon; // inkrementujemy x o epsilon
    }

    Console.WriteLine($"Liczba iteracji {liczbaIteracji}");
    return double.NaN; // jeśli nie znaleziono pierwiastka, zwracamy NaN (Not-a-Number)
}
/*










/*
// -+-+-+-+-+-[ ZADANIE 7.2a ]-+-+-+-+-+-

// wartości pomiarowe
double[] x = { 0, Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2 };
double[] f = { 0, 1.0 / 2, Math.Sqrt(2) / 2, Math.Sqrt(3) / 2, 1 };

// liczba węzłów interpolacji
int n = x.Length;

// przedział wartości
double a = 0;
double b = Math.PI / 2;

// krok dyskretyzacji
double dx = Math.PI / 30;

Console.WriteLine($"[ ZADANIE 7.2a ]\n");

// obliczanie wartości interpolowanej w przedziale od a do b
for (double xi = a; xi <= b; xi += dx)
{
    double wynik = InterpolacjaLagrange(xi, x, f, n);
    Console.WriteLine($"x = {xi}, f(x) = {wynik}");
}


static double InterpolacjaLagrange(double xi, double[] x, double[] f, int n)
{
    double wynik = 0;

    for (int i = 0; i < n; i++)
    {
        double wartosc = f[i];

        // Aby stworzyć wielomian Lagrange'a, rozważamy każdy punkt danych oddzielnie. Dla każdego punktu danych (xᵢ, yᵢ), tworzymy iloczyn wielomianów postaci Lᵢ(x)
        // Wielomian Lᵢ(x) można obliczyć za pomocą wzoru:  Lᵢ(x) = Π[j ≠ i](x - xⱼ) / (xᵢ - xⱼ), gdzie Π[j ≠ i] oznacza iloczyn dla wszystkich indeksów j różnych od i.

        for (int j = 0; j < n; j++)
        {
            if (j != i)
            {
                wartosc *= (xi - x[j]) / (x[i] - x[j]);
            }
        }

        wynik += wartosc;
    }

    return wynik;
}
*/


/*
// -+-+-+-+-+-[ ZADANIE 7.1b ]-+-+-+-+-+-

double step = Math.PI / 30;  // krok ∆x
double x;
double max_x = Math.PI / 2;  // górna granica przedziału

// W wyniku wykonania programu, zostaną wyświetlone trzy kolumny: x, wartość F(x) oraz wartość sin(x) dla kolejnych wartości x w przedziale [0, π/2].
Console.WriteLine($"[ ZADANIE 7.1b ]\n");

Console.WriteLine("x\t\tF(x)\t\tsin(x)");
// Używamy pętli for, aby tabulować wartości funkcji F(x) oraz funkcji bibliotecznej sin(x) w zadanym przedziale. Krokiem tabulacji jest ∆x, który wynosi π/30.
for (x = 0; x <= max_x; x += step)
{
    double f = F(x);  // wartość funkcji F(x)
    double sin = Math.Sin(x);  // wartość funkcji sin(x)

    Console.WriteLine($"{Math.Round(x,5)}\t\t{Math.Round(f,5)}\t\t{Math.Round(sin,5)}");
}


// Funkcja F(x) została zdefiniowana zgodnie z wcześniej obliczonymi wartościami współczynników a, b i c.
static double F(double x)
{
    double a = -0.33462102566487867;
    double b = 1.1684849758849556;
    double c = -0.004950191198437726;

    return a * x * x + b * x + c;
}
*/


/*
// -+-+-+-+-+-[ ZADANIE 7.1a ]-+-+-+-+-+-

double[] xi = { 0, Math.PI / 6, Math.PI / 4, Math.PI / 3, Math.PI / 2 };
double[] fi = { 0, 1.0 / 2, Math.Sqrt(2) / 2, Math.Sqrt(3) / 2, 1 };

// Wywołanie metody wyznaczającej współczynniki
double[] wspolczynniki = ZnajdzWspolczynniki(xi, fi);

double a = wspolczynniki[0];
double b = wspolczynniki[1];
double c = wspolczynniki[2];

Console.WriteLine($"[ ZADANIE 7.1a ]\n");
Console.WriteLine($"Wspolczynniki: \na = {a} \nb = {b} \nc = {c}");


//Metoda jest odpowiedzialna za wyznaczenie współczynników a, b i c dla funkcji aproksymującej. Przyjmuje ona dwa argumenty: tablicę xi zawierającą wartości xi oraz tablicę fi zawierającą wartości odpowiadających im fi.
static double[] ZnajdzWspolczynniki(double[] xi, double[] fi)
{
    double[,] macierzA = new double[3, 3];  // tworzona jest macierz A o rozmiarze 3x3
    double[] wektorB = new double[3];   // tworzona jest wektor B o rozmiarze 3

    // Wypełnienie macierzy A i wektora B
    for (int i = 0; i < xi.Length; i++)
    {
        // w pętli, dla każdej pary wartości xi i fi, odpowiednie elementy macierzy A oraz wektora B są aktualizowane na podstawie równań aproksymacyjnych
        double x = xi[i];
        double f = fi[i];

        macierzA[0, 0] += x * x * x * x;
        macierzA[0, 1] += x * x * x;
        macierzA[0, 2] += x * x;
        macierzA[1, 0] += x * x * x;
        macierzA[1, 1] += x * x;
        macierzA[1, 2] += x;
        macierzA[2, 0] += x * x;
        macierzA[2, 1] += x;
        macierzA[2, 2] += 1;

        wektorB[0] += f * x * x;
        wektorB[1] += f * x;
        wektorB[2] += f;
    }

    // Rozwiązanie układu równań
    double[] wspolczynniki = RozwiazRownanie(macierzA, wektorB);

    return wspolczynniki;
}



//Metoda rozwiązuje układ równań macierzowych. Przekazujemy do niej macierz A i wektor B. Metoda korzysta z algorytmu eliminacji Gaussa w celu rozwiązania układu równań.
static double[] RozwiazRownanie(double[,] macierzA, double[] wektorB)
{
    int n = wektorB.Length;
    double[] wspolczynniki = new double[n];

    //najpierw wykonuje się eliminacja współczynników w macierzy A, aby uzyskać macierz trójkątną górną
    for (int k = 0; k < n - 1; k++)
    {
        for (int i = k + 1; i < n; i++)
        {
            double wspolczynnik = macierzA[i, k] / macierzA[k, k];

            for (int j = k + 1; j < n; j++)
            {
                macierzA[i, j] -= wspolczynnik * macierzA[k, j];
            }

            wektorB[i] -= wspolczynnik * wektorB[k];
        }
    }

    // obliczane są wartości współczynników a, b i c w kolejności od ostatniego do pierwszego.
    for (int i = n - 1; i >= 0; i--)
    {
        double sum = 0;

        for (int j = i + 1; j < n; j++)
        {
            sum += macierzA[i, j] * wspolczynniki[j];
        }

        wspolczynniki[i] = (wektorB[i] - sum) / macierzA[i, i];
    }

    return wspolczynniki;
}
*/