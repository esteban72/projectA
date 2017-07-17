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
    public partial class FrmCondonacion : Form
    {
        public FrmCondonacion()
        {
            InitializeComponent();
        }

        decimal ValorMora = 0;
        decimal ValorCondonacion = 0;
        public string VarIdAdjudicacion;
        ClsIdentificacion conexion = new ClsIdentificacion();
        DataTable DtParametros = new DataTable();
        DataTable DtDatos = new DataTable();
        string Concepto = "";
        List<string> BscDtsRcd = new List<string>();
        DataTable DtListado = new DataTable();
        string StrPeriodo, StrInteresCte, StrInteresMora, StrDiaMora, StrDecimales;
        
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();           
        }

//===================================================================================================================================================
// I N I C I O   E V E N T O   C L I P   B T N   A D I C I O N A R
//===================================================================================================================================================
    private void BtnAceptar_Click(object sender, EventArgs e)
        {

            if (Convert.ToDecimal(TxtValor.Text) > (ValorMora - ValorCondonacion))
            {
                MessageBox.Show("Mayor ValorMora Condonacion");
            }
            else
            {              
                    MtdAddCondonacion();                
            }
        }
//===================================================================================================================================================
// F I N    E V E N T O   C L I P   B T N   A D I C I O N A R
//===================================================================================================================================================



        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


//===================================================================================================================================================
// I N I C I O   E V E N T O   C L I P   B T N   M O D I F I C A R
//===================================================================================================================================================
        private void BtnModificar_Click(object sender, EventArgs e)
        {
        
            if (Convert.ToDecimal(TxtValor.Text) > (ValorMora))
            {
                MessageBox.Show("Mayor ValorMora Condonacion");
            }
            else
            {               
                        MtdModCondonacion();                  
            }

        }
//===================================================================================================================================================
//F I N A L  E V E N T O   C L I P   B T N   M O D I F I C A R
//===================================================================================================================================================

//===================================================================================================================================================
// I N I C I O   E V E N T O   C L I P   B T N   E L I M I N A R
//===================================================================================================================================================
        private void BtnElimnar_Click(object sender, EventArgs e)
        {
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Eliminar Este Registro", "Eliminar Condonacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rest == DialogResult.Yes)
            {
                {
                    MtddELCondonacion();
                }
            }
        }
//===================================================================================================================================================
//F I N A L  E V E N T O   C L I P   B T N   E L I M I N A R
//===================================================================================================================================================





        
        #region E V E N T O S


//===================================================================================================================================================
// I N I C I O   E V E N T O   L O A D   F O R M U L A R I O
//===================================================================================================================================================
        private void FrmCondonacion_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            Limpiar();
            DtParametros = conexion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
            StrInteresCte = DtParametros.Rows[0][0].ToString();
            StrInteresMora = DtParametros.Rows[0][1].ToString();
            StrPeriodo = DtParametros.Rows[0][2].ToString();
            StrDiaMora = DtParametros.Rows[0][3].ToString();
            StrDecimales = DtParametros.Rows[0][5].ToString();
        }
//===================================================================================================================================================
// F I N A L   E V E N T O   L O A D   F O R M U L A R I O 
//===================================================================================================================================================

   
 




//===================================================================================================================================================
// I N I C I O N   E V E N T O   K E Y   P R E S S   T X T V A L O R
//===================================================================================================================================================
private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == '\r')
            {
                this.TxtValor.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValor.Text));
                panel3.Focus();
            }

            else
            {
                if (Char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;
                }
                if (Char.IsLetter(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }
//===================================================================================================================================================
//F I N AL   E V E N T O   K E Y   P R E S S   T X T V A L O R 
//===================================================================================================================================================





//===================================================================================================================================================
// I N I C I O   E V E N T O   K E Y   P R E S S   T X T A D J U D I C A C I O N
//===================================================================================================================================================
        private void TxtAdjudicacion_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {

                double Contar = Convert.ToDouble(conexion.MtdBscDatos("select count(Identificacion) from 004CnsAdjudica where IdAdjudicacion = " +
                    TxtAdjudicacion.Text)) ;

                if (Contar == 0)
                {
                    MessageBox.Show("No Existe Adjudicacion");
                    TxtAdjudicacion.Clear();
                }
                else
                {
                    TxtAdjudicacion.Text =  TxtAdjudicacion.Text;
                    TxtCuota.Text = "";
                    TxtValor.Clear();
                    DtDatos = conexion.MtdBuscarDataset("Select * From 003CnsAdjudica WHERE IdAdjudicacion = " + TxtAdjudicacion.Text );
                    DatosGrl();  
                }
            }

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
//===================================================================================================================================================
// F I N A L   E V E N T O   K E Y   P R E S S   T X T A D J U D I C A C I O N
//===================================================================================================================================================





//===================================================================================================================================================
// I N I C I O   E V E N T O   L E A V E   T X T A D J U D I C A C I O N
//===================================================================================================================================================
private void TxtAdjudicacion_Leave(object sender, EventArgs e)
        {

            if (TxtAdjudicacion.Text != "")
            {

                double Contar = Convert.ToDouble(conexion.MtdBscDatos("select count(Identificacion) from 004CnsAdjudica where IdAdjudicacion = " +
                           TxtAdjudicacion.Text ));

                if (Contar == 0)
                {
                    MessageBox.Show("No Existe Adjudicacion)");
                }
                else
                {
                    TxtCuota.Text = "";
                    TxtValor.Clear();
                    DtDatos = conexion.MtdBuscarDataset("Select * From 003CnsAdjudica WHERE IdAdjudicacion = '" + TxtAdjudicacion.Text + "'");
                    DatosGrl();

                }
            }
        }
//===================================================================================================================================================
//F I N A L   E V E N T O   L E A V E   T X T A D J U D I C A C I O N 
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O  E V E N T O   DgvPagos_CellEnter
//===================================================================================================================================================
private void DgvPagos_CellEnter(object sender, DataGridViewCellEventArgs e)
{
    int C = DgvPagos.Rows.Count;
    ValorMora = Convert.ToDecimal(DgvPagos.Rows[e.RowIndex].Cells[5].Value.ToString());
    ValorCondonacion = Convert.ToDecimal(DgvPagos.Rows[e.RowIndex].Cells[6].Value.ToString());
    Concepto = DgvPagos.Rows[e.RowIndex].Cells[2].Value.ToString();
    TxtConcepto.Text = DgvPagos.Rows[e.RowIndex].Cells[2].Value.ToString();
    TxtCuota.Text = DgvPagos.Rows[e.RowIndex].Cells[1].Value.ToString();
    TxtValor.Text = Convert.ToString(ValorMora);
    this.TxtValor.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValor.Text));

    if (ValorCondonacion > 0)
    {
        BtnModificar.Visible = true;
        BtnElimnar.Visible = true;
        BtnAdicionar.Visible = false;
    }
    else
    {
        BtnModificar.Visible = false;
        BtnElimnar.Visible = false;
        BtnAdicionar.Visible = true;
    }

}
//===================================================================================================================================================
//F I N A L   E V E N T O   DgvPagos_CellEnter
//===================================================================================================================================================

        #endregion
  


        #region REGION DE METODOS

       
//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O  S   G E N  E R A L E S
//===================================================================================================================================================
        public void DatosGrl()
        {
            string Sentencia2 = conexion.MtdNuevoScripRecaudo( TxtAdjudicacion.Text, Convert.ToDecimal(StrInteresMora), Convert.ToInt16(StrDecimales));

            DtListado = conexion.MtdBuscarDataset(Sentencia2);
                   
            TxtNombres.Text = DtDatos.Rows[0][1].ToString();           
            TxtInmueble.Text = DtDatos.Rows[0][6].ToString();

            DgvPagos.Rows.Clear();
            for (int i = 0; i < (DtListado.Rows.Count); i++)
            {
                DgvPagos.Rows.Add(DtListado.Rows[i][3], DtListado.Rows[i][2], DtListado.Rows[i][1], DtListado.Rows[i][6], DtListado.Rows[i][12], DtListado.Rows[i][10], DtListado.Rows[i][14]);

            }          
        }
//===================================================================================================================================================
// F I N   M E T O D O   D A T O  S   G E N  E R A L E S
//===================================================================================================================================================





//===================================================================================================================================================
// I N I C I O  M E T O D O   MtdAddCondonacion
//===================================================================================================================================================
        private void MtdAddCondonacion()
        {
            int consecutivo = Convert.ToInt16(conexion.MtdBscDatos("select if(max(IdCondonacion)is null,1,max(IdCondonacion+1))from condonacion"));
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Condonacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                string StrAddCondonacion = "Insert Into Condonacion ( IdCondonacion,Fecha,IdAdjudicacion,IdFinanciacion,Cuota,Condonacion,Concepto,Usuario,FechaOpercion) Values" +
                 ("(@IdCondonacion,@Fecha,@IdAdjudicacion,@IdFinanciacion,@Cuota,@Condonacion,@Concepto,@Usuario,@FechaOperacion)");

                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {
                    CmdAddPrm.Parameters.Add("@IdCondonacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@IdFinanciacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Cuota", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@Condonacion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                    CmdAddPrm.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);

                    CmdAddPrm.Parameters["@IdCondonacion"].Value = consecutivo;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;                    
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@IdFinanciacion"].Value = TxtConcepto.Text + TxtCuota.Text + "ADJ" + TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@Cuota"].Value = Convert.ToInt16(TxtCuota.Text);
                    CmdAddPrm.Parameters["@Condonacion"].Value = Convert.ToDecimal(TxtValor.Text);
                    CmdAddPrm.Parameters["@Concepto"].Value = Concepto;
                    CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;

                    CmdAddPrm.CommandText = StrAddCondonacion;
                    CmdAddPrm.ExecuteNonQuery();

                    myTrans.Commit();
                    MessageBox.Show("Registro Adicionado", "Adicionar Condonacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DatosGrl();
                    BtnNuevo.Visible = true;
                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Condonacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MysqlConexion.Close();
                }

            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  MtdAddCondonacion
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O  M E T O D O   MtdAddCondonacion
//===================================================================================================================================================
        private void MtdModCondonacion()
        {
            int consecutivo = Convert.ToInt16(conexion.MtdBscDatos("select if(max(IdCondonacion)is null,1,max(IdCondonacion+1))from condonacion"));
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Condonacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                string AddModCondonacion = "Insert into ModCondonacion (Select * From Condonacion Where IdFinanciacion=@IdFinanciacion)";
                string StrDelCondonacin = "Delete From Condonacion Where IdFinanciacion=@IdFinanciacion";

                string StrAddCondonacion = "Insert Into Condonacion ( IdCondonacion,Fecha,IdAdjudicacion,IdFinanciacion,Cuota,Condonacion,Concepto,Usuario,FechaOpercion) Values" +
                 ("(@IdCondonacion,@Fecha,@IdAdjudicacion,@IdFinanciacion,@Cuota,@Condonacion,@Concepto,@Usuario,@FechaOperacion)");

                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {
                    CmdAddPrm.Parameters.Add("@IdCondonacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@IdFinanciacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Cuota", MySql.Data.MySqlClient.MySqlDbType.Int16);
                    CmdAddPrm.Parameters.Add("@Condonacion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                    CmdAddPrm.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);

                    CmdAddPrm.Parameters["@IdCondonacion"].Value = consecutivo;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@IdFinanciacion"].Value = TxtConcepto.Text + TxtCuota.Text + "ADJ" + TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@Cuota"].Value = Convert.ToInt16(TxtCuota.Text);
                    CmdAddPrm.Parameters["@Condonacion"].Value = Convert.ToDecimal(TxtValor.Text);
                    CmdAddPrm.Parameters["@Concepto"].Value = Concepto;
                    CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;

                    CmdAddPrm.CommandText = AddModCondonacion;
                    CmdAddPrm.ExecuteNonQuery();
                    CmdAddPrm.CommandText = StrDelCondonacin;
                    CmdAddPrm.ExecuteNonQuery();
                    CmdAddPrm.CommandText = StrAddCondonacion;
                    CmdAddPrm.ExecuteNonQuery();

                    myTrans.Commit();
                    MessageBox.Show("Registro Modificado", "Modificar Condonacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DatosGrl();
                    BtnNuevo.Visible = true;
                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Condonacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MysqlConexion.Close();
                }

            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  MtdAddCondonacion
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D O   MtddELCondonacion
//===================================================================================================================================================
        private void MtddELCondonacion()
        {
            
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Eliminar Este Registro", "Eliminar Condonacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                string AddModCondonacion = "Insert into ModCondonacion (Select * From Condonacion Where IdFinanciacion=@IdFinanciacion)";
                string StrDelCondonacin = "Delete From Condonacion Where IdFinanciacion=@IdFinanciacion";

              

                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {
                  
                    CmdAddPrm.Parameters.Add("@IdFinanciacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);                 

                   
                    CmdAddPrm.Parameters["@IdFinanciacion"].Value = TxtConcepto.Text + TxtCuota.Text + "ADJ" + TxtAdjudicacion.Text;
                   

                    CmdAddPrm.CommandText = AddModCondonacion;
                    CmdAddPrm.ExecuteNonQuery();
                    CmdAddPrm.CommandText = StrDelCondonacin;
                    CmdAddPrm.ExecuteNonQuery();
                   

                    myTrans.Commit();
                    MessageBox.Show("Registro Eliminado", "Eliminar Condonacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    DatosGrl();
                    BtnNuevo.Visible = true;
                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Eliminar Condonacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MysqlConexion.Close();
                }

            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  MtddELCondonacion
//===================================================================================================================================================






//===================================================================================================================================================
// I N I C I O  M E T O D O   L I M P I A R
//===================================================================================================================================================
        private void Limpiar()
        {
            panel2.Enabled = true;
            panel1.Enabled = true;
            DgvPagos.DataSource = null;
            TxtNombres.Text="";
            TxtInmueble.Text = "";
            TxtAdjudicacion.Clear();
            TxtCuota.Text="";
            TxtValor.Clear();
            BtnNuevo.Visible = false;
            BtnAdicionar.Enabled = true;
            TxtAdjudicacion.Focus();
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  L I M P I A R
//===================================================================================================================================================
        #endregion

        
       
      




    }
}
