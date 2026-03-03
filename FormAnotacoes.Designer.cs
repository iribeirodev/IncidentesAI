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
            panelControles = new Panel();
            label4 = new Label();
            lblDataAtualizacao = new Label();
            txtObservacao = new TextBox();
            cboStatus = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            btnRemover = new Button();
            txtNumero = new TextBox();
            btnAplicar = new Button();
            label1 = new Label();
            panelControles.SuspendLayout();
            SuspendLayout();
            // 
            // panelControles
            // 
            panelControles.BackColor = Color.FromArgb(30, 30, 30);
            panelControles.Controls.Add(label4);
            panelControles.Controls.Add(lblDataAtualizacao);
            panelControles.Controls.Add(txtObservacao);
            panelControles.Controls.Add(cboStatus);
            panelControles.Controls.Add(label3);
            panelControles.Controls.Add(label2);
            panelControles.Controls.Add(btnRemover);
            panelControles.Controls.Add(txtNumero);
            panelControles.Controls.Add(btnAplicar);
            panelControles.Controls.Add(label1);
            panelControles.Location = new Point(11, 9);
            panelControles.Name = "panelControles";
            panelControles.Size = new Size(581, 281);
            panelControles.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Gainsboro;
            label4.Location = new Point(49, 190);
            label4.Name = "label4";
            label4.Size = new Size(106, 15);
            label4.TabIndex = 9;
            label4.Text = "Última Atualização";
            // 
            // lblDataAtualizacao
            // 
            lblDataAtualizacao.BackColor = Color.FromArgb(45, 45, 48);
            lblDataAtualizacao.BorderStyle = BorderStyle.FixedSingle;
            lblDataAtualizacao.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDataAtualizacao.ForeColor = Color.Orange;
            lblDataAtualizacao.Location = new Point(176, 186);
            lblDataAtualizacao.Name = "lblDataAtualizacao";
            lblDataAtualizacao.Size = new Size(369, 23);
            lblDataAtualizacao.TabIndex = 8;
            lblDataAtualizacao.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtObservacao
            // 
            txtObservacao.BackColor = Color.FromArgb(45, 45, 48);
            txtObservacao.BorderStyle = BorderStyle.FixedSingle;
            txtObservacao.ForeColor = Color.FromArgb(241, 241, 241);
            txtObservacao.Location = new Point(176, 93);
            txtObservacao.MaxLength = 250;
            txtObservacao.Multiline = true;
            txtObservacao.Name = "txtObservacao";
            txtObservacao.Size = new Size(369, 79);
            txtObservacao.TabIndex = 7;
            txtObservacao.TabStop = false;
            // 
            // cboStatus
            // 
            cboStatus.BackColor = Color.FromArgb(45, 45, 48);
            cboStatus.FlatStyle = FlatStyle.Flat;
            cboStatus.ForeColor = Color.FromArgb(241, 241, 241);
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(176, 57);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(369, 23);
            cboStatus.TabIndex = 6;
            cboStatus.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.ForeColor = Color.Gainsboro;
            label3.Location = new Point(49, 95);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 5;
            label3.Text = "Observação";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.ForeColor = Color.Gainsboro;
            label2.Location = new Point(49, 61);
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
            btnRemover.Location = new Point(293, 227);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(136, 34);
            btnRemover.TabIndex = 3;
            btnRemover.TabStop = false;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += btnRemover_Click;
            // 
            // txtNumero
            // 
            txtNumero.BackColor = Color.FromArgb(45, 45, 48);
            txtNumero.BorderStyle = BorderStyle.FixedSingle;
            txtNumero.ForeColor = Color.FromArgb(241, 241, 241);
            txtNumero.Location = new Point(176, 21);
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
            btnAplicar.Location = new Point(151, 227);
            btnAplicar.Name = "btnAplicar";
            btnAplicar.Size = new Size(136, 34);
            btnAplicar.TabIndex = 1;
            btnAplicar.TabStop = false;
            btnAplicar.Text = "Aplicar";
            btnAplicar.UseVisualStyleBackColor = false;
            btnAplicar.Click += btnAplicar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Gainsboro;
            label1.Location = new Point(49, 23);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Número";
            // 
            // FormAnotacoes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(602, 301);
            Controls.Add(panelControles);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAnotacoes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Anotações";
            Load += FormAnotacoes_Load;
            panelControles.ResumeLayout(false);
            panelControles.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelControles;
        private Button btnRemover;
        private TextBox txtNumero;
        private Button btnAplicar;
        private Label label1;
        private TextBox txtObservacao;
        private ComboBox cboStatus;
        private Label label3;
        private Label label2;
        private Label lblDataAtualizacao;
        private Label label4;
    }
}