using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace CarteraGeneral
{
    public partial class FrmSaldoCartera : Form
    {
        public FrmSaldoCartera()
        {
            InitializeComponent();
        }
        MySqlConnection MysqlConexion = new MySqlConnection();
        string SentenciaPrs;
        ClsIdentificacion conexion = new ClsIdentificacion();
        private void FrmSaldoCartera_Load(object sender, EventArgs e)
        {
            this.rptsaldocarteraTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
            this.rptsaldocarteraTableAdapter.Fill(this.CarteraGeneralDataSet.rptsaldocartera);
            
        }


//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdInsertarProyeccion
//===================================================================================================================================================
        public void MtdInsertarProyeccion()
        {

            MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {


                myCommand.CommandText = "Delete From rptsaldocartera";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO rptsaldocartera (" + SentenciaPrs + ")";
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                mtdinforme();

            }
            catch (MySqlException ex)
            {
                myTrans.Rollback();
                MessageBox.Show(ex.Message + "", "" + "Adicionar", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                MysqlConexion.Close();
            }

        }
//===================================================================================================================================================
// F I N   M E T O D O   MtdInsertarProyeccion
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   mtdinforme
//===================================================================================================================================================
        public void mtdinforme()
        {
            string Fecha = String.Format("{0:dd-MM-yyyy}", DtpFechaFin.Value);
            try
            {
                this.rptsaldocarteraTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("Titulo", "SALDO GENERAL DE CARTERA A CORTE "+Fecha) ;
               this.rptsaldocarteraTableAdapter.Fill(this.CarteraGeneralDataSet.rptsaldocartera);
                this.reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception e)
            {
                MessageBox.Show("Se Presento el Sgte Error:  " + e.Message, "Salgo Gral Cartera", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }      
//===================================================================================================================================================
// F I N   M E T O D O   mtdinforme
//===================================================================================================================================================


        private void BtnCalcular_Click(object sender, EventArgs e)
        {

            string Fecha = String.Format("{0:d/M/yyyy}", DtpFechaFin.Value);
            SentenciaPrs = " Select A1.IdAdjudicacion,c.Identificacion Cliente,c.IdInmueble," +
             " sum(Capital)Capital,Sum(Interes)Interes,Sum(Cuota)Cuota ,c.Tipocartera TipoCartera " +
            " From " +
            " ( " +
            " Select IdAdjudicacion,sum(Capital)Capital,Sum(Interes)Interes,Sum(Cuota)Cuota From financiacion " +
            " group by idadjudicacion " +
            " UNION " +
            " Select IdAdjudicacion,sum(-Capital)Capital,Sum(-InteresCte)Interes,Sum(-capital-InteresCte)Cuota From recaudos " +
            " where estado='aprobado' And Fecha <= '" + conexion.MtdVldFchPed(DtpFechaFin.Value) + "' " +
            " group by idadjudicacion " +
            " ) " +
            " A1 " +
            " join 004cnsadjudica c " +
            " on c.idadjudicacion=A1.idadjudicacion " +
            " where estado='Aprobado' " +
            " group by idadjudicacion ";

            MtdInsertarProyeccion();
            mtdinforme();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
