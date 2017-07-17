namespace CarteraGeneral
{
    partial class FrmSeguimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSeguimiento));
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.CmbAccion = new System.Windows.Forms.ComboBox();
            this.RtBCompromiso = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DtpFechaCompro = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtInmueble = new System.Windows.Forms.TextBox();
            this.LblInmuebleç = new System.Windows.Forms.Label();
            this.TxtTitular = new System.Windows.Forms.TextBox();
            this.LblTitular = new System.Windows.Forms.Label();
            this.TxtAdjudicacion = new System.Windows.Forms.TextBox();
            this.LblAdjudicacion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(169, 334);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(73, 28);
            this.BtnSalir.TabIndex = 220;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(37, 334);
            this.BtnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(73, 28);
            this.BtnAceptar.TabIndex = 219;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // CmbAccion
            // 
            this.CmbAccion.FormattingEnabled = true;
            this.CmbAccion.Items.AddRange(new object[] {
            "1. LLAMADA",
            "2. MENSAJE",
            "3. CARTA 1",
            "4. CARTA 2",
            "5. CARTA 3",
            "6. CARTA 4",
            "7. CARTA ESPECIAL",
            "8. PROPUESTA CLIENTE",
            "9.  SIN CONTACTO ",
            "10 . ILOCALIZADO",
            "11. SEGUIMIENTO",
            "12. REVISION COMITE ",
            "13.E-MAIL"});
            this.CmbAccion.Location = new System.Drawing.Point(169, 158);
            this.CmbAccion.Name = "CmbAccion";
            this.CmbAccion.Size = new System.Drawing.Size(100, 21);
            this.CmbAccion.TabIndex = 214;
            // 
            // RtBCompromiso
            // 
            this.RtBCompromiso.Location = new System.Drawing.Point(169, 185);
            this.RtBCompromiso.Name = "RtBCompromiso";
            this.RtBCompromiso.Size = new System.Drawing.Size(174, 96);
            this.RtBCompromiso.TabIndex = 216;
            this.RtBCompromiso.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(119, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(252, 20);
            this.label3.TabIndex = 224;
            this.label3.Text = "SEGUIMIENTO DE CARTERA";
            // 
            // DtpFechaCompro
            // 
            this.DtpFechaCompro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaCompro.Location = new System.Drawing.Point(165, 288);
            this.DtpFechaCompro.Name = "DtpFechaCompro";
            this.DtpFechaCompro.Size = new System.Drawing.Size(100, 20);
            this.DtpFechaCompro.TabIndex = 217;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 223;
            this.label2.Text = "FechaCompromiso";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 222;
            this.label1.Text = "Compromiso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 221;
            this.label4.Text = "Accion";
            // 
            // TxtInmueble
            // 
            this.TxtInmueble.Location = new System.Drawing.Point(169, 126);
            this.TxtInmueble.Name = "TxtInmueble";
            this.TxtInmueble.ReadOnly = true;
            this.TxtInmueble.Size = new System.Drawing.Size(100, 20);
            this.TxtInmueble.TabIndex = 227;
            // 
            // LblInmuebleç
            // 
            this.LblInmuebleç.AutoSize = true;
            this.LblInmuebleç.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblInmuebleç.Location = new System.Drawing.Point(35, 126);
            this.LblInmuebleç.Name = "LblInmuebleç";
            this.LblInmuebleç.Size = new System.Drawing.Size(58, 13);
            this.LblInmuebleç.TabIndex = 218;
            this.LblInmuebleç.Text = "Inmueble";
            // 
            // TxtTitular
            // 
            this.TxtTitular.Location = new System.Drawing.Point(169, 96);
            this.TxtTitular.Name = "TxtTitular";
            this.TxtTitular.ReadOnly = true;
            this.TxtTitular.Size = new System.Drawing.Size(174, 20);
            this.TxtTitular.TabIndex = 226;
            // 
            // LblTitular
            // 
            this.LblTitular.AutoSize = true;
            this.LblTitular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitular.Location = new System.Drawing.Point(35, 96);
            this.LblTitular.Name = "LblTitular";
            this.LblTitular.Size = new System.Drawing.Size(43, 13);
            this.LblTitular.TabIndex = 215;
            this.LblTitular.Text = "Titular";
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.Location = new System.Drawing.Point(169, 66);
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.ReadOnly = true;
            this.TxtAdjudicacion.Size = new System.Drawing.Size(100, 20);
            this.TxtAdjudicacion.TabIndex = 225;
            // 
            // LblAdjudicacion
            // 
            this.LblAdjudicacion.AutoSize = true;
            this.LblAdjudicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAdjudicacion.Location = new System.Drawing.Point(35, 66);
            this.LblAdjudicacion.Name = "LblAdjudicacion";
            this.LblAdjudicacion.Size = new System.Drawing.Size(80, 13);
            this.LblAdjudicacion.TabIndex = 213;
            this.LblAdjudicacion.Text = "Adjudicacion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(2, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 228;
            this.pictureBox1.TabStop = false;
            // 
            // FrmSeguimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(407, 373);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.CmbAccion);
            this.Controls.Add(this.RtBCompromiso);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DtpFechaCompro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtInmueble);
            this.Controls.Add(this.LblInmuebleç);
            this.Controls.Add(this.TxtTitular);
            this.Controls.Add(this.LblTitular);
            this.Controls.Add(this.TxtAdjudicacion);
            this.Controls.Add(this.LblAdjudicacion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSeguimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSeguimiento";
            this.Load += new System.EventHandler(this.FrmSeguimiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.ComboBox CmbAccion;
        private System.Windows.Forms.RichTextBox RtBCompromiso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker DtpFechaCompro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtInmueble;
        private System.Windows.Forms.Label LblInmuebleç;
        private System.Windows.Forms.TextBox TxtTitular;
        private System.Windows.Forms.Label LblTitular;
        private System.Windows.Forms.TextBox TxtAdjudicacion;
        private System.Windows.Forms.Label LblAdjudicacion;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}