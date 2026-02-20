namespace IncidentesAI
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            dgvIncidentes = new DataGridView();
            panel1 = new Panel();
            btnShowCalendarFim = new Button();
            txtDtFim = new TextBox();
            btnShowCalendarInicio = new Button();
            txtDtInicio = new TextBox();
            lblCntFilter = new Label();
            cboCaller = new ComboBox();
            cboStatus = new ComboBox();
            cboConfigurationItem = new ComboBox();
            txtShortDescription = new TextBox();
            txtNumber = new TextBox();
            btnLimpar = new Button();
            btnFiltrar = new Button();
            chkFiltrarData = new CheckBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            btnHistoricoDown = new Button();
            btnHistoricoUp = new Button();
            btnPrompt = new Button();
            lblStatus = new Label();
            btnProcessar = new Button();
            txtPergunta = new TextBox();
            txtHistorico = new RichTextBox();
            timerFade = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvIncidentes).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dgvIncidentes
            // 
            dgvIncidentes.AllowUserToAddRows = false;
            dgvIncidentes.AllowUserToDeleteRows = false;
            dgvIncidentes.AllowUserToResizeColumns = false;
            dgvIncidentes.AllowUserToResizeRows = false;
            dgvIncidentes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvIncidentes.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvIncidentes.BorderStyle = BorderStyle.None;
            dgvIncidentes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(37, 37, 38);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(9, 71, 113);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dgvIncidentes.DefaultCellStyle = dataGridViewCellStyle1;
            dgvIncidentes.EnableHeadersVisualStyles = false;
            dgvIncidentes.GridColor = Color.FromArgb(50, 50, 50);
            dgvIncidentes.Location = new Point(31, 397);
            dgvIncidentes.Name = "dgvIncidentes";
            dgvIncidentes.ReadOnly = true;
            dgvIncidentes.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvIncidentes.Size = new Size(751, 269);
            dgvIncidentes.TabIndex = 0;
            dgvIncidentes.CellDoubleClick += dgvIncidentes_CellDoubleClick;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(30, 30, 30);
            panel1.Controls.Add(btnShowCalendarFim);
            panel1.Controls.Add(txtDtFim);
            panel1.Controls.Add(btnShowCalendarInicio);
            panel1.Controls.Add(txtDtInicio);
            panel1.Controls.Add(lblCntFilter);
            panel1.Controls.Add(cboCaller);
            panel1.Controls.Add(cboStatus);
            panel1.Controls.Add(cboConfigurationItem);
            panel1.Controls.Add(txtShortDescription);
            panel1.Controls.Add(txtNumber);
            panel1.Controls.Add(btnLimpar);
            panel1.Controls.Add(btnFiltrar);
            panel1.Controls.Add(chkFiltrarData);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(31, 29);
            panel1.Name = "panel1";
            panel1.Size = new Size(751, 348);
            panel1.TabIndex = 1;
            // 
            // btnShowCalendarFim
            // 
            btnShowCalendarFim.Cursor = Cursors.Hand;
            btnShowCalendarFim.FlatAppearance.BorderSize = 0;
            btnShowCalendarFim.FlatStyle = FlatStyle.Flat;
            btnShowCalendarFim.Image = (Image)resources.GetObject("btnShowCalendarFim.Image");
            btnShowCalendarFim.Location = new Point(665, 208);
            btnShowCalendarFim.Name = "btnShowCalendarFim";
            btnShowCalendarFim.Size = new Size(33, 23);
            btnShowCalendarFim.TabIndex = 21;
            btnShowCalendarFim.Tag = "DataFim";
            btnShowCalendarFim.UseVisualStyleBackColor = true;
            btnShowCalendarFim.Click += AbrirCalendario;
            // 
            // txtDtFim
            // 
            txtDtFim.BackColor = Color.FromArgb(45, 45, 48);
            txtDtFim.BorderStyle = BorderStyle.FixedSingle;
            txtDtFim.ForeColor = Color.FromArgb(241, 241, 241);
            txtDtFim.Location = new Point(537, 210);
            txtDtFim.MaxLength = 10;
            txtDtFim.Name = "txtDtFim";
            txtDtFim.ReadOnly = true;
            txtDtFim.Size = new Size(127, 23);
            txtDtFim.TabIndex = 20;
            // 
            // btnShowCalendarInicio
            // 
            btnShowCalendarInicio.Cursor = Cursors.Hand;
            btnShowCalendarInicio.FlatAppearance.BorderSize = 0;
            btnShowCalendarInicio.FlatStyle = FlatStyle.Flat;
            btnShowCalendarInicio.Image = (Image)resources.GetObject("btnShowCalendarInicio.Image");
            btnShowCalendarInicio.Location = new Point(491, 208);
            btnShowCalendarInicio.Name = "btnShowCalendarInicio";
            btnShowCalendarInicio.Size = new Size(33, 23);
            btnShowCalendarInicio.TabIndex = 19;
            btnShowCalendarInicio.Tag = "DataInicio";
            btnShowCalendarInicio.UseVisualStyleBackColor = true;
            btnShowCalendarInicio.Click += AbrirCalendario;
            // 
            // txtDtInicio
            // 
            txtDtInicio.BackColor = Color.FromArgb(45, 45, 48);
            txtDtInicio.BorderStyle = BorderStyle.FixedSingle;
            txtDtInicio.ForeColor = Color.FromArgb(241, 241, 241);
            txtDtInicio.Location = new Point(363, 210);
            txtDtInicio.MaxLength = 10;
            txtDtInicio.Name = "txtDtInicio";
            txtDtInicio.ReadOnly = true;
            txtDtInicio.Size = new Size(127, 23);
            txtDtInicio.TabIndex = 18;
            // 
            // lblCntFilter
            // 
            lblCntFilter.ForeColor = Color.DarkGray;
            lblCntFilter.Location = new Point(223, 316);
            lblCntFilter.Name = "lblCntFilter";
            lblCntFilter.Size = new Size(305, 23);
            lblCntFilter.TabIndex = 15;
            lblCntFilter.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cboCaller
            // 
            cboCaller.BackColor = Color.FromArgb(45, 45, 48);
            cboCaller.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCaller.FlatStyle = FlatStyle.Flat;
            cboCaller.ForeColor = Color.FromArgb(241, 241, 241);
            cboCaller.FormattingEnabled = true;
            cboCaller.Location = new Point(366, 138);
            cboCaller.Name = "cboCaller";
            cboCaller.Size = new Size(336, 23);
            cboCaller.TabIndex = 14;
            // 
            // cboStatus
            // 
            cboStatus.BackColor = Color.FromArgb(45, 45, 48);
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FlatStyle = FlatStyle.Flat;
            cboStatus.ForeColor = Color.FromArgb(241, 241, 241);
            cboStatus.FormattingEnabled = true;
            cboStatus.Location = new Point(366, 59);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(336, 23);
            cboStatus.TabIndex = 13;
            // 
            // cboConfigurationItem
            // 
            cboConfigurationItem.BackColor = Color.FromArgb(45, 45, 48);
            cboConfigurationItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cboConfigurationItem.FlatStyle = FlatStyle.Flat;
            cboConfigurationItem.ForeColor = Color.FromArgb(241, 241, 241);
            cboConfigurationItem.FormattingEnabled = true;
            cboConfigurationItem.Location = new Point(33, 213);
            cboConfigurationItem.Name = "cboConfigurationItem";
            cboConfigurationItem.Size = new Size(282, 23);
            cboConfigurationItem.TabIndex = 12;
            // 
            // txtShortDescription
            // 
            txtShortDescription.BackColor = Color.FromArgb(45, 45, 48);
            txtShortDescription.BorderStyle = BorderStyle.FixedSingle;
            txtShortDescription.ForeColor = Color.FromArgb(241, 241, 241);
            txtShortDescription.Location = new Point(32, 138);
            txtShortDescription.MaxLength = 100;
            txtShortDescription.Name = "txtShortDescription";
            txtShortDescription.Size = new Size(283, 23);
            txtShortDescription.TabIndex = 11;
            // 
            // txtNumber
            // 
            txtNumber.BackColor = Color.FromArgb(45, 45, 48);
            txtNumber.BorderStyle = BorderStyle.FixedSingle;
            txtNumber.ForeColor = Color.FromArgb(241, 241, 241);
            txtNumber.Location = new Point(32, 59);
            txtNumber.MaxLength = 10;
            txtNumber.Name = "txtNumber";
            txtNumber.Size = new Size(165, 23);
            txtNumber.TabIndex = 10;
            // 
            // btnLimpar
            // 
            btnLimpar.FlatAppearance.BorderColor = Color.FromArgb(100, 100, 100);
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.ForeColor = Color.FromArgb(200, 200, 200);
            btnLimpar.Location = new Point(374, 269);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(139, 40);
            btnLimpar.TabIndex = 9;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.SteelBlue;
            btnFiltrar.FlatAppearance.BorderSize = 0;
            btnFiltrar.FlatStyle = FlatStyle.Flat;
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(229, 269);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(139, 40);
            btnFiltrar.TabIndex = 8;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = false;
            btnFiltrar.Click += btnFiltrar_Click;
            // 
            // chkFiltrarData
            // 
            chkFiltrarData.AutoSize = true;
            chkFiltrarData.FlatStyle = FlatStyle.Flat;
            chkFiltrarData.ForeColor = Color.Silver;
            chkFiltrarData.Location = new Point(364, 185);
            chkFiltrarData.Name = "chkFiltrarData";
            chkFiltrarData.Size = new Size(175, 19);
            chkFiltrarData.TabIndex = 5;
            chkFiltrarData.Text = "Filtrar por período de criação";
            chkFiltrarData.UseVisualStyleBackColor = false;
            chkFiltrarData.CheckedChanged += chkFiltrarData_CheckedChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.FromArgb(220, 220, 220);
            label5.Location = new Point(364, 111);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 4;
            label5.Text = "Solicitante";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.FromArgb(220, 220, 220);
            label4.Location = new Point(364, 29);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 3;
            label4.Text = "Status";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.FromArgb(220, 220, 220);
            label3.Location = new Point(28, 186);
            label3.Name = "label3";
            label3.Size = new Size(108, 15);
            label3.TabIndex = 2;
            label3.Text = "Configuration Item";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.FromArgb(220, 220, 220);
            label2.Location = new Point(28, 111);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 1;
            label2.Text = "Short Description";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(220, 220, 220);
            label1.Location = new Point(28, 29);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 0;
            label1.Text = "Number";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(30, 30, 30);
            panel2.Controls.Add(btnHistoricoDown);
            panel2.Controls.Add(btnHistoricoUp);
            panel2.Controls.Add(btnPrompt);
            panel2.Controls.Add(lblStatus);
            panel2.Controls.Add(btnProcessar);
            panel2.Controls.Add(txtPergunta);
            panel2.Controls.Add(txtHistorico);
            panel2.Location = new Point(803, 29);
            panel2.Name = "panel2";
            panel2.Size = new Size(329, 637);
            panel2.TabIndex = 4;
            // 
            // btnHistoricoDown
            // 
            btnHistoricoDown.BackColor = Color.FromArgb(45, 45, 48);
            btnHistoricoDown.Cursor = Cursors.Hand;
            btnHistoricoDown.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
            btnHistoricoDown.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
            btnHistoricoDown.FlatStyle = FlatStyle.Flat;
            btnHistoricoDown.Font = new Font("Arial", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHistoricoDown.Location = new Point(293, 37);
            btnHistoricoDown.Name = "btnHistoricoDown";
            btnHistoricoDown.Size = new Size(21, 19);
            btnHistoricoDown.TabIndex = 14;
            btnHistoricoDown.Text = "▼";
            btnHistoricoDown.UseCompatibleTextRendering = true;
            btnHistoricoDown.UseVisualStyleBackColor = false;
            btnHistoricoDown.Click += btnHistoricoDown_Click;
            // 
            // btnHistoricoUp
            // 
            btnHistoricoUp.BackColor = Color.FromArgb(45, 45, 48);
            btnHistoricoUp.Cursor = Cursors.Hand;
            btnHistoricoUp.FlatAppearance.BorderColor = Color.FromArgb(80, 80, 80);
            btnHistoricoUp.FlatAppearance.MouseOverBackColor = Color.SteelBlue;
            btnHistoricoUp.FlatStyle = FlatStyle.Flat;
            btnHistoricoUp.Font = new Font("Arial", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnHistoricoUp.Location = new Point(293, 12);
            btnHistoricoUp.Name = "btnHistoricoUp";
            btnHistoricoUp.Size = new Size(21, 19);
            btnHistoricoUp.TabIndex = 13;
            btnHistoricoUp.Text = "▲";
            btnHistoricoUp.UseCompatibleTextRendering = true;
            btnHistoricoUp.UseVisualStyleBackColor = false;
            btnHistoricoUp.Click += btnHistoricoUp_Click;
            // 
            // btnPrompt
            // 
            btnPrompt.BackColor = Color.FromArgb(45, 45, 48);
            btnPrompt.Cursor = Cursors.Hand;
            btnPrompt.FlatAppearance.BorderColor = Color.SteelBlue;
            btnPrompt.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnPrompt.FlatStyle = FlatStyle.Flat;
            btnPrompt.Font = new Font("Segoe UI Emoji", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPrompt.ForeColor = Color.SteelBlue;
            btnPrompt.Location = new Point(290, 70);
            btnPrompt.Name = "btnPrompt";
            btnPrompt.Size = new Size(24, 24);
            btnPrompt.TabIndex = 12;
            btnPrompt.Text = "✨";
            btnPrompt.UseVisualStyleBackColor = false;
            btnPrompt.Click += btnPrompt_Click;
            // 
            // lblStatus
            // 
            lblStatus.ForeColor = Color.SteelBlue;
            lblStatus.Location = new Point(16, 604);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(298, 23);
            lblStatus.TabIndex = 11;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnProcessar
            // 
            btnProcessar.BackColor = Color.SteelBlue;
            btnProcessar.FlatAppearance.BorderSize = 0;
            btnProcessar.FlatStyle = FlatStyle.Flat;
            btnProcessar.ForeColor = Color.White;
            btnProcessar.Location = new Point(95, 69);
            btnProcessar.Name = "btnProcessar";
            btnProcessar.Size = new Size(139, 26);
            btnProcessar.TabIndex = 10;
            btnProcessar.Text = "Processar";
            btnProcessar.UseVisualStyleBackColor = false;
            btnProcessar.Click += btnProcessar_Click;
            // 
            // txtPergunta
            // 
            txtPergunta.BackColor = Color.FromArgb(45, 45, 48);
            txtPergunta.BorderStyle = BorderStyle.FixedSingle;
            txtPergunta.ForeColor = Color.FromArgb(241, 241, 241);
            txtPergunta.Location = new Point(14, 12);
            txtPergunta.Multiline = true;
            txtPergunta.Name = "txtPergunta";
            txtPergunta.Size = new Size(274, 52);
            txtPergunta.TabIndex = 5;
            // 
            // txtHistorico
            // 
            txtHistorico.BackColor = Color.FromArgb(45, 45, 48);
            txtHistorico.BorderStyle = BorderStyle.FixedSingle;
            txtHistorico.ForeColor = Color.White;
            txtHistorico.Location = new Point(14, 114);
            txtHistorico.Name = "txtHistorico";
            txtHistorico.Size = new Size(303, 474);
            txtHistorico.TabIndex = 4;
            txtHistorico.Text = "";
            // 
            // timerFade
            // 
            timerFade.Interval = 10;
            timerFade.Tick += timerFade_Tick;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1144, 694);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dgvIncidentes);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormMain";
            Opacity = 0D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Incidentes";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIncidentes).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvIncidentes;
        private Panel panel1;
        private ComboBox cboCaller;
        private ComboBox cboStatus;
        private ComboBox cboConfigurationItem;
        private TextBox txtShortDescription;
        private TextBox txtNumber;
        private Button btnLimpar;
        private Button btnFiltrar;
        private CheckBox chkFiltrarData;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private TextBox txtPergunta;
        private RichTextBox txtHistorico;
        private Label lblCntFilter;
        private Button btnProcessar;
        private Label lblStatus;
        private Button btnPrompt;
        private Button btnHistoricoDown;
        private Button btnHistoricoUp;
        private TextBox txtDtInicio;
        private Button btnShowCalendarInicio;
        private Button btnShowCalendarFim;
        private TextBox txtDtFim;
        private System.Windows.Forms.Timer timerFade;
    }
}