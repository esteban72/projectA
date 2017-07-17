using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarteraGeneral
{
    public partial class FrmRptSegPresupuesto : Form
    {
        public FrmRptSegPresupuesto()
        {
            InitializeComponent();
        }
        int varperiodo;
        string NomTabla,Scripseguimiento;
        private void FrmRptSegPresupuesto_Load(object sender, EventArgs e)
        {
            this.rptsegpresupuestoTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
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
            "select f.IdAdjudicacion,f.Cliente,f.Concepto,f.CuotaNum,F.Fecha,Capital,Interes,Mora,(Cuota+Mora)TtCuota," +
            " if((r.RcdCapital)is null,0,r.rcdCapital)RcdCapital," +
            " if((r.RcdInteresCte)is null,0,r.RcdInteresCte)RcdInteresCte," +
            " if((r.RcdInteresMora)is null,0,r.RcdInteresMora)RcdInteresMora," +
            " if((r.RcdCapital)is null,0,r.rcdCapital)  + if((r.RcdInteresCte)is null,0,r.RcdInteresCte) +if((r.RcdInteresMora)is null,0,r.RcdInteresMora)  As TtRecaudo" +
            " FROM " + NomTabla +
            " f" +
            " left join " +
            "(" +
            " select idfinanciacion,idadjudicacion," +
            " sum(Capital)RcdCapital," +
            " Sum(InteresCte)RcdInteresCte," +
            " Sum(InteresMora)RcdInteresMora" +
            " from recaudos where periodo =" + varperiodo +
            " GROUP by idfinanciacion" +
          "  )r " +
           " on r.idfinanciacion=f.id ";
        }
//===================================================================================================================================================
// F I N A L     M E T O D O   MtdScrip
//===================================================================================================================================================



        private void BtnCalcular_Click(object sender, EventArgs e)
        {
           
            if (CmbMes.Text == "")
            {
                MessageBox.Show("Falta Seleccionar Mes","Seguimiento Presupuesto",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else
                if(TxtAño.Text=="")
                {
                  MessageBox.Show("Falta Seleccionar Año","Seguimiento Presupuesto",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                else
                {
                    BtnCalcular.Enabled = false;
                    BtnCalcular.Cursor = Cursors.AppStarting;
                    MtdDatosMes();
                    MtdScrip();
                    this.rptsegpresupuestoTableAdapter.Fill(this.CarteraGeneralDataSet.rptsegpresupuesto);
                    this.rptsegpresupuestoTableAdapter.Adapter.SelectCommand.CommandText = Scripseguimiento;
                    this.rptsegpresupuestoTableAdapter.Fill(this.CarteraGeneralDataSet.rptsegpresupuesto);
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
