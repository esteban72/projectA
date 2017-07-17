using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace CarteraGeneral
{
    public partial class FrmRecaudoPorCuotas : Form
    {
        public FrmRecaudoPorCuotas()
        {
            InitializeComponent();
        }


//=================================================================================================================================================== 
// I N I C I O   D E   V A R I A B L E S
//===================================================================================================================================================
        #region VARIABLES

        public string VarIdAdjudicacion;
        public int VarIdPosfechado;
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        public int EntradaRecaudos;
        bool Automatico;
        DataTable DtDatosGral = new DataTable();
        DataTable DtGrilla = new DataTable();
        DataTable DtPagoMinimo = new DataTable();
        DataTable DtPosfechado = new DataTable();
        DataTable DatosCuenta = new DataTable();
        DataTable DtParametros = new DataTable();
        List<string> DatosdeErrores = new List<string>();

        double SumPagoMinimo = 0, CuentaErrores,VarValor, VarMora, Pendiente = 0, NuevoSaldoTotal;
        public string tipor = "";
        string CuentaDebe, CuentaHaber,CuentaMora, Fuente,Centrocosto,Subcentro, IdTercero, FechaAsiento, idtransacciones, IdDocumento,RefPosfecha;
        string Consecutivo,Formato,Operacion = "", FormaPago = "",SentenciaGrilla = "",SentenciaDatosRcd = "",StrPeriodo, StrInteresCte, StrInteresMora,StrDiaMora,StrDecimales,Estado = "Aprobado",periodo;
        int CuotasVdas, MaxDiasMora;
     
      
   

       


        #endregion
//===================================================================================================================================================
//F I N A L   D E   V A R I A B L E S
//===================================================================================================================================================
        


//===================================================================================================================================================
//I N i C I O   M E T O D O   C U O T A S   P A G A R
//===================================================================================================================================================
    private void MtdCuotasPagar()
        {
            double SumaCuota = 0, SumaMora = 0, MoraCta = 0;
            VarValor = Convert.ToDouble(TxtTotalRecaudo.Text);
            for (int i = 0; i < (DgvPagos.Rows.Count); i++)
            {
                MoraCta = Convert.ToDouble(DgvPagos.Rows[i].Cells[11].Value) - Convert.ToDouble(DgvPagos.Rows[i].Cells[12].Value);
                if (VarValor > (Convert.ToDouble(DgvPagos.Rows[i].Cells[13].Value)))
                {
                    DgvPagos.Rows[i].Cells[14].Value = DgvPagos.Rows[i].Cells[13].Value;
                    VarValor = VarValor - Convert.ToDouble(DgvPagos.Rows[i].Cells[14].Value);
                    SumaCuota = SumaCuota + Convert.ToDouble(DgvPagos.Rows[i].Cells[8].Value);
                    SumaMora = SumaMora + MoraCta;
                }

                else
                {
                    DgvPagos.Rows[i].Cells[14].Value = VarValor;
                    VarValor = VarValor - Convert.ToDouble(DgvPagos.Rows[i].Cells[14].Value);

                    if (MoraCta <= Convert.ToDouble(DgvPagos.Rows[i].Cells[14].Value))
                    {
                        SumaMora = SumaMora + MoraCta;
                        SumaCuota = SumaCuota + (Convert.ToDouble(DgvPagos.Rows[i].Cells[14].Value) - MoraCta);
                    }
                    else
                    {
                        SumaMora = SumaMora + Convert.ToDouble(DgvPagos.Rows[i].Cells[14].Value);
                    }
                }
            }

            TxtTotalCuota.Text = Convert.ToString(SumaCuota);
            TxtTotalMora.Text = Convert.ToString(SumaMora);
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   C U O T A S   A   P A G A  R
//===================================================================================================================================================



//===================================================================================================================================================
//I N i C I O   M E T O D O   C U O T A S   P A G A R
//===================================================================================================================================================
    private void MtdCuotasPagarCuota()
    {
        double SumaCuota = 0, SumaMora = 0, MoraCta = 0,SumaReca=0;
        VarValor = Convert.ToDouble(TxtTotalRecaudo.Text);
        for (int i = 0; i < (DgvPagos.Rows.Count); i++)
        {
            MoraCta = Convert.ToDouble(DgvPagos.Rows[i].Cells[11].Value) - Convert.ToDouble(DgvPagos.Rows[i].Cells[12].Value);
            VarValor = Convert.ToDouble(DgvPagos.Rows[i].Cells[14].Value);

            if (VarValor > MoraCta)
            {

                SumaMora = SumaMora + MoraCta;
                VarValor = VarValor - MoraCta;
                SumaCuota = SumaCuota + VarValor;
               
            }   

            else
            {
                SumaMora = SumaMora + VarValor;
            }
        }

        TxtTotalCuota.Text = Convert.ToString(SumaCuota);

        TxtTotalMora.Text = Convert.ToString(SumaMora);
        SumaReca = SumaCuota + SumaMora;
        TxtTotalRecaudo.Text = Convert.ToString(SumaReca);

    }
//===================================================================================================================================================
//F I N A L   M E T O D O   C U O T A S   A   P A G A  R
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdValidarAdd
//===================================================================================================================================================
        private void MtdValidarAdd()
        {
            DatosdeErrores.Clear();
            CuentaErrores = 0;

            if (TxtRecibo.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Ingresar Numero de Recibo");
            }

            if (CmbFormaPago.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccionar Forma de pago");
            }

            if (CmbOperacion.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccionar Operacion");
            }
            if (Convert.ToDouble(TxtTotalRecaudo.Text) == 0)
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Adicionar Valor recaudo");
            }


            if (Convert.ToDouble(TxtTotalRecaudo.Text) > Convert.ToDouble(TxtPagoTotal.Text))
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Valor recaudo Mayor a Pago total");
            }

            if (TxtMotivo.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Concepto");
            }


            string Periodo = NuevoClsIdentificacion.MtdBscDatos("select EXTRACT(YEAR_MONTH from '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "')");
            if (StrPeriodo != Periodo)
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Periodo no se encuentra activo");
            }
        }
//===================================================================================================================================================
// F I N   M E T O D O   DMtdValidarAdd
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D  O   A D I C I O N A R   R E C A U D O S
//===================================================================================================================================================
        public void MtdAddRecaudo()
        {

            CuentaDebe = NuevoClsIdentificacion.MtdBscDatos("Select Debe   From Contabilidad_alttum.datoscuenta Where Operacion= '" + CmbFormaPago.Text + "' and Documento = '" + Fuente + "'");
            CuentaHaber = NuevoClsIdentificacion.MtdBscDatos("Select Haber  From Contabilidad_alttum.datoscuenta Where Operacion= '" + CmbFormaPago.Text + "' and Documento = '" + Fuente + "'");
            CuentaMora = NuevoClsIdentificacion.MtdBscDatos("Select Cuenta From Contabilidad_alttum.cuentasdetalles Where Nombre= 'Interes Mora'");

            idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
            IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + Fuente + "'"));
            Formato = CuentaDebe.Substring(0, 4);
            Consecutivo = NuevoClsIdentificacion.MtdBscDatos("select if(max(IdRecaudo)is null,1,max(IdRecaudo+1))from datosrecaudos");
            periodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "')");
            int cuentareg = 0;          

            FrmLogeo.MysqlConexion.Open();
            MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
            myCommand.Connection = FrmLogeo.MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.Parameters.Add("@IdRecaudo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@NumRecibo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);            
                myCommand.Parameters.Add("@CodBanco", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@FormaPago", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@DetalleRec", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@Transaccion", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@IdFinanciacion", MySql.Data.MySqlClient.MySqlDbType.String);
                myCommand.Parameters.Add("@NumCuota", MySql.Data.MySqlClient.MySqlDbType.Int16);
                myCommand.Parameters.Add("@Capital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@InteresCte", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@InteresMora", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@InteresCnd", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@VrMoraCalc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@EstadoRec", MySql.Data.MySqlClient.MySqlDbType.String);
                myCommand.Parameters.Add("@Periodo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@FechaCuota", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.String);


                myCommand.Parameters["@IdRecaudo"].Value = Consecutivo;
                myCommand.Parameters["@IdAdjudicacion"].Value = Convert.ToInt32(TxtAdjudicacion.Text);
                myCommand.Parameters["@Fecha"].Value = DtpFecha.Value;
                myCommand.Parameters["@NumRecibo"].Value = TxtRecibo.Text;
                myCommand.Parameters["@IdTercero"].Value = IdTercero;
                myCommand.Parameters["@Operacion"].Value = CmbOperacion.Text;
                myCommand.Parameters["@Valor"].Value = Convert.ToDecimal(TxtTotalRecaudo.Text);
                myCommand.Parameters["@CodBanco"].Value = TxtCodBan.Text;
                myCommand.Parameters["@FormaPago"].Value = CmbFormaPago.Text;
                myCommand.Parameters["@DetalleRec"].Value = TxtMotivo.Text;
                myCommand.Parameters["@Usuario"].Value = FrmLogeo.FrmUsuarioIdUsr;
                myCommand.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                myCommand.Parameters["@Transaccion"].Value = idtransacciones;
                myCommand.Parameters["@EstadoRec"].Value = Estado;
                myCommand.Parameters["@Periodo"].Value =Convert.ToInt32( periodo);


              SentenciaDatosRcd = "insert into Datosrecaudos (IdRecaudo ,  IdAdjudicacion ,  Fecha ,  NumRecibo,  IdTercero,  Operacion    ,  Valor   ,  CodBanco  ,  FormaPago  , Detalle,Usuario,FechaOperacion, Transaccion ) " +
                "Values (@IdRecaudo ,  @IdAdjudicacion ,  @Fecha ,  @NumRecibo,  @IdTercero,  @Operacion    ,  @Valor   ,  @CodBanco  ,  @FormaPago  , @DetalleRec,@Usuario,@FechaOperacion, @Transaccion )";

              myCommand.CommandText = SentenciaDatosRcd;
                myCommand.ExecuteNonQuery();


            VarValor = 0;




            #region Cuota
            for (int i = 0; i < (DgvPagos.Rows.Count); i++)
            {
                decimal Capital = Convert.ToDecimal(DgvPagos.Rows[i].Cells[6].Value);
                decimal IntCte = Convert.ToDecimal(DgvPagos.Rows[i].Cells[7].Value);
                decimal IntMora = ((Convert.ToDecimal(DgvPagos.Rows[i].Cells[11].Value)) - (Convert.ToDecimal(DgvPagos.Rows[i].Cells[12].Value)));
                decimal TotalPago = Convert.ToDecimal(DgvPagos.Rows[i].Cells[14].Value);


                if ((Convert.ToDouble(DgvPagos.Rows[i].Cells[14].Value)) > 0)
                {

                    //-------------------------------------------------------------------------------------------------------------------------------
                    if (TotalPago < IntMora)
                    {
                        IntMora = TotalPago;
                        TotalPago = TotalPago - IntMora;
                    }
                    else
                    {
                        TotalPago = TotalPago - IntMora;
                    }
                    //-------------------------------------------------------------------------------------------------------------------------------


                    //-------------------------------------------------------------------------------------------------------------------------------
                    if (TotalPago < IntCte)
                    {
                        IntCte = TotalPago;
                        TotalPago = TotalPago - IntCte;
                        Capital = TotalPago;
                    }
                    else
                    {
                        TotalPago = TotalPago - IntCte;
                        Capital = TotalPago;
                    }

                    //-------------------------------------------------------------------------------------------------------------------------------


                    myCommand.Parameters["@IdFinanciacion"].Value = (Convert.ToString(DgvPagos.Rows[i].Cells[0].Value) + Convert.ToString(DgvPagos.Rows[i].Cells[1].Value) +"ADJ"+ TxtAdjudicacion.Text);
                    myCommand.Parameters["@NumCuota"].Value=Convert.ToInt16(DgvPagos.Rows[i].Cells[1].Value) ;
                    myCommand.Parameters["@Concepto"].Value = Convert.ToString(DgvPagos.Rows[i].Cells[0].Value);
                    myCommand.Parameters["@Capital"].Value=Capital;
                    myCommand.Parameters["@InteresCte"].Value = IntCte;
                    myCommand.Parameters["@InteresMora"].Value = IntMora;
                    myCommand.Parameters["@InteresCnd"].Value=Convert.ToDecimal(DgvPagos.Rows[i].Cells[12].Value);
                    myCommand.Parameters["@VrMoraCalc"].Value = Convert.ToDecimal(DgvPagos.Rows[i].Cells[10].Value);
                    myCommand.Parameters["@FechaCuota"].Value = Convert.ToDateTime(DgvPagos.Rows[i].Cells[2].Value);
                    
                    myCommand.CommandText = "Insert into Recaudos (IdRecaudo  ,  IdAdjudicacion  ,IdFinanciacion,    Recibo  ,  Fecha  ,  NumCuota  ,  Concepto  ," +
                                            "Capital  ,  InteresCte  ,  InteresMora ,  InteresCnd  ,  VrMoraCalc  ,  FechaOperacion  ,Usuario,Estado,Periodo,FechaCuota)" +
                                            "Values (@IdRecaudo  ,  @IdAdjudicacion  ,@IdFinanciacion,  @NumRecibo  ,  @Fecha  ,  @NumCuota  ,  @Concepto  ," +
                                            "@Capital  ,  @InteresCte  ,  @InteresMora ,  @InteresCnd  ,   @VrMoraCalc  ,  @FechaOperacion  ,@Usuario,@EstadoRec,@Periodo,@FechaCuota)";
                    myCommand.ExecuteNonQuery();

                    myCommand.CommandText = "Update Financiacion Set SaldoCapital=(SaldoCapital-@Capital),SaldoInteres=(SaldoInteres-@InteresCte),SaldoCuota=(SaldoCuota-@Capital-@InteresCte)," +
                    "UltimaFechaPago=@Fecha  Where IdCta=@IdFinanciacion";
                    myCommand.ExecuteNonQuery();
                    }
                }
                #endregion

                #region REGION CONTABLE

                myCommand.Parameters.Add("@IdDocumento", MySql.Data.MySqlClient.MySqlDbType.Int32);              
                myCommand.Parameters.Add("@Cuenta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Debe", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Haber", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Descuento", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Consecutivo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@motivo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Detalle", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Cheque", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@fuente", MySql.Data.MySqlClient.MySqlDbType.VarChar);                
                myCommand.Parameters.Add("@BaseRetencion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                
                myCommand.Parameters.Add("@CentroCostos", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@SubCentro", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.Int32);               
                myCommand.Parameters.Add("@Beneficiario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Factura", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Cero", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Add", MySql.Data.MySqlClient.MySqlDbType.VarChar);               
                myCommand.Parameters.Add("@Matricula", MySql.Data.MySqlClient.MySqlDbType.VarChar);


                myCommand.Parameters["@IdDocumento"].Value = IdDocumento;              
                myCommand.Parameters["@motivo"].Value = TxtMotivo.Text;
                myCommand.Parameters["@fuente"].Value = Fuente;
              
                myCommand.Parameters["@Estado"].Value = 1;         
                myCommand.Parameters["@Beneficiario"].Value = TxtNombre1.Text;
                myCommand.Parameters["@Cero"].Value = 0;
                myCommand.Parameters["@Add"].Value = "ADD";                
                myCommand.Parameters["@Matricula"].Value = TxtInmueble.Text;               
                myCommand.Parameters["@CentroCostos"].Value = Centrocosto;
                myCommand.Parameters["@SubCentro"].Value = Subcentro;
                myCommand.Parameters["@Detalle"].Value = "Recaudo Cartera  " + CmbOperacion.Text + " " + TxtAdjudicacion.Text;
                myCommand.Parameters["@Cheque"].Value = TxtRecibo.Text;
                myCommand.Parameters["@BaseRetencion"].Value = 0;
                myCommand.Parameters["@Factura"].Value = "ADJ"+TxtAdjudicacion.Text;

                cuentareg = cuentareg + 1;
                myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                myCommand.Parameters["@Debe"].Value = Convert.ToDecimal(TxtTotalRecaudo.Text);
                myCommand.Parameters["@Haber"].Value = 0;
                myCommand.Parameters["@Cuenta"].Value = CuentaDebe;
                
                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";
                               
                myCommand.ExecuteNonQuery();

                cuentareg = cuentareg + 1;
                myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                myCommand.Parameters["@Debe"].Value = 0;
                myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(TxtTotalCuota.Text);
                myCommand.Parameters["@Cuenta"].Value = CuentaHaber;


                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";
                myCommand.ExecuteNonQuery();

                if (Convert.ToDecimal(TxtTotalMora.Text) > 0)
                {
                    cuentareg = cuentareg + 1;
                    myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                    myCommand.Parameters["@Debe"].Value = 0;
                    myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(TxtTotalMora.Text);
                    myCommand.Parameters["@Cuenta"].Value = CuentaMora;


                    myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                    " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";
                    myCommand.ExecuteNonQuery();
                }

                #endregion

                myCommand.CommandText = "Update Contabilidad_alttum.documentomanual set Consecutivo=Consecutivo+1 ,ConsecutivoRef=ConsecutivoRef+1 Where idComprobante= @Fuente ";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Update Contabilidad_alttum.documento set Consecutivo=Consecutivo+1 Where idComprobante='99'";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.transacciones (IdTransaccion,Fecha,Transaccion,Fuente,Registro,Usuario) Values (@Transaccion ,Curdate(),'Add',@Fuente ,@IdDocumento,@Usuario)";
                myCommand.ExecuteNonQuery();

          

                myTrans.Commit();
                MessageBox.Show("Registro Adicionado", "Adicionar Recaudos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                BtnAceptar.Enabled = false;
                BtnNuevo.Visible = true;
                BtnImprimir.Visible = true;
                TxtidRecaudo.Text = "Rcd" + Consecutivo;
               

            }

                catch (MySqlException ex)
            {
                myTrans.Rollback();
               MessageBox.Show("Ha Ocurrido el sgte Error " + ex.Message, "Adicionar Recaudos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }
            MtdCambioEstado();
            panel2.Enabled = false;
           
        }
//===================================================================================================================================================
// F I N A L    M E T O D  O   A D I C I O N A R   R E C A U D O S
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O  M E T O D  O   A N U L A R 
//===================================================================================================================================================
        public void MtdAnular()
        {
            CuentaDebe = NuevoClsIdentificacion.MtdBscDatos("Select Debe   From Contabilidad_alttum.datoscuenta Where Operacion= 'Anulado' and Documento = '" + Fuente + "'");
            CuentaHaber = NuevoClsIdentificacion.MtdBscDatos("Select Haber  From Contabilidad_alttum.datoscuenta Where Operacion= 'Anulado' and Documento = '" + Fuente + "'");

            Consecutivo = NuevoClsIdentificacion.MtdBscDatos("select if(max(IdRecaudo)is null,1,max(IdRecaudo+1))from datosrecaudos");
            periodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "')");
            idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
            IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + Fuente + "'"));

            FrmLogeo.MysqlConexion.Open();
            MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
            myCommand.Connection = FrmLogeo.MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.Parameters.Add("@IdRecaudo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@NumRecibo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@CodBanco", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@FormaPago", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@DetalleRec", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@Transaccion", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@IdFinanciacion", MySql.Data.MySqlClient.MySqlDbType.String);
                myCommand.Parameters.Add("@NumCuota", MySql.Data.MySqlClient.MySqlDbType.Int16);
                myCommand.Parameters.Add("@Capital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@InteresCte", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@InteresMora", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@InteresCnd", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@VrMoraCalc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@EstadoRec", MySql.Data.MySqlClient.MySqlDbType.String);
                myCommand.Parameters.Add("@Periodo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@FechaCuota", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.String);


                myCommand.Parameters["@IdRecaudo"].Value = Consecutivo;
                myCommand.Parameters["@IdAdjudicacion"].Value = 0;
                myCommand.Parameters["@Fecha"].Value = DtpFecha.Value;
                myCommand.Parameters["@NumRecibo"].Value = TxtRecibo.Text;
                myCommand.Parameters["@IdTercero"].Value = IdTercero;
                myCommand.Parameters["@Operacion"].Value = CmbOperacion.Text;
                myCommand.Parameters["@Valor"].Value =0;
                myCommand.Parameters["@CodBanco"].Value = TxtCodBan.Text;
                myCommand.Parameters["@FormaPago"].Value = CmbFormaPago.Text;
                myCommand.Parameters["@DetalleRec"].Value ="ANULADO";
                myCommand.Parameters["@Usuario"].Value = FrmLogeo.FrmUsuarioIdUsr;
                myCommand.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                myCommand.Parameters["@Transaccion"].Value = idtransacciones;
                myCommand.Parameters["@EstadoRec"].Value = Estado;
                myCommand.Parameters["@Periodo"].Value = Convert.ToInt32(periodo);


                myCommand.Parameters.Add("@IdDocumento", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@Cuenta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Debe", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Haber", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Descuento", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Consecutivo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@motivo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Detalle", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Cheque", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@fuente", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@BaseRetencion", MySql.Data.MySqlClient.MySqlDbType.Decimal);

                myCommand.Parameters.Add("@CentroCostos", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@SubCentro", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@Beneficiario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Factura", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Cero", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@Add", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Matricula", MySql.Data.MySqlClient.MySqlDbType.VarChar);


                myCommand.Parameters["@IdDocumento"].Value = IdDocumento;
                myCommand.Parameters["@motivo"].Value = TxtMotivo.Text;
                myCommand.Parameters["@fuente"].Value = Fuente;

                myCommand.Parameters["@Estado"].Value = 1;
                myCommand.Parameters["@Beneficiario"].Value = TxtNombre1.Text;
                myCommand.Parameters["@Cero"].Value = 0;
                myCommand.Parameters["@Add"].Value = "ADD";
                myCommand.Parameters["@Matricula"].Value = TxtInmueble.Text;
                myCommand.Parameters["@CentroCostos"].Value = Centrocosto;
                myCommand.Parameters["@SubCentro"].Value = Subcentro;
                myCommand.Parameters["@Detalle"].Value = "ANULADO";
                myCommand.Parameters["@Cheque"].Value = TxtRecibo.Text;
                myCommand.Parameters["@BaseRetencion"].Value = 0;
                myCommand.Parameters["@Factura"].Value = "ADJ0" ;

                
                myCommand.Parameters["@Consecutivo"].Value = 1;
                myCommand.Parameters["@Debe"].Value = 0;
                myCommand.Parameters["@Haber"].Value = 0;
                myCommand.Parameters["@Cuenta"].Value = CuentaDebe;

                  
               


                myCommand.CommandText = "insert into Datosrecaudos (IdRecaudo ,  IdAdjudicacion ,  Fecha ,  NumRecibo,    Operacion    ,  Valor,Detalle,Usuario,FechaOperacion,Transaccion  ) " +
                    "Values (@IdRecaudo ,  @IdAdjudicacion ,  @Fecha ,  @NumRecibo,    @Operacion    ,  @Valor, @DetalleRec,@Usuario,@FechaOperacion,@Transaccion  )";
                myCommand.ExecuteNonQuery();


                myCommand.CommandText = "Insert into Recaudos (IdRecaudo  ,  IdAdjudicacion  ,IdFinanciacion,    Recibo  ,  Fecha  ,    FechaOperacion  ,Usuario,Estado,Periodo)" +
                              "Values (@IdRecaudo  ,  @IdAdjudicacion  ,@IdFinanciacion,  @NumRecibo  ,  @Fecha  ,  @FechaOperacion  ,@Usuario,@EstadoRec,@Periodo)";
                myCommand.ExecuteNonQuery();


                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula)  " +
                " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula)";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Update Contabilidad_alttum.documentomanual set Consecutivo=Consecutivo+1 ,ConsecutivoRef=ConsecutivoRef+1 Where idComprobante= @Fuente ";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Update Contabilidad_alttum.documento set Consecutivo=Consecutivo+1 Where idComprobante='99'";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.transacciones (IdTransaccion,Fecha,Transaccion,Fuente,Registro,Usuario) Values (@Transaccion ,@FechaOperacion,@Add,@Fuente ,@IdDocumento,@Usuario)";
                myCommand.ExecuteNonQuery();

                myTrans.Commit();
                MessageBox.Show("Registro Adicionado", "Anular Recibo",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

                BtnAceptar.Enabled = false;
               

                TxtidRecaudo.Text = "Rcd" + Consecutivo;
                MtdDatosInicio();

            }
            catch (Exception e)
            {

                myTrans.Rollback();

                MessageBox.Show("Ha Ocurrido el sgte Error " + e.Message,"Anular Recibo",MessageBoxButtons.AbortRetryIgnore,MessageBoxIcon.Error);

            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }

          
        }
//===================================================================================================================================================
// F I N A L    M E T O D  O   A N U L A R
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D  O   A D I C I O N A R   R E C A U D O S  P O S F E C H A D  O S
//===================================================================================================================================================
        public void MtdAddPosfechado()
        {
            Consecutivo = NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo From Consecutivos  Where Prefijo= 'Pos'");
            CuentaDebe = NuevoClsIdentificacion.MtdBscDatos("Select Debe From Contabilidad_alttum.datoscuenta Where Operacion= '" + CmbFormaPago.Text + "'");
            CuentaHaber = NuevoClsIdentificacion.MtdBscDatos("Select Haber From Contabilidad_alttum.datoscuenta Where Operacion= '" + CmbFormaPago.Text + "'");
            FechaAsiento = NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value);
            idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
            IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + Fuente + "'"));
            periodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "')");
            FrmLogeo.MysqlConexion.Open();
            MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
            myCommand.Connection = FrmLogeo.MysqlConexion;
            myCommand.Transaction = myTrans;

            string AddPosfechado = "Insert into posfechado (IdPosfechado,IdAdjudicacion,Fecha ,FechaPresentacion,Recibo ,Valor,Banco,Usuario,FechaOperacion,Estado)value (" +
                Convert.ToInt16(Consecutivo) + ",'" + TxtAdjudicacion.Text + "','" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "','" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaPresentacion.Value) +
                "','" + TxtRecibo.Text + "'," + Convert.ToDouble(TxtTotalRecaudo.Text) + ",'" + TxtCodBan.Text + "','" + FrmLogeo.Usuario + "',curdate(),'Pendiente')";

            try
            {
                myCommand.CommandText = AddPosfechado;
                myCommand.ExecuteNonQuery();


                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario,Matricula) VALUES (" +
                  IdDocumento + ",'" + FechaAsiento + "','" + CuentaDebe + "'," + Convert.ToDouble(TxtTotalRecaudo.Text) + "," + 0 + "," + 1 + ",'" + TxtMotivo.Text + "','" + "Recaudo Cartera  " + CmbOperacion.Text + " " + TxtAdjudicacion.Text + "','" + TxtRecibo.Text + "','" + Fuente + "','" + IdTercero + "'," +
                  0 + "," + periodo + "," + FrmLogeo.CentroCosto + "," + 1 + ",1," + idtransacciones + ",'" + TxtNombre1.Text + "','" + TxtInmueble.Text + "')";
                myCommand.ExecuteNonQuery();


                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario,Matricula) VALUES (" +
                   IdDocumento + ",'" + FechaAsiento + "','" + CuentaHaber + "'," + 0 + "," + Convert.ToDouble(TxtTotalRecaudo.Text) + "," + 2 + ",'" + TxtMotivo.Text + "','" + "Recaudo Cartera  " + CmbOperacion.Text + " " + TxtAdjudicacion.Text + "','" + TxtRecibo.Text + "','" + Fuente + "','" + IdTercero + "'," +
                   0 + "," + periodo + "," + FrmLogeo.CentroCosto + "," + 1 + ",1," + idtransacciones + ",'" + TxtNombre1.Text + "','" + TxtInmueble.Text + "')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Update Contabilidad_alttum.documentomanual set Consecutivo=Consecutivo+1 ,ConsecutivoRef=ConsecutivoRef+1 Where idComprobante= '" + Fuente + "'";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Update Contabilidad_alttum.documento set Consecutivo=Consecutivo+1 Where idComprobante='99'";
                myCommand.ExecuteNonQuery();




                myCommand.CommandText = "Update Consecutivos set Consecutivo=Consecutivo+1 Where Prefijo='Pos'";
                myCommand.ExecuteNonQuery();


                myTrans.Commit();
                MessageBox.Show("Registro Adicionado", "Registro Adicionado");

                BtnAceptar.Enabled = false;
                BtnNuevo.Visible = true;


                MtdDatosInicio();

            }
            catch (Exception e)
            {

                myTrans.Rollback();

                MessageBox.Show("Ha Ocurrido el sgte Error " + e.Message);

            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }

            MtdCambioEstado();

        }
//===================================================================================================================================================
// F I N A L    M E T O D  O   A D I C I O N A R   R E C A U D O S  P O S F E C H A D O S
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D  O  M O D I F I C A R   P O S F E C H A D O S
//===================================================================================================================================================
        public void MtdModPosfechado()
        {
            periodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "')");
            FrmLogeo.MysqlConexion.Open();
            MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
            myCommand.Connection = FrmLogeo.MysqlConexion;
            myCommand.Transaction = myTrans;

            string ModPosfechado = "Update posfechado set " +
            "Fecha = '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) +
            "',FechaPresentacion = '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaPresentacion.Value) +
            "', Recibo = '" + TxtRecibo.Text + "' , Valor = " + Convert.ToDouble(TxtTotalRecaudo.Text) +
            ", Banco = '" + TxtCodBan.Text + "', Usuario = '" + FrmLogeo.Usuario + "', FechaOperacion = curdate() Where Idposfechado = " + Convert.ToInt16(VarIdPosfechado) + "";


            try
            {
                myCommand.CommandText = ModPosfechado;
                myCommand.ExecuteNonQuery();



                myTrans.Commit();
                MessageBox.Show("Registro Modificado", "Registro Modificado");

                BtnAceptar.Enabled = false;


            }
            catch (Exception e)
            {

                myTrans.Rollback();

                MessageBox.Show("Ha Ocurrido el sgte Error " + e.Message);

            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }


        }
//===================================================================================================================================================
// F I N A L    M E T O D  O   M O D I F I C A R   P O S F E C H A D O S
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D  O  E L I M I N A R   P O S F E C H A D O S
//===================================================================================================================================================
        public void MtdDelPosfechado()
        {
            Fuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = '" + CmbFormaPago.Text + "'");
            IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + Fuente + "'"));
            idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
            string CuentaDebePos = NuevoClsIdentificacion.MtdBscDatos("Select Haber From Contabilidad_alttum.datoscuenta Where Operacion= 'Posfechado'");
            string CuentaHaberPos = NuevoClsIdentificacion.MtdBscDatos("Select Debe From Contabilidad_alttum.datoscuenta Where Operacion= 'Posfechado'");
            periodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "')");
            FechaAsiento = NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value);
            FrmLogeo.MysqlConexion.Open();
            MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
            myCommand.Connection = FrmLogeo.MysqlConexion;
            myCommand.Transaction = myTrans;

            string DelPosfechado = "Update  posfechado set Estado = 'Eliminado'  Where Idposfechado = " + (VarIdPosfechado);


            try
            {
                myCommand.CommandText = DelPosfechado;
                myCommand.ExecuteNonQuery();





                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario,Matricula) VALUES (" +
                IdDocumento + ",'" + FechaAsiento + "','" + CuentaDebePos + "'," + Convert.ToDouble(TxtTotalRecaudo.Text) + "," + 0 + "," + 1 + ",'" + TxtMotivo.Text + "','" + "Recaudo Cartera  " + CmbOperacion.Text + " " + TxtAdjudicacion.Text + "','" + TxtRecibo.Text + "','" + Fuente + "','" + IdTercero + "'," +
                0 + "," + periodo + "," + FrmLogeo.CentroCosto + "," + 1 + ",1," + idtransacciones + ",'" + TxtNombre1.Text + "','" + TxtInmueble.Text + "')";
                myCommand.ExecuteNonQuery();


                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario,Matricula) VALUES (" +
                   IdDocumento + ",'" + FechaAsiento + "','" + CuentaHaberPos + "'," + 0 + "," + Convert.ToDouble(TxtTotalRecaudo.Text) + "," + 2 + ",'" + TxtMotivo.Text + "','" + "Recaudo Cartera  " + CmbOperacion.Text + " " + TxtAdjudicacion.Text + "','" + TxtRecibo.Text + "','" + Fuente + "','" + IdTercero + "'," +
                   0 + "," + periodo + "," + FrmLogeo.CentroCosto + "," + 1 + ",1," + idtransacciones + ",'" + TxtNombre1.Text + "','" + TxtInmueble.Text + "')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Update Contabilidad_alttum.documentomanual set Consecutivo=Consecutivo+1 ,ConsecutivoRef=ConsecutivoRef+1 Where idComprobante= '" + Fuente + "'";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Update Contabilidad_alttum.documento set Consecutivo=Consecutivo+1 Where idComprobante='99'";
                myCommand.ExecuteNonQuery();




                myCommand.CommandText = "Update Consecutivos set Consecutivo=Consecutivo+1 Where Prefijo='Pos'";
                myCommand.ExecuteNonQuery();

                myTrans.Commit();
                MessageBox.Show("Registro Eliminado", "Registro Eliminado");

                BtnAceptar.Enabled = false;
            }
            catch (Exception e)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el sgte Error " + e.Message);
            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }
        }
//===================================================================================================================================================
// F I N A L    M E T O D  O    E L I M I N A R   P O S F E C H A D O S
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O  S   G E N  E R A L E S
//===================================================================================================================================================
        public void MtdDatosGrl()
        {           
            DtDatosGral = NuevoClsIdentificacion.MtdBuscarDataset("Select IdTercero1,Identificacion,TipodeAdjudicacion,Temporada,Grado,IdInmueble From 004cnsadjudica WHERE IdAdjudicacion = " + TxtAdjudicacion.Text );
            Pendiente = Convert.ToDouble(NuevoClsIdentificacion.MtdBscDatos("select if(sum(capital+interescte)is null,0,sum(capital+interescte))as Pendiente from recaudos " +
            " where estado = 'pendiente'  and  IdAdjudicacion = " + TxtAdjudicacion.Text ));
            TxtNombre1.Text = DtDatosGral.Rows[0][1].ToString();
            TxtTipoAdj.Text = DtDatosGral.Rows[0][2].ToString();
            TxtTemporada.Text = DtDatosGral.Rows[0][3].ToString();
            TxtGrado.Text = DtDatosGral.Rows[0][4].ToString();
            TxtInmueble.Text = DtDatosGral.Rows[0][5].ToString();
            IdTercero = DtDatosGral.Rows[0][0].ToString();
            TxtCanjePdt.Text = Convert.ToString(Pendiente);
            this.TxtCanjePdt.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtCanjePdt.Text));
        }
//===================================================================================================================================================
// F I N   M E T O D O   D A T O  S   G E N  E R A L E S
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O  S   G R I L L A
//===================================================================================================================================================
        public void MtdDatosGrilla()
        {
            DgvPagos.Rows.Clear();           
            decimal MoraCalc=0;  
            {
                for (int i = 0; i < (DtGrilla.Rows.Count); i++)
                { 
                    DgvPagos.Rows.Add(DtGrilla.Rows[i][1], DtGrilla.Rows[i][2], DtGrilla.Rows[i][3], DtGrilla.Rows[i][12],DtGrilla.Rows[i][7],
                    DtGrilla.Rows[i][11], DtGrilla.Rows[i][4], DtGrilla.Rows[i][5], DtGrilla.Rows[i][6], DtGrilla.Rows[i][8], DtGrilla.Rows[i][9],
                    DtGrilla.Rows[i][10], DtGrilla.Rows[i][14]);    
                }
            }
            MaxDiasMora = 0;
            for (int i = 0; i < (DgvPagos.Rows.Count); i++)
            {
                if ((Convert.ToInt16(DgvPagos.Rows[i].Cells[3].Value) > MaxDiasMora))
                {
                    MaxDiasMora = Convert.ToInt16(DgvPagos.Rows[i].Cells[3].Value);
                }
            }
            TxtDiasMora.Text = Convert.ToString(MaxDiasMora);

            if (MaxDiasMora > Convert.ToInt16(StrDiaMora))
            {
                TxtTasaMora.Text = StrInteresMora;
                MoraCalc=1;
            }
            else
            {
               TxtTasaMora.Text = "0";
                MoraCalc=0;
            }

            for (int i = 0; i < (DgvPagos.Rows.Count); i++)
            {                
                DgvPagos.Rows[i].Cells[10].Value= Convert.ToDecimal(DgvPagos.Rows[i].Cells[10].Value)*MoraCalc;
                DgvPagos.Rows[i].Cells[11].Value =Convert.ToDecimal( DgvPagos.Rows[i].Cells[10].Value) + Convert.ToDecimal(DgvPagos.Rows[i].Cells[9].Value);
                DgvPagos.Rows[i].Cells[13].Value = Convert.ToDecimal(DgvPagos.Rows[i].Cells[11].Value) + Convert.ToDecimal(DgvPagos.Rows[i].Cells[8].Value) - Convert.ToDecimal(DgvPagos.Rows[i].Cells[12].Value);
            }

            SumPagoMinimo = 0;
            VarValor = 0;
            VarMora = 0;
            TxtPagoTotal.Text = "0";
            TxtInteresesMora.Text = "0";
            TxtPagoMin.Text = "0";
            TxtCtaVda.Text = "0";           
          
            CuotasVdas = 0;
            for (int i = 0; i < (DgvPagos.Rows.Count); i++)
            {
                VarValor += Convert.ToDouble(DgvPagos.Rows[i].Cells[13].Value);
                VarMora += Convert.ToDouble(DgvPagos.Rows[i].Cells[11].Value);

                if ((Convert.ToDateTime(DgvPagos.Rows[i].Cells[2].Value) <= DateTime.Now))
                {
                    SumPagoMinimo += Convert.ToDouble(Convert.ToString(DgvPagos.Rows[i].Cells[13].Value));
                    CuotasVdas = CuotasVdas + 1;
                }               
                TxtCtaVda.Text = Convert.ToString(CuotasVdas);
                TxtPagoMin.Text = Convert.ToString(SumPagoMinimo);
                TxtPagoTotal.Text = Convert.ToString(VarValor);
                TxtInteresesMora.Text = Convert.ToString(VarMora);  
            }
            MtdFormato();
    }
//===================================================================================================================================================
// F I N   M E T O D O   D A T O  S   G R I L L A
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   F O R M A T O
//===================================================================================================================================================
        public void MtdFormato()
        {
            this.TxtTasaMora.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtTasaMora.Text));
            this.TxtInteresesMora.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtInteresesMora.Text));
            this.TxtTotalRecaudo.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtTotalRecaudo.Text));
            this.TxtPagoTotal.Text = String.Format("{0:#,##0.00;#,-##0.00;0.00}", decimal.Parse(this.TxtPagoTotal.Text));
            this.TxtInteresesMora.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtInteresesMora.Text));
            this.TxtPagoMin.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtPagoMin.Text));
            this.TxtTotalCuota.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtTotalCuota.Text));
            this.TxtTotalMora.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtTotalMora.Text));    
        }
//===================================================================================================================================================
// F I N   M E T O D O    F O R M A T O
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O M E T O D O  C A M B I O    D E   E S T A D O
//===================================================================================================================================================
        public void MtdCambioEstado()
        {
            string ModEstado = "Update Adjudicacion set Estado ='Pagado' , FechaOperacion= curdate() where  idadjudicacion= '" + TxtAdjudicacion.Text + "'";
            NuevoSaldoTotal = Convert.ToDouble(NuevoClsIdentificacion.MtdBscDatos("select sum(cuota) FROM 004carterarecaudos where idadjudicacion=" + TxtAdjudicacion.Text ));
            if (NuevoSaldoTotal == 0)
            {
                FrmLogeo.MysqlConexion.Open();
                MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
                myCommand.Connection = FrmLogeo.MysqlConexion;
                myCommand.Transaction = myTrans;

                try
                {
                    myCommand.CommandText = ModEstado;
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = "insert into documentacion (fecha,FechaRecibe,Operacion,IdAdjudicacion,UsuarioEnvio,Estado) VALUES  (curdate(), curdate(),'Pagado','" + TxtAdjudicacion.Text + "','" + FrmLogeo.Usuario + "','Enviado')";
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Credito cancelado en su totalidad, su nuevo estado es pagado","Adicionar Recaudos",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }                
                catch (Exception e)
                {
                    myTrans.Rollback(); 
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " +e.Message,"Adicionar Recaudo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                finally
                {
                    FrmLogeo.MysqlConexion.Close();
                }
            }
        }
//===================================================================================================================================================
// F I N A L M E T O D O   C A M B  I  O   D E   E S T A  D O
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O M E T O D O  C A M B I O    D E   E S T A D O
//===================================================================================================================================================
        public void MtdCambiarPosfecha()
        {
            periodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "')");
            string CuentaDebePos = NuevoClsIdentificacion.MtdBscDatos("Select Haber From Contabilidad_alttum.datoscuenta Where Operacion= 'Posfechado'");
            string CuentaHaberPos = NuevoClsIdentificacion.MtdBscDatos("Select Debe From Contabilidad_alttum.datoscuenta Where Operacion= 'Posfechado'");
            string ModEstado = "Update posfechado set Estado ='Consignado' , FechaOperacion= curdate() where  IdPosfechado= '" +VarIdPosfechado + "'";

            string MensajeSalida = "";

            FrmLogeo.MysqlConexion.Open();
            MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
            myCommand.Connection = FrmLogeo.MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = ModEstado;
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario,Matricula) VALUES (" +
              IdDocumento + ",'" + FechaAsiento + "','" + CuentaDebePos + "'," + Convert.ToDouble(TxtTotalRecaudo.Text) + "," + 0 + "," + 4 + ",'" + TxtMotivo.Text + "','" + "Recaudo Cartera  " + CmbOperacion.Text + " " + TxtAdjudicacion.Text + "','" + RefPosfecha + "','" + Fuente + "','" + IdTercero + "'," +
              0 + "," + periodo + "," + 1 + "," + 1 + ",1," + idtransacciones + ",'" + TxtNombre1.Text + "','" + TxtInmueble.Text + "')";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario,Matricula) VALUES (" +
              IdDocumento + ",'" + FechaAsiento + "','" + CuentaHaberPos + "'," + 0 + "," + Convert.ToDouble(TxtTotalCuota.Text) + "," + 3 + ",'" + TxtMotivo.Text + "','" + "Recaudo Cartera  " + CmbOperacion.Text + " " + TxtAdjudicacion.Text + "','" + RefPosfecha + "','" + Fuente + "','" + IdTercero + "'," +
              0 + "," + periodo + "," + 1 + "," + 1 + ",1," + idtransacciones + ",'" + TxtNombre1.Text + "','" + TxtInmueble.Text + "')";
                myCommand.ExecuteNonQuery();
                
                myTrans.Commit();

            }
            catch (Exception e)
            {
                MensajeSalida = "Ocurrio el sgte Error " + e.Message;
            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }
        }
//===================================================================================================================================================
// F I N A L M E T O D O   C A M B  I  O   D E   E S T A  D O
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O    B O T O N   A C E P T A R
//===================================================================================================================================================
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (EntradaRecaudos)
            {
                case 1:
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
                        rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (rest == DialogResult.Yes)
                        {
                            if (CmbFormaPago.Text != "Posfechado")
                            {
                                MtdAddRecaudo();
                            }

                            else
                            {
                                MtdAddPosfechado();
                            }
                        }
                    }
                    break;


                case 2:
                    #region VARIABLES
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
                        rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (rest == DialogResult.Yes)
                        {
                            if (CmbFormaPago.Text != "Posfechado")
                            {
                                MtdAddRecaudo();
                            }

                            else
                            {
                                MtdAddPosfechado();
                            }
                        }
                    }
                    #endregion
                    break;



                case 8:
                    DialogResult rest1;
                        rest1 = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (rest1 == DialogResult.Yes)
                        {
                            Consecutivo = NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo From Consecutivos  Where Prefijo= 'Rcd'");
                            CuentaDebe = NuevoClsIdentificacion.MtdBscDatos("Select Debe From Contabilidad_alttum.datoscuenta Where Operacion= '" + CmbFormaPago.Text + "'");
                            CuentaHaber = NuevoClsIdentificacion.MtdBscDatos("Select Haber From Contabilidad_alttum.datoscuenta Where Operacion= '" + CmbFormaPago.Text + "'");
                            FechaAsiento = NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value);
                            idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
                            IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + Fuente + "'"));
                            Estado = "Pendiente";
                            MtdAddRecaudo();
                            MtdCambiarPosfecha();
                        }
                    break;

                case 9:
                    MtdModPosfechado();
                    break;

                case 10:
                    MtdDelPosfechado();
                    break;

                case 11:
                    DialogResult rest2;
                        rest2 = MessageBox.Show("Esta seguro de Anular Este Recibo", "Anular Recibo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (rest2 == DialogResult.Yes)
                        {
                            Consecutivo = NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo From Consecutivos  Where Prefijo= 'Rcd'");
                            CuentaDebe = NuevoClsIdentificacion.MtdBscDatos("Select Debe From Contabilidad_alttum.datoscuenta Where Operacion= '" + CmbFormaPago.Text + "'");                          
                            FechaAsiento = NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value);
                            idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
                            IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + Fuente + "'"));
                            MtdAnular();
                        }
                    break;
                default:

                    break;


            }

        }
//===================================================================================================================================================
//F I N A L      B O T O N   A C E P T A R
//===================================================================================================================================================
       





        #region EVENTOS


//===================================================================================================================================================
//I N I C I O   E V E N T O  FrmRecaudoPorCuotas_Load
//===================================================================================================================================================
        private void FrmRecaudoPorCuotas_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            BtnAceptar.Enabled = NuevoClsIdentificacion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "401");
            DtParametros = NuevoClsIdentificacion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
            StrInteresCte = DtParametros.Rows[0][0].ToString();
            StrInteresMora = DtParametros.Rows[0][1].ToString();
            StrPeriodo = DtParametros.Rows[0][2].ToString();
            StrDiaMora = DtParametros.Rows[0][3].ToString();
            StrDecimales = DtParametros.Rows[0][5].ToString();
            Fuente = DtParametros.Rows[0][6].ToString();
            Centrocosto=DtParametros.Rows[0][7].ToString();
            Subcentro = DtParametros.Rows[0][8].ToString();
            TxtAdjudicacion.Text = VarIdAdjudicacion;

            if (CmbFormaPago.Text == "Posfechado")
            {
                Fuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = '" + CmbFormaPago.Text + "'");          
            }

            if (tipor == "Recibo Pago")
            {

                Fuente = "RP-01";
                TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));
                TxtRecibo.Text = "P-" + TxtRecibo.Text;
            }
            else
            {
                TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '"+Fuente+"'");
                Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));


            }
          
            
            if (Automatico == true)
            {
                TxtRecibo.Enabled = false;
            }

            else
            {
                TxtRecibo.Enabled = true;
            }

            CmbFormaPago.DataSource = NuevoClsIdentificacion.MtdListaCamposSent("(SELECT * FROM Contabilidad_alttum.datoscuenta WHERE IdTransaccionesAuto =1 AND (documento= '" + Fuente + "' OR documento ='PF'  OR documento ='N-CR'))", "Operacion");
            MtdDatosInicio();
        }
//===================================================================================================================================================
//F I N A  L    E V E N T O  FrmRecaudoPorCuotas_Load
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O S   I N I C I O
//===================================================================================================================================================
        public void MtdDatosInicio()
        {
            CmbFormaPago.Text = "";
            string Sentencia2 = "";
            CmbOperacion.Text = "";
            //TxtRecibo.Clear();
            TxtTotalRecaudo.Text = "0";
            TxtCodBan.Clear();
            TxtTotalMora.Text = "0";
            TxtTotalRecaudo.Text = "0";
            if (EntradaRecaudos != 11)
            {

                Sentencia2 = NuevoClsIdentificacion.MtdNuevoScripRecaudo(TxtAdjudicacion.Text, Convert.ToDecimal(StrInteresMora), Convert.ToInt16(StrDecimales)); 
            MtdDatosGrl();
            DtGrilla = NuevoClsIdentificacion.MtdBuscarDataset(Sentencia2 + "order by car.Fecha");
            MtdDatosGrilla();
            }
            switch (EntradaRecaudos)
            {
                case 1:
                    BtnAceptar.Visible = true;
                    DgvPagos.Columns[14].ReadOnly = false;
                    TxtTotalRecaudo.ReadOnly = true;
                    LblTitulo.Text = "ADICIONAR CARTERA POR CUOTAS";
                    break;

                case 2:
                    BtnAceptar.Visible = true;
                    DgvPagos.Columns[14].ReadOnly = true;
                    TxtTotalRecaudo.ReadOnly = false;
                    LblTitulo.Text = "ADICIONAR CARTERA NORMAL";
                    break;

                case 5:
                    BtnAceptar.Visible = false;
                    panel2.Visible = false;
                    LblTitulo.Text = "CONSULTA DE CARTERA";
                    break;

                case 8:
                    DtPosfechado = NuevoClsIdentificacion.MtdBuscarDataset("Select * From posfechado Where IdPosfechado = " + VarIdPosfechado);
                    BtnAceptar.Visible = true;
                    DgvPagos.Columns[14].ReadOnly = true;
                    TxtTotalRecaudo.ReadOnly = true;
                    LblTitulo.Text = "CONSIGNAR CHEQUE POSFECHADO";
                    CmbFormaPago.Text = "Cheque";
                    CmbFormaPago.Enabled = false;
                    LblCodigoBanco.Visible = true;
                    TxtCodBan.Visible = true;
                    Fuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = '" + CmbFormaPago.Text + "'");
           
                    
                 //   TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");

                    if (tipor == "Recibo Pago")
                    {

                        Fuente = "RP-01";
                        TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                        Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));
                        TxtRecibo.Text = "P-" + TxtRecibo.Text;
                    }
                    else
                    {
                        TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                        Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));


                    }
                    RefPosfecha = DtPosfechado.Rows[0][4].ToString();
                    TxtTotalRecaudo.Text = DtPosfechado.Rows[0][5].ToString();
                    TxtCodBan.Text = DtPosfechado.Rows[0][6].ToString();
                    MtdCuotasPagar();
                    break;

                case 9:
                    DtPosfechado = NuevoClsIdentificacion.MtdBuscarDataset("Select * From posfechado Where IdPosfechado = " +VarIdPosfechado);
                    BtnAceptar.Visible = true;
                    TxtTotalRecaudo.ReadOnly = false;
                    DgvPagos.Columns[14].ReadOnly = false;
                    LblTitulo.Text = "MODIFICAR RECAUDO CHEQUE POSFECHADO";
                    CmbFormaPago.Text = "Posfechado";
                    CmbFormaPago.Enabled = false;
                    LblCodigoBanco.Visible = true;
                    TxtCodBan.Visible = true;
                    TxtRecibo.Text = DtPosfechado.Rows[0][4].ToString();
                    TxtTotalRecaudo.Text = DtPosfechado.Rows[0][5].ToString();
                    TxtCodBan.Text = DtPosfechado.Rows[0][6].ToString();
                    BtnAceptar.Text = "Modificar";
                    break;

                case 10:
                    DtPosfechado = NuevoClsIdentificacion.MtdBuscarDataset("Select * From posfechado Where IdPosfechado = " + VarIdPosfechado);
                    BtnAceptar.Visible = true;
                    DgvPagos.Columns[14].ReadOnly = false;
                    LblTitulo.Text = "ELIMINAR RECAUDO CHEQUE POSFECHADO";
                    CmbFormaPago.Text = "Posfechado";
                    LblCodigoBanco.Visible = true;
                    TxtCodBan.Visible = true;
                    TxtRecibo.Text = DtPosfechado.Rows[0][4].ToString();
                    TxtTotalRecaudo.Text = DtPosfechado.Rows[0][5].ToString();
                    TxtCodBan.Text = DtPosfechado.Rows[0][6].ToString();
                    Fuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = '" + CmbFormaPago.Text + "'");

                    if (tipor == "Recibo Pago")
                    {

                        Fuente = "RP-01";
                        TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                        Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));
                        TxtRecibo.Text = "P-" + TxtRecibo.Text;
                    }
                    else
                    {
                        TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                        Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));


                    }
                    
                 //   TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                    TxtMotivo.Text = "Cheque Eliminado";
                    BtnAceptar.Text = "Eliminar";
                    break;
                case 11:

                    BtnAceptar.Visible = true;
                    TxtMotivo.Text = "Recibo Anulado";
                    LblTitulo.Text = "ANULAR RECIBO";
                    CmbFormaPago.Text = "Anulado";
                    BtnAceptar.Text = "Anular";
                    break;

                default:

                    break;
            }
        }
//===================================================================================================================================================
// F I N   M E T O D O   D A T O  S   I N I C I O
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   E V E N T O  DgvPagos_KeyPress
//===================================================================================================================================================
        private void DgvPagos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

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
//===================================================================================================================================================
//F I N A L  E V E N T O     DgvPagos_KeyPress
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   E V E N T O  DgvPagos_EditingControlShowing
//===================================================================================================================================================
        private void DgvPagos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvPagos.CurrentCell.ColumnIndex == 8)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvPagos_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvPagos_KeyPress);
                }
            }
        }
//===================================================================================================================================================
//F I N A L  E V E N T O     DgvPagos_EditingControlShowing
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   E V E N T O  DgvPagos_CellValidated
//===================================================================================================================================================
        private void DgvPagos_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (EntradaRecaudos == 1)
            {
                if (DgvPagos.CurrentCell.ColumnIndex == 14)
                {
                    VarValor = 0;
                    for (int i = 0; i < (DgvPagos.Rows.Count); i++)
                    {
                        if ((Convert.ToString(DgvPagos.Rows[i].Cells[14].Value)) == "")
                        {
                            DgvPagos.Rows[i].Cells[10].Value = 0;

                        }
                        else
                            if ((Convert.ToDouble(DgvPagos.Rows[i].Cells[14].Value)) > (Convert.ToDouble(DgvPagos.Rows[i].Cells[13].Value)))
                            {
                                DgvPagos.Rows[i].Cells[14].Value = DgvPagos.Rows[i].Cells[13].Value;
                                VarValor += Convert.ToDouble(Convert.ToString(DgvPagos.Rows[i].Cells[14].Value));
                                TxtTotalRecaudo.Text = Convert.ToString(VarValor);
                            }
                            else
                            {
                                VarValor += Convert.ToDouble(Convert.ToString(DgvPagos.Rows[i].Cells[14].Value));
                                TxtTotalRecaudo.Text = Convert.ToString(VarValor);
                            }
                    }
                }
                this.TxtTotalRecaudo.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtTotalRecaudo.Text));
                MtdCuotasPagarCuota();
                MtdFormato();
            }
        }
//===================================================================================================================================================
//F I N A L  E V E N T O     DgvPagos_CellValidated
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   E V E N T O  CmbFormaPago_SelectedIndexChanged
//===================================================================================================================================================
        private void CmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TxtRecibo.Enabled = false;
            FormaPago = CmbFormaPago.Text;
            LblCodigoBanco.Visible = true;
            TxtCodBan.Visible = true;
            LblFechaPresentacion.Visible = false;
            DtpFechaPresentacion.Visible = false;

            if (CmbFormaPago.Text == "Posfechado")
            {
                Fuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = '" + CmbFormaPago.Text + "'");
            }
            else
                if (CmbFormaPago.Text == "Nota Credito")
                {
                    Fuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = '" + CmbFormaPago.Text + "'");
                }
                else

            {
                Fuente = DtParametros.Rows[0][6].ToString();
            }

            if (tipor == "Recibo Pago")
            {

                Fuente = "RP-01";
                TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));
                TxtRecibo.Text = "P-" + TxtRecibo.Text;
            }
            else
            {
                TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));


            }
        //    TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
            Estado = "Aprobado";
            //TxtRecibo.ReadOnly = true;
            switch (FormaPago)
            {
                   
                case "Efectivo":
                    LblCodigoBanco.Visible = false;
                    TxtCodBan.Visible = false;
                    break;

                case "Cheque":
                    Estado = "Pendiente";
                    break;
                case "ChequeGerencia":

                    break;

                case "TarjetaDebito":

                    break;

                case "TarjetaCredito":

                    break;

                case "Transferencia":

                    break;

                case "Cdt":

                    break;
                case "Posfechado":
                    LblFechaPresentacion.Visible = true;
                    DtpFechaPresentacion.Visible = true;
                    TxtRecibo.Enabled = true;
                   // TxtRecibo.ReadOnly = false;

                    break;
                default:

                    break;

            }
        }
//===================================================================================================================================================
//F I N A L  E V E N T O     CmbFormaPago_SelectedIndexChanged
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   E V E N T O  CmbOperacion_SelectedIndexChanged
//===================================================================================================================================================
        private void CmbOperacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            Operacion = CmbOperacion.Text;

            DgvPagos.Rows.Clear();
            switch (Operacion)
            {
                case "Cuota Inicial":
                                       
                SentenciaGrilla = NuevoClsIdentificacion.MtdNuevoScripRecaudo( TxtAdjudicacion.Text,Convert.ToDecimal(StrInteresMora),Convert.ToInt16(StrDecimales)); 
                DtGrilla = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaGrilla + " and Car.Concepto='CI' order by car.Fecha");
                MtdDatosGrilla();

                    break;

                case "Financiacion":

                    SentenciaGrilla = NuevoClsIdentificacion.MtdNuevoScripRecaudo(TxtAdjudicacion.Text, Convert.ToDecimal(StrInteresMora), Convert.ToInt16(StrDecimales)); 
                    DtGrilla = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaGrilla + "and (Car.Concepto='FN' or Car.Concepto='CM') order by car.Fecha");
                    MtdDatosGrilla();
                    break;
                case "Extraordinaria":

                    SentenciaGrilla = NuevoClsIdentificacion.MtdNuevoScripRecaudo(TxtAdjudicacion.Text, Convert.ToDecimal(StrInteresMora), Convert.ToInt16(StrDecimales)); 
                    DtGrilla = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaGrilla + "and Car.Concepto='CE' order by car.Fecha");
                    MtdDatosGrilla();

                    break;
                case "Contado":

                    SentenciaGrilla = NuevoClsIdentificacion.MtdNuevoScripRecaudo(TxtAdjudicacion.Text, Convert.ToDecimal(StrInteresMora), Convert.ToInt16(StrDecimales));                  
                    DtGrilla = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaGrilla + "and Car.Concepto='CO' order by car.Fecha");
                    //TxtTotalRecaudo.Text = "0";
                    MtdDatosGrilla();

                    break;


                case "Gastos":

                    SentenciaGrilla = NuevoClsIdentificacion.MtdNuevoScripRecaudo(TxtAdjudicacion.Text, Convert.ToDecimal(StrInteresMora), Convert.ToInt16(StrDecimales)); 
                    DtGrilla = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaGrilla + "and Car.Concepto='GA' order by car.Fecha");
                    //TxtTotalRecaudo.Text = "0";
                    MtdDatosGrilla();

                    break;
                case "Todos":

                    SentenciaGrilla = NuevoClsIdentificacion.MtdNuevoScripRecaudo(TxtAdjudicacion.Text, Convert.ToDecimal(StrInteresMora), Convert.ToInt16(StrDecimales));                 
                    DtGrilla = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaGrilla + " 'order by car.Fecha");
                    //TxtTotalRecaudo.Text = "0";
                    MtdDatosGrilla();
                    break;

                default:

                    break;
            }

            if (Convert.ToDouble(TxtTotalRecaudo.Text) > 0)
            {
                MtdCuotasPagar();
            }
            MtdFormato();
        }
//===================================================================================================================================================
//F I N A L  E V E N T O     CmbOperacion_SelectedIndexChanged
//===================================================================================================================================================

//===================================================================================================================================================
//I N I C I O   E V E N T O  TxtAdjudicacion_KeyPress
//===================================================================================================================================================
        private void TxtAdjudicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (TxtAdjudicacion.Text == "")
                {
                    MessageBox.Show("Falta Anotar Numero de Adjudicacion");
                }
                else
                {
                    double Contar = Convert.ToDouble(NuevoClsIdentificacion.MtdBscDatos("select count(IdAdjudicacion) from Adjudicacion where IdAdjudicacion = " +
                                   ( TxtAdjudicacion.Text) ));

                    if (Contar == 0)
                    {
                        MessageBox.Show("No Existe Adjudicacion");
                    }
                    else
                    {
                        string Estado = NuevoClsIdentificacion.MtdBscDatos("Select estado From Adjudicacion where IdAdjudicacion=" + ( TxtAdjudicacion.Text) );
                        if (Estado == "Aprobado")
                        {
                            TxtAdjudicacion.Text = (TxtAdjudicacion.Text);
                            MtdDatosInicio();
                        }

                        else
                        {
                            MessageBox.Show("Credito " + Estado, "Error Estado del credito");
                        }
                    }
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
//===================================================================================================================================================
//F I N A L  E V E N T O     TxtAdjudicacion_KeyPress
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   E V E N T O  BtnSalir_Click
//===================================================================================================================================================
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
//===================================================================================================================================================
//F I N A L  E V E N T O     BtnSalir_Click
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   E V E N T O  TxtTotalRecaudo_KeyPress
//===================================================================================================================================================
         private void TxtTotalRecaudo_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {
                if (EntradaRecaudos == 2)
                {
                    MtdCuotasPagar();
                    MtdFormato();
                    BtnAceptar.Focus();
                }
            }



            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtTotalRecaudo.Text.Length; i++)
            {
                if (TxtTotalRecaudo.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
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
//===================================================================================================================================================
//F I N A L  E V E N T O     TxtTotalRecaudo_KeyPress
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   E V E N T O  TxtTotalRecaudo_Leave
//===================================================================================================================================================
         private void TxtTotalRecaudo_Leave(object sender, EventArgs e)
        {
            if (TxtTotalRecaudo.Text == "")
            {
                TxtTotalRecaudo.Text = "0";
            }
            MtdCuotasPagar();
            MtdFormato();
        }
//===================================================================================================================================================
//F I N A L  E V E N T O     TxtTotalRecaudo_Leave
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   E V E N T O  BtnNuevo_Click
//===================================================================================================================================================
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            MtdDatosInicio();
            panel2.Enabled = true;
            BtnAceptar.Enabled = true;
            BtnNuevo.Visible = false;
            BtnImprimir.Visible = false;

            if (tipor == "Recibo Pago")
            {

                Fuente = "RP-01";
                TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));
                TxtRecibo.Text = "P-" + TxtRecibo.Text;
            }
            else
            {
                TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
                Automatico = Convert.ToBoolean(NuevoClsIdentificacion.MtdBscDatos("Select Automatico From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'"));


            }
           // TxtRecibo.Text = NuevoClsIdentificacion.MtdBscDatos("Select ConsecutivoRef From Contabilidad_alttum.documentomanual Where IdComprobante = '" + Fuente + "'");
            TxtTotalCuota.Text = "0";
            TxtTotalMora.Text = "0";
            TxtMotivo.Clear();
        }
//===================================================================================================================================================
//F I N A L  E V E N T O     BtnNuevo_Click
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   E V E N T O  TxtTasaMora_KeyPress
//===================================================================================================================================================
        private void TxtTasaMora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtTasaMora.Text.Length; i++)
            {
                if (TxtTasaMora.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
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
//===================================================================================================================================================
//F I N A L  E V E N T O    TxtTasaMora_KeyPress
//===================================================================================================================================================

        private void TxtMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtTotalRecaudo.Focus();
            }
        }
        
        private void DtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbOperacion.Focus();
            }
        }

        private void CmbOperacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtCodBan.Focus();
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {

            FrmImpRecibo recibo = new FrmImpRecibo();
            recibo.IdRecaudo = Consecutivo;
            recibo.Concepto = TxtMotivo.Text;
            recibo.Show();

            FrmRptRecibodeCaja rptingreso = new FrmRptRecibodeCaja();
            
            rptingreso.VarBenef = TxtNombre1.Text;
            rptingreso.VarMotivo = TxtMotivo.Text;
            rptingreso.VarNit = IdTercero;
            rptingreso.VarRecibo = TxtRecibo.Text;
            rptingreso.VarValor = TxtTotalRecaudo.Text;
            rptingreso.NumComprobante = IdDocumento;
            rptingreso.VarFuente = Fuente;
            rptingreso.VarTitulo = "RECIBO DE INGRESO";
            rptingreso.Text = "RECIBO DE INGRESO";
            rptingreso.Show();

        }

        #endregion

       


    }

}

