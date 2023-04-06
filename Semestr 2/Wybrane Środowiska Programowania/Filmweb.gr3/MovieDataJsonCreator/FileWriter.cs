using Newtonsoft.Json;
using SanFilmotekaCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDataJsonCreator
{
    internal class FileWriter
    {
        private readonly string path;
        private readonly List<Movie> movies;

        public FileWriter(string path, List<Movie> movies)
        {
            this.path = path;
            this.movies = movies;
        }

        public void SaveFile()
        {
            Console.WriteLine();
            Console.WriteLine(" Trwa zapis pliku ...");
            var json = JsonConvert.SerializeObject(this.movies);    //Serializacja listy filmów do stringa w postaci json
            File.WriteAllText(path, json);  //Stworzenie na dysku pliku json przy użyciu wbudowanej klasy path
            Console.WriteLine($" Plik zapisano w {path}");
        }

    }
}