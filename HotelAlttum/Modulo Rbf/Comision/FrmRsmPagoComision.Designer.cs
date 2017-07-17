namespace CarteraGeneral
{
    partial class FrmRsmPagoComision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRsmPagoComision));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.DtpFecha = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.BtnConsultar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GrdComisiones = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdTercero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Asesor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Comision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Retencion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DctoAnticipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PagoNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdComisiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.DtpFecha,
            this.BtnConsultar,
            this.BtnImprimir});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 4;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1});
            this.ribbon.Size = new System.Drawing.Size(1248, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Caption = "Fecha:";
            this.DtpFecha.Edit = this.repositoryItemDateEdit1;
            this.DtpFecha.Id = 1;
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Width = 120;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Caption = "Consultar";
            this.BtnConsultar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnConsultar.Glyph")));
            this.BtnConsultar.Id = 2;
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnConsultar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnConsultar_ItemClick);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Caption = "Imprimir";
            this.BtnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Glyph")));
            this.BtnImprimir.Id = 3;
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnImprimir_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.DtpFecha);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnConsultar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnImprimir);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 504);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1248, 31);
            // 
            // GrdComisiones
            // 
            this.GrdComisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdComisiones.Location = new System.Drawing.Point(0, 143);
            this.GrdComisiones.MainView = this.gridView1;
            this.GrdComisiones.MenuManager = this.ribbon;
            this.GrdComisiones.Name = "GrdComisiones";
            this.GrdComisiones.Size = new System.Drawing.Size(1248, 361);
            this.GrdComisiones.TabIndex = 2;
            this.GrdComisiones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdTercero,
            this.Asesor,
            this.Comision,
            this.Retencion,
            this.DctoAnticipo,
            this.PagoNeto});
            this.gridView1.GridControl = this.GrdComisiones;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Comision", this.Comision, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DctoAnticipo", this.DctoAnticipo, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PagoNeto", this.PagoNeto, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Retencion", this.Retencion, "{0:c2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // IdTercero
            // 
            this.IdTercero.Caption = "IdTercero";
            this.IdTercero.FieldName = "IdTercero";
            this.IdTercero.Name = "IdTercero";
            this.IdTercero.Visible = true;
            this.IdTercero.VisibleIndex = 0;
            this.IdTercero.Width = 96;
            // 
            // Asesor
            // 
            this.Asesor.Caption = "Asesor";
            this.Asesor.FieldName = "Asesor";
            this.Asesor.Name = "Asesor";
            this.Asesor.Visible = true;
            this.Asesor.VisibleIndex = 1;
            this.Asesor.Width = 244;
            // 
            // Comision
            // 
            this.Comision.Caption = "Comision";
            this.Comision.DisplayFormat.FormatString = "{0:c2}";
            this.Comision.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Comision.FieldName = "Comision";
            this.Comision.GroupFormat.FormatString = "{0:c2}";
            this.Comision.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Comision.Name = "Comision";
            this.Comision.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Comision", "SUMA={0:#.##}")});
            this.Comision.Visible = true;
            this.Comision.VisibleIndex = 2;
            this.Comision.Width = 175;
            // 
            // Retencion
            // 
            this.Retencion.Caption = "Retencion";
            this.Retencion.DisplayFormat.FormatString = "{0:c2}";
            this.Retencion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Retencion.FieldName = "Retencion";
            this.Retencion.GroupFormat.FormatString = "{0:c2}";
            this.Retencion.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Retencion.Name = "Retencion";
            this.Retencion.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Retencion", "SUMA={0:#.##}")});
            this.Retencion.Visible = true;
            this.Retencion.VisibleIndex = 3;
            this.Retencion.Width = 175;
            // 
            // DctoAnticipo
            // 
            this.DctoAnticipo.Caption = "DctoAnticipo";
            this.DctoAnticipo.DisplayFormat.FormatString = "{0:c2}";
            this.DctoAnticipo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DctoAnticipo.FieldName = "DctoAnticipo";
            this.DctoAnticipo.GroupFormat.FormatString = "{0:c2}";
            this.DctoAnticipo.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DctoAnticipo.Name = "DctoAnticipo";
            this.DctoAnticipo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DctoAnticipo", "SUMA={0:#.##}")});
            this.DctoAnticipo.Visible = true;
            this.DctoAnticipo.VisibleIndex = 4;
            this.DctoAnticipo.Width = 175;
            // 
            // PagoNeto
            // 
            this.PagoNeto.Caption = "Pago Neto";
            this.PagoNeto.DisplayFormat.FormatString = "{0:c2}";
            this.PagoNeto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PagoNeto.FieldName = "PagoNeto";
            this.PagoNeto.GroupFormat.FormatString = "{0:c2}";
            this.PagoNeto.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.PagoNeto.Name = "PagoNeto";
            this.PagoNeto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PagoNeto", "SUMA={0:#.##}")});
            this.PagoNeto.Visible = true;
            this.PagoNeto.VisibleIndex = 5;
            this.PagoNeto.Width = 175;
            // 
            // FrmRsmPagoComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 535);
            this.Controls.Add(this.GrdComisiones);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmRsmPagoComision";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmRsmPagoComision";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdComisiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarEditItem DtpFecha;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem BtnConsultar;
        private DevExpress.XtraBars.BarButtonItem BtnImprimir;
        private DevExpress.XtraGrid.GridControl GrdComisiones;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IdTercero;
        private DevExpress.XtraGrid.Columns.GridColumn Asesor;
        private DevExpress.XtraGrid.Columns.GridColumn Comision;
        private DevExpress.XtraGrid.Columns.GridColumn Retencion;
        private DevExpress.XtraGrid.Columns.GridColumn DctoAnticipo;
        private DevExpress.XtraGrid.Columns.GridColumn PagoNeto;
    }
}