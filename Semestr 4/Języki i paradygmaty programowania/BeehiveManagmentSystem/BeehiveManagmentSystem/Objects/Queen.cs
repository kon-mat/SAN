using BeehiveManagmentSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagmentSystem.Objects
{
    internal class Queen : Bee
    {
        private Hive _hive;
        private List<Worker> _workers;


        public Queen(List<Worker> workers, Hive hive) 
            : base(275)
        {
            _workers = workers;
            _hive = hive;
        }

        public List<Worker> Workers { get { return _workers; } }

        public bool AssignWork(string job, int numberOfShits)
        {
            if (job == Job.Patrol_z_żądłami.ToString())
                foreach (Worker worker in _workers)
                    if (worker is IStingPatrol)
                    {
                        (worker as IStingPatrol).DoPatrol();
                        return true;
                    }

            if (job == Job.Zbieranie_nektaru.ToString())
                foreach (Worker worker2 in _workers)
                    if (worker2 is INectarCollector && worker2.DoThisJob(job, numberOfShits))
                        return true;

            foreach (Worker worker3 in _workers)
                if (!(worker3 is INectarCollector) && !(worker3 is IStingPatrol) && worker3.DoThisJob(job, numberOfShits))
                    return true;

            foreach (Worker worker4 in _workers)
                if ((!(worker4 is INectarCollector) || !(worker4 is IStingPatrol)) && worker4.DoThisJob(job, numberOfShits))
                    return true;

            foreach (Worker worker5 in _workers)
                if (worker5.DoThisJob(job, numberOfShits))
                    return true;

            return false;
        }

        public string WorkTheNextShift()
        {
            double totalConsumpiton = 0;
            foreach (Worker worker in _workers)
            {
                totalConsumpiton += worker.GetHoneyConsumption();
                if (worker is IStingPatrol)
                    (worker as IStingPatrol).GrowStinger();
            }
                
            totalConsumpiton += GetHoneyConsumption();
            _hive.NextShift(this);
            string report = $"Raport zmiany numer {_hive.ShiftNumber}\r\n\r\n";
            report += _hive.AlertLevel == 0 ? "Brak zagrożenia atakiem\r\n" : $"Ul został zaatakowany. Poziom alarmu: {_hive.AlertLevel}. Zdrowie przeciwnika: {_hive.EnemyHP}\r\n";
            report += $"Zgromadzona ilość nektaru w ulu: {_hive.Nectar}\r\n";
            report += $"Dostępne zasoby miodu w ulu: {_hive.Honey}\r\n";
            report += $"Całkowite spożycie miodu: {Math.Round(totalConsumpiton)} jednostek\r\n";

            for (int i = 0; i < _workers.Count(); i++)
            {
                report += $"\r\n• Robotnica numer {i + 1} :\r\n";
                report += _workers[i].WorkOneShift();
            }


            if (FeedBees(totalConsumpiton))
                report += $"\r\nPszczoły zostały pomyślnie nakarmione\r\n";
            else
                report += "Zapotrzebowanie na miód przerosło zasoby ula.";

            report += $"Zgromadzona ilość nektaru po przepracowanej zmianie: {_hive.Nectar}\r\n";
            report += $"Zgromadzona ilość miodu po przepracowanej zmianie: {_hive.Honey}\r\n";
            return report;
        }

        public override double GetHoneyConsumption()
        {
            double consumption = 0;
            double largestWorkersConsumption = 0;
            foreach (Worker worker in _workers)
                if (worker.GetHoneyConsumption() > largestWorkersConsumption)
                    largestWorkersConsumption = worker.GetHoneyConsumption();
            consumption += largestWorkersConsumption;
            if (_workers.Where(w => w.ShiftsLeft > 0).Count() >= 3)
                consumption += 30;
            else
                consumption += 20;
            return consumption;
        }

        public bool FeedBees(double consumption)
        {
            if (consumption > _hive.Honey)
                return false;
            _hive.ShareHoney(consumption);
            return true;
        }












    }
}
