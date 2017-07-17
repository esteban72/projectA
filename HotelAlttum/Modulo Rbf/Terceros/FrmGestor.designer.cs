namespace CarteraGeneral
{
    partial class FrmGestor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestor));
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.BtnEscape = new System.Windows.Forms.Button();
            this.PnlSuperior = new System.Windows.Forms.Panel();
            this.CmbTipoTercero = new System.Windows.Forms.ComboBox();
            this.LblClase = new System.Windows.Forms.Label();
            this.LblApellido2 = new System.Windows.Forms.Label();
            this.LblNombre1 = new System.Windows.Forms.Label();
            this.TxtApellido2 = new System.Windows.Forms.TextBox();
            this.TxtApellido1 = new System.Windows.Forms.TextBox();
            this.Txtnombre2 = new System.Windows.Forms.TextBox();
            this.LblNombre2 = new System.Windows.Forms.Label();
            this.TxtNombre1 = new System.Windows.Forms.TextBox();
            this.LblApellido1 = new System.Windows.Forms.Label();
            this.LblNombreCompleto = new System.Windows.Forms.Label();
            this.TxtNombreCompleto = new System.Windows.Forms.TextBox();
            this.CmbCtaRetencion = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRetencion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.PnlInferior = new System.Windows.Forms.Panel();
            this.TxtPaginaWeb = new System.Windows.Forms.TextBox();
            this.LblDpto = new System.Windows.Forms.Label();
            this.LblCelular = new System.Windows.Forms.Label();
            this.LblTelefono2 = new System.Windows.Forms.Label();
            this.LblTelefono1 = new System.Windows.Forms.Label();
            this.LblCiudad = new System.Windows.Forms.Label();
            this.LblBarrio = new System.Windows.Forms.Label();
            this.LblDireccion = new System.Windows.Forms.Label();
            this.LblContacto = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblPaginasWeb = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtContacto = new System.Windows.Forms.TextBox();
            this.TxtCelular = new System.Windows.Forms.TextBox();
            this.TxtTelefono2 = new System.Windows.Forms.TextBox();
            this.TxtTelefono1 = new System.Windows.Forms.TextBox();
            this.TxtBarrio = new System.Windows.Forms.TextBox();
            this.TxtDireccion = new System.Windows.Forms.TextBox();
            this.TxtCiudad = new System.Windows.Forms.TextBox();
            this.TxtDpto = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblTipo = new System.Windows.Forms.Label();
            this.CmbTipoPersona = new System.Windows.Forms.ComboBox();
            this.LblFechanaci = new System.Windows.Forms.Label();
            this.DtpFechaNaci = new System.Windows.Forms.DateTimePicker();
            this.TxtIdentificacion = new System.Windows.Forms.TextBox();
            this.DtpAlta = new System.Windows.Forms.DateTimePicker();
            this.LblIdentificacion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PnlSuperior.SuspendLayout();
            this.PnlInferior.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevo.Location = new System.Drawing.Point(776, 478);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(102, 34);
            this.BtnNuevo.TabIndex = 27;
            this.BtnNuevo.Text = "Nuevo";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Visible = false;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // BtnEscape
            // 
            this.BtnEscape.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnEscape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEscape.Location = new System.Drawing.Point(640, 478);
            this.BtnEscape.Name = "BtnEscape";
            this.BtnEscape.Size = new System.Drawing.Size(102, 34);
            this.BtnEscape.TabIndex = 26;
            this.BtnEscape.Text = "Salir";
            this.BtnEscape.UseVisualStyleBackColor = true;
            this.BtnEscape.Click += new System.EventHandler(this.BtnEscape_Click);
            // 
            // PnlSuperior
            // 
            this.PnlSuperior.BackColor = System.Drawing.Color.Transparent;
            this.PnlSuperior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlSuperior.Controls.Add(this.CmbTipoTercero);
            this.PnlSuperior.Controls.Add(this.LblClase);
            this.PnlSuperior.Controls.Add(this.LblApellido2);
            this.PnlSuperior.Controls.Add(this.LblNombre1);
            this.PnlSuperior.Controls.Add(this.TxtApellido2);
            this.PnlSuperior.Controls.Add(this.TxtApellido1);
            this.PnlSuperior.Controls.Add(this.Txtnombre2);
            this.PnlSuperior.Controls.Add(this.LblNombre2);
            this.PnlSuperior.Controls.Add(this.TxtNombre1);
            this.PnlSuperior.Controls.Add(this.LblApellido1);
            this.PnlSuperior.Controls.Add(this.LblNombreCompleto);
            this.PnlSuperior.Controls.Add(this.TxtNombreCompleto);
            this.PnlSuperior.Controls.Add(this.CmbCtaRetencion);
            this.PnlSuperior.Controls.Add(this.label2);
            this.PnlSuperior.Controls.Add(this.TxtRetencion);
            this.PnlSuperior.Controls.Add(this.label1);
            this.PnlSuperior.Enabled = false;
            this.PnlSuperior.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, System.Drawing.FontStyle.Bold);
            this.PnlSuperior.Location = new System.Drawing.Point(30, 110);
            this.PnlSuperior.Name = "PnlSuperior";
            this.PnlSuperior.Size = new System.Drawing.Size(895, 132);
            this.PnlSuperior.TabIndex = 111;
            // 
            // CmbTipoTercero
            // 
            this.CmbTipoTercero.Enabled = false;
            this.CmbTipoTercero.FormattingEnabled = true;
            this.CmbTipoTercero.Items.AddRange(new object[] {
            "Gestor"});
            this.CmbTipoTercero.Location = new System.Drawing.Point(666, 77);
            this.CmbTipoTercero.Name = "CmbTipoTercero";
            this.CmbTipoTercero.Size = new System.Drawing.Size(163, 22);
            this.CmbTipoTercero.TabIndex = 12;
            this.CmbTipoTercero.Text = "Gestor";
            // 
            // LblClase
            // 
            this.LblClase.AutoSize = true;
            this.LblClase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblClase.ForeColor = System.Drawing.Color.Black;
            this.LblClase.Location = new System.Drawing.Point(535, 80);
            this.LblClase.Name = "LblClase";
            this.LblClase.Size = new System.Drawing.Size(96, 15);
            this.LblClase.TabIndex = 113;
            this.LblClase.Text = "Clase Tercero";
            // 
            // LblApellido2
            // 
            this.LblApellido2.AutoSize = true;
            this.LblApellido2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblApellido2.ForeColor = System.Drawing.Color.Black;
            this.LblApellido2.Location = new System.Drawing.Point(533, 45);
            this.LblApellido2.Name = "LblApellido2";
            this.LblApellido2.Size = new System.Drawing.Size(120, 15);
            this.LblApellido2.TabIndex = 112;
            this.LblApellido2.Text = "Segundo Apellido";
            // 
            // LblNombre1
            // 
            this.LblNombre1.AutoSize = true;
            this.LblNombre1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre1.ForeColor = System.Drawing.Color.Black;
            this.LblNombre1.Location = new System.Drawing.Point(9, 15);
            this.LblNombre1.Name = "LblNombre1";
            this.LblNombre1.Size = new System.Drawing.Size(105, 15);
            this.LblNombre1.TabIndex = 109;
            this.LblNombre1.Text = "Primer Nombre";
            // 
            // TxtApellido2
            // 
            this.TxtApellido2.Enabled = false;
            this.TxtApellido2.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, System.Drawing.FontStyle.Bold);
            this.TxtApellido2.Location = new System.Drawing.Point(666, 43);
            this.TxtApellido2.MaxLength = 15;
            this.TxtApellido2.Name = "TxtApellido2";
            this.TxtApellido2.Size = new System.Drawing.Size(163, 21);
            this.TxtApellido2.TabIndex = 8;
            // 
            // TxtApellido1
            // 
            this.TxtApellido1.Enabled = false;
            this.TxtApellido1.Location = new System.Drawing.Point(160, 43);
            this.TxtApellido1.MaxLength = 15;
            this.TxtApellido1.Name = "TxtApellido1";
            this.TxtApellido1.Size = new System.Drawing.Size(140, 21);
            this.TxtApellido1.TabIndex = 7;
            // 
            // Txtnombre2
            // 
            this.Txtnombre2.Enabled = false;
            this.Txtnombre2.Location = new System.Drawing.Point(666, 12);
            this.Txtnombre2.MaxLength = 15;
            this.Txtnombre2.Name = "Txtnombre2";
            this.Txtnombre2.Size = new System.Drawing.Size(163, 21);
            this.Txtnombre2.TabIndex = 6;
            // 
            // LblNombre2
            // 
            this.LblNombre2.AutoSize = true;
            this.LblNombre2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre2.ForeColor = System.Drawing.Color.Black;
            this.LblNombre2.Location = new System.Drawing.Point(533, 15);
            this.LblNombre2.Name = "LblNombre2";
            this.LblNombre2.Size = new System.Drawing.Size(119, 15);
            this.LblNombre2.TabIndex = 111;
            this.LblNombre2.Text = "Segundo Nombre";
            // 
            // TxtNombre1
            // 
            this.TxtNombre1.Enabled = false;
            this.TxtNombre1.Location = new System.Drawing.Point(160, 12);
            this.TxtNombre1.MaxLength = 35;
            this.TxtNombre1.Name = "TxtNombre1";
            this.TxtNombre1.Size = new System.Drawing.Size(140, 21);
            this.TxtNombre1.TabIndex = 5;
            // 
            // LblApellido1
            // 
            this.LblApellido1.AutoSize = true;
            this.LblApellido1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblApellido1.ForeColor = System.Drawing.Color.Black;
            this.LblApellido1.Location = new System.Drawing.Point(9, 45);
            this.LblApellido1.Name = "LblApellido1";
            this.LblApellido1.Size = new System.Drawing.Size(106, 15);
            this.LblApellido1.TabIndex = 110;
            this.LblApellido1.Text = "Primer Apellido";
            // 
            // LblNombreCompleto
            // 
            this.LblNombreCompleto.AutoSize = true;
            this.LblNombreCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombreCompleto.ForeColor = System.Drawing.Color.Black;
            this.LblNombreCompleto.Location = new System.Drawing.Point(9, 80);
            this.LblNombreCompleto.Name = "LblNombreCompleto";
            this.LblNombreCompleto.Size = new System.Drawing.Size(123, 15);
            this.LblNombreCompleto.TabIndex = 104;
            this.LblNombreCompleto.Text = "Nombre Completo";
            // 
            // TxtNombreCompleto
            // 
            this.TxtNombreCompleto.BackColor = System.Drawing.SystemColors.Window;
            this.TxtNombreCompleto.Enabled = false;
            this.TxtNombreCompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.TxtNombreCompleto.Location = new System.Drawing.Point(160, 77);
            this.TxtNombreCompleto.MaxLength = 120;
            this.TxtNombreCompleto.Name = "TxtNombreCompleto";
            this.TxtNombreCompleto.Size = new System.Drawing.Size(359, 21);
            this.TxtNombreCompleto.TabIndex = 11;
            // 
            // CmbCtaRetencion
            // 
            this.CmbCtaRetencion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCtaRetencion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbCtaRetencion.FormattingEnabled = true;
            this.CmbCtaRetencion.Items.AddRange(new object[] {
            "Empleado",
            "Independiente"});
            this.CmbCtaRetencion.Location = new System.Drawing.Point(498, 104);
            this.CmbCtaRetencion.Name = "CmbCtaRetencion";
            this.CmbCtaRetencion.Size = new System.Drawing.Size(155, 22);
            this.CmbCtaRetencion.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(331, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 101;
            this.label2.Text = "Cuenta Retencion";
            // 
            // TxtRetencion
            // 
            this.TxtRetencion.BackColor = System.Drawing.Color.White;
            this.TxtRetencion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtRetencion.Location = new System.Drawing.Point(160, 105);
            this.TxtRetencion.MaxLength = 15;
            this.TxtRetencion.Name = "TxtRetencion";
            this.TxtRetencion.Size = new System.Drawing.Size(58, 21);
            this.TxtRetencion.TabIndex = 13;
            this.TxtRetencion.Text = "0";
            this.TxtRetencion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 99;
            this.label1.Text = "Retencion";
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblTitulo.Location = new System.Drawing.Point(365, 3);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(239, 24);
            this.LblTitulo.TabIndex = 113;
            this.LblTitulo.Text = "ADICIONAR GESTORES";
            // 
            // BtnOk
            // 
            this.BtnOk.Enabled = false;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.Location = new System.Drawing.Point(505, 478);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(102, 34);
            this.BtnOk.TabIndex = 25;
            this.BtnOk.Text = "Adicionar";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click_1);
            // 
            // PnlInferior
            // 
            this.PnlInferior.BackColor = System.Drawing.SystemColors.Control;
            this.PnlInferior.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlInferior.Controls.Add(this.TxtPaginaWeb);
            this.PnlInferior.Controls.Add(this.LblDpto);
            this.PnlInferior.Controls.Add(this.LblCelular);
            this.PnlInferior.Controls.Add(this.LblTelefono2);
            this.PnlInferior.Controls.Add(this.LblTelefono1);
            this.PnlInferior.Controls.Add(this.LblCiudad);
            this.PnlInferior.Controls.Add(this.LblBarrio);
            this.PnlInferior.Controls.Add(this.LblDireccion);
            this.PnlInferior.Controls.Add(this.LblContacto);
            this.PnlInferior.Controls.Add(this.LblEmail);
            this.PnlInferior.Controls.Add(this.LblPaginasWeb);
            this.PnlInferior.Controls.Add(this.TxtEmail);
            this.PnlInferior.Controls.Add(this.TxtContacto);
            this.PnlInferior.Controls.Add(this.TxtCelular);
            this.PnlInferior.Controls.Add(this.TxtTelefono2);
            this.PnlInferior.Controls.Add(this.TxtTelefono1);
            this.PnlInferior.Controls.Add(this.TxtBarrio);
            this.PnlInferior.Controls.Add(this.TxtDireccion);
            this.PnlInferior.Controls.Add(this.TxtCiudad);
            this.PnlInferior.Controls.Add(this.TxtDpto);
            this.PnlInferior.Location = new System.Drawing.Point(30, 248);
            this.PnlInferior.Name = "PnlInferior";
            this.PnlInferior.Size = new System.Drawing.Size(895, 194);
            this.PnlInferior.TabIndex = 115;
            // 
            // TxtPaginaWeb
            // 
            this.TxtPaginaWeb.BackColor = System.Drawing.Color.White;
            this.TxtPaginaWeb.Enabled = false;
            this.TxtPaginaWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPaginaWeb.Location = new System.Drawing.Point(590, 20);
            this.TxtPaginaWeb.MaxLength = 40;
            this.TxtPaginaWeb.Name = "TxtPaginaWeb";
            this.TxtPaginaWeb.Size = new System.Drawing.Size(237, 21);
            this.TxtPaginaWeb.TabIndex = 16;
            // 
            // LblDpto
            // 
            this.LblDpto.AutoSize = true;
            this.LblDpto.BackColor = System.Drawing.Color.Transparent;
            this.LblDpto.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDpto.Location = new System.Drawing.Point(128, 92);
            this.LblDpto.Name = "LblDpto";
            this.LblDpto.Size = new System.Drawing.Size(35, 14);
            this.LblDpto.TabIndex = 95;
            this.LblDpto.Text = "Dpto";
            // 
            // LblCelular
            // 
            this.LblCelular.AutoSize = true;
            this.LblCelular.BackColor = System.Drawing.Color.Transparent;
            this.LblCelular.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCelular.Location = new System.Drawing.Point(249, 142);
            this.LblCelular.Name = "LblCelular";
            this.LblCelular.Size = new System.Drawing.Size(56, 14);
            this.LblCelular.TabIndex = 94;
            this.LblCelular.Text = "Celular";
            // 
            // LblTelefono2
            // 
            this.LblTelefono2.AutoSize = true;
            this.LblTelefono2.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.LblTelefono2.Location = new System.Drawing.Point(37, 153);
            this.LblTelefono2.Name = "LblTelefono2";
            this.LblTelefono2.Size = new System.Drawing.Size(70, 14);
            this.LblTelefono2.TabIndex = 93;
            this.LblTelefono2.Text = "Telefono2";
            // 
            // LblTelefono1
            // 
            this.LblTelefono1.AutoSize = true;
            this.LblTelefono1.BackColor = System.Drawing.Color.Transparent;
            this.LblTelefono1.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTelefono1.Location = new System.Drawing.Point(37, 131);
            this.LblTelefono1.Name = "LblTelefono1";
            this.LblTelefono1.Size = new System.Drawing.Size(70, 14);
            this.LblTelefono1.TabIndex = 92;
            this.LblTelefono1.Text = "Telefono1";
            // 
            // LblCiudad
            // 
            this.LblCiudad.AutoSize = true;
            this.LblCiudad.BackColor = System.Drawing.Color.Transparent;
            this.LblCiudad.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCiudad.Location = new System.Drawing.Point(117, 70);
            this.LblCiudad.Name = "LblCiudad";
            this.LblCiudad.Size = new System.Drawing.Size(49, 14);
            this.LblCiudad.TabIndex = 91;
            this.LblCiudad.Text = "Ciudad";
            // 
            // LblBarrio
            // 
            this.LblBarrio.AutoSize = true;
            this.LblBarrio.BackColor = System.Drawing.Color.Transparent;
            this.LblBarrio.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBarrio.Location = new System.Drawing.Point(124, 48);
            this.LblBarrio.Name = "LblBarrio";
            this.LblBarrio.Size = new System.Drawing.Size(49, 14);
            this.LblBarrio.TabIndex = 90;
            this.LblBarrio.Text = "Barrio";
            // 
            // LblDireccion
            // 
            this.LblDireccion.AutoSize = true;
            this.LblDireccion.BackColor = System.Drawing.Color.Transparent;
            this.LblDireccion.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDireccion.Location = new System.Drawing.Point(40, 27);
            this.LblDireccion.Name = "LblDireccion";
            this.LblDireccion.Size = new System.Drawing.Size(70, 14);
            this.LblDireccion.TabIndex = 89;
            this.LblDireccion.Text = "Direccion";
            // 
            // LblContacto
            // 
            this.LblContacto.AutoSize = true;
            this.LblContacto.BackColor = System.Drawing.Color.Transparent;
            this.LblContacto.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblContacto.Location = new System.Drawing.Point(512, 157);
            this.LblContacto.Name = "LblContacto";
            this.LblContacto.Size = new System.Drawing.Size(63, 14);
            this.LblContacto.TabIndex = 88;
            this.LblContacto.Text = "Contacto";
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.BackColor = System.Drawing.Color.Transparent;
            this.LblEmail.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmail.Location = new System.Drawing.Point(533, 93);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(42, 14);
            this.LblEmail.TabIndex = 87;
            this.LblEmail.Text = "Email";
            // 
            // LblPaginasWeb
            // 
            this.LblPaginasWeb.AutoSize = true;
            this.LblPaginasWeb.BackColor = System.Drawing.Color.Transparent;
            this.LblPaginasWeb.Font = new System.Drawing.Font("Bitstream Vera Sans Mono", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPaginasWeb.Location = new System.Drawing.Point(493, 28);
            this.LblPaginasWeb.Name = "LblPaginasWeb";
            this.LblPaginasWeb.Size = new System.Drawing.Size(77, 14);
            this.LblPaginasWeb.TabIndex = 86;
            this.LblPaginasWeb.Text = "Pagina Web";
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.White;
            this.TxtEmail.Enabled = false;
            this.TxtEmail.Location = new System.Drawing.Point(590, 90);
            this.TxtEmail.MaxLength = 40;
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(237, 20);
            this.TxtEmail.TabIndex = 20;
            // 
            // TxtContacto
            // 
            this.TxtContacto.BackColor = System.Drawing.Color.White;
            this.TxtContacto.Enabled = false;
            this.TxtContacto.Location = new System.Drawing.Point(590, 155);
            this.TxtContacto.MaxLength = 40;
            this.TxtContacto.Name = "TxtContacto";
            this.TxtContacto.Size = new System.Drawing.Size(237, 20);
            this.TxtContacto.TabIndex = 24;
            // 
            // TxtCelular
            // 
            this.TxtCelular.BackColor = System.Drawing.Color.White;
            this.TxtCelular.Enabled = false;
            this.TxtCelular.Location = new System.Drawing.Point(334, 137);
            this.TxtCelular.MaxLength = 10;
            this.TxtCelular.Name = "TxtCelular";
            this.TxtCelular.Size = new System.Drawing.Size(116, 20);
            this.TxtCelular.TabIndex = 23;
            // 
            // TxtTelefono2
            // 
            this.TxtTelefono2.BackColor = System.Drawing.Color.White;
            this.TxtTelefono2.Enabled = false;
            this.TxtTelefono2.Location = new System.Drawing.Point(125, 151);
            this.TxtTelefono2.MaxLength = 10;
            this.TxtTelefono2.Name = "TxtTelefono2";
            this.TxtTelefono2.Size = new System.Drawing.Size(116, 20);
            this.TxtTelefono2.TabIndex = 22;
            // 
            // TxtTelefono1
            // 
            this.TxtTelefono1.BackColor = System.Drawing.Color.White;
            this.TxtTelefono1.Enabled = false;
            this.TxtTelefono1.Location = new System.Drawing.Point(125, 129);
            this.TxtTelefono1.MaxLength = 10;
            this.TxtTelefono1.Name = "TxtTelefono1";
            this.TxtTelefono1.Size = new System.Drawing.Size(116, 20);
            this.TxtTelefono1.TabIndex = 21;
            // 
            // TxtBarrio
            // 
            this.TxtBarrio.BackColor = System.Drawing.Color.White;
            this.TxtBarrio.Enabled = false;
            this.TxtBarrio.Location = new System.Drawing.Point(182, 46);
            this.TxtBarrio.MaxLength = 30;
            this.TxtBarrio.Name = "TxtBarrio";
            this.TxtBarrio.Size = new System.Drawing.Size(221, 20);
            this.TxtBarrio.TabIndex = 17;
            // 
            // TxtDireccion
            // 
            this.TxtDireccion.BackColor = System.Drawing.Color.White;
            this.TxtDireccion.Enabled = false;
            this.TxtDireccion.Location = new System.Drawing.Point(112, 25);
            this.TxtDireccion.MaxLength = 40;
            this.TxtDireccion.Name = "TxtDireccion";
            this.TxtDireccion.Size = new System.Drawing.Size(291, 20);
            this.TxtDireccion.TabIndex = 15;
            // 
            // TxtCiudad
            // 
            this.TxtCiudad.BackColor = System.Drawing.Color.White;
            this.TxtCiudad.Enabled = false;
            this.TxtCiudad.Location = new System.Drawing.Point(182, 68);
            this.TxtCiudad.MaxLength = 30;
            this.TxtCiudad.Name = "TxtCiudad";
            this.TxtCiudad.Size = new System.Drawing.Size(221, 20);
            this.TxtCiudad.TabIndex = 18;
            // 
            // TxtDpto
            // 
            this.TxtDpto.BackColor = System.Drawing.Color.White;
            this.TxtDpto.Enabled = false;
            this.TxtDpto.Location = new System.Drawing.Point(182, 89);
            this.TxtDpto.MaxLength = 30;
            this.TxtDpto.Name = "TxtDpto";
            this.TxtDpto.Size = new System.Drawing.Size(221, 20);
            this.TxtDpto.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(969, 30);
            this.panel1.TabIndex = 116;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.LblTipo);
            this.panel2.Controls.Add(this.CmbTipoPersona);
            this.panel2.Controls.Add(this.LblFechanaci);
            this.panel2.Controls.Add(this.DtpFechaNaci);
            this.panel2.Controls.Add(this.TxtIdentificacion);
            this.panel2.Controls.Add(this.DtpAlta);
            this.panel2.Controls.Add(this.LblIdentificacion);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(30, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(895, 33);
            this.panel2.TabIndex = 115;
            // 
            // LblTipo
            // 
            this.LblTipo.AutoSize = true;
            this.LblTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTipo.ForeColor = System.Drawing.Color.Black;
            this.LblTipo.Location = new System.Drawing.Point(5, 6);
            this.LblTipo.Name = "LblTipo";
            this.LblTipo.Size = new System.Drawing.Size(35, 15);
            this.LblTipo.TabIndex = 82;
            this.LblTipo.Text = "Tipo";
            // 
            // CmbTipoPersona
            // 
            this.CmbTipoPersona.FormattingEnabled = true;
            this.CmbTipoPersona.Items.AddRange(new object[] {
            "Persona Natural",
            "Persona Juridica"});
            this.CmbTipoPersona.Location = new System.Drawing.Point(47, 5);
            this.CmbTipoPersona.Name = "CmbTipoPersona";
            this.CmbTipoPersona.Size = new System.Drawing.Size(121, 21);
            this.CmbTipoPersona.TabIndex = 1;
            this.CmbTipoPersona.SelectedIndexChanged += new System.EventHandler(this.CmbTipoPersona_SelectedIndexChanged);
            // 
            // LblFechanaci
            // 
            this.LblFechanaci.AutoSize = true;
            this.LblFechanaci.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFechanaci.ForeColor = System.Drawing.Color.Black;
            this.LblFechanaci.Location = new System.Drawing.Point(650, 6);
            this.LblFechanaci.Name = "LblFechanaci";
            this.LblFechanaci.Size = new System.Drawing.Size(123, 15);
            this.LblFechanaci.TabIndex = 97;
            this.LblFechanaci.Text = "Fecha Nacimiento";
            // 
            // DtpFechaNaci
            // 
            this.DtpFechaNaci.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpFechaNaci.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaNaci.Location = new System.Drawing.Point(779, 5);
            this.DtpFechaNaci.Name = "DtpFechaNaci";
            this.DtpFechaNaci.Size = new System.Drawing.Size(94, 20);
            this.DtpFechaNaci.TabIndex = 4;
            // 
            // TxtIdentificacion
            // 
            this.TxtIdentificacion.BackColor = System.Drawing.Color.White;
            this.TxtIdentificacion.Enabled = false;
            this.TxtIdentificacion.Location = new System.Drawing.Point(289, 5);
            this.TxtIdentificacion.MaxLength = 30;
            this.TxtIdentificacion.Name = "TxtIdentificacion";
            this.TxtIdentificacion.Size = new System.Drawing.Size(116, 20);
            this.TxtIdentificacion.TabIndex = 2;
            this.TxtIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtIdentificacion_KeyPress);
            // 
            // DtpAlta
            // 
            this.DtpAlta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DtpAlta.Enabled = false;
            this.DtpAlta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpAlta.Location = new System.Drawing.Point(542, 5);
            this.DtpAlta.Name = "DtpAlta";
            this.DtpAlta.Size = new System.Drawing.Size(102, 20);
            this.DtpAlta.TabIndex = 3;
            // 
            // LblIdentificacion
            // 
            this.LblIdentificacion.AutoSize = true;
            this.LblIdentificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblIdentificacion.ForeColor = System.Drawing.Color.Black;
            this.LblIdentificacion.Location = new System.Drawing.Point(181, 6);
            this.LblIdentificacion.Name = "LblIdentificacion";
            this.LblIdentificacion.Size = new System.Drawing.Size(93, 15);
            this.LblIdentificacion.TabIndex = 80;
            this.LblIdentificacion.Text = "Identificacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(429, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 15);
            this.label5.TabIndex = 85;
            this.label5.Text = "Fecha Creacion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(5, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 112;
            this.pictureBox1.TabStop = false;
            // 
            // FrmGestor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(969, 570);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PnlInferior);
            this.Controls.Add(this.BtnNuevo);
            this.Controls.Add(this.BtnEscape);
            this.Controls.Add(this.PnlSuperior);
            this.Controls.Add(this.BtnOk);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGestor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGestor";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmClientes_FormClosed);
            this.Load += new System.EventHandler(this.FrmTerceros_Load);
            this.PnlSuperior.ResumeLayout(false);
            this.PnlSuperior.PerformLayout();
            this.PnlInferior.ResumeLayout(false);
            this.PnlInferior.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnNuevo;
        private System.Windows.Forms.Button BtnEscape;
        private System.Windows.Forms.Panel PnlSuperior;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Panel PnlInferior;
        private System.Windows.Forms.TextBox TxtPaginaWeb;
        private System.Windows.Forms.Label LblDpto;
        private System.Windows.Forms.Label LblCelular;
        private System.Windows.Forms.Label LblTelefono2;
        private System.Windows.Forms.Label LblTelefono1;
        private System.Windows.Forms.Label LblCiudad;
        private System.Windows.Forms.Label LblBarrio;
        private System.Windows.Forms.Label LblDireccion;
        private System.Windows.Forms.Label LblContacto;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblPaginasWeb;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtContacto;
        private System.Windows.Forms.TextBox TxtCelular;
        private System.Windows.Forms.TextBox TxtTelefono2;
        private System.Windows.Forms.TextBox TxtTelefono1;
        private System.Windows.Forms.TextBox TxtBarrio;
        private System.Windows.Forms.TextBox TxtDireccion;
        private System.Windows.Forms.TextBox TxtCiudad;
        private System.Windows.Forms.TextBox TxtDpto;
        private System.Windows.Forms.TextBox TxtRetencion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbCtaRetencion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblNombreCompleto;
        private System.Windows.Forms.TextBox TxtNombreCompleto;
        private System.Windows.Forms.Label LblApellido2;
        private System.Windows.Forms.Label LblNombre1;
        private System.Windows.Forms.TextBox TxtApellido2;
        private System.Windows.Forms.TextBox TxtApellido1;
        private System.Windows.Forms.TextBox Txtnombre2;
        private System.Windows.Forms.Label LblNombre2;
        private System.Windows.Forms.TextBox TxtNombre1;
        private System.Windows.Forms.Label LblApellido1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblTipo;
        private System.Windows.Forms.ComboBox CmbTipoPersona;
        private System.Windows.Forms.Label LblFechanaci;
        private System.Windows.Forms.DateTimePicker DtpFechaNaci;
        private System.Windows.Forms.TextBox TxtIdentificacion;
        private System.Windows.Forms.DateTimePicker DtpAlta;
        private System.Windows.Forms.Label LblIdentificacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbTipoTercero;
        private System.Windows.Forms.Label LblClase;
    }
}