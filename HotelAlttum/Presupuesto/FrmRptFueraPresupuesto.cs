using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CarteraGeneral
{
    public partial class FrmRptFueraPresupuesto : Form
    {
        public FrmRptFueraPresupuesto()
        {
            InitializeComponent();
        }
        int varperiodo;
        string NomTabla, Scripseguimiento,Vartitulo;
        public string EntradaRango;
        ReportParameter[] parameters = new ReportParameter[1];
        private void FrmRptFueraPresupuesto_Load(object sender, EventArgs e)
        {
        }


//===================================================================================================================================================
// I N I C I O    M E T O D O   D A T O S   D E L   M E S 
//=================================================================================================================================================== 
        private void MtdDatosMes()
        {
            switch (CmbMes.Text)
            {
                case "Enero":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "01");
                    NomTabla = "PresupuestoEnero";
                    break;

                case "Febrero":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "02");
                    NomTabla = "PresupuestoFebrero";

                    break;

                case "Marzo":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "03");
                    NomTabla = "PresupuestoMarzo";
                    break;

                case "Abril":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "04");
                    NomTabla = "PresupuestoAbril";
                    break;
                case "Mayo":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "05");
                    NomTabla = "PresupuestoMayo";
                    break;

                case "Junio":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "06");
                    NomTabla = "PresupuestoJunio";
                    break;

                case "Julio":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "07");
                    NomTabla = "PresupuestoJulio";
                    break;

                case "Agosto":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "08");
                    NomTabla = "PresupuestoAgosto";
                    break;

                case "Septiembre":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "09");
                    NomTabla = "PresupuestoSeptiembre";
                    break;

                case "Octubre":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "10");
                    NomTabla = "PresupuestoOctubre";
                    break;

                case "Noviembre":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "11");
                    NomTabla = "PresupuestoNoviembre";
                    break;

                case "Diciembre":
                    varperiodo = Convert.ToInt32(TxtAño.Text + "12");
                    NomTabla = "PresupuestoDiciembre";
                    break;

                default:

                    break;
            }
        }
//===================================================================================================================================================
// F I N A L     M E T O D O   D A T O S   D E L   M E S 
//===================================================================================================================================================

//===================================================================================================================================================
// I N I C I O    M E T O D O  MtdScrip
//=================================================================================================================================================== 
        private void MtdScrip()
        {
         Scripseguimiento =
        " Select r.IdAdjudicacion,t.Identificacion as Cliente,r.Concepto,r.Numcuota CuotaNum,r.Fecha,"+
        " r.Capital,r.InteresCte Interes ,r.InteresMora Mora,(r.capital+r.InteresCte+r.interesMora)TtCuota  "+
        " from recaudos r "+
        " join 004cnsadjudica t on t.idadjudicacion=r.idadjudicacion "+
        " where periodo = " + varperiodo + 
        " and r.idfinanciacion not in(Select id from " + NomTabla+")";
        }
//===================================================================================================================================================
// F I N A L     M E T O D O   MtdScrip
//===================================================================================================================================================

        private void ScripExponNoPresupuestada()
        {
            Scripseguimiento =
       " Select r.IdAdjudicacion,t.Identificacion as Cliente,r.Concepto,r.Numcuota CuotaNum,r.Fecha," +
       " r.Capital,r.InteresCte Interes ,r.InteresMora Mora,(r.capital+r.InteresCte+r.interesMora)TtCuota  " +
       " from recaudos r " +
       " join 004cnsadjudica t on t.idadjudicacion=r.idadjudicacion " +
       " where periodo = " + varperiodo +
       " and r.idfinanciacion not in(Select id from " + NomTabla + ") And r.IdAdjudicacion Not In (Select idAdjudicacion from " + NomTabla + ")";
        }

        private void ScripExponPresupuestada()
        {
            Scripseguimiento =
         " Select r.IdAdjudicacion,t.Identificacion as Cliente,r.Concepto,r.Numcuota CuotaNum,r.Fecha," +
         " r.Capital,r.InteresCte Interes ,r.InteresMora Mora,(r.capital+r.InteresCte+r.interesMora)TtCuota  " +
         " from recaudos r " +
         " join 004cnsadjudica t on t.idadjudicacion=r.idadjudicacion " +
         " where periodo = " + varperiodo +
         " and r.idfinanciacion not in(Select id from " + NomTabla + ") And r.IdAdjudicacion  In (Select idAdjudicacion from " + NomTabla + ")";
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {

            if (CmbMes.Text == "")
            {
                MessageBox.Show("Falta Seleccionar Mes", "Seguimiento Presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                if (TxtAño.Text == "")
                {
                    MessageBox.Show("Falta Seleccionar Año", "Seguimiento Presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    BtnCalcular.Enabled = false;
                    BtnCalcular.Cursor = Cursors.AppStarting;
                    MtdDatosMes();

                    if (EntradaRango == "Recaudo Fuera")
                    {
                        MtdScrip();
                        Vartitulo = "RECAUDOS FUERA PRESUPUESTO";
                    }
                    if (EntradaRango == "Expontaneo Fuera")
                    {
                        ScripExponNoPresupuestada();
                        Vartitulo = "RECAUDOS EXPONTANEO NO PRESUPUESTADO";
                    }
                    if (EntradaRango == "Expontaneo Dentro")
                    {
                        ScripExponPresupuestada();
                        Vartitulo = "RECAUDOS EXPONTANEO  PRESUPUESTADO";
                    }


                    parameters[0] = new ReportParameter("Titulo", Vartitulo);
                    this.rptrcdfuerapresupTableAdapter.Fill(this.CarteraGeneralDataSet.rptrcdfuerapresup);
                    this.rptrcdfuerapresupTableAdapter.Adapter.SelectCommand.CommandText = Scripseguimiento;
                    this.rptrcdfuerapresupTableAdapter.Fill(this.CarteraGeneralDataSet.rptrcdfuerapresup);
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    this.reportViewer1.RefreshReport();
                    BtnCalcular.Enabled = true;
                    BtnCalcular.Cursor = Cursors.Default;
                }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
