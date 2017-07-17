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
    public partial class FrmParametros : Form
    {
        public FrmParametros()
        {
            InitializeComponent();
        }
        DataTable DtParametros = new DataTable();
        ClsIdentificacion conexion = new ClsIdentificacion();

        #region REGION DE EVENTOS

        private void FrmParametros_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmLogeo.LogoFondo;
            toolStripStatusLabel1.Text = "Usuario Conectado " + FrmLogeo.Usuario;
            MtdLLenarDatosParametros();
        }

        private void TxtInteresCte_Enter(object sender, EventArgs e)
        {
            TxtInteresCte.BackColor = Color.White;
        }

        private void TxtInteresCte_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {

                TxtInteresMora.Focus();

            }
            else
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }


                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < TxtInteresCte.Text.Length; i++)
                {
                    if (TxtInteresCte.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
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
        }

        private void TxtInteresCte_Leave(object sender, EventArgs e)
        {
            TxtInteresCte.BackColor = Color.Gainsboro;
            if (TxtInteresCte.Text == "")
            {
                TxtInteresCte.Text = "0";
            }
        }

        private void TxtInteresMora_Enter(object sender, EventArgs e)
        {
            TxtInteresMora.BackColor = Color.White;
        }

        private void TxtInteresMora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

                TxtPorcetanje.Focus();

            }
            else
            {

                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }


                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < TxtInteresMora.Text.Length; i++)
                {
                    if (TxtInteresMora.Text[i] == '.')
                        IsDec = true;

                    if (IsDec && nroDec++ >= 3)
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
        }

        private void TxtInteresMora_Leave(object sender, EventArgs e)
        {
            TxtInteresMora.BackColor = Color.Gainsboro;
            if (TxtInteresMora.Text == "")
            {
                TxtInteresMora.Text = "0";
            }
        }       

        private void TxtPorcetanje_Enter(object sender, EventArgs e)
        {
            TxtPorcetanje.BackColor = Color.White;            
        }

        private void TxtPorcetanje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtPeriodo.Focus();
            }
            else
            {

                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }


                bool IsDec = false;
                int nroDec = 0;

                for (int i = 0; i < TxtPorcetanje.Text.Length; i++)
                {
                    if (TxtPorcetanje.Text[i] == '.')
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
        }

        private void TxtPorcetanje_Leave(object sender, EventArgs e)
        {
            TxtPorcetanje.BackColor = Color.Gainsboro;
            if (TxtPorcetanje.Text == "")
            {
                TxtPorcetanje.Text = "0";
            }
        }

        private void TxtPeriodo_Enter(object sender, EventArgs e)
        {
            TxtPeriodo.BackColor = Color.White;
        }

        private void TxtPeriodo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

                TxtDiasMora.Focus();

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

        private void TxtPeriodo_Leave(object sender, EventArgs e)
        {
            TxtPeriodo.BackColor = Color.Gainsboro;
            if (TxtPeriodo.Text == "")
            {
                TxtPeriodo.Text = conexion.MtdBscDatos("select EXTRACT(YEAR_MONTH from curdate())"); 
            }
        }

        private void TxtDiasMora_Enter(object sender, EventArgs e)
        {
            TxtDiasMora.BackColor = Color.White;
        }

        private void TxtDiasMora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtDecimales.Focus(); 
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

        private void TxtDiasMora_Leave(object sender, EventArgs e)
        {
            TxtDiasMora.BackColor = Color.Gainsboro;
            if (TxtDiasMora.Text == "")
            {
                TxtDiasMora.Text = "10";
            }
        }

        private void TxtDecimales_Enter(object sender, EventArgs e)
        {
            TxtDecimales.BackColor = Color.White;
        }

        private void TxtDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
            TxtFuente.Focus();
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

        private void TxtDecimales_Leave(object sender, EventArgs e)
        {
            TxtDecimales.BackColor = Color.Gainsboro;
        }  


        private void BtnAceptar_Enter(object sender, EventArgs e)
        {
            BtnAceptar.BackColor = Color.White;
        }

        private void BtnAceptar_Leave(object sender, EventArgs e)
        {
            BtnAceptar.BackColor = Color.Gainsboro;
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                MtdActualizar();
            }
        }

        private void BtnSalir_Enter(object sender, EventArgs e)
        {
            BtnSalir.BackColor = Color.White;
        }

        private void BtnSalir_DragLeave(object sender, EventArgs e)
        {
            BtnSalir.BackColor = Color.Gainsboro;
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


        private void TxtFuente_Enter(object sender, EventArgs e)
        {
            TxtFuente.BackColor = Color.White;
        }

        private void TxtFuente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtCentroCosto.Focus();
            }
        }

        private void TxtFuente_Leave(object sender, EventArgs e)
        {
            TxtFuente.BackColor = Color.Gainsboro;
        }

        private void TxtCentroCosto_Enter(object sender, EventArgs e)
        {
            TxtCentroCosto.BackColor = Color.White;
        }

        private void TxtCentroCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtSubCentro.Focus();
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

        private void TxtCentroCosto_Leave(object sender, EventArgs e)
        {
            TxtCentroCosto.BackColor = Color.Gainsboro;
        }

        private void TxtSubCentro_Enter(object sender, EventArgs e)
        {
            TxtSubCentro.BackColor = Color.White;
        }

        private void TxtSubCentro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                BtnAceptar.Focus();
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

        private void TxtSubCentro_Leave(object sender, EventArgs e)
        {
            TxtSubCentro.BackColor = Color.Gainsboro;
        }

        #endregion

      

        private void MtdLLenarDatosParametros()
        {
            DtParametros = conexion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
            TxtInteresCte.Text = DtParametros.Rows[0][0].ToString();
            TxtInteresMora.Text = DtParametros.Rows[0][1].ToString();
            TxtPeriodo.Text = DtParametros.Rows[0][2].ToString();
            TxtDiasMora.Text = DtParametros.Rows[0][3].ToString();
            TxtPorcetanje.Text = DtParametros.Rows[0][4].ToString();
            TxtDecimales.Text = DtParametros.Rows[0][5].ToString();
            TxtFuente.Text = DtParametros.Rows[0][6].ToString();
            TxtCentroCosto.Text = DtParametros.Rows[0][7].ToString();
            TxtSubCentro.Text = DtParametros.Rows[0][8].ToString();
        }

//===================================================================================================================================================
// I N I C I O  M E T O D O   A C T U A L I Z A R
//===================================================================================================================================================
      private void MtdActualizar()
        {

            MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

            string StrAddParametro = "INSERT INTO Parametro (InteresCte,Mora, Periodo, DiasMoras, Porcentaje,Decimales,Fuente,Centrocosto,Subcentro ,Usuario, Fecha, Estado) VALUES " +
                            "(@InteresCte,@Mora, @Periodo, @DiasMoras, @Porcentaje,@Decimales,@Fuente,@CentroCosto,@Subcentro, @Usuario, @Fecha, @Estado)";

            string StrCambiodeestado = "Update Parametro Set Estado = 'Modificado' Where Estado = 'Vigente'";

            

            MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            CmdAddPrm.Connection = MysqlConexion;
            CmdAddPrm.Transaction = myTrans;
            try
            {
                
                CmdAddPrm.Parameters.Add("@InteresCte", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                CmdAddPrm.Parameters.Add("@Mora", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                CmdAddPrm.Parameters.Add("@Periodo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                CmdAddPrm.Parameters.Add("@DiasMoras", MySql.Data.MySqlClient.MySqlDbType.Int32);
                CmdAddPrm.Parameters.Add("@Porcentaje", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);               
                CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Decimales", MySql.Data.MySqlClient.MySqlDbType.Int16);
                CmdAddPrm.Parameters.Add("@Fuente", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@CentroCosto", MySql.Data.MySqlClient.MySqlDbType.Int16);
                CmdAddPrm.Parameters.Add("@SubCentro", MySql.Data.MySqlClient.MySqlDbType.Int16);


                CmdAddPrm.Parameters["@InteresCte"].Value = Convert.ToDecimal(TxtInteresCte.Text);
                CmdAddPrm.Parameters["@Mora"].Value = Convert.ToDecimal(TxtInteresMora.Text);
                CmdAddPrm.Parameters["@Periodo"].Value = Convert.ToInt32(TxtPeriodo.Text);
                CmdAddPrm.Parameters["@DiasMoras"].Value = Convert.ToInt32(TxtDiasMora.Text);
                CmdAddPrm.Parameters["@Porcentaje"].Value = Convert.ToDecimal(TxtPorcetanje.Text);
                CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now;
                CmdAddPrm.Parameters["@Estado"].Value = "Vigente";
                CmdAddPrm.Parameters["@Decimales"].Value = Convert.ToInt16(TxtDecimales.Text);
                CmdAddPrm.Parameters["@Fuente"].Value = TxtFuente.Text;
                CmdAddPrm.Parameters["@CentroCosto"].Value = Convert.ToInt16(TxtCentroCosto.Text);
                CmdAddPrm.Parameters["@SubCentro"].Value = Convert.ToInt16(TxtSubCentro.Text);

                CmdAddPrm.CommandText = StrCambiodeestado;
                CmdAddPrm.ExecuteNonQuery();

                CmdAddPrm.CommandText = StrAddParametro;
                CmdAddPrm.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Registro Adicionado", "Modificar Parametros", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                BtnAceptar.Enabled = false;
            }
            catch (MySqlException ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Parametros", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
            finally
            {
                MysqlConexion.Close();

            }
            

        }         
//===================================================================================================================================================
//F I N A L   M E T O D O   A C T U A L I Z A R
//===================================================================================================================================================
   
        
 



    }
}
