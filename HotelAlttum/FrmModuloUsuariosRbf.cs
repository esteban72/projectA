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
    public partial class FrmModuloUsuariosRbf : DevExpress.XtraEditors.XtraForm
    {
        public FrmModuloUsuariosRbf()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        string SentenciaDatos = "Select IdUsuario, NombreUsuario From Usuario Where Estado='Vigente'";
        string VarIdUsuario, VarNombreUsuario;
        private void FrmModuloUsuariosRbf_Load(object sender, EventArgs e)
        {
            this.Text = "MODULO DE USUARIOS  USUARIO CONECTADO: " + FrmLogeo.Usuario;
            BtnAdd.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "902");
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, "902");
            BtnDel.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, "902");
            GrdTerceros.DataSource = conexion.MtdBuscarDataset(SentenciaDatos);
        }

        private void BtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Permisos permiso = new Permisos();
            permiso.EntradaPermisos = "Adicionar";
            permiso.ShowDialog();
        }

        private void BtnMod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdUsuario == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Usuario ", "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Permisos permiso = new Permisos();
                permiso.EntradaPermisos = "Modificar";
                permiso.VarIdUsuario = VarIdUsuario;
                permiso.VarNombreUsuario = VarNombreUsuario;
                permiso.ShowDialog();
            }
        }

        private void BtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdUsuario == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Usuario ", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Permisos permiso = new Permisos();
                permiso.EntradaPermisos = "Eliminar";
                permiso.VarIdUsuario = VarIdUsuario;
                permiso.VarNombreUsuario = VarNombreUsuario;
                permiso.ShowDialog();
            }
        }

        private void BtnConsultar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdUsuario == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Usuario ", "Consultar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Permisos permiso = new Permisos();
                permiso.EntradaPermisos = "Consultar";
                permiso.VarIdUsuario = VarIdUsuario;
                permiso.VarNombreUsuario = VarNombreUsuario;
                permiso.ShowDialog();
            }
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            conexion.impirmir(GrdTerceros, "MODULO DE USUARIOS");
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarIdUsuario = gridView1.GetFocusedRowCellValue("IdUsuario").ToString();
            VarNombreUsuario = gridView1.GetFocusedRowCellValue("NombreUsuario").ToString();
        }
    }
}