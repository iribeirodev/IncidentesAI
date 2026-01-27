namespace IncidentesAI
{
    partial class FormAnotacoes
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
            lblDataAtualizacao = new Label();
            txtObservacao = new TextBox();
            cboStatus = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            btnRemover = new Button();
            txtNumero = new TextBox();
            btnAplicar = new Button();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.GhostWhite;
            panel1.Controls.Add(lblDataAtualizacao);
            panel1.Controls.Add(txtObservacao);
            panel1.Controls.Add(cboStatus);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(btnRemover);
            panel1.Controls.Add(txtNumero);
            panel1.Controls.Add(btnAplicar);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(10, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(652, 344);
            panel1.TabIndex = 1;
            // 
            // lblDataAtualizacao
            // 
            lblDataAtualizacao.ForeColor = Color.RoyalBlue;
            lblDataAtualizacao.Location = new Point(43, 244);
            lblDataAtualizacao.Name = "lblDataAtualizacao";
            lblDataAtualizacao.Size = new Size(273, 23);
            lblDataAtualizacao.TabIndex = 8;
            // 
            // txtObservacao
            // 
            txtObservacao.BackColor = Color.White;
            txtObservacao.ForeColor = Color.Black;
            txtObservacao.Location = new Point(165, 150);
            txtObservacao.MaxLength = 250;
            txtObservacao.Multiline = true;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(369, 79);
            txtObservacao.TabIndex = 7;
            txtObservacao.TabStop = false;
            // 
            // cboStatus
            // 
            cboStatus.BackColor = Color.White;
            cboStatus.ForeColor = Color.Black;
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(165, 94);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(369, 23);
            cboStatus.TabIndex = 6;
            cboStatus.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.RoyalBlue;
            label3.Location = new Point(38, 153);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 5;
            label3.Text = "Observação";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(38, 97);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 4;
            label2.Text = "Status Interno";
            // 
            // btnRemover
            // 
            btnRemover.BackColor = Color.OrangeRed;
            btnRemover.Cursor = Cursors.Hand;
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.ForeColor = Color.White;
            btnRemover.Location = new Point(180, 282);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(136, 34);
            btnRemover.TabIndex = 3;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += btnRemover_Click;
            // 
            // txtNumero
            // 
            txtNumero.BackColor = Color.White;
            txtNumero.ForeColor = Color.Black;
            txtNumero.Location = new Point(165, 41);
            txtNumero.MaxLength = 15;
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(151, 23);
            txtNumero.TabIndex = 2;
            txtNumero.TabStop = false;
            // 
            // btnAplicar
            // 
            btnAplicar.BackColor = Color.SeaGreen;
            btnAplicar.Cursor = Cursors.Hand;
            btnAplicar.FlatStyle = FlatStyle.Flat;
            btnAplicar.ForeColor = Color.White;
            btnAplicar.Location = new Point(38, 282);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(136, 34);
            btnAplicar.TabIndex = 1;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(38, 41);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Número";
            // 
            // FormAnotacoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSlateGray;
            ClientSize = new Size(672, 363);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAnotacoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anotações";
            Load += FormAnotacoes_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnRemover;
        private TextBox txtNumero;
        private Button btnAplicar;
        private Label label1;
        private TextBox txtObservacao;
        private ComboBox cboStatus;
        private Label label3;
        private Label label2;
        private Label lblDataAtualizacao;
    }
}