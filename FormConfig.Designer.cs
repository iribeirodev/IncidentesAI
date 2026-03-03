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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel1 = new Panel();
            btnEscolherCaminho = new Button();
            txtCaminhoBanco = new TextBox();
            btnCriarDatabase = new Button();
            label1 = new Label();
            panel2 = new Panel();
            progressBar0 = new IncidentesAI.Components.AnimatedProgressBar();
            btnEscolherCaminhoPlanilha = new Button();
            lblStatusImportacao = new Label();
            btnImportar = new Button();
            txtCaminhoPlanilha = new TextBox();
            label2 = new Label();
            timerFade = new System.Windows.Forms.Timer(components);
            panel3 = new Panel();
            lblExplicacao = new Label();
            lblNumeroIncidentes = new Label();
            trackBarNumeroIncidentes = new TrackBar();
            label3 = new Label();
            toolTip1 = new ToolTip(components);
            panel4 = new Panel();
            lblEndpoint = new Label();
            label5 = new Label();
            lblModelo = new Label();
            label6 = new Label();
            label7 = new Label();
            label9 = new Label();
            label11 = new Label();
            label12 = new Label();
            label4 = new Label();
            dgvImported = new DataGridView();
            btnRemoverSelecionadas = new Button();
            btnDesmarcarTodas = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarNumeroIncidentes).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImported).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(btnEscolherCaminho);
            panel1.Controls.Add(txtCaminhoBanco);
            panel1.Controls.Add(btnCriarDatabase);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(22, 51);
            panel1.Name = "panel1";
            panel1.Size = new Size(573, 89);
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
            btnEscolherCaminho.Location = new Point(514, 8);
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
            txtCaminhoBanco.Location = new Point(139, 14);
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
            btnCriarDatabase.Location = new Point(218, 43);
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
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 0;
            label1.Text = "Local Selecionado";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(30, 30, 30);
            panel2.Controls.Add(progressBar0);
            panel2.Controls.Add(btnEscolherCaminhoPlanilha);
            panel2.Controls.Add(lblStatusImportacao);
            panel2.Controls.Add(btnImportar);
            panel2.Controls.Add(txtCaminhoPlanilha);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(22, 205);
            panel2.Name = "panel2";
            panel2.Size = new Size(573, 139);
            panel2.TabIndex = 1;
            // 
            // progressBar0
            // 
            progressBar0.BackColor = Color.FromArgb(20, 20, 20);
            progressBar0.ForeColor = Color.WhiteSmoke;
            progressBar0.Location = new Point(59, 78);
            progressBar0.Name = "progressBar0";
            progressBar0.Size = new Size(465, 23);
            progressBar0.TabIndex = 12;
            // 
            // btnEscolherCaminhoPlanilha
            // 
            btnEscolherCaminhoPlanilha.BackgroundImageLayout = ImageLayout.Stretch;
            btnEscolherCaminhoPlanilha.Cursor = Cursors.Hand;
            btnEscolherCaminhoPlanilha.FlatAppearance.BorderSize = 0;
            btnEscolherCaminhoPlanilha.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnEscolherCaminhoPlanilha.FlatStyle = FlatStyle.Flat;
            btnEscolherCaminhoPlanilha.Image = (Image)resources.GetObject("btnEscolherCaminhoPlanilha.Image");
            btnEscolherCaminhoPlanilha.Location = new Point(514, 3);
            btnEscolherCaminhoPlanilha.Name = "btnEscolherCaminhoPlanilha";
            btnEscolherCaminhoPlanilha.Size = new Size(35, 31);
            btnEscolherCaminhoPlanilha.TabIndex = 11;
            btnEscolherCaminhoPlanilha.TabStop = false;
            btnEscolherCaminhoPlanilha.UseVisualStyleBackColor = true;
            btnEscolherCaminhoPlanilha.Click += btnEscolherCaminhoPlanilha_Click;
            // 
            // lblStatusImportacao
            // 
            lblStatusImportacao.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusImportacao.ForeColor = Color.SteelBlue;
            lblStatusImportacao.Location = new Point(24, 113);
            lblStatusImportacao.Name = "lblStatusImportacao";
            lblStatusImportacao.Size = new Size(525, 17);
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
            btnImportar.Location = new Point(218, 38);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(136, 34);
            btnImportar.TabIndex = 9;
            btnImportar.TabStop = false;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = false;
            btnImportar.Click += btnImportar_Click;
            // 
            // txtCaminhoPlanilha
            // 
            txtCaminhoPlanilha.BackColor = Color.FromArgb(45, 45, 48);
            txtCaminhoPlanilha.BorderStyle = BorderStyle.FixedSingle;
            txtCaminhoPlanilha.ForeColor = Color.Silver;
            txtCaminhoPlanilha.Location = new Point(139, 9);
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
            label2.Location = new Point(24, 11);
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(30, 30, 30);
            panel3.Controls.Add(lblExplicacao);
            panel3.Controls.Add(lblNumeroIncidentes);
            panel3.Controls.Add(trackBarNumeroIncidentes);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(657, 46);
            panel3.Name = "panel3";
            panel3.Size = new Size(567, 94);
            panel3.TabIndex = 2;
            // 
            // lblExplicacao
            // 
            lblExplicacao.AutoSize = true;
            lblExplicacao.BackColor = Color.Transparent;
            lblExplicacao.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExplicacao.ForeColor = Color.Silver;
            lblExplicacao.Location = new Point(14, 59);
            lblExplicacao.Name = "lblExplicacao";
            lblExplicacao.Size = new Size(535, 13);
            lblExplicacao.TabIndex = 8;
            lblExplicacao.Text = "* O número de incidentes influencia diretamente o consumo de tokens (custo de processamento da IA)";
            toolTip1.SetToolTip(lblExplicacao, "Tokens são unidades de texto que a IA processa.\\nEm média, 1 token equivale a 4 caracteres. Quanto mais incidentes você incluir, mais tokens serão consumidos, o que pode afetar o limite de uso da API.");
            // 
            // lblNumeroIncidentes
            // 
            lblNumeroIncidentes.BackColor = Color.SteelBlue;
            lblNumeroIncidentes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNumeroIncidentes.ForeColor = Color.White;
            lblNumeroIncidentes.Location = new Point(460, 11);
            lblNumeroIncidentes.Name = "lblNumeroIncidentes";
            lblNumeroIncidentes.Size = new Size(39, 18);
            lblNumeroIncidentes.TabIndex = 7;
            lblNumeroIncidentes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBarNumeroIncidentes
            // 
            trackBarNumeroIncidentes.BackColor = Color.FromArgb(30, 30, 30);
            trackBarNumeroIncidentes.LargeChange = 10;
            trackBarNumeroIncidentes.Location = new Point(240, 11);
            trackBarNumeroIncidentes.Maximum = 200;
            trackBarNumeroIncidentes.Name = "trackBarNumeroIncidentes";
            trackBarNumeroIncidentes.Size = new Size(214, 45);
            trackBarNumeroIncidentes.SmallChange = 10;
            trackBarNumeroIncidentes.TabIndex = 6;
            trackBarNumeroIncidentes.TabStop = false;
            trackBarNumeroIncidentes.TickFrequency = 20;
            trackBarNumeroIncidentes.Scroll += trackBarNumeroIncidentes_Scroll;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.Silver;
            label3.Location = new Point(14, 14);
            label3.Name = "label3";
            label3.Size = new Size(191, 15);
            label3.TabIndex = 5;
            label3.Text = "Número de Incidentes a considerar";
            // 
            // toolTip1
            // 
            toolTip1.BackColor = Color.Gold;
            toolTip1.ForeColor = Color.Black;
            toolTip1.IsBalloon = true;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(30, 30, 30);
            panel4.Controls.Add(lblEndpoint);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(lblModelo);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(660, 205);
            panel4.Name = "panel4";
            panel4.Size = new Size(564, 139);
            panel4.TabIndex = 3;
            // 
            // lblEndpoint
            // 
            lblEndpoint.AutoSize = true;
            lblEndpoint.BackColor = Color.Transparent;
            lblEndpoint.ForeColor = Color.White;
            lblEndpoint.Location = new Point(141, 83);
            lblEndpoint.Name = "lblEndpoint";
            lblEndpoint.Size = new Size(0, 15);
            lblEndpoint.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.Silver;
            label5.Location = new Point(21, 83);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 7;
            label5.Text = "Endpoint";
            // 
            // lblModelo
            // 
            lblModelo.AutoSize = true;
            lblModelo.BackColor = Color.Transparent;
            lblModelo.ForeColor = Color.White;
            lblModelo.Location = new Point(141, 28);
            lblModelo.Name = "lblModelo";
            lblModelo.Size = new Size(0, 15);
            lblModelo.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = Color.Silver;
            label6.Location = new Point(21, 28);
            label6.Name = "label6";
            label6.Size = new Size(48, 15);
            label6.TabIndex = 5;
            label6.Text = "Modelo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Variable Display Semib", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(22, 9);
            label7.Name = "label7";
            label7.Size = new Size(266, 28);
            label7.TabIndex = 4;
            label7.Text = "Configuração do Database";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Variable Display Semib", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(22, 157);
            label9.Name = "label9";
            label9.Size = new Size(377, 28);
            label9.TabIndex = 6;
            label9.Text = "Importação de Planilha do ServiceNow";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Variable Display Semib", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(653, 9);
            label11.Name = "label11";
            label11.Size = new Size(202, 28);
            label11.TabIndex = 8;
            label11.Text = "Limite de Incidentes";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Variable Display Semib", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(657, 157);
            label12.Name = "label12";
            label12.Size = new Size(237, 28);
            label12.TabIndex = 9;
            label12.Text = "Informações do Modelo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Display Semib", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 360);
            label4.Name = "label4";
            label4.Size = new Size(227, 28);
            label4.TabIndex = 10;
            label4.Text = "Incidentes Importados";
            // 
            // dgvImported
            // 
            dgvImported.AllowUserToAddRows = false;
            dgvImported.AllowUserToResizeRows = false;
            dgvImported.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvImported.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Gainsboro;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvImported.DefaultCellStyle = dataGridViewCellStyle1;
            dgvImported.GridColor = Color.DimGray;
            dgvImported.Location = new Point(22, 396);
            dgvImported.MultiSelect = false;
            dgvImported.Name = "dgvImported";
            dgvImported.ReadOnly = true;
            dgvImported.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvImported.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvImported.Size = new Size(1202, 193);
            dgvImported.TabIndex = 11;
            dgvImported.RowPostPaint += dgvImported_RowPostPaint;
            dgvImported.RowPrePaint += dgvImported_RowPrePaint;
            dgvImported.KeyDown += dgvImported_KeyDown;
            // 
            // btnRemoverSelecionadas
            // 
            btnRemoverSelecionadas.BackColor = Color.Crimson;
            btnRemoverSelecionadas.Cursor = Cursors.Hand;
            btnRemoverSelecionadas.Enabled = false;
            btnRemoverSelecionadas.FlatAppearance.BorderSize = 0;
            btnRemoverSelecionadas.FlatStyle = FlatStyle.Flat;
            btnRemoverSelecionadas.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoverSelecionadas.ForeColor = Color.White;
            btnRemoverSelecionadas.Location = new Point(1079, 595);
            btnRemoverSelecionadas.Name = "btnRemoverSelecionadas";
            btnRemoverSelecionadas.Size = new Size(145, 24);
            btnRemoverSelecionadas.TabIndex = 14;
            btnRemoverSelecionadas.TabStop = false;
            btnRemoverSelecionadas.Text = "Remover Selecionadas";
            btnRemoverSelecionadas.UseVisualStyleBackColor = false;
            btnRemoverSelecionadas.Click += btnRemoverSelecionadas_Click;
            // 
            // btnDesmarcarTodas
            // 
            btnDesmarcarTodas.BackColor = Color.SteelBlue;
            btnDesmarcarTodas.Cursor = Cursors.Hand;
            btnDesmarcarTodas.Enabled = false;
            btnDesmarcarTodas.FlatAppearance.BorderSize = 0;
            btnDesmarcarTodas.FlatStyle = FlatStyle.Flat;
            btnDesmarcarTodas.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDesmarcarTodas.ForeColor = Color.White;
            btnDesmarcarTodas.Location = new Point(897, 595);
            btnDesmarcarTodas.Name = "btnDesmarcarTodas";
            btnDesmarcarTodas.Size = new Size(145, 24);
            btnDesmarcarTodas.TabIndex = 15;
            btnDesmarcarTodas.TabStop = false;
            btnDesmarcarTodas.Text = "Desmarcar Todas";
            btnDesmarcarTodas.UseVisualStyleBackColor = false;
            btnDesmarcarTodas.Click += btnDesmarcarTodas_Click;
            // 
            // FormConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1253, 644);
            Controls.Add(btnDesmarcarTodas);
            Controls.Add(btnRemoverSelecionadas);
            Controls.Add(dgvImported);
            Controls.Add(label4);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarNumeroIncidentes).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvImported).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label lblStatusImportacao;
        private Button btnEscolherCaminhoPlanilha;
        private System.Windows.Forms.Timer timerFade;
        private Panel panel3;
        private Label lblNumeroIncidentes;
        private TrackBar trackBarNumeroIncidentes;
        private Label label3;
        private Label lblExplicacao;
        private ToolTip toolTip1;
        private Panel panel4;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label label11;
        private Label label12;
        private Label lblModelo;
        private Label lblEndpoint;
        private Label label5;
        private Components.AnimatedProgressBar progressBar0;
        private Label label4;
        private DataGridView dgvImported;
        private Button btnRemoverSelecionadas;
        private Button btnDesmarcarTodas;
    }
}