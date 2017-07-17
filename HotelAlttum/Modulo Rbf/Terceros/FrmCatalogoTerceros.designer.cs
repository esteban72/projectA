namespace CarteraGeneral
{
    partial class FrmCatalogoTerceros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCatalogoTerceros));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnAddTercero = new System.Windows.Forms.Button();
            this.LblCuenta = new System.Windows.Forms.Label();
            this.TxtNombreCompleto = new System.Windows.Forms.TextBox();
            this.DgvTerceros = new System.Windows.Forms.DataGridView();
            this.IdTercero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTerceros)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.BtnAddTercero);
            this.panel1.Controls.Add(this.LblCuenta);
            this.panel1.Controls.Add(this.TxtNombreCompleto);
            this.panel1.Location = new System.Drawing.Point(28, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(522, 34);
            this.panel1.TabIndex = 72;
            // 
            // BtnAddTercero
            // 
            this.BtnAddTercero.BackColor = System.Drawing.Color.Transparent;
            this.BtnAddTercero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnAddTercero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddTercero.Location = new System.Drawing.Point(407, 9);
            this.BtnAddTercero.Name = "BtnAddTercero";
            this.BtnAddTercero.Size = new System.Drawing.Size(25, 20);
            this.BtnAddTercero.TabIndex = 84;
            this.BtnAddTercero.UseVisualStyleBackColor = false;
            this.BtnAddTercero.Click += new System.EventHandler(this.BtnAddTercero_Click);
            // 
            // LblCuenta
            // 
            this.LblCuenta.AutoSize = true;
            this.LblCuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCuenta.ForeColor = System.Drawing.Color.Black;
            this.LblCuenta.Location = new System.Drawing.Point(7, 6);
            this.LblCuenta.Name = "LblCuenta";
            this.LblCuenta.Size = new System.Drawing.Size(58, 15);
            this.LblCuenta.TabIndex = 5;
            this.LblCuenta.Text = "Nombre";
            // 
            // TxtNombreCompleto
            // 
            this.TxtNombreCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreCompleto.Location = new System.Drawing.Point(92, 6);
            this.TxtNombreCompleto.MaxLength = 20;
            this.TxtNombreCompleto.Name = "TxtNombreCompleto";
            this.TxtNombreCompleto.Size = new System.Drawing.Size(309, 22);
            this.TxtNombreCompleto.TabIndex = 4;
            this.TxtNombreCompleto.TextChanged += new System.EventHandler(this.TxtNombreProductos_TextChanged);
            // 
            // DgvTerceros
            // 
            this.DgvTerceros.AllowUserToAddRows = false;
            this.DgvTerceros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvTerceros.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DgvTerceros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvTerceros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdTercero,
            this.NombreCompleto});
            this.DgvTerceros.Location = new System.Drawing.Point(28, 110);
            this.DgvTerceros.Name = "DgvTerceros";
            this.DgvTerceros.Size = new System.Drawing.Size(522, 389);
            this.DgvTerceros.TabIndex = 71;
            this.DgvTerceros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTerceros_CellDoubleClick);
            this.DgvTerceros.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTerceros_CellEnter);
            this.DgvTerceros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DgvTerceros_KeyDown);
            // 
            // IdTercero
            // 
            this.IdTercero.HeaderText = "IdTercero";
            this.IdTercero.Name = "IdTercero";
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.HeaderText = "Nombre Completo";
            this.NombreCompleto.Name = "NombreCompleto";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.LblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(579, 31);
            this.panel2.TabIndex = 73;
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
            this.LblTitulo.Location = new System.Drawing.Point(171, 5);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(237, 20);
            this.LblTitulo.TabIndex = 59;
            this.LblTitulo.Text = "CATALOGO DE TERCEROS";
            // 
            // FrmCatalogoTerceros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 511);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DgvTerceros);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCatalogoTerceros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CatalogoTerceros";
            this.Activated += new System.EventHandler(this.FrmCatalogoTerceros_Activated);
            this.Load += new System.EventHandler(this.FrmCatalogoTerceros_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvTerceros)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblCuenta;
        private System.Windows.Forms.TextBox TxtNombreCompleto;
        private System.Windows.Forms.DataGridView DgvTerceros;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdTercero;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.Button BtnAddTercero;
    }
}