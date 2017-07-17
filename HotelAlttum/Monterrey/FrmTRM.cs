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
using CarteraGeneral.WebServiceTRMColombia;
using System.Globalization;

namespace CarteraGeneral
{
    public partial class FrmTRM : DevExpress.XtraEditors.XtraForm
    {
        TCRMServicesInterfaceClient client = new TCRMServicesInterfaceClient();
        tcrmResponse response = default(tcrmResponse);
        public FrmTRM()
        {
            InitializeComponent();
        }

        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
        ClsIdentificacion Conexion = new ClsIdentificacion();
        public string strEntrada;

        private void FrmTRM_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            try
            {
                if (chkFechaActual.Checked)
                {
                    response = client.queryTCRM(DateTime.Now);

                }
                else
                {
                    System.DateTime currentDate = monthCalendar1.SelectionStart;
                    response = client.queryTCRM(currentDate);
                }

                txtTRM.Text = response.value.ToString();
                txtValidoDesde.Text = string.Concat(response.validityFrom.ToString("dd/MM/yyyy"), " - ", response.validityTo.ToString("dd/MM/yyyy"));
                txtIdentificador.Text = response.id.ToString();
                txtUnidad.Text = response.unit;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ups! Hubo un inconveniente consultando la TRM:\n"+ ex.Message + ".", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTRM.Text = "";
            txtValidoDesde.Text = "";
            txtIdentificador.Text = "";
            txtUnidad.Text = "";
            txtValorCalcular.Text = "";
            txtResultado.Text = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (chkFechaActual.Checked)
            {
                if (txtValorCalcular.Text != "")
                {
                    float valorConvertido = float.Parse(txtValorCalcular.Text, CultureInfo.InvariantCulture);
                    if (rbtnDolares.Checked == true)
                    {
                        txtResultado.Text = (valorConvertido / response.value).ToString("###,###.###");
                    }
                    else
                    {
                        txtResultado.Text = (valorConvertido * response.value).ToString("###,###.###");
                    }

                }
                else
                {
                    MessageBox.Show("Debe ingresar un valor a calcular.", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (txtValorCalcular.Text != "")
                {
                    float valorConvertido = float.Parse(txtValorCalcular.Text, CultureInfo.InvariantCulture);
                    txtResultado.Text = (valorConvertido * response.value).ToString("###,###.###");
                }
                else
                {
                    MessageBox.Show("Debe ingresar un valor a calcular.", "ERROR!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void rbtnDolares_CheckedChanged(object sender, EventArgs e)
        {
            if(rbtnDolares.Checked == true){
                rbtnPesos.Checked = false;
                txtValorCalcular.Text = "";
                txtResultado.Text = "";
            }
            
        }

        private void rbtnPesos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnPesos.Checked == true)
            {
                rbtnDolares.Checked = false;
                txtValorCalcular.Text = "";
                txtResultado.Text = "";
            }
        }


        
    }
}