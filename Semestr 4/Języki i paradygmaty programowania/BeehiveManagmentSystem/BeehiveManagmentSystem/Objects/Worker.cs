using System.Windows.Forms.VisualStyles;

namespace BeehiveManagmentSystem.Object
{
    internal class Worker : Bee
    {
        private string _currentJob;
        private string[] _jobsICanDo;
        private int _shiftsToWork;
        private int _shiftsWorked;

        public Worker(int weight, string[] jobsICanDo) 
            : base(weight)
        {
            _jobsICanDo = jobsICanDo;
        }

        public string CurrentJob { get { return _currentJob; } }
        public override int ShiftsLeft { get { return _shiftsToWork - _shiftsWorked; } }
        public string[] JobsICanDo { get { return _jobsICanDo; } }

        public bool DoThisJob(string job, int numberOfShifts)
        {
            if (!string.IsNullOrEmpty(_currentJob))
                return false;
            foreach (string jobWorkerCanDo in _jobsICanDo)
            {
                if (jobWorkerCanDo == job)
                {
                    _currentJob = job;
                    _shiftsToWork = numberOfShifts;
                    _shiftsWorked = 0;
                    return true;    // jeżeli może wykonać pracę z parametru funkcji
                }
            }
            return false;           // jeżeli nie może wykonać pracy z parametru funkcji
        }

        public bool WorkOneShift()
        {
            if (string.IsNullOrEmpty(_currentJob))
                return false;   // jeżeli pszczoła nie ma przypisanej żadnej pracy
            _shiftsWorked++;    // pszczoła ma przypisaną pracę, więc przepracuje kolejną zmianę
            if (_shiftsWorked > _shiftsToWork)   // jeżeli przepracowano więcej zmian, niż zostało zlecone (oznacza to, że pszczoła pracuje ostanią zmianę)
            {
                _shiftsWorked = 0;
                _shiftsToWork = 0;
                _currentJob = "";
                return true;
            }
            else    // w tym wypadku pszczoła akutalnie pracuje i nie jest to jej ostatnia zmiana
                return false;
        }




    }
}
