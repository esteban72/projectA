using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;

namespace CarteraGeneral.Cartera
{
    public partial class Frm_Recaudos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Frm_Recaudos()
        {
            InitializeComponent();
        }
        ClsRecaudos recaudos = new ClsRecaudos("2");
        private void Frm_Recaudos_Load(object sender, EventArgs e)
        {
            TxtAdjudicacion.EditValue = recaudos.DtDatosGeneral.Rows[0][0];
            TxtCliente.EditValue = recaudos.DtDatosGeneral.Rows[0][2];
            TxtGrado.EditValue = recaudos.DtDatosGeneral.Rows[0][5];
            TxtSemana.EditValue = recaudos.DtDatosGeneral.Rows[0][6];
            TxtTemporada.EditValue = recaudos.DtDatosGeneral.Rows[0][4];
            TxtTipo.EditValue = recaudos.DtDatosGeneral.Rows[0][3];
            TxtDiasMora.EditValue = recaudos.MaxDiasMora;
            TxtPagoMinimo.EditValue = recaudos.PagoMinimo;
            TxtPagoTotal.EditValue = recaudos.PagoTotal;
            TxtInteresMora.EditValue = recaudos.InteresesMora;
            if (recaudos.UltFechaPago != null)
            {
                DtpUltimoPago.EditValue =Convert.ToDateTime( recaudos.UltFechaPago);
            }
            else
            {
                DtpUltimoPago.EditValue = recaudos.UltFechaPago;
            }
          
            GrdCuota.DataSource = recaudos.DtDatosCuota;
        }
    }
}