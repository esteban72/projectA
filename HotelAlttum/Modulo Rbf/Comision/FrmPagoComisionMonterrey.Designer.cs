namespace CarteraGeneral.Modulo_Rbf.Comision
{
    partial class FrmPagoComisionMonterrey
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPagoComisionMonterrey));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnPagar = new DevExpress.XtraBars.BarButtonItem();
            this.btnActualizar = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcel = new DevExpress.XtraBars.BarButtonItem();
            this.pestanaComisiones = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.SeccionComisiones = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.lblContrato = new DevExpress.XtraEditors.LabelControl();
            this.lblInmueble = new DevExpress.XtraEditors.LabelControl();
            this.lblCliente = new DevExpress.XtraEditors.LabelControl();
            this.lblFechaContrato = new DevExpress.XtraEditors.LabelControl();
            this.txtInmueble = new DevExpress.XtraEditors.TextEdit();
            this.txtCliente = new DevExpress.XtraEditors.TextEdit();
            this.grdComisionesMonterrey = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblPorcentajeVenta = new DevExpress.XtraEditors.LabelControl();
            this.lblTRMFechaContrato = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalRecaudado = new DevExpress.XtraEditors.LabelControl();
            this.lblVentaTotal = new DevExpress.XtraEditors.LabelControl();
            this.txtTotalRecaudado = new DevExpress.XtraEditors.TextEdit();
            this.txtVentaTotal = new DevExpress.XtraEditors.TextEdit();
            this.txtTRM = new DevExpress.XtraEditors.TextEdit();
            this.imgAlttum = new DevExpress.XtraEditors.PictureEdit();
            this.cmbContrato = new System.Windows.Forms.ComboBox();
            this.lblMensaje = new System.Windows.Forms.Label();
            this.pictureBoxVerificar = new System.Windows.Forms.PictureBox();
            this.txtFechaContrato = new DevExpress.XtraEditors.TextEdit();
            this.txtPorcentajeComisionado = new DevExpress.XtraEditors.TextEdit();
            this.cmbVecesPagoComision = new System.Windows.Forms.ComboBox();
            this.lblVecesComision = new System.Windows.Forms.Label();
            this.lblMensajeComision = new System.Windows.Forms.Label();
            this.lblNotaValorFijo = new System.Windows.Forms.Label();
            this.txtNotaValorFijo = new System.Windows.Forms.TextBox();
            this.txtTotalPagarComision = new DevExpress.XtraEditors.TextEdit();
            this.lblTotalPagarComision = new DevExpress.XtraEditors.LabelControl();
            this.btnRechazar = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInmueble.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdComisionesMonterrey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRecaudado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVentaTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTRM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAlttum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVerificar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaContrato.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentajeComisionado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPagarComision.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.btnPagar,
            this.btnActualizar,
            this.btnExcel,
            this.btnRechazar});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.pestanaComisiones});
            this.ribbon.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbon.Size = new System.Drawing.Size(1368, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnPagar
            // 
            this.btnPagar.Caption = "Pagar";
            this.btnPagar.Glyph = global::CarteraGeneral.RecursosIconos.efectivo;
            this.btnPagar.Id = 1;
            this.btnPagar.Name = "btnPagar";
            this.btnPagar.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.btnPagar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPagar_ItemClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Caption = "Actualizar";
            this.btnActualizar.Id = 2;
            this.btnActualizar.ImageUri.Uri = "Recurrence";
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnActualizar_ItemClick);
            // 
            // btnExcel
            // 
            this.btnExcel.Caption = "Exportar a Excel";
            this.btnExcel.Id = 3;
            this.btnExcel.ImageUri.Uri = "ExportToXLS";
            this.btnExcel.Name = "btnExcel";
            // 
            // pestanaComisiones
            // 
            this.pestanaComisiones.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.SeccionComisiones});
            this.pestanaComisiones.Name = "pestanaComisiones";
            this.pestanaComisiones.Text = "Comisiones";
            // 
            // SeccionComisiones
            // 
            this.SeccionComisiones.ItemLinks.Add(this.btnPagar);
            this.SeccionComisiones.ItemLinks.Add(this.btnActualizar);
            this.SeccionComisiones.ItemLinks.Add(this.btnRechazar);
            this.SeccionComisiones.Name = "SeccionComisiones";
            this.SeccionComisiones.Text = "Comisiones M.";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 642);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1368, 31);
            // 
            // lblContrato
            // 
            this.lblContrato.Location = new System.Drawing.Point(22, 171);
            this.lblContrato.Name = "lblContrato";
            this.lblContrato.Size = new System.Drawing.Size(62, 13);
            this.lblContrato.TabIndex = 2;
            this.lblContrato.Text = "N° Contrato:";
            // 
            // lblInmueble
            // 
            this.lblInmueble.Location = new System.Drawing.Point(22, 257);
            this.lblInmueble.Name = "lblInmueble";
            this.lblInmueble.Size = new System.Drawing.Size(48, 13);
            this.lblInmueble.TabIndex = 3;
            this.lblInmueble.Text = "Inmueble:";
            // 
            // lblCliente
            // 
            this.lblCliente.Location = new System.Drawing.Point(22, 231);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(37, 13);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente:";
            // 
            // lblFechaContrato
            // 
            this.lblFechaContrato.Location = new System.Drawing.Point(22, 283);
            this.lblFechaContrato.Name = "lblFechaContrato";
            this.lblFechaContrato.Size = new System.Drawing.Size(79, 13);
            this.lblFechaContrato.TabIndex = 5;
            this.lblFechaContrato.Text = "Fecha Contrato:";
            // 
            // txtInmueble
            // 
            this.txtInmueble.Location = new System.Drawing.Point(141, 252);
            this.txtInmueble.MenuManager = this.ribbon;
            this.txtInmueble.Name = "txtInmueble";
            this.txtInmueble.Properties.ReadOnly = true;
            this.txtInmueble.Size = new System.Drawing.Size(135, 20);
            this.txtInmueble.TabIndex = 3;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(141, 226);
            this.txtCliente.MenuManager = this.ribbon;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Properties.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(243, 20);
            this.txtCliente.TabIndex = 2;
            // 
            // grdComisionesMonterrey
            // 
            this.grdComisionesMonterrey.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdComisionesMonterrey.EmbeddedNavigator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdComisionesMonterrey.EmbeddedNavigator.Appearance.BackColor = System.Drawing.Color.White;
            this.grdComisionesMonterrey.EmbeddedNavigator.Appearance.Options.UseBackColor = true;
            this.grdComisionesMonterrey.EmbeddedNavigator.Appearance.Options.UseTextOptions = true;
            this.grdComisionesMonterrey.EmbeddedNavigator.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.grdComisionesMonterrey.EmbeddedNavigator.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.grdComisionesMonterrey.Location = new System.Drawing.Point(0, 321);
            this.grdComisionesMonterrey.LookAndFeel.SkinName = "Metropolis Dark";
            this.grdComisionesMonterrey.MainView = this.gridView1;
            this.grdComisionesMonterrey.MenuManager = this.ribbon;
            this.grdComisionesMonterrey.Name = "grdComisionesMonterrey";
            this.grdComisionesMonterrey.Size = new System.Drawing.Size(1368, 315);
            this.grdComisionesMonterrey.TabIndex = 11;
            this.grdComisionesMonterrey.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grdComisionesMonterrey;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // lblPorcentajeVenta
            // 
            this.lblPorcentajeVenta.Location = new System.Drawing.Point(618, 253);
            this.lblPorcentajeVenta.Name = "lblPorcentajeVenta";
            this.lblPorcentajeVenta.Size = new System.Drawing.Size(119, 13);
            this.lblPorcentajeVenta.TabIndex = 13;
            this.lblPorcentajeVenta.Text = "Porcentaje Comisionado:";
            // 
            // lblTRMFechaContrato
            // 
            this.lblTRMFechaContrato.Location = new System.Drawing.Point(618, 227);
            this.lblTRMFechaContrato.Name = "lblTRMFechaContrato";
            this.lblTRMFechaContrato.Size = new System.Drawing.Size(99, 13);
            this.lblTRMFechaContrato.TabIndex = 14;
            this.lblTRMFechaContrato.Text = "TRM fecha contrato:";
            // 
            // lblTotalRecaudado
            // 
            this.lblTotalRecaudado.Location = new System.Drawing.Point(618, 201);
            this.lblTotalRecaudado.Name = "lblTotalRecaudado";
            this.lblTotalRecaudado.Size = new System.Drawing.Size(85, 13);
            this.lblTotalRecaudado.TabIndex = 15;
            this.lblTotalRecaudado.Text = "Total Recaudado:";
            // 
            // lblVentaTotal
            // 
            this.lblVentaTotal.Location = new System.Drawing.Point(618, 175);
            this.lblVentaTotal.Name = "lblVentaTotal";
            this.lblVentaTotal.Size = new System.Drawing.Size(59, 13);
            this.lblVentaTotal.TabIndex = 16;
            this.lblVentaTotal.Text = "Total Venta:";
            // 
            // txtTotalRecaudado
            // 
            this.txtTotalRecaudado.Location = new System.Drawing.Point(743, 198);
            this.txtTotalRecaudado.MenuManager = this.ribbon;
            this.txtTotalRecaudado.Name = "txtTotalRecaudado";
            this.txtTotalRecaudado.Properties.ReadOnly = true;
            this.txtTotalRecaudado.Size = new System.Drawing.Size(156, 20);
            this.txtTotalRecaudado.TabIndex = 6;
            // 
            // txtVentaTotal
            // 
            this.txtVentaTotal.Location = new System.Drawing.Point(743, 172);
            this.txtVentaTotal.MenuManager = this.ribbon;
            this.txtVentaTotal.Name = "txtVentaTotal";
            this.txtVentaTotal.Properties.ReadOnly = true;
            this.txtVentaTotal.Size = new System.Drawing.Size(156, 20);
            this.txtVentaTotal.TabIndex = 5;
            // 
            // txtTRM
            // 
            this.txtTRM.Location = new System.Drawing.Point(743, 224);
            this.txtTRM.MenuManager = this.ribbon;
            this.txtTRM.Name = "txtTRM";
            this.txtTRM.Properties.ReadOnly = true;
            this.txtTRM.Size = new System.Drawing.Size(156, 20);
            this.txtTRM.TabIndex = 7;
            // 
            // imgAlttum
            // 
            this.imgAlttum.EditValue = global::CarteraGeneral.RecursosIconos.LogoAlttum;
            this.imgAlttum.Location = new System.Drawing.Point(1004, 171);
            this.imgAlttum.MenuManager = this.ribbon;
            this.imgAlttum.Name = "imgAlttum";
            this.imgAlttum.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imgAlttum.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.imgAlttum.Size = new System.Drawing.Size(256, 99);
            this.imgAlttum.TabIndex = 26;
            // 
            // cmbContrato
            // 
            this.cmbContrato.FormattingEnabled = true;
            this.cmbContrato.Location = new System.Drawing.Point(141, 168);
            this.cmbContrato.Name = "cmbContrato";
            this.cmbContrato.Size = new System.Drawing.Size(135, 21);
            this.cmbContrato.TabIndex = 0;
            this.cmbContrato.SelectedIndexChanged += new System.EventHandler(this.cmbContrato_SelectedIndexChanged);
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.ForeColor = System.Drawing.Color.Red;
            this.lblMensaje.Location = new System.Drawing.Point(309, 172);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(11, 13);
            this.lblMensaje.TabIndex = 30;
            this.lblMensaje.Text = "|";
            // 
            // pictureBoxVerificar
            // 
            this.pictureBoxVerificar.Location = new System.Drawing.Point(282, 172);
            this.pictureBoxVerificar.Name = "pictureBoxVerificar";
            this.pictureBoxVerificar.Size = new System.Drawing.Size(21, 21);
            this.pictureBoxVerificar.TabIndex = 31;
            this.pictureBoxVerificar.TabStop = false;
            // 
            // txtFechaContrato
            // 
            this.txtFechaContrato.Location = new System.Drawing.Point(141, 278);
            this.txtFechaContrato.MenuManager = this.ribbon;
            this.txtFechaContrato.Name = "txtFechaContrato";
            this.txtFechaContrato.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFechaContrato.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtFechaContrato.Properties.ReadOnly = true;
            this.txtFechaContrato.Size = new System.Drawing.Size(135, 20);
            this.txtFechaContrato.TabIndex = 4;
            // 
            // txtPorcentajeComisionado
            // 
            this.txtPorcentajeComisionado.Location = new System.Drawing.Point(743, 250);
            this.txtPorcentajeComisionado.MenuManager = this.ribbon;
            this.txtPorcentajeComisionado.Name = "txtPorcentajeComisionado";
            this.txtPorcentajeComisionado.Properties.ReadOnly = true;
            this.txtPorcentajeComisionado.Size = new System.Drawing.Size(156, 20);
            this.txtPorcentajeComisionado.TabIndex = 8;
            // 
            // cmbVecesPagoComision
            // 
            this.cmbVecesPagoComision.FormattingEnabled = true;
            this.cmbVecesPagoComision.Location = new System.Drawing.Point(141, 198);
            this.cmbVecesPagoComision.Name = "cmbVecesPagoComision";
            this.cmbVecesPagoComision.Size = new System.Drawing.Size(44, 21);
            this.cmbVecesPagoComision.TabIndex = 1;
            this.cmbVecesPagoComision.SelectedIndexChanged += new System.EventHandler(this.cmbVecesPagoComision_SelectedIndexChanged);
            // 
            // lblVecesComision
            // 
            this.lblVecesComision.AutoSize = true;
            this.lblVecesComision.Location = new System.Drawing.Point(19, 193);
            this.lblVecesComision.Name = "lblVecesComision";
            this.lblVecesComision.Size = new System.Drawing.Size(116, 26);
            this.lblVecesComision.TabIndex = 35;
            this.lblVecesComision.Text = "Veces que puede \ncomisionar el contrato:";
            // 
            // lblMensajeComision
            // 
            this.lblMensajeComision.AutoSize = true;
            this.lblMensajeComision.ForeColor = System.Drawing.Color.Red;
            this.lblMensajeComision.Location = new System.Drawing.Point(191, 201);
            this.lblMensajeComision.Name = "lblMensajeComision";
            this.lblMensajeComision.Size = new System.Drawing.Size(11, 13);
            this.lblMensajeComision.TabIndex = 38;
            this.lblMensajeComision.Text = "|";
            // 
            // lblNotaValorFijo
            // 
            this.lblNotaValorFijo.AutoSize = true;
            this.lblNotaValorFijo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNotaValorFijo.Location = new System.Drawing.Point(428, 243);
            this.lblNotaValorFijo.Name = "lblNotaValorFijo";
            this.lblNotaValorFijo.Size = new System.Drawing.Size(36, 13);
            this.lblNotaValorFijo.TabIndex = 41;
            this.lblNotaValorFijo.Text = "Nota:";
            // 
            // txtNotaValorFijo
            // 
            this.txtNotaValorFijo.Location = new System.Drawing.Point(470, 224);
            this.txtNotaValorFijo.Multiline = true;
            this.txtNotaValorFijo.Name = "txtNotaValorFijo";
            this.txtNotaValorFijo.ReadOnly = true;
            this.txtNotaValorFijo.Size = new System.Drawing.Size(105, 68);
            this.txtNotaValorFijo.TabIndex = 42;
            this.txtNotaValorFijo.Text = "Las personas con valor fijo solo recibirán y se les registrará un pago.";
            // 
            // txtTotalPagarComision
            // 
            this.txtTotalPagarComision.Location = new System.Drawing.Point(743, 278);
            this.txtTotalPagarComision.MenuManager = this.ribbon;
            this.txtTotalPagarComision.Name = "txtTotalPagarComision";
            this.txtTotalPagarComision.Properties.ReadOnly = true;
            this.txtTotalPagarComision.Size = new System.Drawing.Size(156, 20);
            this.txtTotalPagarComision.TabIndex = 9;
            // 
            // lblTotalPagarComision
            // 
            this.lblTotalPagarComision.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTotalPagarComision.Location = new System.Drawing.Point(618, 273);
            this.lblTotalPagarComision.Name = "lblTotalPagarComision";
            this.lblTotalPagarComision.Size = new System.Drawing.Size(116, 26);
            this.lblTotalPagarComision.TabIndex = 46;
            this.lblTotalPagarComision.Text = "Total necesario para \npagar la comisión:";
            // 
            // btnRechazar
            // 
            this.btnRechazar.Caption = "Rechazar por falta de comisionistas";
            this.btnRechazar.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRechazar.Glyph")));
            this.btnRechazar.Id = 4;
            this.btnRechazar.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRechazar.LargeGlyph")));
            this.btnRechazar.Name = "btnRechazar";
            this.btnRechazar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRechazar_ItemClick);
            // 
            // FrmPagoComisionMonterrey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 673);
            this.Controls.Add(this.lblTotalPagarComision);
            this.Controls.Add(this.txtTotalPagarComision);
            this.Controls.Add(this.txtNotaValorFijo);
            this.Controls.Add(this.lblNotaValorFijo);
            this.Controls.Add(this.lblMensajeComision);
            this.Controls.Add(this.lblVecesComision);
            this.Controls.Add(this.cmbVecesPagoComision);
            this.Controls.Add(this.txtPorcentajeComisionado);
            this.Controls.Add(this.pictureBoxVerificar);
            this.Controls.Add(this.lblMensaje);
            this.Controls.Add(this.cmbContrato);
            this.Controls.Add(this.imgAlttum);
            this.Controls.Add(this.txtTRM);
            this.Controls.Add(this.txtVentaTotal);
            this.Controls.Add(this.txtTotalRecaudado);
            this.Controls.Add(this.lblVentaTotal);
            this.Controls.Add(this.lblTotalRecaudado);
            this.Controls.Add(this.lblTRMFechaContrato);
            this.Controls.Add(this.lblPorcentajeVenta);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.txtInmueble);
            this.Controls.Add(this.lblFechaContrato);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.lblInmueble);
            this.Controls.Add(this.lblContrato);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.grdComisionesMonterrey);
            this.Controls.Add(this.txtFechaContrato);
            this.Controls.Add(this.ribbon);
            this.MaximizeBox = false;
            this.Name = "FrmPagoComisionMonterrey";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Comisiones Monterrey ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPagoComisionMonterrey_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtInmueble.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdComisionesMonterrey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalRecaudado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVentaTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTRM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgAlttum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVerificar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFechaContrato.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPorcentajeComisionado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTotalPagarComision.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage pestanaComisiones;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup SeccionComisiones;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnPagar;
        private DevExpress.XtraEditors.LabelControl lblContrato;
        private DevExpress.XtraEditors.LabelControl lblInmueble;
        private DevExpress.XtraEditors.LabelControl lblCliente;
        private DevExpress.XtraEditors.LabelControl lblFechaContrato;
        private DevExpress.XtraEditors.TextEdit txtInmueble;
        private DevExpress.XtraEditors.TextEdit txtCliente;
        private DevExpress.XtraGrid.GridControl grdComisionesMonterrey;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl lblVentaTotal;
        private DevExpress.XtraEditors.LabelControl lblTotalRecaudado;
        private DevExpress.XtraEditors.LabelControl lblTRMFechaContrato;
        private DevExpress.XtraEditors.LabelControl lblPorcentajeVenta;
        private DevExpress.XtraEditors.TextEdit txtTRM;
        private DevExpress.XtraEditors.TextEdit txtVentaTotal;
        private DevExpress.XtraEditors.TextEdit txtTotalRecaudado;
        private DevExpress.XtraEditors.PictureEdit imgAlttum;
        private System.Windows.Forms.ComboBox cmbContrato;
        private System.Windows.Forms.Label lblMensaje;
        private System.Windows.Forms.PictureBox pictureBoxVerificar;
        private DevExpress.XtraEditors.TextEdit txtFechaContrato;
        private DevExpress.XtraEditors.TextEdit txtPorcentajeComisionado;
        private DevExpress.XtraBars.BarButtonItem btnActualizar;
        private DevExpress.XtraBars.BarButtonItem btnExcel;
        private System.Windows.Forms.ComboBox cmbVecesPagoComision;
        private System.Windows.Forms.Label lblVecesComision;
        private System.Windows.Forms.Label lblMensajeComision;
        private System.Windows.Forms.Label lblNotaValorFijo;
        private System.Windows.Forms.TextBox txtNotaValorFijo;
        private DevExpress.XtraEditors.TextEdit txtTotalPagarComision;
        private DevExpress.XtraEditors.LabelControl lblTotalPagarComision;
        private DevExpress.XtraBars.BarButtonItem btnRechazar;
    }
}