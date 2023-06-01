double A = 0, B = 0, C = 0, D = 0;
double W, Wa, Wb, a1, b1, a, b;
const int n = 3;
double[] x = new double[n + 1] { 1, 3, 4, 6 };
double[] f = new double[n + 1] { 1.8, 8.5, 9.5, 20};
double[] u = new double[n + 1];
double[] z = new double[n + 1];

for (int i = 0; i <= n; i++)
{
    u[i] = Math.Log(x[i]);
    z[i] = Math.Log(f[i]);
}

for (int i = 0; i <= n; i++)
{
    A += u[i] * u[i];
    B += u[i];
    C += z[i] * u[i];
    D += z[i];
}


W = A * (n + 1) - B * B;
Wa = C * (n + 1) - B * D;
Wb = A * D - C * B;
a1 = Wa / W;
b1 = Wb / W;
a = Math.Exp(b1);
b = a1;


Console.WriteLine("-+-+-+-[Zadanie 3.2]-+-+-+-");
Console.WriteLine();

Console.WriteLine("W = " + String.Format("{0:#,###.#####}", W));
Console.WriteLine("Wa = " + String.Format("{0:#,###.#####}", Wa));
Console.WriteLine("Wb = " + String.Format("{0:#,###.#####}", Wb));
Console.WriteLine();
Console.WriteLine("a1 = " + String.Format("{0:0.#####}", a1));
Console.WriteLine("b1 = " + String.Format("{0:0.#####}", b1));
Console.WriteLine("a = " + String.Format("{0:0.#####}", a));
Console.WriteLine("b = " + String.Format("{0:0.#####}", b));
Console.WriteLine();

Console.WriteLine($"F(x) = {String.Format("{0:0.#####}", a)} * x^({String.Format("{0:0.#####}", b)})");

Console.ReadKey();





/* Zadanie 3.1

double A = 0, B = 0, C = 0, D = 0, E = 0, F = 0, G = 0;
double W, Wa, Wb, Wc, a, b, c;
const int n = 8;
double[] x = new double[n + 1] { -4, -3, -2, -0.6, -0.2, 1, 3, 5, 7 };
double[] f = new double[n + 1] { 4, 2.25, 1, 0.25, 0, 1, 2.25, 4, 6.25 };

for (int i = 0; i <= n; i++)
{
    A += x[i] * x[i] * x[i] * x[i];
    B += x[i] * x[i] * x[i];
    C += x[i] * x[i];
    D += x[i];
    E += f[i] * x[i] * x[i];
    F += f[i] * x[i];
    G += f[i];
}

W = A * C * (n + 1) + B * D * C + C * B * D - C * C * C - D * D * A - B * B * (n + 1);
Wa = E * C * (n + 1) + F * D * C + G * B * D - G * C * C - D * D * E - F * B * (n + 1);
Wb = A * F * (n + 1) + B * G * C + C * E * D - F * C * C - A * G * D - B * E * (n + 1);
Wc = A * C * G + B * D * E + C * B * F - C * C * E - A * D * F - B * B * G;
a = Wa / W;
b = Wb / W;
c = Wc / W;

Console.WriteLine("-+-+-+-[Zadanie 3.1]-+-+-+-");
Console.WriteLine();

Console.WriteLine("W = " + String.Format("{0:#,###.#####}", W));
Console.WriteLine($"F(x) = {String.Format("{0:0.#####}", a)}x^2 + {String.Format("{0:0.#####}", b)}x + {String.Format("{0:0.#####}", c)}");
Console.WriteLine("a = " + String.Format("{0:0.#####}", a));
Console.WriteLine("b = " + String.Format("{0:0.#####}", b));
Console.WriteLine("c = " + String.Format("{0:0.#####}", c));
Console.WriteLine();
Console.WriteLine("Wa = " + String.Format("{0:#,###.#####}", Wa));
Console.WriteLine("Wb = " + String.Format("{0:#,###.#####}", Wb));
Console.WriteLine("Wc = " + String.Format("{0:#,###.#####}", Wc));

*/