namespace CarteraGeneral
{
    partial class FrmAdjudicacionMonterey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdjudicacionMonterey));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.BtnEnvioDirecta = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.GridModAdjMont = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridModAdjMont)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.BtnEnvioDirecta});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(528, 141);
            // 
            // BtnEnvioDirecta
            // 
            this.BtnEnvioDirecta.Caption = "Envio a Directa";
            this.BtnEnvioDirecta.Glyph = ((System.Drawing.Image)(resources.GetObject("BtnEnvioDirecta.Glyph")));
            this.BtnEnvioDirecta.Id = 1;
            this.BtnEnvioDirecta.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("BtnEnvioDirecta.LargeGlyph")));
            this.BtnEnvioDirecta.Name = "BtnEnvioDirecta";
            this.BtnEnvioDirecta.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnEnvioDirecta_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Envio a Directo";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.BtnEnvioDirecta);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // GridModAdjMont
            // 
            this.GridModAdjMont.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridModAdjMont.Location = new System.Drawing.Point(0, 141);
            this.GridModAdjMont.MainView = this.gridView1;
            this.GridModAdjMont.MenuManager = this.ribbonControl1;
            this.GridModAdjMont.Name = "GridModAdjMont";
            this.GridModAdjMont.Size = new System.Drawing.Size(528, 271);
            this.GridModAdjMont.TabIndex = 1;
            this.GridModAdjMont.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GridModAdjMont;
            this.gridView1.Name = "gridView1";
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            // 
            // FrmAdjudicacionMonterey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 412);
            this.Controls.Add(this.GridModAdjMont);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "FrmAdjudicacionMonterey";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmAdjudicacionMonterey";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmAdjudicacionMonterey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridModAdjMont)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem BtnEnvioDirecta;
        private DevExpress.XtraGrid.GridControl GridModAdjMont;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}