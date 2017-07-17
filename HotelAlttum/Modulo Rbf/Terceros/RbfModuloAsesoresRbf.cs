using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CarteraGeneral.Modulo_Rbf.Terceros
{
    public partial class RbfModuloAsesoresRbf : DevExpress.XtraEditors.XtraForm
    {
        public RbfModuloAsesoresRbf()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        string VarIdTerceros;
        string Sentencia = "select IdTercero,NombreCompleto,Direccion,Ciudad,Telefono1,Telefono2,Celular,Email From Contabilidad_alttum.Terceros Where TipoTercero='Gestor'";

        private void RbfModuloAsesoresRbf_Load(object sender, EventArgs e)
        {
            GrdTerceros.DataSource = conexion.MtdBuscarDataset(Sentencia);
            this.Text = "MODULO DE ASESORES   USUARIO CONECTADO  " + FrmLogeo.Usuario.ToUpper();
            BtnAdd.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnDel.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            
        }

        private void BtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmGestor frmGestor = new FrmGestor();
            frmGestor.EntradaTerceros = 2;
            frmGestor.Show();
        }

        private void BtnMod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdTerceros == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Tercero ", "Modificar Asesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmGestor frmGestor = new FrmGestor();
                frmGestor.EntradaTerceros = 3;
                frmGestor.VarIdTerceros = VarIdTerceros;
                frmGestor.Show();
            }
        }

        private void BtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdTerceros == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Tercero ", "Eliminar Asesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmGestor frmGestor = new FrmGestor();
                frmGestor.EntradaTerceros = 4;
                frmGestor.VarIdTerceros = VarIdTerceros;
                frmGestor.Show();
            }
        }

        private void BtnConsultar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdTerceros == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Tercero ", "Consultar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmGestor frmGestor = new FrmGestor();
                frmGestor.EntradaTerceros = 5;
                frmGestor.VarIdTerceros = VarIdTerceros;
                frmGestor.Show();
            }
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarIdTerceros = gridView1.GetFocusedRowCellValue("IdTercero").ToString();
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            conexion.impirmir(GrdTerceros, "MODULO DE ASESORES");
        }
    }
}