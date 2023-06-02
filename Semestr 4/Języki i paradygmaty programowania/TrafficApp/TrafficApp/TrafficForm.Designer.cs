namespace TrafficApp
{
    partial class TrafficApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pointBtn = new System.Windows.Forms.Button();
            this.lineBtn = new System.Windows.Forms.Button();
            this.streetBtn = new System.Windows.Forms.Button();
            this.vehicleBtn = new System.Windows.Forms.Button();
            this.reportText = new System.Windows.Forms.TextBox();
            this.actionLabel = new System.Windows.Forms.Label();
            this.moveBtn = new System.Windows.Forms.Button();
            this.beforeMove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // streetBtn
            // 
            this.streetBtn.Location = new System.Drawing.Point(737, 136);
            this.streetBtn.Name = "streetBtn";
            this.streetBtn.Size = new System.Drawing.Size(115, 32);
            this.streetBtn.TabIndex = 7;
            this.streetBtn.Text = "Streets";
            this.streetBtn.UseVisualStyleBackColor = true;
            this.streetBtn.Click += new System.EventHandler(this.streetBtn_Click);
            // 
            // vehicleBtn
            // 
            this.vehicleBtn.Location = new System.Drawing.Point(737, 174);
            this.vehicleBtn.Name = "vehicleBtn";
            this.vehicleBtn.Size = new System.Drawing.Size(115, 32);
            this.vehicleBtn.TabIndex = 8;
            this.vehicleBtn.Text = "Vehicles";
            this.vehicleBtn.UseVisualStyleBackColor = true;
            this.vehicleBtn.Click += new System.EventHandler(this.vehicleBtn_Click);
            // 
            // reportText
            // 
            this.reportText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.reportText.Location = new System.Drawing.Point(2, 1);
            this.reportText.Multiline = true;
            this.reportText.Name = "reportText";
            this.reportText.ReadOnly = true;
            this.reportText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reportText.Size = new System.Drawing.Size(729, 805);
            this.reportText.TabIndex = 9;
            // 
            // actionLabel
            // 
            this.actionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(751, 262);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(71, 38);
            this.actionLabel.TabIndex = 11;
            this.actionLabel.Text = "Action\r\nFunctions";
            this.actionLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // moveBtn
            // 
            this.moveBtn.Location = new System.Drawing.Point(737, 313);
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(115, 32);
            this.moveBtn.TabIndex = 12;
            this.moveBtn.Text = "Move";
            this.moveBtn.UseVisualStyleBackColor = true;
            this.moveBtn.Click += new System.EventHandler(this.moveBtn_Click);
            // 
            // beforeMove
            // 
            this.beforeMove.Location = new System.Drawing.Point(737, 351);
            this.beforeMove.Name = "beforeMove";
            this.beforeMove.Size = new System.Drawing.Size(115, 32);
            this.beforeMove.TabIndex = 13;
            this.beforeMove.Text = "BefforeMove";
            this.beforeMove.UseVisualStyleBackColor = true;
            this.beforeMove.Click += new System.EventHandler(this.beforeMove_Click);
            // 
            // TrafficApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 807);
            this.Controls.Add(this.beforeMove);
            this.Controls.Add(this.moveBtn);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.reportText);
            this.Controls.Add(this.vehicleBtn);
            this.Controls.Add(this.streetBtn);
            this.Controls.Add(this.lineBtn);
            this.Controls.Add(this.pointBtn);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrafficApp";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button pointBtn;
        private System.Windows.Forms.Button lineBtn;
        private System.Windows.Forms.Button streetBtn;
        private System.Windows.Forms.Button vehicleBtn;
        private System.Windows.Forms.TextBox reportText;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Button moveBtn;
        private System.Windows.Forms.Button beforeMove;
    }
}

