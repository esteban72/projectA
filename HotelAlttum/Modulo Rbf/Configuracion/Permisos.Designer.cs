namespace CarteraGeneral
{
    partial class Permisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Permisos));
            this.DgvPermisos = new System.Windows.Forms.DataGridView();
            this.Modulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adicionar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.PnlDatos = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.ChbMarcar = new System.Windows.Forms.CheckBox();
            this.TxtConfClave = new System.Windows.Forms.TextBox();
            this.LblConClave = new System.Windows.Forms.Label();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.LblClave = new System.Windows.Forms.Label();
            this.TxtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnEscape = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPermisos)).BeginInit();
            this.panel1.SuspendLayout();
            this.PnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvPermisos
            // 
            this.DgvPermisos.AllowUserToAddRows = false;
            this.DgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPermisos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Modulo,
            this.NombreModulo,
            this.Adicionar,
            this.Modificar,
            this.Eliminar});
            this.DgvPermisos.Location = new System.Drawing.Point(82, 139);
            this.DgvPermisos.Name = "DgvPermisos";
            this.DgvPermisos.Size = new System.Drawing.Size(706, 500);
            this.DgvPermisos.TabIndex = 0;
            // 
            // Modulo
            // 
            this.Modulo.HeaderText = "Modulo";
            this.Modulo.Name = "Modulo";
            this.Modulo.ReadOnly = true;
            // 
            // NombreModulo
            // 
            this.NombreModulo.HeaderText = "Nombre";
            this.NombreModulo.Name = "NombreModulo";
            this.NombreModulo.ReadOnly = true;
            this.NombreModulo.Width = 250;
            // 
            // Adicionar
            // 
            this.Adicionar.HeaderText = "Adicionar";
            this.Adicionar.Name = "Adicionar";
            // 
            // Modificar
            // 
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            // 
            // Eliminar
            // 
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 33);
            this.panel1.TabIndex = 330;
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblTitulo.Location = new System.Drawing.Point(282, 4);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(323, 24);
            this.LblTitulo.TabIndex = 211;
            this.LblTitulo.Text = "CONFIGURACION DE USUARIOS";
            // 
            // PnlDatos
            // 
            this.PnlDatos.BackColor = System.Drawing.SystemColors.Control;
            this.PnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlDatos.Controls.Add(this.label1);
            this.PnlDatos.Controls.Add(this.DtpFecha);
            this.PnlDatos.Controls.Add(this.ChbMarcar);
            this.PnlDatos.Controls.Add(this.TxtConfClave);
            this.PnlDatos.Controls.Add(this.LblConClave);
            this.PnlDatos.Controls.Add(this.TxtClave);
            this.PnlDatos.Controls.Add(this.LblClave);
            this.PnlDatos.Controls.Add(this.TxtNombreUsuario);
            this.PnlDatos.Controls.Add(this.label57);
            this.PnlDatos.Controls.Add(this.TxtUsuario);
            this.PnlDatos.Controls.Add(this.label2);
            this.PnlDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlDatos.Location = new System.Drawing.Point(0, 33);
            this.PnlDatos.Name = "PnlDatos";
            this.PnlDatos.Size = new System.Drawing.Size(1005, 85);
            this.PnlDatos.TabIndex = 329;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(427, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 319;
            this.label1.Text = "Fecha:";
            // 
            // DtpFecha
            // 
            this.DtpFecha.Enabled = false;
            this.DtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(576, 31);
            this.DtpFecha.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(115, 22);
            this.DtpFecha.TabIndex = 318;
            // 
            // ChbMarcar
            // 
            this.ChbMarcar.AutoSize = true;
            this.ChbMarcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChbMarcar.Location = new System.Drawing.Point(742, 34);
            this.ChbMarcar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ChbMarcar.Name = "ChbMarcar";
            this.ChbMarcar.Size = new System.Drawing.Size(98, 17);
            this.ChbMarcar.TabIndex = 324;
            this.ChbMarcar.Text = "Marcar Todo";
            this.ChbMarcar.UseVisualStyleBackColor = true;
            this.ChbMarcar.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // TxtConfClave
            // 
            this.TxtConfClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtConfClave.Location = new System.Drawing.Point(164, 56);
            this.TxtConfClave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtConfClave.Name = "TxtConfClave";
            this.TxtConfClave.PasswordChar = '*';
            this.TxtConfClave.Size = new System.Drawing.Size(143, 22);
            this.TxtConfClave.TabIndex = 317;
            // 
            // LblConClave
            // 
            this.LblConClave.AutoSize = true;
            this.LblConClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblConClave.Location = new System.Drawing.Point(31, 60);
            this.LblConClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblConClave.Name = "LblConClave";
            this.LblConClave.Size = new System.Drawing.Size(122, 16);
            this.LblConClave.TabIndex = 316;
            this.LblConClave.Text = "Confirmar Clave:";
            // 
            // TxtClave
            // 
            this.TxtClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClave.Location = new System.Drawing.Point(164, 31);
            this.TxtClave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.PasswordChar = '*';
            this.TxtClave.Size = new System.Drawing.Size(143, 22);
            this.TxtClave.TabIndex = 315;
            // 
            // LblClave
            // 
            this.LblClave.AutoSize = true;
            this.LblClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClave.Location = new System.Drawing.Point(31, 34);
            this.LblClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblClave.Name = "LblClave";
            this.LblClave.Size = new System.Drawing.Size(52, 16);
            this.LblClave.TabIndex = 314;
            this.LblClave.Text = "Clave:";
            // 
            // TxtNombreUsuario
            // 
            this.TxtNombreUsuario.BackColor = System.Drawing.Color.White;
            this.TxtNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNombreUsuario.Location = new System.Drawing.Point(576, 4);
            this.TxtNombreUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtNombreUsuario.Name = "TxtNombreUsuario";
            this.TxtNombreUsuario.Size = new System.Drawing.Size(237, 22);
            this.TxtNombreUsuario.TabIndex = 313;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label57.Location = new System.Drawing.Point(427, 5);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(125, 16);
            this.label57.TabIndex = 312;
            this.label57.Text = "Nombre Usuario:";
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.Location = new System.Drawing.Point(164, 4);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(143, 22);
            this.TxtUsuario.TabIndex = 311;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 310;
            this.label2.Text = "Usuario:";
            // 
            // BtnEscape
            // 
            this.BtnEscape.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnEscape.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnEscape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEscape.Location = new System.Drawing.Point(812, 243);
            this.BtnEscape.Name = "BtnEscape";
            this.BtnEscape.Size = new System.Drawing.Size(74, 25);
            this.BtnEscape.TabIndex = 338;
            this.BtnEscape.Text = "Salir";
            this.BtnEscape.UseVisualStyleBackColor = true;
            this.BtnEscape.Click += new System.EventHandler(this.BtnEscape_Click);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.Location = new System.Drawing.Point(812, 193);
            this.BtnAceptar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(74, 25);
            this.BtnAceptar.TabIndex = 337;
            this.BtnAceptar.Text = "Aceptar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnExportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExportar.Location = new System.Drawing.Point(812, 292);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(74, 25);
            this.BtnExportar.TabIndex = 339;
            this.BtnExportar.Text = "Exportar";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(122, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 325;
            this.pictureBox1.TabStop = false;
            // 
            // Permisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 680);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.BtnEscape);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.PnlDatos);
            this.Controls.Add(this.DgvPermisos);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Permisos";
            this.Text = "Permisos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Permisos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPermisos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PnlDatos.ResumeLayout(false);
            this.PnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvPermisos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreModulo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Adicionar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Modificar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Eliminar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel PnlDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.CheckBox ChbMarcar;
        private System.Windows.Forms.TextBox TxtConfClave;
        private System.Windows.Forms.Label LblConClave;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.Label LblClave;
        private System.Windows.Forms.TextBox TxtNombreUsuario;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnEscape;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Button BtnExportar;
    }
}