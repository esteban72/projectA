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
    public partial class FrmComisionesxPagarMonterey : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmComisionesxPagarMonterey()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        public string EntradaComision;
        private void FrmComisionesxPagarMonterey_Load(object sender, EventArgs e)
        {
            if (EntradaComision == "Enganche")
            {
                GrdComisiones.DataSource = conexion.MtdBuscarDataset(MisConsultas.ComisionesMonterey);
            }
            else
                if(EntradaComision=="Tiempo")
                {
                    GrdComisiones.DataSource = conexion.MtdBuscarDataset(MisConsultas.ComisionesMonterreyTiempo);
                }
        }

        private void BtnExportar_ItemClick(object sender, ItemClickEventArgs e)
        {
            conexion.impirmir (GrdComisiones, "COMISIONES POR PAGAR MONTEREY A CORTE " + DateTime.Now.ToShortDateString());
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }
    }
}