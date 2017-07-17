using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CarteraGeneral.Clases;
using System.Globalization;

namespace CarteraGeneral
{
    public partial class FrmRadicacion : Form
    {
        public FrmRadicacion()
        {
            InitializeComponent();
        }
        public string EntradaRadicacion;
        public string VarIdajudicacion;
        string TipoContrato;
        ClsIdentificacion conexion = new ClsIdentificacion();
        ClsRadicacion radicacion = new ClsRadicacion();
        System.Data.DataTable DatosAdjudicacion = new System.Data.DataTable();

        private string cargoSeleccionado;
        decimal Diferencia;
        int Rg;

        private void FrmRadicacion_Load(object sender, EventArgs e)
        {
            CmbCargos.DataSource = conexion.MtdListaCamposSent("Select NombreCargo From tablacomisiones  Where CodEstado = 1   Order By NombreCargo", "NombreCargo");
            CmbCargos.Text = "";
            txtValorFijo.Enabled = false;
            //DtCargos = conexion.MtdBuscarDataset("select *from  tablacomision");
            TxtAdjudicacion.Text = VarIdajudicacion;
            MtdLimpiar();
            MtdDatosAdjudicacion();
            MtdDiferencia();
            if (EntradaRadicacion == "Consultar")
            {
                PnlDatosAsesor.Enabled = false;

                BtnOk.Visible = false;

            }
        }


        //===================================================================================================================================================
        // I N I C I O   M E T O D O   L I M P I A R
        //===================================================================================================================================================
        private void MtdLimpiar()
        {

            TxtAsesor.Text = "";
            LblNombreAsesor.Text = "";
            TxtComisionAsesor.Text = "0";
            TxtContrato.Text = "";
            TxtTitular1.Text = "";
            LblNombreTitular.Text = "";
            TxtTitular2.Text = "";
            LblNombreTitular2.Text = "";
            TxtTitular3.Text = "";
            LblNombreTitular3.Text = "";
            TxtInmueble.Text = "";
            lblVilla.Text = "";
            lblUnidad.Text = "";
            lblSemana.Text = "";
            lblTemporada.Text = "";
            lblCategoriaReserva.Text = "";
            txtGradoVinculacion.Text = "";
            lblTemporada.Text = "";
            TxtValorContrato.Text = "0";
            TxtGastoLegal.Text = "0";
            TxtObservacion.Text = "";
            TxtValorExtra.Text = "0";
            TxtValorFnc.Text = "0";
            TxtValorContado.Text = "0";
            lblErrorPorcentaje.Text = "";
            txtValorFijo.Text = "0";
        }
        //===================================================================================================================================================
        // F I N A L    M E T O D O   L I M P I A R
        //===================================================================================================================================================


        //===================================================================================================================================================
        // I N I C I O   M E T O D O   MtdDiferencia
        //===================================================================================================================================================
        private void MtdDiferencia()
        {
            Diferencia = Convert.ToDecimal(TxtValorContrato.Text) - Convert.ToDecimal(TxtValorContado.Text) - Convert.ToDecimal(TxtValorFnc.Text) - Convert.ToDecimal(TxtValorExtra.Text) -
            Convert.ToDecimal(TxtValorIni.Text);
            LblDiferencia.Text = Convert.ToString(Diferencia);
            this.LblDiferencia.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblDiferencia.Text));
        }
        //===================================================================================================================================================
        // F I N A L    M E T O D O   MtdDiferencia
        //===================================================================================================================================================


        //==================================================================================================================================================
        // I N I C I O   M E T O D O   D A T O S   A D J U D I C A C I O N
        //===================================================================================================================================================
        private void MtdDatosAdjudicacion()
        {
            //DatosAdjudicacion = conexion.MtdBuscarDataset("Select Fecha,Contrato,IdInmueble,IdTercero1,IdTercero2,IdTercero3,Observacion,Grado,FormaPago,Valor," +
            //"GastosLegales,CuotaInicial,Contado,Financiacion,PlazoFnc,TasaFnc,CuotaFnc,InicioFnc,Extraordinaria,PlazoExtra,TasaExtra,CuotaExtra,InicioExtra," +
            //"Porcentaje,TipodeAdjudicacion   from Adjudicacion where IdAdjudicacion = " + VarIdajudicacion);

            DatosAdjudicacion = conexion.MtdBuscarDataset("Select adj.FechaContrato,adj.Contrato,adj.IdTercero1,adj.IdTercero2,adj.IdTercero3,adj.IdInmueble,inm.Villa, inm.Unidad, inm.Semana, inm.Temporada," +
                 "inm.TipodeSemana,adj.Observacion,adj.Grado,adj.FormaPago,adj.Valor,adj.GastosLegales,adj.CuotaInicial,adj.Financiacion,adj.Contado,adj.Extraordinaria,adj.TipoOperacion "+
                 "FROM Adjudicacion adj "+
                 "INNER JOIN inmuebles inm ON inm.IdInmueble = adj.IdInmueble "+
                 "WHERE adj.IdAdjudicacion = " + VarIdajudicacion);

            DtpFecha.Text = DatosAdjudicacion.Rows[0][0].ToString();
            TxtContrato.Text = DatosAdjudicacion.Rows[0][1].ToString();
            TxtTitular1.Text = DatosAdjudicacion.Rows[0][2].ToString();
            TxtTitular2.Text = DatosAdjudicacion.Rows[0][3].ToString();
            TxtTitular3.Text = DatosAdjudicacion.Rows[0][4].ToString();
            TxtInmueble.Text = DatosAdjudicacion.Rows[0][5].ToString();
            lblVilla.Text = DatosAdjudicacion.Rows[0][6].ToString();
            lblUnidad.Text = DatosAdjudicacion.Rows[0][7].ToString();
            lblSemana.Text = DatosAdjudicacion.Rows[0][8].ToString();
            lblTemporada.Text = DatosAdjudicacion.Rows[0][9].ToString();
            lblCategoriaReserva.Text = DatosAdjudicacion.Rows[0][10].ToString();
            
            LblNombreTitular.Text = conexion.MtdBscNombres(TxtTitular1.Text);

            if (TxtTitular2.Text != "")
            {
                LblNombreTitular2.Text = conexion.MtdBscNombres(TxtTitular2.Text);
            }
            if (TxtTitular3.Text != "")
            {
                LblNombreTitular3.Text = conexion.MtdBscNombres(TxtTitular3.Text);
            }
            TxtObservacion.Text = DatosAdjudicacion.Rows[0][11].ToString();
            txtGradoVinculacion.Text = DatosAdjudicacion.Rows[0][12].ToString();
            txtFormaPago.Text = DatosAdjudicacion.Rows[0][13].ToString();
            TxtValorContrato.Text = DatosAdjudicacion.Rows[0][14].ToString();
            this.TxtValorContrato.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorContrato.Text));
            TxtGastoLegal.Text = DatosAdjudicacion.Rows[0][15].ToString();
            this.TxtGastoLegal.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtGastoLegal.Text));
            TxtValorIni.Text = DatosAdjudicacion.Rows[0][16].ToString();
            this.TxtValorIni.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorIni.Text));
            TxtValorFnc.Text = DatosAdjudicacion.Rows[0][17].ToString();
            this.TxtValorFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorFnc.Text));
            TxtValorContado.Text = DatosAdjudicacion.Rows[0][18].ToString();
            this.TxtValorContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorContado.Text));
            TxtValorExtra.Text = DatosAdjudicacion.Rows[0][19].ToString();
            TipoContrato = DatosAdjudicacion.Rows[0][20].ToString();
            //TxtPlazoFnc.Text = DatosAdjudicacion.Rows[0][14].ToString();
            //TxtTasaFnc.Text = DatosAdjudicacion.Rows[0][15].ToString();
            //TxtCuotaFnc.Text = DatosAdjudicacion.Rows[0][16].ToString();
            //DtpInicioFnc.Text = DatosAdjudicacion.Rows[0][17].ToString();

        }
        //===================================================================================================================================================
        // F I N A L     M E T O D O   D A T O S   A D J U D I C A C I O N
        //===================================================================================================================================================



        //===================================================================================================================================================
        // I N I C I O   M E T O D O   D A T O S   C O M I S I O N
        //===================================================================================================================================================
        private void MtdDatosComision()
        {
            //DtComisionesMod = clsIdentificacion.MtdBuscarDataset("SELECT c.idcargo,t.Nombrecargo,c.IdGestor,t.nombrecompleto asesor,Comision1 " +
            //" FROM comision1  c JOIN Contabilidad_alttum.terceros t on t.idtercero=c.IdGestor join tablacomision t ON t.idcarg=c.idcargo where c.idcargo in " +
            //" (SELECT idcarg FROM tablacomision WHERE normal =0 ) And IdAdjudicacion = '" + TxtIdAdj.Text + "'");

            //for (int i = 0; i < (DtComisionesMod.Rows.Count); i++)
            //{
            //    DgvAsesor.Rows.Add(DtComisionesMod.Rows[i][0], DtComisionesMod.Rows[i][1], DtComisionesMod.Rows[i][2], DtComisionesMod.Rows[i][3], DtComisionesMod.Rows[i][4]);
            //}

        }
        //===================================================================================================================================================
        //  F I N A L   M E T O D O   D A T O S   C U O T A     C O M I S I O N
        //===================================================================================================================================================


        //===================================================================================================================================================
        // I N I C I O  M E T O D O   A D I C I O N A R   
        //===================================================================================================================================================
        private void MtdAdicionar()
        {
            string VarIdComision;

            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Radicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {


                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                //Query para insertar las demás personas que comisionaron en el contrato.
                string StrAddComision = "insert into comisiones (IdComision,IdAdjudicacion,IdTercero,IdCargo,Usuario,FechaOperacion,PorcentajeComision) " +
                "Values (@IdComision,@IdAdjudicacion,@IdTercero,@IdCargo,@Usuario,@FechaOperacion,@Comision)";

                string StrAddComisionValorFijo = "insert into comisiones (IdComision,IdAdjudicacion,IdTercero,IdCargo,PagoNeto,Usuario,FechaOperacion) " +
                "Values (@IdComision,@IdAdjudicacion,@IdTercero,@IdCargo,@PagoNeto,@Usuario,@FechaOperacion)";


                //Query que inserta las personas que comisionan siempre como el presidente, vicepresidente...
                string StrAddComisionGerencia = "insert into comisiones (IdComision,IdAdjudicacion,IdTercero,IdCargo,Usuario,FechaOperacion,PorcentajeComision) " +
                " Select concat(idcargo,'ADJ',@IdAdjudicacion), @IdAdjudicacion,IdTercero, IdCargo,@Usuario,@FechaOperacion, Comision From tablacomisiones where CodEstado = 3";

                string StrModAdjudicacion = "Update Adjudicacion Set Radicacion = 'Radicado', FechaRadicacion = @FechaOperacion, UsuarioRadica=@Usuario Where IdAdjudicacion = @IdAdjudicacion";

                //MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {
                    CmdAddPrm.Parameters.Add("@IdComision", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdCargo", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    //CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);                    
                    CmdAddPrm.Parameters.Add("@Comision", MySql.Data.MySqlClient.MySqlDbType.Double);
                    CmdAddPrm.Parameters.Add("@PagoNeto", MySql.Data.MySqlClient.MySqlDbType.Double);
                    CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);

                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    //CmdAddPrm.Parameters["@Fecha"].Value = DtpFecha.Value;
                    CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;

                    CmdAddPrm.CommandText = StrAddComisionGerencia;
                    CmdAddPrm.ExecuteNonQuery();

                    for (int i = 0; i < DgvAsesor.Rows.Count - 1; i++)
                    {
                        VarIdComision = (DgvAsesor.Rows[i].Cells[0].Value.ToString() + "ADJ" + TxtAdjudicacion.Text);
                        CmdAddPrm.Parameters["@IdComision"].Value = VarIdComision;
                        CmdAddPrm.Parameters["@IdTercero"].Value = DgvAsesor.Rows[i].Cells[2].Value.ToString();
                        CmdAddPrm.Parameters["@IdCargo"].Value = Convert.ToInt16(DgvAsesor.Rows[i].Cells[0].Value);
                        //En la linea de abajo se convierte el valor de la comision que llega en texto a double para poderlo almacenar asi en la BD
                        double doNumber = double.Parse(DgvAsesor.Rows[i].Cells[4].Value.ToString(), CultureInfo.InvariantCulture);
                        if (doNumber >= 10000)
                        {

                            CmdAddPrm.Parameters["@PagoNeto"].Value = doNumber;
                            CmdAddPrm.CommandText = StrAddComisionValorFijo;
                        }
                        else
                        {
                            CmdAddPrm.Parameters["@Comision"].Value = doNumber;
                            CmdAddPrm.CommandText = StrAddComision;
                        }
                        CmdAddPrm.ExecuteNonQuery();
                    }

                    CmdAddPrm.CommandText = StrModAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Registro Adicionado", "Adicionar Radicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    BtnOk.Enabled = false;

                    ClsComision comision = new ClsComision();
                    if (TipoContrato.Equals("Normal"))
                    {
                        comision.ActualizarComisiones(TxtAdjudicacion.Text);
                    }
                    else if(TipoContrato.Equals("PIV")){
                        comision.ActualizarComisiones_PIV(TxtAdjudicacion.Text);
                    }
                    else
                    {
                        comision.ActualizarComisiones_Monterrey(TxtAdjudicacion.Text,DtpFecha.Text);
                    }
                    
                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Por favor verificar que los valores ingresados sean correctos. \n"
                        + "Recuerde que si tiene valores fijos deben ser mayores o iguales a 10.000.", "" + "Adicionar Radicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MysqlConexion.Close();
                }
            }
        }
        //===================================================================================================================================================
        //F I N A L   M E T O D O    A D I C I O N A R   
        //===================================================================================================================================================



        private void DgvAsesor_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            Rg = e.RowIndex;
        }

        private void BtnBscAsesor_Click(object sender, EventArgs e)
        {
            FrmCatalogoTerceros catalogo = new FrmCatalogoTerceros();
            catalogo.VarTipoTercero = "Gestor";
            catalogo.ShowDialog();
            TxtAsesor.Text = FrmCatalogoTerceros.VarIdTercero;
            LblNombreAsesor.Text = FrmCatalogoTerceros.VarNombreTercero;
        }

        private void BtnAddAsesor_Click(object sender, EventArgs e)
        {
            int CuentaCargo = 0;

            for (int i = 0; i < (DgvAsesor.Rows.Count); i++)
            {
                if (Convert.ToString(DgvAsesor.Rows[i].Cells[1].Value) == CmbCargos.Text)
                {
                    CuentaCargo = CuentaCargo + 1;
                }
            }

            if (CuentaCargo > 0)
            {
                MessageBox.Show("El Cargo ya esta en la lista", "Adicionar Asesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
                if (TxtAsesor.Text == "")
                {
                    MessageBox.Show("No se ha agregado Asesor", "Adicionar Asesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else

                    try
                    {
                        if ((Convert.ToDecimal(TxtComisionAsesor.Text) == 0 && TxtComisionAsesor.Enabled == true) || (Convert.ToDecimal(txtValorFijo.Text) == 0 && txtValorFijo.Enabled == true))
                        {
                            MessageBox.Show("La comision debe ser mayor a 0", "Adicionar Asesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            try
                            {
                                if(TxtComisionAsesor.Enabled == true){
                                    
                                    DgvAsesor.Rows.Add((radicacion.ConsultarIdCargo(CmbCargos.Text)), CmbCargos.Text, TxtAsesor.Text, LblNombreAsesor.Text, TxtComisionAsesor.Text);
                                    lblErrorPorcentaje.Text = "";                                    
                                }
                                else
                                {
                                    double valorFijo = Convert.ToDouble(txtValorFijo.Text);
                                    DialogResult respuesta;
                                    respuesta = MessageBox.Show("Esta ingresando una comisión fija de: ** $" + Convert.ToString(valorFijo.ToString("###,###.###")) + " ** \n"
                                    + "Si el valor es correcto, de clic en Aceptar para continuar.", "Confirmación valor fijo.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (respuesta == DialogResult.Yes)
                                    {
                                        DgvAsesor.Rows.Add((radicacion.ConsultarIdCargo(CmbCargos.Text)), CmbCargos.Text, TxtAsesor.Text, LblNombreAsesor.Text, txtValorFijo.Text);
                                        lblErrorPorcentaje.Text = "";
                                    }
                                    
                                }
                                
                            }
                            catch (Exception ex)
                            {
                                lblErrorPorcentaje.Text = "Recuerde ingresar los decimales con . ";
                            }
                            TxtAsesor.Text = "";
                            LblNombreAsesor.Text = "";
                            TxtComisionAsesor.Text = "0";
                            txtValorFijo.Text = "0";
                        }
                    }
                    catch (Exception)
                    {
                        lblErrorPorcentaje.Text = "Verificar que los campos de porcentaje \no valor fijo no esten vacios.";
                    }
        }

        private void TxtAsesor_Enter(object sender, EventArgs e)
        {
            TxtAsesor.BackColor = Color.White;
        }

        private void TxtAsesor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbCargos.Focus();
            }
        }

        private void TxtAsesor_Leave(object sender, EventArgs e)
        {
            TxtAsesor.BackColor = Color.Gainsboro;
        }

        private void CmbCargos_Enter(object sender, EventArgs e)
        {
            CmbCargos.BackColor = Color.White;
        }

        private void CmbCargos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtComisionAsesor.Focus();
            }
        }

        private void CmbCargos_Leave(object sender, EventArgs e)
        {
            CmbCargos.BackColor = Color.Gainsboro;
        }

        private void TxtComisionAsesor_Enter(object sender, EventArgs e)
        {
            TxtComisionAsesor.BackColor = Color.White;
        }

        private void TxtComisionAsesor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                BtnAddAsesor.Focus();
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

        private void TxtComisionAsesor_Leave(object sender, EventArgs e)
        {
            TxtComisionAsesor.BackColor = Color.Gainsboro;
            if (TxtComisionAsesor.Text == "")
            {
                TxtComisionAsesor.Text = "0";
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DgvAsesor.Rows.Count > 1)
            {
                DgvAsesor.Rows.RemoveAt(Rg);
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (DgvAsesor.Rows.Count == 1)
            {
                MessageBox.Show("No Hay Asesores Radicados", "Radicar Negocios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MtdAdicionar();
            }
        }

        private void BtnEscape_Click(object sender, EventArgs e)
        {
            Close();
        }

        
        //private void validarIngresoNumeros(object sender, System.Windows.Forms.KeyPressEventArgs e)
        //{
        //    lblErrorPorcentaje.Text = "";

        //    bool IsDec = false;
        //    int nroDec = 0;

        //    for (int i = 0; i < TxtComisionAsesor.Text.Length; i++)
        //    {

        //        if (TxtComisionAsesor.Text[i] == '.')
        //            IsDec = true;

        //        if (IsDec && nroDec++ >= 2)
        //        {
        //            e.Handled = true;
        //            return;
        //        }
        //    }
        //}

        private void validarIngresoNumeros(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtComisionAsesor.Text.Length; i++)
            {
                if (TxtComisionAsesor.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 2)
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

        private void CmbCargos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargoSeleccionado = CmbCargos.SelectedValue.ToString();
            if(cargoSeleccionado == "Jefe Tlmk" || cargoSeleccionado == "Supervisor Tlmk"
                || cargoSeleccionado == "Telemarquista" || cargoSeleccionado == "Jefe Promocion"
                || cargoSeleccionado == "Promotor")
            {
                TxtComisionAsesor.Text = "0";
                txtValorFijo.Enabled = true;
                TxtComisionAsesor.Enabled = false;
            }
            else
            {
                txtValorFijo.Text = "0";
                txtValorFijo.Enabled = false;
                TxtComisionAsesor.Enabled = true;
            }
        }

    }
}
