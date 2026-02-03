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
            btnConfiguracoes = new FontAwesome.Sharp.IconButton();
            btnIncidentes = new FontAwesome.Sharp.IconButton();
            pnlMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.BackColor = Color.FloralWhite;
            pnlMenu.Controls.Add(btnConfiguracoes);
            pnlMenu.Controls.Add(btnIncidentes);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(200, 450);
            pnlMenu.TabIndex = 0;
            // 
            // btnConfiguracoes
            // 
            btnConfiguracoes.BackColor = Color.LightSlateGray;
            btnConfiguracoes.Cursor = Cursors.Hand;
            btnConfiguracoes.Font = new Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfiguracoes.ForeColor = Color.White;
            btnConfiguracoes.IconChar = FontAwesome.Sharp.IconChar.Cog;
            btnConfiguracoes.IconColor = Color.White;
            btnConfiguracoes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnConfiguracoes.IconSize = 22;
            btnConfiguracoes.ImageAlign = ContentAlignment.MiddleLeft;
            btnConfiguracoes.Location = new Point(3, 67);
            btnConfiguracoes.Name = "btnConfiguracoes";
            btnConfiguracoes.Padding = new Padding(10, 0, 0, 0);
            btnConfiguracoes.Size = new Size(194, 61);
            btnConfiguracoes.TabIndex = 3;
            btnConfiguracoes.Text = "Configurações";
            btnConfiguracoes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnConfiguracoes.UseVisualStyleBackColor = false;
            btnConfiguracoes.Click += btnConfiguracoes_Click;
            btnConfiguracoes.MouseEnter += btnConfiguracoes_MouseEnter;
            // 
            // btnIncidentes
            // 
            btnIncidentes.BackColor = Color.LightSlateGray;
            btnIncidentes.Cursor = Cursors.Hand;
            btnIncidentes.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIncidentes.ForeColor = Color.White;
            btnIncidentes.IconChar = FontAwesome.Sharp.IconChar.List12;
            btnIncidentes.IconColor = Color.White;
            btnIncidentes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIncidentes.IconSize = 22;
            btnIncidentes.ImageAlign = ContentAlignment.MiddleLeft;
            btnIncidentes.Location = new Point(3, 4);
            btnIncidentes.Name = "btnIncidentes";
            btnIncidentes.Padding = new Padding(10, 0, 0, 0);
            btnIncidentes.Size = new Size(194, 61);
            btnIncidentes.TabIndex = 2;
            btnIncidentes.Text = "Lista de Incidentes";
            btnIncidentes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIncidentes.UseVisualStyleBackColor = false;
            btnIncidentes.Click += btnIncidentes_Click;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlMenu);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormMenu";
            Text = "ServiceNow AI Insights and Analytics (Incidentes AI)";
            WindowState = FormWindowState.Maximized;
            Paint += FormMenu_Paint;
            pnlMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenu;
        private FontAwesome.Sharp.IconButton btnIncidentes;
        private FontAwesome.Sharp.IconButton btnConfiguracoes;
    }
}