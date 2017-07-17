namespace CarteraGeneral
{
    partial class FrmAprobarVentasRbf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAprobarVentasRbf));
            this.Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Valor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Grado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Temporada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoAdjudica = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdInmueble = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Contrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdTercero1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdAdjudicacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipoOperacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnAprobar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnSalir = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.BtnConsultar = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // Estado
            // 
            this.Estado.Caption = "Estado";
            this.Estado.FieldName = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.OptionsColumn.ReadOnly = true;
            this.Estado.Visible = true;
            this.Estado.VisibleIndex = 11;
            this.Estado.Width = 62;
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
            // TipoAdjudica
            // 
            this.TipoAdjudica.Caption = "TipoAdjudica";
            this.TipoAdjudica.FieldName = "TipoAdjudica";
            this.TipoAdjudica.Name = "TipoAdjudica";
            this.TipoAdjudica.OptionsColumn.ReadOnly = true;
            this.TipoAdjudica.Visible = true;
            this.TipoAdjudica.VisibleIndex = 6;
            this.TipoAdjudica.Width = 109;
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
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.FieldName = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.OptionsColumn.ReadOnly = true;
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 3;
            this.Fecha.Width = 90;
            // 
            // Cliente
            // 
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.OptionsColumn.ReadOnly = true;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 2;
            this.Cliente.Width = 273;
            // 
            // IdTercero1
            // 
            this.IdTercero1.Caption = "Documento";
            this.IdTercero1.FieldName = "IdTercero1";
            this.IdTercero1.Name = "IdTercero1";
            this.IdTercero1.OptionsColumn.ReadOnly = true;
            this.IdTercero1.Visible = true;
            this.IdTercero1.VisibleIndex = 1;
            this.IdTercero1.Width = 109;
            // 
            // IdAdjudicacion
            // 
            this.IdAdjudicacion.Caption = "Adj";
            this.IdAdjudicacion.FieldName = "IdAdjudicacion";
            this.IdAdjudicacion.Name = "IdAdjudicacion";
            this.IdAdjudicacion.OptionsColumn.ReadOnly = true;
            this.IdAdjudicacion.Visible = true;
            this.IdAdjudicacion.VisibleIndex = 0;
            this.IdAdjudicacion.Width = 93;
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
            this.Estado});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Valor", this.Valor, "(Valor: SUMA={0:N2})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 141);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbon;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1325, 380);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.BtnAprobar,
            this.BtnSalir,
            this.BtnConsultar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1325, 141);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // BtnAprobar
            // 
            this.BtnAprobar.Caption = "Aprobar Venta";
            this.BtnAprobar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAprobar.Glyph")));
            this.BtnAprobar.Id = 1;
            this.BtnAprobar.Name = "BtnAprobar";
            this.BtnAprobar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnAprobar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAdd_ItemClick);
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
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Aprobar Ventas";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAprobar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnConsultar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnSalir);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Aciones de Aprobacion";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 494);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1325, 27);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Caption = "Consultaar";
            this.BtnConsultar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnConsultar.Glyph")));
            this.BtnConsultar.Id = 8;
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnConsultar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnConsultar_ItemClick);
            // 
            // FrmAprobarVentasRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 521);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmAprobarVentasRbf";
            this.Text = "FrmAprobarVentasRbf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAprobarVentasRbf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn Estado;
        private DevExpress.XtraGrid.Columns.GridColumn Valor;
        private DevExpress.XtraGrid.Columns.GridColumn Grado;
        private DevExpress.XtraGrid.Columns.GridColumn Temporada;
        private DevExpress.XtraGrid.Columns.GridColumn TipoAdjudica;
        private DevExpress.XtraGrid.Columns.GridColumn IdInmueble;
        private DevExpress.XtraGrid.Columns.GridColumn Contrato;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn IdTercero1;
        private DevExpress.XtraGrid.Columns.GridColumn IdAdjudicacion;
        private DevExpress.XtraGrid.Columns.GridColumn TipoOperacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem BtnAprobar;
        private DevExpress.XtraBars.BarButtonItem BtnSalir;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem BtnConsultar;
    }
}