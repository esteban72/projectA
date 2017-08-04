using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using DevExpress.XtraGrid;
using System.IO;
using CarteraGeneral.WebServiceTRMColombia;

namespace CarteraGeneral.Clases
{
    public class ClsComision
    {
        #region "Atributos"
        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
        System.Data.DataTable DatosContratos = new System.Data.DataTable();
        //Datos para llenar los textBox
        private string sContrato;
        private string sCliente;
        private string sInmueble;
        private string sVecesPuedeComisionarContrato;
        private string sVecesContratoComisionado;
        private DateTime dFechaContrato;
        private double dTotalVenta;
        private double dTotalRecaudado;
        private double dPorcentajeComisionado;
        private double dTotalPagoComision;
        private double dvalTRMcontrato;
        private double valorGenerico;
        
        //Demas operaciones
        private DateTime? dFecha1Comision;
        public DateTime? dFecha2Comision;

        //Datos para llenar el GridView
        private string sNombreComisionista;
        private string sNombreCargo;
        private string sIdTercero;
        private double dTRM;
        private double dComisionTotalPagada;

        private double dPagoNeto;
        private string sError;
        private Int32 iContadorContratos;

        #endregion

        #region "Constructor"
        public ClsComision()
        {
            MysqlConexion.Close();
            dFecha1Comision = null;
            dFecha2Comision = null;
        }
        #endregion

        #region "Propiedades"
        #region "Propiedades para los txt"
        public string Contrato
        {
            get { return sContrato; }
            set { sContrato = value; }
        }

        public string Cliente
        {
            get { return sCliente; }
            set { sCliente = value; }
        }

        public string Inmueble
        {
            get { return sInmueble; }
            set { sInmueble = value; }
        }

        public string VecesPuedeComisionarContrato
        {
            get { return sVecesPuedeComisionarContrato; }
            set { sVecesPuedeComisionarContrato = value; }
        }

        public string VecesContratoComisionado
        {
            get { return sVecesContratoComisionado; }
            set { sVecesContratoComisionado = value; }
        }

        public DateTime FechaContrato
        {
            get { return dFechaContrato; }
            set { dFechaContrato = value; }
        }

        public DateTime Fecha1Comision
        {
            set { dFecha1Comision = value; }
        }

        public DateTime Fecha2Comision
        {
            set { dFecha2Comision = value; }
        }
        public double TotalVenta
        {
            get { return dTotalVenta; }
            set { dTotalVenta = value; }
        }

        public double TotalRecaudado
        {
            get { return dTotalRecaudado; }
            set { dTotalRecaudado = value; }
        }

        public double PorcentajeComisionado
        {
            get { return dPorcentajeComisionado; }
            set { dPorcentajeComisionado = value; }
        }

        public double TotalPagoComision
        {
            get { return dTotalPagoComision; }
            set { dTotalPagoComision = value; }
        }
        #endregion

        #region "Propiedades para el GridView"

        public string NombreComisionista
        {
            get { return sNombreComisionista; }
            set { sNombreComisionista = value; }
        }

        public string NombreCargo
        {
            get { return sNombreCargo; }
            set { sNombreCargo = value; }
        }

        public string IdTercero
        {
            get { return sIdTercero; }
            set { sIdTercero = value; }
        }

        
        public double TRM
        {
            get { return dTRM; }
            set { dTRM = value; }
        }

        public double ComisionTotalPagada
        {
            get { return dComisionTotalPagada; }
            set { dComisionTotalPagada = value; }
        }
        
        public double PagoNeto
        {
            get { return dPagoNeto; }
            set { dPagoNeto = value; }
        }
        #endregion

        #region "Demas propiedades"
        public string Error
        {
            get { return sError; }
            set { sError = value; }
        }

        public Int32 ContadorContratos
        {
            get { return iContadorContratos; }
            set { iContadorContratos = value; }
        }

        public double valTRMcontrato
        {
            get { return dvalTRMcontrato; }
            set { dvalTRMcontrato = value; }
        }
        #endregion

        

        #endregion

        #region "Metodos"

        #region "Metodos Alttum"

        /*Metodo que trae la lista de contratos que pueden comisionar, el metodo ejecuta el 
         sp_Alttum_Contratos para validar que contratos comisionan*/
        public List<string> ListaContratos(string Sentencia, string Campo)
        {

            List<string> ListaContratos = new List<string>();
            MySqlCommand CmdListaContratos = new MySqlCommand(Sentencia, MysqlConexion);
            MySqlDataReader DrdListaContratos;
            MysqlConexion.Open();
            DrdListaContratos = CmdListaContratos.ExecuteReader();
            try
            {
                while (DrdListaContratos.Read())
                {
                    ListaContratos.Add(DrdListaContratos[Campo].ToString());
                    ContadorContratos = ListaContratos.Count;
                }
                if (ListaContratos.Count == 0)
                {
                    ContadorContratos = 0;
                }
                return ListaContratos;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return null;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }
        

        /*Metodo para cargar la información en los txt del formulario, se valida si la fecha del contrato
         esta entre las fechas 20-MAY-2016 a 01-JUN-2017, ya que entre esas fechas los contratos son
         de 4 comisiones, c/u del 25% y ademas tienen fondo de cancelación obligatoria*/
        public bool cargarInformacionContrato()
        {
            
            MySqlCommand Query = new MySqlCommand();
            MySqlDataReader consultar;
            try
            {
                MysqlConexion.Open();
                Query.CommandText = "SELECT adj.IdAdjudicacion, TR.NombreCompleto, adj.IdInmueble, adj.FechaContrato, "+
                                    "adj.Valor AS 'Valor total venta', sum(rec.Capital) as 'Total recaudado',"+
                                    "if(adj.FechaContrato >= '2016-05-20' and adj.FechaContrato <= '2017-06-01',"+
                                    "(SELECT DISTINCT format (((VecesPagoComision* 100)/4),0) AS PorcentajeComision FROM comisiones "+
                                    "WHERE IdAdjudicacion = (SELECT IdAdjudicacion FROM adjudicacion where Contrato = '" + sContrato + "') and IdCargo not in (12,13,14,15,16,19))," +
                                    "(SELECT DISTINCT format (((VecesPagoComision* 100)/3),0) AS PorcentajeComision FROM comisiones "+
                                    "WHERE IdAdjudicacion = (SELECT IdAdjudicacion FROM adjudicacion where Contrato = '" + sContrato + "') and IdCargo not in (12,13,14,15,16,19))) as 'PorcentajeComision' " +
                                    "FROM contabilidad_alttum.terceros TR "+
                                    "INNER JOIN adjudicacion adj on adj.IdTercero1 = TR.IdTercero "+
                                    "INNER JOIN recaudos rec on adj.IdAdjudicacion = rec.IdAdjudicacion "+
                                    "WHERE adj.Contrato = '" + sContrato + "' and rec.Concepto != 'GA' " +
                                    "GROUP BY adj.IdAdjudicacion, adj.IdInmueble, adj.FechaContrato, adj.Valor";

                Query.Connection = MysqlConexion;
                consultar = Query.ExecuteReader();
                while (consultar.Read())
                {
                    sCliente = consultar.GetString(1);
                    sInmueble = consultar.GetString(2);
                    dFechaContrato = consultar.GetDateTime(3);
                    dTotalVenta = consultar.GetDouble(4);
                    dTotalRecaudado = consultar.GetDouble(5);
                    dPorcentajeComisionado = consultar.GetDouble(6);
                }
                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        /*Método que trae la informacion del contrato seleccionado y lo muestra en el 
         GridControl*/
        public System.Data.DataTable cargarInformacionComisiones()
        {
            MySqlCommand comando = new MySqlCommand("sp_CargarInfoComisiones", MysqlConexion);
            comando.Parameters.AddWithValue("_Contrato", sContrato);
            comando.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter DtaBuscarDataset = new MySqlDataAdapter();
            DataSet DtsBuscarDataset = new DataSet();
            comando.CommandTimeout = 0;
            DtaBuscarDataset.SelectCommand = comando;
            DtsBuscarDataset.Tables.Clear();

            try
            {
                DtaBuscarDataset.Fill(DtsBuscarDataset, "BuscarDataset");
                return DtsBuscarDataset.Tables[("BuscarDataset")];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente: " + ex.Message + " ", " " + "MtdBuscarDataset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DtsBuscarDataset.Tables[("BuscarDataset")];
            }
            finally
            {
                MysqlConexion.Close();
            }
        }
        
        /*Este metodo valida mediante un sp cual es el valor a pagar por el contrato seleccionado,
         es decir, el sistema muestra que el contrato se puede pagar 2 veces
         pero el usuario selecciona que quiere pagar solo una vez, entonces el sistema trae el valor
         de cuanto debe pagar por esa 1ra vez que va a pagar el usuario*/
        public Boolean calcularPagoComision(string numeroPago)
        {
            try
            {
                MySqlCommand Query = new MySqlCommand();
                MySqlDataReader consultar;
                Query.CommandType = CommandType.StoredProcedure;
                Query.Connection = MysqlConexion;
                Query.CommandText = "sp_ValorPagarComision";
                Query.Parameters.AddWithValue("_Contrato", sContrato);
                Int32 cantPagos = Convert.ToInt32(numeroPago);
                Query.Parameters.AddWithValue("_numVecesPagoComision", cantPagos);
                Query.Connection.Open();
                consultar = Query.ExecuteReader();
                if (consultar.Read())
                {
                    dTotalPagoComision = consultar.GetDouble("PagoComision");
                }
                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        /*Este metodo valida (mediante un sp) cuantas veces se puede 
         pagar el contrato seleccionado en el formulario. Tambien trae el total que se debe
         pagar por el contrato, es decir, el sistema muestra que el contrato se puede pagar 2 veces
         pero el usuario selecciona que quiere pagar solo una vez, entonces el sistema trae el valor
         de cuanto debe pagar por esa 1ra vez que va a pagar el usuario*/
        public Boolean vecesPagoComisionContrato(string campo)
        {
            try
            {
                MySqlCommand Query = new MySqlCommand();
                MySqlDataReader consultar;
                Query.CommandType = CommandType.StoredProcedure;
                Query.Connection = MysqlConexion;
                Query.CommandText = "sp_Alttum_VecesQuePuedeComisionarContrato";
                Query.Parameters.AddWithValue("_Contrato", campo);
                Query.Connection.Open();
                consultar = Query.ExecuteReader();
                if (consultar.Read())
                {
                    sVecesPuedeComisionarContrato = consultar.GetString("VecesComisionadas_VecesPuedeComisionar");
                }


                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        public Boolean vecesPagoComisionContrato_Antiguo(string campo, int ingreso)
        {
            try
            {
                MySqlCommand Query = new MySqlCommand();
                MySqlDataReader consultar;
                Query.CommandType = CommandType.StoredProcedure;
                Query.Connection = MysqlConexion;
                Query.CommandText = "sp_Alttum_VecesPuedeComisionarContrato_Antiguo";
                Query.Parameters.AddWithValue("_Contrato", campo);
                Query.Parameters.AddWithValue("_Ingreso", ingreso);
                Query.Connection.Open();
                consultar = Query.ExecuteReader();
                if (consultar.Read())
                {
                    sVecesPuedeComisionarContrato = consultar.GetString("VecesComisionadas_VecesPuedeComisionar");
                }


                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }
        
        /*Metodo que valida los contratos que ya han sido radicados y que se 
         encuentran en la tabla comisiones y calcula los valores que a cada comisionista
         se le debe pagar*/
        public void ActualizarComisiones(string IdAdjudicacion)
        {
            string IdTercero;
            Int32 cargo;
            List<string> ListaPersonasComisionan = new List<string>();
            List<string> ListaIdCargoPersonas = new List<string>();
            MySqlCommand CmdListaContratos = new MySqlCommand("sp_ListaComisionesActualizar", MysqlConexion);
            CmdListaContratos.Parameters.AddWithValue("_IdAdjudicacion", IdAdjudicacion);
            CmdListaContratos.CommandType = CommandType.StoredProcedure;
            MySqlDataReader DrdListaComisiones;

            MysqlConexion.Open();
            DrdListaComisiones = CmdListaContratos.ExecuteReader();
            try
            {

                while (DrdListaComisiones.Read())
                {
                    IdTercero = DrdListaComisiones["IdTercero"].ToString();
                    cargo = Convert.ToInt32(DrdListaComisiones["IdCargo"].ToString());
                    //el sgte codigo ejecuta el sp agregarValoresComisiones para que calcule el valor de la comision
                    //de cada persona que participo en el negocio
                    MySqlCommand cmdValoresComisiones = new MySqlCommand();
                    cmdValoresComisiones.CommandType = CommandType.StoredProcedure;
                    cmdValoresComisiones.Connection = new MySqlConnection(FrmLogeo.StrConexion);
                    cmdValoresComisiones.CommandText = "sp_Alttum_AgregarValoresComisiones";
                    
                    cmdValoresComisiones.Parameters.AddWithValue("_IdTercero", IdTercero);
                    cmdValoresComisiones.Parameters.AddWithValue("_IdAdjudicacion", IdAdjudicacion);
                    cmdValoresComisiones.Parameters.AddWithValue("_IdCargo", cargo);
                    cmdValoresComisiones.Connection.Open();
                    cmdValoresComisiones.ExecuteNonQuery();
                    cmdValoresComisiones.Connection.Close();
                }

            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        /*Metodo que con un sp realiza el registro del pago de la comision
         que este pagando en el momento el usuario*/
        public Boolean PagoComision(string contrato, string numeroPago)
        {
            try
            {
            MySqlCommand CmdListaContratos = new MySqlCommand("sp_PagoComision", MysqlConexion);
            CmdListaContratos.Parameters.AddWithValue("_Contrato", contrato);
            CmdListaContratos.Parameters.AddWithValue("_NumeroPago", numeroPago);
            CmdListaContratos.CommandType = CommandType.StoredProcedure;
            MySqlDataReader DrdListaComisiones;
            MysqlConexion.Open();
            DrdListaComisiones = CmdListaContratos.ExecuteReader();
            return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        public Boolean RechazarOperacion(string contrato, string tipoRechazo)
        {
            try
            {
                MySqlCommand CmdListaContratos = new MySqlCommand("sp_Rechazar_Operacion", MysqlConexion);
                CmdListaContratos.Parameters.AddWithValue("_Contrato", contrato);
                CmdListaContratos.Parameters.AddWithValue("_TipoRechazo", tipoRechazo);
                CmdListaContratos.CommandType = CommandType.StoredProcedure;
                MySqlDataReader DrdListaComisiones;
                MysqlConexion.Open();
                DrdListaComisiones = CmdListaContratos.ExecuteReader();
                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        
        public void exporta_a_excel(DataGridView tabla)
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            excel.Cells[1, 3] = "COMISIONES PAGADAS";


            foreach (DataGridViewColumn col in tabla.Columns)
            {
                ColumnIndex++;
                excel.Cells[5, ColumnIndex] = col.Name;
            }

            int rowIndex = 4;

            foreach (DataGridViewRow row in tabla.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in tabla.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }

            }

            excel.Visible = true;

            Worksheet Libro = (Worksheet)excel.ActiveSheet;

            //Libro.Activate();

        }

        #endregion

        #region "Metodos Monterrey"

        /*Metodo que valida los contratos que ya han sido radicados y que se 
         encuentran en la tabla comisiones y calcula los valores que a cada comisionista
         se le debe pagar*/
        public void ActualizarComisiones_Monterrey(string IdAdjudicacion, string fecha_Contrato)
        {
            string IdTercero;
            Int32 cargo;
            double valorTRMcontrato;
            DateTime fechaContratoConvertida;
            List<string> ListaPersonasComisionan = new List<string>();
            List<string> ListaIdCargoPersonas = new List<string>();
            MySqlCommand CmdListaContratos = new MySqlCommand("sp_ListaComisionesActualizar", MysqlConexion);
            CmdListaContratos.Parameters.AddWithValue("_IdAdjudicacion", IdAdjudicacion);
            CmdListaContratos.CommandType = CommandType.StoredProcedure;
            MySqlDataReader DrdListaComisiones;
            fechaContratoConvertida = Convert.ToDateTime(fecha_Contrato);

            TCRMServicesInterfaceClient client = new TCRMServicesInterfaceClient();
            tcrmResponse response = default(tcrmResponse);            
            response = client.queryTCRM(fechaContratoConvertida);
            valorTRMcontrato = response.value;

            MysqlConexion.Open();
            DrdListaComisiones = CmdListaContratos.ExecuteReader();
            try
            {

                while (DrdListaComisiones.Read())
                {
                    IdTercero = DrdListaComisiones["IdTercero"].ToString();
                    cargo = Convert.ToInt32(DrdListaComisiones["IdCargo"].ToString());
                    //el sgte codigo ejecuta el sp agregarValoresComisiones para que calcule el valor de la comision
                    //de cada persona que participo en el negocio
                    MySqlCommand cmdValoresComisiones = new MySqlCommand();
                    cmdValoresComisiones.CommandType = CommandType.StoredProcedure;
                    cmdValoresComisiones.Connection = new MySqlConnection(FrmLogeo.StrConexion);
                    cmdValoresComisiones.CommandText = "sp_Monterrey_AgregarValoresComisiones";

                    cmdValoresComisiones.Parameters.AddWithValue("_IdTercero", IdTercero);
                    cmdValoresComisiones.Parameters.AddWithValue("_IdAdjudicacion", IdAdjudicacion);
                    cmdValoresComisiones.Parameters.AddWithValue("_IdCargo", cargo);
                    cmdValoresComisiones.Parameters.AddWithValue("_trmContrato", valorTRMcontrato);
                    cmdValoresComisiones.Connection.Open();
                    cmdValoresComisiones.ExecuteNonQuery();
                    cmdValoresComisiones.Connection.Close();
                }

            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        /*Metodo para cargar la información en los txt del formulario, se valida si la fecha del contrato
        esta entre las fechas 20-MAY-2016 a 01-JUN-2017, ya que entre esas fechas los contratos son
        de 4 comisiones, c/u del 25% y ademas tienen fondo de cancelación obligatoria*/
        public bool cargarInformacionContrato_Monterrey()
        {
            try
            {
                fechaContrato();
                double totalVenta, totalRecaudo;
                MySqlCommand Query = new MySqlCommand();
                MySqlDataReader consultar;
                MysqlConexion.Open();
                Query.CommandText = "SELECT adj.IdAdjudicacion, TR.NombreCompleto, adj.IdInmueble, adj.FechaContrato, " +
                                    "adj.Valor AS 'Valor total venta', sum(rec.Capital) as 'Total recaudado'," +
                                    "if(adj.FechaContrato >= '2016-05-20' and adj.FechaContrato <= '2017-06-01'," +
                                    "(SELECT DISTINCT format (((VecesPagoComision* 100)/4),0) AS PorcentajeComision FROM comisiones " +
                                    "WHERE IdAdjudicacion = (SELECT IdAdjudicacion FROM adjudicacion where Contrato = '" + sContrato + "') and IdCargo not in (12,13,14,15,16,19))," +
                                    "(SELECT DISTINCT format (((VecesPagoComision* 100)/4),0) AS PorcentajeComision FROM comisiones " +
                                    "WHERE IdAdjudicacion = (SELECT IdAdjudicacion FROM adjudicacion where Contrato = '" + sContrato + "') and IdCargo not in (12,13,14,15,16,19))) as 'PorcentajeComision' " +
                                    "FROM contabilidad_alttum.terceros TR " +
                                    "INNER JOIN adjudicacion adj on adj.IdTercero1 = TR.IdTercero " +
                                    "INNER JOIN recaudos rec on adj.IdAdjudicacion = rec.IdAdjudicacion " +
                                    "WHERE adj.Contrato = '" + sContrato + "' and rec.Concepto != 'GA' " +
                                    "GROUP BY adj.IdAdjudicacion, adj.IdInmueble, adj.FechaContrato, adj.Valor";

                Query.Connection = MysqlConexion;
                consultar = Query.ExecuteReader();
                
                while (consultar.Read())
                {
                    sCliente = consultar.GetString(1);
                    sInmueble = consultar.GetString(2);
                    dFechaContrato = consultar.GetDateTime(3);
                    totalVenta = consultar.GetDouble(4);
                    dTotalVenta = totalVenta * dvalTRMcontrato;
                    totalRecaudo = consultar.GetDouble(5);
                    dTotalRecaudado = totalRecaudo * dvalTRMcontrato;
                    dPorcentajeComisionado = consultar.GetDouble(6);
                }
                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        private void fechaContrato()
        {
            MySqlCommand Query = new MySqlCommand();
            MySqlDataReader consultar;
            try
            {
                Query.CommandType = CommandType.StoredProcedure;
                Query.Connection = MysqlConexion;
                Query.CommandText = "sp_FechaContrato";
                Query.Parameters.AddWithValue("_Contrato", sContrato);
                Query.Connection.Open();
                consultar = Query.ExecuteReader();
                if (consultar.Read())
                {
                    dFechaContrato = consultar.GetDateTime(2);
                }
                TCRMServicesInterfaceClient client = new TCRMServicesInterfaceClient();
                tcrmResponse response = default(tcrmResponse);
                response = client.queryTCRM(dFechaContrato);
                dvalTRMcontrato = response.value;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        /*Este metodo valida (mediante un sp) cuantas veces se puede 
         pagar el contrato seleccionado en el formulario. Tambien trae el total que se debe
         pagar por el contrato, es decir, el sistema muestra que el contrato se puede pagar 2 veces
         pero el usuario selecciona que quiere pagar solo una vez, entonces el sistema trae el valor
         de cuanto debe pagar por esa 1ra vez que va a pagar el usuario*/
        public Boolean vecesPagoComisionContrato_Monterrey(string campo)
        {
            try
            {
                MySqlCommand Query = new MySqlCommand();
                MySqlDataReader consultar;
                Query.CommandType = CommandType.StoredProcedure;
                Query.Connection = MysqlConexion;
                Query.CommandText = "sp_Monterrey_VecesQuePuedeComisionarContrato";
                Query.Parameters.AddWithValue("_Contrato", campo);
                Query.Connection.Open();
                consultar = Query.ExecuteReader();
                if (consultar.Read())
                {
                    sVecesPuedeComisionarContrato = consultar.GetString("VecesComisionadas_VecesPuedeComisionar");
                }


                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }
        #endregion

        #region "Metodos PIV"

        public void ActualizarComisiones_PIV(string IdAdjudicacion)
        {
            string IdTercero;
            Int32 cargo;
            List<string> ListaPersonasComisionan = new List<string>();
            List<string> ListaIdCargoPersonas = new List<string>();
            MySqlCommand CmdListaContratos = new MySqlCommand("sp_ListaComisionesActualizar", MysqlConexion);
            CmdListaContratos.Parameters.AddWithValue("_IdAdjudicacion", IdAdjudicacion);
            CmdListaContratos.CommandType = CommandType.StoredProcedure;
            MySqlDataReader DrdListaComisiones;
            Consultar("Select trm from adjudicacion where idadjudicacion = '"+IdAdjudicacion+"'");
            MysqlConexion.Open();
            DrdListaComisiones = CmdListaContratos.ExecuteReader();
            try
            {

                while (DrdListaComisiones.Read())
                {
                    IdTercero = DrdListaComisiones["IdTercero"].ToString();
                    cargo = Convert.ToInt32(DrdListaComisiones["IdCargo"].ToString());
                    //el sgte codigo ejecuta el sp agregarValoresComisiones para que calcule el valor de la comision
                    //de cada persona que participo en el negocio
                    MySqlCommand cmdValoresComisiones = new MySqlCommand();
                    cmdValoresComisiones.CommandType = CommandType.StoredProcedure;
                    cmdValoresComisiones.Connection = new MySqlConnection(FrmLogeo.StrConexion);
                    cmdValoresComisiones.CommandText = "sp_PIV_AgregarValoresComisiones";

                    cmdValoresComisiones.Parameters.AddWithValue("_IdTercero", IdTercero);
                    cmdValoresComisiones.Parameters.AddWithValue("_IdAdjudicacion", IdAdjudicacion);
                    cmdValoresComisiones.Parameters.AddWithValue("_IdCargo", cargo);
                    cmdValoresComisiones.Parameters.AddWithValue("_trmContrato", valorGenerico);
                    cmdValoresComisiones.Connection.Open();
                    cmdValoresComisiones.ExecuteNonQuery();
                    cmdValoresComisiones.Connection.Close();
                }

            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        #endregion
        public void Consultar(string Sentencia)
        {
            
            MySqlCommand Query = new MySqlCommand();
            MySqlDataReader consultar;
            try
            {
                MysqlConexion.Open();
                Query.CommandText = Sentencia;

                Query.Connection = MysqlConexion;
                consultar = Query.ExecuteReader();
                if (consultar.Read())
                {
                    valorGenerico = consultar.GetDouble(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ups! Hubo un inconveniente: " + ex.Message, "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        public void ConsultarContrato(string sentencia, string campo)
        {
            MySqlCommand Query = new MySqlCommand();
            MySqlDataReader consultar;
            ContadorContratos = 0;
            try
            {
                Query.CommandType = CommandType.StoredProcedure;
                Query.Connection = MysqlConexion;
                Query.CommandText = sentencia;
                Query.Parameters.AddWithValue("_Contrato", campo);
                Query.Connection.Open();
                consultar = Query.ExecuteReader();
                if (consultar.Read())
                {
                    sContrato = consultar.GetString(0);
                    ContadorContratos++;
                }
            }
            catch (Exception ex)
            {
                sError = ex.Message;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        #region "Metodos para consultas comisiones pagadas"

        public List<string> ListaContratos_Monterrey(string Sentencia, string Campo)
        {

            List<string> ListaContratos = new List<string>();
            MySqlCommand CmdListaContratos = new MySqlCommand(Sentencia, MysqlConexion);
            MySqlDataReader DrdListaContratos;
            MysqlConexion.Open();
            DrdListaContratos = CmdListaContratos.ExecuteReader();
            try
            {
                while (DrdListaContratos.Read())
                {
                    ListaContratos.Add(DrdListaContratos[Campo].ToString());
                    ContadorContratos = ListaContratos.Count;
                }
                if (ListaContratos.Count == 0)
                {
                    ContadorContratos = 0;
                }
                return ListaContratos;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return null;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        public bool NumVecesComisionada()
        {
            try
            {
                MySqlCommand Query = new MySqlCommand();
                MySqlDataReader consultar;
                Query.CommandType = CommandType.StoredProcedure;
                Query.Connection = MysqlConexion;
                Query.CommandText = "sp_vecesComisionadoContrato";
                Query.Parameters.AddWithValue("_Contrato", sContrato);
                Query.Connection.Open();
                consultar = Query.ExecuteReader();
                if (consultar.Read())
                {
                    sVecesContratoComisionado = consultar.GetString(1);
                    dTotalPagoComision = consultar.GetDouble(2);
                }
                return true;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return false;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        //Metodo trae la informacion de las comisiones sin haber formateado los numeros
        public System.Data.DataTable cargaYExportaExcel()
        {
            MySqlCommand comando = new MySqlCommand("sp_ExportarExcel", MysqlConexion);
            comando.Parameters.AddWithValue("_Contrato", sContrato);
            comando.CommandType = CommandType.StoredProcedure;

            MySqlDataAdapter DtaBuscarDataset = new MySqlDataAdapter();
            DataSet DtsBuscarDataset = new DataSet();
            comando.CommandTimeout = 0;
            DtaBuscarDataset.SelectCommand = comando;
            DtsBuscarDataset.Tables.Clear();

            try
            {
                DtaBuscarDataset.Fill(DtsBuscarDataset, "BuscarDataset");
                return DtsBuscarDataset.Tables[("BuscarDataset")];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un inconveniente: " + ex.Message + " ", " " + "MtdBuscarDataset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DtsBuscarDataset.Tables[("BuscarDataset")];
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        //Metodo para exportar a excel
        public void exportarArchivo(GridControl grdExportar, object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2013) (.xlsx)|*.xlsx";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    try
                    {
                        switch (fileExtenstion)
                        {
                            case ".xls":
                                grdExportar.ExportToXls(exportFilePath);
                                break;
                            case ".xlsx":
                                grdExportar.ExportToXlsx(exportFilePath);
                                break;
                            default:
                                break;
                        }
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Por favor revisar que no se tenga abierto el documento que esta tratando de guardar. " + ex.Message, "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "No se pudo abrir el archivo." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "No se pudo guardar el archivo." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /*Metodo para buscar un contrato por fechas*/
        public List<string> ContratosXFecha(string Sentencia, string Campo)
        {

            List<string> ListaContratos = new List<string>();
            MySqlCommand CmdListaContratos = new MySqlCommand(Sentencia, MysqlConexion);
            CmdListaContratos.Parameters.AddWithValue("_fecha1", dFecha1Comision);
            if (dFecha2Comision != null)
            {
                CmdListaContratos.Parameters.AddWithValue("_fecha2", dFecha2Comision);
            }
            else
            {
                CmdListaContratos.Parameters.AddWithValue("_fecha2", dFecha1Comision);
            }
            CmdListaContratos.CommandType = CommandType.StoredProcedure;
            MySqlDataReader DrdListaContratos;
            MysqlConexion.Open();
            DrdListaContratos = CmdListaContratos.ExecuteReader();
            try
            {
                while (DrdListaContratos.Read())
                {
                    ListaContratos.Add(DrdListaContratos[Campo].ToString());
                    ContadorContratos = ListaContratos.Count;
                }
                if (ListaContratos.Count == 0)
                {
                    ContadorContratos = 0;
                }
                return ListaContratos;
            }
            catch (Exception ex)
            {
                sError = ex.Message;
                return null;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }
        #endregion

        #endregion
    }
}
