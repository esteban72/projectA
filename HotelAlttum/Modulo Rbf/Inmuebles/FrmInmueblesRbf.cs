using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace CarteraGeneral.Modulo_Rbf.Inmuebles
{
    public partial class FrmInmueblesRbf : DevExpress.XtraEditors.XtraForm
    {
        public FrmInmueblesRbf()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        string VarIdInmueble;
        private void FrmInmueblesRbf_Load(object sender, EventArgs e)
        {
            GrdTerceros.DataSource = conexion.MtdBuscarDataset(RscAdjudicacion.CnsInmuebles);
            this.Text = "MODULO DE INMUEBLES   USUARIO CONECTADO  " + FrmLogeo.Usuario.ToUpper();
            BtnAdd.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnDel.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarIdInmueble = gridView1.GetFocusedRowCellValue("IdInmueble").ToString();
        }

        private void BtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmInmuebles inmuebles = new FrmInmuebles();
            inmuebles.EntradaInmuebles = "Adicionar";
            inmuebles.ShowDialog();
        }

        private void BtnMod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdInmueble == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Inmueble ", "Modificar Inmueble", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmInmuebles inmuebles = new FrmInmuebles();
                inmuebles.EntradaInmuebles = "Modificar";
                inmuebles.VarIdInmueble = VarIdInmueble;
                inmuebles.ShowDialog();
            }
        }

        private void BtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdInmueble == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Inmueble ", "Eliminar Inmueble", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmInmuebles inmuebles = new FrmInmuebles();
                inmuebles.EntradaInmuebles = "Eliminar";
                inmuebles.VarIdInmueble = VarIdInmueble;
                inmuebles.ShowDialog();
            }
        }

        private void BtnConsultar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdInmueble == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Inmueble ", "Consultar Inmueble", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmInmuebles inmuebles = new FrmInmuebles();
                inmuebles.EntradaInmuebles = "Consultar";
                inmuebles.VarIdInmueble = VarIdInmueble;
                inmuebles.ShowDialog();
            }
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            conexion.impirmir(GrdTerceros, "MODULO DE INMUEBLES");
        }
    }
}