namespace CarteraGeneral
{
    partial class FrmParametros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmParametros));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxtInteresCte = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnAceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TxtPeriodo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtInteresMora = new System.Windows.Forms.TextBox();
            this.TxtPorcetanje = new System.Windows.Forms.TextBox();
            this.TxtDiasMora = new System.Windows.Forms.TextBox();
            this.TxtDecimales = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFuente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCentroCosto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtSubCentro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 372);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(336, 22);
            this.statusStrip1.TabIndex = 69;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.Location = new System.Drawing.Point(111, 6);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(121, 20);
            this.LblTitulo.TabIndex = 28;
            this.LblTitulo.Text = "PARAMETROS";
            // 
            // TxtInteresCte
            // 
            this.TxtInteresCte.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtInteresCte.Location = new System.Drawing.Point(208, 52);
            this.TxtInteresCte.MaxLength = 10;
            this.TxtInteresCte.Name = "TxtInteresCte";
            this.TxtInteresCte.Size = new System.Drawing.Size(59, 20);
            this.TxtInteresCte.TabIndex = 1;
            this.TxtInteresCte.Text = "0";
            this.TxtInteresCte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtInteresCte.Enter += new System.EventHandler(this.TxtInteresCte_Enter);
            this.TxtInteresCte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtInteresCte_KeyPress);
            this.TxtInteresCte.Leave += new System.EventHandler(this.TxtInteresCte_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(70, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 68;
            this.label6.Text = "Interes Cte";
            // 
            // BtnSalir
            // 
            this.BtnSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.ForeColor = System.Drawing.Color.Black;
            this.BtnSalir.Location = new System.Drawing.Point(192, 333);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(61, 23);
            this.BtnSalir.TabIndex = 13;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            this.BtnSalir.DragLeave += new System.EventHandler(this.BtnSalir_DragLeave);
            this.BtnSalir.Enter += new System.EventHandler(this.BtnSalir_Enter);
            // 
            // BtnAceptar
            // 
            this.BtnAceptar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAceptar.ForeColor = System.Drawing.Color.Black;
            this.BtnAceptar.Location = new System.Drawing.Point(84, 333);
            this.BtnAceptar.Name = "BtnAceptar";
            this.BtnAceptar.Size = new System.Drawing.Size(61, 23);
            this.BtnAceptar.TabIndex = 12;
            this.BtnAceptar.Text = "Actualizar";
            this.BtnAceptar.UseVisualStyleBackColor = true;
            this.BtnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            this.BtnAceptar.Enter += new System.EventHandler(this.BtnAceptar_Enter);
            this.BtnAceptar.Leave += new System.EventHandler(this.BtnAceptar_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 30);
            this.panel1.TabIndex = 67;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(98, 21);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // TxtPeriodo
            // 
            this.TxtPeriodo.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtPeriodo.Location = new System.Drawing.Point(208, 142);
            this.TxtPeriodo.MaxLength = 10;
            this.TxtPeriodo.Name = "TxtPeriodo";
            this.TxtPeriodo.Size = new System.Drawing.Size(59, 20);
            this.TxtPeriodo.TabIndex = 4;
            this.TxtPeriodo.Text = "0";
            this.TxtPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPeriodo.Enter += new System.EventHandler(this.TxtPeriodo_Enter);
            this.TxtPeriodo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPeriodo_KeyPress);
            this.TxtPeriodo.Leave += new System.EventHandler(this.TxtPeriodo_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 63;
            this.label4.Text = "Periodo Activo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Porcentaje";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Interes Mora";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(70, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 70;
            this.label7.Text = "Dias Mora";
            // 
            // TxtInteresMora
            // 
            this.TxtInteresMora.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtInteresMora.Location = new System.Drawing.Point(208, 82);
            this.TxtInteresMora.MaxLength = 30;
            this.TxtInteresMora.Name = "TxtInteresMora";
            this.TxtInteresMora.Size = new System.Drawing.Size(59, 20);
            this.TxtInteresMora.TabIndex = 2;
            this.TxtInteresMora.Text = "0";
            this.TxtInteresMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtInteresMora.Enter += new System.EventHandler(this.TxtInteresMora_Enter);
            this.TxtInteresMora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtInteresMora_KeyPress);
            this.TxtInteresMora.Leave += new System.EventHandler(this.TxtInteresMora_Leave);
            // 
            // TxtPorcetanje
            // 
            this.TxtPorcetanje.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtPorcetanje.Location = new System.Drawing.Point(208, 112);
            this.TxtPorcetanje.MaxLength = 30;
            this.TxtPorcetanje.Name = "TxtPorcetanje";
            this.TxtPorcetanje.Size = new System.Drawing.Size(59, 20);
            this.TxtPorcetanje.TabIndex = 3;
            this.TxtPorcetanje.Text = "0";
            this.TxtPorcetanje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtPorcetanje.Enter += new System.EventHandler(this.TxtPorcetanje_Enter);
            this.TxtPorcetanje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPorcetanje_KeyPress);
            this.TxtPorcetanje.Leave += new System.EventHandler(this.TxtPorcetanje_Leave);
            // 
            // TxtDiasMora
            // 
            this.TxtDiasMora.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtDiasMora.Location = new System.Drawing.Point(208, 172);
            this.TxtDiasMora.MaxLength = 30;
            this.TxtDiasMora.Name = "TxtDiasMora";
            this.TxtDiasMora.Size = new System.Drawing.Size(59, 20);
            this.TxtDiasMora.TabIndex = 5;
            this.TxtDiasMora.Text = "10";
            this.TxtDiasMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtDiasMora.Enter += new System.EventHandler(this.TxtDiasMora_Enter);
            this.TxtDiasMora.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDiasMora_KeyPress);
            this.TxtDiasMora.Leave += new System.EventHandler(this.TxtDiasMora_Leave);
            // 
            // TxtDecimales
            // 
            this.TxtDecimales.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtDecimales.Location = new System.Drawing.Point(208, 202);
            this.TxtDecimales.MaxLength = 1;
            this.TxtDecimales.Name = "TxtDecimales";
            this.TxtDecimales.Size = new System.Drawing.Size(59, 20);
            this.TxtDecimales.TabIndex = 6;
            this.TxtDecimales.Text = "2";
            this.TxtDecimales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtDecimales.Enter += new System.EventHandler(this.TxtDecimales_Enter);
            this.TxtDecimales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtDecimales_KeyPress);
            this.TxtDecimales.Leave += new System.EventHandler(this.TxtDecimales_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Decimales";
            // 
            // TxtFuente
            // 
            this.TxtFuente.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtFuente.Location = new System.Drawing.Point(208, 232);
            this.TxtFuente.MaxLength = 5;
            this.TxtFuente.Name = "TxtFuente";
            this.TxtFuente.Size = new System.Drawing.Size(59, 20);
            this.TxtFuente.TabIndex = 7;
            this.TxtFuente.Text = "2";
            this.TxtFuente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtFuente.Enter += new System.EventHandler(this.TxtFuente_Enter);
            this.TxtFuente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtFuente_KeyPress);
            this.TxtFuente.Leave += new System.EventHandler(this.TxtFuente_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(70, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Fuente de Recaudos";
            // 
            // TxtCentroCosto
            // 
            this.TxtCentroCosto.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtCentroCosto.Location = new System.Drawing.Point(208, 262);
            this.TxtCentroCosto.MaxLength = 2;
            this.TxtCentroCosto.Name = "TxtCentroCosto";
            this.TxtCentroCosto.Size = new System.Drawing.Size(59, 20);
            this.TxtCentroCosto.TabIndex = 8;
            this.TxtCentroCosto.Text = "2";
            this.TxtCentroCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtCentroCosto.Enter += new System.EventHandler(this.TxtCentroCosto_Enter);
            this.TxtCentroCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCentroCosto_KeyPress);
            this.TxtCentroCosto.Leave += new System.EventHandler(this.TxtCentroCosto_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 76;
            this.label8.Text = "CentroCosto";
            // 
            // TxtSubCentro
            // 
            this.TxtSubCentro.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtSubCentro.Location = new System.Drawing.Point(208, 292);
            this.TxtSubCentro.MaxLength = 2;
            this.TxtSubCentro.Name = "TxtSubCentro";
            this.TxtSubCentro.Size = new System.Drawing.Size(59, 20);
            this.TxtSubCentro.TabIndex = 9;
            this.TxtSubCentro.Text = "2";
            this.TxtSubCentro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TxtSubCentro.Enter += new System.EventHandler(this.TxtSubCentro_Enter);
            this.TxtSubCentro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSubCentro_KeyPress);
            this.TxtSubCentro.Leave += new System.EventHandler(this.TxtSubCentro_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 297);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 78;
            this.label9.Text = "SubCentro";
            // 
            // FrmParametros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 394);
            this.Controls.Add(this.TxtSubCentro);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TxtCentroCosto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.TxtFuente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TxtDecimales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtDiasMora);
            this.Controls.Add(this.TxtPorcetanje);
            this.Controls.Add(this.TxtInteresMora);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TxtInteresCte);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnAceptar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TxtPeriodo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmParametros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmParametros";
            this.Load += new System.EventHandler(this.FrmParametros_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox TxtInteresCte;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnAceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtPeriodo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtInteresMora;
        private System.Windows.Forms.TextBox TxtPorcetanje;
        private System.Windows.Forms.TextBox TxtDiasMora;
        private System.Windows.Forms.TextBox TxtDecimales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtFuente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCentroCosto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtSubCentro;
        private System.Windows.Forms.Label label9;
    }
}