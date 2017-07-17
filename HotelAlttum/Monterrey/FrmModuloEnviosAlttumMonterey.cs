using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.LookAndFeel;

namespace CarteraGeneral
{
    public partial class FrmModuloEnviosAlttumMonterey : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmModuloEnviosAlttumMonterey()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        string VarIdLote;
        private void FrmModuloEnviosMonterey_Load(object sender, EventArgs e)
        {
            #region PERMISOS
            BtnAdd.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "414");
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, "414");
            #endregion

            GrdEnvios.DataSource = conexion.MtdBuscarDataset(MisConsultas.CnsEnviosAltumMonterey);
            MtdColumna();

        }

        private void BtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmEnviosNormal envio = new FrmEnviosNormal();
            envio.Entrada = "Adicionar";
            envio.Show();
        }

        private void BtnMod_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdLote == null)
            {
                MessageBox.Show("No Se Ha Seleccionado lote a modificar", "Modificar Envio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmEnviosMonterey envio = new FrmEnviosMonterey();
                envio.Entrada = "Modificar";
                envio.VarIdLote = VarIdLote;
                envio.Show();
            }
        }

        private void BtnDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void MtdColumna()
        {
          ValorContrato.DisplayFormat.FormatType = FormatType.Numeric;
          ValorContrato.DisplayFormat.FormatString = "n";

            

            gridView1.GroupSummary.Clear();
            gridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;


            GridGroupSummaryItem Cuota = new GridGroupSummaryItem();
            Cuota.FieldName = "ValorContrato";
            Cuota.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Cuota.DisplayFormat = "Subtotal {0:n}";
            Cuota.ShowInGroupColumnFooter = ValorContrato;
            gridView1.GroupSummary.Add(Cuota);

            GridGroupSummaryItem IdAdj = new GridGroupSummaryItem();
            IdAdj.FieldName = "IdAdjudicacion";
            IdAdj.SummaryType = DevExpress.Data.SummaryItemType.Count;
            IdAdj.DisplayFormat = "Cant {0:n0}";
            IdAdj.ShowInGroupColumnFooter = IdAdjudicacion;
            gridView1.GroupSummary.Add(IdAdj);



            gridView1.Columns["ValorContrato"].Summary.Clear();
            gridView1.Columns["IdAdjudicacion"].Summary.Add(DevExpress.Data.SummaryItemType.Count, "IdAdjudicacion", "Cant={0:n0}");
            gridView1.Columns["ValorContrato"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ValorContrato", "Total={0:n2}");
        }

        private void BtnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            conexion.impirmir(GrdEnvios, "RELACION ENVIOS A MONTEREY");
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            VarIdLote = gridView1.GetFocusedRowCellValue("IdLote").ToString();
        }

        private void skinRibbonGalleryBarItem1_GalleryPopupClose(object sender, DevExpress.XtraBars.Ribbon.InplaceGalleryEventArgs e)
        {
            {
                conexion.MtdAddSentencia("update usuario set tema= '" + UserLookAndFeel.Default.SkinName.ToString() + "' where idusuario = '" + FrmLogeo.Usuario + "'");
            }
        }
    }
}