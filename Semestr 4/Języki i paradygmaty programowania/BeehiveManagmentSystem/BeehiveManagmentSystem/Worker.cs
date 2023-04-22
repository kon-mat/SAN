using System.Windows.Forms.VisualStyles;

namespace BeehiveManagmentSystem
{
    internal class Worker
    {
        private string currentJob;
        private int shiftsLeft;
        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;

        public string CurrentJob
        { 
            get
            {
                if (String.IsNullOrEmpty(currentJob))
                    return "";
                else
                    return currentJob;
            } 
        }
        public int ShiftsLeft { get { return shiftsLeft; } }
        public bool DoThisJob(string job)
        {
            if (String.IsNullOrEmpty(currentJob) && jobsICanDo.Contains(job))
            {
                currentJob = job;
                return true;
            }
            else
                return false;
        }

       

    }
}