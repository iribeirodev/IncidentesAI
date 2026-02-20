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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            Sair = new PictureBox();
            lblTitulo = new Label();
            pnlPrincipal = new Panel();
            panel4 = new Panel();
            lblDescricao = new Label();
            Panel02 = new Panel();
            Titulo02 = new Label();
            Prompt = new PictureBox();
            Panel03 = new Panel();
            Titulo03 = new Label();
            Configuracoes = new PictureBox();
            Panel01 = new Panel();
            ListaIncidentes = new PictureBox();
            Titulo01 = new Label();
            ((System.ComponentModel.ISupportInitialize)Sair).BeginInit();
            pnlPrincipal.SuspendLayout();
            panel4.SuspendLayout();
            Panel02.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Prompt).BeginInit();
            Panel03.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Configuracoes).BeginInit();
            Panel01.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListaIncidentes).BeginInit();
            SuspendLayout();
            // 
            // Sair
            // 
            Sair.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Sair.BackColor = Color.Transparent;
            Sair.Cursor = Cursors.Hand;
            Sair.Image = (Image)resources.GetObject("Sair.Image");
            Sair.Location = new Point(1110, 5);
            Sair.Margin = new Padding(5);
            Sair.Name = "Sair";
            Sair.Size = new Size(32, 32);
            Sair.SizeMode = PictureBoxSizeMode.StretchImage;
            Sair.TabIndex = 12;
            Sair.TabStop = false;
            Sair.Tag = "Encerrar a aplicação";
            Sair.Click += Sair_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI Variable Text", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.Highlight;
            lblTitulo.Location = new Point(81, 5);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(64, 32);
            lblTitulo.TabIndex = 18;
            lblTitulo.Text = "Title";
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.Anchor = AnchorStyles.None;
            pnlPrincipal.Controls.Add(panel4);
            pnlPrincipal.Controls.Add(Panel02);
            pnlPrincipal.Controls.Add(Panel03);
            pnlPrincipal.Controls.Add(Panel01);
            pnlPrincipal.Location = new Point(81, 102);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(1001, 624);
            pnlPrincipal.TabIndex = 19;
            // 
            // panel4
            // 
            panel4.Controls.Add(lblDescricao);
            panel4.Location = new Point(125, 489);
            panel4.Name = "panel4";
            panel4.Size = new Size(753, 100);
            panel4.TabIndex = 21;
            // 
            // lblDescricao
            // 
            lblDescricao.Font = new Font("Segoe UI Variable Display Semib", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescricao.ForeColor = SystemColors.ButtonShadow;
            lblDescricao.Location = new Point(25, 37);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(696, 26);
            lblDescricao.TabIndex = 17;
            lblDescricao.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Panel02
            // 
            Panel02.BackColor = Color.FromArgb(30, 30, 30);
            Panel02.Controls.Add(Titulo02);
            Panel02.Controls.Add(Prompt);
            Panel02.Cursor = Cursors.Hand;
            Panel02.Location = new Point(122, 171);
            Panel02.Name = "Panel02";
            Panel02.Size = new Size(756, 130);
            Panel02.TabIndex = 20;
            Panel02.Tag = "Configuração de Diretrizes da I.A.";
            Panel02.Click += ExibirFormulario;
            // 
            // Titulo02
            // 
            Titulo02.AutoSize = true;
            Titulo02.BackColor = Color.Transparent;
            Titulo02.Font = new Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold);
            Titulo02.ForeColor = Color.FromArgb(224, 224, 224);
            Titulo02.Location = new Point(291, 47);
            Titulo02.Name = "Titulo02";
            Titulo02.Size = new Size(255, 36);
            Titulo02.TabIndex = 13;
            Titulo02.Text = "Prompt do Sistema";
            Titulo02.Click += ExibirFormulario;
            // 
            // Prompt
            // 
            Prompt.BackColor = Color.Transparent;
            Prompt.Cursor = Cursors.Hand;
            Prompt.Image = (Image)resources.GetObject("Prompt.Image");
            Prompt.Location = new Point(48, 5);
            Prompt.Margin = new Padding(5);
            Prompt.Name = "Prompt";
            Prompt.Size = new Size(158, 120);
            Prompt.SizeMode = PictureBoxSizeMode.CenterImage;
            Prompt.TabIndex = 12;
            Prompt.TabStop = false;
            Prompt.Tag = "Configuração do Prompt (Persona)";
            // 
            // Panel03
            // 
            Panel03.BackColor = Color.FromArgb(30, 30, 30);
            Panel03.Controls.Add(Titulo03);
            Panel03.Controls.Add(Configuracoes);
            Panel03.Cursor = Cursors.Hand;
            Panel03.Location = new Point(122, 307);
            Panel03.Name = "Panel03";
            Panel03.Size = new Size(756, 130);
            Panel03.TabIndex = 19;
            Panel03.Tag = "Database e Importação ServiceNow";
            Panel03.Click += ExibirFormulario;
            // 
            // Titulo03
            // 
            Titulo03.AutoSize = true;
            Titulo03.BackColor = Color.Transparent;
            Titulo03.Font = new Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold);
            Titulo03.ForeColor = Color.FromArgb(224, 224, 224);
            Titulo03.Location = new Point(291, 46);
            Titulo03.Name = "Titulo03";
            Titulo03.Size = new Size(200, 36);
            Titulo03.TabIndex = 13;
            Titulo03.Text = "Configurações";
            Titulo03.Click += ExibirFormulario;
            // 
            // Configuracoes
            // 
            Configuracoes.BackColor = Color.Transparent;
            Configuracoes.Cursor = Cursors.Hand;
            Configuracoes.Image = (Image)resources.GetObject("Configuracoes.Image");
            Configuracoes.Location = new Point(48, 3);
            Configuracoes.Margin = new Padding(5);
            Configuracoes.Name = "Configuracoes";
            Configuracoes.Size = new Size(158, 122);
            Configuracoes.SizeMode = PictureBoxSizeMode.CenterImage;
            Configuracoes.TabIndex = 12;
            Configuracoes.TabStop = false;
            Configuracoes.Tag = "Configurações Gerais";
            // 
            // Panel01
            // 
            Panel01.BackColor = Color.FromArgb(30, 30, 30);
            Panel01.Controls.Add(ListaIncidentes);
            Panel01.Controls.Add(Titulo01);
            Panel01.Cursor = Cursors.Hand;
            Panel01.Location = new Point(122, 35);
            Panel01.Name = "Panel01";
            Panel01.Size = new Size(756, 130);
            Panel01.TabIndex = 18;
            Panel01.Tag = "Lista de incidentes importados do ServiceNow";
            Panel01.Click += ExibirFormulario;
            // 
            // ListaIncidentes
            // 
            ListaIncidentes.BackColor = Color.Transparent;
            ListaIncidentes.Cursor = Cursors.Hand;
            ListaIncidentes.Image = (Image)resources.GetObject("ListaIncidentes.Image");
            ListaIncidentes.Location = new Point(48, 3);
            ListaIncidentes.Margin = new Padding(5);
            ListaIncidentes.Name = "ListaIncidentes";
            ListaIncidentes.Size = new Size(158, 122);
            ListaIncidentes.SizeMode = PictureBoxSizeMode.CenterImage;
            ListaIncidentes.TabIndex = 10;
            ListaIncidentes.TabStop = false;
            ListaIncidentes.Tag = "Exibe a lista de incidentes principal";
            // 
            // Titulo01
            // 
            Titulo01.AutoSize = true;
            Titulo01.BackColor = Color.Transparent;
            Titulo01.Font = new Font("Segoe UI Variable Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Titulo01.ForeColor = Color.FromArgb(224, 224, 224);
            Titulo01.Location = new Point(291, 46);
            Titulo01.Name = "Titulo01";
            Titulo01.Size = new Size(251, 36);
            Titulo01.TabIndex = 11;
            Titulo01.Text = "Lista de Incidentes";
            Titulo01.Click += ExibirFormulario;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1148, 813);
            ControlBox = false;
            Controls.Add(pnlPrincipal);
            Controls.Add(lblTitulo);
            Controls.Add(Sair);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormMenu";
            WindowState = FormWindowState.Maximized;
            Paint += FormMenu_Paint;
            ((System.ComponentModel.ISupportInitialize)Sair).EndInit();
            pnlPrincipal.ResumeLayout(false);
            panel4.ResumeLayout(false);
            Panel02.ResumeLayout(false);
            Panel02.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Prompt).EndInit();
            Panel03.ResumeLayout(false);
            Panel03.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Configuracoes).EndInit();
            Panel01.ResumeLayout(false);
            Panel01.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ListaIncidentes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox Sair;
        private Label lblTitulo;
        private Panel pnlPrincipal;
        private Panel panel4;
        private Label lblDescricao;
        private Panel Panel02;
        private Label Titulo02;
        private PictureBox Prompt;
        private Panel Panel03;
        private Label Titulo03;
        private PictureBox Configuracoes;
        private Panel Panel01;
        private Label Titulo01;
        private PictureBox ListaIncidentes;
    }
}