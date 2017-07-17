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
    public partial class FrmCambioConsecutivos : Form
    {
        public FrmCambioConsecutivos()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        List<string> DatosdeErrores = new List<string>();
        double CuentaErrores;
        DataTable DtDatos = new DataTable();
        System.Data.DataTable DtParametros = new System.Data.DataTable();
        string strfuente;
        private void FrmControl_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
        
            DtParametros = conexion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
      
            strfuente =  DtParametros.Rows[0][6].ToString();
            MtdDatos();
        }

//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O S
//===================================================================================================================================================
        private void MtdDatos()
        {
            TxtId.Text = strfuente;
            DtDatos = conexion.MtdBuscarDataset("Select * From Contabilidad_alttum.documentomanual Where idComprobante ='" + TxtId.Text + "'");
            TxtNombre.Text = DtDatos.Rows[0][1].ToString();
            CmbTipo.Text = conexion.MtdBscDatos("Select Nombre From Contabilidad_alttum.Tipodocumento where ID=" + DtDatos.Rows[0][3].ToString());
            CmbCuenta.Text = conexion.MtdBscDatos("Select Descripcion From Contabilidad_alttum.006cnscuenta where codigo= '" + DtDatos.Rows[0][4].ToString() + "'");
            TxtConsecutivo.Text = DtDatos.Rows[0][5].ToString();
            ChbAutomatico.Checked = Convert.ToBoolean( DtDatos.Rows[0][6].ToString());
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   V A L I D A R  
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O  M O D I F I C A R  D O C U M E N T O
//===================================================================================================================================================
        public void MtdModDocumento()
        {
            if (CuentaErrores > 0)
            {
                FrmMensajeError  frmError= new FrmMensajeError();
                frmError.LblErrores.DataSource = DatosdeErrores;
                frmError.ShowDialog();
            }

            else
            {
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Documento", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {

                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                    MysqlConexion.Open();
                    MySqlCommand myCommand = MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    string idTipoDocumento, Cuenta;
                    idTipoDocumento = conexion.MtdBscDatos("Select Id From Contabilidad_alttum.TipoDocumento where Nombre = '" + CmbTipo.Text + "'");
                    Cuenta = conexion.MtdBscDatos("Select Codigo From Contabilidad_alttum.006cnscuenta where Descripcion = '" + CmbCuenta.Text + "'");
                    myTrans = MysqlConexion.BeginTransaction();
                    myCommand.Connection = MysqlConexion;
                    myCommand.Transaction = myTrans;
                    try
                    {
                        myCommand.CommandText = "Update  Contabilidad_alttum.documentomanual set idComprobante = '" + TxtId.Text + "',NombreComprobante = '" + TxtNombre.Text + "',IdTipoDocumento = " +
                        idTipoDocumento + ",Cuenta ='" + Cuenta + "',ConsecutivoRef =" + TxtConsecutivo.Text + ",Automatico =" + Convert.ToBoolean(ChbAutomatico.Checked) + " Where IdComprobante ='"+ TxtId.Text+"'";


                        myCommand.ExecuteNonQuery();

                        myTrans.Commit();
                        MessageBox.Show("Registro Modificado", "Modificar Documento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        BtnAceptar.Enabled = false;
                    }
                    catch (Exception e)
                    {
                        try
                        {
                            myTrans.Rollback();
                            MessageBox.Show("Ha ocurrido el Sgte Error " + e.Message, "Modificar Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (MySqlException ex)
                        {
                            if (myTrans.Connection != null)
                            {
                                MessageBox.Show("Ha ocurrido el Sgte Error " + ex.Message, "Modificar Documento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }
                }
            }

        }       
//===================================================================================================================================================
// F I N A L   M E T O D O   A D I C I O  N A R   D O M U E N T O 
//===================================================================================================================================================

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            MtdModDocumento();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
