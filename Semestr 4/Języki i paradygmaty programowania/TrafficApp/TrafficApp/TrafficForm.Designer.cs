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
            this.reportText = new System.Windows.Forms.TextBox();
            this.moveBtn = new System.Windows.Forms.Button();
            this.trafficJamsText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pointBtn
            // 
            this.pointBtn.Location = new System.Drawing.Point(0, 0);
            this.pointBtn.Name = "pointBtn";
            this.pointBtn.Size = new System.Drawing.Size(75, 23);
            this.pointBtn.TabIndex = 15;
            // 
            // lineBtn
            // 
            this.lineBtn.Location = new System.Drawing.Point(0, 0);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(75, 23);
            this.lineBtn.TabIndex = 14;
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
            this.reportText.Size = new System.Drawing.Size(774, 596);
            this.reportText.TabIndex = 9;
            // 
            // moveBtn
            // 
            this.moveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.moveBtn.Location = new System.Drawing.Point(782, 1);
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.Size = new System.Drawing.Size(380, 43);
            this.moveBtn.TabIndex = 12;
            this.moveBtn.Text = "Move";
            this.moveBtn.UseVisualStyleBackColor = true;
            this.moveBtn.Click += new System.EventHandler(this.moveBtn_Click);
            // 
            // trafficJamsText
            // 
            this.trafficJamsText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trafficJamsText.Location = new System.Drawing.Point(782, 50);
            this.trafficJamsText.Multiline = true;
            this.trafficJamsText.Name = "trafficJamsText";
            this.trafficJamsText.ReadOnly = true;
            this.trafficJamsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.trafficJamsText.Size = new System.Drawing.Size(380, 547);
            this.trafficJamsText.TabIndex = 16;
            // 
            // TrafficApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 598);
            this.Controls.Add(this.trafficJamsText);
            this.Controls.Add(this.moveBtn);
            this.Controls.Add(this.reportText);
            this.Controls.Add(this.lineBtn);
            this.Controls.Add(this.pointBtn);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrafficApp";
            this.Text = "`";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button pointBtn;
        private System.Windows.Forms.Button lineBtn;
        private System.Windows.Forms.TextBox reportText;
        private System.Windows.Forms.Button moveBtn;
        private System.Windows.Forms.TextBox trafficJamsText;
    }
}

