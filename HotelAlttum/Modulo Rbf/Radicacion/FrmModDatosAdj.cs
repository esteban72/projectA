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
    public partial class FrmModDatosAdj : Form
    {
        public FrmModDatosAdj()
        {
            InitializeComponent();
        }
        public string VarIdajudicacion;
        System.Data.DataTable DatosAdjudicacion = new System.Data.DataTable();
        System.Data.DataTable DtInmueble = new System.Data.DataTable();
        ClsIdentificacion conexion = new ClsIdentificacion();
        private void FrmModDatosAdj_Load(object sender, EventArgs e)
        {
            MtdDatosAdjudicacion();
        }

        private void TxtBase_Enter(object sender, EventArgs e)
        {
            TxtBase.BackColor = Color.White;
        }

        private void TxtBase_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {
                TxtPorcentaje.Focus();
            }

            else
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                bool IsDec = false;

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
        }

        private void TxtBase_Leave(object sender, EventArgs e)
        {
            TxtBase.BackColor = Color.Gainsboro;
            if (TxtBase.Text == "")
            {
                TxtBase.Text = DatosAdjudicacion.Rows[0][7].ToString();
                this.TxtBase.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtBase.Text));
            }
            else
            {
                this.TxtBase.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtBase.Text));
            }
        }

        private void TxtPorcentaje_Enter(object sender, EventArgs e)
        {
            TxtPorcentaje.BackColor = Color.White;
        }

        private void TxtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                BtnOk.Focus();
            }

            else
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                bool IsDec = false;

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
        }

        private void TxtPorcentaje_Leave(object sender, EventArgs e)
        {
            TxtPorcentaje.BackColor = Color.Gainsboro;
            if (TxtPorcentaje.Text == "")
            {
                TxtPorcentaje.Text = DatosAdjudicacion.Rows[0][8].ToString();
            }

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

        private void BtnOk_Click(object sender, EventArgs e)
        {
            MtdModificar();
        }

        private void BtnEscape_Click(object sender, EventArgs e)
        {
            Close();
        }

//==================================================================================================================================================
// I N I C I O   M E T O D O   D A T O S   A D J U D I C A C I O N
//===================================================================================================================================================
        private void MtdDatosAdjudicacion()
        {
            DatosAdjudicacion = conexion.MtdBuscarDataset("Select Contrato,IdInmueble,IdTercero1,IdTercero2,IdTercero3,Observacion,Valor,BaseComision," +
            "Porcentaje   from Adjudicacion where IdAdjudicacion = " + VarIdajudicacion);

            LblAdjudicacion.Text = VarIdajudicacion;
            TxtContrato.Text = DatosAdjudicacion.Rows[0][0].ToString();
            TxtInmueble.Text = DatosAdjudicacion.Rows[0][1].ToString();
            TxtTitular1.Text = DatosAdjudicacion.Rows[0][2].ToString();
            TxtTitular2.Text = DatosAdjudicacion.Rows[0][3].ToString();
            TxtTitular3.Text = DatosAdjudicacion.Rows[0][4].ToString();
            LblNombreTitular.Text = conexion.MtdBscNombres(TxtTitular1.Text);

            if (TxtTitular2.Text != "")
            {
                LblNombreTitular2.Text = conexion.MtdBscNombres(TxtTitular2.Text);
            }
            if (TxtTitular3.Text != "")
            {
                LblNombreTitular3.Text = conexion.MtdBscNombres(TxtTitular3.Text);
            }
            TxtObservacion.Text = DatosAdjudicacion.Rows[0][5].ToString();
          
            TxtValorContrato.Text = DatosAdjudicacion.Rows[0][6].ToString();
            this.TxtValorContrato.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorContrato.Text));
            TxtBase.Text = DatosAdjudicacion.Rows[0][7].ToString();
            this.TxtBase.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtBase.Text));
            TxtPorcentaje.Text = DatosAdjudicacion.Rows[0][8].ToString();
            if (TxtInmueble.Text != "")
            {
                DtInmueble = conexion.MtdBuscarDataset("Select Villa,Unidad,Semana from Inmuebles  Where IdInmueble = '" + TxtInmueble.Text + "'");
                TxtVilla.Text = DtInmueble.Rows[0][0].ToString();
                TxtUnidad.Text = DtInmueble.Rows[0][1].ToString();
               TxtSemana.Text = DtInmueble.Rows[0][2].ToString();
            }
        }
//===================================================================================================================================================
// F I N A L     M E T O D O   D A T O S   A D J U D I C A C I O N
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O  M E T O D O   M O D I F I C A R   A D J U D I C A C I O N
//===================================================================================================================================================
        private void MtdModificar()
        {
                     
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                   

                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);


                    string ModAdjudicacion = "insert into modadjudicacion (Select * from Adjudicacion where idadjudicacion=@IdAdjudicacion)";
                   

                    string StrModAdjudicacion = " Update Adjudicacion set BaseComision=@BaseComision,Porcentaje=@Porcentaje,FechaOperacion=@FechaOperacion,Usuario=@Usuario "+
                                                " Where IdAdjudicacion=@IdAdjudicacion";                   


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
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Porcentaje", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@BaseComision", MySql.Data.MySqlClient.MySqlDbType.Decimal);                       

                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = VarIdajudicacion;                        
                        CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                        CmdAddPrm.Parameters["@Porcentaje"].Value = Convert.ToDecimal(TxtPorcentaje.Text);
                        CmdAddPrm.Parameters["@BaseComision"].Value = Convert.ToDecimal(TxtBase.Text);   

                        CmdAddPrm.CommandText = ModAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();
                        CmdAddPrm.CommandText = StrModAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();  
                        
                        myTrans.Commit();
                        MessageBox.Show("Registro Modificado", "Modificar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                    }
                      
                    
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        MysqlConexion.Close();
                    }
                
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    M O D I F I C A R  A D J U D I C A C I O N
//===================================================================================================================================================


        
    }
}
