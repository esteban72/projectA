namespace CarteraGeneral
{
    partial class FrmCatalogoInmuebles
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbBusquedad = new System.Windows.Forms.ComboBox();
            this.LblCuenta = new System.Windows.Forms.Label();
            this.TxtNombreCompleto = new System.Windows.Forms.TextBox();
            this.DgvTerceros = new System.Windows.Forms.DataGridView();
            this.Inmueble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Villa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Semana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoSemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Temporada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CnsCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTerceros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.LblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(785, 31);
            this.panel2.TabIndex = 76;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 62;
            this.pictureBox1.TabStop = false;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.Black;
            this.LblTitulo.Location = new System.Drawing.Point(193, 5);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(243, 20);
            this.LblTitulo.TabIndex = 59;
            this.LblTitulo.Text = "CATALOGO DE INMUEBLES";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbBusquedad);
            this.panel1.Controls.Add(this.LblCuenta);
            this.panel1.Controls.Add(this.TxtNombreCompleto);
            this.panel1.Location = new System.Drawing.Point(3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 34);
            this.panel1.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(281, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 15);
            this.label1.TabIndex = 77;
            this.label1.Text = "Busquedad";
            // 
            // CmbBusquedad
            // 
            this.CmbBusquedad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBusquedad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbBusquedad.FormattingEnabled = true;
            this.CmbBusquedad.Items.AddRange(new object[] {
            "IdInmueble",
            "Semana",
            "TipoSemana",
            "Villa",
            "Unidad"});
            this.CmbBusquedad.Location = new System.Drawing.Point(100, 4);
            this.CmbBusquedad.Name = "CmbBusquedad";
            this.CmbBusquedad.Size = new System.Drawing.Size(136, 21);
            this.CmbBusquedad.TabIndex = 6;
            // 
            // LblCuenta
            // 
            this.LblCuenta.AutoSize = true;
            this.LblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCuenta.ForeColor = System.Drawing.Color.Black;
            this.LblCuenta.Location = new System.Drawing.Point(18, 7);
            this.LblCuenta.Name = "LblCuenta";
            this.LblCuenta.Size = new System.Drawing.Size(52, 15);
            this.LblCuenta.TabIndex = 5;
            this.LblCuenta.Text = "Campo";
            // 
            // TxtNombreCompleto
            // 
            this.TxtNombreCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreCompleto.Location = new System.Drawing.Point(370, 3);
            this.TxtNombreCompleto.MaxLength = 20;
            this.TxtNombreCompleto.Name = "TxtNombreCompleto";
            this.TxtNombreCompleto.Size = new System.Drawing.Size(160, 22);
            this.TxtNombreCompleto.TabIndex = 4;
            this.TxtNombreCompleto.TextChanged += new System.EventHandler(this.TxtNombreCompleto_TextChanged);
            // 
            // DgvTerceros
            // 
            this.DgvTerceros.AllowUserToAddRows = false;
            this.DgvTerceros.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvTerceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTerceros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Inmueble,
            this.Villa,
            this.Unidad,
            this.Semana,
            this.TipoSemana,
            this.Temporada,
            this.CnsCompra});
            this.DgvTerceros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvTerceros.Location = new System.Drawing.Point(0, 0);
            this.DgvTerceros.Name = "DgvTerceros";
            this.DgvTerceros.Size = new System.Drawing.Size(785, 467);
            this.DgvTerceros.TabIndex = 74;
            this.DgvTerceros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTerceros_CellDoubleClick);
            this.DgvTerceros.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTerceros_CellEnter);
            // 
            // Inmueble
            // 
            this.Inmueble.FillWeight = 42.4441F;
            this.Inmueble.HeaderText = "IdInmueble";
            this.Inmueble.Name = "Inmueble";
            // 
            // Villa
            // 
            this.Villa.FillWeight = 14.43677F;
            this.Villa.HeaderText = "Villa";
            this.Villa.Name = "Villa";
            // 
            // Unidad
            // 
            this.Unidad.FillWeight = 111.5262F;
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            // 
            // Semana
            // 
            this.Semana.FillWeight = 77.7858F;
            this.Semana.HeaderText = "Semana";
            this.Semana.Name = "Semana";
            // 
            // TipoSemana
            // 
            this.TipoSemana.FillWeight = 253.8071F;
            this.TipoSemana.HeaderText = "TipoSemana";
            this.TipoSemana.Name = "TipoSemana";
            // 
            // Temporada
            // 
            this.Temporada.HeaderText = "Temporada";
            this.Temporada.Name = "Temporada";
            // 
            // CnsCompra
            // 
            this.CnsCompra.HeaderText = "CnsCompra";
            this.CnsCompra.Name = "CnsCompra";
            this.CnsCompra.ReadOnly = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 31);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvTerceros);
            this.splitContainer1.Size = new System.Drawing.Size(785, 510);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.TabIndex = 77;
            // 
            // FrmCatalogoInmuebles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 541);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmCatalogoInmuebles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCatalogoInmuebles";
            this.Load += new System.EventHandler(this.FrmCatalogoInmuebles_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTerceros)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblCuenta;
        private System.Windows.Forms.TextBox TxtNombreCompleto;
        private System.Windows.Forms.DataGridView DgvTerceros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbBusquedad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inmueble;
        private System.Windows.Forms.DataGridViewTextBoxColumn Villa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Semana;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn Temporada;
        private System.Windows.Forms.DataGridViewTextBoxColumn CnsCompra;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}