using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QuizLogic
{
    public class Gra
    {
        public Gra()
        {
            UtworzPulePytan();
            UtworzKategoriePytan();
            BiezacaKategoria = KategoriePytan[IndeksKategorii];
        }

        public int BiezacaKategoria { get; set; }
        public List<Pytanie> PulaPytan { get; set; } //lista nadaje sie najlepiej, zeby przchowywac pule
        public List<int> KategoriePytan { get; set; }
        public int IndeksKategorii { get; set; }
        public Pytanie AktualnePytanie { get; set; }

        void UtworzPulePytan()      // jezeli nie dodamy public, to metoda domyslnie jest private
        {
            // program musi wiedziec gdzie ten plik sie znajduje
            string sciezka = Directory.GetCurrentDirectory() + "\\pytania.json"; // klasa Directory z System.IO, metoda zwraca aktualna sciezke, w ktorej znajduje sie plik wykonywalny exe
            // zamienic zawartosc pliku pytania.json na obiekt typu List<Pytanie>
            string zawartosc = File.ReadAllText(sciezka);    // klasa File z metoda  umozliwia odczytanie zawartosci
                                                             // zamiana json na inne tekst - deserializacja, a na odwort serializacja

            // zeby korzystac z tej biblioteki, trzeba zainstalowac i dopisac using Newtonsoft.Json;
            PulaPytan = JsonConvert.DeserializeObject<List<Pytanie>>(zawartosc);

            // trzeba nadac ID dla pytan, bo w liscie tego nie bylo
            for (int idx = 0; idx < PulaPytan.Count(); idx++)       // nie uzywajmy stalych w petlach
            {
                PulaPytan[idx].Id = idx + 1;
            }
        }

        void UtworzKategoriePytan()
        {
            // Select => zwraca liste o takiej samej liczbie elementów, 
            // można wybrac właściwości które chcemy umieścić w liście
            KategoriePytan = PulaPytan.Select(p => p.Kategoria).Distinct().OrderBy(p => p).ToList();
        }

        public bool CzyMoznaZwiekszycKategorie()
        {
            IndeksKategorii++;
            if (IndeksKategorii > KategoriePytan.Count - 1)
                return false;
            else
            {
                BiezacaKategoria = KategoriePytan[IndeksKategorii];
                return true;
            }
        }

        public void WylosujPytania()
        {
            var pytaniaBezace = PulaPytan.Where(p => p.Kategoria == BiezacaKategoria).ToList();     // zawsze to list
            int liczbaLosowa = Randomizer.Randomizer.GenarateRandomNumber(pytaniaBezace.Count);
            var pytanie = pytaniaBezace[liczbaLosowa - 1];

            // zamieszamy odpowiedziami
            var numerki = Randomizer.Randomizer                                                     // nasza losowo ulozona lista 4 liczb, zbey wyswietlalo losowo odpowiedzi
                .ListOfRandomNumbers(pytanie.Odpowiedzi.Count, pytanie.Odpowiedzi.Count);          // 1 parametr ile chcemy liczb i jaka maksymalna wartosc
                                                                                                   // da nam cztery cyfry od 1 do 4, ale ulozone w losowej kolejnosci

            for (int idx = 0; idx < pytanie.Odpowiedzi.Count; idx++)
            {
                pytanie.Odpowiedzi[idx].KolejnoscWyswietlania = numerki[idx];
            }

            pytanie.Odpowiedzi.OrderBy(p => p.KolejnoscWyswietlania).ToList();
            AktualnePytanie = pytanie;
        }

        public bool CzyGraczOdpowiedzialpoprawnie(int liczba)
        {
            return AktualnePytanie.Odpowiedzi.FirstOrDefault(o => o.KolejnoscWyswietlania == liczba).CzyPrawidlowa;
        }





        // Lista i jej metody
        //List<int> numerki = new List<int>();
        //numerki.Add(4);
        //numerki.Add(10);
        //numerki.Add(15);
        //numerki.Add(8);
        //numerki.Add(1);
        //numerki.Add(4);

        //int numer_a = numerki[0];

        //// LISTA I JEJ METODY
        //// Add - DODAWANIE ELEMNTÓW DO LISTY
        //// WYRAZENIE LAMBDA =>  
        //int numer_b = numerki.FirstOrDefault();     // ta metoda zwraca pierwszy element listy// do tych metod potrzebujemy system linq
        //int numer_c = numerki.FirstOrDefault(n => n > 4);   // daj taki element, gdzie n bedzie wieksze od 4 w sensie wartosc elemntu, a nie index
        //                                                    // Where - wyrazenie, ktore nie zwraca pojedynczego elementu, tylko kolekcje wedlug kryteriow
        //List<int> numerki_a = numerki.Where(n => n > 4).ToList();   // trzeba przerobic to na listę
        //                                                            // metody list mozemy ze sobą łączyć

        //// sortowanie kolekcji
        //// OrderBy, - od najmniejsz do najwie , OrderByDescending - Z-A   od najwiekszej
        //List<int> numerki_d = numerki.Where(n => n > 4).OrderBy(n => n).ToList();       //polaczone metody

        //// Distinct => usuwa z kolekcji duplikaty
        //List<int> numer_e = numerki.Where(n => n > 1).Distinct().ToList();      // 4, 10, 15, 8    i juz 4 nie bedzie, bo to duplikat

        //// Select => pozniej

        //// metody dostepne tylko dla kolekcji liczbowych
        //// Max, Min, Average, Sum
        //var a = numerki.Max();      // 15
        //var b = numerki.Min();      // 1
        //var c = numerki.Average();  // srednia
        //var d = numerki.Sum();      // suma 
        //numerki.Count();            // - zwraca ilosc elemntów list



        //void UtworzKategoriePytan()
        //{
        //    // Select => zwraca liste o takiej samej liczbie elementów, 
        //    // można wybrac właściwości które chcemy umieścić w liście
        //    KategoriePytan = PulaPytan.Select(p => p.Kategoria).Distinct().OrderBy(p => p).ToList();  // właściwość Kategoria, bez duplikatów, rosnąco
        //}

        //public void PrzejdzDoNastepnejKategorii()
        //{
        //    IndeksKategorii++;
        //    BiezacaKategoria = KategoriePytan[IndeksKategorii];
        //    // 500
        //    // 1000
        //    // 2000
        //    // 5000
        //    // 10000
        //}
    }
}



