using BeehiveManagmentSystem.Object;

namespace BeehiveManagmentSystem
{
    public partial class workAssignmentGroup : Form
    {
        Queen queen;

        public workAssignmentGroup()
        {
            InitializeComponent();
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(175, new string[] { "Zbieranie nektaru", "Wytwarzanie miodu" });
            workers[1] = new Worker(114, new string[] { "Pielêgnacja jaj", "Nauczanie pszczó³ek" });
            workers[2] = new Worker(149, new string[] { "Utrzymywanie ula", "Patrol z ¿¹d³ami" });
            workers[3] = new Worker(155, new string[] { "Zbieranie nektaru", "Wytwarzanie miodu", "Pielêgnacja jaj", "Nauczanie pszczó³ek", "Utrzymywanie ula", "Patrol z ¿¹d³ami" });
            queen = new Queen(workers);
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