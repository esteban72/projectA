namespace CarteraGeneral
{
    partial class FrmCondonacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCondonacion));
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DgvPagos = new System.Windows.Forms.DataGridView();
            this.LblInmueble = new System.Windows.Forms.Label();
            this.TxtValor = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnElimnar = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnAdicionar = new System.Windows.Forms.Button();
            this.LblValor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.LblNombres = new System.Windows.Forms.Label();
            this.TxtAdjudicacion = new System.Windows.Forms.TextBox();
            this.Lbldjudicacion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condonacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TxtNombres = new System.Windows.Forms.Label();
            this.TxtInmueble = new System.Windows.Forms.Label();
            this.TxtConcepto = new System.Windows.Forms.Label();
            this.TxtCuota = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPagos)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnModificar
            // 
            this.BtnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnModificar.Location = new System.Drawing.Point(6, 70);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(63, 23);
            this.BtnModificar.TabIndex = 11;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Visible = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.Location = new System.Drawing.Point(8, 172);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(63, 23);
            this.BtnNuevo.TabIndex = 14;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Visible = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(217, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 24);
            this.label1.TabIndex = 217;
            this.label1.Text = "CONDONACION DE INTERESES MORATORIO";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.DgvPagos);
            this.panel2.Location = new System.Drawing.Point(25, 187);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(696, 247);
            this.panel2.TabIndex = 216;
            // 
            // DgvPagos
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvPagos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPagos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvPagos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column12,
            this.Concept,
            this.Column15,
            this.Column16,
            this.Column17,
            this.Condonacion});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPagos.DefaultCellStyle = dataGridViewCellStyle10;
            this.DgvPagos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvPagos.Location = new System.Drawing.Point(0, 0);
            this.DgvPagos.Name = "DgvPagos";
            this.DgvPagos.ReadOnly = true;
            this.DgvPagos.Size = new System.Drawing.Size(696, 247);
            this.DgvPagos.TabIndex = 208;
            this.DgvPagos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvPagos_CellEnter);
            // 
            // LblInmueble
            // 
            this.LblInmueble.AutoSize = true;
            this.LblInmueble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInmueble.ForeColor = System.Drawing.Color.Black;
            this.LblInmueble.Location = new System.Drawing.Point(525, 9);
            this.LblInmueble.Name = "LblInmueble";
            this.LblInmueble.Size = new System.Drawing.Size(58, 13);
            this.LblInmueble.TabIndex = 207;
            this.LblInmueble.Text = "Inmueble";
            // 
            // TxtValor
            // 
            this.TxtValor.ForeColor = System.Drawing.Color.Black;
            this.TxtValor.Location = new System.Drawing.Point(537, 48);
            this.TxtValor.Name = "TxtValor";
            this.TxtValor.Size = new System.Drawing.Size(103, 20);
            this.TxtValor.TabIndex = 7;
            this.TxtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtValor_KeyPress);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.BtnElimnar);
            this.panel3.Controls.Add(this.BtnModificar);
            this.panel3.Controls.Add(this.BtnNuevo);
            this.panel3.Controls.Add(this.BtnSalir);
            this.panel3.Controls.Add(this.BtnAdicionar);
            this.panel3.Location = new System.Drawing.Point(721, 187);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(79, 247);
            this.panel3.TabIndex = 219;
            // 
            // BtnElimnar
            // 
            this.BtnElimnar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnElimnar.Location = new System.Drawing.Point(6, 104);
            this.BtnElimnar.Name = "BtnElimnar";
            this.BtnElimnar.Size = new System.Drawing.Size(63, 23);
            this.BtnElimnar.TabIndex = 12;
            this.BtnElimnar.Text = "Eliminar";
            this.BtnElimnar.UseVisualStyleBackColor = true;
            this.BtnElimnar.Visible = false;
            this.BtnElimnar.Click += new System.EventHandler(this.BtnElimnar_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(8, 138);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(63, 23);
            this.BtnSalir.TabIndex = 13;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnAdicionar
            // 
            this.BtnAdicionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdicionar.Location = new System.Drawing.Point(6, 36);
            this.BtnAdicionar.Name = "BtnAdicionar";
            this.BtnAdicionar.Size = new System.Drawing.Size(63, 23);
            this.BtnAdicionar.TabIndex = 10;
            this.BtnAdicionar.Text = "Adicionar";
            this.BtnAdicionar.UseVisualStyleBackColor = true;
            this.BtnAdicionar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // LblValor
            // 
            this.LblValor.AutoSize = true;
            this.LblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblValor.ForeColor = System.Drawing.Color.Black;
            this.LblValor.Location = new System.Drawing.Point(437, 52);
            this.LblValor.Name = "LblValor";
            this.LblValor.Size = new System.Drawing.Size(74, 13);
            this.LblValor.TabIndex = 6;
            this.LblValor.Text = "InteresMora";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(228, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cuota";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.TxtCuota);
            this.panel1.Controls.Add(this.TxtConcepto);
            this.panel1.Controls.Add(this.TxtInmueble);
            this.panel1.Controls.Add(this.TxtNombres);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.LblInmueble);
            this.panel1.Controls.Add(this.TxtValor);
            this.panel1.Controls.Add(this.LblValor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.LblNombres);
            this.panel1.Controls.Add(this.TxtAdjudicacion);
            this.panel1.Controls.Add(this.Lbldjudicacion);
            this.panel1.Location = new System.Drawing.Point(25, 80);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(775, 85);
            this.panel1.TabIndex = 215;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(4, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 209;
            this.label2.Text = "Concepto";
            // 
            // LblNombres
            // 
            this.LblNombres.AutoSize = true;
            this.LblNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombres.ForeColor = System.Drawing.Color.Black;
            this.LblNombres.Location = new System.Drawing.Point(207, 9);
            this.LblNombres.Name = "LblNombres";
            this.LblNombres.Size = new System.Drawing.Size(56, 13);
            this.LblNombres.TabIndex = 2;
            this.LblNombres.Text = "Nombres";
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.ForeColor = System.Drawing.Color.Black;
            this.TxtAdjudicacion.Location = new System.Drawing.Point(90, 5);
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.Size = new System.Drawing.Size(75, 20);
            this.TxtAdjudicacion.TabIndex = 1;
            this.TxtAdjudicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAdjudicacion_KeyPress);
            this.TxtAdjudicacion.Leave += new System.EventHandler(this.TxtAdjudicacion_Leave);
            // 
            // Lbldjudicacion
            // 
            this.Lbldjudicacion.AutoSize = true;
            this.Lbldjudicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbldjudicacion.ForeColor = System.Drawing.Color.Black;
            this.Lbldjudicacion.Location = new System.Drawing.Point(4, 9);
            this.Lbldjudicacion.Name = "Lbldjudicacion";
            this.Lbldjudicacion.Size = new System.Drawing.Size(80, 13);
            this.Lbldjudicacion.TabIndex = 0;
            this.Lbldjudicacion.Text = "Adjudicacion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(13, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 227;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(805, 34);
            this.panel4.TabIndex = 228;
            // 
            // Column1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column1.HeaderText = "Fecha";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 90;
            // 
            // Column12
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column12.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column12.HeaderText = "#";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 70;
            // 
            // Concept
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Concept.DefaultCellStyle = dataGridViewCellStyle5;
            this.Concept.HeaderText = "Concepto";
            this.Concept.Name = "Concept";
            this.Concept.ReadOnly = true;
            this.Concept.Width = 70;
            // 
            // Column15
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column15.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column15.HeaderText = "Cuota";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 120;
            // 
            // Column16
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column16.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column16.HeaderText = "Dmora";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 60;
            // 
            // Column17
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Column17.DefaultCellStyle = dataGridViewCellStyle8;
            this.Column17.HeaderText = "VrMora";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Condonacion
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.Condonacion.DefaultCellStyle = dataGridViewCellStyle9;
            this.Condonacion.HeaderText = "Cond Mora";
            this.Condonacion.Name = "Condonacion";
            this.Condonacion.ReadOnly = true;
            // 
            // TxtNombres
            // 
            this.TxtNombres.AutoSize = true;
            this.TxtNombres.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombres.ForeColor = System.Drawing.Color.Black;
            this.TxtNombres.Location = new System.Drawing.Point(290, 9);
            this.TxtNombres.Name = "TxtNombres";
            this.TxtNombres.Size = new System.Drawing.Size(49, 13);
            this.TxtNombres.TabIndex = 211;
            this.TxtNombres.Text = "Nombres";
            // 
            // TxtInmueble
            // 
            this.TxtInmueble.AutoSize = true;
            this.TxtInmueble.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInmueble.ForeColor = System.Drawing.Color.Black;
            this.TxtInmueble.Location = new System.Drawing.Point(591, 9);
            this.TxtInmueble.Name = "TxtInmueble";
            this.TxtInmueble.Size = new System.Drawing.Size(49, 13);
            this.TxtInmueble.TabIndex = 212;
            this.TxtInmueble.Text = "Nombres";
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.AutoSize = true;
            this.TxtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConcepto.ForeColor = System.Drawing.Color.Black;
            this.TxtConcepto.Location = new System.Drawing.Point(87, 52);
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(49, 13);
            this.TxtConcepto.TabIndex = 213;
            this.TxtConcepto.Text = "Nombres";
            // 
            // TxtCuota
            // 
            this.TxtCuota.AutoSize = true;
            this.TxtCuota.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtCuota.ForeColor = System.Drawing.Color.Black;
            this.TxtCuota.Location = new System.Drawing.Point(274, 52);
            this.TxtCuota.Name = "TxtCuota";
            this.TxtCuota.Size = new System.Drawing.Size(49, 13);
            this.TxtCuota.TabIndex = 214;
            this.TxtCuota.Text = "Nombres";
            // 
            // FrmCondonacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(805, 452);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCondonacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCondonacion";
            this.Load += new System.EventHandler(this.FrmCondonacion_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPagos)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DgvPagos;
        private System.Windows.Forms.Label LblInmueble;
        private System.Windows.Forms.TextBox TxtValor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnAdicionar;
        private System.Windows.Forms.Label LblValor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblNombres;
        private System.Windows.Forms.TextBox TxtAdjudicacion;
        private System.Windows.Forms.Label Lbldjudicacion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnElimnar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concept;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condonacion;
        private System.Windows.Forms.Label TxtCuota;
        private System.Windows.Forms.Label TxtConcepto;
        private System.Windows.Forms.Label TxtInmueble;
        private System.Windows.Forms.Label TxtNombres;
    }
}