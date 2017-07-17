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
    public partial class FrmPagodeAnticipos : Form
    {
        public FrmPagodeAnticipos()
        {
            InitializeComponent();
        }
       
       
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        DataTable DtDatos = new DataTable();
        DataTable DtDatosAdj = new DataTable();
        string VarCentroCostos;
        decimal SumTotalCom, SumRetencion, SumDctoAnt, SumPagoNeto,SumComPagada,SumaCom1,SumaCom2,Sumalqd1,SumaLqd2;
        
        string CuentaDebe, CuentaHaber,CuentaRetencion,CuentaAnticipo, Fuente,  FechaAsiento, idtransacciones, IdDocumento, SentenciaCom,  VarFuente,Motivo,Detalle,VarTercero,VarPeriodo;











        #region  Region de Eventos


        private void FrmPagos_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Usuario Conectado " + FrmLogeo.Usuario;
            pictureBox1.Image = FrmMenuGeneral.Logo;
            TxtAdjudicacion.DataSource = NuevoClsIdentificacion.MtdListaCamposSent("SELECT DISTINCTROW IdAdjudicacion from 005saldoanticipoxpagar Where SaldoAnticipo>0", "IdAdjudicacion");
            LblTitulo.Text = "PAGO DE ANTICIPOS";
        }

        private void TxtAdjudicacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LblCliente.Text = "";
            LblTotal.Text = "";
            DgvListado.Rows.Clear();

            DtDatosAdj = NuevoClsIdentificacion.MtdBuscarDataset("select Identificacion,Valor,Porcentaje,BaseComision,IdInmueble from 004cnsadjudica where idadjudicacion=" + TxtAdjudicacion.Text);
            LblRecaudo.Text = NuevoClsIdentificacion.MtdBscDatos("select if(sum(capital+InteresCte)is null,0,sum(capital+InteresCte)) from recaudos where idadjudicacion=" + TxtAdjudicacion.Text );
            LblCliente.Text = DtDatosAdj.Rows[0][0].ToString();
            LblVrVenta.Text = DtDatosAdj.Rows[0][1].ToString();
            LblVrPorcentaje.Text = DtDatosAdj.Rows[0][2].ToString();
            LblVrBase.Text = DtDatosAdj.Rows[0][3].ToString();
            LblInmueble.Text = DtDatosAdj.Rows[0][4].ToString();
            this.LblVrVenta.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblVrVenta.Text));
            this.LblVrBase.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblVrBase.Text));
            LblRecaudo.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblRecaudo.Text));
             MtdConAnticipo();
            if(Convert.ToDecimal( LblTotal.Text)>0)
            {
            BtnPagar.Enabled=true;
            }
        }

        private void DgvListado_CellValidated(object sender, DataGridViewCellEventArgs e)
        {


            if (DgvListado.CurrentCell.ColumnIndex == 9)
            {

                if (Convert.ToString(DgvListado.Rows[e.RowIndex].Cells[1].Value) != "")
                {
                    if (Convert.ToDecimal(DgvListado.Rows[e.RowIndex].Cells[9].Value) > Convert.ToDecimal(DgvListado.Rows[e.RowIndex].Cells[8].Value))
                    {
                        DgvListado.Rows[e.RowIndex].Cells[9].Value = 0;
                        MessageBox.Show("Mayor VAlor a Saldo Pagar", "Pagar Anticipos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MtdTotalAnticipo1();

                    }
                    else
                    {
                        MtdTotalAnticipo1();
                    }
                }
            }
        }

        private void DgvListado_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = e.Control as TextBox;

            if (txt != null)
            {
                txt.KeyPress -= new KeyPressEventHandler(DgvListado_KeyPress);
                txt.KeyPress += new KeyPressEventHandler(DgvListado_KeyPress);
            }
        }

        private void DgvListado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {


            }
            else
            {

                if (DgvListado.CurrentCell.ColumnIndex == 9)
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

            }
        }

        private void BtnPagar_Click(object sender, EventArgs e)
        {
            CuentaDebe = NuevoClsIdentificacion.MtdBscDatos("Select Debe From Contabilidad_alttum.datoscuenta Where Operacion= 'Anticipo Comision'");
            CuentaHaber = NuevoClsIdentificacion.MtdBscDatos("Select Haber From Contabilidad_alttum.datoscuenta Where Operacion= 'Anticipo Comision'");
            FechaAsiento = NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value);
            idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
            VarFuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = 'Anticipo Comision'");
            IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + VarFuente + "'"));
            Motivo = "PAGO ANTICIPO COMISION" + TxtAdjudicacion.Text + " " + LblCliente.Text;
            VarPeriodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM '" + FechaAsiento + "')");
            MtdAddAnticipo();

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        #endregion



#region REGION DE METODOS

 



//===================================================================================================================================================
// I N I C I O  M E T O D  O   A D I C I O N A R   A N T I C I P O
//===================================================================================================================================================
        public void MtdAddAnticipo()
        {
            decimal ValorPago = 0;
            ValorPago = Convert.ToDecimal(LblTotal.Text);
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Anticipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                if (ValorPago > 0)
                {

                    VarCentroCostos = NuevoClsIdentificacion.MtdBscDatos("Select CentroCosto  From Parametro Where Estado= 'Vigente'");
                    CuentaDebe = NuevoClsIdentificacion.MtdBscDatos("Select Debe From Contabilidad_alttum.datoscuenta Where Operacion= 'Anticipo Comision'");
                    CuentaHaber = NuevoClsIdentificacion.MtdBscDatos("Select Haber From Contabilidad_alttum.datoscuenta Where Operacion= 'Anticipo Comision'");
                    FechaAsiento = NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value);
                    idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
                    VarFuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = 'Anticipo Comision'");
                    IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + VarFuente + "'"));
                    Motivo = "PAGO ANTICIPO COMISION  ADJ" + TxtAdjudicacion.Text + " CLIENTE:" + LblCliente.Text;
                    VarPeriodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM '" + FechaAsiento + "')");

                    string SentenciaAddAnticipo = "Insert into pagoanticipo(IdFinanciacion,IdAdjudicacion,Fecha,IdCargo,IdTercero,Valor,Usuario,FechaOperacion,Transaccion)" +
                               " VALUES(@IdFinanciacion,@IdAdjudicacion,@Fecha,@IdCargo,@IdTercero,@Valor,@Usuario,@FechaOperacion,@Transaccion)";


                    int cuentareg = 0;

                    FrmLogeo.MysqlConexion.Open();
                    MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
                    myCommand.Connection = FrmLogeo.MysqlConexion;
                    myCommand.Transaction = myTrans;

                    try
                    {

                        myCommand.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                        myCommand.Parameters.Add("@IdCargo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@IdFinanciacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        myCommand.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        myCommand.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
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


                        myCommand.Parameters["@Usuario"].Value = FrmLogeo.FrmUsuarioIdUsr;
                        myCommand.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                        myCommand.Parameters["@IdDocumento"].Value = IdDocumento;
                        myCommand.Parameters["@Fecha"].Value = DtpFecha.Value;
                        myCommand.Parameters["@motivo"].Value = Motivo;
                        myCommand.Parameters["@Cheque"].Value = IdDocumento;
                        myCommand.Parameters["@Fuente"].Value = VarFuente;
                        myCommand.Parameters["@BaseRetencion"].Value = 0;
                        myCommand.Parameters["@Periodo"].Value = Convert.ToInt32(VarPeriodo);
                        myCommand.Parameters["@CentroCostos"].Value = VarCentroCostos;
                        myCommand.Parameters["@SubCentro"].Value = 2;
                        myCommand.Parameters["@Estado"].Value = 1;
                        myCommand.Parameters["@Transaccion"].Value = Convert.ToInt32(idtransacciones);
                        myCommand.Parameters["@IdAdjudicacion"].Value = Convert.ToInt32(TxtAdjudicacion.Text);
                        myCommand.Parameters["@Matricula"].Value = LblInmueble.Text;
                        myCommand.Parameters["@Cero"].Value = 0;
                        myCommand.Parameters["@Add"].Value = "ADD";




                        for (int i = 0; i < DgvListado.Rows.Count - 1; i++)
                        {
                            myCommand.Parameters["@Factura"].Value =  Convert.ToString(DgvListado.Rows[i].Cells[0].Value) + "-"+IdDocumento;
                            myCommand.Parameters["@IdCargo"].Value = Convert.ToString(DgvListado.Rows[i].Cells[3].Value);
                            myCommand.Parameters["@IdFinanciacion"].Value = Convert.ToString(DgvListado.Rows[i].Cells[0].Value);
                            myCommand.Parameters["@Valor"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[9].Value);
                            myCommand.Parameters["@IdTercero"].Value = Convert.ToString(DgvListado.Rows[i].Cells[1].Value);
                            myCommand.Parameters["@Cuenta"].Value = CuentaDebe;
                            myCommand.Parameters["@Debe"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[9].Value);
                            myCommand.Parameters["@Haber"].Value = 0;
                            myCommand.Parameters["@Beneficiario"].Value = Convert.ToString(DgvListado.Rows[i].Cells[2].Value); ;
                            myCommand.Parameters["@Detalle"].Value = Convert.ToString(DgvListado.Rows[i].Cells[2].Value);
                            cuentareg = cuentareg + 1;
                            myCommand.Parameters["@Consecutivo"].Value = cuentareg;

                            myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                         " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";

                            myCommand.ExecuteNonQuery();

                            myCommand.Parameters["@Cuenta"].Value = CuentaHaber;
                            myCommand.Parameters["@Debe"].Value = 0;
                            myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(DgvListado.Rows[i].Cells[9].Value); ;
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
                        MessageBox.Show("Registro Adicionado", "Adicionar Anticipos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnPagar.Enabled = false;
                    }

                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el sgte Error " + ex.Message, "Adicionar Anticipos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        FrmLogeo.MysqlConexion.Close();
                    }

                }
                else
                {
                    MessageBox.Show("Anticipo Sin Valor "  , "Adicionar Anticipos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
//===================================================================================================================================================
// F I N A L    M E T O D  O   A D I C I O N A R   A N T I C I P O
//===================================================================================================================================================



       

//===================================================================================================================================================
// I N I C I O   M E T O D O   C O N S U L T A R   A N T I C I P O S
//===================================================================================================================================================
        public void MtdConAnticipo()
        {
                 DtDatos.Clear();
                 DgvListado.Rows.Clear();
                 DtDatos = NuevoClsIdentificacion.MtdBuscarDataset("SELECT IdComision,IdGestor,Nombres,IdCargo,NombreCargo,Anticipo1,Anticipo2,"+
                "PagoAnticipo, SaldoAnticipo FROM 005saldoanticipoxpagar WHERE SaldoAnticipo >0 and IdAdjudicacion= " + (TxtAdjudicacion.Text));

                 {
                     for (int i = 0; i < (DtDatos.Rows.Count); i++)
                     {
                         DgvListado.Rows.Add(DtDatos.Rows[i][0], DtDatos.Rows[i][1], DtDatos.Rows[i][2], DtDatos.Rows[i][3], DtDatos.Rows[i][4], DtDatos.Rows[i][5],
                         DtDatos.Rows[i][6], DtDatos.Rows[i][7], DtDatos.Rows[i][8], DtDatos.Rows[i][8]);
                     }
                 }
                MtdTotalAnticipo();

                BtnPagar.Visible = true;
            }        
//===================================================================================================================================================
//F I N A L   M E T O D O   C O N S U L T A R    A N T I C I P O S
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O  T O T A L   A N T I C I P O
//===================================================================================================================================================
        private void MtdTotalAnticipo()
        {
           decimal Anticipo1=0;
           decimal Anticipo2=0;
         
           decimal AntPagado=0;
           decimal SaldoAnt = 0;
           decimal TtAnticipo = 0;

            BtnPagar.Visible = true;

            for (int i = 0; i < (DgvListado.Rows.Count-1); i++)
            {               
                Anticipo1 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[5].Value));
                Anticipo2 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[6].Value));                
                AntPagado += (Convert.ToDecimal(DgvListado.Rows[i].Cells[7].Value));
                SaldoAnt += (Convert.ToDecimal(DgvListado.Rows[i].Cells[8].Value));
                TtAnticipo += (Convert.ToDecimal(DgvListado.Rows[i].Cells[9].Value));
            }
            int a = DgvListado.Rows.Count - 1;
            DgvListado.Rows[a].Cells[2].Value = "T O T A L  . .";


            DgvListado.Rows[a].Cells[5].Value = Anticipo1;
            DgvListado.Rows[a].Cells[6].Value = Anticipo2;
            DgvListado.Rows[a].Cells[7].Value = AntPagado;
            DgvListado.Rows[a].Cells[8].Value = SaldoAnt;
            DgvListado.Rows[a].Cells[9].Value = TtAnticipo;
            DgvListado.Rows[a].DefaultCellStyle.BackColor = Color.Beige;
            LblTotal.Text = Convert.ToString(TtAnticipo);
            this.LblTotal.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblTotal.Text));
        }
//===================================================================================================================================================
// F I N   M E T O D O   T O T A L   A N T I C I P O
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O  T O T A L   A N T I C I P O 1
//===================================================================================================================================================
        private void MtdTotalAnticipo1()
        {
           
            decimal TtAnticipo = 0;

            BtnPagar.Visible = true;

            for (int i = 0; i < (DgvListado.Rows.Count - 1); i++)           
            {
               
                TtAnticipo += (Convert.ToDecimal(DgvListado.Rows[i].Cells[9].Value));
            }
            int a = DgvListado.Rows.Count - 1;                   
            DgvListado.Rows[a].Cells[9].Value = TtAnticipo;
          
            LblTotal.Text = Convert.ToString(TtAnticipo);
            this.LblTotal.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblTotal.Text));
        }
//===================================================================================================================================================
// F I N   M E T O D O  T O T A L   A N T I C I P O 1
//===================================================================================================================================================


        #endregion


  

    }
}
