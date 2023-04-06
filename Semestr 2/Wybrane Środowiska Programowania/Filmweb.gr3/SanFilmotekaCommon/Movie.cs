using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanFilmotekaCommon
{
    public class Movie
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public List<string> Cast { get; set; } = new();
        public string Genre { get; set; }
        public string Image { get; set; }
        public string Trailer { get; set; }
    }
}