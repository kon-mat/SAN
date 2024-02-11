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
