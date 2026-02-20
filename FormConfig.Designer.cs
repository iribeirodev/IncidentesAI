namespace IncidentesAI
{
    partial class FormConfig
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se os recursos gerenciados devem ser descartados; caso contrário, false.</param>
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
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            panel1 = new Panel();
            btnEscolherCaminho = new Button();
            txtCaminhoBanco = new TextBox();
            btnCriarDatabase = new Button();
            label1 = new Label();
            panel2 = new Panel();
            btnEscolherCaminhoPlanilha = new Button();
            lblStatusImportacao = new Label();
            btnImportar = new Button();
            progressBar1 = new ProgressBar();
            txtCaminhoPlanilha = new TextBox();
            label2 = new Label();
            timerFade = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(btnEscolherCaminho);
            panel1.Controls.Add(txtCaminhoBanco);
            panel1.Controls.Add(btnCriarDatabase);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(22, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(652, 161);
            panel1.TabIndex = 0;
            // 
            // btnEscolherCaminho
            // 
            btnEscolherCaminho.BackgroundImageLayout = ImageLayout.Stretch;
            btnEscolherCaminho.Cursor = Cursors.Hand;
            btnEscolherCaminho.FlatAppearance.BorderSize = 0;
            btnEscolherCaminho.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnEscolherCaminho.FlatStyle = FlatStyle.Flat;
            btnEscolherCaminho.Image = (Image)resources.GetObject("btnEscolherCaminho.Image");
            btnEscolherCaminho.Location = new Point(540, 36);
            btnEscolherCaminho.Name = "btnEscolherCaminho";
            btnEscolherCaminho.Size = new Size(35, 31);
            btnEscolherCaminho.TabIndex = 3;
            btnEscolherCaminho.TabStop = false;
            btnEscolherCaminho.UseVisualStyleBackColor = true;
            btnEscolherCaminho.Click += btnEscolherCaminho_Click;
            // 
            // txtCaminhoBanco
            // 
            txtCaminhoBanco.BackColor = Color.FromArgb(45, 45, 48);
            txtCaminhoBanco.BorderStyle = BorderStyle.FixedSingle;
            txtCaminhoBanco.ForeColor = Color.Silver;
            txtCaminhoBanco.Location = new Point(165, 41);
            txtCaminhoBanco.Name = "txtCaminhoBanco";
            txtCaminhoBanco.ReadOnly = true;
            txtCaminhoBanco.Size = new Size(369, 23);
            txtCaminhoBanco.TabIndex = 2;
            txtCaminhoBanco.TabStop = false;
            // 
            // btnCriarDatabase
            // 
            btnCriarDatabase.BackColor = Color.SteelBlue;
            btnCriarDatabase.Cursor = Cursors.Hand;
            btnCriarDatabase.FlatAppearance.BorderSize = 0;
            btnCriarDatabase.FlatStyle = FlatStyle.Flat;
            btnCriarDatabase.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCriarDatabase.ForeColor = Color.White;
            btnCriarDatabase.Location = new Point(39, 91);
            btnCriarDatabase.Name = "btnCriarDatabase";
            btnCriarDatabase.Size = new Size(136, 34);
            btnCriarDatabase.TabIndex = 1;
            btnCriarDatabase.TabStop = false;
            btnCriarDatabase.Text = "Criar Database";
            btnCriarDatabase.UseVisualStyleBackColor = false;
            btnCriarDatabase.Click += btnCriarDatabase_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(38, 41);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Local Selecionado";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(30, 30, 30);
            panel2.Controls.Add(btnEscolherCaminhoPlanilha);
            panel2.Controls.Add(lblStatusImportacao);
            panel2.Controls.Add(btnImportar);
            panel2.Controls.Add(progressBar1);
            panel2.Controls.Add(txtCaminhoPlanilha);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(22, 192);
            panel2.Name = "panel2";
            panel2.Size = new Size(652, 186);
            panel2.TabIndex = 1;
            // 
            // btnEscolherCaminhoPlanilha
            // 
            btnEscolherCaminhoPlanilha.BackgroundImageLayout = ImageLayout.Stretch;
            btnEscolherCaminhoPlanilha.Cursor = Cursors.Hand;
            btnEscolherCaminhoPlanilha.FlatAppearance.BorderSize = 0;
            btnEscolherCaminhoPlanilha.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnEscolherCaminhoPlanilha.FlatStyle = FlatStyle.Flat;
            btnEscolherCaminhoPlanilha.Image = (Image)resources.GetObject("btnEscolherCaminhoPlanilha.Image");
            btnEscolherCaminhoPlanilha.Location = new Point(542, 37);
            btnEscolherCaminhoPlanilha.Name = "btnEscolherCaminhoPlanilha";
            btnEscolherCaminhoPlanilha.Size = new Size(35, 31);
            btnEscolherCaminhoPlanilha.TabIndex = 11;
            btnEscolherCaminhoPlanilha.TabStop = false;
            btnEscolherCaminhoPlanilha.UseVisualStyleBackColor = true;
            btnEscolherCaminhoPlanilha.Click += btnEscolherCaminhoPlanilha_Click;
            // 
            // lblStatusImportacao
            // 
            lblStatusImportacao.ForeColor = Color.SteelBlue;
            lblStatusImportacao.Location = new Point(36, 155);
            lblStatusImportacao.Name = "lblStatusImportacao";
            lblStatusImportacao.Size = new Size(582, 23);
            lblStatusImportacao.TabIndex = 10;
            lblStatusImportacao.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnImportar
            // 
            btnImportar.BackColor = Color.SteelBlue;
            btnImportar.Cursor = Cursors.Hand;
            btnImportar.FlatAppearance.BorderSize = 0;
            btnImportar.FlatStyle = FlatStyle.Flat;
            btnImportar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImportar.ForeColor = Color.White;
            btnImportar.Location = new Point(36, 86);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(136, 34);
            btnImportar.TabIndex = 9;
            btnImportar.TabStop = false;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = false;
            btnImportar.Click += btnImportar_Click;
            // 
            // progressBar1
            // 
            progressBar1.BackColor = Color.FromArgb(45, 45, 48);
            progressBar1.ForeColor = Color.SteelBlue;
            progressBar1.Location = new Point(40, 126);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(578, 20);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 8;
            // 
            // txtCaminhoPlanilha
            // 
            txtCaminhoPlanilha.BackColor = Color.FromArgb(45, 45, 48);
            txtCaminhoPlanilha.BorderStyle = BorderStyle.FixedSingle;
            txtCaminhoPlanilha.ForeColor = Color.Silver;
            txtCaminhoPlanilha.Location = new Point(167, 42);
            txtCaminhoPlanilha.Name = "txtCaminhoPlanilha";
            txtCaminhoPlanilha.ReadOnly = true;
            txtCaminhoPlanilha.Size = new Size(369, 23);
            txtCaminhoPlanilha.TabIndex = 6;
            txtCaminhoPlanilha.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Silver;
            label2.Location = new Point(36, 42);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 4;
            label2.Text = "Local Selecionado";
            // 
            // timerFade
            // 
            timerFade.Interval = 10;
            timerFade.Tick += timerFade_Tick;
            // 
            // FormConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(695, 395);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConfig";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configurações do Sistema";
            Load += FormConfig_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnCriarDatabase;
        private Label label1;
        private Panel panel2;
        private Button btnEscolherCaminho;
        private TextBox txtCaminhoBanco;
        private TextBox txtCaminhoPlanilha;
        private Label label2;
        private Button btnImportar;
        private ProgressBar progressBar1;
        private Label lblStatusImportacao;
        private Button btnEscolherCaminhoPlanilha;
        private System.Windows.Forms.Timer timerFade;
    }
}