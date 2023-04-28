using BeehiveManagmentSystem.Objects;

namespace BeehiveManagmentSystem
{
    public partial class workAssignmentGroup : Form
    {
        Queen queen;
        Hive hive;

        public workAssignmentGroup()
        {
            InitializeComponent();
            hive = new Hive();
            List<Worker> workers = new List<Worker>()
            {
                new NectarCollector(175, new List<Job> { Job.Zbieranie_nektaru, Job.Wytwarzanie_miodu }, hive),
                new NectarCollector(114, new List<Job> { Job.Zbieranie_nektaru, Job.Piel�gnacja_jaj, Job.Nauczanie_Pszcz�ek, Job.Wytwarzanie_miodu }, hive),
                new StingPatrol(149, new List<Job> { Job.Utrzymywanie_ula, Job.Patrol_z_��d�ami }, hive),
                //new NectarStinger(155, new List<Job> { Job.Zbieranie_nektaru, Job.Wytwarzanie_miodu, Job.Piel�gnacja_jaj, Job.Nauczanie_Pszcz�ek, Job.Utrzymywanie_ula, Job.Patrol_z_��d�ami }, hive),
        };


            queen = new Queen(workers, hive);
        }


        private void assignJobButton_Click(object sender, EventArgs e)
        {
            if (queen.AssignWork(workerBeeJob.Text, (int)shifts.Value) == false)    // je�eli kr�lowa nie mo�e przypisa� �adnej pszczole wybranego przez u�ytkownika zadania
            {
                MessageBox.Show($"Nie ma dost�pnych robotnic do wykonania zadania '{workerBeeJob.Text}'", "Kr�lowa pszcz� m�wi...");
            }
            else        // w innym wypadku pomy�lnie przydzielono zadanie pszczole
            {
                MessageBox.Show($"Zadanie '{workerBeeJob.Text}' b�dzie uko�czone za {shifts.Value} zmiany", "Kr�lowa pszcz� m�wi...");
            }
        }

        private void nextShift_Click(object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }
    }
}