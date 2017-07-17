using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace CarteraGeneral
{
    public partial class FrmCnsGralCredito : Form
    {
        public FrmCnsGralCredito()
        {
            InitializeComponent();
        }
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        ClsVentas clsVentas =new  ClsVentas();
        public string VarIdAdjudicacion;
        System.Data.DataTable DtDatos = new System.Data.DataTable();
        System.Data.DataTable DtCuotas = new System.Data.DataTable();
        System.Data.DataTable DtExtracto = new System.Data.DataTable();
        double SumRcdIni, SumRcdFnc, SumRcdCon, SumRcdTotal, SumRcdExtra;
        double SumMoraIni, SumMoraFnc, SumMoraContado, SumMoraExtra,SumMoraTotal;
        double MaxMoraIni, MaxMoraFnc, MaxMoraExtra, MaxMoraContado,MaxMoraTotal;
        string Estado;
        System.Data.DataTable DtParametros = new System.Data.DataTable();
        string StrInteresCte, StrInteresMora, StrPeriodo, StrDiaMora, StrDecimales;

        private void FrmDesistimiento_Load(object sender, EventArgs e)
        {
            DtParametros = NuevoClsIdentificacion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
            StrInteresCte = DtParametros.Rows[0][0].ToString();
            StrInteresMora = DtParametros.Rows[0][1].ToString();
            StrPeriodo = DtParametros.Rows[0][2].ToString();
            StrDiaMora = DtParametros.Rows[0][3].ToString();
            StrDecimales = DtParametros.Rows[0][5].ToString();
            pictureBox1.Image = FrmMenuGeneral.Logo;
            TxtAdjudicacion.Text = VarIdAdjudicacion;
            DtCuotas = NuevoClsIdentificacion.MtdBuscarDataset("Select S.Concepto,S.NumCuota,S.Fecha,S.UltimaFechaPago,S.SaldoInteres,S.SaldoCapital,S.SaldoCuota,DiasCpt ,(round((((`s`.`DiasLqd` * `s`.`SaldoCuota`) * if((s.Concepto = 'CI' OR Concepto='GA'),0," + StrInteresMora + ")) / 36000)," + StrDecimales + ") + s.SaldoIntMora) AS TotalIntMora from 004saldocuotas s where IdAdjudicacion = " + TxtAdjudicacion.Text + " And saldoCuota>0 order by Fecha");
            DtExtracto = NuevoClsIdentificacion.MtdBuscarDataset(MtdScripExt(TxtAdjudicacion.Text));
            DtDatos =NuevoClsIdentificacion.MtdBuscarDataset( MtdScrip());
            MtdDatos();           
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
           " (SELECT IF(SUM(Capital) is null,0,SUM(Capital))FROM descuento where Idadjudicacion= a.idadjudicacion ) AS SaldoCpt , " +
           " A.TipodeAdjudicacion,A.Temporada,A.Grado " +
           " FROM adjudicacion A  " +
           " JOIN Contabilidad_alttum.Terceros T  " +
           " ON T.IdTercero= A.IdTercero1  WHERE A.idadjudicacion = " + (TxtAdjudicacion.Text);
            return Sentencia;
        }
//===================================================================================================================================================
// F I N   M E T O D O   M E T O D O S C R I P
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O S C R I P
//===================================================================================================================================================
        public string MtdScripExt(string IdAdjudica)
        {
            string Sentencia1 = "";
            Sentencia1 =
            "select  r.Concepto,r.NumCuota,c.Fecha as Vencimiento, C.Cuota as VrCuota, r.Recibo,r.Fecha as FechaPago, r.capital,R.InteresCte,r.Cuota,R.InteresMora " +
            " from (" +
            " Select r.Id, r.Concepto,r.cuotanum as numcuota,r.Recibo,r.Fecha,-(r.capital)capital,-(R.InteresCte) InteresCte ,-(r.cuota)Cuota," +
            " -(R.InteresMora)InteresMora  from 004cnsadjudica A  join 004recaudosdetallados R on " +
            " A.idadjudicacion=r.idadjudicacion where a.idadjudicacion= " + TxtAdjudicacion.Text +
            " )r" +
            " join Financiacion c on c.idcta=r.id order by c.fecha";
            return Sentencia1;
        }
//===================================================================================================================================================
// F I N   M E T O D O   M E T O D O S C R I P
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   M E T O D O   E X P O R T A R   A    E X C E L   E X T R A C T O
//===================================================================================================================================================
        public void MtdExportarExtracto()
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            foreach (DataGridViewColumn col in DgvExtracto.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }

            int rowIndex = 0;

            foreach (DataGridViewRow row in DgvExtracto.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvExtracto.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }

            }

            excel.Visible = true;

            Worksheet Libro = (Worksheet)excel.ActiveSheet;

            //Libro.Activate();

        }
//===================================================================================================================================================
//F I N A L    M E T O D O   E X P O R T A R    A     E X C E L  E X T R A C T O
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O   E X P O R T A R   A    E X C E L   C U O T A S
//===================================================================================================================================================
        public void MtdExportarCuota()
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            foreach (DataGridViewColumn col in DgvCuotas.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }

            int rowIndex = 0;

            foreach (DataGridViewRow row in DgvCuotas.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvCuotas.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }

            }

            excel.Visible = true;

            Worksheet Libro = (Worksheet)excel.ActiveSheet;

            //Libro.Activate();

        }
//===================================================================================================================================================
//F I N A L    M E T O D O   E X P O R T A R    A     E X C E L  C U O T A S
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O  S  
//===================================================================================================================================================
        public void MtdDatos()
        {

            TxtNombre.Text = DtDatos.Rows[0][1].ToString();
            TxtDireccion.Text = DtDatos.Rows[0][2].ToString();
            DtpFEcha.Text = DtDatos.Rows[0][3].ToString();
            DtpFEcha.Text = String.Format("{0:d/M/yyyy}", Convert.ToDateTime(DtpFEcha.Text));
            TxtInmueble.Text = DtDatos.Rows[0][6].ToString();
            TxtFormaPago.Text = DtDatos.Rows[0][8].ToString();
            TxtVenta.Text = DtDatos.Rows[0][9].ToString();
            TxtCtaInicial.Text = DtDatos.Rows[0][10].ToString();
            TxtFinanciacion.Text = DtDatos.Rows[0][12].ToString();
            TxtExtraordinaria.Text = DtDatos.Rows[0][13].ToString();
            TxtContado.Text = DtDatos.Rows[0][11].ToString();
            TxtTipo.Text = DtDatos.Rows[0][30].ToString();
            TxtTemporada.Text = DtDatos.Rows[0][31].ToString();

            DgvCuotas.Rows.Clear();

            for (int i = 0; i < (DtCuotas.Rows.Count); i++)
            {
                DgvCuotas.Rows.Add(DtCuotas.Rows[i][0], DtCuotas.Rows[i][1], DtCuotas.Rows[i][2], DtCuotas.Rows[i][3], DtCuotas.Rows[i][4],
                DtCuotas.Rows[i][5], DtCuotas.Rows[i][6], DtCuotas.Rows[i][7], DtCuotas.Rows[i][8]);
            }
                       


            SumMoraContado = 0;
            SumMoraExtra = 0;
            SumMoraFnc = 0;
            SumMoraIni = 0;
            MaxMoraContado = 0;
            MaxMoraExtra = 0;
            MaxMoraFnc = 0;
            MaxMoraFnc = 0;
            MaxMoraTotal = 0;

           
            for (int f = 0; f < (DgvCuotas.Rows.Count); f++)
            {
                if ((Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value)) > MaxMoraTotal)
                {
                    MaxMoraTotal = Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value);
                }


                SumMoraTotal += (Convert.ToDouble(DgvCuotas.Rows[f].Cells[8].Value));

                if (Convert.ToString(DgvCuotas.Rows[f].Cells[0].Value) == "CI")
                {
                    SumMoraIni += (Convert.ToDouble(DgvCuotas.Rows[f].Cells[8].Value));

                    if ((Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value)) > MaxMoraIni)

                    { 
                        MaxMoraIni =Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value);
                    }
                }


                if (Convert.ToString(DgvCuotas.Rows[f].Cells[0].Value) == "FN")
                {
                    SumMoraFnc += (Convert.ToDouble(DgvCuotas.Rows[f].Cells[8].Value));

                    if ((Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value)) > MaxMoraFnc)
                    {
                        MaxMoraFnc = Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value);
                    }
                }

                if (Convert.ToString(DgvCuotas.Rows[f].Cells[0].Value) == "CE")
                {
                    SumMoraExtra += (Convert.ToDouble(DgvCuotas.Rows[f].Cells[8].Value));
                    if ((Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value)) > MaxMoraExtra)
                    {
                        MaxMoraExtra = Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value);
                    }
                }

                if (Convert.ToString(DgvCuotas.Rows[f].Cells[0].Value) == "CO")
                {
                    SumMoraContado += (Convert.ToDouble(DgvCuotas.Rows[f].Cells[8].Value));
                    if ((Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value)) > MaxMoraContado)
                    {
                        MaxMoraContado = Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value);
                    }
                }

            }
            DgvExtracto.Rows.Clear();

            for (int i = 0; i < (DtExtracto.Rows.Count); i++)
            {
                DgvExtracto.Rows.Add(DtExtracto.Rows[i][0], DtExtracto.Rows[i][1], DtExtracto.Rows[i][2], DtExtracto.Rows[i][3], DtExtracto.Rows[i][4],
                DtExtracto.Rows[i][5], DtExtracto.Rows[i][6], DtExtracto.Rows[i][7], DtExtracto.Rows[i][8], DtExtracto.Rows[i][9]);
            }


            
            
            SumRcdIni = 0;
            SumRcdFnc = 0;
            SumRcdExtra = 0;
            SumRcdTotal = 0;
            SumRcdCon = 0;

            for (int i = 0; i < (DgvExtracto.Rows.Count); i++)
            {
                SumRcdTotal += (Convert.ToDouble(DgvExtracto.Rows[i].Cells[6].Value));

                if (i == 0)
                {
                    DgvExtracto.Rows[i].Cells[10].Value = Convert.ToDouble(TxtVenta.Text) - Convert.ToDouble(DgvExtracto.Rows[i].Cells[6].Value);
                }
                else
                {
                    DgvExtracto.Rows[i].Cells[10].Value = Convert.ToDouble(DgvExtracto.Rows[i - 1].Cells[10].Value) - Convert.ToDouble(DgvExtracto.Rows[i].Cells[6].Value);
                }


                if (Convert.ToString(DgvExtracto.Rows[i].Cells[0].Value) == "CI")
                {
                    SumRcdIni += (Convert.ToDouble(DgvExtracto.Rows[i].Cells[6].Value));
                }


                if (Convert.ToString(DgvExtracto.Rows[i].Cells[0].Value) == "FN")
                {
                    SumRcdFnc += (Convert.ToDouble(DgvExtracto.Rows[i].Cells[6].Value));
                }

                if (Convert.ToString(DgvExtracto.Rows[i].Cells[0].Value) == "CE")
                {
                    SumRcdExtra += (Convert.ToDouble(DgvExtracto.Rows[i].Cells[6].Value));
                }

                if (Convert.ToString(DgvExtracto.Rows[i].Cells[0].Value) == "CO")
                {
                    SumRcdCon += (Convert.ToDouble(DgvExtracto.Rows[i].Cells[6].Value));
                }

            }

            TxtRcdIni.Text = Convert.ToString(SumRcdIni);
            TxtRecaudoContado.Text = Convert.ToString(SumRcdCon);
            TxtRcdFnc.Text = Convert.ToString(SumRcdFnc);
            TxtRcdExtra.Text = Convert.ToString(SumRcdExtra);
            TxtRcdTotal.Text = Convert.ToString(SumRcdTotal);
            TxtSdoCtaIni.Text = Convert.ToString((Convert.ToDouble(TxtCtaInicial.Text) - Convert.ToDouble(TxtRcdIni.Text)));
            TxtSdoCtaFnc.Text = Convert.ToString((Convert.ToDouble(TxtFinanciacion.Text) - Convert.ToDouble(TxtRcdFnc.Text)));
            TxtSdoCtaExt.Text = Convert.ToString((Convert.ToDouble(TxtExtraordinaria.Text) - Convert.ToDouble(TxtRcdExtra.Text)));
            TxtSaldoContado.Text = Convert.ToString(Convert.ToDouble(TxtContado.Text) - Convert.ToDouble(TxtRecaudoContado.Text));
            TxtSaldoTotal.Text = Convert.ToString(Convert.ToDouble(TxtVenta.Text) - Convert.ToDouble(TxtRcdTotal.Text));
            TxtMoraCon.Text = Convert.ToString(SumMoraContado);
            TxtMoraExtra.Text = Convert.ToString(SumMoraExtra);
            TxtMoraFnc.Text = Convert.ToString(SumMoraFnc);
            TxtMoraIni.Text = Convert.ToString(SumMoraIni);
            TxtMoraVenta.Text = Convert.ToString(SumMoraTotal);
            TxtDiasMoraCon.Text = Convert.ToString(MaxMoraContado);
            TxtDiasMoraExtra.Text = Convert.ToString(MaxMoraExtra);
            TxtDiasMoraFnc.Text = Convert.ToString(MaxMoraFnc);
            TxtDiasMoraIni.Text = Convert.ToString(MaxMoraIni);
            TxtDiasMotaVenta.Text = Convert.ToString(MaxMoraTotal);



            this.TxtVenta.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtVenta.Text));
            this.TxtCtaInicial.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtCtaInicial.Text));
            this.TxtContado.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtContado.Text));
            this.TxtFinanciacion.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtFinanciacion.Text));
            this.TxtExtraordinaria.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtExtraordinaria.Text));

            this.TxtRcdIni.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtRcdIni.Text));
            this.TxtRecaudoContado.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtRecaudoContado.Text));
            this.TxtRcdFnc.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtRcdFnc.Text));
            this.TxtRcdExtra.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtRcdExtra.Text));
            this.TxtRcdTotal.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtRcdTotal.Text));

            this.TxtSdoCtaIni.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtSdoCtaIni.Text));
            this.TxtSaldoContado.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtSaldoContado.Text));
            this.TxtSdoCtaFnc.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtSdoCtaFnc.Text));
            this.TxtSdoCtaExt.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtSdoCtaExt.Text));
            this.TxtSaldoTotal.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtSaldoTotal.Text));

            this.TxtMoraCon.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtMoraCon.Text));
            this.TxtMoraExtra.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtMoraExtra.Text));
            this.TxtMoraFnc.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtMoraFnc.Text));
            this.TxtMoraIni.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtMoraIni.Text));
            this.TxtMoraVenta.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtMoraVenta.Text));         

        }
//===================================================================================================================================================
// F I N   M E T O D O   D A T O  S  
//===================================================================================================================================================



        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnExportarExtracto_Click(object sender, EventArgs e)
        {
            MtdExportarExtracto();
        }

        private void BtnExportarCuotas_Click(object sender, EventArgs e)
        {
            MtdExportarCuota();
        }


        private void DgvExtracto_Sorted(object sender, EventArgs e)
        {
            MtdDatos();
        }


    }
}
