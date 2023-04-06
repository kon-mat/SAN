using QuizLogic;
using System;

namespace QuizGame
{
    class Program
    {
        static void Main(string[] args)
        {
            {   //Plan programu
                // 1.wyswielenie pytania
                // 2.stworzenie puli pytan
                // 3. wylosowanie pytania z puli pytan
                // 4. wyswietlenie pytania (czyli caly obiekt)
                // 5. Pobieramy odpowiedz od gracza 
                // 6. Weryfikujemy odpowiedz od gracza
                // 7. warunek jezeli odpowie dobrze lub zle - zle - pech, game over
                // 8. jezeli pytanie dobre, to podnosimy kategrie pytania i wracamy do pkt. 3}
            }
            Ekran.PokazPowitanie();
            Gra gra = new Gra();    //bez new Gra(), przestrzen gra bylaby nullem. konstruktor ustawia kategorie na 500 i wywoluje metode utworz pule pytan         

            while (true)
            {
                gra.WylosujPytania();     // Metoda gra.WylosujPytanie zwraca obiekt Pytanie, wiec mozemy uzyc var zmiast Pytanie, bo kompilator 'domysli sie' jaki to typ
                int liczbaGracza = Ekran.PokazPytanieGraczowi(gra.AktualnePytanie);
                if (gra.CzyGraczOdpowiedzialpoprawnie(liczbaGracza))
                {
                    Ekran.Hurra();
                    if (!gra.CzyMoznaZwiekszycKategorie())
                    {
                        Ekran.Wygrana();
                        return;
                    }
                    else
                    {
                        Ekran.Pech();
                        return;
                    }
                }
            }

            //// gracz podaje nam wlasciwosc kolejnosc wyswietlania, a nie ID (nieswiadomie)
            //// mamy zaznaczone ktora odpowiedz jest prawidlowa wlasciwoscia CzyPrawidlowa
            //Odpowiedz odpGracza = p.Odpowiedzi.FirstOrDefault(o => o.KolejnoscWyswietlania == liczbaGracza);

            //if (odpGracza.CzyPrawidlowa)   // Prawodlowa odpowiedz
            //{
            //    // Hurra();
            //    // przejsc do wyższej kategorii
            //    gra.PrzejdzDoNastepnejKategorii();

            //    // wrócić do losowania pytania
            //}
            //else                    // Nieprawidlowa odpowiedz
            //{
            //    // Pech();
            //}

            //Console.ReadLine();

        }
    }
}
