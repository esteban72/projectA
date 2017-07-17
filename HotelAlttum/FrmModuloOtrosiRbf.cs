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
    public partial class FrmModuloOtrosiRbf : DevExpress.XtraEditors.XtraForm
    {
        public FrmModuloOtrosiRbf()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        string VarIdAdjudicacion, VarIdOtrosi;

        private void FrmModuloOtrosiRbf_Load(object sender, EventArgs e)
        {
            this.Text = "MODULO DE OTROS USUARIO CONECTADO :" + FrmLogeo.Usuario.ToUpper();
            BtnModOtrosi.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, "407");
            BtnDelOtrosi.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, "407");
            BtnAprobarOtrosi.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "307");
            GrdOtrosi.DataSource = conexion.MtdBuscarDataset(RscAdjudicacion.OtrsisPendientes);
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarIdAdjudicacion = gridView1.GetFocusedRowCellValue("IdAdjudicacion").ToString();
            VarIdOtrosi = gridView1.GetFocusedRowCellValue("IdOtrosi").ToString();
        }

        private void BtnModOtrosi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Modificar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
             else
            {
                FrmOtrosi otrosi = new FrmOtrosi();
                otrosi.EntradaOtrosi = "Modificar";
                otrosi.VarIdAdjudicacion = VarIdAdjudicacion;
                otrosi.VarIdOtrosi = VarIdOtrosi;
                otrosi.ShowDialog();
            }
        }

        private void BtnDelOtrosi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Eliminar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmOtrosi otrosi = new FrmOtrosi();
                otrosi.EntradaOtrosi = "Eliminar";
                otrosi.VarIdAdjudicacion = VarIdAdjudicacion;
                otrosi.VarIdOtrosi = VarIdOtrosi;
                otrosi.ShowDialog();
            }
        }
        
        private void BtnAprobarOtrosi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Aprobar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmOtrosi otrosi = new FrmOtrosi();
                otrosi.EntradaOtrosi = "Aprobar";
                otrosi.VarIdAdjudicacion = VarIdAdjudicacion;
                otrosi.VarIdOtrosi = VarIdOtrosi;
                otrosi.ShowDialog();
            }
        }

        private void BtnImprimir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            conexion.impirmir(GrdOtrosi, "MODULO DE OTROSI");
        }

        private void BtnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}