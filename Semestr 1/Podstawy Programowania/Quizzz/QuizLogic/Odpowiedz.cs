using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizLogic
{
    public class Odpowiedz
    {
        public int Id { get; set; }
        public string Tresc { get; set; }
        public bool CzyPrawidlowa { get; set; }
        public int KolejnoscWyswietlania { get; set; }
    }
}
