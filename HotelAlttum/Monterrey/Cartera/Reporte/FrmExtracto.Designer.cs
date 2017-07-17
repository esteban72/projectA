namespace CarteraGeneral
{
    partial class FrmExtracto
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.rpt004sadlocarteraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CarteraGeneralDataSet = new CarteraGeneral.CarteraGeneralDataSet();
            this.rpt004diasmorasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TxtAdjudicacion = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TxtClinte = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rpt004sadlocarteraTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.rpt004sadlocarteraTableAdapter();
            this.rpt004diasmorasTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.rpt004diasmorasTableAdapter();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rpt004sadlocarteraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt004diasmorasBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rpt004sadlocarteraBindingSource
            // 
            this.rpt004sadlocarteraBindingSource.DataMember = "rpt004sadlocartera";
            this.rpt004sadlocarteraBindingSource.DataSource = this.CarteraGeneralDataSet;
            // 
            // CarteraGeneralDataSet
            // 
            this.CarteraGeneralDataSet.DataSetName = "CarteraGeneralDataSet";
            this.CarteraGeneralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rpt004diasmorasBindingSource
            // 
            this.rpt004diasmorasBindingSource.DataMember = "rpt004diasmoras";
            this.rpt004diasmorasBindingSource.DataSource = this.CarteraGeneralDataSet;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.TxtAdjudicacion,
            this.toolStripSeparator1,
            this.TxtClinte,
            this.toolStripSeparator2,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1046, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 24);
            this.toolStripLabel1.Text = "Adjudicacion";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(30, 27);
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.AutoSize = false;
            this.TxtAdjudicacion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.Size = new System.Drawing.Size(70, 27);
            this.TxtAdjudicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAdjudicacion_KeyPress);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(30, 25);
            // 
            // TxtClinte
            // 
            this.TxtClinte.BackColor = System.Drawing.Color.White;
            this.TxtClinte.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtClinte.Name = "TxtClinte";
            this.TxtClinte.ReadOnly = true;
            this.TxtClinte.Size = new System.Drawing.Size(300, 27);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(30, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(82, 24);
            this.toolStripLabel2.Text = "Fecha Final";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.rpt004sadlocarteraBindingSource;
            reportDataSource4.Name = "DataSet2";
            reportDataSource4.Value = this.rpt004diasmorasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteraGeneral.InfExtracto.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 27);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1046, 312);
            this.reportViewer1.TabIndex = 3;
            // 
            // rpt004sadlocarteraTableAdapter
            // 
            this.rpt004sadlocarteraTableAdapter.ClearBeforeFill = true;
            // 
            // rpt004diasmorasTableAdapter
            // 
            this.rpt004diasmorasTableAdapter.ClearBeforeFill = true;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(646, 4);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(85, 20);
            this.DtpFecha.TabIndex = 4;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnSalir.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Location = new System.Drawing.Point(815, 1);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(34, 23);
            this.BtnSalir.TabIndex = 7;
            this.BtnSalir.UseVisualStyleBackColor = false;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnBuscar.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBuscar.Location = new System.Drawing.Point(756, 1);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(34, 23);
            this.BtnBuscar.TabIndex = 6;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // FrmExtracto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 339);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FrmExtracto";
            this.Text = "FrmExtracto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmExtracto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rpt004sadlocarteraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpt004diasmorasBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox TxtAdjudicacion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripTextBox TxtClinte;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rpt004sadlocarteraBindingSource;
        private CarteraGeneralDataSet CarteraGeneralDataSet;
        private System.Windows.Forms.BindingSource rpt004diasmorasBindingSource;
        private CarteraGeneralDataSetTableAdapters.rpt004sadlocarteraTableAdapter rpt004sadlocarteraTableAdapter;
        private CarteraGeneralDataSetTableAdapters.rpt004diasmorasTableAdapter rpt004diasmorasTableAdapter;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnBuscar;
    }
}