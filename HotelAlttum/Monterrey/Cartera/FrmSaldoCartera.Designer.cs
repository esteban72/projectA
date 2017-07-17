namespace CarteraGeneral
{
    partial class FrmSaldoCartera
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rptsaldocarteraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CarteraGeneralDataSet = new CarteraGeneral.CarteraGeneralDataSet();
            this.PnlSuperior = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.BtnCalcular = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptsaldocarteraTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.rptsaldocarteraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.rptsaldocarteraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).BeginInit();
            this.PnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptsaldocarteraBindingSource
            // 
            this.rptsaldocarteraBindingSource.DataMember = "rptsaldocartera";
            this.rptsaldocarteraBindingSource.DataSource = this.CarteraGeneralDataSet;
            // 
            // CarteraGeneralDataSet
            // 
            this.CarteraGeneralDataSet.DataSetName = "CarteraGeneralDataSet";
            this.CarteraGeneralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PnlSuperior
            // 
            this.PnlSuperior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PnlSuperior.Controls.Add(this.BtnSalir);
            this.PnlSuperior.Controls.Add(this.label2);
            this.PnlSuperior.Controls.Add(this.DtpFechaFin);
            this.PnlSuperior.Controls.Add(this.BtnCalcular);
            this.PnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSuperior.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlSuperior.Name = "PnlSuperior";
            this.PnlSuperior.Size = new System.Drawing.Size(1267, 30);
            this.PnlSuperior.TabIndex = 254;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(338, 6);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(28, 19);
            this.BtnSalir.TabIndex = 8;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(26, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Corte";
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(116, 5);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(99, 20);
            this.DtpFechaFin.TabIndex = 1;
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCalcular.Location = new System.Drawing.Point(261, 6);
            this.BtnCalcular.Name = "BtnCalcular";
            this.BtnCalcular.Size = new System.Drawing.Size(28, 19);
            this.BtnCalcular.TabIndex = 3;
            this.BtnCalcular.UseVisualStyleBackColor = true;
            this.BtnCalcular.Click += new System.EventHandler(this.BtnCalcular_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.rptsaldocarteraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteraGeneral.InfSaldoCartera.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 30);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1267, 553);
            this.reportViewer1.TabIndex = 255;
            // 
            // rptsaldocarteraTableAdapter
            // 
            this.rptsaldocarteraTableAdapter.ClearBeforeFill = true;
            // 
            // FrmSaldoCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 583);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.PnlSuperior);
            this.Name = "FrmSaldoCartera";
            this.Text = "FrmSaldoCartera";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmSaldoCartera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rptsaldocarteraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).EndInit();
            this.PnlSuperior.ResumeLayout(false);
            this.PnlSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlSuperior;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Button BtnCalcular;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptsaldocarteraBindingSource;
        private CarteraGeneralDataSet CarteraGeneralDataSet;
        private CarteraGeneralDataSetTableAdapters.rptsaldocarteraTableAdapter rptsaldocarteraTableAdapter;
    }
}