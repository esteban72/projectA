namespace CarteraGeneral
{
    partial class FrmEnvioEscrituracion
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
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnEnviar = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.TxtCliente = new System.Windows.Forms.TextBox();
            this.LblCliente = new System.Windows.Forms.Label();
            this.LblComentario = new System.Windows.Forms.Label();
            this.RtbComentario = new System.Windows.Forms.RichTextBox();
            this.TxtAdjudicacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnSalir
            // 
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Location = new System.Drawing.Point(257, 282);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(75, 23);
            this.BtnSalir.TabIndex = 189;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnEnviar
            // 
            this.BtnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnEnviar.Location = new System.Drawing.Point(129, 282);
            this.BtnEnviar.Name = "BtnEnviar";
            this.BtnEnviar.Size = new System.Drawing.Size(75, 23);
            this.BtnEnviar.TabIndex = 188;
            this.BtnEnviar.Text = "Enviar";
            this.BtnEnviar.UseVisualStyleBackColor = true;
            this.BtnEnviar.Click += new System.EventHandler(this.BtnEnviar_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.Black;
            this.LblTitulo.Location = new System.Drawing.Point(126, 9);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(214, 13);
            this.LblTitulo.TabIndex = 187;
            this.LblTitulo.Text = "TRAMITAR ESCRITURA NEGOCIOS";
            // 
            // TxtCliente
            // 
            this.TxtCliente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCliente.Location = new System.Drawing.Point(119, 103);
            this.TxtCliente.Name = "TxtCliente";
            this.TxtCliente.Size = new System.Drawing.Size(225, 20);
            this.TxtCliente.TabIndex = 186;
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Location = new System.Drawing.Point(17, 103);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(39, 13);
            this.LblCliente.TabIndex = 185;
            this.LblCliente.Text = "Cliente";
            // 
            // LblComentario
            // 
            this.LblComentario.AutoSize = true;
            this.LblComentario.Location = new System.Drawing.Point(17, 142);
            this.LblComentario.Name = "LblComentario";
            this.LblComentario.Size = new System.Drawing.Size(60, 13);
            this.LblComentario.TabIndex = 184;
            this.LblComentario.Text = "Comentario";
            // 
            // RtbComentario
            // 
            this.RtbComentario.BackColor = System.Drawing.Color.White;
            this.RtbComentario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RtbComentario.Location = new System.Drawing.Point(86, 139);
            this.RtbComentario.Name = "RtbComentario";
            this.RtbComentario.Size = new System.Drawing.Size(258, 96);
            this.RtbComentario.TabIndex = 183;
            this.RtbComentario.Text = "";
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAdjudicacion.Location = new System.Drawing.Point(119, 71);
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.Size = new System.Drawing.Size(100, 20);
            this.TxtAdjudicacion.TabIndex = 182;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 181;
            this.label1.Text = "Adjudicacion";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 27);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 218;
            this.pictureBox1.TabStop = false;
            // 
            // FrmEnvioEscrituracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(377, 332);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnEnviar);
            this.Controls.Add(this.LblTitulo);
            this.Controls.Add(this.TxtCliente);
            this.Controls.Add(this.LblCliente);
            this.Controls.Add(this.LblComentario);
            this.Controls.Add(this.RtbComentario);
            this.Controls.Add(this.TxtAdjudicacion);
            this.Controls.Add(this.label1);
            this.Name = "FrmEnvioEscrituracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmEnvioEscrituracion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnEnviar;
        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.TextBox TxtCliente;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.Label LblComentario;
        private System.Windows.Forms.RichTextBox RtbComentario;
        private System.Windows.Forms.TextBox TxtAdjudicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}