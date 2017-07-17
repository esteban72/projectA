namespace CarteraGeneral
{
    partial class FrmModuloRecaudosRbf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuloRecaudosRbf));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMod = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.BtnExtracto = new DevExpress.XtraBars.BarButtonItem();
            this.BtnREcaudosDetallados = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRsmCredito = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRecaudosFecha = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAddOtrosi = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAnular = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GrdCartera = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdAdjudicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdTercero1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Contrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdInmueble = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoAdjudica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Temporada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Grado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Valor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoOperacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCartera)).BeginInit();
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
            this.BtnExtracto,
            this.BtnREcaudosDetallados,
            this.BtnRsmCredito,
            this.BtnRecaudosFecha,
            this.BtnAddOtrosi,
            this.BtnAnular});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 12;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1360, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
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
            this.BtnDel.Caption = "Eliminar";
            this.BtnDel.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnDel.Glyph")));
            this.BtnDel.Id = 3;
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDel_ItemClick);
            // 
            // BtnExtracto
            // 
            this.BtnExtracto.Caption = "Extracto";
            this.BtnExtracto.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnExtracto.Glyph")));
            this.BtnExtracto.Id = 6;
            this.BtnExtracto.Name = "BtnExtracto";
            this.BtnExtracto.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnExtracto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnExtracto_ItemClick);
            // 
            // BtnREcaudosDetallados
            // 
            this.BtnREcaudosDetallados.Caption = "Recaudos Detalaldos";
            this.BtnREcaudosDetallados.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnREcaudosDetallados.Glyph")));
            this.BtnREcaudosDetallados.Id = 7;
            this.BtnREcaudosDetallados.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnREcaudosDetallados.LargeGlyph")));
            this.BtnREcaudosDetallados.Name = "BtnREcaudosDetallados";
            this.BtnREcaudosDetallados.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnREcaudosDetallados.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // BtnRsmCredito
            // 
            this.BtnRsmCredito.Caption = "Resumen Credito";
            this.BtnRsmCredito.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnRsmCredito.Glyph")));
            this.BtnRsmCredito.Id = 8;
            this.BtnRsmCredito.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnRsmCredito.LargeGlyph")));
            this.BtnRsmCredito.Name = "BtnRsmCredito";
            this.BtnRsmCredito.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnRsmCredito.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRsmCredito_ItemClick);
            // 
            // BtnRecaudosFecha
            // 
            this.BtnRecaudosFecha.Caption = "Recaudos por Fechas";
            this.BtnRecaudosFecha.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnRecaudosFecha.Glyph")));
            this.BtnRecaudosFecha.Id = 9;
            this.BtnRecaudosFecha.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnRecaudosFecha.LargeGlyph")));
            this.BtnRecaudosFecha.Name = "BtnRecaudosFecha";
            this.BtnRecaudosFecha.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnRecaudosFecha.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRecaudosFecha_ItemClick);
            // 
            // BtnAddOtrosi
            // 
            this.BtnAddOtrosi.Caption = "Adicionar Otrosi";
            this.BtnAddOtrosi.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAddOtrosi.Glyph")));
            this.BtnAddOtrosi.Id = 10;
            this.BtnAddOtrosi.Name = "BtnAddOtrosi";
            this.BtnAddOtrosi.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnAddOtrosi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAddOtrosi_ItemClick);
            // 
            // BtnAnular
            // 
            this.BtnAnular.Caption = "Anular Recibo";
            this.BtnAnular.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAnular.Glyph")));
            this.BtnAnular.Id = 11;
            this.BtnAnular.Name = "BtnAnular";
            this.BtnAnular.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnAnular.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAnular_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Modulo Cartera";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnMod);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnDel);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAnular);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAddOtrosi);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnExtracto);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Operaciones";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnREcaudosDetallados);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnRsmCredito);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnRecaudosFecha);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Consultas";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 523);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1360, 31);
            // 
            // GrdCartera
            // 
            this.GrdCartera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdCartera.Location = new System.Drawing.Point(0, 143);
            this.GrdCartera.MainView = this.gridView1;
            this.GrdCartera.MenuManager = this.ribbon;
            this.GrdCartera.Name = "GrdCartera";
            this.GrdCartera.Size = new System.Drawing.Size(1360, 380);
            this.GrdCartera.TabIndex = 3;
            this.GrdCartera.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdAdjudicacion,
            this.IdTercero1,
            this.Cliente,
            this.Fecha,
            this.Contrato,
            this.IdInmueble,
            this.TipoAdjudica,
            this.Temporada,
            this.Grado,
            this.Valor,
            this.TipoOperacion,
            this.Estado,
            this.Cliente2});
            this.gridView1.GridControl = this.GrdCartera;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Valor", this.Valor, "(Valor: SUMA={0:N2})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing_1);
            // 
            // IdAdjudicacion
            // 
            this.IdAdjudicacion.Caption = "Adj";
            this.IdAdjudicacion.FieldName = "IdAdjudicacion";
            this.IdAdjudicacion.Name = "IdAdjudicacion";
            this.IdAdjudicacion.OptionsColumn.ReadOnly = true;
            this.IdAdjudicacion.Visible = true;
            this.IdAdjudicacion.VisibleIndex = 0;
            this.IdAdjudicacion.Width = 90;
            // 
            // IdTercero1
            // 
            this.IdTercero1.Caption = "Documento";
            this.IdTercero1.FieldName = "IdTercero1";
            this.IdTercero1.Name = "IdTercero1";
            this.IdTercero1.OptionsColumn.ReadOnly = true;
            this.IdTercero1.Visible = true;
            this.IdTercero1.VisibleIndex = 1;
            this.IdTercero1.Width = 105;
            // 
            // Cliente
            // 
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.OptionsColumn.ReadOnly = true;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 2;
            this.Cliente.Width = 231;
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.FieldName = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.OptionsColumn.ReadOnly = true;
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 4;
            this.Fecha.Width = 81;
            // 
            // Contrato
            // 
            this.Contrato.Caption = "Contrato";
            this.Contrato.FieldName = "Contrato";
            this.Contrato.Name = "Contrato";
            this.Contrato.OptionsColumn.ReadOnly = true;
            this.Contrato.Visible = true;
            this.Contrato.VisibleIndex = 5;
            this.Contrato.Width = 81;
            // 
            // IdInmueble
            // 
            this.IdInmueble.Caption = "Inmueble";
            this.IdInmueble.FieldName = "IdInmueble";
            this.IdInmueble.Name = "IdInmueble";
            this.IdInmueble.OptionsColumn.ReadOnly = true;
            this.IdInmueble.Visible = true;
            this.IdInmueble.VisibleIndex = 6;
            this.IdInmueble.Width = 81;
            // 
            // TipoAdjudica
            // 
            this.TipoAdjudica.Caption = "Categoria";
            this.TipoAdjudica.FieldName = "TipodeAdjudicacion";
            this.TipoAdjudica.Name = "TipoAdjudica";
            this.TipoAdjudica.OptionsColumn.ReadOnly = true;
            this.TipoAdjudica.Visible = true;
            this.TipoAdjudica.VisibleIndex = 7;
            this.TipoAdjudica.Width = 98;
            // 
            // Temporada
            // 
            this.Temporada.Caption = "Temporada";
            this.Temporada.FieldName = "Temporada";
            this.Temporada.Name = "Temporada";
            this.Temporada.OptionsColumn.ReadOnly = true;
            this.Temporada.Visible = true;
            this.Temporada.VisibleIndex = 8;
            this.Temporada.Width = 94;
            // 
            // Grado
            // 
            this.Grado.Caption = "Grado";
            this.Grado.FieldName = "Grado";
            this.Grado.Name = "Grado";
            this.Grado.OptionsColumn.ReadOnly = true;
            this.Grado.Visible = true;
            this.Grado.VisibleIndex = 9;
            this.Grado.Width = 72;
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
            this.Valor.VisibleIndex = 10;
            this.Valor.Width = 122;
            // 
            // TipoOperacion
            // 
            this.TipoOperacion.Caption = "TipoOperacion ";
            this.TipoOperacion.FieldName = "TipoOperacion";
            this.TipoOperacion.Name = "TipoOperacion";
            this.TipoOperacion.Visible = true;
            this.TipoOperacion.VisibleIndex = 11;
            this.TipoOperacion.Width = 72;
            // 
            // Estado
            // 
            this.Estado.Caption = "Estado";
            this.Estado.FieldName = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.OptionsColumn.ReadOnly = true;
            this.Estado.Visible = true;
            this.Estado.VisibleIndex = 12;
            this.Estado.Width = 72;
            // 
            // Cliente2
            // 
            this.Cliente2.Caption = "Titular 2";
            this.Cliente2.FieldName = "Cliente2";
            this.Cliente2.Name = "Cliente2";
            this.Cliente2.Visible = true;
            this.Cliente2.VisibleIndex = 3;
            this.Cliente2.Width = 151;
            // 
            // FrmModuloRecaudosRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 554);
            this.Controls.Add(this.GrdCartera);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmModuloRecaudosRbf";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmModuloRecaudosRbf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmModuloRecaudosRbf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdCartera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem BtnAdd;
        private DevExpress.XtraBars.BarButtonItem BtnMod;
        private DevExpress.XtraBars.BarButtonItem BtnDel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem BtnExtracto;
        private DevExpress.XtraBars.BarButtonItem BtnREcaudosDetallados;
        private DevExpress.XtraBars.BarButtonItem BtnRsmCredito;
        private DevExpress.XtraBars.BarButtonItem BtnRecaudosFecha;
        private DevExpress.XtraBars.BarButtonItem BtnAddOtrosi;
        private DevExpress.XtraBars.BarButtonItem BtnAnular;
        private DevExpress.XtraGrid.GridControl GrdCartera;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IdAdjudicacion;
        private DevExpress.XtraGrid.Columns.GridColumn IdTercero1;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn Contrato;
        private DevExpress.XtraGrid.Columns.GridColumn IdInmueble;
        private DevExpress.XtraGrid.Columns.GridColumn TipoAdjudica;
        private DevExpress.XtraGrid.Columns.GridColumn Temporada;
        private DevExpress.XtraGrid.Columns.GridColumn Grado;
        private DevExpress.XtraGrid.Columns.GridColumn Valor;
        private DevExpress.XtraGrid.Columns.GridColumn TipoOperacion;
        private DevExpress.XtraGrid.Columns.GridColumn Estado;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente2;
    }
}