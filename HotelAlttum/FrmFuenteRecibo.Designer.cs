namespace CarteraGeneral
{
    partial class FrmFuenteRecibo
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
            this.CmbFuenteR = new System.Windows.Forms.ComboBox();
            this.BtnConfir = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CmbFuenteR
            // 
            this.CmbFuenteR.AllowDrop = true;
            this.CmbFuenteR.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbFuenteR.FormattingEnabled = true;
            this.CmbFuenteR.Items.AddRange(new object[] {
            "Recibo Caja",
            "Recibo Pago"});
            this.CmbFuenteR.Location = new System.Drawing.Point(24, 76);
            this.CmbFuenteR.Name = "CmbFuenteR";
            this.CmbFuenteR.Size = new System.Drawing.Size(430, 37);
            this.CmbFuenteR.TabIndex = 0;
            // 
            // BtnConfir
            // 
            this.BtnConfir.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConfir.Location = new System.Drawing.Point(24, 141);
            this.BtnConfir.Name = "BtnConfir";
            this.BtnConfir.Size = new System.Drawing.Size(170, 42);
            this.BtnConfir.TabIndex = 1;
            this.BtnConfir.Text = "Confirmar";
            this.BtnConfir.UseVisualStyleBackColor = true;
            this.BtnConfir.Click += new System.EventHandler(this.BtnConfir_Click);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalir.Location = new System.Drawing.Point(284, 141);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(170, 42);
            this.BtnSalir.TabIndex = 2;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(366, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "SELECCIONAR TIPO RECIBO";
            // 
            // FrmFuenteRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 216);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnConfir);
            this.Controls.Add(this.CmbFuenteR);
            this.Name = "FrmFuenteRecibo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo Recibo";
            this.Load += new System.EventHandler(this.FrmFuenteRecibo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbFuenteR;
        private System.Windows.Forms.Button BtnConfir;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label1;
    }
}