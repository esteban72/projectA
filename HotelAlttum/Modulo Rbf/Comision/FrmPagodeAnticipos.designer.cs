namespace CarteraGeneral
{
    partial class FrmPagodeAnticipos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPagodeAnticipos));
            this.label3 = new System.Windows.Forms.Label();
            this.LblCliente = new System.Windows.Forms.Label();
            this.BtnPagar = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.IdComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdGestor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anticipo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anticipo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagoAnticipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo_Anticipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnticipoaPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.LblInmueble = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LblRecaudo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblVrPorcentaje = new System.Windows.Forms.Label();
            this.LblBase = new System.Windows.Forms.Label();
            this.LblVrBase = new System.Windows.Forms.Label();
            this.lblVenta = new System.Windows.Forms.Label();
            this.LblVrVenta = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.TxtAdjudicacion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LblTotal = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(431, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 142;
            this.label3.Text = "Cliente";
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCliente.Location = new System.Drawing.Point(497, 15);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(0, 16);
            this.LblCliente.TabIndex = 141;
            // 
            // BtnPagar
            // 
            this.BtnPagar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPagar.Location = new System.Drawing.Point(24, 74);
            this.BtnPagar.Name = "BtnPagar";
            this.BtnPagar.Size = new System.Drawing.Size(75, 23);
            this.BtnPagar.TabIndex = 139;
            this.BtnPagar.Text = "Pagar";
            this.BtnPagar.UseVisualStyleBackColor = true;
            this.BtnPagar.Visible = false;
            this.BtnPagar.Click += new System.EventHandler(this.BtnPagar_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.Black;
            this.LblTitulo.Location = new System.Drawing.Point(506, 3);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(255, 29);
            this.LblTitulo.TabIndex = 137;
            this.LblTitulo.Text = "PAGO DE ANTICIPOS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 136;
            this.label1.Text = "Adjudicacion";
            // 
            // BtnSalir
            // 
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(154, 74);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 134;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvListado.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdComision,
            this.IdGestor,
            this.Nombre,
            this.IdCargo,
            this.NombreCargo,
            this.Anticipo1,
            this.Anticipo2,
            this.PagoAnticipo,
            this.Saldo_Anticipo,
            this.AnticipoaPagar});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListado.DefaultCellStyle = dataGridViewCellStyle9;
            this.DgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvListado.Location = new System.Drawing.Point(0, 0);
            this.DgvListado.Name = "DgvListado";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvListado.Size = new System.Drawing.Size(1291, 325);
            this.DgvListado.TabIndex = 0;
            this.DgvListado.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellValidated);
            this.DgvListado.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvListado_EditingControlShowing);
            this.DgvListado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DgvListado_KeyPress);
            // 
            // IdComision
            // 
            this.IdComision.HeaderText = "IdComision";
            this.IdComision.Name = "IdComision";
            this.IdComision.ReadOnly = true;
            // 
            // IdGestor
            // 
            this.IdGestor.HeaderText = "IdGestor";
            this.IdGestor.Name = "IdGestor";
            this.IdGestor.ReadOnly = true;
            this.IdGestor.Width = 110;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 220;
            // 
            // IdCargo
            // 
            this.IdCargo.HeaderText = "IdCargo";
            this.IdCargo.Name = "IdCargo";
            this.IdCargo.ReadOnly = true;
            this.IdCargo.Width = 80;
            // 
            // NombreCargo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.NombreCargo.DefaultCellStyle = dataGridViewCellStyle3;
            this.NombreCargo.HeaderText = "Nombre Cargo";
            this.NombreCargo.Name = "NombreCargo";
            this.NombreCargo.ReadOnly = true;
            this.NombreCargo.Width = 200;
            // 
            // Anticipo1
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.Anticipo1.DefaultCellStyle = dataGridViewCellStyle4;
            this.Anticipo1.HeaderText = "Anticipo1";
            this.Anticipo1.Name = "Anticipo1";
            this.Anticipo1.ReadOnly = true;
            // 
            // Anticipo2
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.Anticipo2.DefaultCellStyle = dataGridViewCellStyle5;
            this.Anticipo2.HeaderText = "Anticipo2";
            this.Anticipo2.Name = "Anticipo2";
            this.Anticipo2.ReadOnly = true;
            // 
            // PagoAnticipo
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.PagoAnticipo.DefaultCellStyle = dataGridViewCellStyle6;
            this.PagoAnticipo.HeaderText = "PagoAnticipo";
            this.PagoAnticipo.Name = "PagoAnticipo";
            this.PagoAnticipo.ReadOnly = true;
            // 
            // Saldo_Anticipo
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Saldo_Anticipo.DefaultCellStyle = dataGridViewCellStyle7;
            this.Saldo_Anticipo.HeaderText = "Saldo Anticipo";
            this.Saldo_Anticipo.Name = "Saldo_Anticipo";
            this.Saldo_Anticipo.ReadOnly = true;
            // 
            // AnticipoaPagar
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.AnticipoaPagar.DefaultCellStyle = dataGridViewCellStyle8;
            this.AnticipoaPagar.HeaderText = "Valor a Pagar";
            this.AnticipoaPagar.Name = "AnticipoaPagar";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.LblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1291, 34);
            this.panel2.TabIndex = 230;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.LblInmueble);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.LblRecaudo);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.LblVrPorcentaje);
            this.panel3.Controls.Add(this.BtnSalir);
            this.panel3.Controls.Add(this.LblBase);
            this.panel3.Controls.Add(this.BtnPagar);
            this.panel3.Controls.Add(this.LblVrBase);
            this.panel3.Controls.Add(this.lblVenta);
            this.panel3.Controls.Add(this.LblVrVenta);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.DtpFecha);
            this.panel3.Controls.Add(this.TxtAdjudicacion);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.LblTotal);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.LblCliente);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 34);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1291, 103);
            this.panel3.TabIndex = 231;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(865, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 16);
            this.label7.TabIndex = 157;
            this.label7.Text = "Inmueble";
            // 
            // LblInmueble
            // 
            this.LblInmueble.AutoSize = true;
            this.LblInmueble.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInmueble.Location = new System.Drawing.Point(931, 12);
            this.LblInmueble.Name = "LblInmueble";
            this.LblInmueble.Size = new System.Drawing.Size(15, 16);
            this.LblInmueble.TabIndex = 156;
            this.LblInmueble.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1082, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 155;
            this.label6.Text = "Recaudo";
            // 
            // LblRecaudo
            // 
            this.LblRecaudo.AutoSize = true;
            this.LblRecaudo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRecaudo.Location = new System.Drawing.Point(1165, 41);
            this.LblRecaudo.Name = "LblRecaudo";
            this.LblRecaudo.Size = new System.Drawing.Size(15, 16);
            this.LblRecaudo.TabIndex = 154;
            this.LblRecaudo.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(282, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 16);
            this.label5.TabIndex = 153;
            this.label5.Text = "Porcentaje";
            // 
            // LblVrPorcentaje
            // 
            this.LblVrPorcentaje.AutoSize = true;
            this.LblVrPorcentaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVrPorcentaje.Location = new System.Drawing.Point(405, 41);
            this.LblVrPorcentaje.Name = "LblVrPorcentaje";
            this.LblVrPorcentaje.Size = new System.Drawing.Size(15, 16);
            this.LblVrPorcentaje.TabIndex = 152;
            this.LblVrPorcentaje.Text = "0";
            // 
            // LblBase
            // 
            this.LblBase.AutoSize = true;
            this.LblBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBase.Location = new System.Drawing.Point(21, 41);
            this.LblBase.Name = "LblBase";
            this.LblBase.Size = new System.Drawing.Size(40, 16);
            this.LblBase.TabIndex = 151;
            this.LblBase.Text = "Base";
            // 
            // LblVrBase
            // 
            this.LblVrBase.AutoSize = true;
            this.LblVrBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVrBase.Location = new System.Drawing.Point(144, 41);
            this.LblVrBase.Name = "LblVrBase";
            this.LblVrBase.Size = new System.Drawing.Size(15, 16);
            this.LblVrBase.TabIndex = 150;
            this.LblVrBase.Text = "0";
            // 
            // lblVenta
            // 
            this.lblVenta.AutoSize = true;
            this.lblVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVenta.Location = new System.Drawing.Point(865, 41);
            this.lblVenta.Name = "lblVenta";
            this.lblVenta.Size = new System.Drawing.Size(43, 16);
            this.lblVenta.TabIndex = 149;
            this.lblVenta.Text = "Venta";
            // 
            // LblVrVenta
            // 
            this.LblVrVenta.AutoSize = true;
            this.LblVrVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblVrVenta.Location = new System.Drawing.Point(931, 41);
            this.LblVrVenta.Name = "LblVrVenta";
            this.LblVrVenta.Size = new System.Drawing.Size(15, 16);
            this.LblVrVenta.TabIndex = 148;
            this.LblVrVenta.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 16);
            this.label4.TabIndex = 147;
            this.label4.Text = "Fecha Pago";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(105, 8);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(101, 20);
            this.DtpFecha.TabIndex = 146;
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.FormattingEnabled = true;
            this.TxtAdjudicacion.Location = new System.Drawing.Point(325, 10);
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.Size = new System.Drawing.Size(76, 21);
            this.TxtAdjudicacion.TabIndex = 145;
            this.TxtAdjudicacion.SelectedIndexChanged += new System.EventHandler(this.TxtAdjudicacion_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(491, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 144;
            this.label2.Text = "Total";
            // 
            // LblTotal
            // 
            this.LblTotal.AutoSize = true;
            this.LblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotal.Location = new System.Drawing.Point(640, 41);
            this.LblTotal.Name = "LblTotal";
            this.LblTotal.Size = new System.Drawing.Size(15, 16);
            this.LblTotal.TabIndex = 143;
            this.LblTotal.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DgvListado);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 137);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1291, 325);
            this.panel1.TabIndex = 232;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1291, 22);
            this.statusStrip1.TabIndex = 233;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(7, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 229;
            this.pictureBox1.TabStop = false;
            // 
            // FrmPagodeAnticipos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1291, 462);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPagodeAnticipos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos de Anticipos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPagos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.Button BtnPagar;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblTotal;
        private System.Windows.Forms.ComboBox TxtAdjudicacion;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblVenta;
        private System.Windows.Forms.Label LblVrVenta;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblVrPorcentaje;
        private System.Windows.Forms.Label LblBase;
        private System.Windows.Forms.Label LblVrBase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label LblRecaudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGestor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anticipo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anticipo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagoAnticipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo_Anticipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnticipoaPagar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label LblInmueble;
    }
}