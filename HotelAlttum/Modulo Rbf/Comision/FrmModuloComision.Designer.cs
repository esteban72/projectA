namespace CarteraGeneral
{
    partial class FrmModuloComision
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmAddComision = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmModificarCms = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TxtAdjudicacion = new System.Windows.Forms.TextBox();
            this.TxtUnidad = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtVilla = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtTipo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtTemporada = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtSemana = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtInmueble = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtClinte = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.BtnAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnMod = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnExportar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.BtnSalir = new System.Windows.Forms.ToolStripButton();
            this.IdTercero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DgvListado
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvListado.BackgroundColor = System.Drawing.Color.White;
            this.DgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTercero,
            this.Nombre,
            this.IdCargo,
            this.NombreCargo,
            this.Comision1,
            this.Comision2,
            this.Comision3});
            this.DgvListado.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListado.DefaultCellStyle = dataGridViewCellStyle6;
            this.DgvListado.GridColor = System.Drawing.Color.Black;
            this.DgvListado.Location = new System.Drawing.Point(13, 171);
            this.DgvListado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.ReadOnly = true;
            this.DgvListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DgvListado.Size = new System.Drawing.Size(1006, 399);
            this.DgvListado.TabIndex = 275;
            this.DgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellDoubleClick);
            this.DgvListado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellEnter);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmAddComision,
            this.TsmModificarCms,
            this.TsmExportar});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 70);
            // 
            // TsmAddComision
            // 
            this.TsmAddComision.Image = global::CarteraGeneral.Properties.Resources.add_48;
            this.TsmAddComision.Name = "TsmAddComision";
            this.TsmAddComision.Size = new System.Drawing.Size(179, 22);
            this.TsmAddComision.Text = "Adicionar Comision";
            this.TsmAddComision.Click += new System.EventHandler(this.TsmAddComision_Click);
            // 
            // TsmModificarCms
            // 
            this.TsmModificarCms.Image = global::CarteraGeneral.Properties.Resources._1402294180_Modify;
            this.TsmModificarCms.Name = "TsmModificarCms";
            this.TsmModificarCms.Size = new System.Drawing.Size(179, 22);
            this.TsmModificarCms.Text = "Modificar Comision";
            this.TsmModificarCms.Click += new System.EventHandler(this.TsmModificarCms_Click);
            // 
            // TsmExportar
            // 
            this.TsmExportar.Image = global::CarteraGeneral.Properties.Resources._1402297290_Excel;
            this.TsmExportar.Name = "TsmExportar";
            this.TsmExportar.Size = new System.Drawing.Size(179, 22);
            this.TsmExportar.Text = "Exportar a Excel";
            this.TsmExportar.Click += new System.EventHandler(this.TsmExportar_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 573);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1037, 22);
            this.statusStrip1.TabIndex = 278;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAdjudicacion.Location = new System.Drawing.Point(117, 64);
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.Size = new System.Drawing.Size(150, 22);
            this.TxtAdjudicacion.TabIndex = 265;
            this.TxtAdjudicacion.Enter += new System.EventHandler(this.TxtAdjudicacion_Enter);
            this.TxtAdjudicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAdjudicacion_KeyPress);
            this.TxtAdjudicacion.Leave += new System.EventHandler(this.TxtAdjudicacion_Leave);
            // 
            // TxtUnidad
            // 
            this.TxtUnidad.BackColor = System.Drawing.Color.SteelBlue;
            this.TxtUnidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUnidad.ForeColor = System.Drawing.Color.White;
            this.TxtUnidad.Location = new System.Drawing.Point(869, 82);
            this.TxtUnidad.Name = "TxtUnidad";
            this.TxtUnidad.Size = new System.Drawing.Size(150, 18);
            this.TxtUnidad.TabIndex = 343;
            this.TxtUnidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(746, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 18);
            this.label11.TabIndex = 342;
            this.label11.Text = "Unidad:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtVilla
            // 
            this.TxtVilla.BackColor = System.Drawing.Color.SteelBlue;
            this.TxtVilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtVilla.ForeColor = System.Drawing.Color.White;
            this.TxtVilla.Location = new System.Drawing.Point(869, 61);
            this.TxtVilla.Name = "TxtVilla";
            this.TxtVilla.Size = new System.Drawing.Size(150, 18);
            this.TxtVilla.TabIndex = 341;
            this.TxtVilla.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(746, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 340;
            this.label4.Text = "Vlla:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtTipo
            // 
            this.TxtTipo.BackColor = System.Drawing.Color.SteelBlue;
            this.TxtTipo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTipo.ForeColor = System.Drawing.Color.White;
            this.TxtTipo.Location = new System.Drawing.Point(869, 145);
            this.TxtTipo.Name = "TxtTipo";
            this.TxtTipo.Size = new System.Drawing.Size(150, 18);
            this.TxtTipo.TabIndex = 339;
            this.TxtTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(746, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 338;
            this.label5.Text = "Tipo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtTemporada
            // 
            this.TxtTemporada.BackColor = System.Drawing.Color.SteelBlue;
            this.TxtTemporada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtTemporada.ForeColor = System.Drawing.Color.White;
            this.TxtTemporada.Location = new System.Drawing.Point(869, 124);
            this.TxtTemporada.Name = "TxtTemporada";
            this.TxtTemporada.Size = new System.Drawing.Size(150, 18);
            this.TxtTemporada.TabIndex = 337;
            this.TxtTemporada.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(746, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 18);
            this.label10.TabIndex = 336;
            this.label10.Text = "Temporada:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtSemana
            // 
            this.TxtSemana.BackColor = System.Drawing.Color.SteelBlue;
            this.TxtSemana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSemana.ForeColor = System.Drawing.Color.White;
            this.TxtSemana.Location = new System.Drawing.Point(869, 103);
            this.TxtSemana.Name = "TxtSemana";
            this.TxtSemana.Size = new System.Drawing.Size(150, 18);
            this.TxtSemana.TabIndex = 335;
            this.TxtSemana.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(746, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 18);
            this.label7.TabIndex = 334;
            this.label7.Text = "Semana:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtInmueble
            // 
            this.TxtInmueble.BackColor = System.Drawing.Color.SteelBlue;
            this.TxtInmueble.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtInmueble.ForeColor = System.Drawing.Color.White;
            this.TxtInmueble.Location = new System.Drawing.Point(117, 112);
            this.TxtInmueble.Name = "TxtInmueble";
            this.TxtInmueble.Size = new System.Drawing.Size(150, 18);
            this.TxtInmueble.TabIndex = 350;
            this.TxtInmueble.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 349;
            this.label6.Text = "Inmueble:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtClinte
            // 
            this.TxtClinte.BackColor = System.Drawing.Color.SteelBlue;
            this.TxtClinte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtClinte.ForeColor = System.Drawing.Color.White;
            this.TxtClinte.Location = new System.Drawing.Point(117, 91);
            this.TxtClinte.Name = "TxtClinte";
            this.TxtClinte.Size = new System.Drawing.Size(381, 18);
            this.TxtClinte.TabIndex = 348;
            this.TxtClinte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(3, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 18);
            this.label9.TabIndex = 347;
            this.label9.Text = "Cliente";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(3, 70);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 18);
            this.label12.TabIndex = 346;
            this.label12.Text = "Adjudicacion:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SteelBlue;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.LblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1037, 30);
            this.panel2.TabIndex = 351;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(116, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 217;
            this.pictureBox1.TabStop = false;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(125, 6);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(153, 18);
            this.LblTitulo.TabIndex = 185;
            this.LblTitulo.Text = "Modificar Comisiones";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnAdd,
            this.toolStripSeparator1,
            this.BtnMod,
            this.toolStripSeparator2,
            this.BtnExportar,
            this.toolStripSeparator3,
            this.toolStripSeparator4,
            this.BtnSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 30);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1037, 25);
            this.toolStrip1.TabIndex = 352;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnAdd
            // 
            this.BtnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnAdd.Image = global::CarteraGeneral.Properties.Resources._1402297104_Plus;
            this.BtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(23, 22);
            this.BtnAdd.ToolTipText = "Adicionar";
            this.BtnAdd.Click += new System.EventHandler(this.TsmAddComision_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnMod
            // 
            this.BtnMod.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnMod.Image = global::CarteraGeneral.Properties.Resources._1402294180_Modify;
            this.BtnMod.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnMod.Name = "BtnMod";
            this.BtnMod.Size = new System.Drawing.Size(23, 22);
            this.BtnMod.Text = " ";
            this.BtnMod.ToolTipText = " Modificar";
            this.BtnMod.Click += new System.EventHandler(this.TsmModificarCms_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnExportar
            // 
            this.BtnExportar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnExportar.Image = global::CarteraGeneral.Properties.Resources._1340379317_Microsoft_Office_2007_Excel1;
            this.BtnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(23, 22);
            this.BtnExportar.ToolTipText = "Exportar";
            this.BtnExportar.Click += new System.EventHandler(this.TsmExportar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // BtnSalir
            // 
            this.BtnSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.BtnSalir.Image = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(23, 22);
            this.BtnSalir.ToolTipText = "Salir";
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // IdTercero
            // 
            this.IdTercero.HeaderText = "IdTercero";
            this.IdTercero.Name = "IdTercero";
            this.IdTercero.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 250;
            // 
            // IdCargo
            // 
            this.IdCargo.HeaderText = "IdCargo";
            this.IdCargo.Name = "IdCargo";
            this.IdCargo.ReadOnly = true;
            // 
            // NombreCargo
            // 
            this.NombreCargo.HeaderText = "NombreCargo";
            this.NombreCargo.Name = "NombreCargo";
            this.NombreCargo.ReadOnly = true;
            this.NombreCargo.Width = 150;
            // 
            // Comision1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N3";
            dataGridViewCellStyle3.NullValue = "0";
            this.Comision1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Comision1.HeaderText = "Comision1";
            this.Comision1.Name = "Comision1";
            this.Comision1.ReadOnly = true;
            // 
            // Comision2
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N3";
            dataGridViewCellStyle4.NullValue = "0";
            this.Comision2.DefaultCellStyle = dataGridViewCellStyle4;
            this.Comision2.HeaderText = "Comision2";
            this.Comision2.Name = "Comision2";
            this.Comision2.ReadOnly = true;
            // 
            // Comision3
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = "0";
            this.Comision3.DefaultCellStyle = dataGridViewCellStyle5;
            this.Comision3.HeaderText = "Comision3";
            this.Comision3.Name = "Comision3";
            this.Comision3.ReadOnly = true;
            // 
            // FrmModuloComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(1037, 595);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TxtInmueble);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtClinte);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.TxtUnidad);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TxtVilla);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtTipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtTemporada);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.TxtSemana);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.DgvListado);
            this.Controls.Add(this.TxtAdjudicacion);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmModuloComision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.FrmModuloComision_Activated);
            this.Load += new System.EventHandler(this.FrmModuloComision_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox TxtAdjudicacion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TsmModificarCms;
        private System.Windows.Forms.ToolStripMenuItem TsmAddComision;
        private System.Windows.Forms.ToolStripMenuItem TsmExportar;
        private System.Windows.Forms.Label TxtUnidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label TxtVilla;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TxtTipo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label TxtTemporada;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label TxtSemana;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label TxtInmueble;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label TxtClinte;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton BtnAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnMod;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton BtnExportar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton BtnSalir;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTercero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision3;
    }
}