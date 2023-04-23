using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Object
{
    internal class Queen : Bee
    {
        private Worker[] _workers;
        private int _shiftNumber = 0;

        public Queen(Worker[] workers) 
            : base(275)
        {
            _workers = workers;
        }

        public bool AssignWork(string job, int numberOfShits)
        {
            foreach (Worker worker in _workers)
                if (worker.DoThisJob(job, numberOfShits))
                    return true;    // pomyślnie przypisano pracę dla pszczoły
            return false;   // nie było możliwości przypisania pracy dla żadnej ze pszczół
        }

        public string WorkTheNextShift()
        {
            double totalConsumpiton = 0;
            foreach (Worker worker in _workers) // pętla do obliczenia konsumpcji miodu wszystkich pszczół
                totalConsumpiton += worker.GetHoneyConsumption();
            totalConsumpiton += GetHoneyConsumption(); // kosumpcja królowej

            _shiftNumber++;
            string report = $"Raport zmiany numer {_shiftNumber}\r\n";
            for (int i = 0; i < _workers.Length; i++)   
            {
                if (_workers[i].WorkOneShift())     // jeżeli któraś z pszczół zakończyła swoją pracę
                    report += $"Robotnica numer {i + 1} zakończyła swoje zadanie\r\n";
                if (string.IsNullOrEmpty(_workers[i].CurrentJob))   // jeżeli pszczoła nie ma przydzielonej pracy
                    report += $"Robotnica numer {i + 1} nie pracuje\r\n";
                else    // w innym wypadku pszczoła ma przydzieloną pracę
                    if (_workers[i].ShiftsLeft > 0)    // jeżeli to nie jest ostatnia zmiana pszczoły
                    report += $"Robotnica numer {i + 1} robi '{_workers[i].CurrentJob}' jeszcze przez {_workers[i].ShiftsLeft} zmiany\r\n";
                else    // jeżeli to jest ostatnia zmiana pszczoły   
                    report += $"Robotnica numer {i + 1} zakończy '{_workers[i].CurrentJob}' po tej zmianie\r\n";
            }
            report += $"Całkowite spożycie miodu: {totalConsumpiton} jednostek";
            return report;
        }

        public override double GetHoneyConsumption()
        {
            double consumption = 0;
            double largestWorkersConsumption = 0;
            foreach (Worker worker in _workers)
                if (worker.GetHoneyConsumption() > largestWorkersConsumption)
                    largestWorkersConsumption = worker.GetHoneyConsumption();
            consumption += largestWorkersConsumption;   // konsumpcja pszczoły, która aktualnie potrzebuje najwięcej miodu
            if (_workers.Where(w => w.ShiftsLeft > 0).Count() >= 3) // jeżeli 3 lub więcej robotnic wykonuje swoją pracę
                consumption += 30;
            else
                consumption += 20;
            return consumption;
        }

    }
}
