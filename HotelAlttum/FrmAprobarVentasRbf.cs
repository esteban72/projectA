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
    public partial class FrmAprobarVentasRbf : DevExpress.XtraEditors.XtraForm
    {
        public FrmAprobarVentasRbf()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        string VarIdAdjudicacion, VarTipoOperacion;
        string Sentencia = "select  a.IdAdjudicacion,a.IdTercero1,t.NombreCompleto Cliente,a.Fecha,a.Contrato,a.IdInmueble,a.TipodeAdjudicacion,a.Temporada,upper(a.Grado)Grado," +
       "a.Valor,Upper(a.Estado)Estado,TipoOperacion From Adjudicacion a Left join  Contabilidad_alttum.Terceros t on t.IdTercero=a.IdTercero1 Where a.Estado='Pendiente' Order By IdADjudicacion";
        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarIdAdjudicacion = gridView1.GetFocusedRowCellValue("IdAdjudicacion").ToString();
            VarTipoOperacion = gridView1.GetFocusedRowCellValue("TipoOperacion").ToString();
        }

        private void BtnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Aprobar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (VarTipoOperacion == "Monterey")
                {
                    RbfAdjudicacion adjudicacion = new RbfAdjudicacion();
                    adjudicacion.EntradaAdjudicacion = "Aprobar";
                    adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                    adjudicacion.Show();
                }
                else
                {
                    FrmAdjudicacion adjudicacion = new FrmAdjudicacion();
                    adjudicacion.EntradaAdjudicacion = "Aprobar";
                    adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                    adjudicacion.Show();
                }
            }
        }

        private void FrmAprobarVentasRbf_Load(object sender, EventArgs e)
        {
            this.Text = "APROBACION DE ADJUDICACION USUARIO: " + FrmLogeo.Usuario.ToUpper();
            BtnAprobar.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "306");
            gridControl1.DataSource = conexion.MtdBuscarDataset(Sentencia);
        }

        private void BtnConsultar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Consultar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                FrmAdjudicacion adjudicacion = new FrmAdjudicacion();
                adjudicacion.EntradaAdjudicacion = "Consultar";
                adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                adjudicacion.Show();
            }
        }

        private void BtnSalir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }
    }
}