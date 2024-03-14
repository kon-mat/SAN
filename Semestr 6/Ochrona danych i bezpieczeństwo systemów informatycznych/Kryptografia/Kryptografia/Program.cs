using System.Text;

Console.WriteLine("Mateusz Koniuch - 110893");
Console.WriteLine("Szyfr Vigenere’a - program do odszyfrowania");
Console.WriteLine("=================================================");
Console.WriteLine();


try
{
    // Ścieżki do plików
    string encryptedTextFilePath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\ZaszyfrowanyTekst.txt";
    string keyFilePath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\Klucz.txt";
    string decryptedTextFilePath = "D:\\Programowanie\\SAN\\Semestr 6\\Ochrona danych i bezpieczeństwo systemów informatycznych\\Kryptografia\\Pliki tekstowe\\OdszyfrowanyTekst.txt";

    // Wyświetlenie zawartości plików
    Console.WriteLine("Zawartość pliku zaszyfrowanego:");
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

    Console.WriteLine("\nTekst odszyfrowany i zapisany do pliku.");

    // Wyświetlenie zawartości pliku odszyfrowanego
    Console.WriteLine("\nZawartość pliku odszyfrowanego:");
    ReadFileContent(decryptedTextFilePath);
}
catch (Exception ex)
{
    Console.WriteLine("Wystąpił błąd: " + ex.Message);
}



static string DecryptVigenere(string encryptedText, string key)
{
    StringBuilder decryptedText = new StringBuilder();
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


// Metoda do odczytu zawartości pliku i wyświetlenia jej w konsoli
static void ReadFileContent(string filePath)
{
    string fileContent = File.ReadAllText(filePath);
    Console.WriteLine(fileContent);
}


/* opis funkcjonalności decryptChar

Obliczamy odszyfrowaną literę:
- Odejmujemy kod litery 'A' (który wynosi 65 w kodzie ASCII) od kodu litery zaszyfrowanej, aby uzyskać wartość przesunięcia.
- Następnie odejmujemy kod litery klucza od 'A', aby uzyskać wartość przesunięcia klucza.
- Dodajemy 26 i bierzemy modulo 26, aby zapewnić, że wynik będzie dodatni i mieścił się w zakresie alfabetu (26 liter).
- Dodajemy ponownie kod litery 'A', aby uzyskać kod litery odszyfrowanej.

*/