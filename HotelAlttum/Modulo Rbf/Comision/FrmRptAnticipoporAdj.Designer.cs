namespace CarteraGeneral
{
    partial class FrmRptAnticipoporAdj
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnBusqueda2 = new System.Windows.Forms.Button();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.Btnok = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.CarteraGeneralDataSet = new CarteraGeneral.CarteraGeneralDataSet();
            this.rptpagoanticipoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rptpagoanticipoTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.rptpagoanticipoTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtAdjudicacion = new System.Windows.Forms.TextBox();
            this.LblCliente = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptpagoanticipoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblCliente);
            this.panel1.Controls.Add(this.TxtAdjudicacion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnBusqueda2);
            this.panel1.Controls.Add(this.BtnSalir);
            this.panel1.Controls.Add(this.Btnok);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 28);
            this.panel1.TabIndex = 220;
            // 
            // BtnBusqueda2
            // 
            this.BtnBusqueda2.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnBusqueda2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnBusqueda2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnBusqueda2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBusqueda2.Location = new System.Drawing.Point(649, 5);
            this.BtnBusqueda2.Name = "BtnBusqueda2";
            this.BtnBusqueda2.Size = new System.Drawing.Size(20, 20);
            this.BtnBusqueda2.TabIndex = 216;
            this.BtnBusqueda2.UseVisualStyleBackColor = true;
            this.BtnBusqueda2.Click += new System.EventHandler(this.BtnBusqueda2_Click);
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
            reportDataSource4.Name = "DataSet1";
            reportDataSource4.Value = this.rptpagoanticipoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteraGeneral.RptAnticipoporAdjudicacion.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 28);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(957, 334);
            this.reportViewer1.TabIndex = 221;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 217;
            this.label1.Text = "Adjudicacion";
            // 
            // TxtAdjudicacion
            // 
            this.TxtAdjudicacion.Location = new System.Drawing.Point(238, 3);
            this.TxtAdjudicacion.MaxLength = 10;
            this.TxtAdjudicacion.Name = "TxtAdjudicacion";
            this.TxtAdjudicacion.Size = new System.Drawing.Size(52, 20);
            this.TxtAdjudicacion.TabIndex = 218;
            this.TxtAdjudicacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAdjudicacion_KeyPress);
            // 
            // LblCliente
            // 
            this.LblCliente.AutoSize = true;
            this.LblCliente.Location = new System.Drawing.Point(305, 6);
            this.LblCliente.Name = "LblCliente";
            this.LblCliente.Size = new System.Drawing.Size(68, 13);
            this.LblCliente.TabIndex = 219;
            this.LblCliente.Text = "Adjudicacion";
            // 
            // FrmRptAnticipoporAdj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 362);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmRptAnticipoporAdj";
            this.Text = "FrmRptAnticipoporAdj";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRptAnticipoporAdj_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rptpagoanticipoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnBusqueda2;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button Btnok;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptpagoanticipoBindingSource;
        private CarteraGeneralDataSet CarteraGeneralDataSet;
        private CarteraGeneralDataSetTableAdapters.rptpagoanticipoTableAdapter rptpagoanticipoTableAdapter;
        private System.Windows.Forms.Label LblCliente;
        private System.Windows.Forms.TextBox TxtAdjudicacion;
        private System.Windows.Forms.Label label1;
    }
}