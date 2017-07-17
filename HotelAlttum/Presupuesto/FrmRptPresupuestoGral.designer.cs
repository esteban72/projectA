namespace CarteraGeneral
{
    partial class FrmRptPresupuestoGral
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
            this.PnlSuperior = new System.Windows.Forms.Panel();
            this.LblAño = new System.Windows.Forms.Label();
            this.CmbMes = new System.Windows.Forms.ComboBox();
            this.LblFecha = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnCalcular = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.presupuestogralBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CarteraGeneralDataSet = new CarteraGeneral.CarteraGeneralDataSet();
            this.presupuestogralTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.presupuestogralTableAdapter();
            this.TxtAño = new System.Windows.Forms.ComboBox();
            this.PnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.presupuestogralBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlSuperior
            // 
            this.PnlSuperior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PnlSuperior.Controls.Add(this.TxtAño);
            this.PnlSuperior.Controls.Add(this.LblAño);
            this.PnlSuperior.Controls.Add(this.CmbMes);
            this.PnlSuperior.Controls.Add(this.LblFecha);
            this.PnlSuperior.Controls.Add(this.resultLabel);
            this.PnlSuperior.Controls.Add(this.BtnSalir);
            this.PnlSuperior.Controls.Add(this.BtnCalcular);
            this.PnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlSuperior.Name = "PnlSuperior";
            this.PnlSuperior.Size = new System.Drawing.Size(1268, 24);
            this.PnlSuperior.TabIndex = 250;
            // 
            // LblAño
            // 
            this.LblAño.AutoSize = true;
            this.LblAño.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAño.Location = new System.Drawing.Point(290, 4);
            this.LblAño.Name = "LblAño";
            this.LblAño.Size = new System.Drawing.Size(111, 16);
            this.LblAño.TabIndex = 271;
            this.LblAño.Text = "Año Presupuesto";
            // 
            // CmbMes
            // 
            this.CmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CmbMes.FormattingEnabled = true;
            this.CmbMes.Items.AddRange(new object[] {
            "Enero",
            "Febrero",
            "Marzo",
            "Abril",
            "Mayo",
            "Junio",
            "Julio",
            "Agosto",
            "Septiembre",
            "Octubre",
            "Noviembre",
            "Diciembre"});
            this.CmbMes.Location = new System.Drawing.Point(157, 2);
            this.CmbMes.Name = "CmbMes";
            this.CmbMes.Size = new System.Drawing.Size(121, 21);
            this.CmbMes.TabIndex = 269;
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFecha.Location = new System.Drawing.Point(15, 4);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(113, 16);
            this.LblFecha.TabIndex = 268;
            this.LblFecha.Text = "Mes Presupuesto";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(761, 9);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 13);
            this.resultLabel.TabIndex = 254;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.Location = new System.Drawing.Point(743, 3);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(28, 19);
            this.BtnSalir.TabIndex = 8;
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCalcular.Location = new System.Drawing.Point(683, 3);
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
            reportDataSource1.Value = this.presupuestogralBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteraGeneral.InfPresupuestoGeneral.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 24);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1268, 603);
            this.reportViewer1.TabIndex = 251;
            // 
            // presupuestogralBindingSource
            // 
            this.presupuestogralBindingSource.DataMember = "presupuestogral";
            this.presupuestogralBindingSource.DataSource = this.CarteraGeneralDataSet;
            // 
            // CarteraGeneralDataSet
            // 
            this.CarteraGeneralDataSet.DataSetName = "CarteraGeneralDataSet";
            this.CarteraGeneralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // presupuestogralTableAdapter
            // 
            this.presupuestogralTableAdapter.ClearBeforeFill = true;
            // 
            // TxtAño
            // 
            this.TxtAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TxtAño.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TxtAño.FormattingEnabled = true;
            this.TxtAño.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016"});
            this.TxtAño.Location = new System.Drawing.Point(407, 2);
            this.TxtAño.Name = "TxtAño";
            this.TxtAño.Size = new System.Drawing.Size(121, 21);
            this.TxtAño.TabIndex = 272;
            // 
            // FrmRptPresupuestoGral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 627);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.PnlSuperior);
            this.Name = "FrmRptPresupuestoGral";
            this.Text = "FrmRptPresupuestoGral";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRptPresupuestoGral_Load);
            this.PnlSuperior.ResumeLayout(false);
            this.PnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.presupuestogralBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlSuperior;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnCalcular;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource presupuestogralBindingSource;
        private CarteraGeneralDataSet CarteraGeneralDataSet;
        private CarteraGeneralDataSetTableAdapters.presupuestogralTableAdapter presupuestogralTableAdapter;
        private System.Windows.Forms.Label LblAño;
        private System.Windows.Forms.ComboBox CmbMes;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.ComboBox TxtAño;
    }
}