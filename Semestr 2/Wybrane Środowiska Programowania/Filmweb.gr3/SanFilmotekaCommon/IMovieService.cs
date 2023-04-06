using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanFilmotekaCommon
{
    public interface IMovieService
    {
        IEnumerable<SimpleMovie> GetMoviesByCategory(string category);
        IEnumerable<SimpleMovie> GetMoviesByTitleOrActor(string search);
        IEnumerable<SimpleMovie> GetRandomMovies();
        IEnumerable<string> GetCategories();
        Movie GetMovieById(string id);
    }
}
