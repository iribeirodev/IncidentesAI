namespace IncidentesAI
{
    partial class FormCalendar
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
            lblClose = new Label();
            panel1 = new Panel();
            calendarioMensal = new MonthCalendar();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblClose
            // 
            lblClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblClose.BackColor = Color.Transparent;
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblClose.ForeColor = Color.White;
            lblClose.Location = new Point(213, 0);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(16, 17);
            lblClose.TabIndex = 1;
            lblClose.Text = "x";
            lblClose.TextAlign = ContentAlignment.MiddleCenter;
            lblClose.Click += lblClose_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Orange;
            panel1.Controls.Add(calendarioMensal);
            panel1.Location = new Point(-1, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(233, 168);
            panel1.TabIndex = 2;
            // 
            // calendarioMensal
            // 
            calendarioMensal.BackColor = Color.Black;
            calendarioMensal.ForeColor = Color.White;
            calendarioMensal.Location = new Point(3, 3);
            calendarioMensal.MaxDate = new DateTime(2050, 12, 31, 0, 0, 0, 0);
            calendarioMensal.MinDate = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            calendarioMensal.Name = "calendarioMensal";
            calendarioMensal.TabIndex = 1;
            calendarioMensal.TitleBackColor = Color.DarkOrange;
            calendarioMensal.DateSelected += calendarioMensal_DateSelected;
            // 
            // FormCalendar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(231, 190);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(lblClose);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCalendar";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblClose;
        private Panel panel1;
        private MonthCalendar calendarioMensal;
    }
}