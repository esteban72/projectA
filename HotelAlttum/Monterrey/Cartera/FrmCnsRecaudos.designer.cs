namespace CarteraGeneral
{
    partial class FrmCnsRecaudos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCnsRecaudos));
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.NumRecibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblAprobado = new System.Windows.Forms.Label();
            this.LblPendiente = new System.Windows.Forms.Label();
            this.LblDevuelto = new System.Windows.Forms.Label();
            this.LblCuentaApr = new System.Windows.Forms.Label();
            this.LblCuentaPend = new System.Windows.Forms.Label();
            this.LblCuentaDev = new System.Windows.Forms.Label();
            this.LblTituloSumenu = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.PnlEncbezado = new System.Windows.Forms.Panel();
            this.TxtNombre1 = new System.Windows.Forms.Label();
            this.TxtInmueble = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.LblNombre1 = new System.Windows.Forms.Label();
            this.LblAdjudicacion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtAdjudicacion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtAprobado = new System.Windows.Forms.Label();
            this.TxtPendiente = new System.Windows.Forms.Label();
            this.TxtDevuelto = new System.Windows.Forms.Label();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.TxtTotal = new System.Windows.Forms.Label();
            this.LblCuentaTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.PnlEncbezado.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
            this.DgvListado.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumRecibo,
            this.Fecha,
            this.Operacion,
            this.Valor,
            this.Estado});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListado.DefaultCellStyle = dataGridViewCellStyle4;
            this.DgvListado.GridColor = System.Drawing.Color.OliveDrab;
            this.DgvListado.Location = new System.Drawing.Point(23, 85);
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.ReadOnly = true;
            this.DgvListado.Size = new System.Drawing.Size(719, 242);
            this.DgvListado.TabIndex = 0;
            // 
            // NumRecibo
            // 
            this.NumRecibo.HeaderText = "NumRecibo";
            this.NumRecibo.Name = "NumRecibo";
            this.NumRecibo.ReadOnly = true;
            // 
            // Fecha
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 120;
            // 
            // Operacion
            // 
            this.Operacion.HeaderText = "Operacion";
            this.Operacion.Name = "Operacion";
            this.Operacion.ReadOnly = true;
            this.Operacion.Width = 150;
            // 
            // Valor
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle3;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 120;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            this.Estado.Width = 150;
            // 
            // LblAprobado
            // 
            this.LblAprobado.AutoSize = true;
            this.LblAprobado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAprobado.Location = new System.Drawing.Point(23, 330);
            this.LblAprobado.Name = "LblAprobado";
            this.LblAprobado.Size = new System.Drawing.Size(85, 16);
            this.LblAprobado.TabIndex = 1;
            this.LblAprobado.Text = "Aprobados";
            // 
            // LblPendiente
            // 
            this.LblPendiente.AutoSize = true;
            this.LblPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPendiente.Location = new System.Drawing.Point(26, 352);
            this.LblPendiente.Name = "LblPendiente";
            this.LblPendiente.Size = new System.Drawing.Size(78, 16);
            this.LblPendiente.TabIndex = 2;
            this.LblPendiente.Text = "Pendiente";
            // 
            // LblDevuelto
            // 
            this.LblDevuelto.AutoSize = true;
            this.LblDevuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDevuelto.Location = new System.Drawing.Point(26, 374);
            this.LblDevuelto.Name = "LblDevuelto";
            this.LblDevuelto.Size = new System.Drawing.Size(70, 16);
            this.LblDevuelto.TabIndex = 3;
            this.LblDevuelto.Text = "Devuelto";
            // 
            // LblCuentaApr
            // 
            this.LblCuentaApr.AutoSize = true;
            this.LblCuentaApr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCuentaApr.Location = new System.Drawing.Point(140, 330);
            this.LblCuentaApr.Name = "LblCuentaApr";
            this.LblCuentaApr.Size = new System.Drawing.Size(12, 16);
            this.LblCuentaApr.TabIndex = 7;
            this.LblCuentaApr.Text = " ";
            // 
            // LblCuentaPend
            // 
            this.LblCuentaPend.AutoSize = true;
            this.LblCuentaPend.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCuentaPend.Location = new System.Drawing.Point(140, 352);
            this.LblCuentaPend.Name = "LblCuentaPend";
            this.LblCuentaPend.Size = new System.Drawing.Size(12, 16);
            this.LblCuentaPend.TabIndex = 8;
            this.LblCuentaPend.Text = " ";
            // 
            // LblCuentaDev
            // 
            this.LblCuentaDev.AutoSize = true;
            this.LblCuentaDev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCuentaDev.Location = new System.Drawing.Point(140, 374);
            this.LblCuentaDev.Name = "LblCuentaDev";
            this.LblCuentaDev.Size = new System.Drawing.Size(12, 16);
            this.LblCuentaDev.TabIndex = 9;
            this.LblCuentaDev.Text = " ";
            // 
            // LblTituloSumenu
            // 
            this.LblTituloSumenu.BackColor = System.Drawing.Color.Transparent;
            this.LblTituloSumenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTituloSumenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblTituloSumenu.Location = new System.Drawing.Point(184, 3);
            this.LblTituloSumenu.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTituloSumenu.Name = "LblTituloSumenu";
            this.LblTituloSumenu.Size = new System.Drawing.Size(381, 27);
            this.LblTituloSumenu.TabIndex = 219;
            this.LblTituloSumenu.Text = "CONSULTA DE RECAUDOS";
            this.LblTituloSumenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(656, 348);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(28, 22);
            this.BtnSalir.TabIndex = 220;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click_1);
            // 
            // PnlEncbezado
            // 
            this.PnlEncbezado.BackColor = System.Drawing.SystemColors.Control;
            this.PnlEncbezado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlEncbezado.Controls.Add(this.TxtNombre1);
            this.PnlEncbezado.Controls.Add(this.TxtInmueble);
            this.PnlEncbezado.Controls.Add(this.label19);
            this.PnlEncbezado.Controls.Add(this.LblNombre1);
            this.PnlEncbezado.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlEncbezado.Location = new System.Drawing.Point(0, 33);
            this.PnlEncbezado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PnlEncbezado.Name = "PnlEncbezado";
            this.PnlEncbezado.Size = new System.Drawing.Size(786, 31);
            this.PnlEncbezado.TabIndex = 221;
            // 
            // TxtNombre1
            // 
            this.TxtNombre1.AutoSize = true;
            this.TxtNombre1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombre1.Location = new System.Drawing.Point(65, 8);
            this.TxtNombre1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtNombre1.Name = "TxtNombre1";
            this.TxtNombre1.Size = new System.Drawing.Size(52, 16);
            this.TxtNombre1.TabIndex = 157;
            this.TxtNombre1.Text = "Titular1";
            // 
            // TxtInmueble
            // 
            this.TxtInmueble.AutoSize = true;
            this.TxtInmueble.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInmueble.Location = new System.Drawing.Point(483, 8);
            this.TxtInmueble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtInmueble.Name = "TxtInmueble";
            this.TxtInmueble.Size = new System.Drawing.Size(63, 16);
            this.TxtInmueble.TabIndex = 156;
            this.TxtInmueble.Text = "Inmueble";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(400, 8);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 16);
            this.label19.TabIndex = 155;
            this.label19.Text = "Inmueble:";
            // 
            // LblNombre1
            // 
            this.LblNombre1.AutoSize = true;
            this.LblNombre1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre1.Location = new System.Drawing.Point(4, 8);
            this.LblNombre1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNombre1.Name = "LblNombre1";
            this.LblNombre1.Size = new System.Drawing.Size(55, 16);
            this.LblNombre1.TabIndex = 148;
            this.LblNombre1.Text = "Titular1:";
            // 
            // LblAdjudicacion
            // 
            this.LblAdjudicacion.AutoSize = true;
            this.LblAdjudicacion.BackColor = System.Drawing.Color.Transparent;
            this.LblAdjudicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAdjudicacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblAdjudicacion.Location = new System.Drawing.Point(573, 6);
            this.LblAdjudicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblAdjudicacion.Name = "LblAdjudicacion";
            this.LblAdjudicacion.Size = new System.Drawing.Size(111, 20);
            this.LblAdjudicacion.TabIndex = 223;
            this.LblAdjudicacion.Text = "Adjudicacion";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TxtAdjudicacion);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LblAdjudicacion);
            this.panel1.Controls.Add(this.LblTituloSumenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 33);
            this.panel1.TabIndex = 224;
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.AutoSize = true;
            this.TxtAdjudicacion.BackColor = System.Drawing.Color.Transparent;
            this.TxtAdjudicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAdjudicacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TxtAdjudicacion.Location = new System.Drawing.Point(692, 6);
            this.TxtAdjudicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.Size = new System.Drawing.Size(19, 20);
            this.TxtAdjudicacion.TabIndex = 224;
            this.TxtAdjudicacion.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 218;
            this.pictureBox1.TabStop = false;
            // 
            // TxtAprobado
            // 
            this.TxtAprobado.AutoSize = true;
            this.TxtAprobado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAprobado.Location = new System.Drawing.Point(186, 330);
            this.TxtAprobado.Name = "TxtAprobado";
            this.TxtAprobado.Size = new System.Drawing.Size(16, 16);
            this.TxtAprobado.TabIndex = 225;
            this.TxtAprobado.Text = "0";
            // 
            // TxtPendiente
            // 
            this.TxtPendiente.AutoSize = true;
            this.TxtPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPendiente.Location = new System.Drawing.Point(186, 352);
            this.TxtPendiente.Name = "TxtPendiente";
            this.TxtPendiente.Size = new System.Drawing.Size(16, 16);
            this.TxtPendiente.TabIndex = 226;
            this.TxtPendiente.Text = "0";
            // 
            // TxtDevuelto
            // 
            this.TxtDevuelto.AutoSize = true;
            this.TxtDevuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDevuelto.Location = new System.Drawing.Point(186, 374);
            this.TxtDevuelto.Name = "TxtDevuelto";
            this.TxtDevuelto.Size = new System.Drawing.Size(16, 16);
            this.TxtDevuelto.TabIndex = 227;
            this.TxtDevuelto.Text = "0";
            // 
            // BtnExportar
            // 
            this.BtnExportar.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297290_Excel;
            this.BtnExportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportar.Location = new System.Drawing.Point(609, 348);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(28, 22);
            this.BtnExportar.TabIndex = 228;
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // TxtTotal
            // 
            this.TxtTotal.AutoSize = true;
            this.TxtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotal.Location = new System.Drawing.Point(186, 400);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(16, 16);
            this.TxtTotal.TabIndex = 231;
            this.TxtTotal.Text = "0";
            // 
            // LblCuentaTotal
            // 
            this.LblCuentaTotal.AutoSize = true;
            this.LblCuentaTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCuentaTotal.Location = new System.Drawing.Point(140, 400);
            this.LblCuentaTotal.Name = "LblCuentaTotal";
            this.LblCuentaTotal.Size = new System.Drawing.Size(12, 16);
            this.LblCuentaTotal.TabIndex = 230;
            this.LblCuentaTotal.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 229;
            this.label3.Text = "Total";
            // 
            // FrmCnsRecaudos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(786, 425);
            this.Controls.Add(this.TxtTotal);
            this.Controls.Add(this.LblCuentaTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.TxtDevuelto);
            this.Controls.Add(this.TxtPendiente);
            this.Controls.Add(this.TxtAprobado);
            this.Controls.Add(this.PnlEncbezado);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.LblCuentaDev);
            this.Controls.Add(this.LblCuentaPend);
            this.Controls.Add(this.LblCuentaApr);
            this.Controls.Add(this.LblDevuelto);
            this.Controls.Add(this.LblPendiente);
            this.Controls.Add(this.LblAprobado);
            this.Controls.Add(this.DgvListado);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCnsRecaudos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCnsRecaudos";
            this.Load += new System.EventHandler(this.FrmCnsRecaudos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.PnlEncbezado.ResumeLayout(false);
            this.PnlEncbezado.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.Label LblAprobado;
        private System.Windows.Forms.Label LblPendiente;
        private System.Windows.Forms.Label LblDevuelto;
        private System.Windows.Forms.Label LblCuentaApr;
        private System.Windows.Forms.Label LblCuentaPend;
        private System.Windows.Forms.Label LblCuentaDev;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblTituloSumenu;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Panel PnlEncbezado;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label LblNombre1;
        private System.Windows.Forms.Label LblAdjudicacion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label TxtNombre1;
        private System.Windows.Forms.Label TxtInmueble;
        private System.Windows.Forms.Label TxtAdjudicacion;
        private System.Windows.Forms.Label TxtAprobado;
        private System.Windows.Forms.Label TxtPendiente;
        private System.Windows.Forms.Label TxtDevuelto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumRecibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Label TxtTotal;
        private System.Windows.Forms.Label LblCuentaTotal;
        private System.Windows.Forms.Label label3;
    }
}