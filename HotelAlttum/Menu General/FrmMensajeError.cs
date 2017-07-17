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
    public partial class FrmMensajeError : Form
    {
        public FrmMensajeError()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMensajeError_Load(object sender, EventArgs e)
        {
            pictureBox2.Image = FrmMenuGeneral.Logo;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
