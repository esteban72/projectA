using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace CarteraGeneral
{
    public partial class FrmCnsSaldoFondo : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmCnsSaldoFondo()
        {
            InitializeComponent();
        }
        DataTable DtAsesores = new DataTable();
        DataTable DtDatos = new DataTable();
        ClsIdentificacion conexion = new ClsIdentificacion();
        private void FrmCnsSaldoFondo_Load(object sender, EventArgs e)
        {
            DtAsesores = conexion.MtdBuscarDataset(MisConsultas.SaldoFondosMonterey);
            RpsAsesores.DataSource = DtAsesores.AsDataView();
            RpsAsesores.DisplayMember = DtAsesores.DataSet.Tables[0].Columns[1].ToString();
            RpsAsesores.ValueMember = DtAsesores.DataSet.Tables[0].Columns[0].ToString();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            DtDatos = conexion.MtdBuscarDataset(MisConsultas.CnsMovimientoFondosxIdGestor, CmbAsesor.EditValue.ToString());
            gridControl1.DataSource = DtDatos;
        }
    }
}