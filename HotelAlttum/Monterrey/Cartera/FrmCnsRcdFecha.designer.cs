namespace CarteraGeneral
{
    partial class FrmCnsRcdFecha
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCnsRcdFecha));
            this.PnlSuperior = new System.Windows.Forms.Panel();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbTipoCartera = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaCorte = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnCalcular = new System.Windows.Forms.Button();
            this.DgvConslta = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoOperacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TxtTotal = new System.Windows.Forms.TextBox();
            this.TxtAprobados = new System.Windows.Forms.TextBox();
            this.TxtCtaTotal = new System.Windows.Forms.TextBox();
            this.LblTotalSaldo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtCtaAprobado = new System.Windows.Forms.TextBox();
            this.TxtDevueltos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCtaDev = new System.Windows.Forms.TextBox();
            this.TxtCtaPdte = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtPendientes = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printingSystem1 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.printingSystem2 = new DevExpress.XtraPrinting.PrintingSystem(this.components);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.PnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConslta)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlSuperior
            // 
            this.PnlSuperior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PnlSuperior.Controls.Add(this.BtnExportar);
            this.PnlSuperior.Controls.Add(this.BtnSalir);
            this.PnlSuperior.Controls.Add(this.label3);
            this.PnlSuperior.Controls.Add(this.CmbTipoCartera);
            this.PnlSuperior.Controls.Add(this.label2);
            this.PnlSuperior.Controls.Add(this.label1);
            this.PnlSuperior.Controls.Add(this.DtpFechaCorte);
            this.PnlSuperior.Controls.Add(this.DtpFechaFin);
            this.PnlSuperior.Controls.Add(this.pictureBox1);
            this.PnlSuperior.Controls.Add(this.BtnCalcular);
            this.PnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlSuperior.Name = "PnlSuperior";
            this.PnlSuperior.Size = new System.Drawing.Size(1362, 31);
            this.PnlSuperior.TabIndex = 251;
            // 
            // BtnExportar
            // 
            this.BtnExportar.BackColor = System.Drawing.Color.White;
            this.BtnExportar.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297290_Excel;
            this.BtnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnExportar.Location = new System.Drawing.Point(879, 5);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(20, 20);
            this.BtnExportar.TabIndex = 9;
            this.BtnExportar.UseVisualStyleBackColor = false;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.Color.White;
            this.BtnSalir.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Location = new System.Drawing.Point(921, 5);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(20, 20);
            this.BtnSalir.TabIndex = 8;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(576, 8);
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
            "Anulados",
            "Contado",
            "Cuota Inicial",
            "Extraordinaria",
            "Financiacion",
            "Todos"});
            this.CmbTipoCartera.Location = new System.Drawing.Point(675, 3);
            this.CmbTipoCartera.Name = "CmbTipoCartera";
            this.CmbTipoCartera.Size = new System.Drawing.Size(140, 23);
            this.CmbTipoCartera.Sorted = true;
            this.CmbTipoCartera.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(362, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(139, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha Inicial";
            // 
            // DtpFechaCorte
            // 
            this.DtpFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaCorte.Location = new System.Drawing.Point(241, 4);
            this.DtpFechaCorte.Name = "DtpFechaCorte";
            this.DtpFechaCorte.Size = new System.Drawing.Size(99, 21);
            this.DtpFechaCorte.TabIndex = 0;
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(457, 4);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(97, 21);
            this.DtpFechaFin.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 258;
            this.pictureBox1.TabStop = false;
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.BackColor = System.Drawing.Color.White;
            this.BtnCalcular.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCalcular.ForeColor = System.Drawing.Color.Black;
            this.BtnCalcular.Location = new System.Drawing.Point(837, 5);
            this.BtnCalcular.Name = "BtnCalcular";
            this.BtnCalcular.Size = new System.Drawing.Size(20, 20);
            this.BtnCalcular.TabIndex = 3;
            this.BtnCalcular.UseVisualStyleBackColor = false;
            this.BtnCalcular.Click += new System.EventHandler(this.BtnCalcular_Click);
            // 
            // DgvConslta
            // 
            this.DgvConslta.AllowUserToAddRows = false;
            this.DgvConslta.AllowUserToDeleteRows = false;
            this.DgvConslta.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvConslta.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvConslta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvConslta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.FormaPago,
            this.Column7,
            this.TipoOperacion});
            this.DgvConslta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvConslta.Location = new System.Drawing.Point(0, 0);
            this.DgvConslta.Name = "DgvConslta";
            this.DgvConslta.Size = new System.Drawing.Size(1362, 602);
            this.DgvConslta.TabIndex = 252;
            this.DgvConslta.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Adjudicacion";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Cliente";
            this.Column2.Name = "Column2";
            this.Column2.Width = 350;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Recibo";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column4.HeaderText = "Fecha";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Operacion";
            this.Column5.Name = "Column5";
            this.Column5.Width = 170;
            // 
            // Column6
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column6.HeaderText = "Total";
            this.Column6.Name = "Column6";
            this.Column6.Width = 120;
            // 
            // FormaPago
            // 
            this.FormaPago.HeaderText = "FormaPago";
            this.FormaPago.Name = "FormaPago";
            this.FormaPago.Width = 150;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Estado";
            this.Column7.Name = "Column7";
            this.Column7.Width = 170;
            // 
            // TipoOperacion
            // 
            this.TipoOperacion.HeaderText = "TipoOperacion";
            this.TipoOperacion.Name = "TipoOperacion";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1362, 675);
            this.panel1.TabIndex = 267;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            this.splitContainer1.Panel1.Controls.Add(this.DgvConslta);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TxtTotal);
            this.splitContainer1.Panel2.Controls.Add(this.TxtAprobados);
            this.splitContainer1.Panel2.Controls.Add(this.TxtCtaTotal);
            this.splitContainer1.Panel2.Controls.Add(this.LblTotalSaldo);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.TxtCtaAprobado);
            this.splitContainer1.Panel2.Controls.Add(this.TxtDevueltos);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.TxtCtaDev);
            this.splitContainer1.Panel2.Controls.Add(this.TxtCtaPdte);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.TxtPendientes);
            this.splitContainer1.Size = new System.Drawing.Size(1362, 675);
            this.splitContainer1.SplitterDistance = 602;
            this.splitContainer1.TabIndex = 253;
            // 
            // TxtTotal
            // 
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(865, 14);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.ReadOnly = true;
            this.TxtTotal.Size = new System.Drawing.Size(116, 22);
            this.TxtTotal.TabIndex = 298;
            this.TxtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtAprobados
            // 
            this.TxtAprobados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAprobados.Location = new System.Drawing.Point(129, 14);
            this.TxtAprobados.Name = "TxtAprobados";
            this.TxtAprobados.ReadOnly = true;
            this.TxtAprobados.Size = new System.Drawing.Size(116, 22);
            this.TxtAprobados.TabIndex = 289;
            this.TxtAprobados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtCtaTotal
            // 
            this.TxtCtaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCtaTotal.Location = new System.Drawing.Point(834, 14);
            this.TxtCtaTotal.Name = "TxtCtaTotal";
            this.TxtCtaTotal.ReadOnly = true;
            this.TxtCtaTotal.Size = new System.Drawing.Size(25, 22);
            this.TxtCtaTotal.TabIndex = 297;
            this.TxtCtaTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblTotalSaldo
            // 
            this.LblTotalSaldo.AutoSize = true;
            this.LblTotalSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTotalSaldo.Location = new System.Drawing.Point(10, 14);
            this.LblTotalSaldo.Name = "LblTotalSaldo";
            this.LblTotalSaldo.Size = new System.Drawing.Size(66, 15);
            this.LblTotalSaldo.TabIndex = 287;
            this.LblTotalSaldo.Text = "Aprobados";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(756, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 296;
            this.label4.Text = "Total";
            // 
            // TxtCtaAprobado
            // 
            this.TxtCtaAprobado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCtaAprobado.Location = new System.Drawing.Point(98, 14);
            this.TxtCtaAprobado.Name = "TxtCtaAprobado";
            this.TxtCtaAprobado.ReadOnly = true;
            this.TxtCtaAprobado.Size = new System.Drawing.Size(24, 22);
            this.TxtCtaAprobado.TabIndex = 288;
            this.TxtCtaAprobado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtDevueltos
            // 
            this.TxtDevueltos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDevueltos.Location = new System.Drawing.Point(616, 14);
            this.TxtDevueltos.Name = "TxtDevueltos";
            this.TxtDevueltos.ReadOnly = true;
            this.TxtDevueltos.Size = new System.Drawing.Size(116, 22);
            this.TxtDevueltos.TabIndex = 295;
            this.TxtDevueltos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(262, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 290;
            this.label5.Text = "Pendientes";
            // 
            // TxtCtaDev
            // 
            this.TxtCtaDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCtaDev.Location = new System.Drawing.Point(585, 14);
            this.TxtCtaDev.Name = "TxtCtaDev";
            this.TxtCtaDev.ReadOnly = true;
            this.TxtCtaDev.Size = new System.Drawing.Size(25, 22);
            this.TxtCtaDev.TabIndex = 294;
            this.TxtCtaDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtCtaPdte
            // 
            this.TxtCtaPdte.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCtaPdte.Location = new System.Drawing.Point(344, 14);
            this.TxtCtaPdte.Name = "TxtCtaPdte";
            this.TxtCtaPdte.ReadOnly = true;
            this.TxtCtaPdte.Size = new System.Drawing.Size(25, 22);
            this.TxtCtaPdte.TabIndex = 291;
            this.TxtCtaPdte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(507, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 293;
            this.label7.Text = "Devueltos";
            // 
            // TxtPendientes
            // 
            this.TxtPendientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPendientes.Location = new System.Drawing.Point(385, 14);
            this.TxtPendientes.Name = "TxtPendientes";
            this.TxtPendientes.ReadOnly = true;
            this.TxtPendientes.Size = new System.Drawing.Size(116, 22);
            this.TxtPendientes.TabIndex = 292;
            this.TxtPendientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 684);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1362, 22);
            this.statusStrip1.TabIndex = 268;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1362, 602);
            this.gridControl1.TabIndex = 253;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // FrmCnsRcdFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 706);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnlSuperior);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCnsRcdFecha";
            this.Text = "RECAUDOS POR FECHA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCnsRcdFecha_Load);
            this.PnlSuperior.ResumeLayout(false);
            this.PnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvConslta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printingSystem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PnlSuperior;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbTipoCartera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaCorte;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Button BtnCalcular;
        public System.Windows.Forms.DataGridView DgvConslta;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox TxtTotal;
        private System.Windows.Forms.TextBox TxtCtaTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDevueltos;
        private System.Windows.Forms.TextBox TxtCtaDev;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtPendientes;
        private System.Windows.Forms.TextBox TxtCtaPdte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtAprobados;
        private System.Windows.Forms.TextBox TxtCtaAprobado;
        private System.Windows.Forms.Label LblTotalSaldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoOperacion;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem1;
        private DevExpress.XtraPrinting.PrintingSystem printingSystem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}