using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace CarteraGeneral.Modulo_Rbf.Terceros
{
    public partial class FrmModuloTercerosRbf : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmModuloTercerosRbf()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        string VarIdTerceros;
        string Sentencia = "select IdTercero,NombreCompleto,Direccion,Ciudad,Telefono1,Telefono2,Celular,Email From Contabilidad_alttum.Terceros Where TipoTercero='Clientes'";
        private void FrmModuloTercerosRbf_Load(object sender, EventArgs e)
        {
            GrdTerceros.DataSource= conexion.MtdBuscarDataset(Sentencia);
            this.Text = "MODULO DE TERCEROS   USUARIO CONECTADO  " + FrmLogeo.Usuario.ToUpper();
            BtnAdd.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnDel.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarIdTerceros = gridView1.GetFocusedRowCellValue("IdTercero").ToString();
        }

        private void BtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTerceros frmClientes = new FrmTerceros();
            frmClientes.Text = "Adicionar Clientes";
            frmClientes.LblTitulo.Text = "Adicionar Clientes";
            frmClientes.EntradaTerceros = 2;
            frmClientes.Show();
        }

        private void BtnMod_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdTerceros == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Tercero ", "Modificar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmTerceros frmClientes = new FrmTerceros();
                frmClientes.EntradaTerceros = 3;
                frmClientes.Text = "Modificar Clientes";
                frmClientes.LblTitulo.Text = "Modificar Clientes";
                frmClientes.VarIdTerceros = VarIdTerceros;
                frmClientes.Show();
            }
        }

        private void BtnDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdTerceros == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Tercero ", "Eliminar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmTerceros frmClientes = new FrmTerceros();
                frmClientes.EntradaTerceros = 4;
                frmClientes.Text = "Eliminar Clientes";
                frmClientes.LblTitulo.Text = "Eliminar Clientes";
                frmClientes.VarIdTerceros = VarIdTerceros;
                frmClientes.Show();
            }
        }

        private void BtnConsultar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdTerceros == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Tercero ", "Consultar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmTerceros frmClientes = new FrmTerceros();
                frmClientes.EntradaTerceros = 5;
                frmClientes.Text = "Consultar Clientes";
                frmClientes.LblTitulo.Text = "Consultar Clientes";
                frmClientes.VarIdTerceros = VarIdTerceros;
                frmClientes.Show();
            }
        }

        private void BtnExportar_ItemClick(object sender, ItemClickEventArgs e)
        {
            conexion.impirmir(GrdTerceros, "MODULO DE CLIENTES");
        }
    }
}