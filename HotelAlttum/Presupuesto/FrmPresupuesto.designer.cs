namespace CarteraGeneral
{
    partial class FrmPresupuesto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPresupuesto));
            this.DtpFechaCorte = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.DgvPresupuesto = new System.Windows.Forms.DataGridView();
            this.Clip = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Adjudicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NCuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Interes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cuota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasCpt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diaslqd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCartera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblNumRegistro = new System.Windows.Forms.Label();
            this.TxtTotalSaldo = new System.Windows.Forms.TextBox();
            this.TxtRegistros = new System.Windows.Forms.TextBox();
            this.LblTotalSaldo = new System.Windows.Forms.Label();
            this.PnlSuperior = new System.Windows.Forms.Panel();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.TxtCuotaMax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbTipoCartera = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnCalcular = new System.Windows.Forms.Button();
            this.TxtMora = new System.Windows.Forms.TextBox();
            this.LblMora = new System.Windows.Forms.Label();
            this.TxtTotalPrs = new System.Windows.Forms.TextBox();
            this.LblTotalPrs = new System.Windows.Forms.Label();
            this.BtnMontar = new System.Windows.Forms.Button();
            this.LblMontar = new System.Windows.Forms.Label();
            this.TxtDias0 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtDias30 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtDias60 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtDias90 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtDias120 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtMas150 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPresupuesto)).BeginInit();
            this.PnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // DtpFechaCorte
            // 
            this.DtpFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaCorte.Location = new System.Drawing.Point(147, 2);
            this.DtpFechaCorte.Name = "DtpFechaCorte";
            this.DtpFechaCorte.Size = new System.Drawing.Size(101, 20);
            this.DtpFechaCorte.TabIndex = 0;
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(408, 2);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(99, 20);
            this.DtpFechaFin.TabIndex = 1;
            // 
            // DgvPresupuesto
            // 
            this.DgvPresupuesto.AllowUserToAddRows = false;
            this.DgvPresupuesto.AllowUserToDeleteRows = false;
            this.DgvPresupuesto.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPresupuesto.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPresupuesto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPresupuesto.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Clip,
            this.Adjudicacion,
            this.Cliente,
            this.Concepto,
            this.NCuota,
            this.Fecha,
            this.UltPago,
            this.Capital,
            this.Interes,
            this.Cuota,
            this.DiasCpt,
            this.Diaslqd,
            this.Mora,
            this.TipoCartera});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPresupuesto.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvPresupuesto.Location = new System.Drawing.Point(0, 70);
            this.DgvPresupuesto.Name = "DgvPresupuesto";
            this.DgvPresupuesto.Size = new System.Drawing.Size(1293, 366);
            this.DgvPresupuesto.TabIndex = 2;
            this.DgvPresupuesto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPresupuesto_CellContentClick);
            this.DgvPresupuesto.CurrentCellDirtyStateChanged += new System.EventHandler(this.DgvPresupuesto_CurrentCellDirtyStateChanged);
            // 
            // Clip
            // 
            this.Clip.HeaderText = "*";
            this.Clip.Name = "Clip";
            this.Clip.Width = 20;
            // 
            // Adjudicacion
            // 
            this.Adjudicacion.HeaderText = "Adj";
            this.Adjudicacion.Name = "Adjudicacion";
            this.Adjudicacion.Width = 70;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Width = 250;
            // 
            // Concepto
            // 
            this.Concepto.HeaderText = "Cto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 40;
            // 
            // NCuota
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NCuota.DefaultCellStyle = dataGridViewCellStyle2;
            this.NCuota.HeaderText = "#";
            this.NCuota.Name = "NCuota";
            this.NCuota.Width = 40;
            // 
            // Fecha
            // 
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 85;
            // 
            // UltPago
            // 
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.UltPago.DefaultCellStyle = dataGridViewCellStyle4;
            this.UltPago.HeaderText = "Ult Pago";
            this.UltPago.Name = "UltPago";
            this.UltPago.Width = 85;
            // 
            // Capital
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Capital.DefaultCellStyle = dataGridViewCellStyle5;
            this.Capital.HeaderText = "Capital";
            this.Capital.Name = "Capital";
            // 
            // Interes
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Interes.DefaultCellStyle = dataGridViewCellStyle6;
            this.Interes.HeaderText = "Interes";
            this.Interes.Name = "Interes";
            // 
            // Cuota
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Cuota.DefaultCellStyle = dataGridViewCellStyle7;
            this.Cuota.HeaderText = "Cuota";
            this.Cuota.Name = "Cuota";
            // 
            // DiasCpt
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.DiasCpt.DefaultCellStyle = dataGridViewCellStyle8;
            this.DiasCpt.HeaderText = "Dias Cpt";
            this.DiasCpt.Name = "DiasCpt";
            this.DiasCpt.Width = 83;
            // 
            // Diaslqd
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Diaslqd.DefaultCellStyle = dataGridViewCellStyle9;
            this.Diaslqd.HeaderText = "Dias lqd";
            this.Diaslqd.Name = "Diaslqd";
            this.Diaslqd.Width = 83;
            // 
            // Mora
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.Mora.DefaultCellStyle = dataGridViewCellStyle10;
            this.Mora.HeaderText = "Mora";
            this.Mora.Name = "Mora";
            // 
            // TipoCartera
            // 
            this.TipoCartera.HeaderText = "Tipo Cartera";
            this.TipoCartera.Name = "TipoCartera";
            this.TipoCartera.Width = 150;
            // 
            // LblNumRegistro
            // 
            this.LblNumRegistro.AutoSize = true;
            this.LblNumRegistro.Location = new System.Drawing.Point(37, 449);
            this.LblNumRegistro.Name = "LblNumRegistro";
            this.LblNumRegistro.Size = new System.Drawing.Size(91, 13);
            this.LblNumRegistro.TabIndex = 244;
            this.LblNumRegistro.Text = "Numero Registros";
            // 
            // TxtTotalSaldo
            // 
            this.TxtTotalSaldo.Location = new System.Drawing.Point(174, 470);
            this.TxtTotalSaldo.Name = "TxtTotalSaldo";
            this.TxtTotalSaldo.ReadOnly = true;
            this.TxtTotalSaldo.Size = new System.Drawing.Size(100, 20);
            this.TxtTotalSaldo.TabIndex = 247;
            this.TxtTotalSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtRegistros
            // 
            this.TxtRegistros.Location = new System.Drawing.Point(174, 446);
            this.TxtRegistros.Name = "TxtRegistros";
            this.TxtRegistros.ReadOnly = true;
            this.TxtRegistros.Size = new System.Drawing.Size(40, 20);
            this.TxtRegistros.TabIndex = 246;
            this.TxtRegistros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblTotalSaldo
            // 
            this.LblTotalSaldo.AutoSize = true;
            this.LblTotalSaldo.Location = new System.Drawing.Point(37, 469);
            this.LblTotalSaldo.Name = "LblTotalSaldo";
            this.LblTotalSaldo.Size = new System.Drawing.Size(62, 13);
            this.LblTotalSaldo.TabIndex = 245;
            this.LblTotalSaldo.Text = "Total Cuota";
            // 
            // PnlSuperior
            // 
            this.PnlSuperior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PnlSuperior.Controls.Add(this.BtnExportar);
            this.PnlSuperior.Controls.Add(this.TxtCuotaMax);
            this.PnlSuperior.Controls.Add(this.label4);
            this.PnlSuperior.Controls.Add(this.BtnSalir);
            this.PnlSuperior.Controls.Add(this.label3);
            this.PnlSuperior.Controls.Add(this.CmbTipoCartera);
            this.PnlSuperior.Controls.Add(this.label2);
            this.PnlSuperior.Controls.Add(this.label1);
            this.PnlSuperior.Controls.Add(this.DtpFechaCorte);
            this.PnlSuperior.Controls.Add(this.DtpFechaFin);
            this.PnlSuperior.Controls.Add(this.BtnCalcular);
            this.PnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlSuperior.Name = "PnlSuperior";
            this.PnlSuperior.Size = new System.Drawing.Size(1293, 26);
            this.PnlSuperior.TabIndex = 248;
            // 
            // BtnExportar
            // 
            this.BtnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportar.ForeColor = System.Drawing.Color.Black;
            this.BtnExportar.Location = new System.Drawing.Point(970, 4);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(87, 19);
            this.BtnExportar.TabIndex = 254;
            this.BtnExportar.Text = "Exportar Excel";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // TxtCuotaMax
            // 
            this.TxtCuotaMax.Location = new System.Drawing.Point(822, 5);
            this.TxtCuotaMax.Name = "TxtCuotaMax";
            this.TxtCuotaMax.Size = new System.Drawing.Size(26, 20);
            this.TxtCuotaMax.TabIndex = 253;
            this.TxtCuotaMax.Text = "5";
            this.TxtCuotaMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCuotaMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCuotaMax_KeyPress);
            this.TxtCuotaMax.Leave += new System.EventHandler(this.TxtCuotaMax_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(729, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Cuotas Max";
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Location = new System.Drawing.Point(1138, 4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(28, 19);
            this.BtnSalir.TabIndex = 8;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.button1_Salir_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(510, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo Cartera";
            // 
            // CmbTipoCartera
            // 
            this.CmbTipoCartera.FormattingEnabled = true;
            this.CmbTipoCartera.Items.AddRange(new object[] {
            "Administrativa",
            "Comercial",
            "Otros",
            "Todas"});
            this.CmbTipoCartera.Location = new System.Drawing.Point(602, 2);
            this.CmbTipoCartera.Name = "CmbTipoCartera";
            this.CmbTipoCartera.Size = new System.Drawing.Size(121, 21);
            this.CmbTipoCartera.Sorted = true;
            this.CmbTipoCartera.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(255, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Final Cuotas pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha Corte Recaudos";
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCalcular.Location = new System.Drawing.Point(879, 4);
            this.BtnCalcular.Name = "BtnCalcular";
            this.BtnCalcular.Size = new System.Drawing.Size(28, 19);
            this.BtnCalcular.TabIndex = 3;
            this.BtnCalcular.UseVisualStyleBackColor = true;
            this.BtnCalcular.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtMora
            // 
            this.TxtMora.Location = new System.Drawing.Point(174, 495);
            this.TxtMora.Name = "TxtMora";
            this.TxtMora.ReadOnly = true;
            this.TxtMora.Size = new System.Drawing.Size(100, 20);
            this.TxtMora.TabIndex = 250;
            this.TxtMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblMora
            // 
            this.LblMora.AutoSize = true;
            this.LblMora.Location = new System.Drawing.Point(37, 495);
            this.LblMora.Name = "LblMora";
            this.LblMora.Size = new System.Drawing.Size(58, 13);
            this.LblMora.TabIndex = 249;
            this.LblMora.Text = "Total Mora";
            // 
            // TxtTotalPrs
            // 
            this.TxtTotalPrs.Location = new System.Drawing.Point(173, 522);
            this.TxtTotalPrs.Name = "TxtTotalPrs";
            this.TxtTotalPrs.ReadOnly = true;
            this.TxtTotalPrs.Size = new System.Drawing.Size(100, 20);
            this.TxtTotalPrs.TabIndex = 252;
            this.TxtTotalPrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtTotalPrs.TextChanged += new System.EventHandler(this.TxtTotalPrs_TextChanged);
            // 
            // LblTotalPrs
            // 
            this.LblTotalPrs.AutoSize = true;
            this.LblTotalPrs.Location = new System.Drawing.Point(40, 522);
            this.LblTotalPrs.Name = "LblTotalPrs";
            this.LblTotalPrs.Size = new System.Drawing.Size(93, 13);
            this.LblTotalPrs.TabIndex = 251;
            this.LblTotalPrs.Text = "Total Presupuesto";
            // 
            // BtnMontar
            // 
            this.BtnMontar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnMontar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnMontar.Location = new System.Drawing.Point(184, 41);
            this.BtnMontar.Name = "BtnMontar";
            this.BtnMontar.Size = new System.Drawing.Size(75, 23);
            this.BtnMontar.TabIndex = 8;
            this.BtnMontar.Text = "Montar";
            this.BtnMontar.UseVisualStyleBackColor = true;
            this.BtnMontar.Visible = false;
            this.BtnMontar.Click += new System.EventHandler(this.BtnMontar_Click);
            // 
            // LblMontar
            // 
            this.LblMontar.AutoSize = true;
            this.LblMontar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMontar.Location = new System.Drawing.Point(36, 45);
            this.LblMontar.Name = "LblMontar";
            this.LblMontar.Size = new System.Drawing.Size(118, 15);
            this.LblMontar.TabIndex = 254;
            this.LblMontar.Text = "Montar Presupuesto";
            this.LblMontar.Visible = false;
            // 
            // TxtDias0
            // 
            this.TxtDias0.Location = new System.Drawing.Point(551, 446);
            this.TxtDias0.Name = "TxtDias0";
            this.TxtDias0.ReadOnly = true;
            this.TxtDias0.Size = new System.Drawing.Size(100, 20);
            this.TxtDias0.TabIndex = 256;
            this.TxtDias0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(445, 446);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 255;
            this.label5.Text = "De 1 a 30 Dias";
            // 
            // TxtDias30
            // 
            this.TxtDias30.Location = new System.Drawing.Point(776, 449);
            this.TxtDias30.Name = "TxtDias30";
            this.TxtDias30.ReadOnly = true;
            this.TxtDias30.Size = new System.Drawing.Size(100, 20);
            this.TxtDias30.TabIndex = 258;
            this.TxtDias30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(670, 450);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 257;
            this.label6.Text = "De 31 a 60 Dias";
            // 
            // TxtDias60
            // 
            this.TxtDias60.Location = new System.Drawing.Point(1018, 449);
            this.TxtDias60.Name = "TxtDias60";
            this.TxtDias60.ReadOnly = true;
            this.TxtDias60.Size = new System.Drawing.Size(100, 20);
            this.TxtDias60.TabIndex = 260;
            this.TxtDias60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(912, 451);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 259;
            this.label7.Text = "De 61 a 90 Dias";
            // 
            // TxtDias90
            // 
            this.TxtDias90.Location = new System.Drawing.Point(551, 488);
            this.TxtDias90.Name = "TxtDias90";
            this.TxtDias90.ReadOnly = true;
            this.TxtDias90.Size = new System.Drawing.Size(100, 20);
            this.TxtDias90.TabIndex = 262;
            this.TxtDias90.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(445, 491);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 261;
            this.label8.Text = "De 91 a 120 Dias";
            // 
            // TxtDias120
            // 
            this.TxtDias120.Location = new System.Drawing.Point(776, 492);
            this.TxtDias120.Name = "TxtDias120";
            this.TxtDias120.ReadOnly = true;
            this.TxtDias120.Size = new System.Drawing.Size(100, 20);
            this.TxtDias120.TabIndex = 264;
            this.TxtDias120.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(670, 496);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 13);
            this.label9.TabIndex = 263;
            this.label9.Text = "De 121 a 150 Dias";
            // 
            // TxtMas150
            // 
            this.TxtMas150.Location = new System.Drawing.Point(1018, 495);
            this.TxtMas150.Name = "TxtMas150";
            this.TxtMas150.ReadOnly = true;
            this.TxtMas150.Size = new System.Drawing.Size(100, 20);
            this.TxtMas150.TabIndex = 266;
            this.TxtMas150.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(912, 499);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 265;
            this.label10.Text = "Mas de 150";
            // 
            // FrmPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1293, 589);
            this.Controls.Add(this.TxtMas150);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtDias120);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtDias90);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtDias60);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.TxtDias30);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtDias0);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LblMontar);
            this.Controls.Add(this.BtnMontar);
            this.Controls.Add(this.TxtTotalPrs);
            this.Controls.Add(this.LblTotalPrs);
            this.Controls.Add(this.TxtMora);
            this.Controls.Add(this.LblMora);
            this.Controls.Add(this.PnlSuperior);
            this.Controls.Add(this.LblNumRegistro);
            this.Controls.Add(this.TxtTotalSaldo);
            this.Controls.Add(this.TxtRegistros);
            this.Controls.Add(this.LblTotalSaldo);
            this.Controls.Add(this.DgvPresupuesto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPresupuesto";
            this.Text = "Presupuesto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPresupuesto)).EndInit();
            this.PnlSuperior.ResumeLayout(false);
            this.PnlSuperior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtpFechaCorte;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.DataGridView DgvPresupuesto;
        private System.Windows.Forms.Button BtnCalcular;
        private System.Windows.Forms.Label LblNumRegistro;
        private System.Windows.Forms.TextBox TxtTotalSaldo;
        private System.Windows.Forms.TextBox TxtRegistros;
        private System.Windows.Forms.Label LblTotalSaldo;
        private System.Windows.Forms.Panel PnlSuperior;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbTipoCartera;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.TextBox TxtMora;
        private System.Windows.Forms.Label LblMora;
        private System.Windows.Forms.TextBox TxtTotalPrs;
        private System.Windows.Forms.Label LblTotalPrs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtCuotaMax;
        private System.Windows.Forms.Button BtnMontar;
        private System.Windows.Forms.Label LblMontar;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.TextBox TxtDias0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtDias30;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtDias60;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtDias90;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtDias120;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtMas150;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Clip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adjudicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capital;
        private System.Windows.Forms.DataGridViewTextBoxColumn Interes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cuota;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasCpt;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diaslqd;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mora;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCartera;
    }
}