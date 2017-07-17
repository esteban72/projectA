namespace CarteraGeneral
{
    partial class FrmRptPagoCmsPorAsesor
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
            this.rptpagocomisionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CarteraGeneralDataSet = new CarteraGeneral.CarteraGeneralDataSet();
            this.LblAsesor = new System.Windows.Forms.Label();
            this.LblNombre2 = new System.Windows.Forms.Label();
            this.BtnBusqueda2 = new System.Windows.Forms.Button();
            this.TxtAsesor = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.DtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.Btnok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptpagocomisionTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.rptpagocomisionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.rptpagocomisionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // rptpagocomisionBindingSource
            // 
            this.rptpagocomisionBindingSource.DataMember = "rptpagocomision";
            this.rptpagocomisionBindingSource.DataSource = this.CarteraGeneralDataSet;
            // 
            // CarteraGeneralDataSet
            // 
            this.CarteraGeneralDataSet.DataSetName = "CarteraGeneralDataSet";
            this.CarteraGeneralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LblAsesor
            // 
            this.LblAsesor.AutoSize = true;
            this.LblAsesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAsesor.Location = new System.Drawing.Point(662, 7);
            this.LblAsesor.Name = "LblAsesor";
            this.LblAsesor.Size = new System.Drawing.Size(44, 15);
            this.LblAsesor.TabIndex = 217;
            this.LblAsesor.Text = "Asesor";
            // 
            // LblNombre2
            // 
            this.LblNombre2.AutoSize = true;
            this.LblNombre2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNombre2.Location = new System.Drawing.Point(480, 7);
            this.LblNombre2.Name = "LblNombre2";
            this.LblNombre2.Size = new System.Drawing.Size(47, 15);
            this.LblNombre2.TabIndex = 215;
            this.LblNombre2.Text = "Asesor:";
            // 
            // BtnBusqueda2
            // 
            this.BtnBusqueda2.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnBusqueda2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBusqueda2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBusqueda2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBusqueda2.Location = new System.Drawing.Point(636, 4);
            this.BtnBusqueda2.Name = "BtnBusqueda2";
            this.BtnBusqueda2.Size = new System.Drawing.Size(20, 20);
            this.BtnBusqueda2.TabIndex = 216;
            this.BtnBusqueda2.UseVisualStyleBackColor = true;
            this.BtnBusqueda2.Click += new System.EventHandler(this.BtnBusqueda2_Click);
            // 
            // TxtAsesor
            // 
            this.TxtAsesor.BackColor = System.Drawing.Color.Gainsboro;
            this.TxtAsesor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAsesor.Location = new System.Drawing.Point(530, 4);
            this.TxtAsesor.MaxLength = 40;
            this.TxtAsesor.Name = "TxtAsesor";
            this.TxtAsesor.Size = new System.Drawing.Size(100, 21);
            this.TxtAsesor.TabIndex = 4;
            this.TxtAsesor.Enter += new System.EventHandler(this.TxtAsesor_Enter);
            this.TxtAsesor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAsesor_KeyPress);
            this.TxtAsesor.Leave += new System.EventHandler(this.TxtAsesor_Leave);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DtpFechaFin);
            this.panel1.Controls.Add(this.LblAsesor);
            this.panel1.Controls.Add(this.LblNombre2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.BtnBusqueda2);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.TxtAsesor);
            this.panel1.Controls.Add(this.DtpFechaInicio);
            this.panel1.Controls.Add(this.Btnok);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1255, 28);
            this.panel1.TabIndex = 218;
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
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
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
            this.Btnok.Click += new System.EventHandler(this.Btnok_Click);
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
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.rptpagocomisionBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteraGeneral.RptComisionesPorAsesor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 28);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1255, 353);
            this.reportViewer1.TabIndex = 219;
            // 
            // rptpagocomisionTableAdapter
            // 
            this.rptpagocomisionTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRptPagoCmsPorAsesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 381);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRptPagoCmsPorAsesor";
            this.Text = "FrmRptPagoCmsPorAsesor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRptPagoCmsPorAsesor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rptpagocomisionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblAsesor;
        private System.Windows.Forms.Label LblNombre2;
        private System.Windows.Forms.Button BtnBusqueda2;
        public System.Windows.Forms.TextBox TxtAsesor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.DateTimePicker DtpFechaInicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptpagocomisionBindingSource;
        private CarteraGeneralDataSet CarteraGeneralDataSet;
        private CarteraGeneralDataSetTableAdapters.rptpagocomisionTableAdapter rptpagocomisionTableAdapter;
        private System.Windows.Forms.Button Btnok;
    }
}