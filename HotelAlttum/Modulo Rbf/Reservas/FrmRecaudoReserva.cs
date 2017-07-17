using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarteraGeneral.Modulo_Rbf.Reservas
{
    public partial class FrmRecaudoReserva : Form
    {
        public FrmRecaudoReserva()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rest;
                rest = MessageBox.Show("Esta seguro que desea Salir", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    Close();
                }
        }
    }
}
