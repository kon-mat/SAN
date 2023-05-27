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
            this.drawing = new System.Windows.Forms.PictureBox();
            this.pixelCoordsLabel = new System.Windows.Forms.Label();
            this.cartesianCoordsLabel = new System.Windows.Forms.Label();
            this.pixelLabel = new System.Windows.Forms.Label();
            this.cartesianLabel = new System.Windows.Forms.Label();
            this.pointBtn = new System.Windows.Forms.Button();
            this.lineBtn = new System.Windows.Forms.Button();
            this.streetBtn = new System.Windows.Forms.Button();
            this.vehicleBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawing)).BeginInit();
            this.SuspendLayout();
            // 
            // drawing
            // 
            this.drawing.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.drawing.BackColor = System.Drawing.SystemColors.Window;
            this.drawing.Location = new System.Drawing.Point(2, 2);
            this.drawing.Name = "drawing";
            this.drawing.Size = new System.Drawing.Size(722, 800);
            this.drawing.TabIndex = 0;
            this.drawing.TabStop = false;
            this.drawing.Paint += new System.Windows.Forms.PaintEventHandler(this.drawing_Paint);
            this.drawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseDown);
            this.drawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseMove);
            // 
            // pixelCoordsLabel
            // 
            this.pixelCoordsLabel.AutoSize = true;
            this.pixelCoordsLabel.Location = new System.Drawing.Point(142, 815);
            this.pixelCoordsLabel.Name = "pixelCoordsLabel";
            this.pixelCoordsLabel.Size = new System.Drawing.Size(31, 19);
            this.pixelCoordsLabel.TabIndex = 1;
            this.pixelCoordsLabel.Text = "x, y";
            // 
            // cartesianCoordsLabel
            // 
            this.cartesianCoordsLabel.AutoSize = true;
            this.cartesianCoordsLabel.Location = new System.Drawing.Point(540, 815);
            this.cartesianCoordsLabel.Name = "cartesianCoordsLabel";
            this.cartesianCoordsLabel.Size = new System.Drawing.Size(33, 19);
            this.cartesianCoordsLabel.TabIndex = 2;
            this.cartesianCoordsLabel.Text = "X, Y";
            // 
            // pixelLabel
            // 
            this.pixelLabel.AutoSize = true;
            this.pixelLabel.Location = new System.Drawing.Point(12, 815);
            this.pixelLabel.Name = "pixelLabel";
            this.pixelLabel.Size = new System.Drawing.Size(124, 19);
            this.pixelLabel.TabIndex = 3;
            this.pixelLabel.Text = "Pixel coordinates:";
            // 
            // cartesianLabel
            // 
            this.cartesianLabel.AutoSize = true;
            this.cartesianLabel.Location = new System.Drawing.Point(379, 815);
            this.cartesianLabel.Name = "cartesianLabel";
            this.cartesianLabel.Size = new System.Drawing.Size(155, 19);
            this.cartesianLabel.TabIndex = 4;
            this.cartesianLabel.Text = "Cartesian coordinates:";
            // 
            // pointBtn
            // 
            this.pointBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pointBtn.Location = new System.Drawing.Point(737, 12);
            this.pointBtn.Name = "pointBtn";
            this.pointBtn.Size = new System.Drawing.Size(115, 32);
            this.pointBtn.TabIndex = 5;
            this.pointBtn.Text = "Point";
            this.pointBtn.UseVisualStyleBackColor = true;
            this.pointBtn.Click += new System.EventHandler(this.pointBtn_Click);
            // 
            // lineBtn
            // 
            this.lineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lineBtn.Location = new System.Drawing.Point(737, 50);
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.Size = new System.Drawing.Size(115, 32);
            this.lineBtn.TabIndex = 6;
            this.lineBtn.Text = "Line";
            this.lineBtn.UseVisualStyleBackColor = true;
            this.lineBtn.Click += new System.EventHandler(this.lineBtn_Click);
            // 
            // streetBtn
            // 
            this.streetBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.streetBtn.Location = new System.Drawing.Point(737, 88);
            this.streetBtn.Name = "streetBtn";
            this.streetBtn.Size = new System.Drawing.Size(115, 32);
            this.streetBtn.TabIndex = 7;
            this.streetBtn.Text = "Streets";
            this.streetBtn.UseVisualStyleBackColor = true;
            this.streetBtn.Click += new System.EventHandler(this.streetBtn_Click);
            // 
            // vehicleBtn
            // 
            this.vehicleBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vehicleBtn.Location = new System.Drawing.Point(737, 126);
            this.vehicleBtn.Name = "vehicleBtn";
            this.vehicleBtn.Size = new System.Drawing.Size(115, 32);
            this.vehicleBtn.TabIndex = 8;
            this.vehicleBtn.Text = "Vehicles";
            this.vehicleBtn.UseVisualStyleBackColor = true;
            this.vehicleBtn.Click += new System.EventHandler(this.vehicleBtn_Click);
            // 
            // TrafficApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 852);
            this.Controls.Add(this.vehicleBtn);
            this.Controls.Add(this.streetBtn);
            this.Controls.Add(this.lineBtn);
            this.Controls.Add(this.pointBtn);
            this.Controls.Add(this.cartesianLabel);
            this.Controls.Add(this.pixelLabel);
            this.Controls.Add(this.cartesianCoordsLabel);
            this.Controls.Add(this.pixelCoordsLabel);
            this.Controls.Add(this.drawing);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TrafficApp";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.drawing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox drawing;
        private System.Windows.Forms.Label pixelCoordsLabel;
        private System.Windows.Forms.Label cartesianCoordsLabel;
        private System.Windows.Forms.Label pixelLabel;
        private System.Windows.Forms.Label cartesianLabel;
        private System.Windows.Forms.Button pointBtn;
        private System.Windows.Forms.Button lineBtn;
        private System.Windows.Forms.Button streetBtn;
        private System.Windows.Forms.Button vehicleBtn;
    }
}

