namespace CarteraGeneral
{
    partial class FrmInmuebles
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
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.PnlSuperior = new System.Windows.Forms.Panel();
            this.CmbTipodeSemana = new System.Windows.Forms.ComboBox();
            this.CmbTemporada = new System.Windows.Forms.ComboBox();
            this.CmbEstado = new System.Windows.Forms.ComboBox();
            this.CmbSemana = new System.Windows.Forms.ComboBox();
            this.CmbUnidad = new System.Windows.Forms.ComboBox();
            this.CmbVilla = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtInmueble = new System.Windows.Forms.TextBox();
            this.LblInmeble = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnEscape = new System.Windows.Forms.Button();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.PanelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.PnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitulo
            // 
            this.PanelTitulo.Controls.Add(this.pictureBox1);
            this.PanelTitulo.Controls.Add(this.LblTitulo);
            this.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitulo.Location = new System.Drawing.Point(0, 0);
            this.PanelTitulo.Name = "PanelTitulo";
            this.PanelTitulo.Size = new System.Drawing.Size(684, 28);
            this.PanelTitulo.TabIndex = 223;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(6, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 216;
            this.pictureBox1.TabStop = false;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.Black;
            this.LblTitulo.Location = new System.Drawing.Point(221, 2);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(243, 24);
            this.LblTitulo.TabIndex = 215;
            this.LblTitulo.Text = "ADICIONAR INMUEBLES";
            // 
            // PnlSuperior
            // 
            this.PnlSuperior.BackColor = System.Drawing.SystemColors.Control;
            this.PnlSuperior.Controls.Add(this.CmbTipodeSemana);
            this.PnlSuperior.Controls.Add(this.CmbTemporada);
            this.PnlSuperior.Controls.Add(this.CmbEstado);
            this.PnlSuperior.Controls.Add(this.CmbSemana);
            this.PnlSuperior.Controls.Add(this.CmbUnidad);
            this.PnlSuperior.Controls.Add(this.CmbVilla);
            this.PnlSuperior.Controls.Add(this.label7);
            this.PnlSuperior.Controls.Add(this.label2);
            this.PnlSuperior.Controls.Add(this.label6);
            this.PnlSuperior.Controls.Add(this.label4);
            this.PnlSuperior.Controls.Add(this.label3);
            this.PnlSuperior.Controls.Add(this.DtpFecha);
            this.PnlSuperior.Controls.Add(this.label1);
            this.PnlSuperior.Controls.Add(this.label5);
            this.PnlSuperior.Controls.Add(this.TxtInmueble);
            this.PnlSuperior.Controls.Add(this.LblInmeble);
            this.PnlSuperior.Location = new System.Drawing.Point(0, 55);
            this.PnlSuperior.Name = "PnlSuperior";
            this.PnlSuperior.Size = new System.Drawing.Size(666, 245);
            this.PnlSuperior.TabIndex = 221;
            // 
            // CmbTipodeSemana
            // 
            this.CmbTipodeSemana.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbTipodeSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipodeSemana.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbTipodeSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTipodeSemana.FormattingEnabled = true;
            this.CmbTipodeSemana.Items.AddRange(new object[] {
            "SISTEMATICA",
            "PREFERENTE"});
            this.CmbTipodeSemana.Location = new System.Drawing.Point(166, 83);
            this.CmbTipodeSemana.Name = "CmbTipodeSemana";
            this.CmbTipodeSemana.Size = new System.Drawing.Size(133, 21);
            this.CmbTipodeSemana.TabIndex = 3;
            this.CmbTipodeSemana.Enter += new System.EventHandler(this.CmbRipodeSemana_Enter);
            this.CmbTipodeSemana.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbRipodeSemana_KeyPress);
            this.CmbTipodeSemana.Leave += new System.EventHandler(this.CmbRipodeSemana_Leave);
            // 
            // CmbTemporada
            // 
            this.CmbTemporada.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbTemporada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTemporada.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbTemporada.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbTemporada.FormattingEnabled = true;
            this.CmbTemporada.Items.AddRange(new object[] {
            "ALTA",
            "MEDIA",
            "SUPER ALTA"});
            this.CmbTemporada.Location = new System.Drawing.Point(166, 191);
            this.CmbTemporada.Name = "CmbTemporada";
            this.CmbTemporada.Size = new System.Drawing.Size(129, 21);
            this.CmbTemporada.TabIndex = 7;
            this.CmbTemporada.Enter += new System.EventHandler(this.CmbTemporada_Enter);
            this.CmbTemporada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbTemporada_KeyPress);
            this.CmbTemporada.Leave += new System.EventHandler(this.CmbTemporada_Leave);
            // 
            // CmbEstado
            // 
            this.CmbEstado.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEstado.FormattingEnabled = true;
            this.CmbEstado.Items.AddRange(new object[] {
            "Libre",
            "Adjudicado",
            "Reservado"});
            this.CmbEstado.Location = new System.Drawing.Point(501, 191);
            this.CmbEstado.Name = "CmbEstado";
            this.CmbEstado.Size = new System.Drawing.Size(133, 21);
            this.CmbEstado.TabIndex = 8;
            this.CmbEstado.Enter += new System.EventHandler(this.CmbEstado_Enter);
            this.CmbEstado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbEstado_KeyPress);
            this.CmbEstado.Leave += new System.EventHandler(this.CmbEstado_Leave);
            // 
            // CmbSemana
            // 
            this.CmbSemana.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbSemana.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSemana.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbSemana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbSemana.FormattingEnabled = true;
            this.CmbSemana.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "39",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52"});
            this.CmbSemana.Location = new System.Drawing.Point(501, 137);
            this.CmbSemana.Name = "CmbSemana";
            this.CmbSemana.Size = new System.Drawing.Size(133, 21);
            this.CmbSemana.TabIndex = 6;
            this.CmbSemana.Enter += new System.EventHandler(this.CmbSemana_Enter);
            this.CmbSemana.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbSemana_KeyPress);
            this.CmbSemana.Leave += new System.EventHandler(this.CmbSemana_Leave);
            // 
            // CmbUnidad
            // 
            this.CmbUnidad.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbUnidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbUnidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUnidad.FormattingEnabled = true;
            this.CmbUnidad.Items.AddRange(new object[] {
            "101",
            "102",
            "103",
            "201",
            "202",
            "203",
            "301",
            "302",
            "303"});
            this.CmbUnidad.Location = new System.Drawing.Point(170, 137);
            this.CmbUnidad.Name = "CmbUnidad";
            this.CmbUnidad.Size = new System.Drawing.Size(129, 21);
            this.CmbUnidad.TabIndex = 5;
            this.CmbUnidad.Enter += new System.EventHandler(this.CmbUnidad_Enter);
            this.CmbUnidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbUnidad_KeyPress);
            this.CmbUnidad.Leave += new System.EventHandler(this.CmbUnidad_Leave);
            // 
            // CmbVilla
            // 
            this.CmbVilla.BackColor = System.Drawing.Color.Gainsboro;
            this.CmbVilla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbVilla.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbVilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbVilla.FormattingEnabled = true;
            this.CmbVilla.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.CmbVilla.Location = new System.Drawing.Point(501, 83);
            this.CmbVilla.Name = "CmbVilla";
            this.CmbVilla.Size = new System.Drawing.Size(133, 21);
            this.CmbVilla.TabIndex = 4;
            this.CmbVilla.Enter += new System.EventHandler(this.CmbVilla_Enter);
            this.CmbVilla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CmbVilla_KeyPress);
            this.CmbVilla.Leave += new System.EventHandler(this.CmbVilla_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(402, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 15);
            this.label7.TabIndex = 215;
            this.label7.Text = "Estado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 213;
            this.label2.Text = "Temporada";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 15);
            this.label6.TabIndex = 211;
            this.label6.Text = "Unidad";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(402, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 209;
            this.label4.Text = "Semana";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(402, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 15);
            this.label3.TabIndex = 208;
            this.label3.Text = "Villa";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(166, 28);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(129, 22);
            this.DtpFecha.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 133;
            this.label1.Text = "Tipo de Semana";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 128;
            this.label5.Text = "Fecha ";
            // 
            // TxtInmueble
            // 
            this.TxtInmueble.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtInmueble.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtInmueble.Location = new System.Drawing.Point(501, 29);
            this.TxtInmueble.MaxLength = 30;
            this.TxtInmueble.Name = "TxtInmueble";
            this.TxtInmueble.ReadOnly = true;
            this.TxtInmueble.Size = new System.Drawing.Size(133, 21);
            this.TxtInmueble.TabIndex = 2;
            this.TxtInmueble.Enter += new System.EventHandler(this.TxtInmueble_Enter);
            this.TxtInmueble.Leave += new System.EventHandler(this.TxtInmueble_Leave);
            // 
            // LblInmeble
            // 
            this.LblInmeble.AutoSize = true;
            this.LblInmeble.BackColor = System.Drawing.Color.Transparent;
            this.LblInmeble.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInmeble.Location = new System.Drawing.Point(402, 32);
            this.LblInmeble.Name = "LblInmeble";
            this.LblInmeble.Size = new System.Drawing.Size(62, 15);
            this.LblInmeble.TabIndex = 127;
            this.LblInmeble.Text = "Inmueble:";
            // 
            // BtnOk
            // 
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.Location = new System.Drawing.Point(405, 323);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(77, 24);
            this.BtnOk.TabIndex = 219;
            this.BtnOk.Text = "Aceptar";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            this.BtnOk.Enter += new System.EventHandler(this.BtnOk_Enter);
            this.BtnOk.Leave += new System.EventHandler(this.BtnOk_Leave);
            // 
            // BtnEscape
            // 
            this.BtnEscape.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnEscape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEscape.Location = new System.Drawing.Point(508, 323);
            this.BtnEscape.Name = "BtnEscape";
            this.BtnEscape.Size = new System.Drawing.Size(64, 24);
            this.BtnEscape.TabIndex = 220;
            this.BtnEscape.Text = "Salir";
            this.BtnEscape.UseVisualStyleBackColor = true;
            this.BtnEscape.Click += new System.EventHandler(this.BtnEscape_Click);
            this.BtnEscape.Enter += new System.EventHandler(this.BtnEscape_Enter);
            this.BtnEscape.Leave += new System.EventHandler(this.BtnEscape_Leave);
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.Location = new System.Drawing.Point(602, 323);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(64, 24);
            this.BtnNuevo.TabIndex = 222;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Visible = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            this.BtnNuevo.Enter += new System.EventHandler(this.BtnNuevo_Enter);
            this.BtnNuevo.Leave += new System.EventHandler(this.BtnNuevo_Leave);
            // 
            // FrmInmuebles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 380);
            this.Controls.Add(this.PanelTitulo);
            this.Controls.Add(this.PnlSuperior);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.BtnEscape);
            this.Controls.Add(this.BtnNuevo);
            this.Name = "FrmInmuebles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inmuebles";
            this.Load += new System.EventHandler(this.FrmInmuebles_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.PnlSuperior.ResumeLayout(false);
            this.PnlSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel PnlSuperior;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox TxtInmueble;
        private System.Windows.Forms.Label LblInmeble;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnEscape;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CmbTipodeSemana;
        private System.Windows.Forms.ComboBox CmbTemporada;
        private System.Windows.Forms.ComboBox CmbEstado;
        private System.Windows.Forms.ComboBox CmbSemana;
        private System.Windows.Forms.ComboBox CmbUnidad;
        private System.Windows.Forms.ComboBox CmbVilla;
    }
}