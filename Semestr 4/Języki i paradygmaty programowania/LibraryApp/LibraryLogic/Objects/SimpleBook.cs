using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryLogic.Components
{
    public class SimpleBook
    {
        private readonly int _id;
        private readonly string _title;
        private readonly string _author;
        private readonly string _genre;
        private readonly bool _avaible;

        public int Id { get { return _id; } }
        public string Title { get { return _title; } }
        public string Author { get { return _author; } }
        public string Genre { get { return _genre; } }
        public bool Avaible { get { return _avaible; } }

        public SimpleBook(int id, string title, string author, string genre, bool avaible)
        {
            (_id, _title, _author, _genre, _avaible) = (id, title, author, genre, avaible);
        }
    }
}
