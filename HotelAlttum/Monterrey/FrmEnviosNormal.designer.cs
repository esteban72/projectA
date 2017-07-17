namespace CarteraGeneral
{
    partial class FrmEnviosNormal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnviosNormal));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.CmbLote = new DevExpress.XtraBars.BarEditItem();
            this.RpsLotes = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.DtpFecha = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.BtnGuardar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.BtnSalir = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GrdEnviosMonterey = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdAdjudicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RpsAdjduicacion = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemSearchLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdTercero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Contrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Valor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ValorMonedaLocal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Trm = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsLotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdEnviosMonterey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsAdjduicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2View)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.CmbLote,
            this.DtpFecha,
            this.BtnGuardar,
            this.BtnImprimir,
            this.BtnSalir});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RpsLotes,
            this.repositoryItemDateEdit1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1325, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // CmbLote
            // 
            this.CmbLote.Caption = "Lote:   ";
            this.CmbLote.Edit = this.RpsLotes;
            this.CmbLote.Id = 1;
            this.CmbLote.Name = "CmbLote";
            this.CmbLote.Width = 120;
            // 
            // RpsLotes
            // 
            this.RpsLotes.AutoHeight = false;
            this.RpsLotes.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RpsLotes.Name = "RpsLotes";
            this.RpsLotes.View = this.repositoryItemSearchLookUpEdit1View;
            // 
            // repositoryItemSearchLookUpEdit1View
            // 
            this.repositoryItemSearchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit1View.Name = "repositoryItemSearchLookUpEdit1View";
            this.repositoryItemSearchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Caption = "Fecha:";
            this.DtpFecha.Edit = this.repositoryItemDateEdit1;
            this.DtpFecha.Id = 2;
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
            // BtnGuardar
            // 
            this.BtnGuardar.Caption = "Guardar";
            this.BtnGuardar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnGuardar.Glyph")));
            this.BtnGuardar.Id = 6;
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnGuardar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnGuardar_ItemClick);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Caption = "Imprimir";
            this.BtnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Glyph")));
            this.BtnImprimir.Id = 7;
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Caption = "Salir";
            this.BtnSalir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnSalir.Glyph")));
            this.BtnSalir.Id = 8;
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.DtpFecha);
            this.ribbonPageGroup1.ItemLinks.Add(this.CmbLote);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnGuardar);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnImprimir);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnSalir);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 532);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1325, 31);
            // 
            // GrdEnviosMonterey
            // 
            this.GrdEnviosMonterey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdEnviosMonterey.Location = new System.Drawing.Point(0, 143);
            this.GrdEnviosMonterey.MainView = this.gridView1;
            this.GrdEnviosMonterey.MenuManager = this.ribbon;
            this.GrdEnviosMonterey.Name = "GrdEnviosMonterey";
            this.GrdEnviosMonterey.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RpsAdjduicacion});
            this.GrdEnviosMonterey.Size = new System.Drawing.Size(1325, 389);
            this.GrdEnviosMonterey.TabIndex = 3;
            this.GrdEnviosMonterey.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdAdjudicacion,
            this.IdTercero,
            this.Cliente,
            this.Contrato,
            this.Valor,
            this.ValorMonedaLocal,
            this.FechaContrato,
            this.Trm});
            this.gridView1.GridControl = this.GrdEnviosMonterey;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Lqd2", this.Valor, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Lqd3", this.ValorMonedaLocal, "{0:c2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridView1_KeyUp);
            // 
            // IdAdjudicacion
            // 
            this.IdAdjudicacion.Caption = "Adjudicaciion";
            this.IdAdjudicacion.ColumnEdit = this.RpsAdjduicacion;
            this.IdAdjudicacion.FieldName = "IdAdjudicacion";
            this.IdAdjudicacion.Name = "IdAdjudicacion";
            this.IdAdjudicacion.Visible = true;
            this.IdAdjudicacion.VisibleIndex = 0;
            this.IdAdjudicacion.Width = 110;
            // 
            // RpsAdjduicacion
            // 
            this.RpsAdjduicacion.AutoHeight = false;
            this.RpsAdjduicacion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RpsAdjduicacion.Name = "RpsAdjduicacion";
            this.RpsAdjduicacion.View = this.repositoryItemSearchLookUpEdit2View;
            // 
            // repositoryItemSearchLookUpEdit2View
            // 
            this.repositoryItemSearchLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemSearchLookUpEdit2View.Name = "repositoryItemSearchLookUpEdit2View";
            this.repositoryItemSearchLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemSearchLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // IdTercero
            // 
            this.IdTercero.Caption = "IdTercero";
            this.IdTercero.FieldName = "IdTercero1";
            this.IdTercero.Name = "IdTercero";
            this.IdTercero.Visible = true;
            this.IdTercero.VisibleIndex = 1;
            this.IdTercero.Width = 99;
            // 
            // Cliente
            // 
            this.Cliente.FieldName = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 2;
            this.Cliente.Width = 307;
            // 
            // Contrato
            // 
            this.Contrato.Caption = "Contrato";
            this.Contrato.FieldName = "Contrato";
            this.Contrato.Name = "Contrato";
            this.Contrato.Visible = true;
            this.Contrato.VisibleIndex = 4;
            this.Contrato.Width = 82;
            // 
            // Valor
            // 
            this.Valor.Caption = "Valor";
            this.Valor.DisplayFormat.FormatString = "{0:c2}";
            this.Valor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Valor.FieldName = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Valor", "{0:c2}")});
            this.Valor.Visible = true;
            this.Valor.VisibleIndex = 6;
            this.Valor.Width = 177;
            // 
            // ValorMonedaLocal
            // 
            this.ValorMonedaLocal.Caption = "ValorMonedaLocal";
            this.ValorMonedaLocal.DisplayFormat.FormatString = "{0:c2}";
            this.ValorMonedaLocal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ValorMonedaLocal.FieldName = "ValorMonedaLocal";
            this.ValorMonedaLocal.Name = "ValorMonedaLocal";
            this.ValorMonedaLocal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ValorMonedaLocal", "{0:c2}")});
            this.ValorMonedaLocal.Visible = true;
            this.ValorMonedaLocal.VisibleIndex = 7;
            this.ValorMonedaLocal.Width = 202;
            // 
            // FechaContrato
            // 
            this.FechaContrato.Caption = "FechaContrato";
            this.FechaContrato.FieldName = "FechaContrato";
            this.FechaContrato.Name = "FechaContrato";
            this.FechaContrato.Visible = true;
            this.FechaContrato.VisibleIndex = 3;
            this.FechaContrato.Width = 118;
            // 
            // Trm
            // 
            this.Trm.Caption = "Trm";
            this.Trm.FieldName = "Trm";
            this.Trm.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Trm.Name = "Trm";
            this.Trm.Visible = true;
            this.Trm.VisibleIndex = 5;
            this.Trm.Width = 99;
            // 
            // FrmEnviosNormal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 563);
            this.Controls.Add(this.GrdEnviosMonterey);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmEnviosNormal";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmEnviosNormal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmEnviosMonterey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsLotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdEnviosMonterey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsAdjduicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchLookUpEdit2View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl GrdEnviosMonterey;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IdAdjudicacion;
        private DevExpress.XtraGrid.Columns.GridColumn IdTercero;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn Contrato;
        private DevExpress.XtraGrid.Columns.GridColumn Valor;
        private DevExpress.XtraGrid.Columns.GridColumn ValorMonedaLocal;
        private DevExpress.XtraGrid.Columns.GridColumn FechaContrato;
        private DevExpress.XtraGrid.Columns.GridColumn Trm;
        private DevExpress.XtraBars.BarEditItem CmbLote;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RpsLotes;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit1View;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RpsAdjduicacion;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemSearchLookUpEdit2View;
        private DevExpress.XtraBars.BarEditItem DtpFecha;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraBars.BarButtonItem BtnGuardar;
        private DevExpress.XtraBars.BarButtonItem BtnImprimir;
        private DevExpress.XtraBars.BarButtonItem BtnSalir;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}