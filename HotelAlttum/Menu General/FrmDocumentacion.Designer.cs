namespace CarteraGeneral
{
    partial class FrmDocumentacion
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblBuscar = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.BtnEnviar = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnAceptar = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnDevolver = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCns = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCnsRecaudos = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnRcdFecha = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCnsResumenCredito = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSaldosTotales = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnInformes = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExtracto = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            this.LblFiltro = new System.Windows.Forms.Label();
            this.CmbBusqueda = new System.Windows.Forms.ComboBox();
            this.LblTituloSumenu = new System.Windows.Forms.Label();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.LblAceptados = new System.Windows.Forms.Label();
            this.TxtAceptados = new System.Windows.Forms.TextBox();
            this.LblPendientes = new System.Windows.Forms.Label();
            this.TxtPendientes = new System.Windows.Forms.TextBox();
            this.LblNumRegistro = new System.Windows.Forms.Label();
            this.TxtRegistros = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LblBuscar);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.TxtBusqueda);
            this.panel1.Controls.Add(this.LblFiltro);
            this.panel1.Controls.Add(this.CmbBusqueda);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1273, 35);
            this.panel1.TabIndex = 255;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 217;
            this.pictureBox1.TabStop = false;
            // 
            // LblBuscar
            // 
            this.LblBuscar.AutoSize = true;
            this.LblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBuscar.ForeColor = System.Drawing.Color.Black;
            this.LblBuscar.Location = new System.Drawing.Point(1045, 8);
            this.LblBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblBuscar.Name = "LblBuscar";
            this.LblBuscar.Size = new System.Drawing.Size(59, 18);
            this.LblBuscar.TabIndex = 13;
            this.LblBuscar.Text = "Buscar ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnEnviar,
            this.BtnAceptar,
            this.BtnDevolver,
            this.BtnExportar,
            this.BtnCns,
            this.BtnInformes,
            this.BtnSalir});
            this.menuStrip1.Location = new System.Drawing.Point(152, 4);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(448, 24);
            this.menuStrip1.TabIndex = 253;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(51, 20);
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(60, 20);
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnDevolver
            // 
            this.BtnDevolver.Name = "BtnDevolver";
            this.BtnDevolver.Size = new System.Drawing.Size(65, 20);
            this.BtnDevolver.Text = "Devolver";
            this.BtnDevolver.Click += new System.EventHandler(this.BtnDevolver_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(91, 20);
            this.BtnExportar.Text = "Exportar Excel";
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // BtnCns
            // 
            this.BtnCns.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnCnsRecaudos,
            this.BtnRcdFecha,
            this.BtnCnsResumenCredito,
            this.BtnSaldosTotales});
            this.BtnCns.Name = "BtnCns";
            this.BtnCns.Size = new System.Drawing.Size(71, 20);
            this.BtnCns.Text = "Consultas";
            // 
            // BtnCnsRecaudos
            // 
            this.BtnCnsRecaudos.Name = "BtnCnsRecaudos";
            this.BtnCnsRecaudos.Size = new System.Drawing.Size(188, 22);
            this.BtnCnsRecaudos.Text = "Recaudos Detallados";
            // 
            // BtnRcdFecha
            // 
            this.BtnRcdFecha.Name = "BtnRcdFecha";
            this.BtnRcdFecha.Size = new System.Drawing.Size(188, 22);
            this.BtnRcdFecha.Text = "Recaudos Por Fecha";
            // 
            // BtnCnsResumenCredito
            // 
            this.BtnCnsResumenCredito.Name = "BtnCnsResumenCredito";
            this.BtnCnsResumenCredito.Size = new System.Drawing.Size(188, 22);
            this.BtnCnsResumenCredito.Text = "Resumen Credito";
            // 
            // BtnSaldosTotales
            // 
            this.BtnSaldosTotales.Name = "BtnSaldosTotales";
            this.BtnSaldosTotales.Size = new System.Drawing.Size(188, 22);
            this.BtnSaldosTotales.Text = "Saldo General Credito";
            // 
            // BtnInformes
            // 
            this.BtnInformes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnExtracto});
            this.BtnInformes.Name = "BtnInformes";
            this.BtnInformes.Size = new System.Drawing.Size(61, 20);
            this.BtnInformes.Text = "Informe";
            // 
            // BtnExtracto
            // 
            this.BtnExtracto.Name = "BtnExtracto";
            this.BtnExtracto.Size = new System.Drawing.Size(116, 22);
            this.BtnExtracto.Text = "Extracto";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(41, 20);
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtBusqueda.Location = new System.Drawing.Point(1116, 7);
            this.TxtBusqueda.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(144, 20);
            this.TxtBusqueda.TabIndex = 11;
            // 
            // LblFiltro
            // 
            this.LblFiltro.AutoSize = true;
            this.LblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFiltro.ForeColor = System.Drawing.Color.Black;
            this.LblFiltro.Location = new System.Drawing.Point(754, 8);
            this.LblFiltro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFiltro.Name = "LblFiltro";
            this.LblFiltro.Size = new System.Drawing.Size(41, 18);
            this.LblFiltro.TabIndex = 12;
            this.LblFiltro.Text = "Filtro";
            // 
            // CmbBusqueda
            // 
            this.CmbBusqueda.FormattingEnabled = true;
            this.CmbBusqueda.Items.AddRange(new object[] {
            "Tercero1",
            "Cliente",
            "Inmueble",
            "Tercero2",
            "Estado"});
            this.CmbBusqueda.Location = new System.Drawing.Point(809, 7);
            this.CmbBusqueda.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CmbBusqueda.Name = "CmbBusqueda";
            this.CmbBusqueda.Size = new System.Drawing.Size(173, 21);
            this.CmbBusqueda.TabIndex = 10;
            // 
            // LblTituloSumenu
            // 
            this.LblTituloSumenu.BackColor = System.Drawing.Color.Transparent;
            this.LblTituloSumenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTituloSumenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloSumenu.ForeColor = System.Drawing.Color.Black;
            this.LblTituloSumenu.Location = new System.Drawing.Point(0, 35);
            this.LblTituloSumenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTituloSumenu.Name = "LblTituloSumenu";
            this.LblTituloSumenu.Size = new System.Drawing.Size(1273, 31);
            this.LblTituloSumenu.TabIndex = 256;
            this.LblTituloSumenu.Text = "DOCUMENTOS";
            this.LblTituloSumenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvListado.BackgroundColor = System.Drawing.Color.White;
            this.DgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListado.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvListado.Dock = System.Windows.Forms.DockStyle.Top;
            this.DgvListado.GridColor = System.Drawing.Color.Black;
            this.DgvListado.Location = new System.Drawing.Point(0, 66);
            this.DgvListado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.ReadOnly = true;
            this.DgvListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.MidnightBlue;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvListado.RowHeadersVisible = false;
            this.DgvListado.Size = new System.Drawing.Size(1273, 553);
            this.DgvListado.TabIndex = 257;
            this.DgvListado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellEnter);
            // 
            // LblAceptados
            // 
            this.LblAceptados.AutoSize = true;
            this.LblAceptados.Location = new System.Drawing.Point(38, 700);
            this.LblAceptados.Name = "LblAceptados";
            this.LblAceptados.Size = new System.Drawing.Size(58, 13);
            this.LblAceptados.TabIndex = 263;
            this.LblAceptados.Text = "Aceptados";
            // 
            // TxtAceptados
            // 
            this.TxtAceptados.Location = new System.Drawing.Point(175, 697);
            this.TxtAceptados.Name = "TxtAceptados";
            this.TxtAceptados.ReadOnly = true;
            this.TxtAceptados.Size = new System.Drawing.Size(55, 20);
            this.TxtAceptados.TabIndex = 264;
            // 
            // LblPendientes
            // 
            this.LblPendientes.AutoSize = true;
            this.LblPendientes.Location = new System.Drawing.Point(38, 674);
            this.LblPendientes.Name = "LblPendientes";
            this.LblPendientes.Size = new System.Drawing.Size(96, 13);
            this.LblPendientes.TabIndex = 261;
            this.LblPendientes.Text = "Pendientes Recibir";
            // 
            // TxtPendientes
            // 
            this.TxtPendientes.Location = new System.Drawing.Point(175, 671);
            this.TxtPendientes.Name = "TxtPendientes";
            this.TxtPendientes.ReadOnly = true;
            this.TxtPendientes.Size = new System.Drawing.Size(55, 20);
            this.TxtPendientes.TabIndex = 262;
            // 
            // LblNumRegistro
            // 
            this.LblNumRegistro.AutoSize = true;
            this.LblNumRegistro.Location = new System.Drawing.Point(38, 646);
            this.LblNumRegistro.Name = "LblNumRegistro";
            this.LblNumRegistro.Size = new System.Drawing.Size(91, 13);
            this.LblNumRegistro.TabIndex = 259;
            this.LblNumRegistro.Text = "Numero Registros";
            // 
            // TxtRegistros
            // 
            this.TxtRegistros.Location = new System.Drawing.Point(175, 643);
            this.TxtRegistros.Name = "TxtRegistros";
            this.TxtRegistros.ReadOnly = true;
            this.TxtRegistros.Size = new System.Drawing.Size(55, 20);
            this.TxtRegistros.TabIndex = 260;
            // 
            // FrmDocumentacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 741);
            this.Controls.Add(this.DgvListado);
            this.Controls.Add(this.LblAceptados);
            this.Controls.Add(this.TxtAceptados);
            this.Controls.Add(this.LblPendientes);
            this.Controls.Add(this.TxtPendientes);
            this.Controls.Add(this.LblNumRegistro);
            this.Controls.Add(this.TxtRegistros);
            this.Controls.Add(this.LblTituloSumenu);
            this.Controls.Add(this.panel1);
            this.Name = "FrmDocumentacion";
            this.Text = "FrmDocumentacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmDocumentacion_Activated);
            this.Load += new System.EventHandler(this.FrmDocumentacion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblBuscar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem BtnEnviar;
        private System.Windows.Forms.ToolStripMenuItem BtnAceptar;
        private System.Windows.Forms.ToolStripMenuItem BtnDevolver;
        private System.Windows.Forms.ToolStripMenuItem BtnExportar;
        private System.Windows.Forms.ToolStripMenuItem BtnCns;
        private System.Windows.Forms.ToolStripMenuItem BtnCnsRecaudos;
        private System.Windows.Forms.ToolStripMenuItem BtnRcdFecha;
        private System.Windows.Forms.ToolStripMenuItem BtnCnsResumenCredito;
        private System.Windows.Forms.ToolStripMenuItem BtnSaldosTotales;
        private System.Windows.Forms.ToolStripMenuItem BtnInformes;
        private System.Windows.Forms.ToolStripMenuItem BtnExtracto;
        private System.Windows.Forms.ToolStripMenuItem BtnSalir;
        private System.Windows.Forms.TextBox TxtBusqueda;
        private System.Windows.Forms.Label LblFiltro;
        private System.Windows.Forms.ComboBox CmbBusqueda;
        private System.Windows.Forms.Label LblTituloSumenu;
        public System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.Label LblAceptados;
        private System.Windows.Forms.TextBox TxtAceptados;
        private System.Windows.Forms.Label LblPendientes;
        private System.Windows.Forms.TextBox TxtPendientes;
        private System.Windows.Forms.Label LblNumRegistro;
        private System.Windows.Forms.TextBox TxtRegistros;
    }
}