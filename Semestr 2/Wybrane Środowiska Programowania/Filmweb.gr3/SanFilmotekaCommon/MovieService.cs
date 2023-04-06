using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanFilmotekaCommon
{
    public class MovieService : IMovieService
    {
        public MovieService()
        {
            GetMoviesFromJson();
            Random = new Random();
        }

        private IEnumerable<Movie> Movies { get; set; }
        private Random Random { get; set; }

        public IEnumerable<string> GetCategories()
        {
            return Movies.Select(m => m.Genre).Distinct().OrderBy(c => c);
        }

        public Movie GetMovieById(string id)
        {
            return Movies.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<SimpleMovie> GetMoviesByCategory(string category)
        {
            return Movies.Where(m => m.Genre == category).Select(m => Map(m));
        }

        public IEnumerable<SimpleMovie> GetMoviesByTitleOrActor(string search)
        {
            var ids = new List<string>();
            var movies = new List<Movie>();
            foreach (var m in Movies.Where(m => m.Title.Contains(search)))
            {
                if (!ids.Contains(m.Id))
                {
                    ids.Add(m.Id);
                    movies.Add(m);
                }
            }

            foreach (var m in Movies)
            {
                foreach (var c in m.Cast)
                {
                    if (c.Contains(search))
                    {
                        if (!ids.Contains(m.Id))
                        {
                            ids.Add(m.Id);
                            movies.Add(m);
                        }
                    }
                }
            }

            return movies.Select(m => Map(m));
        }

        public IEnumerable<SimpleMovie> GetRandomMovies()
        {
            return Movies.OrderBy(m => Random.Next()).Take(4).Select(m => Map(m));
        }

        private void GetMoviesFromJson()
        {
            var json = File.ReadAllText("wwwroot\\data\\baza_filmow.json");
            Movies = JsonConvert.DeserializeObject<IEnumerable<Movie>>(json);
        }

        private SimpleMovie Map(Movie movie)
        {
            var sm = new SimpleMovie
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Image = movie.Image,
            };

            if (movie.Description.Length >= 50)
                sm.Descr = movie.Description.Substring(0, 50) + " ...";
            else
                sm.Descr = movie.Description + " ...";

            return sm;
        }
    }
}
