using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.Xpf.Core;
using System.Windows;

namespace CarteraGeneral
{
    public partial class FrmCumplimientoPresupuesto : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmCumplimientoPresupuesto()
        {
            InitializeComponent();
        }
        Presupuesto miPresupuesto = new Presupuesto();
        ClsIdentificacion conexion = new ClsIdentificacion();
        private void BtnConsultaa_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (CmbMes.EditValue == null || CmbAño.EditValue == null)
            {
                DXMessageBox.Show("Falta Campo Mes o Año", "Consulta Presupuesto", MessageBoxButton.OK, MessageBoxImage.Question);
            }
            else
            {
                this.Cursor = Cursors.WaitCursor;
               BtnConsultaa.Enabled = false;
                gridControl1.DataSource = miPresupuesto.MtdCnsCumplimientoPresupuestoMeta(CmbAño.EditValue.ToString(), CmbMes.EditValue.ToString());
                this.Cursor = Cursors.Default;
                BtnConsultaa.Enabled = true;
            }
        }

        private void FrmCumplimientoPresupuesto_Load(object sender, EventArgs e)
        {
            this.Text = "CUMPLIMIENTO DEL PRESUPUESTO USUARIO CONECTADO :" + FrmLogeo.Usuario.ToUpper();
            miPresupuesto.MtdListaMeses();

            for (int i = 0; i < miPresupuesto.ListaMes.Count; i++)
            {
                RpsMes.Items.Add(miPresupuesto.ListaMes[i].ToString());
            }
           
            RpsAno.Items.Add("2015");
            RpsAno.Items.Add("2016");
            RpsAno.Items.Add("2017");
            RpsAno.Items.Add("2018");
        }

        private void BtnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
       conexion.impirmir(gridControl1, "INFORME CUMPLIMIENTO DEL PRESUPUESTO \n DEL AÑO "+ CmbAño.EditValue.ToString()+ " MES DE" +CmbMes.EditValue.ToString().ToUpper());
        }

    
    }
}