using BeehiveManagmentSystem.Interfaces;
using System.Globalization;

namespace BeehiveManagmentSystem.Objects
{
    abstract class Worker : Bee
    {
        public Hive Hive;
        private string _currentJob;
        private List<Job> _jobsICanDo;
        private int _shiftsToWork;
        private int _shiftsWorked;
        private Random _random = new Random();


        public Worker(int weight, List<Job> jobsICanDo, Hive hive)
            : base(weight)
        {
            _jobsICanDo = jobsICanDo;
            Hive = hive;
        }

        public string CurrentJob 
        { 
            get { return _currentJob; } 
            set { _currentJob = value; }
        }
        public override int ShiftsLeft { get { return _shiftsToWork - _shiftsWorked; } }
        public bool LastShift { get { return _shiftsWorked > _shiftsToWork ? true : false; } }
        public List<Job> JobsICanDo { get { return _jobsICanDo; } }

        public virtual bool DoThisJob(string job, int numberOfShifts)
        {
            if (!string.IsNullOrEmpty(_currentJob))
                return false;
            foreach (Job jobWorkerCanDo in _jobsICanDo)
            {
                if (jobWorkerCanDo.ToString() == job)
                {
                    _currentJob = job;
                    _shiftsToWork = numberOfShifts;
                    _shiftsWorked = 0;
                    return true;
                }
            }
            return false;
        }

        public string WorkOneShift()
        {
            string report = "";

            if (string.IsNullOrEmpty(_currentJob))
            {
                report += $"Aktualnie nie pracuje. Potrafi: ";
                for (int i = 0; i < _jobsICanDo.Count(); i++)
                {
                    if (i == _jobsICanDo.Count() - 1)
                        report += $"\r\n    •'{_jobsICanDo[i]}'";
                    else
                        report += $"\r\n    •'{_jobsICanDo[i]}'";
                }
                return report += "\r\n";
            }

            _shiftsWorked++;
            if (LastShift)
            {
                report += $"Zakończy '{_currentJob}' po tej zmianie.\r\n";
                _shiftsWorked = 0;
                _shiftsToWork = 0;
                _currentJob = "";
            }
            else
                report += $"Robi '{_currentJob}' jeszcze przez {ShiftsLeft} zmiany.\r\n";


            if (_currentJob == Job.Wytwarzanie_miodu.ToString())
                report += ProduceHoney();
            if (_currentJob == Job.Zbieranie_nektaru.ToString() && this is INectarCollector)
                report += (this as INectarCollector).CollectNectar(LastShift);
            if (_currentJob == Job.Patrol_z_żądłami.ToString() && this is IStingPatrol)
                report += (this as IStingPatrol).DoPatrol();
                //TodO


            return report + "\r\n";
            // w zaleznosci od pracy zdania ToDo



        }

        public string ProduceHoney()
        {
            double nectarToProcess = 0.5 * this.Weight;
            double producedHoney = 0;
            if (Hive.Nectar < nectarToProcess)
                nectarToProcess = Hive.Nectar;
            Hive.ShareNectar(nectarToProcess);
            if (this is INectarCollector)
                producedHoney = _random.Next(80, 91) * nectarToProcess / 100;
            else
                producedHoney = _random.Next(75, 81) * nectarToProcess / 100;
            Hive.ReceiveHoney(producedHoney);

            return $"Pobrała {nectarToProcess} mg nektaru z ula i wyprodukowała {producedHoney} mg miodu.";
        }

    }
}
