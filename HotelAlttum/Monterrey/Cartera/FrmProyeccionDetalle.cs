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
    public partial class FrmProyeccionDetalle : Form
    {
        public FrmProyeccionDetalle()
        {
            InitializeComponent();
        }
        MySqlConnection MysqlConexion = new MySqlConnection();
        double CuentaErrores;
        List<string> DatosdeErrores = new List<string>();
        String SentenciaPrs, StrConexion;
     ClsIdentificacion conexion = new ClsIdentificacion();
        private void FrmProyeccionDetalle_Load(object sender, EventArgs e)
        {
            this.rptproyecciondetalleTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
            this.rptproyecciondetalleTableAdapter.Fill(this.CarteraGeneralDataSet.rptproyecciondetalle);
        
        }


//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdInsertarProyeccion
//===================================================================================================================================================
        public void MtdInsertarProyeccion()
        {

            MysqlConexion.ConnectionString =FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {


                myCommand.CommandText = "Delete From rptproyecciondetalle";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO rptproyecciondetalle (" + SentenciaPrs + ")";
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
            try
            {
                this.rptproyecciondetalleTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
                ReportParameter[] parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("Obra", "INFORME CARTERA PROYECTADA PROYECTO   DE LA CARTERA " + CmbTipoCartera.Text.ToUpper());
                this.rptproyecciondetalleTableAdapter.Fill(this.CarteraGeneralDataSet.rptproyecciondetalle);
                this.reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception e)
            {
                MessageBox.Show("Se Presento el Sgte Error:  " + e.Message, "Adicionar Presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
//===================================================================================================================================================
// F I N   M E T O D O   mtdinforme
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdValidarAdd
//===================================================================================================================================================
        private void MtdValidarAdd()
        {
            try
            {
                DatosdeErrores.Clear();
                CuentaErrores = 0;

               

                if (CmbTipoCartera.Text == "")
                {
                    CuentaErrores = CuentaErrores + 1;
                    DatosdeErrores.Add("Falta Seleccionar Tipo Cartera");
                }

                if (DtpFechaCorte.Value == DtpFechaFin.Value)
                {
                    CuentaErrores = CuentaErrores + 1;
                    DatosdeErrores.Add("Falta Revisar Fecha");
                }
                if (DtpFechaCorte.Value > DtpFechaFin.Value)
                {
                    CuentaErrores = CuentaErrores + 1;
                    DatosdeErrores.Add("Falta Revisar Fecha");
                }
            }

            catch (Exception e)
            {
                MessageBox.Show("Se Presento el Sgte Error:  " + e.Message, "Adicionar Presupuesto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
//===================================================================================================================================================
// F I N   M E T O D O   DMtdValidarAdd
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O    D A T O S    O B  R A
//===================================================================================================================================================
        public void MtdDatosObra()
        {

            //System.Data.DataTable MisUsuarios = conexion.MtdBuscarDataset("SELECT * From Obras");
            //var query = (
            //from Nusuario in MisUsuarios.AsEnumerable()
            //where Nusuario.Field<string>("NombreProyecto") == CmbObra.Text

            //select new
            //{
            //    nombreProyecto = Nusuario.Field<string>("NombreProyecto"),
            //    fuente = Nusuario.Field<string>("Fuente"),
            //    BaseDatos = Nusuario.Field<string>("BaseDatos"),
            //    InteresMora = Nusuario.Field<decimal>("InteresMora"),
            //    Periodo = Nusuario.Field<int>("Periodo"),
            //    LqdMora = Nusuario.Field<int>("LqdMora"),
            //    Conexion = Nusuario.Field<string>("Conexion"),
            //    Id = Nusuario.Field<string>("Id"),
            //});

            //foreach (var order in query)
            //{

            //    StrConexion = order.Conexion;

            //}


        }
//===================================================================================================================================================
// F I N A L    M E T O D O  D A T O S   O B R A
//===================================================================================================================================================



        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            MtdValidarAdd();
            MtdDatosObra();
            if (CuentaErrores > 0)
            {
                FrmMensajeError frmMensajeError = new FrmMensajeError();
                frmMensajeError.LblErrores.DataSource = DatosdeErrores;
                frmMensajeError.ShowDialog();
            }
            else
            {

                BtnCalcular.Enabled = false;
                BtnCalcular.Cursor = Cursors.AppStarting;

                MtdCalcular();

                BtnCalcular.Enabled = true;
                BtnCalcular.Cursor = Cursors.Default;
            }
        }

        private void MtdCalcular()
        {
            if (CmbTipoCartera.Text == "Todos")
            {
                string FechaCorte = "'" + conexion.MtdVldFchPed(DtpFechaCorte.Value) + "'";
                string FechaFinal = "'" + conexion.MtdVldFchPed(DtpFechaFin.Value) + "'";

                SentenciaPrs = "select c.Fecha,eXTRACT(year from c.fecha)Ano,extract(month from c.fecha)Mes,c.Concepto," +
                " c.Capital,c.Interes,c.Cuota ,t.nombrecompleto as Cliente from Financiacion c " +
                " join adjudicacion a " +
                " on a.idadjudicacion=c.idadjudicacion " +
                " join Contabilidad_alttum.terceros t " +
                " on t.idtercero=a.idtercero1 where a.estado ='Aprobado'   and c.Fecha >= " + FechaCorte + " and c.Fecha <= " + FechaFinal;
            }
            else
            {
                string FechaCorte = "'" + conexion.MtdVldFchPed(DtpFechaCorte.Value) + "'";
                string FechaFinal = "'" + conexion.MtdVldFchPed(DtpFechaFin.Value) + "'";

                SentenciaPrs = "select c.Fecha,eXTRACT(year from c.fecha)Ano,extract(month from c.fecha)Mes,c.Concepto," +
                " c.Capital,c.Interes,c.Cuota ,t.nombrecompleto as Cliente from Financiacion c " +
                " join adjudicacion a " +
                " on a.idadjudicacion=c.idadjudicacion " +
                " join Contabilidad_alttum.terceros t " +
                " on t.idtercero=a.idtercero1 where a.estado ='Aprobado' and Concepto ='" + CmbTipoCartera.Text + "'  and c.Fecha >= " + FechaCorte + " and c.Fecha <= " + FechaFinal;
            }
            MtdInsertarProyeccion();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
