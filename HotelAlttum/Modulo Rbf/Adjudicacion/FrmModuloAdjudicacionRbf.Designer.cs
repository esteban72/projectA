namespace CarteraGeneral
{
    partial class FrmModuloAdjudicacionRbf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuloAdjudicacionRbf));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMod = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.BtnCambiarBase = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDesistir = new DevExpress.XtraBars.BarButtonItem();
            this.BtnSalir = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAddMonterey = new DevExpress.XtraBars.BarButtonItem();
            this.BtnConsultar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRecaudoDetallado = new DevExpress.XtraBars.BarButtonItem();
            this.BtnRsmCredito = new DevExpress.XtraBars.BarButtonItem();
            this.BtnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.btnPIV = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdAdjudicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdTercero1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FechaContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Contrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdInmueble = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoAdjudica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Temporada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Grado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Valor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoOperacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
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
            this.BtnCambiarBase,
            this.BtnDesistir,
            this.BtnSalir,
            this.BtnAddMonterey,
            this.BtnConsultar,
            this.BtnRecaudoDetallado,
            this.BtnRsmCredito,
            this.BtnExportar,
            this.btnPIV});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 14;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1335, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Caption = "Adicion Normal";
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
            // BtnCambiarBase
            // 
            this.BtnCambiarBase.Caption = "Cambiar Base";
            this.BtnCambiarBase.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnCambiarBase.Glyph")));
            this.BtnCambiarBase.Id = 4;
            this.BtnCambiarBase.Name = "BtnCambiarBase";
            this.BtnCambiarBase.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnCambiarBase.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnCambiarBase_ItemClick);
            // 
            // BtnDesistir
            // 
            this.BtnDesistir.Caption = "Desistir";
            this.BtnDesistir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnDesistir.Glyph")));
            this.BtnDesistir.Id = 5;
            this.BtnDesistir.Name = "BtnDesistir";
            this.BtnDesistir.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnDesistir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDesistir_ItemClick);
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
            // BtnAddMonterey
            // 
            this.BtnAddMonterey.Caption = "Adicion Monterey";
            this.BtnAddMonterey.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAddMonterey.Glyph")));
            this.BtnAddMonterey.Id = 8;
            this.BtnAddMonterey.Name = "BtnAddMonterey";
            this.BtnAddMonterey.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnAddMonterey.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAddMonterey_ItemClick_1);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Caption = "Consultar";
            this.BtnConsultar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnConsultar.Glyph")));
            this.BtnConsultar.Id = 9;
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnConsultar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // BtnRecaudoDetallado
            // 
            this.BtnRecaudoDetallado.Caption = "Recaudo Detallado";
            this.BtnRecaudoDetallado.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnRecaudoDetallado.Glyph")));
            this.BtnRecaudoDetallado.Id = 10;
            this.BtnRecaudoDetallado.Name = "BtnRecaudoDetallado";
            this.BtnRecaudoDetallado.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnRecaudoDetallado.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRecaudoDetallado_ItemClick);
            // 
            // BtnRsmCredito
            // 
            this.BtnRsmCredito.Caption = "Resumen de Credito";
            this.BtnRsmCredito.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnRsmCredito.Glyph")));
            this.BtnRsmCredito.Id = 11;
            this.BtnRsmCredito.Name = "BtnRsmCredito";
            this.BtnRsmCredito.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnRsmCredito.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnRsmCredito_ItemClick);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Caption = "Exportar";
            this.BtnExportar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnExportar.Glyph")));
            this.BtnExportar.Id = 12;
            this.BtnExportar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnExportar.LargeGlyph")));
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.BtnExportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnExportar_ItemClick);
            // 
            // btnPIV
            // 
            this.btnPIV.Caption = "Adicion PIV";
            this.btnPIV.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPIV.Glyph")));
            this.btnPIV.Id = 13;
            this.btnPIV.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPIV.LargeGlyph")));
            this.btnPIV.Name = "btnPIV";
            this.btnPIV.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPIV_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Adjudicacion";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAddMonterey);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPIV);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnMod);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnDel);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnCambiarBase);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnDesistir);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnSalir);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnExportar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnConsultar);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnRecaudoDetallado);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnRsmCredito);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Consultas";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 553);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1335, 31);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 143);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1335, 410);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdAdjudicacion,
            this.IdTercero1,
            this.Cliente,
            this.Fecha,
            this.FechaContrato,
            this.Contrato,
            this.IdInmueble,
            this.TipoAdjudica,
            this.Temporada,
            this.Grado,
            this.Valor,
            this.TipoOperacion,
            this.Estado,
            this.Cliente2});
            this.gridView1.GridControl = this.gridControl1;
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
            this.IdAdjudicacion.VisibleIndex = 0;
            this.IdAdjudicacion.Width = 82;
            // 
            // IdTercero1
            // 
            this.IdTercero1.Caption = "Documento";
            this.IdTercero1.FieldName = "IdTercero1";
            this.IdTercero1.Name = "IdTercero1";
            this.IdTercero1.OptionsColumn.ReadOnly = true;
            this.IdTercero1.Visible = true;
            this.IdTercero1.VisibleIndex = 1;
            this.IdTercero1.Width = 97;
            // 
            // Cliente
            // 
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.OptionsColumn.ReadOnly = true;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 2;
            this.Cliente.Width = 193;
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.FieldName = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.OptionsColumn.ReadOnly = true;
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 4;
            this.Fecha.Width = 77;
            // 
            // FechaContrato
            // 
            this.FechaContrato.Caption = "FechaContrato";
            this.FechaContrato.FieldName = "FechaContrato";
            this.FechaContrato.Name = "FechaContrato";
            this.FechaContrato.Visible = true;
            this.FechaContrato.VisibleIndex = 5;
            this.FechaContrato.Width = 82;
            // 
            // Contrato
            // 
            this.Contrato.Caption = "Contrato";
            this.Contrato.FieldName = "Contrato";
            this.Contrato.Name = "Contrato";
            this.Contrato.OptionsColumn.ReadOnly = true;
            this.Contrato.Visible = true;
            this.Contrato.VisibleIndex = 6;
            // 
            // IdInmueble
            // 
            this.IdInmueble.Caption = "Inmueble";
            this.IdInmueble.FieldName = "IdInmueble";
            this.IdInmueble.Name = "IdInmueble";
            this.IdInmueble.OptionsColumn.ReadOnly = true;
            this.IdInmueble.Visible = true;
            this.IdInmueble.VisibleIndex = 7;
            // 
            // TipoAdjudica
            // 
            this.TipoAdjudica.Caption = "Categoria";
            this.TipoAdjudica.FieldName = "TipodeAdjudicacion";
            this.TipoAdjudica.Name = "TipoAdjudica";
            this.TipoAdjudica.OptionsColumn.ReadOnly = true;
            this.TipoAdjudica.Visible = true;
            this.TipoAdjudica.VisibleIndex = 8;
            this.TipoAdjudica.Width = 91;
            // 
            // Temporada
            // 
            this.Temporada.Caption = "Temporada";
            this.Temporada.FieldName = "Temporada";
            this.Temporada.Name = "Temporada";
            this.Temporada.OptionsColumn.ReadOnly = true;
            this.Temporada.Visible = true;
            this.Temporada.VisibleIndex = 9;
            this.Temporada.Width = 88;
            // 
            // Grado
            // 
            this.Grado.Caption = "Grado";
            this.Grado.FieldName = "Grado";
            this.Grado.Name = "Grado";
            this.Grado.OptionsColumn.ReadOnly = true;
            this.Grado.Visible = true;
            this.Grado.VisibleIndex = 10;
            this.Grado.Width = 67;
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
            this.Valor.VisibleIndex = 11;
            this.Valor.Width = 112;
            // 
            // TipoOperacion
            // 
            this.TipoOperacion.Caption = "TipoOperacion ";
            this.TipoOperacion.FieldName = "TipoOperacion";
            this.TipoOperacion.Name = "TipoOperacion";
            this.TipoOperacion.Visible = true;
            this.TipoOperacion.VisibleIndex = 12;
            this.TipoOperacion.Width = 66;
            // 
            // Estado
            // 
            this.Estado.Caption = "Estado";
            this.Estado.FieldName = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.OptionsColumn.ReadOnly = true;
            this.Estado.Visible = true;
            this.Estado.VisibleIndex = 13;
            this.Estado.Width = 74;
            // 
            // Cliente2
            // 
            this.Cliente2.Caption = "Titular2";
            this.Cliente2.FieldName = "Cliente2";
            this.Cliente2.Name = "Cliente2";
            this.Cliente2.Visible = true;
            this.Cliente2.VisibleIndex = 3;
            this.Cliente2.Width = 138;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Salir";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 6;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // FrmModuloAdjudicacionRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 584);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmModuloAdjudicacionRbf";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "FrmModuloAdjudicacionRbf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmModuloAdjudicacionRbf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem BtnAdd;
        private DevExpress.XtraBars.BarButtonItem BtnMod;
        private DevExpress.XtraBars.BarButtonItem BtnDel;
        private DevExpress.XtraBars.BarButtonItem BtnCambiarBase;
        private DevExpress.XtraBars.BarButtonItem BtnDesistir;
        private DevExpress.XtraBars.BarButtonItem BtnSalir;
   
        private DevExpress.XtraBars.BarButtonItem BtnAddMonterey;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente2;
        private DevExpress.XtraBars.BarButtonItem BtnConsultar;
        private DevExpress.XtraBars.BarButtonItem BtnRecaudoDetallado;
        private DevExpress.XtraBars.BarButtonItem BtnRsmCredito;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem BtnExportar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Columns.GridColumn FechaContrato;
        private DevExpress.XtraBars.BarButtonItem btnPIV;
    }
}