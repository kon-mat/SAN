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
                new NectarCollector(114, new List<Job> { Job.Zbieranie_nektaru, Job.Pielêgnacja_jaj, Job.Nauczanie_Pszczó³ek, Job.Wytwarzanie_miodu }, hive),
                new StingPatrol(149, new List<Job> { Job.Utrzymywanie_ula, Job.Patrol_z_¿¹d³ami }, hive),
                //new NectarStinger(155, new List<Job> { Job.Zbieranie_nektaru, Job.Wytwarzanie_miodu, Job.Pielêgnacja_jaj, Job.Nauczanie_Pszczó³ek, Job.Utrzymywanie_ula, Job.Patrol_z_¿¹d³ami }, hive),
        };


            queen = new Queen(workers, hive);
        }


        private void assignJobButton_Click(object sender, EventArgs e)
        {
            if (queen.AssignWork(workerBeeJob.Text, (int)shifts.Value) == false)    // je¿eli królowa nie mo¿e przypisaæ ¿adnej pszczole wybranego przez u¿ytkownika zadania
            {
                MessageBox.Show($"Nie ma dostêpnych robotnic do wykonania zadania '{workerBeeJob.Text}'", "Królowa pszczó³ mówi...");
            }
            else        // w innym wypadku pomyœlnie przydzielono zadanie pszczole
            {
                MessageBox.Show($"Zadanie '{workerBeeJob.Text}' bêdzie ukoñczone za {shifts.Value} zmiany", "Królowa pszczó³ mówi...");
            }
        }

        private void nextShift_Click(object sender, EventArgs e)
        {
            report.Text = queen.WorkTheNextShift();
        }
    }
}