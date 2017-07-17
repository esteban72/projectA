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
    public partial class FrmInmuebles : Form
    {
        public FrmInmuebles()
        {
            InitializeComponent();
        }

        #region REGION DE VARIABLES

        decimal CuentaErrores;
        List<string> DatosdeErrores = new List<string>();
        public string EntradaInmuebles,VarIdInmueble;
        ClsIdentificacion conexion = new ClsIdentificacion();
        System.Data.DataTable DtDatosInmuebles = new System.Data.DataTable();

        #endregion


        #region REGION DE METODOS

        //===================================================================================================================================================
// I N I C I O  M E T O D O   FrmInmuebles_Load   
//===================================================================================================================================================
        private void FrmInmuebles_Load(object sender, EventArgs e)
        {
            MtdLimpiar();
            pictureBox1.Image = FrmMenuGeneral.Logo;
            if (EntradaInmuebles == "Modificar")
            {
                LblTitulo.Text = "MODIFICAR INMUEBLES";
                TxtInmueble.Text = VarIdInmueble;
                DatosInmuebles();
                BtnOk.Text = "Modificar";
            }
            if (EntradaInmuebles == "Eliminar")
            {
                LblTitulo.Text = "ELIMINAR INMUEBLES";
                PnlSuperior.Enabled=false;
                TxtInmueble.Text = VarIdInmueble;
                DatosInmuebles();
                BtnOk.Text = "Eliminar";
            }
            if (EntradaInmuebles == "Consultar")
            {
                LblTitulo.Text = "CONSULTAR INMUEBLES";
                PnlSuperior.Enabled=false;
                BtnOk.Visible = false;
                TxtInmueble.Text = VarIdInmueble;
                DatosInmuebles();
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    FrmInmuebles_Load  
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D O   MtdLimpiar   
//===================================================================================================================================================
        public void MtdLimpiar()
        {
            TxtInmueble.Text = "";
            CmbEstado.Text = "";
            CmbSemana.Text = "";
            CmbTemporada.Text = "";
            CmbTipodeSemana.Text = "";
            CmbUnidad.Text = "";
            CmbVilla.Text = "";            
        
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    MtdLimpiar  
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D O   DatosInmuebles   
//===================================================================================================================================================
        private  void DatosInmuebles()
        {
            string Sentencia = "Select TipodeSemana,Villa,Unidad,Semana,Temporada,Estado From Inmuebles Where IdInmueble ='"+TxtInmueble.Text+"'";
            DtDatosInmuebles = conexion.MtdBuscarDataset(Sentencia);
            CmbTipodeSemana.Text = DtDatosInmuebles.Rows[0][0].ToString();
            CmbVilla.Text = DtDatosInmuebles.Rows[0][1].ToString();
            CmbUnidad.Text = DtDatosInmuebles.Rows[0][2].ToString();
            CmbSemana.Text = DtDatosInmuebles.Rows[0][3].ToString();
            CmbTemporada.Text = DtDatosInmuebles.Rows[0][4].ToString();
            CmbEstado.Text = DtDatosInmuebles.Rows[0][5].ToString();        
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   DatosInmuebles
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D O   A D I C I O N A R   
//===================================================================================================================================================
        private void MtdAdicionar()
        {
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
                    rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Inmuebles", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (rest == DialogResult.Yes)
                    {


                        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                        string StrAddInmuebles = "insert into Inmuebles (IdInmueble,IdProyecto,TipodeSemana,Villa,Unidad,Semana,Temporada,Estado,Usuario,FechaOperacion) " +
                        "Values (@IdInmueble,@IdProyecto,@TipodeSemana,@Villa,@Unidad,@Semana,@Temporada,@Estado,@Usuario,@FechaOperacion)";

                     

                        MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                        MysqlConexion.Open();
                        MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                        MySqlTransaction myTrans;
                        myTrans = MysqlConexion.BeginTransaction();
                        CmdAddPrm.Connection = MysqlConexion;
                        CmdAddPrm.Transaction = myTrans;
                        try
                        {
                            CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@IdProyecto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@TipodeSemana", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Villa", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Unidad", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Semana", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Temporada", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);

                            CmdAddPrm.Parameters["@IdInmueble"].Value = TxtInmueble.Text;
                            CmdAddPrm.Parameters["@IdProyecto"].Value = FrmLogeo.Proyecto;
                            CmdAddPrm.Parameters["@TipodeSemana"].Value = CmbTipodeSemana.Text;
                            CmdAddPrm.Parameters["@Villa"].Value =CmbVilla.Text;
                            CmdAddPrm.Parameters["@Unidad"].Value = CmbUnidad.Text;
                            CmdAddPrm.Parameters["@Semana"].Value =CmbSemana.Text;
                            CmdAddPrm.Parameters["@Temporada"].Value =CmbTemporada.Text;
                            CmdAddPrm.Parameters["@Estado"].Value =CmbEstado.Text;
                            CmdAddPrm.Parameters["@Usuario"].Value =FrmLogeo.Usuario;
                            CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;

                            CmdAddPrm.CommandText = StrAddInmuebles;
                            CmdAddPrm.ExecuteNonQuery();                              
                          

                            myTrans.Commit();
                            MessageBox.Show("Registro Adicionado", "Adicionar Inmuebles", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            BtnOk.Enabled = false;
                            PnlSuperior.Enabled = false;
                            BtnNuevo.Visible = true;
                        }
                        catch (MySqlException ex)
                        {
                            myTrans.Rollback();
                            MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Inmuebles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            MysqlConexion.Close();
                        }
                    }
                }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    A D I C I O N A R   
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D O  M O D I F I C A R
//===================================================================================================================================================
        private void MtdModificar()
        {
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
                rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Inmuebles", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {


                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                    string StrAddInmuebles = "Update Inmuebles Set IdProyecto= @IdProyecto,TipodeSemana=@TipodeSemana,Villa=@Villa,Unidad=@Unidad,Semana=@Semana,"+
                    "Temporada=@Temporada,Estado=@Estado,Usuario=@Usuario,FechaOperacion=@FechaOperacion Where IdInmueble=@IdInmueble" ;



                    MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                    MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                        CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@IdProyecto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@TipodeSemana", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Villa", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Unidad", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Semana", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Temporada", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);

                        CmdAddPrm.Parameters["@IdInmueble"].Value = TxtInmueble.Text;
                        CmdAddPrm.Parameters["@IdProyecto"].Value = FrmLogeo.Proyecto;
                        CmdAddPrm.Parameters["@TipodeSemana"].Value = CmbTipodeSemana.Text;
                        CmdAddPrm.Parameters["@Villa"].Value = CmbVilla.Text;
                        CmdAddPrm.Parameters["@Unidad"].Value = CmbUnidad.Text;
                        CmdAddPrm.Parameters["@Semana"].Value = CmbSemana.Text;
                        CmdAddPrm.Parameters["@Temporada"].Value = CmbTemporada.Text;
                        CmdAddPrm.Parameters["@Estado"].Value = CmbEstado.Text;
                        CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;

                        CmdAddPrm.CommandText = StrAddInmuebles;
                        CmdAddPrm.ExecuteNonQuery();


                        myTrans.Commit();
                        MessageBox.Show("Registro Modificado", "Modificar Inmuebles", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                        PnlSuperior.Enabled = false;
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Inmuebles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        MysqlConexion.Close();
                    }
                }
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    M O D I F IC A R
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D O   E L I M I N A R
//===================================================================================================================================================
        private void MtdEliminar()
        {
            

                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Eliminar Este Registro", "Eliminar Inmuebles", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {


                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                    string StrdelInmuebles = "Delete From Inmuebles Where IdInmueble=@IdInmueble" ;



                    MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                    MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                        CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);                      

                        CmdAddPrm.Parameters["@IdInmueble"].Value = TxtInmueble.Text;
                        

                        CmdAddPrm.CommandText = StrdelInmuebles;
                        CmdAddPrm.ExecuteNonQuery();


                        myTrans.Commit();
                        MessageBox.Show("Registro Eliminado", "Eliminar Inmuebles", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Eliminar Inmuebles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        MysqlConexion.Close();
                    }
                
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    E L I M I N A R
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdValidarAdd
//===================================================================================================================================================
        private void MtdValidarAdd()
        {
            DatosdeErrores.Clear();
            CuentaErrores = 0;
            decimal CuentaInmuebles;


            if (CmbTipodeSemana.Text == "SISTEMATICA")
            { 
                TxtInmueble.Text="VS"+CmbVilla.Text+"U"+CmbUnidad.Text+"S"+CmbSemana.Text;
            }
            else

                if (CmbTipodeSemana.Text == "PREFERENTE")
                {
                    TxtInmueble.Text = "VP" + CmbVilla.Text + "U" + CmbUnidad.Text + "S" + CmbSemana.Text;
                }


            if (CmbTipodeSemana.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccionar Tipo de Semana");
                CmbTipodeSemana.BackColor = Color.Blue;
            }


            if (CmbVilla.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccionar Villa");
                CmbVilla.BackColor = Color.Blue;
            }

            if (CmbUnidad.Text=="")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccionar Unidad");
                CmbUnidad.BackColor = Color.Blue;
            }

            if (CmbSemana.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccion Semana");
                CmbSemana.BackColor = Color.Blue;
            }

            if (CmbTemporada.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccion Semana");
                CmbTemporada.BackColor = Color.Blue;
            }

            if (CmbEstado.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccion Semana");
                CmbEstado.BackColor = Color.Blue;
            }

            if (EntradaInmuebles == "Adicionar")
            {
                CuentaInmuebles = Convert.ToDecimal(conexion.MtdBscDatos("select  if(count(idInmueble)is null,0, count(idInmueble))From Inmuebles where idinmueble ='" + TxtInmueble.Text + "'"));

                if (CuentaInmuebles > 0)
                {
                    CuentaErrores = CuentaErrores + 1;
                    DatosdeErrores.Add("Inmueble Ya Existe");
                    TxtInmueble.BackColor = Color.Blue;

                }
            }
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdValidarAdd
//===================================================================================================================================================

        #endregion

        #region REGION DE EVENTOS


        private void TxtInmueble_Enter(object sender, EventArgs e)
        {
            TxtInmueble.BackColor = Color.White;
        }

        private void TxtInmueble_Leave(object sender, EventArgs e)
        {
            TxtInmueble.BackColor = Color.Gainsboro;
        }

        private void CmbRipodeSemana_Enter(object sender, EventArgs e)
        {
            CmbTipodeSemana.BackColor = Color.White;
        }

        private void CmbRipodeSemana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbVilla.Focus();
            }
        }

        private void CmbRipodeSemana_Leave(object sender, EventArgs e)
        {
            CmbTipodeSemana.BackColor = Color.Gainsboro;
        }

        private void CmbVilla_Enter(object sender, EventArgs e)
        {
            CmbVilla.BackColor = Color.White;
        }

        private void CmbVilla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
               CmbUnidad.Focus();
            }
        }

        private void CmbVilla_Leave(object sender, EventArgs e)
        {
            CmbVilla.BackColor = Color.Gainsboro;
        }

        private void CmbUnidad_Enter(object sender, EventArgs e)
        {
            CmbUnidad.BackColor = Color.White;
        }

        private void CmbUnidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbSemana.Focus();
            }
        }

        private void CmbUnidad_Leave(object sender, EventArgs e)
        {
            CmbUnidad.BackColor = Color.Gainsboro;
        }

        private void CmbSemana_Enter(object sender, EventArgs e)
        {
            CmbSemana.BackColor = Color.White;
        }

        private void CmbSemana_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbTemporada.Focus();
            }
        }

        private void CmbSemana_Leave(object sender, EventArgs e)
        {
            CmbSemana.BackColor = Color.Gainsboro;
        }

        private void CmbTemporada_Enter(object sender, EventArgs e)
        {
            CmbTemporada.BackColor = Color.White;
        }

        private void CmbTemporada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbEstado.Focus();
            }
        }

        private void CmbTemporada_Leave(object sender, EventArgs e)
        {
            CmbTemporada.BackColor = Color.Gainsboro;
        }

        private void CmbEstado_Enter(object sender, EventArgs e)
        {
            CmbEstado.BackColor = Color.White;
        }

        private void CmbEstado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                BtnOk.Focus();
            }
        }

        private void CmbEstado_Leave(object sender, EventArgs e)
        {
            CmbEstado.BackColor = Color.Gainsboro;
        }

        private void BtnOk_Enter(object sender, EventArgs e)
        {
            BtnOk.BackColor = Color.White;
        }

        private void BtnOk_Leave(object sender, EventArgs e)
        {
            BtnOk.BackColor = Color.Gainsboro;
        }

        private void BtnEscape_Enter(object sender, EventArgs e)
        {
            BtnEscape.BackColor = Color.White;
        }

        private void BtnEscape_Leave(object sender, EventArgs e)
        {
            BtnEscape.BackColor = Color.Gainsboro;
        }

        private void BtnNuevo_Enter(object sender, EventArgs e)
        {
            BtnNuevo.BackColor = Color.White;
        }

        private void BtnNuevo_Leave(object sender, EventArgs e)
        {
            BtnNuevo.BackColor = Color.Gainsboro;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (EntradaInmuebles == "Adicionar")
            {
                MtdAdicionar();
            }
            else
                if (EntradaInmuebles == "Modificar")
                {
                   MtdModificar();
                }
            else
                if (EntradaInmuebles == "Eliminar")
                {
                MtdEliminar();
                }

        }

        private void BtnEscape_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {          
            BtnOk.Enabled = true;
            PnlSuperior.Enabled = true;
            BtnNuevo.Visible = false;
            MtdLimpiar();
        }

        #endregion




    }
}
