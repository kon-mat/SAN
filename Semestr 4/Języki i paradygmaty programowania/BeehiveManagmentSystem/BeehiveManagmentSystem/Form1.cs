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
            workers[1] = new Worker(114, new string[] { "Piel�gnacja jaj", "Nauczanie pszcz�ek" });
            workers[2] = new Worker(149, new string[] { "Utrzymywanie ula", "Patrol z ��d�ami" });
            workers[3] = new Worker(155, new string[] { "Zbieranie nektaru", "Wytwarzanie miodu", "Piel�gnacja jaj", "Nauczanie pszcz�ek", "Utrzymywanie ula", "Patrol z ��d�ami" });
            queen = new Queen(workers);
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