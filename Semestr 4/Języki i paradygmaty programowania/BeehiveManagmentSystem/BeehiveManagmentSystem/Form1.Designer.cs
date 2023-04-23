namespace BeehiveManagmentSystem
{
    partial class workAssignmentGroup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            workerBeeJob = new ComboBox();
            jobsAssignment = new GroupBox();
            shiftsLabel = new Label();
            assignJobButton = new Button();
            shifts = new NumericUpDown();
            workerTaskLabel = new Label();
            report = new TextBox();
            nextShift = new Button();
            jobsAssignment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)shifts).BeginInit();
            SuspendLayout();
            // 
            // workerBeeJob
            // 
            workerBeeJob.DropDownStyle = ComboBoxStyle.DropDownList;
            workerBeeJob.FormattingEnabled = true;
            workerBeeJob.Items.AddRange(new object[] { "Zbieranie nektaru", "Wytwarzanie miodu", "Pielęgnacja jaj", "Nauczanie pszczółek", "Utrzymywanie ula", "Patrol z żądłami" });
            workerBeeJob.Location = new Point(6, 37);
            workerBeeJob.Name = "workerBeeJob";
            workerBeeJob.Size = new Size(178, 23);
            workerBeeJob.TabIndex = 0;
            // 
            // jobsAssignment
            // 
            jobsAssignment.Controls.Add(shiftsLabel);
            jobsAssignment.Controls.Add(assignJobButton);
            jobsAssignment.Controls.Add(shifts);
            jobsAssignment.Controls.Add(workerTaskLabel);
            jobsAssignment.Controls.Add(workerBeeJob);
            jobsAssignment.Location = new Point(12, 12);
            jobsAssignment.Name = "jobsAssignment";
            jobsAssignment.Size = new Size(275, 105);
            jobsAssignment.TabIndex = 1;
            jobsAssignment.TabStop = false;
            jobsAssignment.Text = "Przydział prac robotnicom";
            // 
            // shiftsLabel
            // 
            shiftsLabel.AutoSize = true;
            shiftsLabel.Location = new Point(203, 19);
            shiftsLabel.Name = "shiftsLabel";
            shiftsLabel.Size = new Size(47, 15);
            shiftsLabel.TabIndex = 3;
            shiftsLabel.Text = "Zmiany";
            // 
            // assignJobButton
            // 
            assignJobButton.Location = new Point(6, 66);
            assignJobButton.Name = "assignJobButton";
            assignJobButton.Size = new Size(178, 23);
            assignJobButton.TabIndex = 2;
            assignJobButton.Text = "Przypisz tę pracę pszczole";
            assignJobButton.UseVisualStyleBackColor = true;
            assignJobButton.Click += assignJobButton_Click;
            // 
            // shifts
            // 
            shifts.Location = new Point(203, 37);
            shifts.Name = "shifts";
            shifts.Size = new Size(65, 23);
            shifts.TabIndex = 1;
            // 
            // workerTaskLabel
            // 
            workerTaskLabel.AutoSize = true;
            workerTaskLabel.Location = new Point(6, 19);
            workerTaskLabel.Name = "workerTaskLabel";
            workerTaskLabel.Size = new Size(103, 15);
            workerTaskLabel.TabIndex = 0;
            workerTaskLabel.Text = "Zadanie robotnicy";
            // 
            // report
            // 
            report.Location = new Point(12, 132);
            report.Multiline = true;
            report.Name = "report";
            report.Size = new Size(370, 182);
            report.TabIndex = 2;
            // 
            // nextShift
            // 
            nextShift.Location = new Point(293, 31);
            nextShift.Name = "nextShift";
            nextShift.Size = new Size(89, 70);
            nextShift.TabIndex = 3;
            nextShift.Text = "Przepracuj następną zmianę";
            nextShift.UseVisualStyleBackColor = true;
            nextShift.Click += nextShift_Click;
            // 
            // workAssignmentGroup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(393, 333);
            Controls.Add(nextShift);
            Controls.Add(report);
            Controls.Add(jobsAssignment);
            Name = "workAssignmentGroup";
            Text = "Form1";
            jobsAssignment.ResumeLayout(false);
            jobsAssignment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)shifts).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox workerBeeJob;
        private GroupBox jobsAssignment;
        private Label shiftsLabel;
        private Button assignJobButton;
        private NumericUpDown shifts;
        private Label workerTaskLabel;
        private TextBox report;
        private Button nextShift;
    }
}