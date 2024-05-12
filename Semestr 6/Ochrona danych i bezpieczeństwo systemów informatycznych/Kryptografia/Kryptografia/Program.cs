// Mateusz Koniuch - 110893
// Szyfr Vigenere’a - program do szyfrowania, defszyfrowania i kryptoanalizy

using System.Text;
using System.Text.RegularExpressions;

string selectedOption;
string encryptedTextFilePath;
string keyFilePath;
string decryptedTextFilePath;
string alphabet = "abcdefghijklmnopqrstuvwxyz";
int maxLengthKeyTest = 6;


while(true)
{
    selectedOption = DisplayMainMenu();

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

            // Wczytanie tekstu odszyfrowanego i klucza
            string decryptedText = File.ReadAllText(decryptedTextFilePath).ToUpper(); // Konwersja na wielkie litery
            string key = File.ReadAllText(keyFilePath).ToUpper(); // Konwersja na wielkie litery

            // Zaszyfrowanie tekstu
            string encryptedText = EncryptVigenere(decryptedText, key);

            // Zapis odszyfrowanego tekstu do pliku
            File.WriteAllText(encryptedTextFilePath, encryptedText);

            // Dostosowanie wielkosci liter w odszyfrowanym tekscie
            AdjustCaseInFile(encryptedTextFilePath, decryptedTextFilePath);

            Console.WriteLine("\nPlik został pomyślnie zaszyfrowany i zapisany w:\n" + decryptedTextFilePath);
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nWystąpił błąd: " + ex.Message);
            Console.ReadKey();
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

            // Wczytanie tekstu zaszyfrowanego i klucza
            string encryptedText = File.ReadAllText(encryptedTextFilePath).ToUpper(); // Konwersja na wielkie litery
            string key = File.ReadAllText(keyFilePath).ToUpper(); // Konwersja na wielkie litery

            // Odszyfrowanie tekstu
            string decryptedText = DecryptVigenere(encryptedText, key);

            // Zapis odszyfrowanego tekstu do pliku
            File.WriteAllText(decryptedTextFilePath, decryptedText);

            // Dostosowanie wielkosci liter w odszyfrowanym tekscie
            AdjustCaseInFile(decryptedTextFilePath, encryptedTextFilePath);

            Console.WriteLine("\nPlik został pomyślnie odszyfrowany i zapisany w:\n" + encryptedTextFilePath);
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nWystąpił błąd: " + ex.Message);
            Console.ReadKey();
        }
    }
    else if (selectedOption == "3") // Kryptoanaliza
    {
        try
        {
            DisplayHeader();

            string mainTextFilesPath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\";

            // Podawanie nazw plików
            Console.WriteLine("Podaj nazwę pliku do odszyfrowania:");
            string toDecryptTextFileName = Console.ReadLine();
            Console.WriteLine("\nPodaj nazwę pliku do zapisania odszyfrowanego tekstu:");
            string toSaveTextFileName = Console.ReadLine();

            // Ścieżki do plików
            string toDecryptTextFilePath = mainTextFilesPath + toDecryptTextFileName + ".txt";
            string toSaveTextFilePath = mainTextFilesPath + toSaveTextFileName + ".txt";

            int keyLength = FindKeyLength(toDecryptTextFilePath, maxLengthKeyTest);
            Decrypt(toDecryptTextFilePath, maxLengthKeyTest, alphabet, toSaveTextFilePath);
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nWystąpił błąd: " + ex.Message);
            Console.ReadKey();
        }
    }
    else if (selectedOption == "4") // Dostosowanie pliku do kryptoanalizy
    {
        try
        {
            DisplayHeader();
            ModifyTextFile(alphabet);
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nWystąpił błąd: " + ex.Message);
            Console.ReadKey();
        }
    }
    else
    {
        Console.Clear();
        Console.WriteLine("Zostaly wybrane niepoprawne opcje. Uruchom ponownie program.");
        Console.ReadKey();
    }
}





// Metoda do wyswietlania naglowka z imieniem i nazwiskiem
static void DisplayHeader()
{
    Console.Clear();
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
        Console.WriteLine("   3. Kryptoanaliza - łamanie klucza (bez polskich liter i białych znaków)");
        Console.WriteLine("   4. Dostosowanie zaszyfrowanego pliku do kryptoanalizy");
        Console.WriteLine();
        Console.WriteLine("Twój wybór:");
        selectedOption = Console.ReadLine();
    }
    while (selectedOption != "1" && selectedOption != "2" && selectedOption != "3" && selectedOption != "4");

    return selectedOption;
}

// Metoda do wczytania nazw plikow - zwraca sciezki do plikow w formie listy
static List<string> ReadFileNames()
{
    string mainTextFilesPath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\";

    // Podawanie nazw plików
    Console.WriteLine("Podaj nazwę pliku zaszyfrowanego:");
    string encryptedTextFileName = Console.ReadLine();
    Console.WriteLine("\nPodaj nazwę pliku z kluczem:");
    string keyFileName = Console.ReadLine();
    Console.WriteLine("\nPodaj nazwę pliku odszyfrowanego:");
    string decryptedTextFileName = Console.ReadLine();

    // Ścieżki do plików
    string encryptedTextFilePath = mainTextFilesPath + encryptedTextFileName + ".txt";
    string keyFilePath = mainTextFilesPath + keyFileName + ".txt";
    string decryptedTextFilePath = mainTextFilesPath + decryptedTextFileName + ".txt";

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



// Metoda dzieli tekst na kawałki o określonej długości
static List<string> SplitText(string text, int n)
{
    return Enumerable.Range(0, (int)Math.Ceiling((double)text.Length / n))
                     .Select(i => text.Skip(i * n).Take(n))
                     .Select(chars => new string(chars.ToArray()))
                     .ToList();
}

// Metoda oblicza odległość między dwiema literami w alfabecie
static int DistanceBetweenLetters(char letter1, char letter2)
{
    return Math.Abs(char.ToUpper(letter2) - char.ToUpper(letter1));
}

// Metoda otwiera plik tekstowy i zwraca jego zawartość jako ciąg znaków
static string OpenFile(string file)
{
    using (StreamReader reader = new StreamReader(file))
    {
        return reader.ReadToEnd();
    }
}

// Metoda zapisuje podany tekst do pliku tekstowego
static void SaveFile(string text, string toSaveTextFilePath)
{
    using (StreamWriter writer = new StreamWriter(toSaveTextFilePath))
    {
        writer.Write(text);
    }
}

// Metoda tworzy listę podciągów z tekstu, grupując znaki według ich pozycji w oryginalnym tekście
static List<string> SubstringsByPosition(List<string> splitText)
{
    List<string> newList = new List<string>();
    foreach (var sublist in splitText)
    {
        for (int j = 0; j < sublist.Length; j++)
        {
            if (newList.Count <= j)
            {
                newList.Add(sublist[j].ToString());
            }
            else
            {
                newList[j] += sublist[j];
            }
        }
    }
    return newList;
}

// Metoda łączy podciągi tekstu, aby odtworzyć oryginalny tekst, przywracając ich pierwotną kolejność
static string ReverseSubstringsByPosition(List<string> listOfSubstrings)
{
    return string.Concat(listOfSubstrings.SelectMany(x => x.Zip(Enumerable.Range(0, x.Length), (c, i) => (c, i))
                                                   .OrderBy(p => p.Item2)
                                                   .Select(p => p.Item1)));
}

// Metoda oblicza indeks koincydencji, miarę, która wskazuje stopień korelacji między częstotliwością występowania liter a rozkładem alfabetycznym
static double CalcIndexCoincidence(string text)
{
    text = text.ToUpper();
    int[] letterFrequency = new int[26];
    int letterTotal = 0;
    foreach (char letter in text)
    {
        if (char.IsLetter(letter))
        {
            letterFrequency[char.ToUpper(letter) - 65]++;
            letterTotal++;
        }
    }

    double indexCoincidence = 0;
    foreach (int frequency in letterFrequency)
    {
        indexCoincidence += (frequency * (frequency - 1)) / (double)(letterTotal * (letterTotal - 1));
    }

    return indexCoincidence;
}

// Metoda deszyfruje tekst za pomocą szyfru Cezara o określonym kluczu
static string CaesarCipherDecrypt(string text, int key, string alphabet)
{
    string message = "";
    foreach (char character in text)
    {
        if (alphabet.Contains(character))
        {
            int position = alphabet.IndexOf(character);
            int newPosition = (position - key + 26) % 26;
            char newCharacter = alphabet[newPosition];
            message += newCharacter;
        }
        else
        {
            message += character;
        }
    }
    return message;
}

// Metoda testuje różne długości klucza i zwraca tę, która najlepiej pasuje do zaszyfrowanego tekstu
static int FindKeyLength(string file, int maxLengthKeyTest)
{
    string text = OpenFile(file);

    int keyLength = 0;
    double ic = 0;

    Console.WriteLine("\nTestowanie różnych długości klucza....\n");

    for (int i = 1; i <= maxLengthKeyTest; i++)
    {
        List<string> chunksText = SplitText(text, i);
        List<string> newList = SubstringsByPosition(chunksText);

        double sum = 0;
        int count = 0;
        foreach (var item in newList)
        {
            sum += CalcIndexCoincidence(item);
            count++;
        }

        double icChunk = sum / count;

        Console.WriteLine("Długość klucza: " + i + "  |  Indeks koincydencji: " + icChunk);

        if (icChunk > ic && icChunk - ic > 0.01)
        {
            ic = icChunk;
            keyLength = i;
        }
    }

    Console.WriteLine("\nPrzypuszczalna długość klucza wynosi " + keyLength + ", ponieważ indeks koincydencji wynosi " + ic);
    return keyLength;
}

// Metoda deszyfruje zaszyfrowany tekst, próbując odgadnąć klucz przy użyciu szyfru Cezara i analizując częstość występowania liter w kolumnach tekstu.
static void Decrypt(string filePath, int keyLength, string alphabet, string toSaveTextFilePath)
{
    Console.WriteLine("\nPróba odszyfrowania przy użyciu klucza o długości " + keyLength + "....\n");
    string text = OpenFile(filePath);
    List<string> chunksText = SplitText(text, keyLength);
    List<string> newList = SubstringsByPosition(chunksText);
    List<string> newListDecrypted = new List<string>();

    List<int> key = new List<int>();

    for (int index = 0; index < newList.Count; index++)
    {
        Dictionary<char, int> count = new Dictionary<char, int>();

        foreach (char letter in newList[index])
        {
            if (count.ContainsKey(letter))
            {
                count[letter]++;
            }
            else
            {
                count[letter] = 1;
            }
        }

        var sortedCount = count.OrderByDescending(x => x.Value);
        char topLetter = sortedCount.First().Key;
        int distance = DistanceBetweenLetters(topLetter, 'e');
        key.Add(distance);

        Console.WriteLine("Dla pozycji " + index + " spodziewany jest szyfr Cezara o długości " + distance);

        newListDecrypted.Add(CaesarCipherDecrypt(newList[index], distance, alphabet));
    }

    string keyString = string.Join("", key.Select(k => alphabet[k]).ToArray()).ToUpper();
    Console.WriteLine("\nPotencjalny klucz to: " + keyString + "\n");
    Console.WriteLine("Odszyfrowany tekst zapisano w:\n" + toSaveTextFilePath + "\n");

    SaveFile(ReverseSubstringsByPosition(newListDecrypted), toSaveTextFilePath);
}

static void ModifyTextFile(string alphabet)
{
    string mainTextFilesPath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\";

    // Podawanie nazw plików
    Console.WriteLine("Podaj nazwę pliku do oczysczenia:");
    string uncleanedTextFileName = Console.ReadLine();

    // Ścieżki do plików
    string uncleanedTextFilePath = mainTextFilesPath + uncleanedTextFileName + ".txt";

    try
    {
        // Odczytanie zawartości pliku
        string text = File.ReadAllText(uncleanedTextFilePath);

        // Zamiana wielkich liter na małe
        text = text.ToLower();

        // Usunięcie znaków spoza alfabetu
        text = Regex.Replace(text, $"[^{alphabet}]", "");

        // Zapisanie zmodyfikowanej zawartości z powrotem do pliku
        File.WriteAllText(uncleanedTextFilePath, text);

        Console.WriteLine("\nPlik został pomyślnie zmodyfikowany i zapisany w:\n" + uncleanedTextFilePath);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Wystąpił błąd: " + ex.Message);
    }
}