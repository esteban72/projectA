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
    public partial class FrmExtracto : Form
    {
        public FrmExtracto()
        {
            InitializeComponent();
        }
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        DataTable DtParametros = new DataTable();
        string StrInteresCte,StrInteresMora,StrPeriodo,StrDiaMora,StrDecimales;
        public string Opciones,VarCliente,VarIdAdjudicacion;
        private void FrmExtracto_Load(object sender, EventArgs e)
        {
            DtParametros = NuevoClsIdentificacion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
            StrInteresCte = DtParametros.Rows[0][0].ToString();
            StrInteresMora = DtParametros.Rows[0][1].ToString();
            StrPeriodo = DtParametros.Rows[0][2].ToString();
            StrDiaMora = DtParametros.Rows[0][3].ToString();
            StrDecimales = DtParametros.Rows[0][5].ToString();
            this.rpt004sadlocarteraTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
            this.rpt004diasmorasTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;

            this.rpt004sadlocarteraTableAdapter.Fill(this.CarteraGeneralDataSet.rpt004sadlocartera);          
            this.rpt004diasmorasTableAdapter.Fill(this.CarteraGeneralDataSet.rpt004diasmoras);

            this.reportViewer1.RefreshReport();  

            TxtAdjudicacion.Focus();
            if (Opciones == "Automatico")
            {
                TxtAdjudicacion.Text = VarIdAdjudicacion;
                TxtClinte.Text = VarCliente;
                TxtClinte.Text = VarCliente;
                 MtdGenerarExt();
            }
        }



//===================================================================================================================================================
// I N I C I O   M E T O D O S C R I P
//===================================================================================================================================================
        public string MtdScrip()
        {
            string Sentencia = "  SELECT    " +
          "  A.Idadjudicacion," +
          " T.nombreCompleto Nombres," +
          " T.Direccion,         " +
          " A.Fecha, " +
          "  A.Contrato," +
          "  A.IdProyecto, " +
          "  A.IdInmueble,   " +
           " T.Telefono1," +
           " A.FormaPago, " +
           " A.Valor, " +
           " (select if( SUM(Capital)is null,0,SUM(Capital)) from Financiacion where concepto='CI' AND IdAdjudicacion=a.idadjudicacion)Inicial ,  " +
           " (select if( SUM(Capital)is null,0,SUM(Capital)) from Financiacion where concepto='CO' AND  IdAdjudicacion=a.idadjudicacion)Contado ,  " +
           "   (select if( SUM(Capital)is null,0,SUM(Capital)) from Financiacion where concepto='FN' AND  IdAdjudicacion=a.idadjudicacion)Financiacion ,  " +
           " (select if( SUM(Capital)is null,0,SUM(Capital)) from Financiacion where concepto='CE' AND  IdAdjudicacion=a.idadjudicacion)Extra , " +
           " A.PlazoFnc, " +
           " A.TasaFnc, " +
           " A.CuotaFnc, " +
           " A.InicioFnc, " +
           " A.PlazoExtra, " +
           " A.TasaExtra, " +
           " A.CuotaExtra, " +
           " A.InicioExtra, " +
           " (SELECT IF(SUM(Capital) is null,0,SUM(-Capital))FROM 004recaudosresumidos where Idadjudicacion= a.idadjudicacion   AND Concepto='CI')AS RecaudoIni,             " +

           " (SELECT IF(SUM(Capital) is null,0,SUM(-Capital))FROM 004recaudosresumidos where Idadjudicacion= a.idadjudicacion  AND Concepto='FN')AS RecaudoFnc, " +
           " (SELECT IF(SUM(Capital) is null,0,SUM(-Capital))FROM 004recaudosresumidos where Idadjudicacion= a.idadjudicacion AND Concepto='CE')AS RecaudoExt,  " +
           " (SELECT IF(SUM(Capital) is null,0,SUM(-Capital))FROM 004recaudosresumidos where Idadjudicacion= a.idadjudicacion AND Concepto='CO')AS RecaudoCon,    " +
           " (SELECT IF(SUM(Capital) is null,0,SUM(-Capital))FROM descuento where Idadjudicacion= a.idadjudicacion )AS Descuento,  " +
           " (SELECT IF(SUM(Capital) is null,0,SUM(-Capital))FROM 004recaudosresumidos where   Idadjudicacion= a.idadjudicacion)AS RecaudoTot, " +
           " (SELECT IF(SUM(Capital+InteresCte+InteresMora) is null,0,SUM(Capital+InteresCte+InteresMora))FROM recaudos where Idadjudicacion= a.idadjudicacion And Estado ='Pendiente')AS Canje, " +
           " A.Valor-(SELECT IF(SUM(Capital) is null,0,SUM(-Capital))FROM 004recaudosresumidos where  Idadjudicacion=  a.idadjudicacion AND Concepto<>'GA')-            " +
           " (SELECT IF(SUM(Capital) is null,0,SUM(Capital))FROM descuento where Idadjudicacion= a.idadjudicacion ) AS SaldoCpt  " +
           " FROM adjudicacion A  " +
           " JOIN Contabilidad_alttum.Terceros T  " +
           " ON T.IdTercero= A.IdTercero1  WHERE A.idadjudicacion = " + (TxtAdjudicacion.Text);
            return Sentencia;
        }
//===================================================================================================================================================
// F I N   M E T O D O   M E T O D O S C R I P
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   D E T A L L A D O
//===================================================================================================================================================
        private string MtdDetallado()
        {
            string Sentencia =

       " Select IdAdjudicacion,Concepto,Numcuota as CuotaNum,Fecha,Capital,Interes as Interescte,Cuota,"+
       " UltimaFechaPago as FechaUltPago,RcdCapital,RcdInteres as RcdInteresCte,RcdCuota,MoraCalc,SaldoCapital as SdoCapital,"+
       " SaldoInteres as SdoInteresCte,SaldoCuota as SdoCuota,SaldoIntMora as IntMoraPdte,"+
       "if(SaldoCuota=0,0, DiasLqd) as DiasMoralq, if(SaldoCuota=0,0,DiasCpt) as DiasMoraCpt,"+
       " if((Concepto='CI'or Concepto='GA'),0 ,Round((SaldoCuota*24*DiasLqd/36000),2)+ SaldoIntMora) VrMora," +
       " InteresCnd as Condonacion,"+
       " IF ((Concepto='CI'or Concepto='GA'),0,Round((SaldoCuota*24*DiasLqd/36000),2)+ SaldoIntMora+SaldoCapital) as TotalCuota" +
       " from 004saldocuotas Where IdAdjudicacion = " + TxtAdjudicacion.Text + 
       "  and Fecha <='" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "'";
            return Sentencia;
        }
//===================================================================================================================================================
// F I N   M E T O D O   D E T A L L A D  O
//===================================================================================================================================================

        

        //===================================================================================================================================================
        // I N I C I O   M E T O D O D E T A L L A D O
        //===================================================================================================================================================
        private void MtdGenerarExt()
        {
            this.rpt004diasmorasTableAdapter.Adapter.SelectCommand.CommandText = MtdDetallado();
            this.rpt004diasmorasTableAdapter.Fill(this.CarteraGeneralDataSet.rpt004diasmoras);

            this.rpt004sadlocarteraTableAdapter.Adapter.SelectCommand.CommandText = MtdScrip();
            this.rpt004sadlocarteraTableAdapter.Fill(this.CarteraGeneralDataSet.rpt004sadlocartera);
            this.reportViewer1.RefreshReport();
        }
        //===================================================================================================================================================
        // F I N   M E T O D O   M E T O D O D E T A L L A D  O
        //===================================================================================================================================================


        private void TxtAdjudicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

                double Contar = Convert.ToDouble(NuevoClsIdentificacion.MtdBscDatos("select count(identificacion) from 004cnsadjudica where IdAdjudicacion = " +
                   ( TxtAdjudicacion.Text) ));

                if (Contar == 0)
                {
                    MessageBox.Show("No Existe Adjudicacion");
                    TxtAdjudicacion.Clear();
                }
                else
                {

                    TxtClinte.Text = NuevoClsIdentificacion.MtdBscDatos("Select Identificacion From 004cnsadjudica WHERE IdAdjudicacion = " + ( TxtAdjudicacion.Text));
                    DtpFecha.Focus();
                }
            }

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        //private void TxtAdjudicacion_Leave(object sender, EventArgs e)
        //{
        //    if (TxtAdjudicacion.Text != "")
        //    {

        //        double Contar = Convert.ToDouble(NuevoClsIdentificacion.MtdBscDatos("select count(identificacion) from 004cnsadjudica where IdAdjudicacion = '" +
        //           ("Adj" + TxtAdjudicacion.Text) + "'"));

        //        if (Contar == 0)
        //        {
        //            MessageBox.Show("No Existe Adjudicacion");
        //            TxtAdjudicacion.Clear();
        //        }
        //        else
        //        {
        //            TxtClinte.Text = NuevoClsIdentificacion.MtdBscDatos("Select Identificacion From 004cnsadjudica WHERE IdAdjudicacion = '" + ("Adj" + TxtAdjudicacion.Text) + "'");
        //            DtpFecha.Focus();
        //        }


        //    }
        //}

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            this.rpt004diasmorasTableAdapter.Adapter.SelectCommand.CommandText = MtdDetallado();
            this.rpt004diasmorasTableAdapter.Fill(this.CarteraGeneralDataSet.rpt004diasmoras);

            this.rpt004sadlocarteraTableAdapter.Adapter.SelectCommand.CommandText = MtdScrip();
            this.rpt004sadlocarteraTableAdapter.Fill(this.CarteraGeneralDataSet.rpt004sadlocartera);
            this.reportViewer1.RefreshReport();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }











    }





}
