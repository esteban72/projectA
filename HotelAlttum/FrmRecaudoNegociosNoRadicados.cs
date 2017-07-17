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
    public partial class FrmRecaudoNegociosNoRadicados : Form
    {
        public FrmRecaudoNegociosNoRadicados()
        {
            InitializeComponent();
        }

        #region VARIABLES
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        string VarIdAdjudicacion;
        DataTable DtListado = new DataTable();

        #endregion

        private void FrmRecaudoNegociosNoRadicados_Load(object sender, EventArgs e)
        {
            DtListado = NuevoClsIdentificacion.MtdBuscarDataset("Select Scrip from vistas where Vista='CnsAddRcdReserva'");
            string strconsulta = DtListado.Rows[0]["Scrip"].ToString();
            DtListado = NuevoClsIdentificacion.MtdBuscarDataset(strconsulta);
            GrdRcdNoRadicado.DataSource = DtListado;
        }
    }
}
