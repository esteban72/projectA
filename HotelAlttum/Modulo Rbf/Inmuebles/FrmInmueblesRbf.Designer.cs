namespace CarteraGeneral.Modulo_Rbf.Inmuebles
{
    partial class FrmInmueblesRbf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInmueblesRbf));
            this.FechaContrato = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Temporada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Semana = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Unidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Villa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TipodeSemana = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdInmueble = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Estado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.GrdTerceros = new DevExpress.XtraGrid.GridControl();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMod = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.BtnConsultar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.CnsCompra = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // FechaContrato
            // 
            this.FechaContrato.Caption = "FechaContrato";
            this.FechaContrato.FieldName = "FechaContrato";
            this.FechaContrato.Name = "FechaContrato";
            this.FechaContrato.OptionsColumn.ReadOnly = true;
            this.FechaContrato.Visible = true;
            this.FechaContrato.VisibleIndex = 8;
            this.FechaContrato.Width = 120;
            // 
            // Temporada
            // 
            this.Temporada.Caption = "Temporada";
            this.Temporada.FieldName = "Temporada";
            this.Temporada.Name = "Temporada";
            this.Temporada.OptionsColumn.ReadOnly = true;
            this.Temporada.Visible = true;
            this.Temporada.VisibleIndex = 5;
            this.Temporada.Width = 116;
            // 
            // Semana
            // 
            this.Semana.Caption = "Semana";
            this.Semana.FieldName = "Semana";
            this.Semana.Name = "Semana";
            this.Semana.OptionsColumn.ReadOnly = true;
            this.Semana.Visible = true;
            this.Semana.VisibleIndex = 4;
            this.Semana.Width = 117;
            // 
            // Unidad
            // 
            this.Unidad.Caption = "Unidad";
            this.Unidad.FieldName = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.OptionsColumn.ReadOnly = true;
            this.Unidad.Visible = true;
            this.Unidad.VisibleIndex = 3;
            this.Unidad.Width = 137;
            // 
            // Villa
            // 
            this.Villa.Caption = "Villa";
            this.Villa.FieldName = "Villa";
            this.Villa.Name = "Villa";
            this.Villa.OptionsColumn.ReadOnly = true;
            this.Villa.Visible = true;
            this.Villa.VisibleIndex = 2;
            this.Villa.Width = 116;
            // 
            // TipodeSemana
            // 
            this.TipodeSemana.Caption = "TipodeSemana";
            this.TipodeSemana.FieldName = "TipodeSemana";
            this.TipodeSemana.Name = "TipodeSemana";
            this.TipodeSemana.OptionsColumn.ReadOnly = true;
            this.TipodeSemana.Visible = true;
            this.TipodeSemana.VisibleIndex = 1;
            this.TipodeSemana.Width = 151;
            // 
            // IdInmueble
            // 
            this.IdInmueble.Caption = "IdInmueble";
            this.IdInmueble.FieldName = "IdInmueble";
            this.IdInmueble.Name = "IdInmueble";
            this.IdInmueble.OptionsColumn.ReadOnly = true;
            this.IdInmueble.Visible = true;
            this.IdInmueble.VisibleIndex = 0;
            this.IdInmueble.Width = 78;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdInmueble,
            this.TipodeSemana,
            this.Villa,
            this.Unidad,
            this.Semana,
            this.Temporada,
            this.Cliente,
            this.FechaContrato,
            this.Estado,
            this.CnsCompra});
            this.gridView1.GridControl = this.GrdTerceros;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // Cliente
            // 
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.OptionsColumn.ReadOnly = true;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 7;
            this.Cliente.Width = 323;
            // 
            // Estado
            // 
            this.Estado.Caption = "Estado";
            this.Estado.FieldName = "Estado";
            this.Estado.Name = "Estado";
            this.Estado.Visible = true;
            this.Estado.VisibleIndex = 9;
            this.Estado.Width = 152;
            // 
            // GrdTerceros
            // 
            this.GrdTerceros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdTerceros.Location = new System.Drawing.Point(0, 141);
            this.GrdTerceros.MainView = this.gridView1;
            this.GrdTerceros.MenuManager = this.ribbon;
            this.GrdTerceros.Name = "GrdTerceros";
            this.GrdTerceros.Size = new System.Drawing.Size(1328, 415);
            this.GrdTerceros.TabIndex = 5;
            this.GrdTerceros.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.BtnAdd,
            this.BtnMod,
            this.BtnDel,
            this.BtnConsultar,
            this.BtnExportar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 6;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1328, 141);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Caption = "Adicionar";
            this.BtnAdd.Enabled = false;
            this.BtnAdd.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAdd.Glyph")));
            this.BtnAdd.Id = 1;
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAdd_ItemClick);
            // 
            // BtnMod
            // 
            this.BtnMod.Caption = "Modificar";
            this.BtnMod.Enabled = false;
            this.BtnMod.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnMod.Glyph")));
            this.BtnMod.Id = 2;
            this.BtnMod.Name = "BtnMod";
            this.BtnMod.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnMod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnMod_ItemClick);
            // 
            // BtnDel
            // 
            this.BtnDel.Caption = "Eliminar";
            this.BtnDel.Enabled = false;
            this.BtnDel.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnDel.Glyph")));
            this.BtnDel.Id = 3;
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnDel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDel_ItemClick);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Caption = "Consultar";
            this.BtnConsultar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnConsultar.Glyph")));
            this.BtnConsultar.Id = 4;
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnConsultar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnConsultar_ItemClick);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Caption = "Exportar";
            this.BtnExportar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnExportar.Glyph")));
            this.BtnExportar.Id = 5;
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnExportar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnExportar_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Inmuebles";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAdd);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnMod);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnDel);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnConsultar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnExportar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Operaciones y Acciones";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 556);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1328, 27);
            // 
            // CnsCompra
            // 
            this.CnsCompra.Caption = "CnsCompra";
            this.CnsCompra.FieldName = "CnsCompra";
            this.CnsCompra.Name = "CnsCompra";
            this.CnsCompra.Visible = true;
            this.CnsCompra.VisibleIndex = 6;
            // 
            // FrmInmueblesRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 583);
            this.Controls.Add(this.GrdTerceros);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmInmueblesRbf";
            this.Tag = "202";
            this.Text = "FrmInmueblesRbf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInmueblesRbf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn FechaContrato;
        private DevExpress.XtraGrid.Columns.GridColumn Temporada;
        private DevExpress.XtraGrid.Columns.GridColumn Semana;
        private DevExpress.XtraGrid.Columns.GridColumn Unidad;
        private DevExpress.XtraGrid.Columns.GridColumn Villa;
        private DevExpress.XtraGrid.Columns.GridColumn TipodeSemana;
        private DevExpress.XtraGrid.Columns.GridColumn IdInmueble;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.GridControl GrdTerceros;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem BtnAdd;
        private DevExpress.XtraBars.BarButtonItem BtnMod;
        private DevExpress.XtraBars.BarButtonItem BtnDel;
        private DevExpress.XtraBars.BarButtonItem BtnConsultar;
        private DevExpress.XtraBars.BarButtonItem BtnExportar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraGrid.Columns.GridColumn Estado;
        private DevExpress.XtraGrid.Columns.GridColumn CnsCompra;
    }
}