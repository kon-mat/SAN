﻿// Zadanie 4 - Algorytm wyżarzania symulowanego
using System;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();

    static void Main(string[] args)
    {
        // Ustawienia algorytmu symulowanego wyżarzania
        double temperature = 1000;
        double coolingRate = 0.003;

        // Dane wejściowe - liczba miast i ich współrzędne
        int numCities = 10;
        int[,] cities = GenerateRandomCities(numCities);

        // Inicjalizacja pierwszego rozwiązania
        int[] currentSolution = GenerateRandomSolution(numCities);
        int[] bestSolution = new int[numCities];
        Array.Copy(currentSolution, bestSolution, numCities);

        // Obliczenie odległości dla pierwszego rozwiązania
        double currentDistance = CalculateTotalDistance(currentSolution, cities);
        double bestDistance = currentDistance;

        // Rozwiązanie
        while (temperature > 1)
        {
            // Generowanie nowego sąsiedniego rozwiązania
            int[] newSolution = GenerateNeighborSolution(currentSolution);

            // Obliczenie odległości dla nowego rozwiązania
            double newDistance = CalculateTotalDistance(newSolution, cities);

            // Akceptacja nowego rozwiązania, jeśli jest lepsze lub na podstawie prawdopodobieństwa
            if (newDistance < currentDistance || random.NextDouble() < Math.Exp((currentDistance - newDistance) / temperature))
            {
                Array.Copy(newSolution, currentSolution, numCities);
                currentDistance = newDistance;
            }

            // Aktualizacja najlepszego rozwiązania
            if (currentDistance < bestDistance)
            {
                Array.Copy(currentSolution, bestSolution, numCities);
                bestDistance = currentDistance;
            }

            // Schładzanie temperatury
            temperature *= 1 - coolingRate;
        }

        // Wyświetlenie wyniku
        Console.WriteLine("Najlepsza trasa znaleziona przez algorytm symulowanego wyżarzania:");
        for (int i = 0; i < numCities; i++)
        {
            Console.Write(bestSolution[i] + " ");
        }
        Console.WriteLine("\nCałkowita minimalna odległość: " + bestDistance);
    }

    static int[,] GenerateRandomCities(int numCities)
    {
        int[,] cities = new int[numCities, 2];
        for (int i = 0; i < numCities; i++)
        {
            cities[i, 0] = random.Next(100); // Losowa współrzędna X
            cities[i, 1] = random.Next(100); // Losowa współrzędna Y
        }
        return cities;
    }

    static int[] GenerateRandomSolution(int numCities)
    {
        List<int> solution = new List<int>();
        for (int i = 0; i < numCities; i++)
        {
            solution.Add(i);
        }
        solution.Sort((a, b) => random.Next(-1, 2));
        return solution.ToArray();
    }

    static int[] GenerateNeighborSolution(int[] solution)
    {
        int[] neighborSolution = new int[solution.Length];
        Array.Copy(solution, neighborSolution, solution.Length);

        int index1 = random.Next(solution.Length);
        int index2 = random.Next(solution.Length);

        int temp = neighborSolution[index1];
        neighborSolution[index1] = neighborSolution[index2];
        neighborSolution[index2] = temp;

        return neighborSolution;
    }

    static double CalculateDistance(int x1, int y1, int x2, int y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    static double CalculateTotalDistance(int[] solution, int[,] cities)
    {
        double totalDistance = 0;
        for (int i = 0; i < solution.Length - 1; i++)
        {
            int cityIndex1 = solution[i];
            int cityIndex2 = solution[i + 1];
            totalDistance += CalculateDistance(cities[cityIndex1, 0], cities[cityIndex1, 1], cities[cityIndex2, 0], cities[cityIndex2, 1]);
        }
        // Dodaj odległość od ostatniego do pierwszego miasta (cykliczność)
        int lastCityIndex = solution[solution.Length - 1];
        int firstCityIndex = solution[0];
        totalDistance += CalculateDistance(cities[lastCityIndex, 0], cities[lastCityIndex, 1], cities[firstCityIndex, 0], cities[firstCityIndex, 1]);
        return totalDistance;
    }
}


















/*
// Zadanie 2 - dychtomizator


// Lista punktów do podziału
List<Point> points = new List<Point>
{
    new Point(1.5, 2.0),
    new Point(3.0, 4.0),
    new Point(2.0, 1.0),
    new Point(5.0, 6.0),
    new Point(4.0, 3.0),
    new Point(6.0, 5.0)
};

// Inicjowanie losowymi wagami
Random rand = new Random();
double w1 = rand.NextDouble(); // Losowa waga 1
double w2 = rand.NextDouble(); // Losowa waga 2
double threshold = rand.NextDouble(); // Losowy próg aktywacji

double learningRate = 0.1; // Współczynnik uczenia

// Przykładowe oczekiwane odpowiedzi dla każdego punktu (1 dla grupy 1, -1 dla grupy 2)
int[] expectedOutputs = { 1, 1, 1, -1, -1, -1 };

// Obliczanie odpowiedzi perceptronu i modyfikacja wag
for (int i = 0; i < points.Count; i++)
{
    double sum = points[i].X * w1 + points[i].Y * w2 - threshold;
    int output = sum > 0 ? 1 : -1;

    // Modyfikacja wag, jeśli odpowiedź jest błędna
    if (output != expectedOutputs[i])
    {
        w1 += learningRate * (expectedOutputs[i] - output) * points[i].X;
        w2 += learningRate * (expectedOutputs[i] - output) * points[i].Y;
        threshold -= learningRate * (expectedOutputs[i] - output);
    }
}

Console.WriteLine($"Waga 1: {w1}");
Console.WriteLine($"Waga 2: {w2}");
Console.WriteLine($"Próg aktywacji: {threshold}");

Console.ReadLine();



class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}
*/




/* Zadanie 1 - wieża Hanoi


int iloscKrazkow;
const int iloscSlupkow = 3;

Console.WriteLine("Podaj ilosc krazkow:");
string podanaWartosc = Console.ReadLine();
if (int.TryParse(podanaWartosc, out iloscKrazkow))
    Console.WriteLine($"Ilosc krazkow ustawiona na {iloscKrazkow}.");
else
{
    Console.WriteLine("Podana wartosc jest bledna. Ilosc krazkow ustawiona na 4.");
    iloscKrazkow = 4;
}

int[,] wieza = GenerujWieze(iloscKrazkow, iloscSlupkow);
Console.WriteLine("\nUklad poczatkowy wiezy");
RysujWieze(wieza);
WiezaHanoi(iloscKrazkow, 0, 1, 2, wieza);
Console.ReadKey();



static void WiezaHanoi(int n, int A, int B, int C, int[,] wieza)
{
    if (n > 0)
    {
        WiezaHanoi(n - 1, A, C, B, wieza);
        Console.WriteLine();
        Console.WriteLine($"Wykonany ruch:\t{A + 1} -> {C + 1}");
        wieza = PrzesunKrazek(wieza, A, C);
        RysujWieze(wieza);
        WiezaHanoi(n - 1, B, A, C, wieza);
    }
}

static int[,] GenerujWieze(int iloscKrazkow, int iloscSlupkow)
{
    int[,] wieza = new int[iloscKrazkow, iloscSlupkow];
    for (int i = 0; i < iloscKrazkow; i++)
    {
        wieza[i, 0] = i + 1;
    }
    for (int i = 1; i < iloscSlupkow; i++)
    {
        for (int j = 0; j < iloscKrazkow; j++)
        {
            wieza[j, i] = 0;
        }
    }
    return wieza;
}

static void RysujWieze(int[,] wieza)
{
    int iloscKrazkow = wieza.GetLength(0);
    int iloscSlupkow = wieza.GetLength(1);
    for (int i = 0; i < iloscKrazkow; i++)
    {
        for (int j = 0; j < iloscSlupkow; j++)
        {
            Console.Write(wieza[i, j] + "\t");
        }
        Console.WriteLine();
    }
}

static int MiejsceGornegoKrazeka(int[,] wieza, int zeSlupka)
{
    int iloscKrazkow = wieza.GetLength(0);
    for (int i = 0; i < iloscKrazkow; i++)
        if (wieza[i, zeSlupka] > 0)
            return i;
    return -1;
}

static int PierwszeWolneMiejsce(int[,] wieza, int naSlupek)
{
    int iloscKrazkow = wieza.GetLength(0);
    for (int i = 0; i < iloscKrazkow; i++)
        if (wieza[i, naSlupek] > 0)
            return i - 1;
    return iloscKrazkow - 1;
}

static int[,] PrzesunKrazek(int[,] wieza, int zeSlupka, int naSlupek)
{
    int przesuwanyKrazek = wieza[MiejsceGornegoKrazeka(wieza, zeSlupka), zeSlupka];
    wieza[MiejsceGornegoKrazeka(wieza, zeSlupka), zeSlupka] = 0;
    wieza[PierwszeWolneMiejsce(wieza, naSlupek), naSlupek] = przesuwanyKrazek;
    return wieza;
}

*/