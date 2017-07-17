namespace CarteraGeneral
{
    partial class FrmModuloUsuariosRbf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuloUsuariosRbf));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnAdd = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMod = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.BtnConsultar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDesistir = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAddRecaudos = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAdjudicar = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GrdTerceros = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NombreUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 492);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(631, 27);
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
            this.BtnExportar,
            this.BtnDesistir,
            this.BtnAddRecaudos,
            this.BtnAdjudicar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(631, 141);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // BtnAdd
            // 
            this.BtnAdd.Caption = "Adicionar Preferente";
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
            // BtnDesistir
            // 
            this.BtnDesistir.Caption = "Desistir";
            this.BtnDesistir.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnDesistir.Glyph")));
            this.BtnDesistir.Id = 6;
            this.BtnDesistir.Name = "BtnDesistir";
            this.BtnDesistir.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // BtnAddRecaudos
            // 
            this.BtnAddRecaudos.Caption = "Adicionar Recaudos";
            this.BtnAddRecaudos.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAddRecaudos.Glyph")));
            this.BtnAddRecaudos.Id = 7;
            this.BtnAddRecaudos.Name = "BtnAddRecaudos";
            this.BtnAddRecaudos.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // BtnAdjudicar
            // 
            this.BtnAdjudicar.Caption = "Adjudicar";
            this.BtnAdjudicar.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAdjudicar.Glyph")));
            this.BtnAdjudicar.Id = 8;
            this.BtnAdjudicar.Name = "BtnAdjudicar";
            this.BtnAdjudicar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
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
            // GrdTerceros
            // 
            this.GrdTerceros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdTerceros.Location = new System.Drawing.Point(0, 141);
            this.GrdTerceros.MainView = this.gridView1;
            this.GrdTerceros.MenuManager = this.ribbon;
            this.GrdTerceros.Name = "GrdTerceros";
            this.GrdTerceros.Size = new System.Drawing.Size(631, 378);
            this.GrdTerceros.TabIndex = 8;
            this.GrdTerceros.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdUsuario,
            this.NombreUsuario});
            this.gridView1.GridControl = this.GrdTerceros;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // IdUsuario
            // 
            this.IdUsuario.Caption = "IdUsuario";
            this.IdUsuario.FieldName = "IdUsuario";
            this.IdUsuario.Name = "IdUsuario";
            this.IdUsuario.OptionsColumn.ReadOnly = true;
            this.IdUsuario.Visible = true;
            this.IdUsuario.VisibleIndex = 0;
            this.IdUsuario.Width = 96;
            // 
            // NombreUsuario
            // 
            this.NombreUsuario.Caption = "NombreUsuario";
            this.NombreUsuario.FieldName = "NombreUsuario";
            this.NombreUsuario.Name = "NombreUsuario";
            this.NombreUsuario.OptionsColumn.ReadOnly = true;
            this.NombreUsuario.Visible = true;
            this.NombreUsuario.VisibleIndex = 1;
            this.NombreUsuario.Width = 118;
            // 
            // FrmModuloUsuariosRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 519);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.GrdTerceros);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmModuloUsuariosRbf";
            this.Text = "FrmModuloUsuariosRbf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmModuloUsuariosRbf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem BtnAdd;
        private DevExpress.XtraBars.BarButtonItem BtnMod;
        private DevExpress.XtraBars.BarButtonItem BtnDel;
        private DevExpress.XtraBars.BarButtonItem BtnConsultar;
        private DevExpress.XtraBars.BarButtonItem BtnExportar;
        private DevExpress.XtraBars.BarButtonItem BtnDesistir;
        private DevExpress.XtraBars.BarButtonItem BtnAddRecaudos;
        private DevExpress.XtraBars.BarButtonItem BtnAdjudicar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraGrid.GridControl GrdTerceros;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IdUsuario;
        private DevExpress.XtraGrid.Columns.GridColumn NombreUsuario;
    }
}