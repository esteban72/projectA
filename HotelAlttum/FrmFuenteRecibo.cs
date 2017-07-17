using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarteraGeneral
{
    public partial class FrmFuenteRecibo : Form
    {
        public FrmFuenteRecibo()
        {
            InitializeComponent();
        }

        public static string botonpresionado;
        public static string strfuente;

        private void FrmFuenteRecibo_Load(object sender, EventArgs e)
        {

        }

        private void BtnConfir_Click(object sender, EventArgs e)
        {
            botonpresionado = "ACEPTAR";
            strfuente = CmbFuenteR.Text;
            if (CmbFuenteR.Text.Length == 0)
            {
                MessageBox.Show("Seleccione Tipo de Recibo", "Recaudos de Cartera", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Close();
            }

        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            botonpresionado = "SALIR";
            Close(); 
        }
    }
}
