using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLogic
{
    public class Pytanie
    {

        public int Id { get; set; }
        public int Kategoria { get; set; }
        public string Tresc { get; set; }
        public List<Odpowiedz> Odpowiedzi { get; set; } = new List<Odpowiedz>();
        // Lista stworzona z Obiektow <Odpowiedz> o nazwie Odpowiedzi
        // Od razu mozemy dodac metode tworzenia nowego obiektu typu Odpowiedz
        // Lista ma takie wlasciwosci ze moze przechowywac tylko obiekty tego samego typu
        


    }
}
