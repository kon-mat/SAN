using QuizLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame
{
    public static class Ekran
    {
        public static void PokazPowitanie()    // Powitanie gracza na poczatku gry
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("WITAJ W QUIZE. ZYCZYMY SZCZESCIA");
            Console.WriteLine("Nacisnij ENTER aby rozpoczac");
            Console.ReadLine();         // Pozwala uzytkownikowi wpisac cos, zeby mogl zdecydowac, kiedy rozpoczyna gre
        }


        public static int PokazPytanieGraczowi(Pytanie pytanie)
        {
            WyswietlPytanie(pytanie, true);
            string klawisz = Console.ReadLine();
            bool czyDobryKlawisz = klawisz == "1" || klawisz == "2" || klawisz == "3" || klawisz == "4";
            while (!czyDobryKlawisz)
            {
                WyswietlPytanie(pytanie, false);
                klawisz = Console.ReadLine();
                czyDobryKlawisz = klawisz == "1" || klawisz == "2" || klawisz == "3" || klawisz == "4";
            }

            return int.Parse(klawisz);
        }

        static void WyswietlPytanie(Pytanie pytanie, bool czyPierwszyRaz)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Pytanie za {pytanie.Kategoria} pkt.");
            Console.WriteLine();
            Console.WriteLine(pytanie.Tresc);
            Console.WriteLine();
            foreach (var odp in pytanie.Odpowiedzi)
            {
                Console.WriteLine($"{odp.KolejnoscWyswietlania}. {odp.Tresc}");
            }
            Console.WriteLine();
            if (czyPierwszyRaz)
                Console.Write("Proszę wybrać 1, 2, 3 lub 4: ");
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Nieprawiłowy klawisz. Proszę wybrać 1, 2, 3 lub 4: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static void Hurra()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BRAWO, DOBRA ODPOWIEDZ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        public static void Wygrana()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("BRAWO, UKOŃCZYŁEŚ QUIZ, WYGARŁAŚ/EŚ 10000 pkt.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }


        public static void Pech()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("SORRY, BŁĘDNA ODPOWIEDZ, KONIEC GRY");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }


    }
}


//public static string PokazPytanieGraczowi(Pytanie pytanie)     // Parametrem jest obiekt pytanie, zebysmy mogli uzyc takich wlasciwosci jak tresc danego pytania itd. Metoda zwraca zmienna typu string, czyli odpowiedz od gracza
//{
//    Console.Clear();            // Czyszczenie konsoli przy pojawieniu sie nowego pytania 
//    Console.WriteLine();
//    //Console.WriteLine("Pytanie za " + pytanie.Kategoria + "pkt.");  
//    Console.WriteLine($"Pytanie za {pytanie.Kategoria} pkt.");
//    Console.WriteLine();
//    Console.WriteLine(pytanie.Tresc);
//    Console.WriteLine();

//    foreach (var odp in pytanie.Odpowiedzi)     // Dla kazdego - moze zostac wykorzystana tylko i wylacznie, gdy mamy jakas kolekcje (np. lista, tablice lub inne typy)
//    {
//        Console.WriteLine($"{odp.KolejnoscWyswietlania}. {odp.Tresc}");
//    }
//    Console.WriteLine();
//    Console.WriteLine("Prosze wybrac 1, 2, 3 lub 4:");
//    return Console.ReadLine();
//}