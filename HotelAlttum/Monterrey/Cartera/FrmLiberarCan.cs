using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;
namespace CarteraGeneral
{
    public partial class FrmLiberarCan : Form
    {
        public FrmLiberarCan()
        {
            InitializeComponent();
        }

        #region REGION DE VARIABLES
        string Fuente;
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        System.Data.DataTable NuevoDataTable = new System.Data.DataTable();
        System.Data.DataTable DtDatosReg = new System.Data.DataTable();
        System.Data.DataTable NuevoDataTable1 = new System.Data.DataTable();
        string SdoCapital = "";
        string Mensaje = "";
        string scrip = "select d.IdRecaudo ,c.Identificacion AS clientes,d.IdAdjudicacion ,d.NumRecibo ,d.Fecha ,d.Valor ,d.CodBanco ,d.Operacion,d.Transaccion " +
        " from datosrecaudos d join recaudos r on d.IdRecaudo = r.IdRecaudo join 004cnsadjudica c on c.IdAdjudicacion = d.IdAdjudicacion where r.Estado = 'pendiente' " +
        " group by d.IdRecaudo";
        #endregion

        #region REGION DE EVENTOS     
        private void FrmLiberarCan_Load(object sender, EventArgs e)
        {
          BtnDevuleto.Enabled = NuevoClsIdentificacion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "406");
          BtnLiberar.Enabled = NuevoClsIdentificacion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "406");         

            pictureBox1.Image = FrmMenuGeneral.Logo;
            MtdInicio();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnLiberar_Click(object sender, EventArgs e)
        {
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro Aprobar Venta", "Aprobar Canje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {                
                Mensaje = NuevoClsIdentificacion.MtdAddSentencia("UPDATE recaudos set Estado = 'Aprobado' where IdRecaudo = " + TxtidRecaudo.Text );
               
                if (Mensaje == "OK")
                {
                    MessageBox.Show("Canje Liberado","Aprobar Canje",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    SdoCapital = NuevoClsIdentificacion.MtdBscDatos("select sum(saldocapital) from 004saldocuotas where idadjudicacion=" + TxtAdjudicacion.Text);
                    MtdCambioEstado(SdoCapital);
                    MtdInicio();
                }
                else
                {
                    MessageBox.Show(Mensaje);
                }
            }
        }

        private void BtnDevuleto_Click(object sender, EventArgs e)
        {
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro es Cheque Devuelto", "Cheque Devuelto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rest == DialogResult.Yes)
            {
                MtdDevCheque();
            }
        }

        private void DgvDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            TxtAdjudicacion.Text = DgvDatos.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtidRecaudo.Text = DgvDatos.Rows[e.RowIndex].Cells[0].Value.ToString();
            MtdDatosGrl();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            exporta_a_excel();
        }

#endregion 

        #region REGION DE METODOS
        public void MtdDatosGrl()
        {
            if (DgvDatos.Rows.Count > 0)
            {
                NuevoDataTable = NuevoClsIdentificacion.MtdBuscarDataset("Select IdTercero1,IdTercero2,IdProyecto,IdInmueble FROM 004CnsAdjudica WHERE IdAdjudicacion = " + TxtAdjudicacion.Text );
                TxtNombre1.Text = NuevoClsIdentificacion.MtdBscNombres(NuevoDataTable.Rows[0][0].ToString());

                LblIdtercero.Text = NuevoDataTable.Rows[0][0].ToString();
                TxtProyecto.Text = NuevoDataTable.Rows[0][2].ToString();
                TxtInmueble.Text = NuevoDataTable.Rows[0][3].ToString();

                NuevoDataTable1 = NuevoClsIdentificacion.MtdBuscarDataset("Select IdRecaudo,Fecha,NumRecibo,Valor,CodBanco FROM datosrecaudos WHERE IdRecaudo = " + TxtidRecaudo.Text);
                TxtFecha.Text = NuevoDataTable1.Rows[0][1].ToString();
                TxtFecha.Text = String.Format("{0:d/M/yyyy}", Convert.ToDateTime(TxtFecha.Text));
                TxtValor.Text = NuevoDataTable1.Rows[0][3].ToString();
                LblCodBanco.Text = NuevoDataTable1.Rows[0][4].ToString();
                this.TxtValor.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtValor.Text));
                TxtRecibo.Text = NuevoDataTable1.Rows[0][2].ToString();
            }
        }

        public void MtdInicio()
        {
            DtDatosReg = NuevoClsIdentificacion.MtdBuscarDataset(scrip);

            DgvDatos.Rows.Clear();

            for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
            {
                DgvDatos.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3], DtDatosReg.Rows[i][4],
                DtDatosReg.Rows[i][5], DtDatosReg.Rows[i][6], DtDatosReg.Rows[i][7], DtDatosReg.Rows[i][8]);
            }
            MtdTotal();        
            MtdDatosGrl();
        }

        private void MtdTotal()
    {       
            double TtDebe;
            TtDebe = 0;          

            for (int i = 0; i < (DgvDatos.Rows.Count); i++)
            {
                TtDebe = TtDebe + Convert.ToDouble(DgvDatos.Rows[i].Cells[5].Value);              
            }
            TxtTotal.Text = TtDebe.ToString();
            this.TxtTotal.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtTotal.Text));
    }

        public void MtdCambioEstado(string SaldoCapital)
        {
            string ModEstado = "Update Adjudicacion set Estado ='Pagado' , FechaOperacion= curdate() where  idadjudicacion= '" + TxtAdjudicacion.Text + "'";

            string MensajeSalida = "";
            if ((Convert.ToDecimal(SaldoCapital)) == 0)
            {
                 FrmLogeo.MysqlConexion.Open();
                MySqlCommand myCommand =  FrmLogeo.MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans =  FrmLogeo.MysqlConexion.BeginTransaction();
                myCommand.Connection =  FrmLogeo.MysqlConexion;
                myCommand.Transaction = myTrans;

                try
                {
                    myCommand.CommandText = ModEstado;
                    myCommand.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Credito cancelado en su totalidad, su nuevo estado es pagado");
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
        }

        public void exporta_a_excel()
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            foreach (DataGridViewColumn col in DgvDatos.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }

            int rowIndex = 0;

            foreach (DataGridViewRow row in DgvDatos.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvDatos.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }

            }

            excel.Visible = true;

            Worksheet Libro = (Worksheet)excel.ActiveSheet;

            //Libro.Activate();

        }

        public void MtdDevCheque()
        {
            Fuente = NuevoClsIdentificacion.MtdBscDatos("Select Documento From Contabilidad_alttum.datoscuenta Where Operacion = 'Cheque Devuelto'");
            string CuentaDebe = NuevoClsIdentificacion.MtdBscDatos("Select Debe   From Contabilidad_alttum.datoscuenta Where Operacion= 'Cheque Devuelto' and Documento = '" + Fuente + "'");
            string CuentaHaber = NuevoClsIdentificacion.MtdBscDatos("Select Haber  From Contabilidad_alttum.datoscuenta Where Operacion= 'Cheque Devuelto' and Documento = '" + Fuente + "'");


            string idtransacciones = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99"));
            string IdDocumento = (NuevoClsIdentificacion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.DocumentoManual where idComprobante = '" + Fuente + "'"));

          string periodo = NuevoClsIdentificacion.MtdBscDatos("SELECT EXTRACT(YEAR_MONTH FROM CURDATE())"); 
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
                myCommand.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@Transaccion", MySql.Data.MySqlClient.MySqlDbType.Int32);              
                myCommand.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                myCommand.Parameters.Add("@EstadoRec", MySql.Data.MySqlClient.MySqlDbType.String);
                myCommand.Parameters.Add("@Periodo", MySql.Data.MySqlClient.MySqlDbType.Int32);               
                myCommand.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.String);


                myCommand.Parameters["@IdRecaudo"].Value = TxtidRecaudo.Text;
                myCommand.Parameters["@IdAdjudicacion"].Value = Convert.ToInt32(TxtAdjudicacion.Text);
                myCommand.Parameters["@Fecha"].Value = DateTime.Now.Date;
                myCommand.Parameters["@NumRecibo"].Value = TxtRecibo.Text;
                myCommand.Parameters["@IdTercero"].Value = LblIdtercero.Text;
                myCommand.Parameters["@Operacion"].Value = "CHEQUE DEVUELTO";
                myCommand.Parameters["@Valor"].Value = Convert.ToDecimal(TxtValor.Text);
                myCommand.Parameters["@CodBanco"].Value = LblCodBanco.Text;
               
             
                myCommand.Parameters["@Usuario"].Value = FrmLogeo.FrmUsuarioIdUsr;
                myCommand.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                myCommand.Parameters["@Transaccion"].Value = idtransacciones;
                myCommand.Parameters["@EstadoRec"].Value = "Devuelto";
                myCommand.Parameters["@Periodo"].Value = Convert.ToInt32(periodo);



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
                myCommand.Parameters["@motivo"].Value = "Devolucion Cheque Cliente:  " + TxtNombre1.Text + " Adjudicacion: " + TxtAdjudicacion.Text; ;
                myCommand.Parameters["@fuente"].Value = Fuente;

                myCommand.Parameters["@Estado"].Value = 1;
                myCommand.Parameters["@Beneficiario"].Value = TxtNombre1.Text;
                myCommand.Parameters["@Cero"].Value = 0;
                myCommand.Parameters["@Add"].Value = "ADD";
                myCommand.Parameters["@Matricula"].Value = TxtInmueble.Text;
                myCommand.Parameters["@CentroCostos"].Value = FrmLogeo.CentroCosto;
                myCommand.Parameters["@SubCentro"].Value = 1;
                myCommand.Parameters["@Detalle"].Value = "Devolucion Cheque Cliente:  " + TxtNombre1.Text + " Adjudicacion: " + TxtAdjudicacion.Text;
                myCommand.Parameters["@Cheque"].Value = TxtRecibo.Text;
                myCommand.Parameters["@BaseRetencion"].Value = 0;
                myCommand.Parameters["@Factura"].Value = "ADJ" + TxtAdjudicacion.Text;

                cuentareg = cuentareg + 1;
                myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                myCommand.Parameters["@Debe"].Value = Convert.ToDecimal(TxtValor.Text);
                myCommand.Parameters["@Haber"].Value = 0;
                myCommand.Parameters["@Cuenta"].Value = CuentaHaber;

                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";

                myCommand.ExecuteNonQuery();

                cuentareg = cuentareg + 1;
                myCommand.Parameters["@Consecutivo"].Value = cuentareg;
                myCommand.Parameters["@Debe"].Value = 0;
                myCommand.Parameters["@Haber"].Value = Convert.ToDecimal(TxtValor.Text);
                myCommand.Parameters["@Cuenta"].Value = CuentaDebe;


                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.Diario (IdDocumento,fecha,Cuenta,Debe,Haber,Consecutivo,motivo,Detalle,Cheque,fuente,IdTercero,BaseRetencion,Periodo,CentroCostos,SubCentro,Estado,Transaccion,Beneficiario, Matricula,Factura)  " +
                " VALUES(@IdDocumento,@fecha,@Cuenta,@Debe,@Haber,@Consecutivo,@motivo,@Detalle,@Cheque,@fuente,@IdTercero,@BaseRetencion,@Periodo,@CentroCostos,@SubCentro,@Estado,@Transaccion,@Beneficiario, @Matricula, @Factura)";
                myCommand.ExecuteNonQuery();

                

                #endregion

                myCommand.CommandText = "Update Contabilidad_alttum.documentomanual set Consecutivo=Consecutivo+1 ,ConsecutivoRef=ConsecutivoRef+1 Where idComprobante= @Fuente ";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Update Contabilidad_alttum.documento set Consecutivo=Consecutivo+1 Where idComprobante='99'";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "INSERT INTO Contabilidad_alttum.transacciones (IdTransaccion,Fecha,Transaccion,Fuente,Registro,Usuario) Values (@Transaccion ,Curdate(),'Add',@Fuente ,@IdDocumento,@Usuario)";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Update Recaudos Set estado='Devuelto' Where IdRecaudo=@IdRecaudo";
                myCommand.ExecuteNonQuery();

                myTrans.Commit();
                MessageBox.Show("Cheque Devuelto", "Cheque Devuelto", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MtdInicio();
            }

            catch (MySqlException ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el sgte Error " + ex.Message, "Cheque Devuelto", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }


        }

        #endregion


    }
}
