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
    public partial class FrmRptComisionesxPagar : Form
    {
        public FrmRptComisionesxPagar()
        {
            InitializeComponent();
        }

        private void FrmRptComisionesxPagar_Load(object sender, EventArgs e)
        {
            try
            {
                this.rptcomisionesxpagarTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
                // TODO: esta línea de código carga datos en la tabla 'CarteraGeneralDataSet.rptcomisionesxpagar' Puede moverla o quitarla según sea necesario.

                this.rptcomisionesxpagarTableAdapter.Fill(this.CarteraGeneralDataSet.rptcomisionesxpagar);
                this.rptcomisionesxpagarTableAdapter.Adapter.SelectCommand.CommandText = "Select * From 006comisionxpagar Where TotalComision>0";
                this.rptcomisionesxpagarTableAdapter.Fill(this.CarteraGeneralDataSet.rptcomisionesxpagar);
                this.reportViewer1.RefreshReport();
            }
            catch {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
