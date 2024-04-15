// Mateusz Koniuch - 110893
// Szyfr Vigenere’a - program do szyfrowania, defszyfrowania i kryptoanalizy

using System.Text;

string selectedOption;
string encryptedTextFilePath;
string keyFilePath;
string decryptedTextFilePath;

selectedOption = DisplayMainMenu();
Console.Clear();

if (selectedOption == "1")  // Szyfrowanie
{
    try
    {
        DisplayHeader();

        // Wczytaj nazwy plikow i przypisz je do sciezek
        List<string> filePaths = ReadFileNames();
        encryptedTextFilePath = filePaths[0];
        keyFilePath = filePaths[1];
        decryptedTextFilePath = filePaths[2];

        // Wyświetlenie zawartości plików
        Console.WriteLine("\nZawartość pliku do zaszyfrowania:");
        ReadFileContent(decryptedTextFilePath);
        Console.WriteLine("\nZawartość pliku klucza:");
        ReadFileContent(keyFilePath);

        // Wczytanie tekstu odszyfrowanego i klucza
        string decryptedText = File.ReadAllText(decryptedTextFilePath).ToUpper(); // Konwersja na wielkie litery
        string key = File.ReadAllText(keyFilePath).ToUpper(); // Konwersja na wielkie litery

        // Zaszyfrowanie tekstu
        string encryptedText = EncryptVigenere(decryptedText, key);

        // Zapis odszyfrowanego tekstu do pliku
        File.WriteAllText(encryptedTextFilePath, encryptedText);

        // Dostosowanie wielkosci liter w odszyfrowanym tekscie
        AdjustCaseInFile(encryptedTextFilePath, decryptedTextFilePath);

        Console.WriteLine("\nTekst zaszyfrowany i zapisany do pliku.");

        // Wyświetlenie zawartości pliku zaszyfrowanego
        Console.WriteLine("\nZawartość pliku zaszyfrowanego:");
        ReadFileContent(encryptedTextFilePath);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił błąd: " + ex.Message);
    }
}
else if (selectedOption == "2") // Deszyfrowanie
{
    try
    {
        DisplayHeader();

        // Wczytaj nazwy plikow i przypisz je do sciezek
        List<string> filePaths = ReadFileNames();
        encryptedTextFilePath = filePaths[0];
        keyFilePath = filePaths[1];
        decryptedTextFilePath = filePaths[2];

        // Wyświetlenie zawartości plików
        Console.WriteLine("\nZawartość pliku do deszyfrowania:");
        ReadFileContent(encryptedTextFilePath);
        Console.WriteLine("\nZawartość pliku klucza:");
        ReadFileContent(keyFilePath);

        // Wczytanie tekstu zaszyfrowanego i klucza
        string encryptedText = File.ReadAllText(encryptedTextFilePath).ToUpper(); // Konwersja na wielkie litery
        string key = File.ReadAllText(keyFilePath).ToUpper(); // Konwersja na wielkie litery

        // Odszyfrowanie tekstu
        string decryptedText = DecryptVigenere(encryptedText, key);

        // Zapis odszyfrowanego tekstu do pliku
        File.WriteAllText(decryptedTextFilePath, decryptedText);

        // Dostosowanie wielkosci liter w odszyfrowanym tekscie
        AdjustCaseInFile(decryptedTextFilePath, encryptedTextFilePath);

        Console.WriteLine("\nTekst odszyfrowany i zapisany do pliku.");

        // Wyświetlenie zawartości pliku odszyfrowanego
        Console.WriteLine("\nZawartość pliku zdeszyfrowanego:");
        ReadFileContent(decryptedTextFilePath);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił błąd: " + ex.Message);
    }
}
else if (selectedOption == "3") // Kryptoanaliza
{
    try
    {
        DisplayHeader();

        // Podawanie nazwy pliku zaszyfrowanego
        Console.WriteLine("Podaj nazwe pliku zaszyfrowanego:");
        string encryptedTextFileName = Console.ReadLine();

        // Ścieżka do pliku zaszyfrowanego
        encryptedTextFilePath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\" + encryptedTextFileName + ".txt";

        // Kryptoanaliza
        Console.Clear();
        DisplayHeader();
        FrequencyAnalysis(encryptedTextFilePath);   // Analiza częstotliwości liter
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił błąd: " + ex.Message);
    }
}
else
{
    Console.Clear();
    Console.WriteLine("Zostaly wybrane niepoprawne opcje. Uruchom ponownie program.");
}



// Metoda do wyswietlania naglowka z imieniem i nazwiskiem
static void DisplayHeader()
{
    Console.WriteLine("Mateusz Koniuch - 110893");
    Console.WriteLine("Szyfr Vigenere’a - program do szyfrowania, defszyfrowania i kryptoanalizy");
    Console.WriteLine("=================================================");
    Console.WriteLine();
}

// Metoda do wyswietlania menu glownego - zwraca wybrana opcje
static string DisplayMainMenu()
{
    string selectedOption;
    do
    {
        Console.Clear();
        DisplayHeader();
        Console.WriteLine("Wybierz opcje:");
        Console.WriteLine("   1. Szyfruj tekst");
        Console.WriteLine("   2. Deszyfruj tekst");
        Console.WriteLine("   3. Kryptoanaliza - częstotliwosc liter");
        Console.WriteLine();
        Console.WriteLine("Twoj wybor:");
        selectedOption = Console.ReadLine();
    }
    while (selectedOption != "1" && selectedOption != "2" && selectedOption != "3");

    return selectedOption;
}

// Metoda do wczytania nazw plikow - zwraca sciezki do plikow w formie listy
static List<string> ReadFileNames()
{
    // Podawanie nazw plików
    Console.WriteLine("Podaj nazwe pliku zaszyfrowanego:");
    string encryptedTextFileName = Console.ReadLine();
    Console.WriteLine("\nPodaj nazwe pliku z kluczem:");
    string keyFileName = Console.ReadLine();
    Console.WriteLine("\nPodaj nazwe pliku odszyfrowanego:");
    string decryptedTextFileName = Console.ReadLine();

    // Ścieżki do plików
    string encryptedTextFilePath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\" + encryptedTextFileName + ".txt";
    string keyFilePath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\" + keyFileName + ".txt";
    string decryptedTextFilePath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\" + decryptedTextFileName + ".txt";

    List<string> fileNamesList = new()
    {
        encryptedTextFilePath,
        keyFilePath,
        decryptedTextFilePath
    };

    return fileNamesList;
}



// Funkcja do szyfrowania tekstu za pomocą szyfru Vigenère'a
static string EncryptVigenere(string originalText, string key)
{
    StringBuilder encryptedText = new StringBuilder();
    int keyIndex = 0;

    foreach (char c in originalText)
    {
        if (char.IsLetter(c))
        {
            /* opis metody decryptedChar
                - Odejmujemy kod litery 'A' (który wynosi 65 w kodzie ASCII) od kodu litery oryginalnej, aby uzyskać wartość przesunięcia w alfabecie.
                - Dodajemy kod litery klucza (również po odjęciu wartości 'A'), aby uzyskać przesunięcie zgodnie z kluczem.
                - Bierzemy modulo 26, aby zapewnić, że wynik mieści się w zakresie alfabetu (26 liter).
                - Dodajemy ponownie kod litery 'A', aby uzyskać kod zaszyfrowanej litery.
           */
            char encryptedChar = (char)(((c - 'A' + (key[keyIndex % key.Length] - 'A')) % 26) + 'A');
            encryptedText.Append(encryptedChar);
            keyIndex++;
        }
        else
        {
            encryptedText.Append(c); // Zachowanie znaków niebędących literami
        }
    }

    return encryptedText.ToString();
}

// Funkcja do odszyfrowania tekstu za pomocą szyfru Vigenère'a
static string DecryptVigenere(string encryptedText, string key)
{
    StringBuilder decryptedText = new();
    int keyIndex = 0;

    foreach (char c in encryptedText)
    {
        if (char.IsLetter(c))
        {
            /* opis metody decryptedChar
                - Odejmujemy kod litery 'A' (który wynosi 65 w kodzie ASCII) od kodu litery zaszyfrowanej, aby uzyskać wartość przesunięcia.
                - Następnie odejmujemy kod litery klucza od 'A', aby uzyskać wartość przesunięcia klucza.
                - Dodajemy 26 i bierzemy modulo 26, aby zapewnić, że wynik będzie dodatni i mieścił się w zakresie alfabetu (26 liter).
                - Dodajemy ponownie kod litery 'A', aby uzyskać kod litery odszyfrowanej.
             */
            char decryptedChar = (char)(((c - 'A' - (key[keyIndex % key.Length] - 'A') + 26) % 26) + 'A');
            decryptedText.Append(decryptedChar);
            keyIndex++;
        }
        else
        {
            decryptedText.Append(c); // Zachowanie znaków niebędących literami
        }
    }

    return decryptedText.ToString();
}

// Metoda do dostosowania wielkosci liter w pliku szyfrowanym/deszyfrowanym
static void AdjustCaseInFile(string textToAdjustFilePath, string textPatternFilePath)
{
    string decryptedText = File.ReadAllText(textToAdjustFilePath);
    string encryptedText = File.ReadAllText(textPatternFilePath);

    StringBuilder adjustedText = new StringBuilder();

    for (int i = 0; i < decryptedText.Length; i++)
    {
        if (char.IsWhiteSpace(encryptedText[i])) // Zachowanie znaków białych
        {
            adjustedText.Append(decryptedText[i]);
        }
        else if (char.IsUpper(encryptedText[i]))
        {
            adjustedText.Append(char.ToUpper(decryptedText[i]));
        }
        else
        {
            adjustedText.Append(char.ToLower(decryptedText[i]));
        }
    }

    File.WriteAllText(textToAdjustFilePath, adjustedText.ToString());
}

// Metoda do odczytu zawartości pliku i wyświetlenia jej w konsoli
static void ReadFileContent(string filePath)
{
    string fileContent = File.ReadAllText(filePath);
    Console.WriteLine(fileContent);
}

// Analiza częstotliwości liter
static void FrequencyAnalysis(string encryptedTextFilePath)
{
    // Wczytanie zawartości pliku
    string encryptedText = File.ReadAllText(encryptedTextFilePath).ToUpper(); // Konwersja na wielkie litery

    // Inicjalizacja słownika do przechowywania częstotliwości liter
    Dictionary<char, int> letterFrequency = new Dictionary<char, int>();

    // Inicjalizacja licznika wystąpień liter w tekście
    int totalLetters = 0;

    // Iteracja po każdej literze w tekście
    foreach (char c in encryptedText)
    {
        // Sprawdzenie, czy znak jest literą
        if (char.IsLetter(c))
        {
            // Inkrementacja licznika wystąpień litery
            if (letterFrequency.ContainsKey(c))
            {
                letterFrequency[c]++;
            }
            else
            {
                letterFrequency[c] = 1;
            }

            // Inkrementacja ogólnego licznika liter
            totalLetters++;
        }
    }

    // Sortowanie liter w oparciu o częstotliwość występowania (malejąco)
    var sortedLetterFrequency = letterFrequency.OrderByDescending(x => x.Value);

    // Wyświetlenie wyników analizy częstotliwości
    Console.WriteLine("\nAnaliza częstotliwości liter (malejąco):");

    foreach (KeyValuePair<char, int> entry in sortedLetterFrequency)
    {
        double frequency = (double)entry.Value / totalLetters * 100;
        Console.WriteLine($"Litera: {entry.Key}, Częstotliwość: {frequency:f2}%");
    }
}