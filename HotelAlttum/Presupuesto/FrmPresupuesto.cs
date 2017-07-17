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
using System.Threading;
namespace CarteraGeneral
{
    public partial class FrmPresupuesto : Form
    {
        public FrmPresupuesto()
        {
            InitializeComponent();
            //Apuntamos el hilo al metodo que consulta los datos y hace las operaciones.    
           
        }


        System.Data.DataTable DtParametros = new System.Data.DataTable();
        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
        System.Data.DataTable DtListado = new System.Data.DataTable();
        System.Data.DataTable DtPresupuesto = new System.Data.DataTable();
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        string  NomTabla;
        String SentenciaPrs;
        double SumaCuota;
        double sumaMora;
        double Cuenta = 0;
        int OpcionMes = 0;
        string FechaCorte;
        string   StrInteresCte , StrInteresMora ,  StrPeriodo,  StrDiaMora , StrDecimales;


//===================================================================================================================================================
// I N I C I O    R E G I O N  D E   E V E N T O S
//=================================================================================================================================================== 
        #region REGION DE EVENTOS


//===================================================================================================================================================
// I N I C I O    E V E N T O   L O A D 
//=================================================================================================================================================== 
        private void Form1_Load(object sender, EventArgs e)
        {
            DtParametros = NuevoClsIdentificacion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
            StrInteresCte = DtParametros.Rows[0][0].ToString();
            StrInteresMora = DtParametros.Rows[0][1].ToString();
            StrPeriodo = DtParametros.Rows[0][2].ToString();
            StrDiaMora = DtParametros.Rows[0][3].ToString();
            StrDecimales = DtParametros.Rows[0][5].ToString();
            BtnMontar.Enabled = NuevoClsIdentificacion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "902");
            DtPresupuesto.Columns.Add("CuotaNum", typeof(string));
            DtPresupuesto.Columns.Add("Fecha", typeof(DateTime));
            DtPresupuesto.Columns.Add("IdAdjudicacion", typeof(string));
            DtPresupuesto.Columns.Add("UltPago", typeof(DateTime));
            DtPresupuesto.Columns.Add("Cliente", typeof(string));
            DtPresupuesto.Columns.Add("Concepto", typeof(string));
            DtPresupuesto.Columns.Add("Capital", typeof(decimal));
            DtPresupuesto.Columns.Add("Interes", typeof(decimal));
            DtPresupuesto.Columns.Add("Cuota", typeof(decimal));
            DtPresupuesto.Columns.Add("DiasCpt", typeof(double));
            DtPresupuesto.Columns.Add("Diaslqd", typeof(double));
            DtPresupuesto.Columns.Add("Mora", typeof(decimal));
            DtPresupuesto.Columns.Add("TipoCartera", typeof(string));
            
        }
//===================================================================================================================================================
// F I N A L   E V E N T O   L O A D 
//=================================================================================================================================================== 


//===================================================================================================================================================
//I N I C I O   E V E N T O BtnMontar_Click
//===================================================================================================================================================
        private void BtnMontar_Click(object sender, EventArgs e)
        {
            MtdNombreTabla();
            DialogResult montarp;
            montarp = MessageBox.Show("Esta seguro de Adicionar " + NomTabla, "Adicionar Presupuesto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (montarp == DialogResult.Yes)
            {
                MtdNombreTabla();
                MtdMontarPrs();
            }
        }
//===================================================================================================================================================
// F I N A L   E V E N T O BtnMontar_Click
//===================================================================================================================================================


        private void button1_Click(object sender, EventArgs e)
        {
            BtnCalcular.Enabled = false;
            BtnCalcular.Cursor = Cursors.AppStarting;            
           
            FechaCorte = "'" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "'";
            Cuenta = Convert.ToDouble(TxtCuotaMax.Text);            
            MtdPrespuesto();
            DatosMora();
            BtnCalcular.Enabled = true;
            BtnCalcular.Cursor = Cursors.Default;          
        }


        private void BtnExportar_Click(object sender, EventArgs e)
        {
            BtnExportar.Enabled = false;
            BtnExportar.Cursor = Cursors.AppStarting;
            BtnExportar.Text = "Exportando";
            exporta_a_excel();
            BtnExportar.Enabled = true;
            BtnExportar.Cursor = Cursors.Default;
            BtnExportar.Text = "Exportar";
        }

        private void TxtCuotaMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtCuotaMax.Focus();
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

        private void TxtCuotaMax_Leave(object sender, EventArgs e)
        {
            if (TxtCuotaMax.Text == "")
            {
                TxtCuotaMax.Text = "5";
            }
        }

        private void button1_Salir_1(object sender, EventArgs e)
        {
            Close();
        }


        #endregion
//===================================================================================================================================================
// F I N AL   R E G I O N  D E   E V E N T O S
//=================================================================================================================================================== 
  



//===================================================================================================================================================
//I N I C I O   R E G I O N   D E   M E T O D O S
//===================================================================================================================================================
         #region REGION DE METODOS


//===================================================================================================================================================
//I N I C I O   M E T O D O   E X P O R T A R   A    E X C E L 
//===================================================================================================================================================
        public void exporta_a_excel()
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            foreach (DataGridViewColumn col in DgvPresupuesto.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }

            int rowIndex = 0;

            foreach (DataGridViewRow row in DgvPresupuesto.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvPresupuesto.Columns)
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
//F I N A L    M E T O D O   E X P O R T A R    A     E X C E L 
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   M E T O D O   P R E S U P U E S T O
//===================================================================================================================================================
    public void MtdPrespuesto()
        {   

            if (CmbTipoCartera.Text == "Administrativa")
            {             
     
                SentenciaPrs = NuevoClsIdentificacion.Mtdscrip(DtpFechaCorte.Value,DtpFechaFin.Value) + " where Tipo.Estado ='Aprobado'And car.cuota>5 and Tipo.tipocartera= 'Administrativa'   order by Cliente,IdAdjudicacion,concepto,cuotanum";
                DtListado = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaPrs);
                MtdSelecionDatos();
                MtdDatosRecaudos();
            }
            else
            if (CmbTipoCartera.Text == "Comercial")
            {
                SentenciaPrs = NuevoClsIdentificacion.Mtdscrip(DtpFechaCorte.Value, DtpFechaFin.Value) + " where Tipo.Estado ='Aprobado'And car.cuota>5 and Tipo.tipocartera= 'Comercial' order by Cliente,IdAdjudicacion,concepto,cuotanum";
                DtListado = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaPrs);
                MtdSelecionDatos();
                MtdDatosRecaudos();
            }
            else
            if (CmbTipoCartera.Text == "Todas")
            {
                SentenciaPrs = NuevoClsIdentificacion.Mtdscrip(DtpFechaCorte.Value, DtpFechaFin.Value) + " where car.cuota>0 and Tipo.Estado !='Desistido' order by Cliente,IdAdjudicacion,concepto,cuotanum";
                DtPresupuesto = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaPrs);                   
                MtdDatosRecaudos();
            }
            else
                      
            if (CmbTipoCartera.Text == "Otros")
            {
                SentenciaPrs = Mtdscrip() + " where car.cuota>0 and Tipo.tipocartera= 'Comercial' and Car.Concepto!='CI' and a.Estado !='Desistido' order by Cliente,IdAdjudicacion,concepto,cuotanum";
                DtListado = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaPrs);
                MtdSelecionDatos();
                MtdDatosRecaudos();
            }
            else
            {
                 MessageBox.Show("Verificar Tipo de Cartera");
            }
             
        } 
//===================================================================================================================================================
//F I N A L   M  E T O D O   P R E S E U P U E S T O
//===================================================================================================================================================




//===================================================================================================================================================
//I N I C I O   M E T O D O   S C R I P
//===================================================================================================================================================
     private string Mtdscrip()

      {
          SentenciaPrs =
            "select " +
            "Car.CuotaNum, " +
            "Car.Fecha, " +
            "Car.IdAdjudicacion, " +
            "Car.FechaRec as UltPago," +
            "A.Identificacion as Cliente, "+
            "Car.Concepto, " +
            "Car.Capital, " +
            "Car.Interes, " +
            "Car.Cuota, " +
            "Car.DiasCpt, " +
            "Car.Diaslqd, "+
            "Car.Mora, "+
            "tipo.TipoCartera  " +

            " from " +
              " ( " +
              "SELECT " +
              "rr.Id, " +
              "rr.Idadjudicacion, " +
              "rr.Concepto, " +
              "rr.CuotaNum, " +
              " Max(rr.Fecha)Fecha, " +
              "if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec))FechaRec, " +
              "sum(rr.Capital)Capital, " +
              "sum(rr.Interes)Interes, " +
              "sum(rr.cuota)Cuota, " +
              " if(DATEDIFF("  +  FechaCorte + ",rr.fecha)<=0,0, DATEDIFF("  +  FechaCorte + ",rr.fecha))DiasCpt,  " +
              "sum(rr.SaldointeMora)SaldoInteMora," +
              "if((rr.Fecha > max(rr.fechaRec)), (if(DATEDIFF("  +  FechaCorte + ",rr.fecha)<=0,0, DATEDIFF("  +  FechaCorte + ",rr.fecha))), " +
              "(if(DATEDIFF("  +  FechaCorte + ",if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec)))<=0,0, DATEDIFF("  +  FechaCorte + ",if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec))))))DiasLqd, " +
              "if(rr.concepto='CI',0,round((sum(rr.cuota) * "+ 
              "if((rr.Fecha > max(rr.fechaRec)), (if(DATEDIFF("  +  FechaCorte + ",rr.fecha)<=0,0, DATEDIFF("  +  FechaCorte + ",rr.fecha))), " +
              "(if(DATEDIFF("  +  FechaCorte + ",if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec)))<=0,0, DATEDIFF("  +  FechaCorte + ",if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec))))))"+
              "*" + StrInteresMora + ")/36000,"+StrDecimales +")) Mora, " +
              " rr.tipo " +
              "from " +

              //Region rr
          #region rr
              
              "( " +

              "SELECT IdCta AS Id," +
              "f.IdAdjudicacion ," +
              "'FN' AS Concepto," +
              "f.NumCuota CuotaNum ," +
              "f.Fecha ," +
              "null FechaRec," +
              "f.Capital ," +
              "f.Interes AS Interes  ," +
              "f.Cuota," +
              "0 AS InteresMora," +
              "0 AS InteresCnd," +
              "0 AS MoraCalc," +
              "0 SaldoInteMora," +
              "'Cta' as Tipo " +
              "FROM financiacion f " +
              "WHERE F.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value) + "'" +

             

              "UNION " +

              "SELECT " +
              "IdFinanciacion AS Id, " +
              "r.IdAdjudicacion , " +
              "r.Concepto AS concepto, " +
              "r.NumCuota AS CuotaNum, " +
              "null fecha, " +
              "r.Fecha FechaRec, " +
              "Sum(-r.Capital) AS Capital, " +
              "Sum(-r.InteresCte) AS InteresCte, " +
              "sum(-(r.Capital) - r.InteresCte) AS Cuota, " +
              "sum(-r.InteresMora) AS InteresMora, " +
              "sum(r.InteresCnd) AS InteresCnd, " +
              "sum(r.VrMoraCalc) AS MoraCalc, " +
              "sum((r.VrMoraCalc - r.InteresCnd) - r.InteresMora) AS SaldoIntMora, " +
              "'Rcd' as Tipo " +
              "FROM recaudos r " +
              "where r.Estado = 'Aprobado' and r.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' group by id "  +
              " UNION " +

               "SELECT IdFinanciacion AS Id, " +
              "d.IdAdjudicacion AS IdAdjudicacion, " +
              "d.Concepto AS concepto, " +
              "d.NumCuota AS CuotaNum, " +
              "null Fecha, " +
              "d.Fecha AS FechaRec, " +
              "sum(-d.Capital) AS Capital, " +
              "sum(-d.Interes) AS InteresCte, " +
              "sum(-d.Cuota) as Cuota, " +
              "0 AS InteresMora, " +
              "0 AS InteresCnd, " +
              "0 AS MoraCalc, " +
              "0 AS SaldoInteMora, " +
              "'Dto' as Tipo " +
              "FROM descuento d " +
              "where   d.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' group by id " +
              "UNION " +



              "SELECT IdFinanciacion AS Id, " +
              "d.IdAdjudicacion AS IdAdjudicacion, " +
              "d.Concepto AS concepto, " +
              "d.NumCuota AS CuotaNum, " +
              "null Fecha, " +
              "d.Fecha AS FechaRec, " +
              "sum(-d.Capital) AS Capital, " +
              "sum(-d.Interes) AS InteresCte, " +
              "sum(-d.Cuota) as Cuota, " +
              "0 AS InteresMora, " +
              "0 AS InteresCnd, " +
              "0 AS MoraCalc, " +
              "0 AS SaldoInteMora, " +
              "'Can' as Tipo " +
              "FROM Canje d " +
               "where   d.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' group by id " +

              ")RR " +
              "group by rr.id " +
          #endregion
              //Region rr

             ")Car " +
                         

              "join " +


          #region Tipo

               "( " +
              "select IdAdjudicacion, if((sum(`ss`.`Cuota`) <= 0),'Administrativa','Comercial') AS TipoCartera " +
              "from " +
              "( " +              
              "SELECT CONCAT('CI',i.CuotaNum,UCASE(i.IdAdjudicacion)) AS Id " +
              ",i.IdAdjudicacion , " +
              "'CI' AS Concepto, " +
              "i.CuotaNum , " +
              "i.Fecha , " +
              "null FechaRec, " +
              "i.Valor AS Capital, " +
              "0 AS Interes  , " +
              "i.Valor AS Cuota, " +
              "0 AS InteresMora, " +
              "0 AS InteresCnd, " +
              "0 AS MoraCalc, " +
              "0 SaldoInteMora , " +
              "'Cta' as Tipo " +
              "FROM cuotainicial i " +
              "WHERE i.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value) + "'" +

              "UNION " +

              "SELECT " +
              "CONCAT(r.Concepto,r.NumCuota,UCASE(r.IdAdjudicacion)) AS Id, " +
              "r.IdAdjudicacion , " +
              "r.Concepto AS concepto, " +
              "r.NumCuota AS CuotaNum, " +
              "null fecha, " +
              "r.Fecha FechaRec, " +
              "Sum(-r.Capital) AS Capital, " +
              "Sum(-r.InteresCte) AS InteresCte, " +
              "sum(-(r.Capital) - r.InteresCte) AS Cuota, " +
              "sum(-r.InteresMora) AS InteresMora, " +
              "sum(r.InteresCnd) AS InteresCnd, " +
              "sum(r.VrMoraCalc) AS MoraCalc, " +
              "sum((r.VrMoraCalc - r.InteresCnd) - r.InteresMora) AS SaldoIntMora, " +
              "'Rcd' as Tipo " +
              "FROM recaudos r " +
              "where r.Estado = 'Aprobado' And r.concepto='CI' and r.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' group by id " +
              "UNION " +  

              "SELECT CONCAT(d.Concepto,d.CuotaNum,UCASE(d.IdAdjudicacion)) AS Id, " +
              "d.IdAdjudicacion AS IdAdjudicacion, " +
              "d.Concepto AS concepto, " +
              "d.CuotaNum AS CuotaNum, " +
              "null Fecha, " +
              "d.Fecha AS FechaRec, " +
              "sum(-d.Capital) AS Capital, " +
              "sum(-d.Interes) AS InteresCte, " +
              "sum(-d.Cuota) as Cuota, " +
              "0 AS InteresMora, " +
              "0 AS InteresCnd, " +
              "0 AS MoraCalc, " +
              "0 AS SaldoInteMora, " +
              "'Dto' as Tipo " +
              "FROM descuento d " +
              "where d.concepto='CI'AND  d.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' group by id " +
              "UNION " +

              "SELECT CONCAT(d.Concepto,d.CuotaNum,UCASE(d.IdAdjudicacion)) AS Id, " +
              "d.IdAdjudicacion AS IdAdjudicacion, " +
              "d.Concepto AS concepto, " +
              "d.CuotaNum AS CuotaNum, " +
              "null Fecha, " +
              "d.Fecha AS FechaRec, " +
              "sum(-d.Capital) AS Capital, " +
              "sum(-d.Interes) AS InteresCte, " +
              "sum(-d.Cuota) as Cuota, " +
              "0 AS InteresMora, " +
              "0 AS InteresCnd, " +
              "0 AS MoraCalc, " +
              "0 AS SaldoInteMora, " +
              "'Can' as Tipo " +
              "FROM Canje d " +
               "where  d.concepto='CI' And d.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' group by id " +

              ")ss " +         

              "group by ss.IdAdjudicacion " +


              ")Tipo " +

          #endregion


            "on tipo.idadjudicacion=car.IdAdjudicacion " +
            " Join 004CnsAdjudica A on A.Idadjudicacion = Car.IdAdjudicacion";

return SentenciaPrs;
      }
//===================================================================================================================================================
//F I N AL  M E T O D O   S C R I P
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O    M E T O D O    D A T O S    R E C A U D O S
//=================================================================================================================================================== 
        public void MtdDatosRecaudos()
            {
                DgvPresupuesto.Rows.Clear();


            for (int i = 0; i < (DtPresupuesto.Rows.Count); i++)
            {
                DgvPresupuesto.Rows.Add(true,DtPresupuesto.Rows[i][2], DtPresupuesto.Rows[i][4], DtPresupuesto.Rows[i][5], DtPresupuesto.Rows[i][0], DtPresupuesto.Rows[i][1], DtPresupuesto.Rows[i][3],
                DtPresupuesto.Rows[i][6], DtPresupuesto.Rows[i][7], DtPresupuesto.Rows[i][8], DtPresupuesto.Rows[i][9], DtPresupuesto.Rows[i][10], DtPresupuesto.Rows[i][11], DtPresupuesto.Rows[i][12]);
            }

            MtdSuma();

        }
//===================================================================================================================================================
// F I N A L    M E T O D O    D A T O S    R E C A U D O S
//===================================================================================================================================================


        public void MtdSuma()
        {



            int Micuenta = 0,Contador=0;
            SumaCuota = 0;
            sumaMora = 0;
            string Adj = "";

            for (int i = 0; i < (DgvPresupuesto.Rows.Count); i++)
            {
                if (Convert.ToBoolean(DgvPresupuesto.Rows[i].Cells[0].Value) == true)
                {
                    Contador = Contador + 1;
                    SumaCuota += (Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[9].Value));
                    sumaMora += (Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[12].Value));
                    DgvPresupuesto.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    DgvPresupuesto.Rows[i].DefaultCellStyle.BackColor = Color.Brown;
                }

                if ((Convert.ToString(DgvPresupuesto.Rows[i].Cells[1].Value)) == Adj)
                {
                    Micuenta = Micuenta + 1;
                }
                else
                {
                    Adj = Convert.ToString(DgvPresupuesto.Rows[i].Cells[1].Value);
                    Micuenta = 1;

                }

                if (Micuenta > Cuenta)
                {
                    DgvPresupuesto.Rows[i].DefaultCellStyle.BackColor = Color.Brown;
                }

            }
            TxtRegistros.Text = Convert.ToString(Contador);
            TxtTotalSaldo.Text = Convert.ToString(SumaCuota);
            TxtMora.Text = Convert.ToString(sumaMora);
            TxtTotalPrs.Text = Convert.ToString(SumaCuota + sumaMora);
            this.TxtTotalSaldo.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtTotalSaldo.Text));
            this.TxtMora.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtMora.Text));
            this.TxtTotalPrs.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtTotalPrs.Text));

            if ((SumaCuota > 0) & (CmbTipoCartera.Text == "Administrativa"))
            {
                LblMontar.Visible = true;
                BtnMontar.Visible = true;
            }

            else
            {
                LblMontar.Visible = false;
                BtnMontar.Visible = false;
            }
        
        }


//===================================================================================================================================================
// I N I C I O    M E T O D O    S E L E C C I O N   D A T O S 
//=================================================================================================================================================== 
    private void MtdSelecionDatos()
        {
            
            DtPresupuesto.Rows.Clear();
            int Micuenta = 0;
            string Adj = "";
            for (int i = 0; i < (DtListado.Rows.Count); i++)
            {


                if ((Convert.ToString(DtListado.Rows[i][2])) == Adj)
                {
                    Micuenta = Micuenta + 1;
                }
                else
                {
                    Adj = Convert.ToString(DtListado.Rows[i][2]);
                    Micuenta = 1;
                }

                if (Micuenta <= Cuenta)
                {
                    DtPresupuesto.Rows.Add(DtListado.Rows[i][0], DtListado.Rows[i][1], DtListado.Rows[i][2],DtListado.Rows[i][3],DtListado.Rows[i][4],
                    DtListado.Rows[i][5],DtListado.Rows[i][6],DtListado.Rows[i][7],DtListado.Rows[i][8],DtListado.Rows[i][9],DtListado.Rows[i][10],
                    DtListado.Rows[i][11],DtListado.Rows[i][12]);
                }                
            }       
        }
//===================================================================================================================================================
// F I N A L    M E T O D O     S E L E C C I O N   D A T O S
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O    M E T O D O   N O M B R E   D E   T A B L A
//=================================================================================================================================================== 
    private void MtdNombreTabla()
    {

        OpcionMes = DtpFechaFin.Value.Month;
      
        switch (OpcionMes)
        {
            case 1:
                NomTabla = "PresupuestoEnero";
                break;

            case 2:

                NomTabla = "PresupuestoFebrero";

                break;

            case 3:
                NomTabla = "PresupuestoMarzo";
                break;

            case 4:
                NomTabla = "PresupuestoAbril";
                break;
            case 5:
                NomTabla = "PresupuestoMayo";
                break;

            case 6:
                NomTabla = "PresupuestoJunio";
                break;

            case 7:
                NomTabla = "PresupuestoJulio";
                break;

            case 8:
                NomTabla = "PresupuestoAgosto";
                break;

            case 9:
                NomTabla = "PresupuestoSeptiembre";
                break;

            case 10:
                NomTabla = "PresupuestoOctubre";
                break;

            case 11:
                NomTabla = "PresupuestoNoviembre";
                break;

            case 12:
                NomTabla = "PresupuestoDiciembre";
                break;

            default:

                break;
        }
        
    }
//===================================================================================================================================================
// F I N A L    M E T O D O    N O M B R E   D E   T A B L A
//===================================================================================================================================================






//===================================================================================================================================================
// I N I C I O    M E T O D O    M O N T A R   P R E S U P U E S T O
//=================================================================================================================================================== 
     private void MtdMontarPrs()
    {
        MysqlConexion.Open();
        MySqlCommand myCommand = MysqlConexion.CreateCommand();
        MySqlTransaction myTrans;
    
        myTrans = MysqlConexion.BeginTransaction();
        myCommand.Connection = MysqlConexion;
        myCommand.Transaction = myTrans;

        string SentenciaDelPrs = "Delete from " + NomTabla;
   

        try
        {            
                   myCommand.CommandText = SentenciaDelPrs;
                   myCommand.ExecuteNonQuery();       
            
           

        for (int i = 0; i < DgvPresupuesto.Rows.Count; i++)
        {

            if (Convert.ToBoolean(DgvPresupuesto.Rows[i].Cells[0].Value) == true)
            {

                myCommand.CommandText = " Insert into " + NomTabla + " Values (Ucase('" +

                (Convert.ToString(DgvPresupuesto.Rows[i].Cells[3].Value)) + (Convert.ToString(DgvPresupuesto.Rows[i].Cells[4].Value)) +"ADJ"+ (Convert.ToString(DgvPresupuesto.Rows[i].Cells[1].Value)) + "'),'" +
                (Convert.ToString(DgvPresupuesto.Rows[i].Cells[1].Value)) + "','" +
                (Convert.ToString(DgvPresupuesto.Rows[i].Cells[2].Value)) + "','" +
                (Convert.ToString(DgvPresupuesto.Rows[i].Cells[3].Value)) + "'," +
                (Convert.ToInt16(DgvPresupuesto.Rows[i].Cells[4].Value)) + ",'" +
                NuevoClsIdentificacion.MtdVldFchPed((Convert.ToDateTime(DgvPresupuesto.Rows[i].Cells[5].Value))) + "','" +
                NuevoClsIdentificacion.MtdVldFchPed((Convert.ToDateTime(DgvPresupuesto.Rows[i].Cells[6].Value))) + "'," +
                (Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[7].Value)) + "," +
                (Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[8].Value)) + "," +
                (Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[9].Value)) + "," +
                (Convert.ToInt16(DgvPresupuesto.Rows[i].Cells[10].Value)) + "," +
                (Convert.ToInt16(DgvPresupuesto.Rows[i].Cells[11].Value)) + "," +
                (Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[12].Value)) + ",'" +
                (Convert.ToString(DgvPresupuesto.Rows[i].Cells[13].Value)) + "','"+FrmLogeo.Usuario+"','"+NuevoClsIdentificacion.MtdVldFchPed(DateTime.Now.Date)+"')";

                myCommand.ExecuteNonQuery();

            }
            }

        myTrans.Commit();
        MessageBox.Show("Presupuesto Adicionado","Adicion de Presupuesto");
        BtnMontar.Enabled = false;
        }

        catch (Exception e)
            {                
                MessageBox.Show ( "Se presento el Sgte Error" + e.Message + " Esta Transaccion no quedo registrada.");
            }
            finally
            {
                MysqlConexion.Close();
            }
    }

     private void TxtTotalPrs_TextChanged(object sender, EventArgs e)
     {
        
     }
//===================================================================================================================================================
// F I N A L    M E T O D O    D A T O S    S E L E C C I O N   D A T O S
//===================================================================================================================================================

        #endregion
//===================================================================================================================================================
// F I N A L   R E G I O N   D E   M E T O D O S
//===================================================================================================================================================


     public void DatosMora()
     {
         double Dias0=0, Dias30=0, Dias60=0, Dias90=0, Dias120=0, Dias150=0;

         for (int i = 0; i < (DgvPresupuesto.Rows.Count); i++)
         {
             if (((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) >=0 )&((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) <=30 )&(Convert.ToBoolean(DgvPresupuesto.Rows[i].Cells[0].Value) == true))
             {
                Dias0 +=(Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[9].Value));
             }

             if (((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) >= 31) & ((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) <= 60) & (Convert.ToBoolean(DgvPresupuesto.Rows[i].Cells[0].Value) == true))
             {
                 Dias30 += Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[9].Value);
             }

             if (((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) >= 61) & ((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) <= 90) & (Convert.ToBoolean(DgvPresupuesto.Rows[i].Cells[0].Value) == true))
             {
                 Dias60 += Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[9].Value);
             }

             if (((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) >= 91) & ((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) <= 120) & (Convert.ToBoolean(DgvPresupuesto.Rows[i].Cells[0].Value) == true))
             {
                 Dias90 += Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[9].Value);
             }

             if (((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) >= 121) & ((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) <= 150) & (Convert.ToBoolean(DgvPresupuesto.Rows[i].Cells[0].Value) == true))
             {
                 Dias120 += Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[9].Value);
             }
             if (((Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[10].Value)) >= 151)&(Convert.ToBoolean(DgvPresupuesto.Rows[i].Cells[0].Value) == true)) 
             {
                 Dias150 += Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[9].Value);
             }

         }
         TxtDias0.Text = Convert.ToString(Dias0);
         TxtDias30.Text = Convert.ToString(Dias30);
         TxtDias60.Text = Convert.ToString(Dias60);
         TxtDias90.Text = Convert.ToString(Dias90);
         TxtDias120.Text = Convert.ToString(Dias120);
         TxtMas150.Text = Convert.ToString(Dias150);
         this.TxtDias0.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtDias0.Text));
         this.TxtDias30.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtDias30.Text));
         this.TxtDias60.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtDias60.Text));
         this.TxtDias90.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtDias90.Text));
         this.TxtDias120.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtDias120.Text));
         this.TxtMas150.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtMas150.Text));
     }

     private void DgvPresupuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
     {

       
         // Detecta si se ha seleccionado el header de la grilla
         //
         if (e.RowIndex == -1)
             return;

         if (DgvPresupuesto.Columns[e.ColumnIndex].Name == "Seleccion")
         {

             //
             // Se toma la fila seleccionada
             //
             DataGridViewRow row = DgvPresupuesto.Rows[e.RowIndex];

             //
             // Se selecciona la celda del checkbox
             //
             DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;

             if (Convert.ToBoolean(cellSelecion.Value))
             {
                 // DgvPresupuesto.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSteelBlue;
             }
             else
             {
                 //DgvPresupuesto.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Violet;
                 }
                 for (int i = 0; i < (DgvPresupuesto.Rows.Count); i++)
                 {
                     // VrPagosProgramados += Convert.ToDouble(DgvPresupuesto.Rows[i].Cells[7].Value);

                 }
            

         }
     }
     

     private void DgvPresupuesto_CurrentCellDirtyStateChanged(object sender, EventArgs e)
     {
         MtdSuma();
         DatosMora();
         if (DgvPresupuesto.IsCurrentCellDirty)
         {
             DgvPresupuesto.CommitEdit(DataGridViewDataErrorContexts.Commit);
         }
     }



     private void MtdClip()
     {
     }

      
     }   


    }

