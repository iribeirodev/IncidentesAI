namespace IncidentesAI
{
    partial class FormPrompt
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
            panel1 = new Panel();
            lblValue = new Label();
            trackBar1 = new TrackBar();
            label1 = new Label();
            txtPrompt = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(lblValue);
            panel1.Controls.Add(trackBar1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtPrompt);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(582, 368);
            panel1.TabIndex = 1;
            // 
            // lblValue
            // 
            lblValue.BackColor = Color.DarkOrange;
            lblValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValue.ForeColor = Color.White;
            lblValue.Location = new Point(411, 320);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(39, 15);
            lblValue.TabIndex = 4;
            lblValue.TextAlign = ContentAlignment.MiddleRight;
            // 
            // trackBar1
            // 
            trackBar1.BackColor = Color.DimGray;
            trackBar1.Location = new Point(177, 316);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(214, 45);
            trackBar1.TabIndex = 3;
            trackBar1.TabStop = false;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.DarkOrange;
            label1.Location = new Point(97, 321);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 2;
            label1.Text = "Temperatura";
            // 
            // txtPrompt
            // 
            txtPrompt.BackColor = Color.Black;
            txtPrompt.Cursor = Cursors.Hand;
            txtPrompt.ForeColor = Color.Sienna;
            txtPrompt.Location = new Point(23, 16);
            txtPrompt.MaxLength = 5000;
            txtPrompt.Multiline = true;
            txtPrompt.Name = "txtPrompt";
            txtPrompt.ScrollBars = ScrollBars.Both;
            txtPrompt.Size = new Size(542, 283);
            txtPrompt.TabIndex = 1;
            txtPrompt.TabStop = false;
            // 
            // FormPrompt
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(605, 388);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPrompt";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Prompt";
            FormClosing += FormPrompt_FormClosing;
            Load += FormPrompt_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblValue;
        private TrackBar trackBar1;
        private Label label1;
        private TextBox txtPrompt;
    }
}