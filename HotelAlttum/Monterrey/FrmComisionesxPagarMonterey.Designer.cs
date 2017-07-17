namespace CarteraGeneral
{
    partial class FrmComisionesxPagarMonterey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmComisionesxPagarMonterey));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GrdComisiones = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdAdjudicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Gestor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Comision1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Comision2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Comision3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lqd1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lqd2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lqd3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PagoComision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalComision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Retencion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Anticipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DctoFondo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PagoNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdComisiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.BtnExportar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1274, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Caption = "barButtonItem1";
            this.BtnExportar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnExportar.Glyph")));
            this.BtnExportar.Id = 1;
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnExportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnExportar_ItemClick);
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
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnExportar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 476);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1274, 31);
            // 
            // GrdComisiones
            // 
            this.GrdComisiones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdComisiones.Location = new System.Drawing.Point(0, 143);
            this.GrdComisiones.MainView = this.gridView1;
            this.GrdComisiones.MenuManager = this.ribbon;
            this.GrdComisiones.Name = "GrdComisiones";
            this.GrdComisiones.Size = new System.Drawing.Size(1274, 333);
            this.GrdComisiones.TabIndex = 2;
            this.GrdComisiones.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdAdjudicacion,
            this.Cliente,
            this.Gestor,
            this.Cargo,
            this.Comision1,
            this.Comision2,
            this.Comision3,
            this.Lqd1,
            this.Lqd2,
            this.Lqd3,
            this.PagoComision,
            this.TotalComision,
            this.Retencion,
            this.Anticipo,
            this.DctoFondo,
            this.PagoNeto});
            this.gridView1.GridControl = this.GrdComisiones;
            this.gridView1.GroupCount = 2;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Lqd1", this.Lqd1, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Lqd2", this.Lqd2, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Lqd3", this.Lqd3, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PagoComision", this.PagoComision, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalComision", this.TotalComision, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Retencion", this.Retencion, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anticipo", this.Anticipo, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PagoNeto", this.PagoNeto, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "DctoFondo", this.DctoFondo, "{0:c2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.IdAdjudicacion, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.Cliente, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // IdAdjudicacion
            // 
            this.IdAdjudicacion.FieldName = "IdAdjudicacion";
            this.IdAdjudicacion.Name = "IdAdjudicacion";
            this.IdAdjudicacion.Visible = true;
            this.IdAdjudicacion.VisibleIndex = 0;
            this.IdAdjudicacion.Width = 83;
            // 
            // Cliente
            // 
            this.Cliente.FieldName = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 0;
            this.Cliente.Width = 162;
            // 
            // Gestor
            // 
            this.Gestor.FieldName = "Gestor";
            this.Gestor.Name = "Gestor";
            this.Gestor.Visible = true;
            this.Gestor.VisibleIndex = 0;
            this.Gestor.Width = 172;
            // 
            // Cargo
            // 
            this.Cargo.FieldName = "Cargo";
            this.Cargo.Name = "Cargo";
            this.Cargo.Visible = true;
            this.Cargo.VisibleIndex = 1;
            this.Cargo.Width = 152;
            // 
            // Comision1
            // 
            this.Comision1.Caption = "Com1";
            this.Comision1.FieldName = "Comision1";
            this.Comision1.Name = "Comision1";
            this.Comision1.Visible = true;
            this.Comision1.VisibleIndex = 2;
            this.Comision1.Width = 38;
            // 
            // Comision2
            // 
            this.Comision2.Caption = "Com2";
            this.Comision2.FieldName = "Comision2";
            this.Comision2.Name = "Comision2";
            this.Comision2.Visible = true;
            this.Comision2.VisibleIndex = 3;
            this.Comision2.Width = 38;
            // 
            // Comision3
            // 
            this.Comision3.Caption = "Comn3";
            this.Comision3.FieldName = "Comision3";
            this.Comision3.Name = "Comision3";
            this.Comision3.Visible = true;
            this.Comision3.VisibleIndex = 4;
            this.Comision3.Width = 44;
            // 
            // Lqd1
            // 
            this.Lqd1.FieldName = "Lqd1";
            this.Lqd1.Name = "Lqd1";
            this.Lqd1.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Lqd1", "{0:c2}")});
            this.Lqd1.Visible = true;
            this.Lqd1.VisibleIndex = 5;
            this.Lqd1.Width = 83;
            // 
            // Lqd2
            // 
            this.Lqd2.FieldName = "Lqd2";
            this.Lqd2.Name = "Lqd2";
            this.Lqd2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Lqd2", "{0:c2}")});
            this.Lqd2.Visible = true;
            this.Lqd2.VisibleIndex = 6;
            this.Lqd2.Width = 83;
            // 
            // Lqd3
            // 
            this.Lqd3.FieldName = "Lqd3";
            this.Lqd3.Name = "Lqd3";
            this.Lqd3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Lqd3", "{0:c2}")});
            this.Lqd3.Visible = true;
            this.Lqd3.VisibleIndex = 7;
            this.Lqd3.Width = 83;
            // 
            // PagoComision
            // 
            this.PagoComision.FieldName = "PagoComision";
            this.PagoComision.Name = "PagoComision";
            this.PagoComision.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PagoComision", "{0:c2}")});
            this.PagoComision.Visible = true;
            this.PagoComision.VisibleIndex = 8;
            this.PagoComision.Width = 83;
            // 
            // TotalComision
            // 
            this.TotalComision.FieldName = "TotalComision";
            this.TotalComision.Name = "TotalComision";
            this.TotalComision.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalComision", "{0:c2}")});
            this.TotalComision.Visible = true;
            this.TotalComision.VisibleIndex = 9;
            this.TotalComision.Width = 83;
            // 
            // Retencion
            // 
            this.Retencion.FieldName = "Retencion";
            this.Retencion.Name = "Retencion";
            this.Retencion.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Retencion", "{0:c2}")});
            this.Retencion.Visible = true;
            this.Retencion.VisibleIndex = 10;
            this.Retencion.Width = 83;
            // 
            // Anticipo
            // 
            this.Anticipo.FieldName = "Anticipo";
            this.Anticipo.Name = "Anticipo";
            this.Anticipo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Anticipo", "{0:c2}")});
            this.Anticipo.Visible = true;
            this.Anticipo.VisibleIndex = 11;
            this.Anticipo.Width = 83;
            // 
            // DctoFondo
            // 
            this.DctoFondo.Caption = "DctoFondo";
            this.DctoFondo.FieldName = "DctoFondo";
            this.DctoFondo.Name = "DctoFondo";
            this.DctoFondo.Visible = true;
            this.DctoFondo.VisibleIndex = 12;
            this.DctoFondo.Width = 103;
            // 
            // PagoNeto
            // 
            this.PagoNeto.FieldName = "PagoNeto";
            this.PagoNeto.Name = "PagoNeto";
            this.PagoNeto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "PagoNeto", "{0:c2}")});
            this.PagoNeto.Visible = true;
            this.PagoNeto.VisibleIndex = 13;
            this.PagoNeto.Width = 128;
            // 
            // FrmComisionesxPagarMonterey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 507);
            this.Controls.Add(this.GrdComisiones);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmComisionesxPagarMonterey";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmComisionesxPagarMonterey";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmComisionesxPagarMonterey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
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
        private DevExpress.XtraGrid.GridControl GrdComisiones;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IdAdjudicacion;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn Gestor;
        private DevExpress.XtraGrid.Columns.GridColumn Cargo;
        private DevExpress.XtraGrid.Columns.GridColumn Comision1;
        private DevExpress.XtraGrid.Columns.GridColumn Comision2;
        private DevExpress.XtraGrid.Columns.GridColumn Comision3;
        private DevExpress.XtraGrid.Columns.GridColumn Lqd1;
        private DevExpress.XtraGrid.Columns.GridColumn Lqd2;
        private DevExpress.XtraGrid.Columns.GridColumn Lqd3;
        private DevExpress.XtraGrid.Columns.GridColumn PagoComision;
        private DevExpress.XtraGrid.Columns.GridColumn TotalComision;
        private DevExpress.XtraGrid.Columns.GridColumn Retencion;
        private DevExpress.XtraGrid.Columns.GridColumn Anticipo;
        private DevExpress.XtraGrid.Columns.GridColumn PagoNeto;
        private DevExpress.XtraGrid.Columns.GridColumn DctoFondo;
        private DevExpress.XtraBars.BarButtonItem BtnExportar;
    }
}