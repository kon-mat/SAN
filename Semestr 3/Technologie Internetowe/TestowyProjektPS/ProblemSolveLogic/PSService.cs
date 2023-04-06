using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProblemSolveLogic
{
    public class PSService : IPSService
    {
        public PSService()
        {
            GetProblemSolversFromJson();
        }

        private IEnumerable<ProblemSolver> problemSolvers { get; set; }

        public ProblemSolver GetPSById(string id)
        {
            return problemSolvers.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<SimpleProblemSolver> GetPSByDepartment(string department)
        {
            return problemSolvers.Where(d => d.Department == department).Select(p => Map(p));
        }

        public IEnumerable<SimpleProblemSolver> GetPSByNameOrForname(string search)
        {
            var ids = new List<string>();
            var searchedPS = new List<ProblemSolver>();
            foreach (var ps in problemSolvers.Where(p => p.Name.Contains(search) || p.Forname.Contains(search)))
            {
                searchedPS.Add(ps);
            }

            return searchedPS.Select(sps => Map(sps));
        }

        private void GetProblemSolversFromJson()
        {
            var json = File.ReadAllText("wwwroot\\data\\PSDataBase.json");
            problemSolvers = JsonConvert.DeserializeObject<IEnumerable<ProblemSolver>>(json);
        }

        private SimpleProblemSolver Map(ProblemSolver problemSolver)
        {
            var simpleProblemSolver = new SimpleProblemSolver
            {
                Id = problemSolver.Id,
                Kronos_name = problemSolver.Kronos_name,
                Forname = problemSolver.Forname,
                Name = problemSolver.Name,
                Team_Leader = problemSolver.Team_Leader,
                Department = problemSolver.Department,
                Shift = problemSolver.Shift,
            };

            return simpleProblemSolver;
        }

    }
}
