using Newtonsoft.Json.Linq;
using ProblemSolveLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSDataJsonCreator
{
    internal class FileParser
    {
        private readonly string path;   // Ścieżka do pliku txt

        public FileParser(string path)
        {
            this.path = path;
        }

        public List<ProblemSolver> GetProblemSolvers()
        {
            Console.WriteLine();
            Console.WriteLine(" Rozpoczynam parsowanie pliku ...");
            var result = new List<ProblemSolver>();
            var lines = File.ReadAllLines(path);    // Metoda zwraca tablicę string'ów
            foreach (var line in lines)
            {
                if (!string.IsNullOrEmpty(line) && !string.IsNullOrWhiteSpace(line))
                {
                    var parts = line.Split("\t");    // Metoda zwraca tablicę stringów na podstawie podanego limitera
                    if (parts.Length == 86)
                    {
                        result.Add(CreateProblemSolver(parts));
                    }
                }
            }

            Console.WriteLine($" Utworzono {result.Count} Problem Solver'ów");
            return result;
        }





        private ProblemSolver CreateProblemSolver(string[] parts)
        {
            int x;
            List<int> myInts = new List<int>();
            for (int i = 8; i < parts.Length; i++)
            {
                if (Int32.TryParse(parts[i], out x))
                {
                    myInts.Add(x);
                }
                else
                {
                    myInts.Add(0);
                }
            }

            ProblemSolver problemSolver = new ProblemSolver
            {
                Id = Guid.NewGuid().ToString(), // Metoda Guid tworzy unkatowy string
                Kronos_name = parts[0],
                Forname = parts[1],
                Name = parts[2],
                Team_Leader = parts[3],
                Date_of_employment = parts[4],
                Mail = parts[5],
                Department = parts[6],
                Shift = parts[7],
                T_PO_Pack = myInts[0],
                T_PO_Pick = myInts[1],
                T_Single = myInts[2],
                T_Express = myInts[3],
                T_Optimus = myInts[4],
                T_Base = myInts[5],
                T_Hot_Pick = myInts[6],
                T_2TPT = myInts[7],
                T_NCO = myInts[8],
                T_Support = myInts[9],
                T_Quality = myInts[10],
                T_WMO = myInts[11],
                T_Process_Pack = myInts[12],
                T_NOS1 = myInts[13],
                T_NOS2 = myInts[14],
                T_Drops = myInts[15],
                T_YBox = myInts[16],
                T_Cartons = myInts[17],
                T_HP = myInts[18],
                T_Process_Pick = myInts[19],
                SL_Optimus = myInts[20],
                SL_Express = myInts[21],
                SL_2TPT = myInts[22],
                SL_LLO = myInts[23],
                SL_Hot_Pick = myInts[24],
                SL_Cancellation_Counter = myInts[25],
                SL_Base = myInts[26],
                SL_Handover = myInts[27],
                SL_CUCA = myInts[28],
                SL_Sample = myInts[29],
                SL_WMO = myInts[30],
                SL_REF = myInts[31],
                SL_Wrong_Articles = myInts[32],
                SL_NCO = myInts[33],
                SL_NCO_WMO_Shipp = myInts[34],
                SL_NCO_DHL_Shipp = myInts[35],
                SL_NCO_TJX_Shipp = myInts[36],
                SL_NCO_AX4_Shipp = myInts[37],
                SL_Analysis = myInts[38],
                SL_Operative = myInts[39],
                SL_QFeed = myInts[40],
                SL_NOS = myInts[41],
                SL_NCO_File = myInts[42],
                SL_PS_WA = myInts[43],
                SL_HP = myInts[44],
                SL_Drops = myInts[45],
                SL_Cartons = myInts[46],
                SL_X_Info = myInts[47],
                SL_QA_LPP = myInts[48],
                AL_Optimus = myInts[49],
                AL_Express = myInts[50],
                AL_2TPT = myInts[51],
                AL_LLO = myInts[52],
                AL_Hot_Pick = myInts[53],
                AL_Cancellation_Counter = myInts[54],
                AL_Base = myInts[55],
                AL_Handover = myInts[56],
                AL_CUCA = myInts[57],
                AL_Sample = myInts[58],
                AL_WMO = myInts[59],
                AL_REF = myInts[60],
                AL_Wrong_Articles = myInts[61],
                AL_NCO = myInts[62],
                AL_NCO_WMO_Shipp = myInts[63],
                AL_NCO_DHL_Shipp = myInts[64],
                AL_NCO_TJX_Shipp = myInts[65],
                AL_NCO_AX4_Shipp = myInts[66],
                AL_Analysis = myInts[67],
                AL_Operative = myInts[68],
                AL_QFeed = myInts[69],
                AL_NOS = myInts[70],
                AL_NCO_File = myInts[71],
                AL_PS_WA = myInts[72],
                AL_HP = myInts[73],
                AL_Drops = myInts[74],
                AL_Cartons = myInts[75],
                AL_X_Info = myInts[76],
                AL_QA_LPP = myInts[77], 
            };

            return problemSolver;
        }





}
}