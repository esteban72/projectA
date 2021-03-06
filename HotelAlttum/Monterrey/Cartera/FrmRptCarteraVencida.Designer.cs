﻿namespace CarteraGeneral
{
    partial class FrmRptCarteraVencida
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
            this.BtnSalir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbTipoCartera = new System.Windows.Forms.ComboBox();
            this.BtnCalcular = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.rptcarteravencidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CarteraGeneralDataSet = new CarteraGeneral.CarteraGeneralDataSet();
            this.rptcarteravencidaTableAdapter = new CarteraGeneral.CarteraGeneralDataSetTableAdapters.rptcarteravencidaTableAdapter();
            this.PnlSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rptcarteravencidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlSuperior
            // 
            this.PnlSuperior.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.PnlSuperior.Controls.Add(this.BtnSalir);
            this.PnlSuperior.Controls.Add(this.label3);
            this.PnlSuperior.Controls.Add(this.CmbTipoCartera);
            this.PnlSuperior.Controls.Add(this.BtnCalcular);
            this.PnlSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSuperior.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PnlSuperior.Location = new System.Drawing.Point(0, 0);
            this.PnlSuperior.Name = "PnlSuperior";
            this.PnlSuperior.Size = new System.Drawing.Size(987, 30);
            this.PnlSuperior.TabIndex = 253;
            // 
            // BtnSalir
            // 
            this.BtnSalir.BackgroundImage = global::CarteraGeneral.Properties.Resources._1402297405_Gnome_Application_Exit_64;
            this.BtnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnSalir.Location = new System.Drawing.Point(295, 7);
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
            this.label3.Location = new System.Drawing.Point(7, 10);
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
            "Administrativa",
            "Comercial"});
            this.CmbTipoCartera.Location = new System.Drawing.Point(99, 6);
            this.CmbTipoCartera.Name = "CmbTipoCartera";
            this.CmbTipoCartera.Size = new System.Drawing.Size(121, 21);
            this.CmbTipoCartera.Sorted = true;
            this.CmbTipoCartera.TabIndex = 6;
            // 
            // BtnCalcular
            // 
            this.BtnCalcular.BackgroundImage = global::CarteraGeneral.Properties.Resources.search_48;
            this.BtnCalcular.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnCalcular.Location = new System.Drawing.Point(244, 8);
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
            reportDataSource1.Value = this.rptcarteravencidaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CarteraGeneral.InfCarteraVencida.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 30);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(987, 469);
            this.reportViewer1.TabIndex = 254;
            // 
            // rptcarteravencidaBindingSource
            // 
            this.rptcarteravencidaBindingSource.DataMember = "rptcarteravencida";
            this.rptcarteravencidaBindingSource.DataSource = this.CarteraGeneralDataSet;
            // 
            // CarteraGeneralDataSet
            // 
            this.CarteraGeneralDataSet.DataSetName = "CarteraGeneralDataSet";
            this.CarteraGeneralDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rptcarteravencidaTableAdapter
            // 
            this.rptcarteravencidaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRptCarteraVencida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 499);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.PnlSuperior);
            this.Name = "FrmRptCarteraVencida";
            this.Text = "FrmRptCarteraVencida";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmRptCarteraVencida_Load);
            this.PnlSuperior.ResumeLayout(false);
            this.PnlSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rptcarteravencidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CarteraGeneralDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlSuperior;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbTipoCartera;
        private System.Windows.Forms.Button BtnCalcular;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource rptcarteravencidaBindingSource;
        private CarteraGeneralDataSet CarteraGeneralDataSet;
        private CarteraGeneralDataSetTableAdapters.rptcarteravencidaTableAdapter rptcarteravencidaTableAdapter;
    }
}