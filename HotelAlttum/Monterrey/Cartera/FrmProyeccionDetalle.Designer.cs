namespace CarteraGeneral
{
    partial class FrmProyeccionDetalle
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
            this.rptproyecciondetalleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CarteraGeneralDataSet = new CarteraGeneral.CarteraGeneralDataSet();
            this.PnlSuperior = new System.Windows.Forms.Panel();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbTipoCartera = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.DtpFechaCorte = new System.Windows.Forms.DateTimePicker();
            this.DtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.BtnCalcular = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptproyecciondetalleTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.rptproyecciondetalleTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.rptproyecciondetalleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).BeginInit();
            this.PnlSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // rptproyecciondetalleBindingSource
            // 
            this.rptproyecciondetalleBindingSource.DataMember = "rptproyecciondetalle";
            this.rptproyecciondetalleBindingSource.DataSource = this.CarteraGeneralDataSet;
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
            this.PnlSuperior.Controls.Add(this.label3);
            this.PnlSuperior.Controls.Add(this.CmbTipoCartera);
            this.PnlSuperior.Controls.Add(this.label2);
            this.PnlSuperior.Controls.Add(this.label1);
            this.PnlSuperior.Controls.Add(this.DtpFechaCorte);
            this.PnlSuperior.Controls.Add(this.DtpFechaFin);
            this.PnlSuperior.Controls.Add(this.BtnCalcular);
            this.PnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSuperior.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlSuperior.Name = "PnlSuperior";
            this.PnlSuperior.Size = new System.Drawing.Size(1263, 30);
            this.PnlSuperior.TabIndex = 252;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(881, 6);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(28, 19);
            this.BtnSalir.TabIndex = 8;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(593, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tipo Cartera";
            // 
            // CmbTipoCartera
            // 
            this.CmbTipoCartera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTipoCartera.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbTipoCartera.FormattingEnabled = true;
            this.CmbTipoCartera.Items.AddRange(new object[] {
            "CE",
            "CI",
            "CO",
            "FN",
            "Todos"});
            this.CmbTipoCartera.Location = new System.Drawing.Point(685, 5);
            this.CmbTipoCartera.Name = "CmbTipoCartera";
            this.CmbTipoCartera.Size = new System.Drawing.Size(121, 21);
            this.CmbTipoCartera.Sorted = true;
            this.CmbTipoCartera.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(198, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha Inicial";
            // 
            // DtpFechaCorte
            // 
            this.DtpFechaCorte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaCorte.Location = new System.Drawing.Point(90, 5);
            this.DtpFechaCorte.Name = "DtpFechaCorte";
            this.DtpFechaCorte.Size = new System.Drawing.Size(101, 20);
            this.DtpFechaCorte.TabIndex = 0;
            // 
            // DtpFechaFin
            // 
            this.DtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaFin.Location = new System.Drawing.Point(288, 5);
            this.DtpFechaFin.Name = "DtpFechaFin";
            this.DtpFechaFin.Size = new System.Drawing.Size(99, 20);
            this.DtpFechaFin.TabIndex = 1;
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCalcular.Location = new System.Drawing.Point(830, 7);
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
            reportDataSource1.Value = this.rptproyecciondetalleBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteraGeneral.InfProyecionDetallada.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 30);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1263, 399);
            this.reportViewer1.TabIndex = 253;
            // 
            // rptproyecciondetalleTableAdapter
            // 
            this.rptproyecciondetalleTableAdapter.ClearBeforeFill = true;
            // 
            // FrmProyeccionDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 429);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.PnlSuperior);
            this.Name = "FrmProyeccionDetalle";
            this.Text = "FrmProyeccionDetalle";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmProyeccionDetalle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rptproyecciondetalleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).EndInit();
            this.PnlSuperior.ResumeLayout(false);
            this.PnlSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlSuperior;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbTipoCartera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtpFechaCorte;
        private System.Windows.Forms.DateTimePicker DtpFechaFin;
        private System.Windows.Forms.Button BtnCalcular;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptproyecciondetalleBindingSource;
        private CarteraGeneralDataSet CarteraGeneralDataSet;
        private CarteraGeneralDataSetTableAdapters.rptproyecciondetalleTableAdapter rptproyecciondetalleTableAdapter;
    }
}