namespace CarteraGeneral.Modulo_Rbf.Terceros
{
    partial class FrmCatalogoTercerosRbf
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
            this.GrdTerceros = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdTercero = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Direccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ciudad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Telefono1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Telefono2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // GrdTerceros
            // 
            this.GrdTerceros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdTerceros.Location = new System.Drawing.Point(0, 0);
            this.GrdTerceros.MainView = this.gridView1;
            this.GrdTerceros.Name = "GrdTerceros";
            this.GrdTerceros.Size = new System.Drawing.Size(721, 480);
            this.GrdTerceros.TabIndex = 3;
            this.GrdTerceros.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdTercero,
            this.Cliente,
            this.Direccion,
            this.Ciudad,
            this.Telefono1,
            this.Telefono2});
            this.gridView1.GridControl = this.GrdTerceros;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
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
            // FrmCatalogoTercerosRbf
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 480);
            this.Controls.Add(this.GrdTerceros);
            this.Name = "FrmCatalogoTercerosRbf";
            this.Text = "FrmCatalogoTercerosRbf";
            ((System.ComponentModel.ISupportInitialize)(this.GrdTerceros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl GrdTerceros;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn IdTercero;
        private DevExpress.XtraGrid.Columns.GridColumn Cliente;
        private DevExpress.XtraGrid.Columns.GridColumn Direccion;
        private DevExpress.XtraGrid.Columns.GridColumn Ciudad;
        private DevExpress.XtraGrid.Columns.GridColumn Telefono1;
        private DevExpress.XtraGrid.Columns.GridColumn Telefono2;
    }
}