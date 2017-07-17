namespace CarteraGeneral
{
    partial class FrmModuloReservasRbf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModuloReservasRbf));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnAddPreferente = new DevExpress.XtraBars.BarButtonItem();
            this.BtnMod = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDel = new DevExpress.XtraBars.BarButtonItem();
            this.BtnConsultar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnExportar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnDesistir = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAddRecaudos = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAdjudicar = new DevExpress.XtraBars.BarButtonItem();
            this.BtnAddSistematica = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.GrdTerceros = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.BtnAddPreferente,
            this.BtnMod,
            this.BtnDel,
            this.BtnConsultar,
            this.BtnExportar,
            this.BtnDesistir,
            this.BtnAddRecaudos,
            this.BtnAdjudicar,
            this.BtnAddSistematica});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 10;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1327, 141);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // BtnAddPreferente
            // 
            this.BtnAddPreferente.Caption = "Adicionar Preferente";
            this.BtnAddPreferente.Enabled = false;
            this.BtnAddPreferente.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAddPreferente.Glyph")));
            this.BtnAddPreferente.Id = 1;
            this.BtnAddPreferente.Name = "BtnAddPreferente";
            this.BtnAddPreferente.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnAddPreferente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAddPreferente_ItemClick);
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
            this.BtnDesistir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnDesistir_ItemClick);
            // 
            // BtnAddRecaudos
            // 
            this.BtnAddRecaudos.Caption = "Adicionar Recaudos";
            this.BtnAddRecaudos.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAddRecaudos.Glyph")));
            this.BtnAddRecaudos.Id = 7;
            this.BtnAddRecaudos.Name = "BtnAddRecaudos";
            this.BtnAddRecaudos.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnAddRecaudos.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAddRecaudos_ItemClick);
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
            // BtnAddSistematica
            // 
            this.BtnAddSistematica.Caption = "Adicionar Sistematica";
            this.BtnAddSistematica.Enabled = false;
            this.BtnAddSistematica.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnAddSistematica.Glyph")));
            this.BtnAddSistematica.Id = 9;
            this.BtnAddSistematica.Name = "BtnAddSistematica";
            this.BtnAddSistematica.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.BtnAddSistematica.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnAddSistematica_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Inmuebles";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAddPreferente);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnAddSistematica);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnMod);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnDel);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnConsultar);
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnExportar);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Operaciones y Acciones";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnDesistir);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnAddRecaudos);
            this.ribbonPageGroup2.ItemLinks.Add(this.BtnAdjudicar);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Otras Acciones";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 489);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1327, 27);
            // 
            // GrdTerceros
            // 
            this.GrdTerceros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdTerceros.Location = new System.Drawing.Point(0, 141);
            this.GrdTerceros.MainView = this.gridView1;
            this.GrdTerceros.MenuManager = this.ribbon;
            this.GrdTerceros.Name = "GrdTerceros";
            this.GrdTerceros.Size = new System.Drawing.Size(1327, 348);
            this.GrdTerceros.TabIndex = 8;
            this.GrdTerceros.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GrdTerceros;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // FrmModuloReservasRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 516);
            this.Controls.Add(this.GrdTerceros);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "FrmModuloReservasRbf";
            this.Tag = "304";
            this.Text = "FrmModuloReservasRbf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.FrmModuloReservasRbf_Activated);
            this.Load += new System.EventHandler(this.FrmModuloReservasRbf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarButtonItem BtnAddPreferente;
        private DevExpress.XtraBars.BarButtonItem BtnMod;
        private DevExpress.XtraBars.BarButtonItem BtnDel;
        private DevExpress.XtraBars.BarButtonItem BtnConsultar;
        private DevExpress.XtraBars.BarButtonItem BtnExportar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem BtnDesistir;
        private DevExpress.XtraBars.BarButtonItem BtnAddRecaudos;
        private DevExpress.XtraBars.BarButtonItem BtnAdjudicar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem BtnAddSistematica;
        private DevExpress.XtraGrid.GridControl GrdTerceros;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}