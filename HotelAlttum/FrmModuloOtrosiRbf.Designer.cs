namespace CarteraGeneral
{
    partial class FrmModuloOtrosiRbf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuloOtrosiRbf));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnModOtrosi = new DevExpress.XtraBars.BarButtonItem();
            this.BtnSalir = new DevExpress.XtraBars.BarButtonItem();
            this.BtnImprimir = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAprobarOtrosi = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDelOtrosi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GrdOtrosi = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdAdjudicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdOtrosi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Contrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdInmueble = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoAdjudica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Temporada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Grado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Valor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoOperacion = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdOtrosi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 498);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1303, 27);
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.BtnModOtrosi,
            this.BtnSalir,
            this.BtnImprimir,
            this.BtnAprobarOtrosi,
            this.BtnDelOtrosi});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 11;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1303, 141);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // BtnModOtrosi
            // 
            this.BtnModOtrosi.Caption = "Modificar";
            this.BtnModOtrosi.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnModOtrosi.Glyph")));
            this.BtnModOtrosi.Id = 1;
            this.BtnModOtrosi.Name = "BtnModOtrosi";
            this.BtnModOtrosi.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnModOtrosi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnModOtrosi_ItemClick);
            // 
            // BtnSalir
            // 
            this.BtnSalir.Caption = "Salir";
            this.BtnSalir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnSalir.Glyph")));
            this.BtnSalir.Id = 6;
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnSalir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnSalir_ItemClick);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.Caption = "Imprimir";
            this.BtnImprimir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnImprimir.Glyph")));
            this.BtnImprimir.Id = 8;
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnImprimir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnImprimir_ItemClick);
            // 
            // BtnAprobarOtrosi
            // 
            this.BtnAprobarOtrosi.Caption = "Aprobar";
            this.BtnAprobarOtrosi.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAprobarOtrosi.Glyph")));
            this.BtnAprobarOtrosi.Id = 9;
            this.BtnAprobarOtrosi.Name = "BtnAprobarOtrosi";
            this.BtnAprobarOtrosi.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnAprobarOtrosi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAprobarOtrosi_ItemClick);
            // 
            // BtnDelOtrosi
            // 
            this.BtnDelOtrosi.Caption = "Eliminar";
            this.BtnDelOtrosi.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnDelOtrosi.Glyph")));
            this.BtnDelOtrosi.Id = 10;
            this.BtnDelOtrosi.Name = "BtnDelOtrosi";
            this.BtnDelOtrosi.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnDelOtrosi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDelOtrosi_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Adjudicacion";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnModOtrosi);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnDelOtrosi);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAprobarOtrosi);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnImprimir);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnSalir);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "MODULO ADJUDICACION";
            // 
            // GrdOtrosi
            // 
            this.GrdOtrosi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdOtrosi.Location = new System.Drawing.Point(0, 141);
            this.GrdOtrosi.MainView = this.gridView1;
            this.GrdOtrosi.MenuManager = this.ribbon;
            this.GrdOtrosi.Name = "GrdOtrosi";
            this.GrdOtrosi.Size = new System.Drawing.Size(1303, 384);
            this.GrdOtrosi.TabIndex = 8;
            this.GrdOtrosi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdAdjudicacion,
            this.IdOtrosi,
            this.Cliente,
            this.Fecha,
            this.Contrato,
            this.IdInmueble,
            this.TipoAdjudica,
            this.Temporada,
            this.Grado,
            this.Valor,
            this.TipoOperacion});
            this.gridView1.GridControl = this.GrdOtrosi;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Valor", this.Valor, "(Valor: SUMA={0:N2})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // IdAdjudicacion
            // 
            this.IdAdjudicacion.Caption = "Adj";
            this.IdAdjudicacion.FieldName = "IdAdjudicacion";
            this.IdAdjudicacion.Name = "IdAdjudicacion";
            this.IdAdjudicacion.OptionsColumn.ReadOnly = true;
            this.IdAdjudicacion.Visible = true;
            this.IdAdjudicacion.VisibleIndex = 1;
            this.IdAdjudicacion.Width = 93;
            // 
            // IdOtrosi
            // 
            this.IdOtrosi.Caption = "IdOtrosi";
            this.IdOtrosi.FieldName = "IdOtrosi";
            this.IdOtrosi.Name = "IdOtrosi";
            this.IdOtrosi.OptionsColumn.ReadOnly = true;
            this.IdOtrosi.Visible = true;
            this.IdOtrosi.VisibleIndex = 0;
            this.IdOtrosi.Width = 109;
            // 
            // Cliente
            // 
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.OptionsColumn.ReadOnly = true;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 3;
            this.Cliente.Width = 273;
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha Otrosi";
            this.Fecha.FieldName = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.OptionsColumn.ReadOnly = true;
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 2;
            this.Fecha.Width = 90;
            // 
            // Contrato
            // 
            this.Contrato.Caption = "Contrato";
            this.Contrato.FieldName = "Contrato";
            this.Contrato.Name = "Contrato";
            this.Contrato.OptionsColumn.ReadOnly = true;
            this.Contrato.Visible = true;
            this.Contrato.VisibleIndex = 4;
            this.Contrato.Width = 90;
            // 
            // IdInmueble
            // 
            this.IdInmueble.Caption = "Inmueble";
            this.IdInmueble.FieldName = "IdInmueble";
            this.IdInmueble.Name = "IdInmueble";
            this.IdInmueble.OptionsColumn.ReadOnly = true;
            this.IdInmueble.Visible = true;
            this.IdInmueble.VisibleIndex = 5;
            this.IdInmueble.Width = 90;
            // 
            // TipoAdjudica
            // 
            this.TipoAdjudica.Caption = "TipoAdjudica";
            this.TipoAdjudica.FieldName = "TipodeAdjudicacion";
            this.TipoAdjudica.Name = "TipoAdjudica";
            this.TipoAdjudica.OptionsColumn.ReadOnly = true;
            this.TipoAdjudica.Visible = true;
            this.TipoAdjudica.VisibleIndex = 6;
            this.TipoAdjudica.Width = 109;
            // 
            // Temporada
            // 
            this.Temporada.Caption = "Temporada";
            this.Temporada.FieldName = "Temporada";
            this.Temporada.Name = "Temporada";
            this.Temporada.OptionsColumn.ReadOnly = true;
            this.Temporada.Visible = true;
            this.Temporada.VisibleIndex = 7;
            this.Temporada.Width = 105;
            // 
            // Grado
            // 
            this.Grado.Caption = "Grado";
            this.Grado.FieldName = "Grado";
            this.Grado.Name = "Grado";
            this.Grado.OptionsColumn.ReadOnly = true;
            this.Grado.Visible = true;
            this.Grado.VisibleIndex = 8;
            this.Grado.Width = 81;
            // 
            // Valor
            // 
            this.Valor.Caption = "Valor";
            this.Valor.DisplayFormat.FormatString = "N2";
            this.Valor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Valor.FieldName = "Valor";
            this.Valor.GroupFormat.FormatString = "N2";
            this.Valor.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Valor.Name = "Valor";
            this.Valor.OptionsColumn.ReadOnly = true;
            this.Valor.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Valor", "SUMA={0:N2}")});
            this.Valor.Visible = true;
            this.Valor.VisibleIndex = 9;
            this.Valor.Width = 135;
            // 
            // TipoOperacion
            // 
            this.TipoOperacion.Caption = "TipoOperacion ";
            this.TipoOperacion.FieldName = "TipoOperacion";
            this.TipoOperacion.Name = "TipoOperacion";
            this.TipoOperacion.Visible = true;
            this.TipoOperacion.VisibleIndex = 10;
            this.TipoOperacion.Width = 80;
            // 
            // FrmModuloOtrosiRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1303, 525);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.GrdOtrosi);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmModuloOtrosiRbf";
            this.Text = "FrmModuloOtrosiRbf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmModuloOtrosiRbf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdOtrosi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem BtnModOtrosi;
        private DevExpress.XtraBars.BarButtonItem BtnSalir;
        private DevExpress.XtraBars.BarButtonItem BtnImprimir;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl GrdOtrosi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IdAdjudicacion;
        private DevExpress.XtraGrid.Columns.GridColumn IdOtrosi;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn Contrato;
        private DevExpress.XtraGrid.Columns.GridColumn IdInmueble;
        private DevExpress.XtraGrid.Columns.GridColumn TipoAdjudica;
        private DevExpress.XtraGrid.Columns.GridColumn Temporada;
        private DevExpress.XtraGrid.Columns.GridColumn Grado;
        private DevExpress.XtraGrid.Columns.GridColumn Valor;
        private DevExpress.XtraGrid.Columns.GridColumn TipoOperacion;
        private DevExpress.XtraBars.BarButtonItem BtnAprobarOtrosi;
        private DevExpress.XtraBars.BarButtonItem BtnDelOtrosi;
    }
}