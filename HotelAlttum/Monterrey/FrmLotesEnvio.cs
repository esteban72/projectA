using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using MySql.Data.MySqlClient;
namespace CarteraGeneral
{
    public partial class FrmLotesEnvio : DevExpress.XtraEditors.XtraForm
    {
        public FrmLotesEnvio()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
        string consecutivo;
        private void FrmLotesEnvio_Load(object sender, EventArgs e)
        {
            consecutivo = conexion.MtdBscDatos(MisConsultas.ConsecutivoLotesEnvio);
            TxtNumLote.EditValue = consecutivo;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (dtFecha.EditValue == null)
            {
                MessageBox.Show("Falta Seleccionar Fecha", "Adicionar Lotes Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Lotes Envio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rest == DialogResult.Yes)
                {
                    MtdGuardarTRM();
                }
            }
        }

        void MtdGuardarTRM()
        {
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            myCommand.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Convert.ToDateTime(dtFecha.EditValue.ToString()).Date;
            myCommand.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32, 10).Value = TxtNumLote.EditValue.ToString();

            try
            {

                myCommand.CommandText = "INSERT INTO lotesenvio (Id,Fecha) values ( @Id,@Fecha)";
                myCommand.ExecuteNonQuery();
                myTrans.Commit();

                MessageBox.Show(this, "Datos Guardados", "Guardar Lotes Envio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnGuardar.Enabled = false;
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                if (ex.Message.Contains("Duplicate entry"))
                {
                    MessageBox.Show("Ya se ha ingresado numero de lote", "" + "Guardar Lotes Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Guardar Lotes Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            finally
            {
                MysqlConexion.Close();

            }
        }

        void MtdModifcarTRM()
        {
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            myCommand.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date).Value = Convert.ToDateTime(dtFecha.EditValue.ToString()).Date;
            myCommand.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32, 10).Value = TxtNumLote.EditValue.ToString();

            try
            {

                myCommand.CommandText = "UPDATE lotesenvio SET Fecha=@Fecha WHERE Id = @Id";
                myCommand.ExecuteNonQuery();
                myTrans.Commit();

                MessageBox.Show(this, "Datos Guardados", "Guardar Lotes Envio", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                BtnGuardar.Enabled = false;
            }
            catch (Exception ex)
            {
                myTrans.Rollback();
                if (ex.Message.Contains("Duplicate entry"))
                {
                    MessageBox.Show("Ya se ha ingresado un valor en esa fecha, cambie la fecha", "" + "Guardar Lotes Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Guardar TRM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            finally
            {
                MysqlConexion.Close();

            }
        }
    }
}