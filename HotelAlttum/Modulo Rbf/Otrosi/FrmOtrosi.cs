using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;

namespace CarteraGeneral
{
    public partial class FrmOtrosi : Form
    {
        public FrmOtrosi()
        {
            InitializeComponent();
        }

        #region REGION DE VARIABLES
        public string  EntradaOtrosi;
        decimal CuentaErrores;
        List<string> DatosdeErrores = new List<string>();
        ClsIdentificacion conexion = new ClsIdentificacion();
        ClsVentas clsVentas = new ClsVentas();
        public string VarIdAdjudicacion,VarIdOtrosi;
        System.Data.DataTable DtDatos = new System.Data.DataTable();
        System.Data.DataTable DtCuotas = new System.Data.DataTable();
        System.Data.DataTable DtExtracto = new System.Data.DataTable();
        System.Data.DataTable DtFinanciacion = new System.Data.DataTable();
        System.Data.DataTable DtSdoFinanciacion = new System.Data.DataTable();
        decimal Diferencia, ValidacionCapital, SumValorInicial, SumValorContado;
        double SumRcdIni, SumRcdFnc, SumRcdCon, SumRcdTotal, SumRcdExtra;
        double SumMoraIni, SumMoraFnc, SumMoraContado, SumMoraExtra, SumMoraTotal;
        double MaxMoraIni, MaxMoraFnc, MaxMoraExtra, MaxMoraContado, MaxMoraTotal;
        string Estado;
        System.Data.DataTable DtParametros = new System.Data.DataTable();
        string StrInteresCte, StrInteresMora, StrPeriodo, StrDiaMora, StrDecimales;


        #endregion



        private void FrmOtrosi_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            DtParametros = conexion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
            switch (EntradaOtrosi)
            {
                case "Adicionar":
                     MtdLoadAdd();
                     MtdDatosSaldos();
                     MtdTotal();
                     MtdDiferencia(); 
                     TxtTasaExtra.Text = StrInteresCte;
                    TxtTasaFnc.Text = StrInteresCte;
                    Text = "ADICIONAR OTROSI";
                    break;


                case "Modificar":
                     LblTitulo.Text = "MODIFICAR OTROSI";
                Text = "MODIFICAR OTROSI";
                     MtdLoadAdd();
                     MtdDatosSaldosOtrosi();
                     MtdTotal();  
                    break;

                case "Eliminar":
                    LblTitulo.Text = "ELIMINAR OTROSI";
                    Text = "ELIMINAR OTROSI";
                    MtdLoadAdd();
                    MtdDatosSaldosOtrosi();
                    MtdTotal();                    
                    ChbFnc.Visible = false;
                    ChbContado.Visible = false;
                    ChbCuotaInicial.Visible = false;
                    ChbExtra.Visible = false;
                    BtnValidar.Visible = false;
                    BtnOk.Enabled = true;
                    break;


                case "Aprobar":
                    LblTitulo.Text = "APROBAR OTROSI";
                    Text = "APROBAR OTROSI";
                     MtdLoadAdd();
                     MtdDatosSaldosOtrosi();
                     MtdTotal();
                     BtnOk.Enabled = true;
                    ChbFnc.Visible = false;
                    ChbContado.Visible = false;
                    ChbCuotaInicial.Visible = false;
                    ChbExtra.Visible = false;
                    BtnValidar.Visible = false;
                    break;


                case "Consultar":
                LblTitulo.Text = "CONSULTAR OTROSI";
                Text = "CONSULTAR OTROSI";
                MtdLoadAdd();
               MtdDatosSaldosOtrosi();
                MtdTotal();                   
                ChbFnc.Visible = false;
                ChbContado.Visible = false;
                ChbCuotaInicial.Visible = false;
                ChbExtra.Visible = false;
                BtnValidar.Visible = false;
                BtnOk.Visible = false;
                    break;


                default:

                    break;
            }
        }

        
        private void  MtdLoadAdd()

        {
            DtFinanciacion = conexion.MtdBuscarDataset("Select Concepto,NumCuota,Fecha,Capital,Interes,Cuota From Financiacion Where Concepto !='GA' AND IdAdjudicacion=" + VarIdAdjudicacion);
           
            StrInteresCte = DtParametros.Rows[0][0].ToString();
            StrInteresMora = DtParametros.Rows[0][1].ToString();
            StrPeriodo = DtParametros.Rows[0][2].ToString();
            StrDiaMora = DtParametros.Rows[0][3].ToString();
            StrDecimales = DtParametros.Rows[0][5].ToString();
            //pictureBox1.Image = FrmMenuGeneral.Logo;
            TxtAdjudicacion.Text = VarIdAdjudicacion;
            DtCuotas = conexion.MtdBuscarDataset("Select S.Concepto,S.NumCuota,S.Fecha,S.UltimaFechaPago,S.SaldoCapital,S.SaldoInteres,S.SaldoCuota,DiasCpt ,(round((((`s`.`DiasLqd` * `s`.`SaldoCuota`) * if((s.Concepto = 'CI' OR Concepto='GA'),0," + StrInteresMora + ")) / 36000)," + StrDecimales + ") + s.SaldoIntMora) AS TotalIntMora from 004saldocuotas s where IdAdjudicacion = " + TxtAdjudicacion.Text + " And saldoCuota>0 order by Fecha");
            DtExtracto = conexion.MtdBuscarDataset(MtdScripExt(TxtAdjudicacion.Text));
            DtDatos = conexion.MtdBuscarDataset(MtdScrip());
            MtdDatos();                   
        
        }
       


        #region REGION DE EVENTOS

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
            " A.idadjudicacion=r.idadjudicacion where r.Concepto!='GA' AND a.idadjudicacion= " + TxtAdjudicacion.Text +
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
//I N I C I O   M E T O D O   E X P O R T A R   A    E X C E L  MtdExportarFnc
//===================================================================================================================================================
        public void MtdExportarFnc()
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            foreach (DataGridViewColumn col in DgvFinanciacion.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }
            
            int rowIndex = 0;

            foreach (DataGridViewRow row in DgvFinanciacion.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvFinanciacion.Columns)
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
//F I N A L    M E T O D O   E X P O R T A R    A     E X C E L  MtdExportarFnc
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O  S  
//===================================================================================================================================================
        public void MtdDatos()
        {

           

            DgvTodaFnc.Rows.Clear();
            for (int i = 0; i < (DtFinanciacion.Rows.Count); i++)
            {
                DgvTodaFnc.Rows.Add(DtFinanciacion.Rows[i][0], DtFinanciacion.Rows[i][1], DtFinanciacion.Rows[i][2], DtFinanciacion.Rows[i][3], DtFinanciacion.Rows[i][4], DtFinanciacion.Rows[i][5]);

            }

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
                        MaxMoraIni = Convert.ToDouble(DgvCuotas.Rows[f].Cells[7].Value);
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



            this.TxtVenta.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtVenta.Text));
            this.TxtCtaInicial.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtCtaInicial.Text));
            this.TxtContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtContado.Text));
            this.TxtFinanciacion.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtFinanciacion.Text));
            this.TxtExtraordinaria.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtExtraordinaria.Text));

            this.TxtRcdIni.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtRcdIni.Text));
            this.TxtRecaudoContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtRecaudoContado.Text));
            this.TxtRcdFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtRcdFnc.Text));
            this.TxtRcdExtra.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtRcdExtra.Text));
            this.TxtRcdTotal.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtRcdTotal.Text));

            this.TxtSdoCtaIni.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSdoCtaIni.Text));
            this.TxtSaldoContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSaldoContado.Text));
            this.TxtSdoCtaFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSdoCtaFnc.Text));
            this.TxtSdoCtaExt.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSdoCtaExt.Text));
            this.TxtSaldoTotal.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSaldoTotal.Text));


            TxtNuevoVrVenta.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtVenta.Text));
            TxtRcdTotalOtrosi.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtRcdTotal.Text));
            TxtNuevoSaldo.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSaldoTotal.Text));
            
            

            this.TxtMoraCon.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtMoraCon.Text));
            this.TxtMoraExtra.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtMoraExtra.Text));
            this.TxtMoraFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtMoraFnc.Text));
            this.TxtMoraIni.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtMoraIni.Text));
            this.TxtMoraVenta.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtMoraVenta.Text));

           
            
        }
//===================================================================================================================================================
// F I N   M E T O D O   D A T O  S  
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   C U O T A S
//===================================================================================================================================================
        public System.Data.DataTable MtdCuotas(double tasaInteres, int plazo, double capital, int periodo, DateTime fechaInicio)
        {
            double CuotaFijaCalculada;

            if (tasaInteres > 0)
            {
                double a, b, x;

                a = (1 + tasaInteres / (periodo * 100));
                b = plazo;
                x = Math.Pow(a, b);
                x = 1 / x;
                x = 1 - x;
                CuotaFijaCalculada = Math.Round(((capital) * (tasaInteres / (periodo * 100)) / x), 0);
            }

            else
            {
                CuotaFijaCalculada = Math.Round((capital / plazo), 2);
            }

            double CapitalCuota, InteresCuota, SaldoCuota, CuotaCuota;
            DateTime Fecha;
            SaldoCuota = capital;

            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("Mes", typeof(DateTime));
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Valor", typeof(double));
            table.Columns.Add("Capital", typeof(double));
            table.Columns.Add("Interes", typeof(double));
            table.Columns.Add("Saldo", typeof(double));
            for (int i = 1; i < plazo + 1; i++)
            {
                Fecha = fechaInicio.AddMonths(12 / periodo * (i - 1));
                InteresCuota = Math.Round(((SaldoCuota * (12 / periodo * 30) * tasaInteres) / 36000), Convert.ToInt16(StrDecimales));
                CapitalCuota = Math.Round((CuotaFijaCalculada - InteresCuota), 0);


                if (i == plazo)
                {
                    CuotaCuota = Math.Round((SaldoCuota + InteresCuota), Convert.ToInt16(StrDecimales));
                    table.Rows.Add(Fecha, i, CuotaCuota, SaldoCuota, InteresCuota, SaldoCuota);
                    SaldoCuota = 0;
                }
                else
                {
                    CuotaCuota = Math.Round((CapitalCuota + InteresCuota), Convert.ToInt16(StrDecimales));
                    SaldoCuota = Math.Round((SaldoCuota - CapitalCuota), Convert.ToInt16(StrDecimales));
                    table.Rows.Add(Fecha, i, CuotaCuota, CapitalCuota, InteresCuota, SaldoCuota);
                }
            }

            return table;
        }
//===================================================================================================================================================
//F I N A L    M E T O D O   C U O T A S
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdCalculoCuota
//===================================================================================================================================================
        public string MtdCalculoCuota(double capital, double tasaInteres, double periodo, double plazo)
        {
            double CuotaFijaCalculada;
            periodo = (30 / periodo) * 12;
            if (tasaInteres > 0)
            {

                double a, b, x;

                a = (1 + tasaInteres / (periodo * 100));
                b = plazo;
                x = Math.Pow(a, b);
                x = 1 / x;
                x = 1 - x;
                CuotaFijaCalculada = (capital) * (tasaInteres / (periodo * 100)) / x;

            }
            else
            {
                CuotaFijaCalculada = Math.Round((capital / plazo), Convert.ToInt16(StrDecimales));

            }
            return Convert.ToString(Math.Round(CuotaFijaCalculada, Convert.ToInt16(StrDecimales)));
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdCalculoCuota
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdCalculoCuotaFnc
//===================================================================================================================================================
        private void MtdCalculoCuotaFnc()
        {
            TxtCuotaFncOtrosi.Text = MtdCalculoCuota(Convert.ToDouble(TxtCapitalFnc.Text), Convert.ToDouble(TxtTasaFnc.Text),
            Convert.ToDouble(CmbPeriodoFnc.Text), Convert.ToDouble(TxtNumCuotasFnc.Text));
            this.TxtCuotaFncOtrosi.Text = String.Format("{0:#,##0.00; -$#,##0.00 ;0.00}", decimal.Parse(this.TxtCuotaFncOtrosi.Text));
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdCalculoCuotaFnc
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdCalculoCuotaExtra
//===================================================================================================================================================
        private void MtdCalculoCuotaExtra()
        {
            TxtCuotaExtraOtrosi.Text = MtdCalculoCuota(Convert.ToDouble(TxtCapitalExtra.Text), Convert.ToDouble(TxtTasaExtra.Text),
                    Convert.ToDouble(CmbPeriodoExtra.Text), Convert.ToDouble(TxtNumCuotasExtra.Text));
            this.TxtCuotaExtraOtrosi.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtCuotaExtraOtrosi.Text));
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdCalculoCuotaExtra
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O   M E T O D O  MtdoDatosCredito
//=================================================================================================================================================== 
        private void MtdoDatosCredito()
        {
            System.Data.DataTable credito = new System.Data.DataTable();
            int CTAFN = Convert.ToInt16(TxtUltCuotaFnc.Text);
            if (ChbFnc.Checked == true)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = conexion.MtdBuscarDataset("select concepto,numcuota,fecha,(capital-SaldoCapital)Capital,(Interes-SaldoInteres)Interes,(Cuota-SaldoCuota)Cuota," +
                " 0 SaldoCapital,0 SaldoInteres,0 SaldoCuota from financiacion Where Concepto ='FN' And IdAdjudicacion =" + VarIdAdjudicacion + " And NumCuota <= " +
                Convert.ToInt16(TxtUltCuotaFnc.Text));
               
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    DgvFinanciacion.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7], dt.Rows[i][8]);
                }

                credito = MtdCuotas(Convert.ToDouble(TxtTasaFnc.Text), Convert.ToInt16(TxtNumCuotasFnc.Text), Convert.ToDouble(TxtCapitalFnc.Text), 
                Convert.ToInt16(30 / Convert.ToDouble(CmbPeriodoFnc.Text) * 12), DtpInicioFnc.Value);
                for (int i = 0; i < (credito.Rows.Count); i++)
                {
                    CTAFN = CTAFN + 1;
                    DgvFinanciacion.Rows.Add("FN", CTAFN, credito.Rows[i][0], credito.Rows[i][3], credito.Rows[i][4], credito.Rows[i][2], credito.Rows[i][3], credito.Rows[i][4], credito.Rows[i][2]);
                }
            }
            else
            {
                credito = conexion.MtdBuscarDataset(
              " select Concepto,NumCuota,Fecha,Capital,Interes,Cuota," +
               " Capital-(Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoCapital," +
              " Interes-(Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoInteresCte," +
              " Cuota-((Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta) -" +
              " (Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta) )SaldoCuota " +
              " From " +
              " financiacion f " +
              " Where  Concepto ='FN'   and IdAdjudicacion=" + VarIdAdjudicacion);
                for (int i = 0; i < (credito.Rows.Count); i++)
                {

                    DgvFinanciacion.Rows.Add(credito.Rows[i][0], credito.Rows[i][1], credito.Rows[i][2], credito.Rows[i][3], credito.Rows[i][4], credito.Rows[i][5],
                    credito.Rows[i][6],credito.Rows[i][7],credito.Rows[i][8]);
                }
            }          

        
           
            
        }
//===================================================================================================================================================
//F I N A L    M E T O D O   MtdoDatosCredito
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O  MtdoDatosExtraordinario
//=================================================================================================================================================== 
        private void MtdoDatosExtraordinario()
        {
            System.Data.DataTable Extraordinario = new System.Data.DataTable();
            int CTACE = Convert.ToInt16(TxtUltCuotaExtra.Text);
            if (ChbExtra.Checked == true)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = conexion.MtdBuscarDataset("select concepto,numcuota,fecha,(capital-SaldoCapital)Capital,(Interes-SaldoInteres)Interes,(Cuota-SaldoCuota)Cuota," +
                " 0 SaldoCapital,0 SaldoInteres,0 SaldoCuota from financiacion Where Concepto ='CE' And IdAdjudicacion =" + VarIdAdjudicacion + " And NumCuota <= " +
                Convert.ToInt16(TxtUltCuotaFnc.Text));

                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    DgvFinanciacion.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7], dt.Rows[i][8]);
                }
                Extraordinario = MtdCuotas(Convert.ToDouble(TxtTasaExtra.Text), Convert.ToInt16(TxtNumCuotasExtra.Text), Convert.ToDouble(TxtCapitalExtra.Text),
                Convert.ToInt16(30 / Convert.ToDouble(CmbPeriodoExtra.Text) * 12), DtpInicioExtra.Value);
                for (int i = 0; i < (Extraordinario.Rows.Count); i++)
                {
                    CTACE = CTACE + 1;
                    DgvFinanciacion.Rows.Add("CE", CTACE, Extraordinario.Rows[i][0], Extraordinario.Rows[i][3], Extraordinario.Rows[i][4], Extraordinario.Rows[i][2], Extraordinario.Rows[i][3], Extraordinario.Rows[i][4], Extraordinario.Rows[i][2]);
                }  
            }
            else
            {
                Extraordinario = conexion.MtdBuscarDataset(
              " select Concepto,NumCuota,Fecha,Capital,Interes,Cuota," +
               " Capital-(Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoCapital," +
              " Interes-(Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoInteresCte," +
              " Cuota-((Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta) -" +
              " (Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta) )SaldoCuota " +
              " From " +
              " financiacion f " +
              " Where  Concepto ='CE'   and IdAdjudicacion=" + VarIdAdjudicacion);

                for (int i = 0; i < (Extraordinario.Rows.Count); i++)
                {
                    DgvFinanciacion.Rows.Add(Extraordinario.Rows[i][0], Extraordinario.Rows[i][1], Extraordinario.Rows[i][2], Extraordinario.Rows[i][3], Extraordinario.Rows[i][4],
                    Extraordinario.Rows[i][5], Extraordinario.Rows[i][6], Extraordinario.Rows[i][7], Extraordinario.Rows[i][8]);
                }
            }           

                    
        }
//===================================================================================================================================================
//F I N A L    M E T O D O   MtdoDatosExtraordinario
//===================================================================================================================================================


//===================================================================================================================================================
        // I N I C I O   M E T O D O  MtdoDatosInicial
//===================================================================================================================================================
        private void MtdoDatosInicial()
        {
            System.Data.DataTable dtcuotainicial = new System.Data.DataTable();
            if (ChbCuotaInicial.Checked == true)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = conexion.MtdBuscarDataset("select concepto,numcuota,fecha,(capital-SaldoCapital)Capital,(Interes-SaldoInteres)Interes,(Cuota-SaldoCuota)Cuota," +
                " 0 SaldoCapital,0 SaldoInteres,0 SaldoCuota from financiacion Where Concepto ='CI' And IdAdjudicacion =" + VarIdAdjudicacion + " And NumCuota <= " +
                Convert.ToInt16(TxtUltCuotaIni.Text));
                int CTAIN = Convert.ToInt16(TxtUltCuotaIni.Text);
                DateTime FechaIni;
                decimal CapitalIni = 0;

                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    DgvFinanciacion.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7], dt.Rows[i][8]);
                }

                for (int i = 0; i < (DgvCtaInicial.Rows.Count - 1); i++)
                {
                    CTAIN = CTAIN + 1;
                    FechaIni = Convert.ToDateTime((Convert.ToString(DgvCtaInicial.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[2].Value)));
                    CapitalIni = Convert.ToDecimal(DgvCtaInicial.Rows[i].Cells[3].Value);
                    DgvFinanciacion.Rows.Add("CI", CTAIN, FechaIni, CapitalIni, 0, CapitalIni, CapitalIni, 0, CapitalIni);
                }
            }
            else
            { 
             dtcuotainicial = conexion.MtdBuscarDataset(
              " select Concepto,NumCuota,Fecha,Capital,Interes,Cuota," +
               " Capital-(Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoCapital," +
              " Interes-(Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoInteresCte," +
              " Cuota-((Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta) -" +
              " (Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta) )SaldoCuota " +
              " From " +
              " financiacion f " +
              " Where  Concepto ='CI'   and IdAdjudicacion=" + VarIdAdjudicacion);

                for (int i = 0; i < (dtcuotainicial.Rows.Count); i++)
                {
                    DgvFinanciacion.Rows.Add(dtcuotainicial.Rows[i][0], dtcuotainicial.Rows[i][1], dtcuotainicial.Rows[i][2], dtcuotainicial.Rows[i][3], dtcuotainicial.Rows[i][4],
                    dtcuotainicial.Rows[i][5], dtcuotainicial.Rows[i][6], dtcuotainicial.Rows[i][7], dtcuotainicial.Rows[i][8]);
                }
            }           
            
            

        }
//===================================================================================================================================================
        //F I N A L    M E T O D O   MtdoDatosInicial
//===================================================================================================================================================


//===================================================================================================================================================
        // I N I C I O   M E T O D O  MtdoNvoDatosContado
//===================================================================================================================================================
        private void MtdoNvoDatosContado()
        {
            System.Data.DataTable dtcontado = new System.Data.DataTable();
            if (ChbContado.Checked == true)
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                dt = conexion.MtdBuscarDataset("select concepto,numcuota,fecha,(capital-SaldoCapital)Capital,(Interes-SaldoInteres)Interes,(Cuota-SaldoCuota)Cuota," +
                " 0 SaldoCapital,0 SaldoInteres,0 SaldoCuota from financiacion Where Concepto ='CO' And IdAdjudicacion =" + VarIdAdjudicacion + " And NumCuota <= " +
                Convert.ToInt16(TxtUltCuotaContado.Text));
                int CTACON = Convert.ToInt16(TxtUltCuotaContado.Text);
                DateTime FechaContado;
                decimal CapitalContado = 0;


                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    DgvFinanciacion.Rows.Add(dt.Rows[i][0], dt.Rows[i][1], dt.Rows[i][2], dt.Rows[i][3], dt.Rows[i][4], dt.Rows[i][5], dt.Rows[i][6], dt.Rows[i][7], dt.Rows[i][8]);
                }

                for (int i = 0; i < (DgvContado.Rows.Count - 1); i++)
                {
                    CTACON = CTACON + 1;
                    FechaContado = Convert.ToDateTime((Convert.ToString(DgvContado.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvContado.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvContado.Rows[i].Cells[2].Value)));
                    CapitalContado = Convert.ToDecimal(DgvContado.Rows[i].Cells[3].Value);
                    DgvFinanciacion.Rows.Add("CO", CTACON, FechaContado, CapitalContado, 0, CapitalContado, CapitalContado, 0, CapitalContado);
                }
            }

            else 
            {
                dtcontado = conexion.MtdBuscarDataset(
                  " select Concepto,NumCuota,Fecha,Capital,Interes,Cuota," +
                   " Capital-(Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoCapital," +
                  " Interes-(Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoInteresCte," +
                  " Cuota-((Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta) -" +
                  " (Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta) )SaldoCuota " +
                  " From " +
                  " financiacion f " +
                  " Where  Concepto ='CO'   and IdAdjudicacion=" + VarIdAdjudicacion);

                for (int i = 0; i < (dtcontado.Rows.Count); i++)
                {
                    DgvFinanciacion.Rows.Add(dtcontado.Rows[i][0], dtcontado.Rows[i][1], dtcontado.Rows[i][2], dtcontado.Rows[i][3], dtcontado.Rows[i][4],
                    dtcontado.Rows[i][5], dtcontado.Rows[i][6], dtcontado.Rows[i][7], dtcontado.Rows[i][8]);
                }
            
            }
        }
//===================================================================================================================================================
        //F I N A L    M E T O D O   MtdoNvoDatosContado
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O   M E T O D O  MtdDatosSaldos
//===================================================================================================================================================
        public void MtdDatosSaldos()

        {
            DtSdoFinanciacion = conexion.MtdBuscarDataset(
           " select Concepto,NumCuota,Fecha,Capital,Interes,Cuota," +
           " Capital-(Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoCapital," +
           " Interes-(Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta)SaldoInteresCte," +
           " Cuota-((Select if(sum(r.Capital) is null,0,Sum(r.Capital)) From Recaudos r where r.IdFinanciacion=f.idCta) -" +
           " (Select if(sum(r.InteresCte) is null,0,Sum(r.InteresCte)) From Recaudos r where r.IdFinanciacion=f.idCta) )SaldoCuota " +
           " From " +
           " financiacion f " +
           " Where  Concepto !='GA'   and IdAdjudicacion=" + VarIdAdjudicacion);

            DgvFinanciacion.Rows.Clear();
            for (int i = 0; i < (DtSdoFinanciacion.Rows.Count); i++)
            {
                DgvFinanciacion.Rows.Add(DtSdoFinanciacion.Rows[i][0], DtSdoFinanciacion.Rows[i][1], DtSdoFinanciacion.Rows[i][2], DtSdoFinanciacion.Rows[i][3], DtSdoFinanciacion.Rows[i][4],
                DtSdoFinanciacion.Rows[i][5], DtSdoFinanciacion.Rows[i][6], DtSdoFinanciacion.Rows[i][7], DtSdoFinanciacion.Rows[i][8]);
            }

            TxtUltCuotaIni.Text= conexion.MtdBscDatos(" Select  IF(Max(NumCuota)IS NULL,0,Max(NumCuota))MaxCI From Recaudos Where Concepto='CI' And idAdjudicacion="+ VarIdAdjudicacion);
            TxtUltCuotaFnc.Text=conexion.MtdBscDatos(" Select  IF(Max(NumCuota)IS NULL,0,Max(NumCuota))MaxFN From Recaudos Where Concepto='FN' And idAdjudicacion= "+ VarIdAdjudicacion);
            TxtUltCuotaExtra.Text=conexion.MtdBscDatos(" Select  IF(Max(NumCuota)IS NULL,0,Max(NumCuota))MaxCE From Recaudos Where Concepto='CE' And idAdjudicacion="+VarIdAdjudicacion);
            TxtUltCuotaContado.Text=conexion.MtdBscDatos("Select  IF(Max(NumCuota)IS NULL,0,Max(NumCuota))MaxCO From Recaudos Where Concepto='CO' And idAdjudicacion= "+VarIdAdjudicacion);
            TxtNumCuotasFnc.Text = DtDatos.Rows[0][14].ToString();
            TxtTasaFnc.Text = DtDatos.Rows[0][15].ToString();
            TxtCuotaFncOtrosi.Text = DtDatos.Rows[0][16].ToString();
            this.TxtCuotaFncOtrosi.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtCuotaFncOtrosi.Text));
            TxtNumCuotasExtra.Text = DtDatos.Rows[0][18].ToString();
            TxtTasaExtra.Text = DtDatos.Rows[0][19].ToString();
            TxtCuotaExtraOtrosi.Text = DtDatos.Rows[0][20].ToString();
            this.TxtCuotaExtraOtrosi.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtCuotaExtraOtrosi.Text));
            MtdDatosContado();
            MtdDatosCtaIni();

            if (Convert.ToDecimal(TxtUltCuotaExtra.Text) == 0)
            {
                LblSdoUltCuotaContado.Text = "0.00";
            }
            else 
            {
                LblSdoUltCuotaContado.Text = conexion.MtdBscDatos("select IF(sum(saldocapital) IS NULL,0,sum(SaldoCapital)) from 004saldocuotas where idcta = 'CO" + TxtUltCuotaContado.Text + "ADJ" + VarIdAdjudicacion + "'");
                this.LblSdoUltCuotaContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSdoUltCuotaContado.Text));
            }

            if (Convert.ToDecimal(TxtUltCuotaFnc.Text) == 0)
            {
                LblSdoUltCtaFnc.Text = "0.00";
            }
            else
            {
                LblSdoUltCtaFnc.Text = conexion.MtdBscDatos("select IF(sum(saldocapital) IS NULL,0,sum(SaldoCapital)) from 004saldocuotas where idcta = 'FN" + TxtUltCuotaFnc.Text + "ADJ" + VarIdAdjudicacion + "'");
                this.LblSdoUltCtaFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSdoUltCtaFnc.Text));
            }

            if (Convert.ToDecimal(TxtUltCuotaIni.Text) == 0)
            {
                LblSdoUltCuotaIni.Text = "0.00";
            }
            else
            {
                LblSdoUltCuotaIni.Text = conexion.MtdBscDatos("select IF(sum(saldocapital) IS NULL,0,sum(SaldoCapital)) from 004saldocuotas where idcta = 'CI" + TxtUltCuotaIni.Text + "ADJ" + VarIdAdjudicacion+"'");
                this.LblSdoUltCuotaIni.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSdoUltCuotaIni.Text));
            }


            if (Convert.ToDecimal(TxtUltCuotaExtra.Text) == 0)
            {
                LblSdoUltCtaExt.Text = "0.00";
            }
            else
            {
                LblSdoUltCtaExt.Text = conexion.MtdBscDatos("select IF(sum(saldocapital) IS NULL,0,sum(SaldoCapital)) from 004saldocuotas where idcta = 'CE" + TxtUltCuotaExtra.Text + "ADJ" + VarIdAdjudicacion + "'");
                this.LblSdoUltCtaExt.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSdoUltCtaExt.Text));
            }
            this.TxtVrContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSaldoContado.Text));
            this.TxtValorIni.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSdoCtaIni.Text));
            this.TxtCapitalExtra.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSdoCtaExt.Text));
            this.TxtCapitalFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtSdoCtaFnc.Text));

        }
//===================================================================================================================================================
//F I N A L    M E T O D O   MtdDatosSaldos
//===================================================================================================================================================


//===================================================================================================================================================
        // I N I C I O   M E T O D O  MtdDatosSaldosOtrosi
//===================================================================================================================================================
        public void MtdDatosSaldosOtrosi()
        {
            System.Data.DataTable DtOtrosiValores = new System.Data.DataTable();

            DtSdoFinanciacion = conexion.MtdBuscarDataset(
           " select Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota From datosotrosi  Where IdOtrosi= "+ VarIdOtrosi);

            DtOtrosiValores= conexion.MtdBuscarDataset("SELECT Valor,CuotaInicial,Contado,Financiacion,PlazoFnc,TasaFnc,CuotaFnc,InicioFnc,Extraordinaria,PlazoExtra,"+
            " TasaExtra,CuotaExtra,InicioExtra,Usuario,FechaOperacion From otrosi where idotrosi="+VarIdOtrosi);

            DgvFinanciacion.Rows.Clear();
            for (int i = 0; i < (DtSdoFinanciacion.Rows.Count); i++)
            {
                DgvFinanciacion.Rows.Add(DtSdoFinanciacion.Rows[i][0], DtSdoFinanciacion.Rows[i][1], DtSdoFinanciacion.Rows[i][2], DtSdoFinanciacion.Rows[i][3], DtSdoFinanciacion.Rows[i][4],
                DtSdoFinanciacion.Rows[i][5], DtSdoFinanciacion.Rows[i][6], DtSdoFinanciacion.Rows[i][7], DtSdoFinanciacion.Rows[i][8]);
            }

            TxtUltCuotaIni.Text = conexion.MtdBscDatos(" Select  IF(Max(NumCuota)IS NULL,0,Max(NumCuota))MaxCI From Recaudos Where Concepto='CI' And idAdjudicacion=" + VarIdAdjudicacion);
            TxtUltCuotaFnc.Text = conexion.MtdBscDatos(" Select  IF(Max(NumCuota)IS NULL,0,Max(NumCuota))MaxFN From Recaudos Where Concepto='FN' And idAdjudicacion= " + VarIdAdjudicacion);
            TxtUltCuotaExtra.Text = conexion.MtdBscDatos(" Select  IF(Max(NumCuota)IS NULL,0,Max(NumCuota))MaxCE From Recaudos Where Concepto='CE' And idAdjudicacion=" + VarIdAdjudicacion);
            TxtUltCuotaContado.Text = conexion.MtdBscDatos("Select  IF(Max(NumCuota)IS NULL,0,Max(NumCuota))MaxCO From Recaudos Where Concepto='CO' And idAdjudicacion= " + VarIdAdjudicacion);
            TxtNumCuotasFnc.Text = DtDatos.Rows[0][14].ToString();
           

            MtdDatosContado();
            MtdDatosCtaIni();

            TxtNuevoVrVenta.Text=DtOtrosiValores.Rows[0][0].ToString();           
            TxtValorIni.Text=DtOtrosiValores.Rows[0][1].ToString();
            TxtVrContado.Text=DtOtrosiValores.Rows[0][2].ToString();
            TxtCapitalFnc.Text=DtOtrosiValores.Rows[0][3].ToString();
            TxtNumCuotasFnc.Text=DtOtrosiValores.Rows[0][4].ToString();
            TxtTasaFnc.Text=DtOtrosiValores.Rows[0][5].ToString();
            TxtCuotaFncOtrosi.Text=DtOtrosiValores.Rows[0][6].ToString();
            DtpInicioFnc.Text=DtOtrosiValores.Rows[0][7].ToString();
            TxtCapitalExtra.Text=DtOtrosiValores.Rows[0][8].ToString();
            TxtNumCuotasExtra.Text=DtOtrosiValores.Rows[0][9].ToString();
            TxtTasaExtra.Text=DtOtrosiValores.Rows[0][10].ToString();
            TxtCuotaExtraOtrosi.Text=DtOtrosiValores.Rows[0][11].ToString();
            DtpInicioExtra.Text=DtOtrosiValores.Rows[0][12].ToString();
            LblUsuarioElabora.Text=DtOtrosiValores.Rows[0][13].ToString();
            LblFechaElaboracion.Text = String.Format("{0:d/M/yyyy}", Convert.ToDateTime(DtOtrosiValores.Rows[0][14].ToString()));
            
            LblFec.Visible=true;
            LblFechaElaboracion.Visible=true;
            LblUsuarioElabora.Visible = true;
            Lblusr.Visible=true;


            if (Convert.ToDecimal(TxtUltCuotaExtra.Text) == 0)
            {
                LblSdoUltCuotaContado.Text = "0.00";
            }
            else
            {
                LblSdoUltCuotaContado.Text = conexion.MtdBscDatos("select IF(sum(saldocapital) IS NULL,0,sum(SaldoCapital)) from 004saldocuotas where idcta = 'CO" + TxtUltCuotaContado.Text + "ADJ" + VarIdAdjudicacion + "'");
                this.LblSdoUltCuotaContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSdoUltCuotaContado.Text));
            }

            if (Convert.ToDecimal(TxtUltCuotaFnc.Text) == 0)
            {
                LblSdoUltCtaFnc.Text = "0.00";
            }
            else
            {
                LblSdoUltCtaFnc.Text = conexion.MtdBscDatos("select IF(sum(saldocapital) IS NULL,0,sum(SaldoCapital)) from 004saldocuotas where idcta = 'FN" + TxtUltCuotaFnc.Text + "ADJ" + VarIdAdjudicacion + "'");
                this.LblSdoUltCtaFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSdoUltCtaFnc.Text));
            }

            if (Convert.ToDecimal(TxtUltCuotaIni.Text) == 0)
            {
                LblSdoUltCuotaIni.Text = "0.00";
            }
            else
            {
                LblSdoUltCuotaIni.Text = conexion.MtdBscDatos("select IF(sum(saldocapital) IS NULL,0,sum(SaldoCapital)) from 004saldocuotas where idcta = 'CI" + TxtUltCuotaIni.Text + "ADJ" + VarIdAdjudicacion + "'");
                this.LblSdoUltCuotaIni.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSdoUltCuotaIni.Text));
            }


            if (Convert.ToDecimal(TxtUltCuotaExtra.Text) == 0)
            {
                LblSdoUltCtaExt.Text = "0.00";
            }
            else
            {
                LblSdoUltCtaExt.Text = conexion.MtdBscDatos("select IF(sum(saldocapital) IS NULL,0,sum(SaldoCapital)) from 004saldocuotas where idcta = 'CE" + TxtUltCuotaExtra.Text + "ADJ" + VarIdAdjudicacion + "'");
                this.LblSdoUltCtaExt.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSdoUltCtaExt.Text));
            }

            TxtVrContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(TxtVrContado.Text));
            TxtValorIni.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(TxtValorIni.Text));
            TxtCapitalExtra.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(TxtCapitalExtra.Text));
            TxtCapitalFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(TxtCapitalFnc.Text));
            TxtNuevoVrVenta.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(TxtNuevoVrVenta.Text));
            MtdDatosContadoOtrosi();
            MtdDatosCtaIniOtrosi();

            TxtRcdTotalOtrosi.Text = Convert.ToString(Convert.ToDecimal(TxtRcdTotal.Text));
            TxtNuevoSaldo.Text = Convert.ToString(Convert.ToDecimal(TxtNuevoVrVenta.Text) - Convert.ToDecimal(TxtRcdTotalOtrosi.Text));

            Diferencia = Convert.ToDecimal(TxtNuevoVrVenta.Text) - Convert.ToDecimal(TxtCapitalFnc.Text) - Convert.ToDecimal(TxtCapitalExtra.Text) -
               Convert.ToDecimal(TxtValorIni.Text) - Convert.ToDecimal(TxtVrContado.Text) ;
            TxtDiferencia.Text = Convert.ToString(Diferencia);
            this.TxtDiferencia.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtDiferencia.Text));
        }
//===================================================================================================================================================
        //F I N A L    M E T O D O   MtdDatosSaldosOtrosi
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O  MtdTotal
//===================================================================================================================================================
        private void MtdTotal()
        {
            decimal SumaCapital = 0, SumaInteres = 0,SumaSdoCapital=0,SumaSdoInteres=0;
            for (int i = 0; i < (DgvTodaFnc.Rows.Count); i++)
            {
                SumaCapital += (Convert.ToDecimal(DgvTodaFnc.Rows[i].Cells[3].Value));
                SumaInteres += (Convert.ToDecimal(DgvTodaFnc.Rows[i].Cells[4].Value));
            }
            int a = DgvTodaFnc.Rows.Count - 1;
            DgvTodaFnc.Rows[a].Cells[2].Value = "T O T A L  . .";
            DgvTodaFnc.Rows[a].Cells[3].Value = SumaCapital;
            DgvTodaFnc.Rows[a].Cells[4].Value = SumaInteres;
            DgvTodaFnc.Rows[a].DefaultCellStyle.BackColor = Color.Lavender;
            ValidacionCapital = SumaCapital;
            
            SumaCapital = 0; SumaInteres = 0;

            for (int i = 0; i < (DgvCuotas.Rows.Count); i++)
            {
                SumaCapital += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value));
                SumaInteres += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[5].Value));
            }
            int b = DgvCuotas.Rows.Count - 1;
            DgvCuotas.Rows[b].Cells[2].Value = "T O T A L  . .";
            DgvCuotas.Rows[b].Cells[4].Value = SumaCapital;
            DgvCuotas.Rows[b].Cells[5].Value = SumaInteres;
            DgvCuotas.Rows[b].DefaultCellStyle.BackColor = Color.Lavender;
            ValidacionCapital = SumaCapital;


            SumaCapital = 0; SumaInteres = 0;

            for (int i = 0; i < (DgvFinanciacion.Rows.Count); i++)
            {
                SumaCapital += (Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[3].Value));
                SumaInteres += (Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[4].Value));
                SumaSdoCapital += (Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[6].Value));
                SumaSdoInteres += (Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[7].Value));
            }
            int c = DgvFinanciacion.Rows.Count - 1;
            DgvFinanciacion.Rows[c].Cells[2].Value = "T O T A L  . .";
            DgvFinanciacion.Rows[c].Cells[3].Value = SumaCapital;
            DgvFinanciacion.Rows[c].Cells[4].Value = SumaInteres;
            DgvFinanciacion.Rows[c].Cells[6].Value = SumaSdoCapital;
            DgvFinanciacion.Rows[c].Cells[7].Value = SumaSdoInteres;
            DgvFinanciacion.Rows[c].DefaultCellStyle.BackColor = Color.Lavender;
            

        }
//===================================================================================================================================================
//F I N A L    M E T O D O   MtdTotal
//===================================================================================================================================================

//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O S   C T A   I N I C I A L
//===================================================================================================================================================
        private void MtdDatosCtaIni()
        {
            DgvCtaInicial.AutoGenerateColumns = false;
            DgvCtaInicial.Columns[0].DataPropertyName = "Dia";
            DgvCtaInicial.Columns[1].DataPropertyName = "Mes";
            DgvCtaInicial.Columns[2].DataPropertyName = "Ano";
            DgvCtaInicial.Columns[3].DataPropertyName = "Valor";
            System.Data.DataTable DtDatosReg = conexion.MtdBuscarDataset("select day(fecha) Dia , MONTH(fecha) Mes,year(fecha) Ano," +
            "SaldoCapital from financiacion where Concepto= 'CI' And SaldoCapital>0 AND idadjudicacion= " + VarIdAdjudicacion);
            DgvCtaInicial.Rows.Clear();
            for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
            {
                DgvCtaInicial.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3]);
            }
        }
//===================================================================================================================================================
//  F I N A L   M E T O D O   D A T O S   C U O T A   I N I C I A L
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O S   C O N T A D O
//===================================================================================================================================================
        private void MtdDatosContado()
        {
            DgvContado.AutoGenerateColumns = false;
            DgvContado.Columns[0].DataPropertyName = "Dia";
            DgvContado.Columns[1].DataPropertyName = "Mes";
            DgvContado.Columns[2].DataPropertyName = "Ano";
            DgvContado.Columns[3].DataPropertyName = "Valor";

            System.Data.DataTable DtDatosReg = conexion.MtdBuscarDataset("select day(fecha) Dia , MONTH(fecha) Mes,year(fecha) Ano," +
             "SaldoCapital from financiacion where Concepto= 'CO' AND SaldoCapital AND idadjudicacion=" + VarIdAdjudicacion);
            DgvContado.Rows.Clear();
            for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
            {
                DgvContado.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3]);
            }            
        }
//===================================================================================================================================================
//  F I N A L   M E T O D O   D A T O S   C O N T A D O
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O S   C T A   I N I C I A L
//===================================================================================================================================================
        private void MtdDatosCtaIniOtrosi()
        {
            DgvCtaInicial.AutoGenerateColumns = false;
            DgvCtaInicial.Columns[0].DataPropertyName = "Dia";
            DgvCtaInicial.Columns[1].DataPropertyName = "Mes";
            DgvCtaInicial.Columns[2].DataPropertyName = "Ano";
            DgvCtaInicial.Columns[3].DataPropertyName = "Valor";
            System.Data.DataTable DtDatosReg = conexion.MtdBuscarDataset("select day(fecha) Dia , MONTH(fecha) Mes,year(fecha) Ano," +
            "SaldoCapital from datosotrosi where Concepto= 'CI' And SaldoCapital>0 AND IdOtrosi= " + VarIdOtrosi);
            DgvCtaInicial.Rows.Clear();
            for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
            {
                DgvCtaInicial.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3]);
            }
        }
//===================================================================================================================================================
//  F I N A L   M E T O D O   D A T O S   C U O T A   I N I C I A L
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O S   C O N T A D O
//===================================================================================================================================================
        private void MtdDatosContadoOtrosi()
        {
            DgvContado.AutoGenerateColumns = false;
            DgvContado.Columns[0].DataPropertyName = "Dia";
            DgvContado.Columns[1].DataPropertyName = "Mes";
            DgvContado.Columns[2].DataPropertyName = "Ano";
            DgvContado.Columns[3].DataPropertyName = "Valor";

            System.Data.DataTable DtDatosReg = conexion.MtdBuscarDataset("select day(fecha) Dia , MONTH(fecha) Mes,year(fecha) Ano," +
             "SaldoCapital from datosotrosi where Concepto= 'CO' AND SaldoCapital AND IdOtrosi= " + VarIdOtrosi);
            DgvContado.Rows.Clear();
            for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
            {
                DgvContado.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3]);
            }
        }
//===================================================================================================================================================
//  F I N A L   M E T O D O   D A T O S   C O N T A D O
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   M E T O D O   V A L I D A R   S A L D O S
//===================================================================================================================================================
        private void MtdValidarSaldos()
        {
            TxtRcdTotalOtrosi.Text = Convert.ToString(Convert.ToDecimal(TxtRcdTotal.Text) );
            TxtNuevoSaldo.Text = Convert.ToString(Convert.ToDecimal(TxtNuevoVrVenta.Text) - Convert.ToDecimal(TxtRcdTotalOtrosi.Text));

            MtdDiferencia();

            
            this.TxtRcdTotalOtrosi.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtRcdTotalOtrosi.Text));

            this.TxtNuevoSaldo.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtNuevoSaldo.Text));

            this.TxtDiferencia.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtDiferencia.Text));
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   V A L I D A R   S A L D O S
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O  MtdDiferencia
//===================================================================================================================================================
        private void MtdDiferencia()
        {
            Diferencia = Convert.ToDecimal(TxtNuevoVrVenta.Text) - Convert.ToDecimal(TxtCapitalFnc.Text) - Convert.ToDecimal(TxtCapitalExtra.Text) -
                Convert.ToDecimal(TxtValorIni.Text) - Convert.ToDecimal(TxtVrContado.Text) - Convert.ToDecimal(TxtRcdTotal.Text);
            TxtDiferencia.Text = Convert.ToString(Diferencia);
            this.TxtDiferencia.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtDiferencia.Text));
        }
//===================================================================================================================================================
//  F I N A L   M E T O D O   MtdDiferencia
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdValidarAdd
//===================================================================================================================================================
        private void MtdValidarAdd()
        {
            DatosdeErrores.Clear();
            CuentaErrores = 0;
           


            if (Convert.ToDouble(TxtDiferencia.Text) != 0)
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Documento Descuadrado");
            }


        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdValidarAdd
//===================================================================================================================================================



        private void MtdOtrosi()
        {
            string VarIdCta, VarConcepto;
            decimal VarCapital, VarInteres, VarCuota,VarSaldoCapital,VarSaldoInteres,VarSaldoCuota;
            int VarNumcuota, Consecutivo, VarIdOtrosiAdd;
            DateTime VarFecha;
            MtdValidarAdd();
            if (CuentaErrores > 0)
            {
                FrmMensajeError frmMensajeError = new FrmMensajeError();
                frmMensajeError.LblErrores.DataSource = DatosdeErrores;
                frmMensajeError.ShowDialog();
            }
            else
            {
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Adicionar ", "Adicionar Otrosi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    Consecutivo = Convert.ToInt16(VarIdAdjudicacion);

                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                    VarIdOtrosiAdd = Convert.ToInt16(conexion.MtdBscDatos("select if(max(IdOtrosi)is null,1,max(IdOtrosi+1))from Otrosi"));


                    string AddOtrosi = "Insert into Otrosi(IdOtrosi,IdAdjudicacion,Fecha,Valor,CuotaInicial,Contado,Financiacion,PlazoFnc,TasaFnc,CuotaFnc,InicioFnc," +
                        "Extraordinaria,PlazoExtra,TasaExtra,CuotaExtra,InicioExtra,Usuario,FechaOperacion)" +
                    "Values(@IdOtrosi,@IdAdjudicacion,@Fecha,@Valor,@CuotaInicial,@Contado,@Financiacion,@PlazoFnc,@TasaFnc,@CuotaFnc,@InicioFnc," +
                        "@Extraordinaria,@PlazoExtra,@TasaExtra,@CuotaExtra,@InicioExtra,@Usuario,@FechaOperacion)";

                    string AddModAdjudicacio = "insert into modadjudicacion (Select * from Adjudicacion where idadjudicacion=@IdAdjudicacion)";
                    string ModAdjudicacion = "Update Adjudicacion set Estado='Otrosi',FechaOperacion=@Fecha,Usuario=@Usuario  Where IdAdjudicacion=@IdAdjudicacion";

                    string StrAddDatosOtrosi = "insert into datosotrosi (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,Usuario,FechaOperacion,IdOtrosi) " +
                        "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital,@Interes,@Cuota,@SaldoCapital,@SaldoInteres,@SaldoCuota,@Usuario,@FechaOperacion,@IdOtrosi)";




                    MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                    MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                        CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaInicial", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Contado", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Financiacion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoFnc", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Extraordinaria", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoExtra", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioExtra", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@IdOtrosi", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@IdCta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Capital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Interes", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Cuota", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@SaldoCapital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@SaldoInteres", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@SaldoCuota", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@NumCuota", MySql.Data.MySqlClient.MySqlDbType.Int16);

                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                        CmdAddPrm.Parameters["@Valor"].Value = Convert.ToDecimal(TxtNuevoVrVenta.Text);                      
                        CmdAddPrm.Parameters["@CuotaInicial"].Value = Convert.ToDecimal(TxtValorIni.Text)+ Convert.ToDecimal(TxtRcdIni.Text);
                        CmdAddPrm.Parameters["@Contado"].Value = Convert.ToDecimal(TxtVrContado.Text) + Convert.ToDecimal(TxtRecaudoContado.Text);
                        CmdAddPrm.Parameters["@Financiacion"].Value = Convert.ToDecimal(TxtCapitalFnc.Text) + Convert.ToDecimal(TxtRcdFnc.Text);
                        CmdAddPrm.Parameters["@PlazoFnc"].Value = Convert.ToInt16(TxtNumCuotasFnc.Text);
                        CmdAddPrm.Parameters["@TasaFnc"].Value = Convert.ToDecimal(TxtTasaFnc.Text);
                        CmdAddPrm.Parameters["@CuotaFnc"].Value = Convert.ToDecimal(TxtCuotaFncOtrosi.Text) ;
                        CmdAddPrm.Parameters["@InicioFnc"].Value = DtpInicioFnc.Value;
                        CmdAddPrm.Parameters["@Extraordinaria"].Value = Convert.ToDecimal(TxtCapitalExtra.Text)+ Convert.ToDecimal(TxtRcdExtra.Text) ;
                        CmdAddPrm.Parameters["@PlazoExtra"].Value = Convert.ToInt16(TxtNumCuotasExtra.Text); ;
                        CmdAddPrm.Parameters["@TasaExtra"].Value = Convert.ToDecimal(TxtTasaExtra.Text);
                        CmdAddPrm.Parameters["@CuotaExtra"].Value = Convert.ToDecimal(TxtCuotaExtraOtrosi.Text);
                        CmdAddPrm.Parameters["@InicioExtra"].Value = DtpInicioExtra.Value;
                        CmdAddPrm.Parameters["@IdOtrosi"].Value = VarIdOtrosiAdd;
                        CmdAddPrm.Parameters["@Fecha"].Value =DtpFechaOtrosi.Value;                        
                        CmdAddPrm.Parameters["@Estado"].Value = "Pendiente";
                        CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                    


                        CmdAddPrm.CommandText = AddOtrosi;
                        CmdAddPrm.ExecuteNonQuery();                       
                        
                        CmdAddPrm.CommandText = AddModAdjudicacio;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = ModAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();


                       

                        for (int i = 0; i < DgvFinanciacion.Rows.Count - 1; i++)
                        {
                            VarConcepto = DgvFinanciacion.Rows[i].Cells[0].Value.ToString();
                            VarNumcuota = Convert.ToInt16(DgvFinanciacion.Rows[i].Cells[1].Value);
                            VarIdCta = VarConcepto + VarNumcuota + "ADJ" + Consecutivo;
                            VarFecha = Convert.ToDateTime(DgvFinanciacion.Rows[i].Cells[2].Value);
                            VarCapital = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[3].Value);
                            VarInteres = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[4].Value);
                            VarCuota = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[5].Value);
                            VarSaldoCapital = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[6].Value);
                            VarSaldoInteres = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[7].Value);
                            VarSaldoCuota = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[8].Value);

                            CmdAddPrm.Parameters["@IdCta"].Value = VarIdCta;
                            CmdAddPrm.Parameters["@Concepto"].Value = VarConcepto;
                            CmdAddPrm.Parameters["@FechaFnc"].Value = VarFecha;
                            CmdAddPrm.Parameters["@Capital"].Value = VarCapital;
                            CmdAddPrm.Parameters["@Interes"].Value = VarInteres;
                            CmdAddPrm.Parameters["@Cuota"].Value = VarCuota;
                            CmdAddPrm.Parameters["@SaldoCapital"].Value = VarSaldoCapital;
                            CmdAddPrm.Parameters["@SaldoInteres"].Value = VarSaldoInteres;
                            CmdAddPrm.Parameters["@SaldoCuota"].Value = VarSaldoCuota;
                            CmdAddPrm.Parameters["@NumCuota"].Value = VarNumcuota;

                            CmdAddPrm.CommandText = StrAddDatosOtrosi;
                            CmdAddPrm.ExecuteNonQuery();
                        }

                        myTrans.Commit();
                        MessageBox.Show("Otrosi Adicionado", "Adicionar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                        BtnValidar.Enabled = false;
                        LblNumOtrosi.Text = VarIdOtrosiAdd.ToString();
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }
                }
            }
        }




        private void MtdModOtrosi()
        {
            string VarIdCta, VarConcepto;
            decimal VarCapital, VarInteres, VarCuota, VarSaldoCapital, VarSaldoInteres, VarSaldoCuota;
            int VarNumcuota, Consecutivo;
            DateTime VarFecha;
            MtdValidarAdd();
            if (CuentaErrores > 0)
            {
                FrmMensajeError frmMensajeError = new FrmMensajeError();
                frmMensajeError.LblErrores.DataSource = DatosdeErrores;
                frmMensajeError.ShowDialog();
            }
            else
            {
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Modificar ", "Modificar Otrosi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    Consecutivo = Convert.ToInt16(VarIdAdjudicacion);

                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);


                    string ModOtrosi = "insert into ModOtrosi (Select * from Otrosi where IdOtrosi=@IdOtrosi)";

                    string DelOtrosi = "Delete From Otrosi Where Idotrosi=@IdOtrosi";

                    string AddOtrosi = "Insert into Otrosi(IdOtrosi,IdAdjudicacion,Fecha,Valor,CuotaInicial,Contado,Financiacion,PlazoFnc,TasaFnc,CuotaFnc,InicioFnc," +
                        "Extraordinaria,PlazoExtra,TasaExtra,CuotaExtra,InicioExtra,Usuario,FechaOperacion)" +
                    "Values(@IdOtrosi,@IdAdjudicacion,@Fecha,@Valor,@CuotaInicial,@Contado,@Financiacion,@PlazoFnc,@TasaFnc,@CuotaFnc,@InicioFnc," +
                        "@Extraordinaria,@PlazoExtra,@TasaExtra,@CuotaExtra,@InicioExtra,@Usuario,@FechaOperacion)";

                    string AddModAdjudicacio = "insert into modadjudicacion (Select * from Adjudicacion where idadjudicacion=@IdAdjudicacion)";

                    string ModAdjudicacion = "Update Adjudicacion set Estado='Otrosi',FechaOperacion=@FechaOperacion,Usuario=@Usuario  Where IdAdjudicacion=@IdAdjudicacion";

                    string DelDatosOtrosi = "Delete From datosotrosi Where Idotrosi=@IdOtrosi";

                    string StrAddDatosOtrosi = "insert into datosotrosi (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,Usuario,FechaOperacion,IdOtrosi) " +
                        "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital,@Interes,@Cuota,@SaldoCapital,@SaldoInteres,@SaldoCuota,@Usuario,@FechaOperacion,@IdOtrosi)";




                    MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                    MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                        CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaInicial", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Contado", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Financiacion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoFnc", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Extraordinaria", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoExtra", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioExtra", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@IdOtrosi", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@IdCta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Capital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Interes", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Cuota", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@SaldoCapital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@SaldoInteres", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@SaldoCuota", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@NumCuota", MySql.Data.MySqlClient.MySqlDbType.Int16);

                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                        CmdAddPrm.Parameters["@Valor"].Value = Convert.ToDecimal(TxtNuevoVrVenta.Text);
                        CmdAddPrm.Parameters["@CuotaInicial"].Value = Convert.ToDecimal(TxtValorIni.Text) + Convert.ToDecimal(TxtRcdIni.Text);
                        CmdAddPrm.Parameters["@Contado"].Value = Convert.ToDecimal(TxtVrContado.Text) + Convert.ToDecimal(TxtRecaudoContado.Text);
                        CmdAddPrm.Parameters["@Financiacion"].Value = Convert.ToDecimal(TxtCapitalFnc.Text) + Convert.ToDecimal(TxtRcdFnc.Text);
                        CmdAddPrm.Parameters["@PlazoFnc"].Value = Convert.ToInt16(TxtNumCuotasFnc.Text);
                        CmdAddPrm.Parameters["@TasaFnc"].Value = Convert.ToDecimal(TxtTasaFnc.Text);
                        CmdAddPrm.Parameters["@CuotaFnc"].Value = Convert.ToDecimal(TxtCuotaFncOtrosi.Text);
                        CmdAddPrm.Parameters["@InicioFnc"].Value = DtpInicioFnc.Value;
                        CmdAddPrm.Parameters["@Extraordinaria"].Value = Convert.ToDecimal(TxtCapitalExtra.Text) + Convert.ToDecimal(TxtRcdExtra.Text);
                        CmdAddPrm.Parameters["@PlazoExtra"].Value = Convert.ToInt16(TxtNumCuotasExtra.Text); ;
                        CmdAddPrm.Parameters["@TasaExtra"].Value = Convert.ToDecimal(TxtTasaExtra.Text);
                        CmdAddPrm.Parameters["@CuotaExtra"].Value = Convert.ToDecimal(TxtCuotaExtraOtrosi.Text);
                        CmdAddPrm.Parameters["@InicioExtra"].Value = DtpInicioExtra.Value;
                        CmdAddPrm.Parameters["@IdOtrosi"].Value = VarIdOtrosi;
                        CmdAddPrm.Parameters["@Fecha"].Value = DtpFechaOtrosi.Value;
                        CmdAddPrm.Parameters["@Estado"].Value = "Pendiente";
                        CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;


                        CmdAddPrm.CommandText = ModOtrosi;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = DelOtrosi;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = AddOtrosi;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = AddModAdjudicacio;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = ModAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = DelDatosOtrosi;
                        CmdAddPrm.ExecuteNonQuery();

                        

                        for (int i = 0; i < DgvFinanciacion.Rows.Count - 1; i++)
                        {
                            VarConcepto = DgvFinanciacion.Rows[i].Cells[0].Value.ToString();
                            VarNumcuota = Convert.ToInt16(DgvFinanciacion.Rows[i].Cells[1].Value);
                            VarIdCta = VarConcepto + VarNumcuota + "ADJ" + Consecutivo;
                            VarFecha = Convert.ToDateTime(DgvFinanciacion.Rows[i].Cells[2].Value);
                            VarCapital = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[3].Value);
                            VarInteres = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[4].Value);
                            VarCuota = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[5].Value);
                            VarSaldoCapital = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[6].Value);
                            VarSaldoInteres = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[7].Value);
                            VarSaldoCuota = Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[8].Value);

                            CmdAddPrm.Parameters["@IdCta"].Value = VarIdCta;
                            CmdAddPrm.Parameters["@Concepto"].Value = VarConcepto;
                            CmdAddPrm.Parameters["@FechaFnc"].Value = VarFecha;
                            CmdAddPrm.Parameters["@Capital"].Value = VarCapital;
                            CmdAddPrm.Parameters["@Interes"].Value = VarInteres;
                            CmdAddPrm.Parameters["@Cuota"].Value = VarCuota;
                            CmdAddPrm.Parameters["@SaldoCapital"].Value = VarSaldoCapital;
                            CmdAddPrm.Parameters["@SaldoInteres"].Value = VarSaldoInteres;
                            CmdAddPrm.Parameters["@SaldoCuota"].Value = VarSaldoCuota;
                            CmdAddPrm.Parameters["@NumCuota"].Value = VarNumcuota;

                            CmdAddPrm.CommandText = StrAddDatosOtrosi;
                            CmdAddPrm.ExecuteNonQuery();
                        }

                        myTrans.Commit();
                        MessageBox.Show("Otrosi Modificado", "Modificar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                        BtnValidar.Enabled = false;
                       
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }
                }
            }
        }




        private void MtdAprOtrosi()
        {
            
            int   Consecutivo;
         
          
           
                DialogResult rest;
                rest = MessageBox.Show("Esta Aprobar Este Otrosi ", "Aprobar Otrosi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    Consecutivo = Convert.ToInt16(VarIdAdjudicacion);

                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);



                    string UpdOtrosi = "Update Otrosi Set Estado='Aprobado',UsuarioAprueba=@Usuario,FechaAprobacion=@FechaOperacion Where IdOtrosi=@IdOtrosi";
                    
                    string ModAdjudicacion = "Update Adjudicacion set Valor=@Valor,CuotaInicial=@CuotaInicial,Contado=@Contado,Financiacion=@Financiacion,Extraordinaria=@Extraordinaria,"+
                    "PlazoFnc=@PlazoFnc,TasaFnc=@TasaFnc,CuotaFnc=@CuotaFnc,PlazoExtra=@PlazoExtra ,TasaExtra=@TasaExtra,CuotaExtra=@CuotaExtra, Estado='Aprobado',"+
                    "FechaOperacion=@FechaOperacion,Usuario=@Usuario  Where IdAdjudicacion=@IdAdjudicacion";

                    string ModFinanciacion = "insert into ModFinanciacion (Select * From Financiacion Where IdAdjudicacion=@IdAdjudicacion) ";

                    string DelFinanciacion = "Delete From Financiacion Where IdAdjudicacion=@IdAdjudicacion and Concepto !='GA'";

                    string StrAddFinanciacion = "insert into Financiacion (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,UltimaFechaPago,Usuario,FechaOperacion) " +
                        "(Select IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,Fecha,Usuario,FechaOperacion From datosotrosi Where IdOtrosi=@IdOtrosi)";
                    


                    MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                    MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                        CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaInicial", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Contado", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Financiacion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoFnc", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Extraordinaria", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoExtra", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioExtra", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@IdOtrosi", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                        

                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                        CmdAddPrm.Parameters["@Valor"].Value = Convert.ToDecimal(TxtNuevoVrVenta.Text);
                        CmdAddPrm.Parameters["@CuotaInicial"].Value = Convert.ToDecimal(TxtValorIni.Text) + Convert.ToDecimal(TxtRcdIni.Text);
                        CmdAddPrm.Parameters["@Contado"].Value = Convert.ToDecimal(TxtVrContado.Text) + Convert.ToDecimal(TxtRecaudoContado.Text);
                        CmdAddPrm.Parameters["@Financiacion"].Value = Convert.ToDecimal(TxtCapitalFnc.Text) + Convert.ToDecimal(TxtRcdFnc.Text);
                        CmdAddPrm.Parameters["@PlazoFnc"].Value = Convert.ToInt16(TxtNumCuotasFnc.Text);
                        CmdAddPrm.Parameters["@TasaFnc"].Value = Convert.ToDecimal(TxtTasaFnc.Text);
                        CmdAddPrm.Parameters["@CuotaFnc"].Value = Convert.ToDecimal(TxtCuotaFncOtrosi.Text);
                        CmdAddPrm.Parameters["@InicioFnc"].Value = DtpInicioFnc.Value;
                        CmdAddPrm.Parameters["@Extraordinaria"].Value = Convert.ToDecimal(TxtCapitalExtra.Text) + Convert.ToDecimal(TxtRcdExtra.Text);
                        CmdAddPrm.Parameters["@PlazoExtra"].Value = Convert.ToInt16(TxtNumCuotasExtra.Text); ;
                        CmdAddPrm.Parameters["@TasaExtra"].Value = Convert.ToDecimal(TxtTasaExtra.Text);
                        CmdAddPrm.Parameters["@CuotaExtra"].Value = Convert.ToDecimal(TxtCuotaExtraOtrosi.Text);
                        CmdAddPrm.Parameters["@InicioExtra"].Value = DtpInicioExtra.Value;
                        CmdAddPrm.Parameters["@IdOtrosi"].Value = VarIdOtrosi;
                        CmdAddPrm.Parameters["@Fecha"].Value = DtpFechaOtrosi.Value;
                        CmdAddPrm.Parameters["@Estado"].Value = "Pendiente";
                        CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;



                        CmdAddPrm.CommandText = UpdOtrosi;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = ModAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = ModFinanciacion;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = DelFinanciacion;
                        CmdAddPrm.ExecuteNonQuery();                       

                        CmdAddPrm.CommandText = StrAddFinanciacion;
                        CmdAddPrm.ExecuteNonQuery();
                       

                        myTrans.Commit();
                        MessageBox.Show("Otrosi Aprobado", "Aprobar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;                      
                        
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Aprobar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }
                }
            
        }




        private void MtdDelOtrosi()
        {
           
            int  Consecutivo;
           
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Eliminar Otrosi ", "Eliminar Otrosi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    Consecutivo = Convert.ToInt16(VarIdAdjudicacion);

                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);


                    

                    string DelOtrosi = "Update Otrosi Set Estado='Eliminado' Where Idotrosi=@IdOtrosi";


                    string AddModAdjudicacio = "insert into modadjudicacion (Select * from Adjudicacion where idadjudicacion=@IdAdjudicacion)";

                    string ModAdjudicacion = "Update Adjudicacion set Estado='Aprobado',FechaOperacion=@FechaOperacion,Usuario=@Usuario  Where IdAdjudicacion=@IdAdjudicacion";

                    
                  
                    MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                    MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                        CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@IdOtrosi", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                       
                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                        CmdAddPrm.Parameters["@IdOtrosi"].Value = VarIdOtrosi;
                        CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;


                        CmdAddPrm.CommandText = DelOtrosi;
                        CmdAddPrm.ExecuteNonQuery();                       
                       
                        CmdAddPrm.CommandText = AddModAdjudicacio;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = ModAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();    

                        myTrans.Commit();
                        MessageBox.Show("Otrosi Eliminado", "Eliminar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                        BtnValidar.Enabled = false;

                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Eliminar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }
                }
            
        }



        #endregion


        #region REGION DE EVENTOS

        private void TxtNuevoVrVenta_Enter(object sender, EventArgs e)
        {
            TxtNuevoVrVenta.BackColor = Color.White;
        }

        private void TxtNuevoVrVenta_Leave(object sender, EventArgs e)
        {
            MtdDiferencia();
            TxtNuevoVrVenta.BackColor = Color.Gainsboro;
        }

        private void TxtNuevoVrVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                MtdDiferencia();
                TxtNuevoVrVenta.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtNuevoVrVenta.Text));
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtNuevoVrVenta.Text.Length; i++)
            {
                if (TxtNuevoVrVenta.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 8)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void TxtCapitalFnc_Enter(object sender, EventArgs e)
        {
            TxtCapitalFnc.BackColor = Color.White;
        }

        private void TxtCapitalFnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtNumCuotasFnc.Focus();
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtCapitalFnc.Text.Length; i++)
            {
                if (TxtCapitalFnc.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 8)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void TxtCapitalFnc_Leave(object sender, EventArgs e)
        {
            if (TxtCapitalFnc.Text == "")
            {
                TxtCapitalFnc.Text = "0";
                TxtCuotaFncOtrosi.Text = "0";
            }
            else
                if (Convert.ToDecimal(TxtCapitalFnc.Text) == 0)
                {
                    TxtCuotaFncOtrosi.Text = "0";
                }
                else
                {
                    if (Convert.ToDecimal(TxtNumCuotasFnc.Text) == 0)
                    {
                        TxtCuotaFncOtrosi.Text = "0";
                    }
                    else
                    {
                        MtdCalculoCuotaFnc();
                    }
                }
            this.TxtCapitalFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtCapitalFnc.Text));
            MtdDiferencia();
            TxtCapitalFnc.BackColor = Color.Gainsboro;
        }        

        private void TxtNumCuotasFnc_Enter(object sender, EventArgs e)
        {
            TxtNumCuotasFnc.BackColor = Color.White;
        }

        private void TxtNumCuotasFnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtTasaFnc.Focus();
            }
            bool IsDec = false;
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void TxtNumCuotasFnc_Leave(object sender, EventArgs e)
        {
            if (TxtNumCuotasFnc.Text == "")
            {
                TxtNumCuotasFnc.Text = "0";
            }

            if (Convert.ToDouble(TxtNumCuotasFnc.Text) > 0)
            {
                MtdDiferencia();
                MtdCalculoCuotaFnc();

            }
            TxtNumCuotasFnc.BackColor = Color.Gainsboro;
        }

        private void TxtTasaFnc_Enter(object sender, EventArgs e)
        {
            TxtTasaFnc.BackColor = Color.White;
        }

        private void TxtTasaFnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbPeriodoFnc.Focus();
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtTasaFnc.Text.Length; i++)
            {
                if (TxtTasaFnc.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 8)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void TxtTasaFnc_Leave(object sender, EventArgs e)
        {
            if (TxtTasaFnc.Text == "")
            {
                TxtTasaFnc.Text = "0";             
            }

            if (Convert.ToDouble(TxtCapitalFnc.Text) == 0)
            {
              TxtCuotaFncOtrosi.Text = "0";
            }
            else
            {
                if (Convert.ToDouble(TxtNumCuotasFnc.Text) == 0)
                {
                    TxtCuotaFncOtrosi.Text = "0";
                }
                else
                {
                  MtdCalculoCuotaFnc();
                }
            }
            TxtTasaFnc.BackColor = Color.Gainsboro;
        }

        private void TxtCapitalExtra_Enter(object sender, EventArgs e)
        {
            TxtCapitalExtra.BackColor = Color.White;
        }

        private void TxtCapitalExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtNumCuotasExtra.Focus();
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtCapitalExtra.Text.Length; i++)
            {
                if (TxtCapitalExtra.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 8)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void TxtCapitalExtra_Leave(object sender, EventArgs e)
        {
            if (TxtCapitalExtra.Text == "")
            {
                TxtCapitalExtra.Text = "0";
                TxtCuotaExtraOtrosi.Text = "0";
            }

            else
                if (Convert.ToDouble(TxtCapitalExtra.Text) == 0)
                {
                    TxtCuotaExtraOtrosi.Text = "0";
                }
                else
                {
                    if (Convert.ToDouble(TxtNumCuotasExtra.Text) == 0)
                    {
                        TxtCuotaExtraOtrosi.Text = "0";
                    }
                    else
                    {
                        MtdCalculoCuotaExtra();
                    }
                }
            MtdDiferencia();
            this.TxtCapitalExtra.Text = String.Format("{0:#,##0.00; -#,##0.00;0.00}", decimal.Parse(this.TxtCapitalExtra.Text));
            TxtCapitalExtra.BackColor = Color.Gainsboro;
        }

        private void TxtNumCuotasExtra_Enter(object sender, EventArgs e)
        {
            TxtNumCuotasExtra.BackColor = Color.White;
        }

        private void TxtNumCuotasExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtTasaExtra.Focus();
            }
            bool IsDec = false;
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void TxtNumCuotasExtra_Leave(object sender, EventArgs e)
        {
            if (TxtNumCuotasExtra.Text == "")
            {
                TxtNumCuotasExtra.Text = "0";
            }
            MtdDiferencia();
            if (Convert.ToDouble(TxtNumCuotasExtra.Text) > 0)
            {
                MtdCalculoCuotaExtra();
            }
            else
            {
                TxtCuotaExtraOtrosi.Text = "0";
            }
            TxtNumCuotasExtra.BackColor = Color.Gainsboro;
        }

        private void TxtTasaExtra_Enter(object sender, EventArgs e)
        {
            
            TxtTasaExtra.BackColor = Color.White;
        }

        private void TxtTasaExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbPeriodoExtra.Focus();
            }
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtTasaExtra.Text.Length; i++)
            {
                if (TxtTasaExtra.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 8)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void TxtTasaExtra_Leave(object sender, EventArgs e)
        {
            if (TxtTasaExtra.Text == "")
            {
                TxtTasaExtra.Text = "0";
            }

            if (Convert.ToDouble(TxtCapitalExtra.Text) == 0)
            {
                TxtCuotaExtraOtrosi.Text = "0";
            }
            else
            {
                if (Convert.ToDouble(TxtNumCuotasExtra.Text) == 0)
                {
                    TxtCuotaExtraOtrosi.Text = "0";
                }
                else
                {
                    MtdCalculoCuotaExtra();
                }
            }
            TxtTasaExtra.BackColor = Color.Gainsboro;
        }

        private void ChbFnc_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbFnc.Checked == true)
            {
                PnlDatosFnc.Enabled = true;
                
            }
            else
            {
                PnlDatosFnc.Enabled = false;
                TxtCapitalFnc.Text = TxtSdoCtaFnc.Text;
                TxtNumCuotasFnc.Text = DtDatos.Rows[0][14].ToString();
                TxtTasaFnc.Text = DtDatos.Rows[0][15].ToString();
                TxtCuotaFncOtrosi.Text = DtDatos.Rows[0][16].ToString();
                BtnOk.Enabled = false;
                MtdValidarSaldos();
            }
        }

        private void ChbExtra_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbExtra.Checked == true)
            {
                PnlDatosExtra.Enabled = true;
                 
            }
            else
            {
                PnlDatosExtra.Enabled = false;
                
                TxtCapitalExtra.Text = TxtSdoCtaExt.Text;
                TxtNumCuotasExtra.Text = DtDatos.Rows[0][18].ToString();
                TxtTasaExtra.Text = DtDatos.Rows[0][19].ToString();
                TxtCuotaExtraOtrosi.Text = DtDatos.Rows[0][20].ToString();
                BtnOk.Enabled = false;
                MtdValidarSaldos();
            }
        }

        private void ChbCuotaInicial_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbCuotaInicial.Checked == true)
            {
                PnlInicial.Enabled = true;
                 
            }
            else
            {
                PnlInicial.Enabled = false;
                MtdDatosCtaIni();
                TxtValorIni.Text = TxtSdoCtaIni.Text;
                MtdValidarSaldos();
                BtnOk.Enabled = false;
            }
        }

        private void ChbContado_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbContado.Checked == true)
            {
              PnlContado.Enabled = true;

            }
            else
            {
                PnlContado.Enabled = false;
                MtdDatosContado();
                TxtVrContado.Text = TxtSaldoContado.Text;               
                MtdValidarSaldos();
                BtnOk.Enabled = false;
            }
        }

        private void DgvCtaInicial_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
             if (DgvCtaInicial.CurrentCell.ColumnIndex == 3)
            {
                SumValorInicial = 0;
                for (int i = 0; i < (DgvCtaInicial.Rows.Count); i++)
                {
                    if ((Convert.ToString(DgvCtaInicial.Rows[i].Cells[3].Value)) == "")
                    {
                        DgvCtaInicial.Rows[i].Cells[3].Value = 0;
                    }
                    else
                    {
                        SumValorInicial += Convert.ToDecimal(Convert.ToString(DgvCtaInicial.Rows[i].Cells[3].Value));
                        TxtValorIni.Text = Convert.ToString(SumValorInicial);
                        this.TxtValorIni.Text = String.Format("{0:#,##0.00; -#,##0.00;0.00}", decimal.Parse(this.TxtValorIni.Text));

                    }
                }
            }
        }

        private void DgvCtaInicial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvCtaInicial.CurrentCell.ColumnIndex == 0)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                }

            }
            else if (DgvCtaInicial.CurrentCell.ColumnIndex == 1)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                }

            }
            else if (DgvCtaInicial.CurrentCell.ColumnIndex == 2)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                }

            }

            else if (DgvCtaInicial.CurrentCell.ColumnIndex == 3)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                }

            }
        }

        private void DgvCtaInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvCtaInicial.CurrentCell.ColumnIndex == 3)
            {
                bool IsDec = false;
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
            else
            {

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
        }

        private void DgvCtaInicial_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SumValorInicial = 0;
            for (int i = 0; i < (DgvCtaInicial.Rows.Count); i++)
            {
                if ((Convert.ToString(DgvCtaInicial.Rows[i].Cells[3].Value)) == "")
                {
                    DgvCtaInicial.Rows[i].Cells[3].Value = 0;
                }
                else
                {
                    SumValorInicial += Convert.ToDecimal(Convert.ToString(DgvCtaInicial.Rows[i].Cells[3].Value));
                    TxtValorIni.Text = Convert.ToString(SumValorInicial);
                }
            }
        }

        private void TxtValorIni_TextChanged(object sender, EventArgs e)
        {
            MtdDiferencia();
        }

        private void DgvContado_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvContado.CurrentCell.ColumnIndex == 3)
            {
                SumValorContado = 0;
                for (int i = 0; i < (DgvContado.Rows.Count); i++)
                {
                    if ((Convert.ToString(DgvContado.Rows[i].Cells[3].Value)) == "")
                    {
                        DgvContado.Rows[i].Cells[3].Value = 0;
                    }
                    else
                    {
                        SumValorContado += Convert.ToDecimal(Convert.ToString(DgvContado.Rows[i].Cells[3].Value));
                        TxtVrContado.Text = Convert.ToString(SumValorContado);
                        this.TxtVrContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtVrContado.Text));

                    }
                }
            }
        }

        private void DgvContado_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvContado.CurrentCell.ColumnIndex == 0)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvContado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvContado_KeyPress);
                }

            }
            else if (DgvContado.CurrentCell.ColumnIndex == 1)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvContado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvContado_KeyPress);
                }

            }
            else if (DgvContado.CurrentCell.ColumnIndex == 2)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvContado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvContado_KeyPress);
                }

            }

            else if (DgvContado.CurrentCell.ColumnIndex == 3)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvContado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvContado_KeyPress);
                }

            }
        }

        private void DgvContado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvContado.CurrentCell.ColumnIndex == 3)
            {

                bool IsDec = false;
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
            else
            {

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
        }

        private void DgvContado_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SumValorContado = 0;
            for (int i = 0; i < (DgvContado.Rows.Count); i++)
            {
                if ((Convert.ToString(DgvContado.Rows[i].Cells[3].Value)) == "")
                {
                    DgvContado.Rows[i].Cells[3].Value = 0;
                }
                else
                {
                    SumValorContado += Convert.ToDecimal(Convert.ToString(DgvContado.Rows[i].Cells[3].Value));
                    TxtVrContado.Text = Convert.ToString(SumValorContado);
                }
            }
        }

        private void TxtVrContado_TextChanged(object sender, EventArgs e)
        {
            MtdDiferencia();
        }

        private void CmbPeriodoFnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DtpInicioFnc.Focus();
            }
        }

        private void CmbPeriodoExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DtpInicioExtra.Focus();
            }
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {

             MtdValidarAdd();

             if (CuentaErrores > 0)
             {
                 FrmMensajeError frmMensajeError = new FrmMensajeError();
                 frmMensajeError.LblErrores.DataSource = DatosdeErrores;
                 frmMensajeError.ShowDialog();
             }
             else
             {
                 DgvFinanciacion.Rows.Clear();
                 decimal SumaCapital = 0, SumaInteres = 0,SumaSdoCapital=0,SumaSdoInteres=0;
                 MtdoDatosInicial();
                 MtdoDatosCredito();
                 MtdoDatosExtraordinario();
                 MtdoNvoDatosContado();

               


                 for (int i = 0; i < (DgvFinanciacion.Rows.Count); i++)
                 {
                     SumaCapital += (Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[3].Value));
                     SumaInteres += (Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[4].Value));
                     SumaSdoCapital += (Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[6].Value));
                     SumaSdoInteres += (Convert.ToDecimal(DgvFinanciacion.Rows[i].Cells[7].Value));
                     
                 }
                 int a = DgvFinanciacion.Rows.Count - 1;
                 DgvFinanciacion.Rows[a].Cells[2].Value = "T O T A L  . .";
                 DgvFinanciacion.Rows[a].Cells[3].Value = SumaCapital;
                 DgvFinanciacion.Rows[a].Cells[4].Value = SumaInteres;
                 DgvFinanciacion.Rows[a].Cells[6].Value = SumaSdoCapital;
                 DgvFinanciacion.Rows[a].Cells[7].Value = SumaSdoInteres;
                 DgvFinanciacion.Rows[a].DefaultCellStyle.BackColor = Color.Lavender;
                 ValidacionCapital = SumaCapital;
                 BtnOk.Enabled = true;
                
             }
             DgvFinanciacion.Sort(FFecha, System.ComponentModel.ListSortDirection.Ascending);
        }       

        private void BtnEscape_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            switch (EntradaOtrosi)
            {

                case "Adicionar":
                    MtdOtrosi();
                    break;

                case "Modificar":
                    MtdModOtrosi();
                    break;

                case "Aprobar":
                    MtdAprOtrosi();
                    break;

                case "Eliminar":
                   MtdDelOtrosi();
                    break;
                default:

                    break;
            }
           
        }

        private void TxtVrContado_TextChanged_1(object sender, EventArgs e)
        {
            MtdDiferencia();
        }

        private void BtnExportarFinanciacion_Click(object sender, EventArgs e)
        {
            MtdExportarFnc();
        }


        private void BtnExportarSaldo_Click(object sender, EventArgs e)
        {
            MtdExportarCuota();
        }

        private void BtnExportarCuotasP_Click_1(object sender, EventArgs e)
        {
            MtdExportarExtracto();
        }

        #endregion


    }
}
