using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CarteraGeneral
{
    public partial class FrmPagodeComisiones : Form
    {
        public FrmPagodeComisiones()
        {
            InitializeComponent();
        }
       
       
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        DataTable DtDatos = new DataTable();
        DataTable DtDatosAdj = new DataTable();
        public int EntradaComision;
        decimal SumTotalCom, SumRetencion, SumDctoAnt, SumPagoNeto, SumComPagada, SumaCom1, SumaCom2, Sumalqd1, SumaLqd2, SumaCom3, Sumlqd3;
        string CuentaDebe, CuentaHaber,  CuentaAnticipo, Fuente, FechaAsiento, idtransacciones, IdDocumento,   VarFuente, Motivo,   VarPeriodo, VarCentroCostos;


     
        private void FrmPagos_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Usuario Conectado " + FrmLogeo.Usuario;
            pictureBox1.Image = FrmMenuGeneral.Logo;
            TxtAdjudicacion.DataSource = NuevoClsIdentificacion.MtdListaCamposSent(MisConsultas.ListaComisionesPorPagarNetas, "IdAdjudicacion");
            //Fuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = 'PagoComision'");
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            MtdAddComision();
        }

//===================================================================================================================================================
// I N I C I O   M E T O D O   C O N S U L T A R   C O M I S I O N
//===================================================================================================================================================
    public void MtdCnsComision()
        {
            DtDatos.Clear();
            DgvListado.Rows.Clear();
            DtDatos = NuevoClsIdentificacion.MtdBuscarDataset(MisConsultas.ConsultaPagoComisionPorAdj, TxtAdjudicacion.Text);
            {
                for (int i = 0; i < (DtDatos.Rows.Count); i++)
                {
                    DgvListado.Rows.Add(DtDatos.Rows[i][0], DtDatos.Rows[i][1], DtDatos.Rows[i][2], DtDatos.Rows[i][3], DtDatos.Rows[i][4], DtDatos.Rows[i][5],
                    DtDatos.Rows[i][6], DtDatos.Rows[i][7], DtDatos.Rows[i][8], DtDatos.Rows[i][9], DtDatos.Rows[i][10], DtDatos.Rows[i][11], DtDatos.Rows[i][12],
                    DtDatos.Rows[i][13], DtDatos.Rows[i][14], DtDatos.Rows[i][15], DtDatos.Rows[i][16]);
                }                    
            }
            MtdTotal();         

        }    
//===================================================================================================================================================
//F I N A L     M E T O D O   C O N S U L T A R    C O  M I S I O N
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O  T O T A L
//===================================================================================================================================================
        private void MtdTotal()
        {
                SumTotalCom = 0;
                SumDctoAnt = 0;
                SumPagoNeto = 0;
                SumRetencion = 0;
                SumComPagada = 0;
                SumaCom1 = 0;
                SumaCom2 = 0;
                SumaCom3 = 0;
                SumaLqd2 = 0;
                Sumalqd1 = 0;
                Sumlqd3 = 0;

                    BtnPagar.Visible = true;

                    for (int i = 0; i < (DgvListado.Rows.Count); i++)
                    {

                        SumaCom1 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[6].Value));
                        SumaCom2 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[7].Value));
                        SumaCom3 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[8].Value));

                        Sumalqd1 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[9].Value));
                        SumaLqd2 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[10].Value));
                        Sumlqd3 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[11].Value));

                        SumComPagada += (Convert.ToDecimal(DgvListado.Rows[i].Cells[12].Value));
                        SumTotalCom += (Convert.ToDecimal(DgvListado.Rows[i].Cells[13].Value));
                        SumRetencion += (Convert.ToDecimal(DgvListado.Rows[i].Cells[14].Value));
                        SumDctoAnt += (Convert.ToDecimal(DgvListado.Rows[i].Cells[15].Value));
                        SumPagoNeto += (Convert.ToDecimal(DgvListado.Rows[i].Cells[16].Value));
                       
                    }
                    int a = DgvListado.Rows.Count-1 ;
                    DgvListado.Rows[a].Cells[2].Value = "T O T A L  . .";


                    DgvListado.Rows[a].Cells[6].Value = SumaCom1;
                    DgvListado.Rows[a].Cells[7].Value = SumaCom2;
                    DgvListado.Rows[a].Cells[8].Value = SumaCom3;
                    DgvListado.Rows[a].Cells[9].Value = Sumalqd1;
                    DgvListado.Rows[a].Cells[10].Value = SumaLqd2;
                    DgvListado.Rows[a].Cells[11].Value = Sumlqd3;
                    DgvListado.Rows[a].Cells[12].Value = SumComPagada;
                    DgvListado.Rows[a].Cells[13].Value = SumTotalCom;
                    DgvListado.Rows[a].Cells[14].Value = SumRetencion;
                    DgvListado.Rows[a].Cells[15].Value = SumDctoAnt;
                    DgvListado.Rows[a].Cells[16].Value = SumPagoNeto;
                    DgvListado.Rows[a].DefaultCellStyle.BackColor = Color.SteelBlue;
                    DgvListado.Rows[a].DefaultCellStyle.ForeColor = Color.White;
                    LblTotal.Text = Convert.ToString(SumPagoNeto);
                    this.LblTotal.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblTotal.Text));
        }
//===================================================================================================================================================
// F I N   M E T O D O   T O T A L
//===================================================================================================================================================

 
//===================================================================================================================================================
//I N I C I O   E V E N T O  TxtAdjudicacion_SelectedIndexChanged
//===================================================================================================================================================
        private void TxtAdjudicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblCliente.Text = "";
            LblTotal.Text = "";
            DgvListado.Rows.Clear();

            DtDatosAdj = NuevoClsIdentificacion.MtdBuscarDataset("select Identificacion,Valor,Porcentaje,BaseComision,IdInmueble from 004cnsadjudica where idadjudicacion= " + TxtAdjudicacion.Text );
            LblRecaudo.Text = NuevoClsIdentificacion.MtdBscDatos("select if(sum(capital+InteresCte)is null,0,sum(capital+InteresCte)) from recaudos where idadjudicacion=" + TxtAdjudicacion.Text );
            LblCliente.Text = DtDatosAdj.Rows[0][0].ToString();
            LblVrVenta.Text = DtDatosAdj.Rows[0][1].ToString();
            LblVrPorcentaje.Text = DtDatosAdj.Rows[0][2].ToString();
            LblVrBase.Text = DtDatosAdj.Rows[0][3].ToString();
            LblInmueble.Text = DtDatosAdj.Rows[0][4].ToString();
            this.LblVrVenta.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblVrVenta.Text));
            this.LblVrBase.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblVrBase.Text));
            LblRecaudo.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblRecaudo.Text));
                   
            MtdCnsComision();
            if (Convert.ToDecimal(LblTotal.Text) > 0)
            {
                BtnPagar.Enabled = true;
            }                        

        }
//===================================================================================================================================================
//F I N A L  E V E N T O   TxtAdjudicacion_SelectedIndexChanged
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D  O   A D I C I O N A R  C O M I S I O N
//===================================================================================================================================================
        public void MtdAddComision()
        {
            decimal ValorPago = 0;
            ValorPago = Convert.ToDecimal(LblTotal.Text);
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Comision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                if (ValorPago > 0)
                {

                    VarCentroCostos = NuevoClsIdentificacion.MtdBscDatos("Select CentroCosto  From Parametro Where Estado= 'Vigente'");
                    CuentaDebe = NuevoClsIdentificacion.MtdBscDatos("Select Debe From Contabilidad_alttum.datoscuenta Where Operacion= 'PagoComision'");
                    CuentaHaber = NuevoClsIdentificacion.MtdBscDatos("Select Haber From Contabilidad_alttum.datoscuenta Where Operacion= 'PagoComision'");
                    CuentaAnticipo = NuevoClsIdentificacion.MtdBscDatos("Select Debe From Contabilidad_alttum.datoscuenta Where Operacion= 'Anticipo Comision'");
                    FechaAsiento = NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value);
                    idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
                    VarFuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = 'PagoComision'");
                    IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + VarFuente + "'"));
                    Motivo = "PAGO  COMISION  ADJ" + TxtAdjudicacion.Text + " CLIENTE:" + LblCliente.Text;
                    VarPeriodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM '" + FechaAsiento + "')");

                    string SentenciaAddAnticipo = "Insert into pagocomision(IdFinanciacion,IdAdjudicacion,Fecha,IdTercero,IdCargo,TasaComision,Comision,Retencion," +
                    " DctoAnticipo, PagoNeto,Usuario,FechaOperacion,Transaccion)" +
                    " VALUES(@IdFinanciacion,@IdAdjudicacion,@Fecha,@IdTercero,@IdCargo,@TasaComision,@Comision,@Retencion, @DctoAnticipo, @PagoNeto,@Usuario,@FechaOperacion,@Transaccion)";


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


                       
                     
                        myCommand.Parameters.Add("@IdDocumento", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                        myCommand.Parameters.Add("@Cuenta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Debe", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@Haber", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        myCommand.Parameters.Add("@Consecutivo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@motivo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Detalle", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@Cheque", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@fuente", MySql.Data.MySqlClient.MySqlDbType.VarChar);
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
                        myCommand.Parameters["@Fecha"].Value = DtpFecha.Value;
                        myCommand.Parameters["@motivo"].Value = Motivo;
                        myCommand.Parameters["@Cheque"].Value = IdDocumento;
                        myCommand.Parameters["@Fuente"].Value = VarFuente;
                        
                        myCommand.Parameters["@Periodo"].Value = Convert.ToInt32(VarPeriodo);
                        myCommand.Parameters["@CentroCostos"].Value = VarCentroCostos;
                        myCommand.Parameters["@SubCentro"].Value = 2;
                        myCommand.Parameters["@Estado"].Value = 1;
                        myCommand.Parameters["@Transaccion"].Value = Convert.ToInt32(idtransacciones);
                        myCommand.Parameters["@IdAdjudicacion"].Value = Convert.ToInt32(TxtAdjudicacion.Text);
                        myCommand.Parameters["@Matricula"].Value = LblInmueble.Text;
                        myCommand.Parameters["@Cero"].Value = 0;
                        myCommand.Parameters["@Add"].Value = "ADD";
                        myCommand.Parameters["@Usuario"].Value = FrmLogeo.FrmUsuarioIdUsr;
                        myCommand.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;



                        for (int i = 0; i < DgvListado.Rows.Count - 1; i++)
                        {
                            myCommand.Parameters["@IdFinanciacion"].Value = Convert.ToString(DgvListado.Rows[i].Cells[0].Value);
                            myCommand.Parameters["@IdCargo"].Value = Convert.ToString(DgvListado.Rows[i].Cells[3].Value);                            
                            myCommand.Parameters["@TasaComision"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[6].Value);
                            myCommand.Parameters["@Comision"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[13].Value);
                            myCommand.Parameters["@Retencion"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[14].Value);
                            myCommand.Parameters["@DctoAnticipo"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[15].Value);
                            myCommand.Parameters["@PagoNeto"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[16].Value);                           
                            myCommand.Parameters["@BaseRetencion"].Value = 0;
                            
                            myCommand.Parameters["@Factura"].Value = "CMS-"+ Convert.ToString(DgvListado.Rows[i].Cells[0].Value) + "-" + IdDocumento;
                            myCommand.Parameters["@IdTercero"].Value = Convert.ToString(DgvListado.Rows[i].Cells[1].Value);
                            myCommand.Parameters["@Cuenta"].Value = CuentaDebe;
                            myCommand.Parameters["@Debe"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[13].Value);
                            myCommand.Parameters["@Haber"].Value = 0;
                            myCommand.Parameters["@Beneficiario"].Value = Convert.ToString(DgvListado.Rows[i].Cells[2].Value); ;
                            myCommand.Parameters["@Detalle"].Value = Convert.ToString(DgvListado.Rows[i].Cells[2].Value);
                            cuentareg = cuentareg + 1;
                            myCommand.Parameters["@Consecutivo"].Value = cuentareg;

                            myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                         " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";

                            myCommand.ExecuteNonQuery();


                            if ((Convert.ToDecimal(DgvListado.Rows[i].Cells[14].Value)) > 0)
                            {
                                myCommand.Parameters["@BaseRetencion"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[13].Value);
                                cuentareg = cuentareg + 1;
                                myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                                myCommand.Parameters["@Cuenta"].Value = Convert.ToString(DgvListado.Rows[i].Cells[5].Value); ;
                                myCommand.Parameters["@Debe"].Value = 0;
                                myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[14].Value);
                                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                               " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";
                                myCommand.ExecuteNonQuery();
                            }

                            if ((Convert.ToDecimal(DgvListado.Rows[i].Cells[15].Value)) > 0)
                            {
                                cuentareg = cuentareg + 1;
                                myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                                myCommand.Parameters["@Cuenta"].Value = CuentaAnticipo ;
                                myCommand.Parameters["@Debe"].Value = 0;
                                myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[15].Value);
                                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                               " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";
                                myCommand.ExecuteNonQuery();
                            }


                            myCommand.Parameters["@Cuenta"].Value = CuentaHaber;
                            myCommand.Parameters["@Debe"].Value = 0;
                            myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[16].Value);
                            cuentareg = cuentareg + 1;
                            myCommand.Parameters["@Consecutivo"].Value = cuentareg;

                            myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                            " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";
                            myCommand.ExecuteNonQuery();

                            myCommand.CommandText = SentenciaAddAnticipo;
                            myCommand.ExecuteNonQuery();

                        }

                        myCommand.CommandText = "Update Contabilidad_alttum.documentomanual set Consecutivo=Consecutivo+1 ,ConsecutivoRef=ConsecutivoRef+1 Where idComprobante= @Fuente ";
                        myCommand.ExecuteNonQuery();

                        myCommand.CommandText = "Update Contabilidad_alttum.documento set Consecutivo=Consecutivo+1 Where idComprobante='99'";
                        myCommand.ExecuteNonQuery();

                        myCommand.CommandText = "INSERT INTO Contabilidad_alttum.transacciones (IdTransaccion,Fecha,Transaccion,Fuente,Registro,Usuario) Values (@Transaccion ,Curdate(),'Add',@Fuente ,@IdDocumento,@Usuario)";
                        myCommand.ExecuteNonQuery();

                        myTrans.Commit();
                        MessageBox.Show("Registro Adicionado", "Adicionar Comision", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnPagar.Enabled = false;
                    }

                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el sgte Error " + ex.Message, "Adicionar Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        FrmLogeo.MysqlConexion.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Anticipo Sin Valor ", "Adicionar Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
//===================================================================================================================================================
// F I N A L    M E T O D  O   A D I C I O N A R  C O M I S I O N
//===================================================================================================================================================


     



    }
}
