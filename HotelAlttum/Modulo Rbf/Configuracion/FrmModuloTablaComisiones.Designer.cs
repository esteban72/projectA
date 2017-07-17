namespace CarteraGeneral
{
    partial class FrmModuloTablaComisiones
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdTercero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Asesor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comision2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recaudo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anticipo1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recaudo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anticipo2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnMod = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnElm = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnCns = new System.Windows.Forms.ToolStripMenuItem();
            this.BtnExportar = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblNumRegistro = new System.Windows.Forms.Label();
            this.LblRegistros = new System.Windows.Forms.Label();
            this.LblSumaComision = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LblComMonterrey = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 563);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1326, 22);
            this.statusStrip1.TabIndex = 271;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DgvListado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
            this.DgvListado.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.NombreCargo,
            this.IdTercero,
            this.Asesor,
            this.Comision,
            this.Comision2,
            this.Recaudo1,
            this.Anticipo1,
            this.Recaudo2,
            this.Anticipo2});
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListado.DefaultCellStyle = dataGridViewCellStyle19;
            this.DgvListado.GridColor = System.Drawing.Color.Black;
            this.DgvListado.Location = new System.Drawing.Point(35, 41);
            this.DgvListado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.ReadOnly = true;
            this.DgvListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.DgvListado.Size = new System.Drawing.Size(1155, 462);
            this.DgvListado.TabIndex = 267;
            this.DgvListado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellEnter);
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 50;
            // 
            // NombreCargo
            // 
            this.NombreCargo.HeaderText = "NombreCargo";
            this.NombreCargo.Name = "NombreCargo";
            this.NombreCargo.ReadOnly = true;
            this.NombreCargo.Width = 150;
            // 
            // IdTercero
            // 
            this.IdTercero.HeaderText = "IdTercero";
            this.IdTercero.Name = "IdTercero";
            this.IdTercero.ReadOnly = true;
            // 
            // Asesor
            // 
            this.Asesor.HeaderText = "Asesor";
            this.Asesor.Name = "Asesor";
            this.Asesor.ReadOnly = true;
            this.Asesor.Width = 250;
            // 
            // Comision
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = "0";
            this.Comision.DefaultCellStyle = dataGridViewCellStyle13;
            this.Comision.HeaderText = "Comision";
            this.Comision.Name = "Comision";
            this.Comision.ReadOnly = true;
            this.Comision.Width = 80;
            // 
            // Comision2
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.Comision2.DefaultCellStyle = dataGridViewCellStyle14;
            this.Comision2.HeaderText = "ComMonterrey";
            this.Comision2.Name = "Comision2";
            this.Comision2.ReadOnly = true;
            // 
            // Recaudo1
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N2";
            dataGridViewCellStyle15.NullValue = "0";
            this.Recaudo1.DefaultCellStyle = dataGridViewCellStyle15;
            this.Recaudo1.HeaderText = "Recaudo1";
            this.Recaudo1.Name = "Recaudo1";
            this.Recaudo1.ReadOnly = true;
            // 
            // Anticipo1
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N2";
            dataGridViewCellStyle16.NullValue = "0";
            this.Anticipo1.DefaultCellStyle = dataGridViewCellStyle16;
            this.Anticipo1.HeaderText = "Anticipo1";
            this.Anticipo1.Name = "Anticipo1";
            this.Anticipo1.ReadOnly = true;
            // 
            // Recaudo2
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Recaudo2.DefaultCellStyle = dataGridViewCellStyle17;
            this.Recaudo2.HeaderText = "Recaudo2";
            this.Recaudo2.Name = "Recaudo2";
            this.Recaudo2.ReadOnly = true;
            // 
            // Anticipo2
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "N2";
            dataGridViewCellStyle18.NullValue = "0";
            this.Anticipo2.DefaultCellStyle = dataGridViewCellStyle18;
            this.Anticipo2.HeaderText = "Anticipo2";
            this.Anticipo2.Name = "Anticipo2";
            this.Anticipo2.ReadOnly = true;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Image = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(57, 20);
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1326, 35);
            this.panel1.TabIndex = 270;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.BtnMod,
            this.BtnElm,
            this.BtnCns,
            this.BtnExportar,
            this.BtnSalir});
            this.menuStrip1.Location = new System.Drawing.Point(161, 3);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(508, 24);
            this.menuStrip1.TabIndex = 264;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::CarteraGeneral.Properties.Resources.add_48;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 20);
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // BtnMod
            // 
            this.BtnMod.Image = global::CarteraGeneral.Properties.Resources._1402294180_Modify;
            this.BtnMod.Name = "BtnMod";
            this.BtnMod.Size = new System.Drawing.Size(86, 20);
            this.BtnMod.Text = "Modificar";
            this.BtnMod.Click += new System.EventHandler(this.BtnMod_Click);
            // 
            // BtnElm
            // 
            this.BtnElm.Image = global::CarteraGeneral.Properties.Resources._14;
            this.BtnElm.Name = "BtnElm";
            this.BtnElm.Size = new System.Drawing.Size(78, 20);
            this.BtnElm.Text = "Eliminar";
            this.BtnElm.Click += new System.EventHandler(this.BtnElm_Click);
            // 
            // BtnCns
            // 
            this.BtnCns.Image = global::CarteraGeneral.Properties.Resources._14;
            this.BtnCns.Name = "BtnCns";
            this.BtnCns.Size = new System.Drawing.Size(86, 20);
            this.BtnCns.Text = "Consultar";
            this.BtnCns.Click += new System.EventHandler(this.BtnCns_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Image = global::CarteraGeneral.Properties.Resources._1402297290_Excel;
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(107, 20);
            this.BtnExportar.Text = "Exportar Excel";
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 217;
            this.pictureBox1.TabStop = false;
            // 
            // LblNumRegistro
            // 
            this.LblNumRegistro.AutoSize = true;
            this.LblNumRegistro.Location = new System.Drawing.Point(44, 513);
            this.LblNumRegistro.Name = "LblNumRegistro";
            this.LblNumRegistro.Size = new System.Drawing.Size(91, 13);
            this.LblNumRegistro.TabIndex = 268;
            this.LblNumRegistro.Text = "Numero Registros";
            // 
            // LblRegistros
            // 
            this.LblRegistros.AutoSize = true;
            this.LblRegistros.Location = new System.Drawing.Point(158, 513);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(13, 13);
            this.LblRegistros.TabIndex = 272;
            this.LblRegistros.Text = "0";
            // 
            // LblSumaComision
            // 
            this.LblSumaComision.AutoSize = true;
            this.LblSumaComision.Location = new System.Drawing.Point(158, 535);
            this.LblSumaComision.Name = "LblSumaComision";
            this.LblSumaComision.Size = new System.Drawing.Size(13, 13);
            this.LblSumaComision.TabIndex = 274;
            this.LblSumaComision.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 273;
            this.label2.Text = "Suma Comision";
            // 
            // LblComMonterrey
            // 
            this.LblComMonterrey.AutoSize = true;
            this.LblComMonterrey.Location = new System.Drawing.Point(395, 535);
            this.LblComMonterrey.Name = "LblComMonterrey";
            this.LblComMonterrey.Size = new System.Drawing.Size(13, 13);
            this.LblComMonterrey.TabIndex = 276;
            this.LblComMonterrey.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(244, 535);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 275;
            this.label3.Text = "Suma Comision Monterrey";
            // 
            // FrmModuloTablaComisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 585);
            this.Controls.Add(this.LblComMonterrey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LblSumaComision);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblRegistros);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.DgvListado);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblNumRegistro);
            this.Name = "FrmModuloTablaComisiones";
            this.Text = "MODULO TABLA DE COMISIONES";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmModuloTablaComisiones_Activated);
            this.Load += new System.EventHandler(this.FrmModuloTablaComisiones_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.ToolStripMenuItem BtnSalir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnAdd;
        private System.Windows.Forms.ToolStripMenuItem BtnMod;
        private System.Windows.Forms.ToolStripMenuItem BtnElm;
        private System.Windows.Forms.ToolStripMenuItem BtnCns;
        private System.Windows.Forms.ToolStripMenuItem BtnExportar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblNumRegistro;
        private System.Windows.Forms.Label LblRegistros;
        private System.Windows.Forms.Label LblSumaComision;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTercero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Asesor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comision2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recaudo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anticipo1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Recaudo2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anticipo2;
        private System.Windows.Forms.Label LblComMonterrey;
        private System.Windows.Forms.Label label3;
    }
}