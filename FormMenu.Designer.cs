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
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ListaIncidentes = new PictureBox();
            Prompt = new PictureBox();
            Configuracoes = new PictureBox();
            Sair = new PictureBox();
            lblTitulo = new Label();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ListaIncidentes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Prompt).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Configuracoes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Sair).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.DimGray;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 1, 1);
            tableLayoutPanel1.Controls.Add(lblTitulo, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.043479F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.47826F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 43.47826F));
            tableLayoutPanel1.Size = new Size(1107, 620);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.None;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(ListaIncidentes);
            flowLayoutPanel1.Controls.Add(Prompt);
            flowLayoutPanel1.Controls.Add(Configuracoes);
            flowLayoutPanel1.Controls.Add(Sair);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(188, 132);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(728, 165);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.Paint += EstilizarBordaFlowLayout;
            // 
            // ListaIncidentes
            // 
            ListaIncidentes.BackColor = Color.DimGray;
            ListaIncidentes.Cursor = Cursors.Hand;
            ListaIncidentes.Image = (Image)resources.GetObject("ListaIncidentes.Image");
            ListaIncidentes.Location = new Point(5, 5);
            ListaIncidentes.Margin = new Padding(5);
            ListaIncidentes.Name = "ListaIncidentes";
            ListaIncidentes.Size = new Size(172, 148);
            ListaIncidentes.SizeMode = PictureBoxSizeMode.CenterImage;
            ListaIncidentes.TabIndex = 4;
            ListaIncidentes.TabStop = false;
            ListaIncidentes.Tag = "Exibe a lista de incidentes principal";
            ListaIncidentes.Click += ExibirFormulario;
            ListaIncidentes.MouseLeave += EsmaecerMenuItem;
            ListaIncidentes.MouseHover += DestacarMenuItem;
            // 
            // Prompt
            // 
            Prompt.BackColor = Color.DimGray;
            Prompt.Cursor = Cursors.Hand;
            Prompt.Image = (Image)resources.GetObject("Prompt.Image");
            Prompt.Location = new Point(187, 5);
            Prompt.Margin = new Padding(5);
            Prompt.Name = "Prompt";
            Prompt.Size = new Size(172, 148);
            Prompt.SizeMode = PictureBoxSizeMode.CenterImage;
            Prompt.TabIndex = 1;
            Prompt.TabStop = false;
            Prompt.Tag = "Configuração do Prompt (Persona)";
            Prompt.Click += ExibirFormulario;
            Prompt.MouseLeave += EsmaecerMenuItem;
            Prompt.MouseHover += DestacarMenuItem;
            // 
            // Configuracoes
            // 
            Configuracoes.BackColor = Color.DimGray;
            Configuracoes.Cursor = Cursors.Hand;
            Configuracoes.Image = (Image)resources.GetObject("Configuracoes.Image");
            Configuracoes.Location = new Point(369, 5);
            Configuracoes.Margin = new Padding(5);
            Configuracoes.Name = "Configuracoes";
            Configuracoes.Size = new Size(172, 148);
            Configuracoes.SizeMode = PictureBoxSizeMode.CenterImage;
            Configuracoes.TabIndex = 2;
            Configuracoes.TabStop = false;
            Configuracoes.Tag = "Configurações Gerais";
            Configuracoes.Click += ExibirFormulario;
            Configuracoes.MouseLeave += EsmaecerMenuItem;
            Configuracoes.MouseHover += DestacarMenuItem;
            // 
            // Sair
            // 
            Sair.BackColor = Color.DimGray;
            Sair.Cursor = Cursors.Hand;
            Sair.Image = (Image)resources.GetObject("Sair.Image");
            Sair.Location = new Point(551, 5);
            Sair.Margin = new Padding(5);
            Sair.Name = "Sair";
            Sair.Size = new Size(172, 148);
            Sair.SizeMode = PictureBoxSizeMode.CenterImage;
            Sair.TabIndex = 5;
            Sair.TabStop = false;
            Sair.Tag = "Encerrar a aplicação";
            Sair.Click += Sair_Click;
            Sair.MouseLeave += EsmaecerMenuItem;
            Sair.MouseHover += DestacarMenuItem;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.DimGray;
            tableLayoutPanel1.SetColumnSpan(lblTitulo, 3);
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.Orange;
            lblTitulo.Location = new Point(3, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1101, 80);
            lblTitulo.TabIndex = 3;
            lblTitulo.Text = "\r\n";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 620);
            ControlBox = false;
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormMenu";
            WindowState = FormWindowState.Maximized;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ListaIncidentes).EndInit();
            ((System.ComponentModel.ISupportInitialize)Prompt).EndInit();
            ((System.ComponentModel.ISupportInitialize)Configuracoes).EndInit();
            ((System.ComponentModel.ISupportInitialize)Sair).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private PictureBox Prompt;
        private PictureBox Configuracoes;
        private PictureBox ListaIncidentes;
        private Label lblTitulo;
        private PictureBox Sair;
    }
}