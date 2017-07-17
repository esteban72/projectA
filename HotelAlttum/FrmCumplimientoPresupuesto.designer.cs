namespace CarteraGeneral
{
    partial class FrmCumplimientoPresupuesto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCumplimientoPresupuesto));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.CmbMes = new DevExpress.XtraBars.BarEditItem();
            this.RpsMes = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.BtnConsultaa = new DevExpress.XtraBars.BarButtonItem();
            this.CmbAño = new DevExpress.XtraBars.BarEditItem();
            this.RpsAno = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.BtnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.RpsAño = new DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit();
            this.repositoryItemComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdAdjudicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ValorPres = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RecaudoGestionado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RecaudoNoEsperado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TotalRecaudo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cumpl = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsMes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsAno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.CmbMes,
            this.BtnConsultaa,
            this.CmbAño,
            this.BtnImprimir});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 7;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RpsAño,
            this.RpsMes,
            this.repositoryItemComboBox2,
            this.RpsAno});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1298, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // CmbMes
            // 
            this.CmbMes.Caption = "Mes:";
            this.CmbMes.Edit = this.RpsMes;
            this.CmbMes.Id = 2;
            this.CmbMes.Name = "CmbMes";
            this.CmbMes.Width = 120;
            // 
            // RpsMes
            // 
            this.RpsMes.AutoHeight = false;
            this.RpsMes.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RpsMes.Name = "RpsMes";
            this.RpsMes.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // BtnConsultaa
            // 
            this.BtnConsultaa.Caption = "Consultar";
            this.BtnConsultaa.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnConsultaa.Glyph")));
            this.BtnConsultaa.Id = 4;
            this.BtnConsultaa.Name = "BtnConsultaa";
            this.BtnConsultaa.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnConsultaa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnConsultaa_ItemClick);
            // 
            // CmbAño
            // 
            this.CmbAño.Caption = "Año:";
            this.CmbAño.Edit = this.RpsAno;
            this.CmbAño.Id = 5;
            this.CmbAño.Name = "CmbAño";
            this.CmbAño.Width = 120;
            // 
            // RpsAno
            // 
            this.RpsAno.AutoHeight = false;
            this.RpsAno.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RpsAno.Name = "RpsAno";
            this.RpsAno.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Caption = "Imprimir";
            this.BtnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Glyph")));
            this.BtnImprimir.Id = 6;
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnImprimir_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Cumplimiento Presupuesto";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.CmbMes);
            this.ribbonPageGroup1.ItemLinks.Add(this.CmbAño);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnConsultaa);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnImprimir);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "PRESUPUESTO";
            // 
            // RpsAño
            // 
            this.RpsAño.AutoHeight = false;
            this.RpsAño.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RpsAño.Name = "RpsAño";
            // 
            // repositoryItemComboBox2
            // 
            this.repositoryItemComboBox2.AutoHeight = false;
            this.repositoryItemComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox2.Name = "repositoryItemComboBox2";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 493);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1298, 31);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 143);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1298, 350);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdAdjudicacion,
            this.Cliente,
            this.ValorPres,
            this.RecaudoGestionado,
            this.RecaudoNoEsperado,
            this.TotalRecaudo,
            this.Cumpl});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Presupuesto", this.ValorPres, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RecaudoGestionado", this.RecaudoGestionado, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RecaudoNoEsperado", this.RecaudoNoEsperado, "{0:c2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Average, "Cumpl", this.Cumpl, "(Indice%: PRO={0:0.##})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // IdAdjudicacion
            // 
            this.IdAdjudicacion.Caption = "IdAdjudicacion";
            this.IdAdjudicacion.FieldName = "IdAdjudicacion";
            this.IdAdjudicacion.Name = "IdAdjudicacion";
            this.IdAdjudicacion.OptionsColumn.ReadOnly = true;
            this.IdAdjudicacion.Visible = true;
            this.IdAdjudicacion.VisibleIndex = 0;
            // 
            // Cliente
            // 
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.OptionsColumn.ReadOnly = true;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 1;
            // 
            // ValorPres
            // 
            this.ValorPres.Caption = "Presupuesto";
            this.ValorPres.DisplayFormat.FormatString = "{0:c2}";
            this.ValorPres.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.ValorPres.FieldName = "Presupuesto";
            this.ValorPres.Name = "ValorPres";
            this.ValorPres.OptionsColumn.ReadOnly = true;
            this.ValorPres.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Presupuesto", "SUMA={0:c2}")});
            this.ValorPres.Visible = true;
            this.ValorPres.VisibleIndex = 2;
            // 
            // RecaudoGestionado
            // 
            this.RecaudoGestionado.Caption = "RecaudoGestionado";
            this.RecaudoGestionado.DisplayFormat.FormatString = "{0:c2}";
            this.RecaudoGestionado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RecaudoGestionado.FieldName = "RecaudoGestionado";
            this.RecaudoGestionado.Name = "RecaudoGestionado";
            this.RecaudoGestionado.OptionsColumn.ReadOnly = true;
            this.RecaudoGestionado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RecaudoGestionado", "{0:c2}")});
            this.RecaudoGestionado.Visible = true;
            this.RecaudoGestionado.VisibleIndex = 3;
            // 
            // RecaudoNoEsperado
            // 
            this.RecaudoNoEsperado.Caption = "RecaudoNoEsperado";
            this.RecaudoNoEsperado.DisplayFormat.FormatString = "{0:c2}";
            this.RecaudoNoEsperado.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.RecaudoNoEsperado.FieldName = "RecaudoNoEsperado";
            this.RecaudoNoEsperado.Name = "RecaudoNoEsperado";
            this.RecaudoNoEsperado.OptionsColumn.ReadOnly = true;
            this.RecaudoNoEsperado.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RecaudoNoEsperado", "{0:c2}")});
            this.RecaudoNoEsperado.Visible = true;
            this.RecaudoNoEsperado.VisibleIndex = 5;
            // 
            // TotalRecaudo
            // 
            this.TotalRecaudo.Caption = "TotalRecaudo";
            this.TotalRecaudo.DisplayFormat.FormatString = "{0:c2}";
            this.TotalRecaudo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.TotalRecaudo.FieldName = "TotalRecaudo";
            this.TotalRecaudo.Name = "TotalRecaudo";
            this.TotalRecaudo.OptionsColumn.ReadOnly = true;
            this.TotalRecaudo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalRecaudo", "SUMA={0:c2}")});
            this.TotalRecaudo.Visible = true;
            this.TotalRecaudo.VisibleIndex = 6;
            // 
            // Cumpl
            // 
            this.Cumpl.Caption = "Indice%";
            this.Cumpl.DisplayFormat.FormatString = "{0:n2}";
            this.Cumpl.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Cumpl.FieldName = "Cumpl";
            this.Cumpl.Name = "Cumpl";
            this.Cumpl.OptionsColumn.ReadOnly = true;
            this.Cumpl.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, "Cumpl", "PRO={0:0.##}")});
            this.Cumpl.Visible = true;
            this.Cumpl.VisibleIndex = 4;
            // 
            // FrmCumplimientoPresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1298, 524);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmCumplimientoPresupuesto";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmCumplimientoPresupuesto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCumplimientoPresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsMes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsAno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IdAdjudicacion;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn ValorPres;
        private DevExpress.XtraGrid.Columns.GridColumn RecaudoGestionado;
        private DevExpress.XtraGrid.Columns.GridColumn RecaudoNoEsperado;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit RpsAño;
        private DevExpress.XtraGrid.Columns.GridColumn TotalRecaudo;
        private DevExpress.XtraBars.BarEditItem CmbMes;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RpsMes;
        private DevExpress.XtraBars.BarButtonItem BtnConsultaa;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        private DevExpress.XtraBars.BarEditItem CmbAño;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox RpsAno;
        private DevExpress.XtraGrid.Columns.GridColumn Cumpl;
        private DevExpress.XtraBars.BarButtonItem BtnImprimir;
    }
}