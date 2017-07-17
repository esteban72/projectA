using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CarteraGeneral
{
    public partial class FrmModuloRadicacionRbf : DevExpress.XtraEditors.XtraForm
    {
        public FrmModuloRadicacionRbf()
        {
            InitializeComponent();
        }
        string VarIdAdjudicacion, VarEstado;
        ClsIdentificacion conexion = new ClsIdentificacion();
        
   
        private void FrmModuloRadicacionRbf_Load(object sender, EventArgs e)
        {
            BtnModOtrosi.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "801");
            this.Text = "MODULO DE RADICACION USUARIO CONECTADO: " + FrmLogeo.Usuario.ToUpper();
            gridControl1.DataSource = conexion.MtdBuscarDataset(RscAdjudicacion.CnsRadicaciones);

        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarIdAdjudicacion = gridView1.GetFocusedRowCellValue("IdAdjudicacion").ToString();
            VarEstado = gridView1.GetFocusedRowCellValue("Estado").ToString();
        }

        private void BtnAddRadicacion_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Radicar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmRadicacion radicacion = new FrmRadicacion();
                radicacion.EntradaRadicacion = "Adicionar";
                radicacion.VarIdajudicacion = VarIdAdjudicacion;
                BtnModOtrosi.Enabled = false;
                BtnImprimir.Enabled = false;
                radicacion.ShowDialog();
            }
        }

        private void BtnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            conexion.impirmir(gridControl1, "MODULO DE RADICACION");
        }

        private void BtnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BtnModOtrosi.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "801");
            this.Text = "MODULO DE RADICACION USUARIO CONECTADO: " + FrmLogeo.Usuario.ToUpper();
            gridControl1.DataSource = conexion.MtdBuscarDataset(RscAdjudicacion.CnsRadicaciones);
            BtnModOtrosi.Enabled = true;
            BtnImprimir.Enabled = true;
        }
    }
}