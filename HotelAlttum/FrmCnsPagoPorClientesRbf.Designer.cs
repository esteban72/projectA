namespace CarteraGeneral
{
    partial class FrmCnsPagoPorClientesRbf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCnsPagoPorClientesRbf));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.RpsAdjudicacion = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.BtnConsultar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GrdConsulta = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.TxtIdAdjudicacion = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.Nombres = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NombreCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lqd1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lqd2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Lqd3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PagoComision = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Retencion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PagoNeto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BtnImprimir = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsAdjudicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdConsulta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.BtnConsultar,
            this.TxtIdAdjudicacion,
            this.BtnImprimir});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.RpsAdjudicacion,
            this.repositoryItemTextEdit1});
            this.ribbon.Size = new System.Drawing.Size(1308, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // RpsAdjudicacion
            // 
            this.RpsAdjudicacion.AutoHeight = false;
            this.RpsAdjudicacion.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RpsAdjudicacion.Name = "RpsAdjudicacion";
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Caption = "Consultar";
            this.BtnConsultar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnConsultar.Glyph")));
            this.BtnConsultar.Id = 2;
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnConsultar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Consultas Pagos Comision";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.TxtIdAdjudicacion);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnConsultar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnImprimir);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Consultas";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 500);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1308, 31);
            // 
            // GrdConsulta
            // 
            this.GrdConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdConsulta.Location = new System.Drawing.Point(0, 143);
            this.GrdConsulta.MainView = this.gridView1;
            this.GrdConsulta.MenuManager = this.ribbon;
            this.GrdConsulta.Name = "GrdConsulta";
            this.GrdConsulta.Size = new System.Drawing.Size(1308, 357);
            this.GrdConsulta.TabIndex = 2;
            this.GrdConsulta.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Nombres,
            this.NombreCargo,
            this.Lqd1,
            this.Lqd2,
            this.Lqd3,
            this.PagoComision,
            this.Retencion,
            this.PagoNeto});
            this.gridView1.GridControl = this.GrdConsulta;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // TxtIdAdjudicacion
            // 
            this.TxtIdAdjudicacion.Caption = "Adjudicacion";
            this.TxtIdAdjudicacion.Edit = this.repositoryItemTextEdit1;
            this.TxtIdAdjudicacion.Id = 3;
            this.TxtIdAdjudicacion.Name = "TxtIdAdjudicacion";
            this.TxtIdAdjudicacion.Width = 100;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // Nombres
            // 
            this.Nombres.Caption = "Asesor";
            this.Nombres.FieldName = "Nombres";
            this.Nombres.Name = "Nombres";
            this.Nombres.Visible = true;
            this.Nombres.VisibleIndex = 1;
            this.Nombres.Width = 283;
            // 
            // NombreCargo
            // 
            this.NombreCargo.Caption = "Cargo";
            this.NombreCargo.FieldName = "NombreCargo";
            this.NombreCargo.Name = "NombreCargo";
            this.NombreCargo.Visible = true;
            this.NombreCargo.VisibleIndex = 2;
            this.NombreCargo.Width = 141;
            // 
            // Lqd1
            // 
            this.Lqd1.Caption = "Com33";
            this.Lqd1.FieldName = "Lqd1";
            this.Lqd1.Name = "Lqd1";
            this.Lqd1.Visible = true;
            this.Lqd1.VisibleIndex = 3;
            this.Lqd1.Width = 112;
            // 
            // Lqd2
            // 
            this.Lqd2.Caption = "Com66";
            this.Lqd2.FieldName = "Lqd2";
            this.Lqd2.Name = "Lqd2";
            this.Lqd2.Visible = true;
            this.Lqd2.VisibleIndex = 4;
            this.Lqd2.Width = 96;
            // 
            // Lqd3
            // 
            this.Lqd3.Caption = "Com100";
            this.Lqd3.FieldName = "Lqd3";
            this.Lqd3.Name = "Lqd3";
            this.Lqd3.Visible = true;
            this.Lqd3.VisibleIndex = 5;
            this.Lqd3.Width = 139;
            // 
            // PagoComision
            // 
            this.PagoComision.Caption = "CmsPagada";
            this.PagoComision.FieldName = "PagoComision";
            this.PagoComision.Name = "PagoComision";
            this.PagoComision.Visible = true;
            this.PagoComision.VisibleIndex = 6;
            this.PagoComision.Width = 128;
            // 
            // Retencion
            // 
            this.Retencion.Caption = "Retencion";
            this.Retencion.FieldName = "Retencion";
            this.Retencion.Name = "Retencion";
            this.Retencion.Visible = true;
            this.Retencion.VisibleIndex = 7;
            this.Retencion.Width = 128;
            // 
            // PagoNeto
            // 
            this.PagoNeto.Caption = "PagoNeto";
            this.PagoNeto.FieldName = "PagoNeto";
            this.PagoNeto.Name = "PagoNeto";
            this.PagoNeto.Visible = true;
            this.PagoNeto.VisibleIndex = 8;
            this.PagoNeto.Width = 154;
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Caption = "Imprimi";
            this.BtnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Glyph")));
            this.BtnImprimir.Id = 4;
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnImprimir_ItemClick);
            // 
            // FrmCnsPagoPorClientesRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 531);
            this.Controls.Add(this.GrdConsulta);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmCnsPagoPorClientesRbf";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmCnsPagoPorClientesRbf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmCnsPagoPorClientesRbf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RpsAdjudicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdConsulta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RpsAdjudicacion;
        private DevExpress.XtraBars.BarButtonItem BtnConsultar;
        private DevExpress.XtraGrid.GridControl GrdConsulta;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.BarEditItem TxtIdAdjudicacion;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn Nombres;
        private DevExpress.XtraGrid.Columns.GridColumn NombreCargo;
        private DevExpress.XtraGrid.Columns.GridColumn Lqd1;
        private DevExpress.XtraGrid.Columns.GridColumn Lqd2;
        private DevExpress.XtraGrid.Columns.GridColumn Lqd3;
        private DevExpress.XtraGrid.Columns.GridColumn PagoComision;
        private DevExpress.XtraGrid.Columns.GridColumn Retencion;
        private DevExpress.XtraGrid.Columns.GridColumn PagoNeto;
        private DevExpress.XtraBars.BarButtonItem BtnImprimir;
    }
}