namespace CarteraGeneral.Modulo_Rbf.Terceros
{
    partial class RbfModuloAsesoresRbf
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RbfModuloAsesoresRbf));
            this.Email = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Telefono2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Telefono1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ciudad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Direccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdTercero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Celular = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // Email
            // 
            this.Email.Caption = "Email";
            this.Email.FieldName = "Email";
            this.Email.Name = "Email";
            this.Email.OptionsColumn.ReadOnly = true;
            this.Email.Visible = true;
            this.Email.VisibleIndex = 7;
            this.Email.Width = 280;
            // 
            // Telefono2
            // 
            this.Telefono2.Caption = "Telefono2";
            this.Telefono2.FieldName = "Telefono2";
            this.Telefono2.Name = "Telefono2";
            this.Telefono2.OptionsColumn.ReadOnly = true;
            this.Telefono2.Visible = true;
            this.Telefono2.VisibleIndex = 5;
            this.Telefono2.Width = 82;
            // 
            // Telefono1
            // 
            this.Telefono1.Caption = "Telefono1";
            this.Telefono1.FieldName = "Telefono1";
            this.Telefono1.Name = "Telefono1";
            this.Telefono1.OptionsColumn.ReadOnly = true;
            this.Telefono1.Visible = true;
            this.Telefono1.VisibleIndex = 4;
            this.Telefono1.Width = 74;
            // 
            // Ciudad
            // 
            this.Ciudad.Caption = "Ciudad";
            this.Ciudad.FieldName = "Ciudad";
            this.Ciudad.Name = "Ciudad";
            this.Ciudad.OptionsColumn.ReadOnly = true;
            this.Ciudad.Visible = true;
            this.Ciudad.VisibleIndex = 3;
            this.Ciudad.Width = 195;
            // 
            // Direccion
            // 
            this.Direccion.Caption = "Direccion";
            this.Direccion.FieldName = "Direccion";
            this.Direccion.Name = "Direccion";
            this.Direccion.OptionsColumn.ReadOnly = true;
            this.Direccion.Visible = true;
            this.Direccion.VisibleIndex = 2;
            this.Direccion.Width = 195;
            // 
            // Cliente
            // 
            this.Cliente.Caption = "Cliente";
            this.Cliente.FieldName = "NombreCompleto";
            this.Cliente.Name = "Cliente";
            this.Cliente.OptionsColumn.ReadOnly = true;
            this.Cliente.Visible = true;
            this.Cliente.VisibleIndex = 1;
            this.Cliente.Width = 271;
            // 
            // IdTercero
            // 
            this.IdTercero.Caption = "IdTercero";
            this.IdTercero.FieldName = "IdTercero";
            this.IdTercero.Name = "IdTercero";
            this.IdTercero.OptionsColumn.ReadOnly = true;
            this.IdTercero.Visible = true;
            this.IdTercero.VisibleIndex = 0;
            this.IdTercero.Width = 91;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdTercero,
            this.Cliente,
            this.Direccion,
            this.Ciudad,
            this.Telefono1,
            this.Telefono2,
            this.Celular,
            this.Email});
            this.gridView1.GridControl = this.GrdTerceros;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // Celular
            // 
            this.Celular.Caption = "Celular";
            this.Celular.FieldName = "Celular";
            this.Celular.Name = "Celular";
            this.Celular.OptionsColumn.ReadOnly = true;
            this.Celular.Visible = true;
            this.Celular.VisibleIndex = 6;
            this.Celular.Width = 95;
            // 
            // GrdTerceros
            // 
            this.GrdTerceros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdTerceros.Location = new System.Drawing.Point(0, 141);
            this.GrdTerceros.MainView = this.gridView1;
            this.GrdTerceros.MenuManager = this.ribbon;
            this.GrdTerceros.Name = "GrdTerceros";
            this.GrdTerceros.Size = new System.Drawing.Size(1293, 366);
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
            this.ribbon.Size = new System.Drawing.Size(1293, 141);
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
            this.ribbonPage1.Text = "Terceros";
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
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 507);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1293, 27);
            // 
            // RbfModuloAsesoresRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 534);
            this.Controls.Add(this.GrdTerceros);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "RbfModuloAsesoresRbf";
            this.Tag = "102";
            this.Text = "RbfModuloAsesoresRbf";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.RbfModuloAsesoresRbf_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn Email;
        private DevExpress.XtraGrid.Columns.GridColumn Telefono2;
        private DevExpress.XtraGrid.Columns.GridColumn Telefono1;
        private DevExpress.XtraGrid.Columns.GridColumn Ciudad;
        private DevExpress.XtraGrid.Columns.GridColumn Direccion;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn IdTercero;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn Celular;
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
    }
}