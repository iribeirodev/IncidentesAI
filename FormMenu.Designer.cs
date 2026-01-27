namespace IncidentesAI
{
    partial class FormMenu
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
            pnlMenu = new Panel();
            lblConfiguracoes = new Label();
            lblIncidentes = new Label();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.Azure;
            pnlMenu.Controls.Add(lblConfiguracoes);
            pnlMenu.Controls.Add(lblIncidentes);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(200, 450);
            pnlMenu.TabIndex = 0;
            // 
            // lblConfiguracoes
            // 
            lblConfiguracoes.BackColor = Color.FromArgb(40, 121, 190);
            lblConfiguracoes.Cursor = Cursors.Hand;
            lblConfiguracoes.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold);
            lblConfiguracoes.ForeColor = Color.White;
            lblConfiguracoes.Location = new Point(4, 45);
            lblConfiguracoes.Name = "lblConfiguracoes";
            lblConfiguracoes.Size = new Size(193, 38);
            lblConfiguracoes.TabIndex = 1;
            lblConfiguracoes.Text = "Configurações";
            lblConfiguracoes.TextAlign = ContentAlignment.MiddleCenter;
            lblConfiguracoes.Click += lblConfiguracoes_Click;
            lblConfiguracoes.MouseLeave += OnMenuMouseLeave;
            lblConfiguracoes.MouseHover += OnMenuMouseHover;
            // 
            // lblIncidentes
            // 
            lblIncidentes.BackColor = Color.FromArgb(40, 121, 190);
            lblIncidentes.Cursor = Cursors.Hand;
            lblIncidentes.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold);
            lblIncidentes.ForeColor = Color.White;
            lblIncidentes.Location = new Point(4, 5);
            lblIncidentes.Name = "lblIncidentes";
            lblIncidentes.Size = new Size(193, 38);
            lblIncidentes.TabIndex = 0;
            lblIncidentes.Text = "Lista de Incidentes";
            lblIncidentes.TextAlign = ContentAlignment.MiddleCenter;
            lblIncidentes.Click += lblIncidentes_Click;
            lblIncidentes.MouseLeave += OnMenuMouseLeave;
            lblIncidentes.MouseHover += OnMenuMouseHover;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Snow;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormMenu";
            Text = "Incidentes App";
            WindowState = FormWindowState.Maximized;
            pnlMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private Label lblConfiguracoes;
        private Label lblIncidentes;
    }
}