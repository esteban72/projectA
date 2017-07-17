namespace CarteraGeneral
{
    partial class FrmModuloEnviosMonterey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuloEnviosMonterey));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMod = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.BtnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GrdEnvios = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdLote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdAdjudicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Contrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ValorContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReferenciaMonterey = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FinanciacionMfs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CuotaMfs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Clasificacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdEnvios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.BtnAdd,
            this.BtnMod,
            this.BtnDel,
            this.BtnImprimir,
            this.skinRibbonGalleryBarItem1,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1308, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Caption = "Adicionar";
            this.BtnAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Glyph")));
            this.BtnAdd.Id = 1;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAdd_ItemClick);
            // 
            // BtnMod
            // 
            this.BtnMod.Caption = "Modificar";
            this.BtnMod.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnMod.Glyph")));
            this.BtnMod.Id = 2;
            this.BtnMod.Name = "BtnMod";
            this.BtnMod.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnMod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnMod_ItemClick);
            // 
            // BtnDel
            // 
            this.BtnDel.Caption = "Salir";
            this.BtnDel.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnDel.Glyph")));
            this.BtnDel.Id = 3;
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDel_ItemClick);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Caption = "Imprimir";
            this.BtnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Glyph")));
            this.BtnImprimir.Id = 4;
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnImprimir_ItemClick);
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 7;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.GalleryPopupClose += new DevExpress.XtraBars.Ribbon.InplaceGalleryEventHandler(this.skinRibbonGalleryBarItem1_GalleryPopupClose);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Datos";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnMod);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnDel);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnImprimir);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Negociacion";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 575);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1308, 31);
            // 
            // GrdEnvios
            // 
            this.GrdEnvios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdEnvios.Location = new System.Drawing.Point(0, 143);
            this.GrdEnvios.MainView = this.gridView1;
            this.GrdEnvios.MenuManager = this.ribbon;
            this.GrdEnvios.Name = "GrdEnvios";
            this.GrdEnvios.Size = new System.Drawing.Size(1308, 432);
            this.GrdEnvios.TabIndex = 2;
            this.GrdEnvios.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdLote,
            this.Fecha,
            this.IdAdjudicacion,
            this.Cliente,
            this.Contrato,
            this.ValorContrato,
            this.Estado,
            this.ReferenciaMonterey,
            this.FinanciacionMfs,
            this.CuotaMfs,
            this.Clasificacion});
            this.gridView1.GridControl = this.GrdEnvios;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.IdLote, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // IdLote
            // 
            this.IdLote.Caption = "IdLote";
            this.IdLote.FieldName = "IdLote";
            this.IdLote.Name = "IdLote";
            this.IdLote.OptionsColumn.ReadOnly = true;
            this.IdLote.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "IdLote", "SUMA={0:#.##}")});
            this.IdLote.Visible = true;
            this.IdLote.VisibleIndex = 0;
            this.IdLote.Width = 65;
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.FieldName = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.OptionsColumn.ReadOnly = true;
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 0;
            this.Fecha.Width = 111;
            // 
            // IdAdjudicacion
            // 
            this.IdAdjudicacion.Caption = "IdAdjudicacion";
            this.IdAdjudicacion.FieldName = "IdAdjudicacion";
            this.IdAdjudicacion.Name = "IdAdjudicacion";
            this.IdAdjudicacion.OptionsColumn.ReadOnly = true;
            this.IdAdjudicacion.Visible = true;
            this.IdAdjudicacion.VisibleIndex = 1;
            this.IdAdjudicacion.Width = 84;
            // 
            // Cliente
            // 
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.OptionsColumn.ReadOnly = true;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 2;
            this.Cliente.Width = 312;
            // 
            // Contrato
            // 
            this.Contrato.Caption = "Contrato";
            this.Contrato.FieldName = "Contrato";
            this.Contrato.Name = "Contrato";
            this.Contrato.OptionsColumn.ReadOnly = true;
            this.Contrato.Visible = true;
            this.Contrato.VisibleIndex = 3;
            this.Contrato.Width = 101;
            // 
            // ValorContrato
            // 
            this.ValorContrato.Caption = "ValorContrato";
            this.ValorContrato.DisplayFormat.FormatString = "N2";
            this.ValorContrato.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ValorContrato.FieldName = "ValorContrato";
            this.ValorContrato.GroupFormat.FormatString = "N2";
            this.ValorContrato.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ValorContrato.Name = "ValorContrato";
            this.ValorContrato.OptionsColumn.ReadOnly = true;
            this.ValorContrato.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValorContrato", "SUMA={0:N2}")});
            this.ValorContrato.Visible = true;
            this.ValorContrato.VisibleIndex = 4;
            this.ValorContrato.Width = 124;
            // 
            // Estado
            // 
            this.Estado.Caption = "Estado";
            this.Estado.FieldName = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.OptionsColumn.ReadOnly = true;
            this.Estado.Visible = true;
            this.Estado.VisibleIndex = 7;
            this.Estado.Width = 124;
            // 
            // ReferenciaMonterey
            // 
            this.ReferenciaMonterey.Caption = "ReferenciaMonterey";
            this.ReferenciaMonterey.FieldName = "ReferenciaMonterey";
            this.ReferenciaMonterey.Name = "ReferenciaMonterey";
            this.ReferenciaMonterey.OptionsColumn.ReadOnly = true;
            this.ReferenciaMonterey.Visible = true;
            this.ReferenciaMonterey.VisibleIndex = 8;
            this.ReferenciaMonterey.Width = 145;
            // 
            // FinanciacionMfs
            // 
            this.FinanciacionMfs.Caption = "FinanciacionMfs";
            this.FinanciacionMfs.FieldName = "FinanciacionMfs";
            this.FinanciacionMfs.Name = "FinanciacionMfs";
            this.FinanciacionMfs.Visible = true;
            this.FinanciacionMfs.VisibleIndex = 5;
            this.FinanciacionMfs.Width = 90;
            // 
            // CuotaMfs
            // 
            this.CuotaMfs.Caption = "Cuota";
            this.CuotaMfs.FieldName = "CuotaMfs";
            this.CuotaMfs.Name = "CuotaMfs";
            this.CuotaMfs.Visible = true;
            this.CuotaMfs.VisibleIndex = 6;
            this.CuotaMfs.Width = 76;
            // 
            // Clasificacion
            // 
            this.Clasificacion.Caption = "Clasificacion";
            this.Clasificacion.FieldName = "Clasificacion";
            this.Clasificacion.Name = "Clasificacion";
            this.Clasificacion.Visible = true;
            this.Clasificacion.VisibleIndex = 9;
            this.Clasificacion.Width = 106;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // FrmModuloEnviosMonterey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 606);
            this.Controls.Add(this.GrdEnvios);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmModuloEnviosMonterey";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmModuloEnviosMonterey";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmModuloEnviosMonterey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdEnvios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl GrdEnvios;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IdLote;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn IdAdjudicacion;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn Contrato;
        private DevExpress.XtraGrid.Columns.GridColumn ValorContrato;
        private DevExpress.XtraGrid.Columns.GridColumn Estado;
        private DevExpress.XtraGrid.Columns.GridColumn ReferenciaMonterey;
        private DevExpress.XtraBars.BarButtonItem BtnAdd;
        private DevExpress.XtraBars.BarButtonItem BtnMod;
        private DevExpress.XtraBars.BarButtonItem BtnDel;
        private DevExpress.XtraBars.BarButtonItem BtnImprimir;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraGrid.Columns.GridColumn FinanciacionMfs;
        private DevExpress.XtraGrid.Columns.GridColumn CuotaMfs;
        private DevExpress.XtraGrid.Columns.GridColumn Clasificacion;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}