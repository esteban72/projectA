namespace CarteraGeneral
{
    partial class FrmTRM
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.gbOperaciones = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbtnPesos = new System.Windows.Forms.RadioButton();
            this.rbtnDolares = new System.Windows.Forms.RadioButton();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.txtValorCalcular = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.txtUnidad = new System.Windows.Forms.TextBox();
            this.txtTRM = new System.Windows.Forms.TextBox();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.txtValidoDesde = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCalendario = new System.Windows.Forms.GroupBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.gbConfiguracion = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.chkOtraFecha = new System.Windows.Forms.RadioButton();
            this.chkFechaActual = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.gbResultados.SuspendLayout();
            this.gbOperaciones.SuspendLayout();
            this.gbCalendario.SuspendLayout();
            this.gbConfiguracion.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gbResultados);
            this.groupControl1.Controls.Add(this.gbCalendario);
            this.groupControl1.Controls.Add(this.gbConfiguracion);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(538, 350);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Tasa Representativa del Mercado";
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.btnLimpiar);
            this.gbResultados.Controls.Add(this.btnCerrar);
            this.gbResultados.Controls.Add(this.gbOperaciones);
            this.gbResultados.Controls.Add(this.txtUnidad);
            this.gbResultados.Controls.Add(this.txtTRM);
            this.gbResultados.Controls.Add(this.txtIdentificador);
            this.gbResultados.Controls.Add(this.txtValidoDesde);
            this.gbResultados.Controls.Add(this.label4);
            this.gbResultados.Controls.Add(this.label3);
            this.gbResultados.Controls.Add(this.label2);
            this.gbResultados.Controls.Add(this.label1);
            this.gbResultados.Location = new System.Drawing.Point(278, 23);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(252, 322);
            this.gbResultados.TabIndex = 1;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "Resultados";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(87, 293);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 2;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(168, 293);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 3;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // gbOperaciones
            // 
            this.gbOperaciones.Controls.Add(this.label5);
            this.gbOperaciones.Controls.Add(this.rbtnPesos);
            this.gbOperaciones.Controls.Add(this.rbtnDolares);
            this.gbOperaciones.Controls.Add(this.btnCalcular);
            this.gbOperaciones.Controls.Add(this.txtResultado);
            this.gbOperaciones.Controls.Add(this.txtValorCalcular);
            this.gbOperaciones.Controls.Add(this.label7);
            this.gbOperaciones.Controls.Add(this.lblValor);
            this.gbOperaciones.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbOperaciones.Location = new System.Drawing.Point(6, 146);
            this.gbOperaciones.Name = "gbOperaciones";
            this.gbOperaciones.Size = new System.Drawing.Size(237, 139);
            this.gbOperaciones.TabIndex = 2;
            this.gbOperaciones.TabStop = false;
            this.gbOperaciones.Text = "Conversión Moneda";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Convertir a";
            // 
            // rbtnPesos
            // 
            this.rbtnPesos.AutoSize = true;
            this.rbtnPesos.Checked = true;
            this.rbtnPesos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPesos.Location = new System.Drawing.Point(103, 23);
            this.rbtnPesos.Name = "rbtnPesos";
            this.rbtnPesos.Size = new System.Drawing.Size(46, 17);
            this.rbtnPesos.TabIndex = 6;
            this.rbtnPesos.TabStop = true;
            this.rbtnPesos.Text = "COP";
            this.rbtnPesos.UseVisualStyleBackColor = true;
            this.rbtnPesos.CheckedChanged += new System.EventHandler(this.rbtnPesos_CheckedChanged);
            // 
            // rbtnDolares
            // 
            this.rbtnDolares.AutoSize = true;
            this.rbtnDolares.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnDolares.Location = new System.Drawing.Point(162, 23);
            this.rbtnDolares.Name = "rbtnDolares";
            this.rbtnDolares.Size = new System.Drawing.Size(45, 17);
            this.rbtnDolares.TabIndex = 5;
            this.rbtnDolares.Text = "USD";
            this.rbtnDolares.UseVisualStyleBackColor = true;
            this.rbtnDolares.CheckedChanged += new System.EventHandler(this.rbtnDolares_CheckedChanged);
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(156, 107);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(91, 80);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.Size = new System.Drawing.Size(140, 21);
            this.txtResultado.TabIndex = 3;
            // 
            // txtValorCalcular
            // 
            this.txtValorCalcular.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorCalcular.Location = new System.Drawing.Point(91, 51);
            this.txtValorCalcular.Name = "txtValorCalcular";
            this.txtValorCalcular.Size = new System.Drawing.Size(140, 21);
            this.txtValorCalcular.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Resultado";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(6, 52);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(79, 13);
            this.lblValor.TabIndex = 0;
            this.lblValor.Text = "Valor a calcular";
            // 
            // txtUnidad
            // 
            this.txtUnidad.Location = new System.Drawing.Point(116, 103);
            this.txtUnidad.Name = "txtUnidad";
            this.txtUnidad.ReadOnly = true;
            this.txtUnidad.Size = new System.Drawing.Size(130, 21);
            this.txtUnidad.TabIndex = 9;
            // 
            // txtTRM
            // 
            this.txtTRM.Location = new System.Drawing.Point(116, 23);
            this.txtTRM.Name = "txtTRM";
            this.txtTRM.ReadOnly = true;
            this.txtTRM.Size = new System.Drawing.Size(130, 21);
            this.txtTRM.TabIndex = 8;
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Location = new System.Drawing.Point(116, 77);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.ReadOnly = true;
            this.txtIdentificador.Size = new System.Drawing.Size(130, 21);
            this.txtIdentificador.TabIndex = 6;
            // 
            // txtValidoDesde
            // 
            this.txtValidoDesde.Location = new System.Drawing.Point(116, 50);
            this.txtValidoDesde.Name = "txtValidoDesde";
            this.txtValidoDesde.ReadOnly = true;
            this.txtValidoDesde.Size = new System.Drawing.Size(130, 21);
            this.txtValidoDesde.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Identificador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Unidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Valido desde - hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "TRM";
            // 
            // gbCalendario
            // 
            this.gbCalendario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbCalendario.Controls.Add(this.monthCalendar1);
            this.gbCalendario.Location = new System.Drawing.Point(5, 120);
            this.gbCalendario.Name = "gbCalendario";
            this.gbCalendario.Size = new System.Drawing.Size(267, 225);
            this.gbCalendario.TabIndex = 1;
            this.gbCalendario.TabStop = false;
            this.gbCalendario.Text = "Calendario";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(9, 26);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // gbConfiguracion
            // 
            this.gbConfiguracion.Controls.Add(this.btnConsultar);
            this.gbConfiguracion.Controls.Add(this.chkOtraFecha);
            this.gbConfiguracion.Controls.Add(this.chkFechaActual);
            this.gbConfiguracion.Location = new System.Drawing.Point(5, 23);
            this.gbConfiguracion.Name = "gbConfiguracion";
            this.gbConfiguracion.Size = new System.Drawing.Size(267, 91);
            this.gbConfiguracion.TabIndex = 0;
            this.gbConfiguracion.TabStop = false;
            this.gbConfiguracion.Text = "Configuración";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(186, 62);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(75, 23);
            this.btnConsultar.TabIndex = 0;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // chkOtraFecha
            // 
            this.chkOtraFecha.AutoSize = true;
            this.chkOtraFecha.Location = new System.Drawing.Point(6, 43);
            this.chkOtraFecha.Name = "chkOtraFecha";
            this.chkOtraFecha.Size = new System.Drawing.Size(114, 17);
            this.chkOtraFecha.TabIndex = 1;
            this.chkOtraFecha.TabStop = true;
            this.chkOtraFecha.Text = "TRM de otra fecha";
            this.chkOtraFecha.UseVisualStyleBackColor = true;
            // 
            // chkFechaActual
            // 
            this.chkFechaActual.AutoSize = true;
            this.chkFechaActual.Checked = true;
            this.chkFechaActual.Location = new System.Drawing.Point(6, 20);
            this.chkFechaActual.Name = "chkFechaActual";
            this.chkFechaActual.Size = new System.Drawing.Size(134, 17);
            this.chkFechaActual.TabIndex = 0;
            this.chkFechaActual.TabStop = true;
            this.chkFechaActual.Text = "TRM de la fecha actual";
            this.chkFechaActual.UseVisualStyleBackColor = true;
            // 
            // FrmTRM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 350);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.Name = "FrmTRM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TRM Colombia";
            this.Load += new System.EventHandler(this.FrmTRM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.gbResultados.ResumeLayout(false);
            this.gbResultados.PerformLayout();
            this.gbOperaciones.ResumeLayout(false);
            this.gbOperaciones.PerformLayout();
            this.gbCalendario.ResumeLayout(false);
            this.gbConfiguracion.ResumeLayout(false);
            this.gbConfiguracion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbCalendario;
        private System.Windows.Forms.GroupBox gbConfiguracion;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.RadioButton chkOtraFecha;
        private System.Windows.Forms.RadioButton chkFechaActual;
        private System.Windows.Forms.TextBox txtTRM;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.TextBox txtValidoDesde;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.GroupBox gbOperaciones;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.TextBox txtValorCalcular;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtnPesos;
        private System.Windows.Forms.RadioButton rbtnDolares;
    }
}