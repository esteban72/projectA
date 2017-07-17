namespace CarteraGeneral
{
    partial class FrmImpRecibo
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
            this.impreciboBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CarteraGeneralDataSet = new CarteraGeneral.CarteraGeneralDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.impreciboTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.impreciboTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.impreciboBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // impreciboBindingSource
            // 
            this.impreciboBindingSource.DataMember = "imprecibo";
            this.impreciboBindingSource.DataSource = this.CarteraGeneralDataSet;
            // 
            // CarteraGeneralDataSet
            // 
            this.CarteraGeneralDataSet.DataSetName = "CarteraGeneralDataSet";
            this.CarteraGeneralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.impreciboBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteraGeneral.ReciboCajaRio.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(284, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // impreciboTableAdapter
            // 
            this.impreciboTableAdapter.ClearBeforeFill = true;
            // 
            // FrmImpRecibo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmImpRecibo";
            this.Text = "FrmImpRecibo";
            this.Load += new System.EventHandler(this.FrmImpRecibo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.impreciboBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource impreciboBindingSource;
        private CarteraGeneralDataSet CarteraGeneralDataSet;
        private CarteraGeneralDataSetTableAdapters.impreciboTableAdapter impreciboTableAdapter;
    }
}