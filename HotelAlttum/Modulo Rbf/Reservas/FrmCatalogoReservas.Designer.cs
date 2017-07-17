namespace CarteraGeneral
{
    partial class FrmCatalogoReservas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblCuenta = new System.Windows.Forms.Label();
            this.TxtNombreCompleto = new System.Windows.Forms.TextBox();
            this.DgvListado = new System.Windows.Forms.DataGridView();
            this.IdReserva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoSemana = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FchCont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VrContrato = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inmueble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tercero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.LblRegistros = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.LblTitulo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 31);
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
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.Black;
            this.LblTitulo.Location = new System.Drawing.Point(270, 5);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(362, 20);
            this.LblTitulo.TabIndex = 59;
            this.LblTitulo.Text = "RESERVAS PENDIENTES DE ADJUDICAR";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblCuenta);
            this.panel1.Controls.Add(this.TxtNombreCompleto);
            this.panel1.Location = new System.Drawing.Point(35, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(945, 34);
            this.panel1.TabIndex = 75;
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
            this.TxtNombreCompleto.TextChanged += new System.EventHandler(this.TxtNombreCompleto_TextChanged);
            // 
            // DgvListado
            // 
            this.DgvListado.AllowUserToAddRows = false;
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
            this.IdReserva,
            this.TipoSemana,
            this.FchCont,
            this.VrContrato,
            this.Inmueble,
            this.Tercero,
            this.Cliente});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvListado.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvListado.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DgvListado.Location = new System.Drawing.Point(35, 77);
            this.DgvListado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DgvListado.Name = "DgvListado";
            this.DgvListado.ReadOnly = true;
            this.DgvListado.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvListado.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvListado.Size = new System.Drawing.Size(945, 323);
            this.DgvListado.TabIndex = 77;
            this.DgvListado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellDoubleClick);
            this.DgvListado.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvListado_CellEnter);
            // 
            // IdReserva
            // 
            this.IdReserva.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.IdReserva.DefaultCellStyle = dataGridViewCellStyle3;
            this.IdReserva.FillWeight = 43.94267F;
            this.IdReserva.HeaderText = "IdReserva";
            this.IdReserva.MaxInputLength = 12;
            this.IdReserva.Name = "IdReserva";
            this.IdReserva.ReadOnly = true;
            this.IdReserva.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdReserva.Width = 80;
            // 
            // TipoSemana
            // 
            this.TipoSemana.HeaderText = "TipoSemana";
            this.TipoSemana.Name = "TipoSemana";
            this.TipoSemana.ReadOnly = true;
            this.TipoSemana.Width = 140;
            // 
            // FchCont
            // 
            this.FchCont.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.FchCont.DefaultCellStyle = dataGridViewCellStyle4;
            this.FchCont.FillWeight = 94.42664F;
            this.FchCont.HeaderText = "FchContra";
            this.FchCont.MaxInputLength = 80;
            this.FchCont.Name = "FchCont";
            this.FchCont.ReadOnly = true;
            this.FchCont.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FchCont.Width = 90;
            // 
            // VrContrato
            // 
            this.VrContrato.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.VrContrato.DefaultCellStyle = dataGridViewCellStyle5;
            this.VrContrato.FillWeight = 162.4366F;
            this.VrContrato.HeaderText = "VrContrato";
            this.VrContrato.MaxInputLength = 12;
            this.VrContrato.Name = "VrContrato";
            this.VrContrato.ReadOnly = true;
            this.VrContrato.Width = 120;
            // 
            // Inmueble
            // 
            this.Inmueble.FillWeight = 63.49206F;
            this.Inmueble.HeaderText = "Inmueble";
            this.Inmueble.MaxInputLength = 12;
            this.Inmueble.Name = "Inmueble";
            this.Inmueble.ReadOnly = true;
            this.Inmueble.Width = 80;
            // 
            // Tercero
            // 
            this.Tercero.HeaderText = "Tercero";
            this.Tercero.Name = "Tercero";
            this.Tercero.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Cliente.DefaultCellStyle = dataGridViewCellStyle6;
            this.Cliente.FillWeight = 99.19415F;
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.MaxInputLength = 1000;
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            this.Cliente.Width = 280;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 430);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 78;
            this.label1.Text = "Num Registros";
            // 
            // LblRegistros
            // 
            this.LblRegistros.AutoSize = true;
            this.LblRegistros.Location = new System.Drawing.Point(160, 430);
            this.LblRegistros.Name = "LblRegistros";
            this.LblRegistros.Size = new System.Drawing.Size(13, 13);
            this.LblRegistros.TabIndex = 79;
            this.LblRegistros.Text = "0";
            // 
            // FrmCatalogoReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 478);
            this.Controls.Add(this.LblRegistros);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DgvListado);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FrmCatalogoReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCatalogoReservas";
            this.Activated += new System.EventHandler(this.FrmCatalogoReservas_Activated);
            this.Load += new System.EventHandler(this.FrmCatalogoReservas_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView DgvListado;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdReserva;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoSemana;
        private System.Windows.Forms.DataGridViewTextBoxColumn FchCont;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrContrato;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inmueble;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tercero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblRegistros;
        private System.Windows.Forms.Label LblCuenta;
        private System.Windows.Forms.TextBox TxtNombreCompleto;
    }
}