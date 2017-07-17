using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarteraGeneral
{
    class ClsComisionesMonterey
    {

      


        MySqlConnection miconexion = new MySqlConnection();
        ClsIdentificacion conexion = new ClsIdentificacion();


        #region REGION DE PROPIEDADES

        string EntradaComision { get; set; }
        public DataTable DtComisiones { get; set; }

        public DataTable DtDatosAdj { get; set; }
        public DataTable DtPago { get; set; }
        int Id { get; set; }
        string IdFinanciacion { get; set; }
        public  int IdAdjudicacion { get; set; }
        public DateTime Fecha { get; set; }
        string IdTercero { get; set; }
        int IdCargo { get; set; }
        decimal TasaComision { get; set; }
        decimal Comision { get; set; }
        decimal Retencion { get; set; }
        decimal DctoAnticipo { get; set; }
        decimal PagoNeto { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaOperacion { get; set; }
        public int Transaccion { get; set; }
        decimal DctoFondo { get; set; }
        public decimal Trm { get; set; }
        string CentroCostos { get; set; }
        string Cuentadebe{ get; set; }
        string CuentaHaber{ get; set; }
        string CuentaAnticipo{ get; set; }
        string CuentaFondo{ get; set; }
        string Fuente { get; set; }
        string IdDocumento { get; set; }
        string periodo { get; set; }
        string Motivo { get; set; }
        DataTable dtCuentas { get; set; }
        string IdInmueble { get; set; }

        #endregion



        public ClsComisionesMonterey()
        {
            dtCuentas = conexion.MtdBuscarDataset(RscComisiones.CuentasComisiones);
            Fuente = dtCuentas.Rows[0][3].ToString();
            Cuentadebe = dtCuentas.Rows[0][1].ToString();
            CuentaHaber = dtCuentas.Rows[0][2].ToString();
            CuentaAnticipo = dtCuentas.Rows[1][1].ToString();
            CuentaFondo = dtCuentas.Rows[2][1].ToString();
        }


       
        public void MtdEntrada(string VarEntradaComision)
        {
            EntradaComision = VarEntradaComision;
            if (EntradaComision == "Enganche")
            {

                DtComisiones = conexion.MtdBuscarDataset(MisConsultas.ComsionesMontereyRsm, FrmLogeo.StrConexion);
            }
            else
                if (EntradaComision == "Tiempo")
                {
                    DtComisiones = conexion.MtdBuscarDataset(MisConsultas.ComisionesMontererTiempoRsm, FrmLogeo.StrConexion);
                }
        }
        public DataTable MtdCnsPagoComisiones()

        {         
            if (EntradaComision == "Enganche")
            {
                DtPago = conexion.MtdBuscarDataset(MisConsultas.ComisionesMontereyxAdj, IdAdjudicacion.ToString());                
            }
            else
                if (EntradaComision == "Tiempo")
                {
                    DtPago = conexion.MtdBuscarDataset(MisConsultas.ComisionesMontereyTimpoAdj,IdAdjudicacion.ToString());
                   
                }
            DtDatosAdj = conexion.MtdBuscarDataset("Select * From Adjudicacion Where IdAdjudicacion =@Parametro1", IdAdjudicacion.ToString());
            IdInmueble = DtDatosAdj.Rows[0]["IdInmueble"].ToString();
            return DtPago;
        }

        public string  MtdAddComision()
        {
            string res="";

                    Transaccion = Convert.ToInt32((conexion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99")));

                    IdDocumento = (conexion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + Fuente + "'"));
                    Motivo = "PAGO  COMISION  ADJ" + IdAdjudicacion + " CLIENTE:" + DtPago.Rows[0][3].ToString();
                    periodo = conexion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM @Fecha)",Fecha);

                    string SentenciaAddComision = "Insert into pagocomision(IdFinanciacion,IdAdjudicacion,Fecha,IdTercero,IdCargo,TasaComision,Comision,Retencion," +
                    " DctoAnticipo, PagoNeto,Usuario,FechaOperacion,Transaccion,DctoFondo,Trm)" +
                    " VALUES(@IdFinanciacion,@IdAdjudicacion,@Fecha,@IdTercero,@IdCargo,@TasaComision,@Comision,@Retencion, @DctoAnticipo, @PagoNeto,@Usuario,@FechaOperacion,@Transaccion,@DctoFondo,@Trm)";

                    string SentenciaFondo = "Insert into fondosmonterrey(IdGestor,IdAdjudicacion,Fecha,Valor) Values(@IdTercero,@IdAdjudicacion,@Fecha,@DctoFondo)";

                    int cuentareg = 0;

                    FrmLogeo.MysqlConexion.Open();
                    MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
                    myCommand.Connection = FrmLogeo.MysqlConexion;
                    myCommand.Transaction = myTrans;

                    try
                    {


                        myCommand.Parameters.Add("@IdCargo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@IdFinanciacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@TasaComision", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@Comision", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@Retencion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@DctoAnticipo", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@PagoNeto", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@DctoFondo", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@Trm", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value=Trm;


                        myCommand.Parameters.Add("@IdDocumento", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                        myCommand.Parameters.Add("@Cuenta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Debe", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@Haber", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@Consecutivo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@motivo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Detalle", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Cheque", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Fuente", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@BaseRetencion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@Periodo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@CentroCostos", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@SubCentro", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@Transaccion", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@Beneficiario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Factura", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Matricula", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Cero", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@Add", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);


                        myCommand.Parameters["@IdDocumento"].Value = IdDocumento;
                        myCommand.Parameters["@Fecha"].Value = Fecha;
                        myCommand.Parameters["@motivo"].Value = Motivo;
                        myCommand.Parameters["@Cheque"].Value = IdDocumento;
                        myCommand.Parameters["@Fuente"].Value = Fuente;

                        myCommand.Parameters["@Periodo"].Value = periodo;
                        myCommand.Parameters["@CentroCostos"].Value = 1;
                        myCommand.Parameters["@SubCentro"].Value = 2;
                        myCommand.Parameters["@Estado"].Value = 1;
                        myCommand.Parameters["@Transaccion"].Value = Convert.ToInt32(Transaccion);
                        myCommand.Parameters["@IdAdjudicacion"].Value = (IdAdjudicacion);
                        myCommand.Parameters["@Matricula"].Value = IdInmueble;
                        myCommand.Parameters["@Cero"].Value = 0;
                        myCommand.Parameters["@Add"].Value = "ADD";
                        myCommand.Parameters["@Usuario"].Value = FrmLogeo.FrmUsuarioIdUsr;
                        myCommand.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;


                        myCommand.CommandText = "INSERT INTO Contabilidad_alttum.transacciones (IdTransaccion,Fecha,Transaccion,Fuente,Registro,Usuario) Values (@Transaccion ,Curdate(),'Add',@Fuente ,@IdDocumento,@Usuario)";
                        myCommand.ExecuteNonQuery();

                        for (int i = 0; i < DtPago.Rows.Count; i++)
                        {
                            myCommand.Parameters["@IdFinanciacion"].Value = Convert.ToString(DtPago.Rows[i][0]);
                            myCommand.Parameters["@IdCargo"].Value = Convert.ToString(DtPago.Rows[i][5]);
                            myCommand.Parameters["@TasaComision"].Value = Convert.ToDecimal(DtPago.Rows[i][7]);
                            myCommand.Parameters["@Comision"].Value = Convert.ToDecimal(DtPago.Rows[i][14]);
                            myCommand.Parameters["@Retencion"].Value = Convert.ToDecimal(DtPago.Rows[i][15]);
                            myCommand.Parameters["@DctoFondo"].Value = Convert.ToDecimal(DtPago.Rows[i]["DctoFondo"]);
                            myCommand.Parameters["@DctoAnticipo"].Value = Convert.ToDecimal(DtPago.Rows[i][17]);                          
                            myCommand.Parameters["@PagoNeto"].Value = Convert.ToDecimal(DtPago.Rows[i]["PagoNeto"]);
                            myCommand.Parameters["@BaseRetencion"].Value = 0;

                            myCommand.Parameters["@Factura"].Value = "CMS-" + Convert.ToString(DtPago.Rows[i][0].ToString()) + "-" + IdDocumento;
                            myCommand.Parameters["@IdTercero"].Value = Convert.ToString(DtPago.Rows[i][1].ToString());
                            myCommand.Parameters["@Cuenta"].Value = Cuentadebe;
                            myCommand.Parameters["@Debe"].Value = Convert.ToDecimal(DtPago.Rows[i][14]);
                            myCommand.Parameters["@Haber"].Value = 0;
                            myCommand.Parameters["@Beneficiario"].Value = Convert.ToString(DtPago.Rows[i][4]); ;
                            myCommand.Parameters["@Detalle"].Value = Convert.ToString(DtPago.Rows[i][4]);
                            cuentareg = cuentareg + 1;
                            myCommand.Parameters["@Consecutivo"].Value = cuentareg;

                            myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura,Trm)  " +
                         " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura,@Trm)";

                            myCommand.ExecuteNonQuery();

                            // Retencion en la Fuente
                            if ((Convert.ToDecimal(DtPago.Rows[i][15])) > 0)
                            {
                                myCommand.Parameters["@BaseRetencion"].Value = Convert.ToDecimal(DtPago.Rows[i][14]);
                                cuentareg = cuentareg + 1;
                                myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                                myCommand.Parameters["@Cuenta"].Value =Retencion ;
                                myCommand.Parameters["@Debe"].Value = 0;
                                myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(DtPago.Rows[i][23]);
                                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura,Trm)  " +
                               " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura,@Trm)";
                                myCommand.ExecuteNonQuery();
                            }

                            // Descuento Rete Fondo
                            if ((Convert.ToDecimal(DtPago.Rows[i][16])) > 0)
                            {
                                myCommand.Parameters["@BaseRetencion"].Value = Convert.ToDecimal(DtPago.Rows[i][14]);
                                cuentareg = cuentareg + 1;
                                myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                                myCommand.Parameters["@Cuenta"].Value = CuentaFondo;
                                myCommand.Parameters["@Debe"].Value = 0;
                                myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(DtPago.Rows[i]["DctoFondo"]);
                                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura,Trm)  " +
                               " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura,@Trm)";
                                myCommand.ExecuteNonQuery();
                            }


                            // Descuento Anticipo
                            if ((Convert.ToDecimal(DtPago.Rows[i][17])) > 0)
                            {
                                cuentareg = cuentareg + 1;
                                myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                                myCommand.Parameters["@Cuenta"].Value = CuentaAnticipo;
                                myCommand.Parameters["@Debe"].Value = 0;
                                myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(DtPago.Rows[i][17]);
                                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura,Trm)  " +
                               " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura,@Trm)";
                                myCommand.ExecuteNonQuery();
                            }

                            // Abono Cuenta Por Pagar
                            myCommand.Parameters["@Cuenta"].Value = CuentaHaber;
                            myCommand.Parameters["@Debe"].Value = 0;
                            myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(DtPago.Rows[i]["PagoNeto"]);
                            cuentareg = cuentareg + 1;
                            myCommand.Parameters["@Consecutivo"].Value = cuentareg;

                            myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura,Trm)  " +
                               " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura,@Trm)";
                                myCommand.ExecuteNonQuery();

                            myCommand.CommandText = SentenciaAddComision;
                            myCommand.ExecuteNonQuery();


                            myCommand.CommandText = SentenciaFondo;
                            myCommand.ExecuteNonQuery();
                          
                        }

                        myCommand.CommandText = "Update Contabilidad_alttum.documentomanual set Consecutivo=Consecutivo+1 ,ConsecutivoRef=ConsecutivoRef+1 Where idComprobante= @Fuente ";
                        myCommand.ExecuteNonQuery();

                        myCommand.CommandText = "Update Contabilidad_alttum.documento set Consecutivo=Consecutivo+1 Where idComprobante='99'";
                        myCommand.ExecuteNonQuery();

                        myTrans.Commit();
                        MessageBox.Show("Registro Adicionado", "Adicionar Comision", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                       
                    }

                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el sgte Error " + ex.Message, "Adicionar Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        res=ex.Message;
                    }
                    finally
                    {
                        FrmLogeo.MysqlConexion.Close();
                        res = "OK";
                       
                    }
                    return res;
                }
    
               
            
        

    }
}
