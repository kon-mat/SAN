using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemSolveLogic
{
    public interface IPSService
    {
        IEnumerable<SimpleProblemSolver> GetPSByNameOrForname(string search);
        IEnumerable<SimpleProblemSolver> GetPSByDepartment(string department);
        ProblemSolver GetPSById(string id);
    }
}
