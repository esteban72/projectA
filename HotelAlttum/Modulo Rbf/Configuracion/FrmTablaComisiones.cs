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
    public partial class FrmTablaComisiones : Form
    {
        double CuentaErrores;
        public string VarId, VarIdTercero, VarNombreCargo, VarComision, VarRecaudo1, VarAnticipo1, VarRecaudo2, VarAnticipo2, VarNombreAsesor,Entrada,VarComision2;
        int Consecutivo;
        ClsIdentificacion conexion = new ClsIdentificacion();
        List<string> DatosdeErrores = new List<string>();
        public FrmTablaComisiones()
        {
            InitializeComponent();
        }

        private void FrmTabalaComisiones_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo; ;
           
            if (Entrada == "Adicionar")
            {
                LblTitulo.Text = "ADICIONAR DATOS TABLA DE COMSIONES";
                BtnOk.Text = "Adicionar";
                LblNombreTitular.Text = "";
            }
            else

                if (Entrada == "Modificar")
                {
                    MtdLimpiar();
                    mtddatos();                  
                    LblTitulo.Text = "MODIFICAR DATOS TABLA DE COMSIONES";
                    BtnOk.Text = "Modificar";
                }
                else
                    if (Entrada == "Eliminar")
                    {                        
                        MtdLimpiar();
                        mtddatos();
                        LblTitulo.Text = "ELIMINAR DATOS TABLA DE COMSIONES";
                        BtnOk.Text = "Eliminar";
                    }
                    else

                        if (Entrada == "Consultar")
                        {
                            MtdLimpiar();
                            mtddatos();
                            LblTitulo.Text="CONSULTA TABLA DE COMSIONES";
                            PnlSuperior.Enabled = false;
                            BtnOk.Visible = false;
                        }
            TxtNombreCargo.Focus();
        }

        private void MtdValidarAdd()
        {
            DatosdeErrores.Clear();
            CuentaErrores = 0;

            
            if (TxtNombreCargo.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Nombre del Cargo");
                TxtNombreCargo.BackColor = Color.Blue;
            }


        }

        private void MtdDatosComision()
        {
            TxtIdCargo.Text = VarId;
            TxtNombreCargo.Text = VarNombreCargo;
            TxtIdTercero.Text = VarIdTercero;
            LblNombreTitular.Text = VarNombreAsesor;
            TxtComision.Text = VarComision;
            TxtRecaudo1.Text = VarRecaudo1;
            TxtRecaudo2.Text = VarRecaudo2;
            TxtAnticipo1.Text = VarAnticipo1;
            TxtAnticipo2.Text = VarAnticipo2;
        }

        private void MtdLimpiar()
        {
            TxtIdCargo.Text ="";
            TxtNombreCargo.Text = "";
            TxtIdTercero.Text = "";
            LblNombreTitular.Text = "";
            TxtComision.Text = "";
            TxtRecaudo1.Text = "";
            TxtRecaudo2.Text = "";
            TxtAnticipo1.Text = "";
            TxtAnticipo2.Text = "";
        }

        private void mtddatos()
        {
            TxtIdCargo.Text = VarId;
            TxtNombreCargo.Text = VarNombreCargo;
            TxtIdTercero.Text = VarIdTercero;
            LblNombreTitular.Text = VarNombreAsesor;
            TxtComision.Text = VarComision;
            TxtComision2.Text = VarComision2;
            TxtRecaudo1.Text = VarRecaudo1;
            TxtRecaudo2.Text = VarRecaudo2;
            TxtAnticipo1.Text = VarAnticipo1;
            TxtAnticipo2.Text = VarAnticipo2;
            this.TxtComision.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtComision.Text));
            this.TxtRecaudo1.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtRecaudo1.Text));
            this.TxtRecaudo2.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtRecaudo2.Text));
            this.TxtAnticipo1.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtAnticipo1.Text));
            this.TxtAnticipo2.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtAnticipo2.Text));
        
        }




//===================================================================================================================================================
// I N I C I O  M E T O D O   M O D I F I C A R
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
                  rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Tabla Comision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                  if (rest == DialogResult.Yes)
                  {
                      Consecutivo = Convert.ToInt16(conexion.MtdBscDatos("select if(max(idcargo)is null,1,max(idcargo+1))from tablacomision"));
                      MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                     

                      string StrAddTabla = "Insert into tablacomision (IdCargo,NombreCargo,IdTercero,Comision,Comision2, Recaudo1,Anticipo1,Recaudo2,Anticipo2,Usuario,FechaOperacion) Value " +
                          " (@IdCargo,@NombreCargo,@IdTercero,@Comision,@Comision2,@Recaudo1,@Anticipo1,@Recaudo2,@Anticipo2,@Usuario,@FechaOperacion) ";

                      MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                      MysqlConexion.Open();
                      MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                      MySqlTransaction myTrans;
                      myTrans = MysqlConexion.BeginTransaction();
                      CmdAddPrm.Connection = MysqlConexion;
                      CmdAddPrm.Transaction = myTrans;
                      try
                      {
                          CmdAddPrm.Parameters.Add("@IdCargo", MySql.Data.MySqlClient.MySqlDbType.Int16);
                          CmdAddPrm.Parameters.Add("@NombreCargo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                          CmdAddPrm.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                          CmdAddPrm.Parameters.Add("@Comision", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                          CmdAddPrm.Parameters.Add("@Comision2", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                          CmdAddPrm.Parameters.Add("@Recaudo1", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                          CmdAddPrm.Parameters.Add("@Anticipo1", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                          CmdAddPrm.Parameters.Add("@Recaudo2", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                          CmdAddPrm.Parameters.Add("@Anticipo2", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                          CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                          CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);

                          CmdAddPrm.Parameters["@IdCargo"].Value = Consecutivo;
                          CmdAddPrm.Parameters["@NombreCargo"].Value = TxtNombreCargo.Text;
                          if (TxtIdTercero.Text == "")
                          {
                              CmdAddPrm.Parameters["@IdTercero"].Value = null;
                          }
                          else
                          {
                              CmdAddPrm.Parameters["@IdTercero"].Value = TxtIdTercero.Text;
                          }
                        
                          CmdAddPrm.Parameters["@Comision"].Value = Convert.ToDecimal(TxtComision.Text);
                          CmdAddPrm.Parameters["@Comision2"].Value = Convert.ToDecimal(TxtComision2.Text);
                          CmdAddPrm.Parameters["@Recaudo1"].Value = Convert.ToDecimal(TxtRecaudo1.Text);
                          CmdAddPrm.Parameters["@Anticipo1"].Value = Convert.ToDecimal(TxtAnticipo1.Text);
                          CmdAddPrm.Parameters["@Recaudo2"].Value = Convert.ToDecimal(TxtRecaudo2.Text);
                          CmdAddPrm.Parameters["@Anticipo2"].Value = Convert.ToDecimal(TxtAnticipo2.Text);
                          CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                          CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;

                          CmdAddPrm.CommandText = StrAddTabla;
                          CmdAddPrm.ExecuteNonQuery();


                          myTrans.Commit();
                          MessageBox.Show("Registro Adicionado", "Adicionar Tabla Comision", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                          BtnOk.Enabled = false;
                      }
                      catch (MySqlException ex)
                      {
                          myTrans.Rollback();
                          MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Tabla Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

                      }
                      finally
                      {
                          MysqlConexion.Close();

                      }
                  }
              }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  M O D I F I C A R
//===================================================================================================================================================

        
//===================================================================================================================================================
// I N I C I O  M E T O D O   M O D I F I C A R
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
                 rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Tabla Comision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                 if (rest == DialogResult.Yes)
                 {
                     MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                     string StrModTabla = "Update tablacomision Set NombreCargo=@NombreCargo, IdTercero=@IdTercero, Comision=@Comision,Comision2=@Comision2, Recaudo1=@Recaudo1, " +
                         "Anticipo1=@Anticipo1, Recaudo2=@Recaudo2, Anticipo2=@Anticipo2,Usuario=@Usuario, FechaOperacion=@FechaOperacion Where IdCargo=@IdCargo";

                     MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                     MysqlConexion.Open();
                     MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                     MySqlTransaction myTrans;
                     myTrans = MysqlConexion.BeginTransaction();
                     CmdAddPrm.Connection = MysqlConexion;
                     CmdAddPrm.Transaction = myTrans;
                     try
                     {
                         CmdAddPrm.Parameters.Add("@IdCargo", MySql.Data.MySqlClient.MySqlDbType.Int16);
                         CmdAddPrm.Parameters.Add("@NombreCargo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                         CmdAddPrm.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                         CmdAddPrm.Parameters.Add("@Comision", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                         CmdAddPrm.Parameters.Add("@Comision2", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                         CmdAddPrm.Parameters.Add("@Recaudo1", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                         CmdAddPrm.Parameters.Add("@Anticipo1", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                         CmdAddPrm.Parameters.Add("@Recaudo2", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                         CmdAddPrm.Parameters.Add("@Anticipo2", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                         CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                         CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);

                         CmdAddPrm.Parameters["@IdCargo"].Value = Convert.ToInt16(TxtIdCargo.Text);
                         CmdAddPrm.Parameters["@NombreCargo"].Value = TxtNombreCargo.Text;
                         if (TxtIdTercero.Text == "")
                         {
                             CmdAddPrm.Parameters["@IdTercero"].Value = null;
                         }
                         else
                         {
                             CmdAddPrm.Parameters["@IdTercero"].Value = TxtIdTercero.Text;
                         }
                         CmdAddPrm.Parameters["@Comision"].Value = Convert.ToDecimal(TxtComision.Text);
                         CmdAddPrm.Parameters["@Comision2"].Value = Convert.ToDecimal(TxtComision2.Text);
                         CmdAddPrm.Parameters["@Recaudo1"].Value = Convert.ToDecimal(TxtRecaudo1.Text);
                         CmdAddPrm.Parameters["@Anticipo1"].Value = Convert.ToDecimal(TxtAnticipo1.Text);
                         CmdAddPrm.Parameters["@Recaudo2"].Value = Convert.ToDecimal(TxtRecaudo2.Text);
                         CmdAddPrm.Parameters["@Anticipo2"].Value = Convert.ToDecimal(TxtAnticipo2.Text);
                         CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                         CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;

                         CmdAddPrm.CommandText = StrModTabla;
                         CmdAddPrm.ExecuteNonQuery();


                         myTrans.Commit();
                         MessageBox.Show("Registro Modificado", "Modificar Tabla Comision", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                         BtnOk.Enabled = false;
                     }
                     catch (MySqlException ex)
                     {
                         myTrans.Rollback();
                         MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Tabla Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

                     }
                     finally
                     {
                         MysqlConexion.Close();

                     }
                 }
             }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  M O D I F I C A R
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O  M E T O D O   M O D I F I C A R
//===================================================================================================================================================
        private void MtdEliminar()
        {

           
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Eliminar Este Registro", "Eliminar Tabla Comision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                    string StrDelTabla = "Delete From TablaComision Where IdCargo=@IdCargo";

                    MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                    MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                        CmdAddPrm.Parameters.Add("@IdCargo", MySql.Data.MySqlClient.MySqlDbType.Int16);                       

                        CmdAddPrm.Parameters["@IdCargo"].Value = Convert.ToInt16(TxtIdCargo.Text);


                        CmdAddPrm.CommandText = StrDelTabla;
                        CmdAddPrm.ExecuteNonQuery();


                        myTrans.Commit();
                        MessageBox.Show("Registro Eliminado", "Eliminar Tabla Comision", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Tabla Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }
                
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  M O D I F I C A R
//===================================================================================================================================================


        #region  REGION DE EVENTOS 

        private void TxtNombreCargo_Enter(object sender, EventArgs e)
        {
            TxtNombreCargo.BackColor = Color.White;
        }

        private void TxtNombreCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtIdTercero.Focus();
            }
        }

        private void TxtNombreCargo_Leave(object sender, EventArgs e)
        {
            TxtNombreCargo.BackColor = Color.Gainsboro;
        }

        private void TxtTitular1_Enter(object sender, EventArgs e)
        {
            TxtIdTercero.BackColor = Color.White;
        }

        private void TxtTitular1_Leave(object sender, EventArgs e)
        {
            TxtIdTercero.BackColor = Color.Gainsboro;
        }

        private void TxtComision_Enter(object sender, EventArgs e)
        {
            TxtComision.BackColor = Color.White;
        }

        private void TxtComision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
               TxtComision2.Focus();
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtComision.Text.Length; i++)
            {
                if (TxtComision.Text[i] == '.')
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

        private void TxtComision_Leave(object sender, EventArgs e)
        {
            TxtComision.BackColor = Color.Gainsboro;
            if (TxtComision.Text == "")
            {
                TxtComision.Text = "0";
            }
            this.TxtComision.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtComision.Text));
        }

        private void TxtRecaudo1_Enter(object sender, EventArgs e)
        {
            TxtRecaudo1.BackColor = Color.White;
        }

        private void TxtRecaudo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtAnticipo1.Focus();
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtRecaudo1.Text.Length; i++)
            {
                if (TxtRecaudo1.Text[i] == '.')
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

        private void TxtRecaudo1_Leave(object sender, EventArgs e)
        {
            TxtRecaudo1.BackColor = Color.Gainsboro;

            if (TxtRecaudo1.Text == "")
            {
                TxtRecaudo1.Text = "0";
            }
            this.TxtRecaudo1.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtRecaudo1.Text));
        }

        private void TxtAnticipo1_Enter(object sender, EventArgs e)
        {
            TxtAnticipo1.BackColor = Color.White;
        }

        private void TxtAnticipo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtRecaudo2.Focus();
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtAnticipo1.Text.Length; i++)
            {
                if (TxtAnticipo1.Text[i] == '.')
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

        private void TxtAnticipo1_Leave(object sender, EventArgs e)
        {
            TxtAnticipo1.BackColor = Color.Gainsboro;

            if (TxtAnticipo1.Text == "")
            {
                TxtAnticipo1.Text = "0";
            }
            this.TxtAnticipo1.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtAnticipo1.Text));
        }

        private void TxtRecaudo2_Enter(object sender, EventArgs e)
        {
            TxtRecaudo2.BackColor = Color.White;
        }

        private void TxtRecaudo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtAnticipo2.Focus();
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtRecaudo2.Text.Length; i++)
            {
                if (TxtRecaudo2.Text[i] == '.')
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

        private void TxtRecaudo2_Leave(object sender, EventArgs e)
        {
            TxtRecaudo2.BackColor = Color.Gainsboro;
            if (TxtRecaudo2.Text == "")
            {
                TxtRecaudo2.Text = "0";
            }
            this.TxtRecaudo2.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtRecaudo2.Text));
        }

        private void TxtAnticipo2_Enter(object sender, EventArgs e)
        {
            TxtAnticipo2.BackColor = Color.White;
        }

        private void TxtAnticipo2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                BtnOk.Focus();
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtAnticipo2.Text.Length; i++)
            {
                if (TxtAnticipo2.Text[i] == '.')
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

        private void TxtAnticipo2_Leave(object sender, EventArgs e)
        {
            TxtAnticipo2.BackColor = Color.Gainsboro;
            if (TxtAnticipo2.Text == "")
            {
                TxtAnticipo2.Text = "0";
            }
            this.TxtAnticipo2.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtAnticipo2.Text));
        }        

        private void BtnOk_Enter(object sender, EventArgs e)
        {
            BtnOk.BackColor = Color.White;
        }

        private void BtnOk_Leave(object sender, EventArgs e)
        {
            BtnOk.BackColor = Color.Gainsboro;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (Entrada == "Adicionar")
            {
                MtdAdicionar();

            }
            else

                if (Entrada == "Modificar")
                {
                    MtdModificar();
                }
                else
                    if (Entrada == "Eliminar")
                    {
                        MtdEliminar();
                    }
                   
        }

        private void BtnEscape_Enter(object sender, EventArgs e)
        {
            BtnEscape.BackColor = Color.White;
        }

        private void BtnEscape_Leave(object sender, EventArgs e)
        {
            BtnEscape.BackColor = Color.Gainsboro;
        }       

        private void BtnEscape_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        private void BtnBusquedad1_Click(object sender, EventArgs e)
        {
            FrmCatalogoTerceros catalogo = new FrmCatalogoTerceros();
            catalogo.VarTipoTercero = "Gestor";
            catalogo.ShowDialog();
            TxtIdTercero.Text = FrmCatalogoTerceros.VarIdTercero;
            LblNombreTitular.Text = FrmCatalogoTerceros.VarNombreTercero;
        }

        private void TxtComision2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtRecaudo1.Focus();
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtComision2.Text.Length; i++)
            {
                if (TxtComision2.Text[i] == '.')
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

        private void TxtComision2_Enter(object sender, EventArgs e)
        {
            TxtComision2.BackColor = Color.White;
        }

        private void TxtComision2_Leave(object sender, EventArgs e)
        {
            TxtComision2.BackColor = Color.Gainsboro;
            if (TxtComision2.Text == "")
            {
                TxtComision2.Text = "0";
            }
            this.TxtComision2.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtComision2.Text));
        }

       

       


    }
}
