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
    public partial class FrmModificarComision : Form
    {
        ClsIdentificacion conexion = new ClsIdentificacion();
        DataTable DtCargos = new DataTable();
        public string VarComision1, VarComision2, VarComision3,VarIdCargo, VarNombreCargo, VarNombre, VarIdTercero, VarEntrada, VarIdadjudicacion, VarCliente;
        public FrmModificarComision()
        {
            InitializeComponent();
        }
       

        private void FrmModificarComision_Load(object sender, EventArgs e)
        {
            DtCargos = conexion.MtdBuscarDataset("select *from  tablacomision");
            pictureBox1.Image = FrmMenuGeneral.Logo;
            if (VarEntrada == "Modificar")
            {
                MtdDAtos();
                LblTitulo.Text = "MODIFICAR COMISION";
            }

            if (VarEntrada == "Adicionar")
            {
                MtdDAtosAdd();
                BtnOk.Text = "Adicionar";
                LblTitulo.Text = "ADICIONAR COMISION";
                CmbCargo.DataSource = conexion.MtdListaCamposSent("Select NombreCargo From tablacomision  Where Comision = 0 and idcargo not in" + 
                " (select idcargo from comision where IdAdjudicacion="+VarIdadjudicacion+")   Order By NombreCargo", "NombreCargo");
                LblTitulo.Text = "Adicionar COMISION";
            }
        }


//===================================================================================================================================================
// I N I C I O  M E T O D O   M O D I F I C A R
//===================================================================================================================================================
        private void MtdModificar()
        {          
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Comision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                    string StrModTabla = "Update Comision Set Comision1 =@Comision1,Comision2=@Comision2,Comision3=@Comision3,Idtercero=@IdTercero , Usuario =@Usuario, " +
                     "  FechaOperacion = @FechaOperacion Where IdAdjudicacion =@IdAdjudicacion And IdCargo =@IdCargo";

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
                        CmdAddPrm.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Comision1", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Comision2", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Comision3", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);

                        CmdAddPrm.Parameters["@IdCargo"].Value = Convert.ToInt16(TxtIdCargo.Text);
                       
                        if (TxtIdTercero.Text == "")
                        {
                            CmdAddPrm.Parameters["@IdTercero"].Value = null;
                        }
                        else
                        {
                            CmdAddPrm.Parameters["@IdTercero"].Value = TxtIdTercero.Text;
                        }
                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                        CmdAddPrm.Parameters["@Comision1"].Value = Convert.ToDecimal(TxtComision1.Text);
                        CmdAddPrm.Parameters["@Comision2"].Value = Convert.ToDecimal(TxtComision2.Text);
                        CmdAddPrm.Parameters["@Comision3"].Value = Convert.ToDecimal(TxtComision3.Text);
                        CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;

                        CmdAddPrm.CommandText = StrModTabla;
                        CmdAddPrm.ExecuteNonQuery();


                        myTrans.Commit();
                        MessageBox.Show("Registro Modificado", "Modificar Comision", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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


//===================================================================================================================================================
// I N I C I O   M E T O D O    V A L I D A R  T E R C E R O S
//===================================================================================================================================================
        public int MtdValidarCargos(string NomCargo)
        {
           
            int idcargo = 0;

            var query = (from DtCargos1 in DtCargos.AsEnumerable()

                         where DtCargos1.Field<string>("NombreCargo") == NomCargo

                         select new
                         {
                             idcargo = DtCargos1.Field<int>("IdCargo"),
                         });

            foreach (var order in query)
            {
                idcargo = order.idcargo;
            }
            return idcargo;

        }
//===================================================================================================================================================
// F I N A L    M E T O D O  V A L I D A R   T E R C E R O S 
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O  M E T O D O   A D I C I O N A R   
//===================================================================================================================================================
        private void MtdAdicionar()
        {
            int VarIdCargo= MtdValidarCargos(CmbCargo.Text);

            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Comision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {


                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                string StrAddComision = "insert into Comision (IdAdjudicacion,Fecha,IdComision,IdTercero,IdCargo,Comision1,Comision2,Comision3,Usuario,FechaOperacion) " +
                "Values (@IdAdjudicacion,@Fecha,@IdComision,@IdTercero,@IdCargo,@Comision1,@Comision2,@Comision3,@Usuario,@FechaOperacion)";

                

                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@IdCargo", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@IdComision", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Comision1", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                    CmdAddPrm.Parameters.Add("@Comision2", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                    CmdAddPrm.Parameters.Add("@Comision3", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                    CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters["@IdComision"].Value =  (VarIdCargo + "ADJ" + TxtAdjudicacion.Text);
                    CmdAddPrm.Parameters["@IdTercero"].Value = TxtIdTercero.Text;
                    CmdAddPrm.Parameters["@IdCargo"].Value = VarIdCargo;
                    CmdAddPrm.Parameters["@Comision1"].Value =Convert.ToDecimal( TxtComision1.Text);
                    CmdAddPrm.Parameters["@Comision2"].Value =Convert.ToDecimal( TxtComision2.Text);
                    CmdAddPrm.Parameters["@Comision3"].Value = Convert.ToDecimal(TxtComision3.Text);
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;   

                    CmdAddPrm.CommandText = StrAddComision;
                    CmdAddPrm.ExecuteNonQuery();                   

                    myTrans.Commit();
                    MessageBox.Show("Registro Adicionado", "Adicionar Comision", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    BtnOk.Enabled = false;
                
                }
                
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
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







        private void MtdDAtos()
        {
            TxtAdjudicacion.Text = VarIdadjudicacion;
            TxtClinte.Text = VarCliente;
            TxtComision1.Text = VarComision1;
            TxtComision2.Text = VarComision2;
            TxtComision3.Text = VarComision3;
            TxtIdCargo.Text = VarIdCargo;
            TxtNombreCargo.Text = VarNombreCargo;
            TxtIdTercero.Text = VarIdTercero;
            LblNombreTitular.Text = VarNombre;
        }

        private void MtdDAtosAdd()
        {
            TxtAdjudicacion.Text = VarIdadjudicacion;
            TxtClinte.Text = VarCliente;
            TxtComision1.Text = "0";
            TxtComision2.Text = "0";
            TxtComision3.Text = "0";
            TxtIdCargo.Text = "";
            TxtNombreCargo.Text = "";
            TxtIdTercero.Text = "";
            LblNombreTitular.Text = "";
            label5.Visible = false;
            TxtNombreCargo.Visible = false;
            TxtIdCargo.Visible = false;
            CmbCargo.Visible = true;
            CmbCargo.Location = new Point(106, 63);
        }


        private void BtnBusquedad1_Click(object sender, EventArgs e)
        {
            FrmCatalogoTerceros catalogo = new FrmCatalogoTerceros();
            catalogo.VarTipoTercero = "Gestor";
            catalogo.ShowDialog();
            TxtIdTercero.Text = FrmCatalogoTerceros.VarIdTercero;
            LblNombreTitular.Text = FrmCatalogoTerceros.VarNombreTercero;
        }

        private void TxtIdCargo_Enter(object sender, EventArgs e)
        {
            TxtIdCargo.BackColor = Color.White;
        }

        private void TxtIdCargo_Leave(object sender, EventArgs e)
        {
            TxtIdCargo.BackColor = Color.Gainsboro;
        }

        private void TxtIdCargo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void TxtIdTercero_Enter(object sender, EventArgs e)
        {
            TxtIdTercero.BackColor = Color.White;
        }

        private void TxtIdTercero_Leave(object sender, EventArgs e)
        {
            TxtIdTercero.BackColor = Color.Gainsboro;
        }

        private void TxtIdTercero_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TxtComision1_Enter(object sender, EventArgs e)
        {
            TxtComision1.BackColor = Color.White;
        }

        private void TxtComision1_Leave(object sender, EventArgs e)
        {
            TxtComision1.BackColor = Color.Gainsboro;
            if (TxtComision1.Text == "")
            {
                TxtComision1.Text = "0";
            }
        }

        private void TxtComision1_KeyPress(object sender, KeyPressEventArgs e)
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

            for (int i = 0; i < TxtComision1.Text.Length; i++)
            {
                if (TxtComision1.Text[i] == '.')
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
        }

        private void TxtComision2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtComision3.Focus();
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

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (VarEntrada == "Modificar")
            {
                MtdModificar();
            }
            else
                
                if (VarEntrada == "Adicionar")
                {
                   MtdAdicionar();
                }
           
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TxtComision3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtComision3_Enter(object sender, EventArgs e)
        {
            TxtComision3.BackColor = Color.White;
        }

        private void TxtComision3_Leave(object sender, EventArgs e)
        {
            TxtComision3.BackColor = Color.Gainsboro;
            if (TxtComision2.Text == "")
            {
                TxtComision3.Text = "0";
            }
        }
    }
}
