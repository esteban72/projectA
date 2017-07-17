namespace CarteraGeneral
{
    partial class FrmModificarRecaudos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificarRecaudos));
            this.label19 = new System.Windows.Forms.Label();
            this.PnlEncbezado = new System.Windows.Forms.Panel();
            this.TxtInmueble = new System.Windows.Forms.Label();
            this.TxtNombre1 = new System.Windows.Forms.Label();
            this.LblNombre1 = new System.Windows.Forms.Label();
            this.PmlPago = new System.Windows.Forms.Panel();
            this.TxtValor = new System.Windows.Forms.Label();
            this.TxtCodBanco = new System.Windows.Forms.Label();
            this.TxtOperacion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblOperacion = new System.Windows.Forms.Label();
            this.LblValor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DgvDatosRecaudos = new System.Windows.Forms.DataGridView();
            this.IdRecaudo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumRecibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtidRecaudo = new System.Windows.Forms.TextBox();
            this.lblIdRecibo = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.LblAdjudicacion = new System.Windows.Forms.Label();
            this.TxtRecibo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.CmbFormaPago = new System.Windows.Forms.ComboBox();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TxtAdjudicacion = new System.Windows.Forms.Label();
            this.PnlEncbezado.SuspendLayout();
            this.PmlPago.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatosRecaudos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(301, 9);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 13);
            this.label19.TabIndex = 155;
            this.label19.Text = "Inmueble:";
            // 
            // PnlEncbezado
            // 
            this.PnlEncbezado.BackColor = System.Drawing.SystemColors.Control;
            this.PnlEncbezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlEncbezado.Controls.Add(this.TxtInmueble);
            this.PnlEncbezado.Controls.Add(this.TxtNombre1);
            this.PnlEncbezado.Controls.Add(this.label19);
            this.PnlEncbezado.Controls.Add(this.LblNombre1);
            this.PnlEncbezado.Location = new System.Drawing.Point(14, 60);
            this.PnlEncbezado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PnlEncbezado.Name = "PnlEncbezado";
            this.PnlEncbezado.Size = new System.Drawing.Size(730, 31);
            this.PnlEncbezado.TabIndex = 191;
            // 
            // TxtInmueble
            // 
            this.TxtInmueble.AutoSize = true;
            this.TxtInmueble.Location = new System.Drawing.Point(369, 9);
            this.TxtInmueble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtInmueble.Name = "TxtInmueble";
            this.TxtInmueble.Size = new System.Drawing.Size(50, 13);
            this.TxtInmueble.TabIndex = 172;
            this.TxtInmueble.Text = "Inmueble";
            // 
            // TxtNombre1
            // 
            this.TxtNombre1.AutoSize = true;
            this.TxtNombre1.Location = new System.Drawing.Point(69, 9);
            this.TxtNombre1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtNombre1.Name = "TxtNombre1";
            this.TxtNombre1.Size = new System.Drawing.Size(42, 13);
            this.TxtNombre1.TabIndex = 171;
            this.TxtNombre1.Text = "Titular1";
            // 
            // LblNombre1
            // 
            this.LblNombre1.AutoSize = true;
            this.LblNombre1.Location = new System.Drawing.Point(4, 9);
            this.LblNombre1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNombre1.Name = "LblNombre1";
            this.LblNombre1.Size = new System.Drawing.Size(45, 13);
            this.LblNombre1.TabIndex = 148;
            this.LblNombre1.Text = "Titular1:";
            // 
            // PmlPago
            // 
            this.PmlPago.BackColor = System.Drawing.SystemColors.Control;
            this.PmlPago.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PmlPago.Controls.Add(this.TxtValor);
            this.PmlPago.Controls.Add(this.TxtCodBanco);
            this.PmlPago.Controls.Add(this.TxtOperacion);
            this.PmlPago.Controls.Add(this.label1);
            this.PmlPago.Controls.Add(this.LblOperacion);
            this.PmlPago.Controls.Add(this.LblValor);
            this.PmlPago.Location = new System.Drawing.Point(270, 12);
            this.PmlPago.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PmlPago.Name = "PmlPago";
            this.PmlPago.Size = new System.Drawing.Size(374, 228);
            this.PmlPago.TabIndex = 2;
            // 
            // TxtValor
            // 
            this.TxtValor.AutoSize = true;
            this.TxtValor.Location = new System.Drawing.Point(118, 119);
            this.TxtValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(13, 13);
            this.TxtValor.TabIndex = 166;
            this.TxtValor.Text = "0";
            // 
            // TxtCodBanco
            // 
            this.TxtCodBanco.AutoSize = true;
            this.TxtCodBanco.Location = new System.Drawing.Point(118, 72);
            this.TxtCodBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtCodBanco.Name = "TxtCodBanco";
            this.TxtCodBanco.Size = new System.Drawing.Size(0, 13);
            this.TxtCodBanco.TabIndex = 165;
            // 
            // TxtOperacion
            // 
            this.TxtOperacion.AutoSize = true;
            this.TxtOperacion.Location = new System.Drawing.Point(118, 27);
            this.TxtOperacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtOperacion.Name = "TxtOperacion";
            this.TxtOperacion.Size = new System.Drawing.Size(56, 13);
            this.TxtOperacion.TabIndex = 164;
            this.TxtOperacion.Text = "Operacion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 163;
            this.label1.Text = "Codigo Banco";
            // 
            // LblOperacion
            // 
            this.LblOperacion.AutoSize = true;
            this.LblOperacion.Location = new System.Drawing.Point(21, 27);
            this.LblOperacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblOperacion.Name = "LblOperacion";
            this.LblOperacion.Size = new System.Drawing.Size(56, 13);
            this.LblOperacion.TabIndex = 161;
            this.LblOperacion.Text = "Operacion";
            // 
            // LblValor
            // 
            this.LblValor.AutoSize = true;
            this.LblValor.Location = new System.Drawing.Point(20, 119);
            this.LblValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblValor.Name = "LblValor";
            this.LblValor.Size = new System.Drawing.Size(31, 13);
            this.LblValor.TabIndex = 157;
            this.LblValor.Text = "Valor";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.YellowGreen;
            this.panel2.Controls.Add(this.DgvDatosRecaudos);
            this.panel2.Location = new System.Drawing.Point(13, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(731, 139);
            this.panel2.TabIndex = 195;
            // 
            // DgvDatosRecaudos
            // 
            this.DgvDatosRecaudos.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvDatosRecaudos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvDatosRecaudos.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvDatosRecaudos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvDatosRecaudos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvDatosRecaudos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdRecaudo,
            this.Transaccion,
            this.NumRecibo,
            this.Fecha,
            this.Operaciones,
            this.Total});
            this.DgvDatosRecaudos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDatosRecaudos.Location = new System.Drawing.Point(0, 0);
            this.DgvDatosRecaudos.Name = "DgvDatosRecaudos";
            this.DgvDatosRecaudos.ReadOnly = true;
            this.DgvDatosRecaudos.Size = new System.Drawing.Size(731, 139);
            this.DgvDatosRecaudos.TabIndex = 0;
            this.DgvDatosRecaudos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatosRecaudos_CellEnter);
            // 
            // IdRecaudo
            // 
            this.IdRecaudo.HeaderText = "IdRecaudo";
            this.IdRecaudo.Name = "IdRecaudo";
            this.IdRecaudo.ReadOnly = true;
            // 
            // Transaccion
            // 
            this.Transaccion.HeaderText = "Trans";
            this.Transaccion.Name = "Transaccion";
            this.Transaccion.ReadOnly = true;
            // 
            // NumRecibo
            // 
            this.NumRecibo.HeaderText = "Num Recibo";
            this.NumRecibo.Name = "NumRecibo";
            this.NumRecibo.ReadOnly = true;
            // 
            // Fecha
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Operaciones
            // 
            this.Operaciones.HeaderText = "Operacion";
            this.Operaciones.Name = "Operaciones";
            this.Operaciones.ReadOnly = true;
            this.Operaciones.Width = 160;
            // 
            // Total
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle4;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 120;
            // 
            // TxtidRecaudo
            // 
            this.TxtidRecaudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtidRecaudo.Location = new System.Drawing.Point(98, 7);
            this.TxtidRecaudo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtidRecaudo.Name = "TxtidRecaudo";
            this.TxtidRecaudo.ReadOnly = true;
            this.TxtidRecaudo.Size = new System.Drawing.Size(97, 20);
            this.TxtidRecaudo.TabIndex = 1;
            // 
            // lblIdRecibo
            // 
            this.lblIdRecibo.AutoSize = true;
            this.lblIdRecibo.BackColor = System.Drawing.Color.Transparent;
            this.lblIdRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdRecibo.ForeColor = System.Drawing.Color.Black;
            this.lblIdRecibo.Location = new System.Drawing.Point(10, 14);
            this.lblIdRecibo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdRecibo.Name = "lblIdRecibo";
            this.lblIdRecibo.Size = new System.Drawing.Size(60, 13);
            this.lblIdRecibo.TabIndex = 181;
            this.lblIdRecibo.Text = "IdRecaudo";
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblTitulo.Location = new System.Drawing.Point(269, 5);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(241, 24);
            this.LblTitulo.TabIndex = 194;
            this.LblTitulo.Text = "MODIFICAR RECAUDOS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 151;
            this.label5.Text = "Fecha";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(101, 52);
            this.DtpFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(94, 20);
            this.DtpFecha.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Recibo Caja";
            // 
            // LblAdjudicacion
            // 
            this.LblAdjudicacion.AutoSize = true;
            this.LblAdjudicacion.BackColor = System.Drawing.Color.Transparent;
            this.LblAdjudicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAdjudicacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblAdjudicacion.Location = new System.Drawing.Point(563, 8);
            this.LblAdjudicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblAdjudicacion.Name = "LblAdjudicacion";
            this.LblAdjudicacion.Size = new System.Drawing.Size(103, 18);
            this.LblAdjudicacion.TabIndex = 190;
            this.LblAdjudicacion.Text = "Adjudicacion";
            // 
            // TxtRecibo
            // 
            this.TxtRecibo.AcceptsReturn = true;
            this.TxtRecibo.Location = new System.Drawing.Point(101, 133);
            this.TxtRecibo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtRecibo.Name = "TxtRecibo";
            this.TxtRecibo.Size = new System.Drawing.Size(66, 20);
            this.TxtRecibo.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.PmlPago);
            this.panel1.Location = new System.Drawing.Point(14, 256);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(730, 260);
            this.panel1.TabIndex = 192;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.BtnSalir);
            this.panel3.Controls.Add(this.BtnNuevo);
            this.panel3.Controls.Add(this.CmbFormaPago);
            this.panel3.Controls.Add(this.BtnAceptar);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.DtpFecha);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.TxtRecibo);
            this.panel3.Controls.Add(this.lblIdRecibo);
            this.panel3.Controls.Add(this.TxtidRecaudo);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(13, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 228);
            this.panel3.TabIndex = 208;
            // 
            // BtnSalir
            // 
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Location = new System.Drawing.Point(146, 191);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 184;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnNuevo.Location = new System.Drawing.Point(13, 191);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(57, 23);
            this.BtnNuevo.TabIndex = 185;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Visible = false;
            // 
            // CmbFormaPago
            // 
            this.CmbFormaPago.FormattingEnabled = true;
            this.CmbFormaPago.Items.AddRange(new object[] {
            "Cdt",
            "Cheque",
            "ChequeGerencia",
            "Efectivo",
            "TarjetaCredito",
            "TarjetaDebito",
            "Transferencia"});
            this.CmbFormaPago.Location = new System.Drawing.Point(101, 92);
            this.CmbFormaPago.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CmbFormaPago.Name = "CmbFormaPago";
            this.CmbFormaPago.Size = new System.Drawing.Size(116, 21);
            this.CmbFormaPago.Sorted = true;
            this.CmbFormaPago.TabIndex = 3;
            this.CmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.CmbFormaPago_SelectedIndexChanged);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAceptar.Location = new System.Drawing.Point(76, 191);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(64, 23);
            this.BtnAceptar.TabIndex = 183;
            this.BtnAceptar.Text = "Modificar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 95);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 207;
            this.label7.Text = "Forma de Pago";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 226;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.TxtAdjudicacion);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.LblTitulo);
            this.panel4.Controls.Add(this.LblAdjudicacion);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(778, 35);
            this.panel4.TabIndex = 227;
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.AutoSize = true;
            this.TxtAdjudicacion.BackColor = System.Drawing.Color.Transparent;
            this.TxtAdjudicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAdjudicacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtAdjudicacion.Location = new System.Drawing.Point(684, 8);
            this.TxtAdjudicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.Size = new System.Drawing.Size(17, 18);
            this.TxtAdjudicacion.TabIndex = 195;
            this.TxtAdjudicacion.Text = "0";
            // 
            // FrmModificarRecaudos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(778, 521);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.PnlEncbezado);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmModificarRecaudos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmModRecaudos";
            this.Load += new System.EventHandler(this.FrmModRecaudos_Load);
            this.PnlEncbezado.ResumeLayout(false);
            this.PnlEncbezado.PerformLayout();
            this.PmlPago.ResumeLayout(false);
            this.PmlPago.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatosRecaudos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel PnlEncbezado;
        private System.Windows.Forms.Label LblNombre1;
        private System.Windows.Forms.Panel PmlPago;
        private System.Windows.Forms.Label LblValor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgvDatosRecaudos;
        private System.Windows.Forms.TextBox TxtidRecaudo;
        private System.Windows.Forms.Label lblIdRecibo;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblAdjudicacion;
        private System.Windows.Forms.TextBox TxtRecibo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.ComboBox CmbFormaPago;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblOperacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TxtInmueble;
        private System.Windows.Forms.Label TxtNombre1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label TxtAdjudicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdRecaudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumRecibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Label TxtValor;
        private System.Windows.Forms.Label TxtCodBanco;
        private System.Windows.Forms.Label TxtOperacion;
    }
}