using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid;

namespace CarteraGeneral
{
    public partial class FrmCnsPagoPorClientesRbf : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmCnsPagoPorClientesRbf()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        DataTable DtAdj = new DataTable();
        DataTable DtComsiones = new DataTable();
        private void barEditItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void FrmCnsPagoPorClientesRbf_Load(object sender, EventArgs e)
        {
            MtdColumna();
        }
        private void MtdColumna()
        {

            gridView1.GroupSummary.Clear();

            gridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;

            Lqd1.DisplayFormat.FormatType = FormatType.Numeric;
            Lqd1.DisplayFormat.FormatString = "n";

            Lqd2.DisplayFormat.FormatType = FormatType.Numeric;
            Lqd2.DisplayFormat.FormatString = "n";

            Lqd3.DisplayFormat.FormatType = FormatType.Numeric;
            Lqd3.DisplayFormat.FormatString = "n";

            PagoComision.DisplayFormat.FormatType = FormatType.Numeric;
            PagoComision.DisplayFormat.FormatString = "n";

            Retencion.DisplayFormat.FormatType = FormatType.Numeric;
            Retencion.DisplayFormat.FormatString = "n";

            PagoNeto.DisplayFormat.FormatType = FormatType.Numeric;
            PagoNeto.DisplayFormat.FormatString = "n";



            gridView1.Columns["Lqd1"].Summary.Clear();
            gridView1.Columns["Nombres"].Summary.Add(DevExpress.Data.SummaryItemType.Count, "Nombres", "Cant={0:n0}");
            gridView1.Columns["Lqd1"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Lqd1", "Total={0:n2}");
            gridView1.Columns["Lqd2"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Lqd2", "Total={0:n2}");
            gridView1.Columns["Lqd3"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Lqd3", "Total={0:n2}");
            gridView1.Columns["PagoComision"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "PagoComision", "Total={0:n2}");
            gridView1.Columns["Retencion"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Retencion", "Total={0:n2}");
            gridView1.Columns["PagoNeto"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "PagoNeto", "Total={0:n2}");
        }
        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TxtIdAdjudicacion.EditValue != null)
            {
                this.Cursor = Cursors.WaitCursor;
                DtComsiones = conexion.MtdBuscarDataset(MisConsultas.ComisionesPorPagarPorAdj, TxtIdAdjudicacion.EditValue.ToString());
                GrdConsulta.DataSource = DtComsiones;

                this.Cursor = Cursors.Default;
            }
        }

        private void BtnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (DtComsiones.Rows.Count > 0)
            {
                this.Cursor = Cursors.WaitCursor;
                string Cliente = DtComsiones.Rows[0]["Cliente"].ToString();
                string Basecom = DtComsiones.Rows[0]["BaseRecaudo"].ToString();


                conexion.impirmir1(GrdConsulta,
                    "RELACION DE PAGOS POR CLIENTES \n CLIENTE:    " + Cliente.ToUpper() +
                    "\n ADJUDICACION:  " + TxtIdAdjudicacion.EditValue.ToString() + "\n BASE DE COMISION:  " + Basecom +
                    "\n FECHA:  " + DateTime.Now.ToShortDateString());
                this.Cursor = Cursors.Default;
            }
        }
    } }
