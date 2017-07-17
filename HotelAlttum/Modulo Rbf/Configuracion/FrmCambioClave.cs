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
    public partial class FrmCambioClave : Form
    {
        public FrmCambioClave()
        {
            InitializeComponent();
        }

        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        List<string> BuscarUsr = new List<string>();

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            if ((TxtClave.Text == "") || (TxtConfClave.Text == ""))
            {
                MessageBox.Show("Faltan Campos por Ingresar");
            }
            else
            if (TxtClave.Text != TxtConfClave.Text)
            {
                MessageBox.Show("Claves No Coinciden");
            }
            else
                
            if ((MtdModUsr(TxtUsuario.Text, TxtNombreUsuario.Text, TxtClave.Text, NuevoClsIdentificacion.MtdVldFch()) == "Ok"))
            {
                MessageBox.Show("Clave Actualizada", "Cambio de  Clave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                BtnActualizar.Enabled = false;
                TxtClave.ReadOnly = true;
                TxtConfClave.ReadOnly = true;
            }
        }

        private void FrmCambioClave_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            toolStripStatusLabel1.Text = "Usuario Conectado ";   
            TxtClave.Focus();
            BuscarUsr = NuevoClsIdentificacion.MtdListaBscUsr(FrmLogeo.Usuario);
            TxtUsuario.Text = FrmLogeo.Usuario;
            TxtNombreUsuario.Text = BuscarUsr[0];
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtConfClave.Focus();
            }
        }

        private void TxtConfClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                BtnActualizar.Focus();
            }
        }



//===================================================================================================================================================
//  I N I C I O  M E T O D O  M O D I F I C A R    U S U A R I O
//===================================================================================================================================================
      public string MtdModUsr(string IdUsuario, string NombreUsuario, string Clave, string fecha)
        {

            MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

            string StrTexto = "Update Usuario set NombreUsuario = '" + NombreUsuario + "' ," + "Clave = (SELECT PASSWORD('" + Clave + "'))" + "," + "fecha =  '" + fecha + "'" +
            "Where IdUsuario = '" + IdUsuario + "' ";

            MySqlCommand CmdModUsr = new MySqlCommand(StrTexto, FrmLogeo.MysqlConexion);

            try
            {
                FrmLogeo.MysqlConexion.Open();

                CmdModUsr.ExecuteNonQuery();
                return "Ok";
            }

            catch (Exception)
            {
                return "Error";
            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }
        }
//===================================================================================================================================================
//F I N A L M E T O D O   M O D I F I C A R    U S U A R I O
//===================================================================================================================================================


    }
}
