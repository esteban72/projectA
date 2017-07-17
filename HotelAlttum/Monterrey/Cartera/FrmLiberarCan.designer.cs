namespace CarteraGeneral
{
    partial class FrmLiberarCan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLiberarCan));
            this.label1 = new System.Windows.Forms.Label();
            this.DgvDatos = new System.Windows.Forms.DataGridView();
            this.Recaudo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recibo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Transaccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblProyecto = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblIdRecibo = new System.Windows.Forms.Label();
            this.LblAdjudicacion = new System.Windows.Forms.Label();
            this.PnlEncbezado = new System.Windows.Forms.Panel();
            this.TxtValor = new System.Windows.Forms.Label();
            this.TxtidRecaudo = new System.Windows.Forms.Label();
            this.TxtRecibo = new System.Windows.Forms.Label();
            this.TxtProyecto = new System.Windows.Forms.Label();
            this.TxtNombre1 = new System.Windows.Forms.Label();
            this.TxtTotal = new System.Windows.Forms.Label();
            this.TxtFecha = new System.Windows.Forms.Label();
            this.TxtInmueble = new System.Windows.Forms.Label();
            this.TxtAdjudicacion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LblNombre1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.BtnDevuleto = new System.Windows.Forms.Button();
            this.BtnLiberar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LblIdtercero = new System.Windows.Forms.Label();
            this.LblCodBanco = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).BeginInit();
            this.panel1.SuspendLayout();
            this.PnlEncbezado.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(492, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 171;
            this.label1.Text = "Valor:";
            // 
            // DgvDatos
            // 
            this.DgvDatos.AllowUserToAddRows = false;
            this.DgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Recaudo,
            this.Cliente,
            this.Adj,
            this.Recibo,
            this.Fecha,
            this.Valor,
            this.CodBanco,
            this.Concepto,
            this.Transaccion});
            this.DgvDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDatos.Location = new System.Drawing.Point(0, 0);
            this.DgvDatos.Name = "DgvDatos";
            this.DgvDatos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DgvDatos.RowHeadersVisible = false;
            this.DgvDatos.Size = new System.Drawing.Size(902, 173);
            this.DgvDatos.TabIndex = 0;
            this.DgvDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDatos_CellEnter);
            // 
            // Recaudo
            // 
            this.Recaudo.HeaderText = "Recaudo";
            this.Recaudo.Name = "Recaudo";
            this.Recaudo.Width = 76;
            // 
            // Cliente
            // 
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Width = 64;
            // 
            // Adj
            // 
            this.Adj.HeaderText = "Adjudicacion";
            this.Adj.Name = "Adj";
            this.Adj.Width = 93;
            // 
            // Recibo
            // 
            this.Recibo.HeaderText = "Recibo";
            this.Recibo.Name = "Recibo";
            this.Recibo.Width = 66;
            // 
            // Fecha
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle1;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 62;
            // 
            // Valor
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.Width = 56;
            // 
            // CodBanco
            // 
            this.CodBanco.HeaderText = "CodBanco";
            this.CodBanco.Name = "CodBanco";
            this.CodBanco.Width = 82;
            // 
            // Concepto
            // 
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 78;
            // 
            // Transaccion
            // 
            this.Transaccion.HeaderText = "Transaccion";
            this.Transaccion.Name = "Transaccion";
            this.Transaccion.Width = 91;
            // 
            // LblProyecto
            // 
            this.LblProyecto.AutoSize = true;
            this.LblProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProyecto.Location = new System.Drawing.Point(186, 36);
            this.LblProyecto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblProyecto.Name = "LblProyecto";
            this.LblProyecto.Size = new System.Drawing.Size(61, 13);
            this.LblProyecto.TabIndex = 168;
            this.LblProyecto.Text = "Proyecto:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(11, 36);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(62, 13);
            this.label19.TabIndex = 155;
            this.label19.Text = "Inmueble:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DgvDatos);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(902, 173);
            this.panel1.TabIndex = 177;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblTitulo.Location = new System.Drawing.Point(356, 9);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(190, 20);
            this.LblTitulo.TabIndex = 175;
            this.LblTitulo.Text = "LIBERACION DE CANJE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(186, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 148;
            this.label3.Text = "Recibo Caja N.:";
            // 
            // lblIdRecibo
            // 
            this.lblIdRecibo.AutoSize = true;
            this.lblIdRecibo.BackColor = System.Drawing.SystemColors.Control;
            this.lblIdRecibo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdRecibo.Location = new System.Drawing.Point(492, 36);
            this.lblIdRecibo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIdRecibo.Name = "lblIdRecibo";
            this.lblIdRecibo.Size = new System.Drawing.Size(62, 13);
            this.lblIdRecibo.TabIndex = 147;
            this.lblIdRecibo.Text = "IdRecibo:";
            // 
            // LblAdjudicacion
            // 
            this.LblAdjudicacion.AutoSize = true;
            this.LblAdjudicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAdjudicacion.Location = new System.Drawing.Point(11, 9);
            this.LblAdjudicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblAdjudicacion.Name = "LblAdjudicacion";
            this.LblAdjudicacion.Size = new System.Drawing.Size(84, 13);
            this.LblAdjudicacion.TabIndex = 153;
            this.LblAdjudicacion.Text = "Adjudicacion:";
            // 
            // PnlEncbezado
            // 
            this.PnlEncbezado.BackColor = System.Drawing.SystemColors.Control;
            this.PnlEncbezado.Controls.Add(this.LblCodBanco);
            this.PnlEncbezado.Controls.Add(this.label6);
            this.PnlEncbezado.Controls.Add(this.LblIdtercero);
            this.PnlEncbezado.Controls.Add(this.TxtValor);
            this.PnlEncbezado.Controls.Add(this.TxtidRecaudo);
            this.PnlEncbezado.Controls.Add(this.TxtRecibo);
            this.PnlEncbezado.Controls.Add(this.TxtProyecto);
            this.PnlEncbezado.Controls.Add(this.TxtNombre1);
            this.PnlEncbezado.Controls.Add(this.TxtTotal);
            this.PnlEncbezado.Controls.Add(this.TxtFecha);
            this.PnlEncbezado.Controls.Add(this.TxtInmueble);
            this.PnlEncbezado.Controls.Add(this.TxtAdjudicacion);
            this.PnlEncbezado.Controls.Add(this.label2);
            this.PnlEncbezado.Controls.Add(this.label1);
            this.PnlEncbezado.Controls.Add(this.LblProyecto);
            this.PnlEncbezado.Controls.Add(this.label19);
            this.PnlEncbezado.Controls.Add(this.label3);
            this.PnlEncbezado.Controls.Add(this.lblIdRecibo);
            this.PnlEncbezado.Controls.Add(this.LblAdjudicacion);
            this.PnlEncbezado.Controls.Add(this.label5);
            this.PnlEncbezado.Controls.Add(this.LblNombre1);
            this.PnlEncbezado.Location = new System.Drawing.Point(0, 220);
            this.PnlEncbezado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.PnlEncbezado.Name = "PnlEncbezado";
            this.PnlEncbezado.Size = new System.Drawing.Size(802, 124);
            this.PnlEncbezado.TabIndex = 174;
            // 
            // TxtValor
            // 
            this.TxtValor.AutoSize = true;
            this.TxtValor.Location = new System.Drawing.Point(557, 69);
            this.TxtValor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(13, 13);
            this.TxtValor.TabIndex = 183;
            this.TxtValor.Text = "0";
            // 
            // TxtidRecaudo
            // 
            this.TxtidRecaudo.AutoSize = true;
            this.TxtidRecaudo.BackColor = System.Drawing.SystemColors.Control;
            this.TxtidRecaudo.Location = new System.Drawing.Point(557, 36);
            this.TxtidRecaudo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtidRecaudo.Name = "TxtidRecaudo";
            this.TxtidRecaudo.Size = new System.Drawing.Size(13, 13);
            this.TxtidRecaudo.TabIndex = 182;
            this.TxtidRecaudo.Text = "0";
            // 
            // TxtRecibo
            // 
            this.TxtRecibo.AutoSize = true;
            this.TxtRecibo.Location = new System.Drawing.Point(282, 69);
            this.TxtRecibo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtRecibo.Name = "TxtRecibo";
            this.TxtRecibo.Size = new System.Drawing.Size(15, 13);
            this.TxtRecibo.TabIndex = 181;
            this.TxtRecibo.Text = "R";
            // 
            // TxtProyecto
            // 
            this.TxtProyecto.AutoSize = true;
            this.TxtProyecto.Location = new System.Drawing.Point(282, 36);
            this.TxtProyecto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtProyecto.Name = "TxtProyecto";
            this.TxtProyecto.Size = new System.Drawing.Size(14, 13);
            this.TxtProyecto.TabIndex = 180;
            this.TxtProyecto.Text = "P";
            // 
            // TxtNombre1
            // 
            this.TxtNombre1.AutoSize = true;
            this.TxtNombre1.Location = new System.Drawing.Point(335, 9);
            this.TxtNombre1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtNombre1.Name = "TxtNombre1";
            this.TxtNombre1.Size = new System.Drawing.Size(42, 13);
            this.TxtNombre1.TabIndex = 178;
            this.TxtNombre1.Text = "Titular1";
            // 
            // TxtTotal
            // 
            this.TxtTotal.AutoSize = true;
            this.TxtTotal.Location = new System.Drawing.Point(404, 96);
            this.TxtTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtTotal.Name = "TxtTotal";
            this.TxtTotal.Size = new System.Drawing.Size(13, 13);
            this.TxtTotal.TabIndex = 177;
            this.TxtTotal.Text = "0";
            // 
            // TxtFecha
            // 
            this.TxtFecha.AutoSize = true;
            this.TxtFecha.Location = new System.Drawing.Point(96, 69);
            this.TxtFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.Size = new System.Drawing.Size(37, 13);
            this.TxtFecha.TabIndex = 176;
            this.TxtFecha.Text = "Fecha";
            // 
            // TxtInmueble
            // 
            this.TxtInmueble.AutoSize = true;
            this.TxtInmueble.Location = new System.Drawing.Point(96, 36);
            this.TxtInmueble.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtInmueble.Name = "TxtInmueble";
            this.TxtInmueble.Size = new System.Drawing.Size(68, 13);
            this.TxtInmueble.TabIndex = 175;
            this.TxtInmueble.Text = "Adjudicacion";
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.AutoSize = true;
            this.TxtAdjudicacion.Location = new System.Drawing.Point(96, 9);
            this.TxtAdjudicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.Size = new System.Drawing.Size(68, 13);
            this.TxtAdjudicacion.TabIndex = 174;
            this.TxtAdjudicacion.Text = "Adjudicacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(192, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 173;
            this.label2.Text = "Canje Total:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 151;
            this.label5.Text = "Fecha:";
            // 
            // LblNombre1
            // 
            this.LblNombre1.AutoSize = true;
            this.LblNombre1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre1.Location = new System.Drawing.Point(186, 9);
            this.LblNombre1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNombre1.Name = "LblNombre1";
            this.LblNombre1.Size = new System.Drawing.Size(54, 13);
            this.LblNombre1.TabIndex = 148;
            this.LblNombre1.Text = "Titular1:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.BtnExportar);
            this.panel2.Controls.Add(this.BtnDevuleto);
            this.panel2.Controls.Add(this.BtnLiberar);
            this.panel2.Controls.Add(this.BtnSalir);
            this.panel2.Location = new System.Drawing.Point(801, 220);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(99, 124);
            this.panel2.TabIndex = 178;
            // 
            // BtnExportar
            // 
            this.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExportar.Location = new System.Drawing.Point(6, 64);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(87, 23);
            this.BtnExportar.TabIndex = 173;
            this.BtnExportar.Text = "Exportar";
            this.BtnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // BtnDevuleto
            // 
            this.BtnDevuleto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnDevuleto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnDevuleto.Location = new System.Drawing.Point(6, 36);
            this.BtnDevuleto.Name = "BtnDevuleto";
            this.BtnDevuleto.Size = new System.Drawing.Size(87, 23);
            this.BtnDevuleto.TabIndex = 172;
            this.BtnDevuleto.Text = "Devuelto";
            this.BtnDevuleto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDevuleto.UseVisualStyleBackColor = true;
            this.BtnDevuleto.Click += new System.EventHandler(this.BtnDevuleto_Click);
            // 
            // BtnLiberar
            // 
            this.BtnLiberar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnLiberar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnLiberar.Location = new System.Drawing.Point(6, 8);
            this.BtnLiberar.Name = "BtnLiberar";
            this.BtnLiberar.Size = new System.Drawing.Size(87, 23);
            this.BtnLiberar.TabIndex = 5;
            this.BtnLiberar.Text = "Corriente";
            this.BtnLiberar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLiberar.UseVisualStyleBackColor = true;
            this.BtnLiberar.Click += new System.EventHandler(this.BtnLiberar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(6, 92);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(87, 23);
            this.BtnSalir.TabIndex = 6;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 179;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.LblTitulo);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(902, 32);
            this.panel3.TabIndex = 180;
            // 
            // LblIdtercero
            // 
            this.LblIdtercero.AutoSize = true;
            this.LblIdtercero.Location = new System.Drawing.Point(255, 9);
            this.LblIdtercero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblIdtercero.Name = "LblIdtercero";
            this.LblIdtercero.Size = new System.Drawing.Size(13, 13);
            this.LblIdtercero.TabIndex = 184;
            this.LblIdtercero.Text = "c";
            // 
            // LblCodBanco
            // 
            this.LblCodBanco.AutoSize = true;
            this.LblCodBanco.Location = new System.Drawing.Point(109, 96);
            this.LblCodBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblCodBanco.Name = "LblCodBanco";
            this.LblCodBanco.Size = new System.Drawing.Size(15, 13);
            this.LblCodBanco.TabIndex = 186;
            this.LblCodBanco.Text = "R";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 96);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 185;
            this.label6.Text = "CodBanco";
            // 
            // FrmLiberarCan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(902, 345);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnlEncbezado);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLiberarCan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Liberar Canje";
            this.Load += new System.EventHandler(this.FrmLiberarCan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvDatos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.PnlEncbezado.ResumeLayout(false);
            this.PnlEncbezado.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvDatos;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label LblProyecto;
        private System.Windows.Forms.Button BtnLiberar;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnDevuleto;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblIdRecibo;
        private System.Windows.Forms.Label LblAdjudicacion;
        private System.Windows.Forms.Panel PnlEncbezado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LblNombre1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recaudo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recibo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Transaccion;
        private System.Windows.Forms.Label TxtValor;
        private System.Windows.Forms.Label TxtidRecaudo;
        private System.Windows.Forms.Label TxtRecibo;
        private System.Windows.Forms.Label TxtProyecto;
        private System.Windows.Forms.Label TxtNombre1;
        private System.Windows.Forms.Label TxtTotal;
        private System.Windows.Forms.Label TxtFecha;
        private System.Windows.Forms.Label TxtInmueble;
        private System.Windows.Forms.Label TxtAdjudicacion;
        private System.Windows.Forms.Label LblIdtercero;
        private System.Windows.Forms.Label LblCodBanco;
        private System.Windows.Forms.Label label6;
    }
}