using Newtonsoft.Json;
using ProblemSolveLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSDataJsonCreator
{
    internal class FileWriter
    {
        private readonly string path;
        private readonly List<ProblemSolver> problemSolvers;

        public FileWriter(string path, List<ProblemSolver> problemSolvers)
        {
            this.path = path;
            this.problemSolvers = problemSolvers;
        }

        public void SaveFile()
        {
            Console.WriteLine();
            Console.WriteLine(" Trwa zapis pliku ...");
            var json = JsonConvert.SerializeObject(this.problemSolvers);    //Serializacja listy filmów do stringa w postaci json
            File.WriteAllText(this.path, json);  //Stworzenie na dysku pliku json przy użyciu wbudowanej klasy path
            Console.WriteLine($" Plik zapisano w {this.path}");
        }

    }
}
