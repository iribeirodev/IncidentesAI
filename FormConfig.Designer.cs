namespace IncidentesAI
{
    partial class FormConfig
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
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(btnEscolherCaminho);
            panel1.Controls.Add(txtCaminhoBanco);
            panel1.Controls.Add(btnCriarDatabase);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(31, 15);
            panel1.Name = "panel1";
            panel1.Size = new Size(652, 161);
            panel1.TabIndex = 0;
            // 
            // btnEscolherCaminho
            // 
            btnEscolherCaminho.BackgroundImageLayout = ImageLayout.Stretch;
            btnEscolherCaminho.Cursor = Cursors.Hand;
            btnEscolherCaminho.FlatAppearance.BorderColor = Color.White;
            btnEscolherCaminho.FlatAppearance.BorderSize = 0;
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
            txtCaminhoBanco.BackColor = Color.Black;
            txtCaminhoBanco.ForeColor = Color.Orange;
            txtCaminhoBanco.Location = new Point(165, 41);
            txtCaminhoBanco.Name = "txtCaminhoBanco";
            txtCaminhoBanco.ReadOnly = true;
            txtCaminhoBanco.Size = new Size(369, 23);
            txtCaminhoBanco.TabIndex = 2;
            txtCaminhoBanco.TabStop = false;
            // 
            // btnCriarDatabase
            // 
            btnCriarDatabase.BackColor = Color.Orange;
            btnCriarDatabase.Cursor = Cursors.Hand;
            btnCriarDatabase.FlatStyle = FlatStyle.Flat;
            btnCriarDatabase.ForeColor = Color.Black;
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
            label1.ForeColor = Color.Orange;
            label1.Location = new Point(38, 41);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Local Selecionado";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(btnEscolherCaminhoPlanilha);
            panel2.Controls.Add(lblStatusImportacao);
            panel2.Controls.Add(btnImportar);
            panel2.Controls.Add(progressBar1);
            panel2.Controls.Add(txtCaminhoPlanilha);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(31, 192);
            panel2.Name = "panel2";
            panel2.Size = new Size(652, 186);
            panel2.TabIndex = 1;
            // 
            // btnEscolherCaminhoPlanilha
            // 
            btnEscolherCaminhoPlanilha.BackgroundImageLayout = ImageLayout.Stretch;
            btnEscolherCaminhoPlanilha.Cursor = Cursors.Hand;
            btnEscolherCaminhoPlanilha.FlatAppearance.BorderColor = Color.White;
            btnEscolherCaminhoPlanilha.FlatAppearance.BorderSize = 0;
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
            lblStatusImportacao.ForeColor = Color.Orange;
            lblStatusImportacao.Location = new Point(36, 155);
            lblStatusImportacao.Name = "lblStatusImportacao";
            lblStatusImportacao.Size = new Size(582, 23);
            lblStatusImportacao.TabIndex = 10;
            lblStatusImportacao.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnImportar
            // 
            btnImportar.BackColor = Color.Orange;
            btnImportar.Cursor = Cursors.Hand;
            btnImportar.FlatStyle = FlatStyle.Flat;
            btnImportar.ForeColor = Color.Black;
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
            progressBar1.BackColor = Color.FromArgb(50, 50, 50);
            progressBar1.ForeColor = Color.Red;
            progressBar1.Location = new Point(40, 126);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(578, 23);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 8;
            // 
            // txtCaminhoPlanilha
            // 
            txtCaminhoPlanilha.BackColor = Color.Black;
            txtCaminhoPlanilha.ForeColor = Color.Orange;
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
            label2.ForeColor = Color.Orange;
            label2.Location = new Point(36, 42);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 4;
            label2.Text = "Local Selecionado";
            // 
            // FormConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(695, 390);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormConfig";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configurações";
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
    }
}