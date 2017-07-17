using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace CarteraGeneral
{
    public partial class FrmRsmPagoComision : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmRsmPagoComision()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        private void BtnConsultar_ItemClick(object sender, ItemClickEventArgs e)
        {
            GrdComisiones.DataSource = conexion.MtdBuscarDataset(RscComisiones.RsmComisiones, Convert.ToDateTime(DtpFecha.EditValue.ToString()));
        }

        private void BtnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            conexion.impirmir(GrdComisiones, "RESUMEN COMISIONES PAGADAS EL DIA " + DtpFecha.EditValue.ToString());
        }
    }
}