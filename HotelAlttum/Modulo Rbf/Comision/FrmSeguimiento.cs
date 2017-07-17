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
    public partial class FrmSeguimiento : Form
    {
        public FrmSeguimiento()
        {
            InitializeComponent();
        }

        public string VarIdAdjudicacion, VarIdInmueble, VarNombreCliente;
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        public string VarIdadjudicacion;



//===================================================================================================================================================
// I N I C I O   E V E N T O   L O A D
//===================================================================================================================================================
        private void FrmSeguimiento_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            TxtAdjudicacion.Text = VarIdadjudicacion;
            TxtTitular.Text = NuevoClsIdentificacion.MtdBscDatos("select Identificacion from 004CnsAdjudica where idadjudicacion = '" + TxtAdjudicacion.Text + "'");
            TxtInmueble.Text = NuevoClsIdentificacion.MtdBscDatos("select idinmueble from adjudicacion where idadjudicacion = '" + TxtAdjudicacion.Text + "'");
        }
//===================================================================================================================================================
// F I N A L   E V E N T O   L O A D
//==================================================================================================================================================




//===================================================================================================================================================
// I N I C I O   B O T O N   S A L I R 
//===================================================================================================================================================
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
//===================================================================================================================================================
// F I N A L   B O T O N   S A L I R
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   A D D S E G
//===================================================================================================================================================
        public void MtdAddSeg()
        {
            string Titular;
            string consecutivo = NuevoClsIdentificacion.MtdBscDatos("select consecutivo From consecutivos where prefijo='Seg'");
            Titular = NuevoClsIdentificacion.MtdBscDatos("select idTercero1 from 004cnsadjudica where idAdjudicacion = " + TxtAdjudicacion.Text);
            string Addseguimiento = "insert into seguimiento ( IdSeguimiento,  IdAdjudicacion ,  Fecha ,  Titular ,  Inmueble ,  Accion,  Compromiso ,  FechaCompromiso,  idusuario)" +
        " values( @IdSeguimiento,  @IdAdjudicacion ,  @Fecha ,  @Titular ,  @Inmueble ,  @Accion,  @Compromiso ,  @FechaCompromiso,  @idusuario) ";
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Seguimiento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {
                    CmdAddPrm.Parameters.Add("@IdSeguimiento", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Titular", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Inmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Accion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Compromiso", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@FechaCompromiso", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Idusuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@IdSeguimiento"].Value = consecutivo;
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Titular"].Value = Titular;
                    CmdAddPrm.Parameters["@Inmueble"].Value = TxtInmueble.Text;
                    CmdAddPrm.Parameters["@Accion"].Value = CmbAccion.Text;
                    CmdAddPrm.Parameters["@Compromiso"].Value = RtBCompromiso.Text;
                    CmdAddPrm.Parameters["@FechaCompromiso"].Value = DtpFechaCompro.Value;
                    CmdAddPrm.Parameters["@Idusuario"].Value = FrmLogeo.Usuario;

                    CmdAddPrm.CommandText = Addseguimiento;
                    CmdAddPrm.ExecuteNonQuery();


                    CmdAddPrm.CommandText = "Update Consecutivos set Consecutivo=Consecutivo+1 Where Prefijo='Seg'";
                    CmdAddPrm.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Registro Adicionado", "Adicionar Seguimiento", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();
                }
            }           
        }
//===================================================================================================================================================
// F I N A L   M E T O D O   A D D S E G
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   B O T O N   A C E P T A R
//===================================================================================================================================================
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            MtdAddSeg();
        }
//===================================================================================================================================================
// F I N A L   B O T O N   S A L I R 
//===================================================================================================================================================

    }
}
