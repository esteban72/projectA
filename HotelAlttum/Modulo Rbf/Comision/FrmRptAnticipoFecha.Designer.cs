namespace CarteraGeneral
{
    partial class FrmRptAnticipoFecha
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CarteraGeneralDataSet = new CarteraGeneral.CarteraGeneralDataSet();
            this.rptpagoanticipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptpagoanticipoTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.rptpagoanticipoTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.Btnok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnBusqueda2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptpagoanticipoBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.rptpagoanticipoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteraGeneral.RptAnticiposporfecha.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 28);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(961, 381);
            this.reportViewer1.TabIndex = 0;
            // 
            // CarteraGeneralDataSet
            // 
            this.CarteraGeneralDataSet.DataSetName = "CarteraGeneralDataSet";
            this.CarteraGeneralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptpagoanticipoBindingSource
            // 
            this.rptpagoanticipoBindingSource.DataMember = "rptpagoanticipo";
            this.rptpagoanticipoBindingSource.DataSource = this.CarteraGeneralDataSet;
            // 
            // rptpagoanticipoTableAdapter
            // 
            this.rptpagoanticipoTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DtpFechaFin);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnBusqueda2);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.DtpFechaInicio);
            this.panel1.Controls.Add(this.Btnok);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(961, 28);
            this.panel1.TabIndex = 219;
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(372, 4);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(93, 20);
            this.DtpFechaFin.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 68;
            this.label2.Text = "Fecha Fin:";
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.Location = new System.Drawing.Point(1116, 3);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(23, 23);
            this.BtnSalir.TabIndex = 6;
            this.BtnSalir.UseVisualStyleBackColor = true;
            // 
            // DtpFechaInicio
            // 
            this.DtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaInicio.Location = new System.Drawing.Point(208, 4);
            this.DtpFechaInicio.Name = "DtpFechaInicio";
            this.DtpFechaInicio.Size = new System.Drawing.Size(93, 20);
            this.DtpFechaInicio.TabIndex = 1;
            // 
            // Btnok
            // 
            this.Btnok.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.Btnok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Btnok.Location = new System.Drawing.Point(1068, 3);
            this.Btnok.Name = "Btnok";
            this.Btnok.Size = new System.Drawing.Size(23, 23);
            this.Btnok.TabIndex = 5;
            this.Btnok.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Fecha Inicio:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 25);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 63;
            this.pictureBox1.TabStop = false;
            // 
            // BtnBusqueda2
            // 
            this.BtnBusqueda2.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnBusqueda2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBusqueda2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBusqueda2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBusqueda2.Location = new System.Drawing.Point(499, 6);
            this.BtnBusqueda2.Name = "BtnBusqueda2";
            this.BtnBusqueda2.Size = new System.Drawing.Size(20, 20);
            this.BtnBusqueda2.TabIndex = 216;
            this.BtnBusqueda2.UseVisualStyleBackColor = true;
            this.BtnBusqueda2.Click += new System.EventHandler(this.BtnBusqueda2_Click);
            // 
            // FrmRptAnticipoFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 409);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRptAnticipoFecha";
            this.Text = "FrmRptAnticipoFecha";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRptAnticipoFecha_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptpagoanticipoBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptpagoanticipoBindingSource;
        private CarteraGeneralDataSet CarteraGeneralDataSet;
        private CarteraGeneralDataSetTableAdapters.rptpagoanticipoTableAdapter rptpagoanticipoTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnBusqueda2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DateTimePicker DtpFechaInicio;
        private System.Windows.Forms.Button Btnok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}