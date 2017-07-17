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
using CarteraGeneral.Modulo_Rbf.Adjudicacion;

namespace CarteraGeneral
{
    public partial class FrmModuloAdjudicacionRbf : DevExpress.XtraBars.Ribbon.RibbonForm
    {
       
        public FrmModuloAdjudicacionRbf()
        {
            InitializeComponent();
          
        }
        string VarIdAdjudicacion, VarEstado, VarIdInmueble, VarCliente, VarTipoOperacion;
        ClsIdentificacion conexion = new ClsIdentificacion();
     
        private void FrmModuloAdjudicacionRbf_Load(object sender, EventArgs e)
        {
            this.Text="MODULO DE ADJUDICACION  USUARIO : " +FrmLogeo.Usuario.ToUpper();
            gridControl1.DataSource = conexion.MtdBuscarDataset(RscRecaudos.DatosAdjudicacionesTodas);
            BtnAddMonterey.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "301");
            BtnAdd.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "301");
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, "301");
            BtnDel.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, "301");
            BtnDesistir.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "303");
            BtnCambiarBase.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "907");
            MtdColumna();
        }

        private void MtdColumna()
        {

            gridView1.GroupSummary.Clear();
            gridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            Valor.DisplayFormat.FormatType = FormatType.Numeric;
            Valor.DisplayFormat.FormatString = "n";



            gridView1.GroupSummary.Clear();
            gridView1.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;
            GridGroupSummaryItem Cuota = new GridGroupSummaryItem();
            Cuota.FieldName = "Valor";
            Cuota.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            Cuota.DisplayFormat = "Subtotal {0:n0}";
            Cuota.ShowInGroupColumnFooter = Valor;
            gridView1.GroupSummary.Add(Cuota);

            GridGroupSummaryItem Idadj = new GridGroupSummaryItem();
            Idadj.FieldName = "IdAdjudicacion";
            Idadj.SummaryType = DevExpress.Data.SummaryItemType.Count;
            Idadj.DisplayFormat = "Cant {0:n0}";
            Idadj.ShowInGroupColumnFooter = IdAdjudicacion;
            gridView1.GroupSummary.Add(Idadj);

            gridView1.Columns["Valor"].Summary.Clear();
            gridView1.Columns["IdAdjudicacion"].Summary.Add(DevExpress.Data.SummaryItemType.Count, "IdAdjudicacion", "Cant={0:n0}");
            gridView1.Columns["Valor"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Valor", "Total={0:n2}");
        }
        private void BtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAdjudicacion adjudicacion = new FrmAdjudicacion();
            adjudicacion.EntradaAdjudicacion = "Adicionar";
            adjudicacion.Show();
        }

        private void BtnMod_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion a modificar", "Modificar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (VarEstado == "PENDIENTE" && VarTipoOperacion == "Normal")
                {
                    FrmAdjudicacion adjudicacion = new FrmAdjudicacion();
                    adjudicacion.EntradaAdjudicacion = "Modificar";
                    adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                    adjudicacion.Show();
                }
                else
                    if (VarEstado == "PENDIENTE" && VarTipoOperacion == "Monterey")
                    {
                        RbfAdjudicacion adjudicacion = new RbfAdjudicacion();
                        adjudicacion.EntradaAdjudicacion = "Modificar";
                        adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                        adjudicacion.Show();
                    }
                    else
                    {
                        MessageBox.Show("Registro No se Puede Modificar su Estado actual es :" + VarEstado, "Cambiar Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void BtnDel_ItemClick(object sender, ItemClickEventArgs e)
        {


            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion a Eliminar", "Eliminar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (VarEstado == "PENDIENTE" && VarTipoOperacion == "Normal")
                {
                    FrmAdjudicacion adjudicacion = new FrmAdjudicacion();
                    adjudicacion.EntradaAdjudicacion = "Eliminar";
                    adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                    adjudicacion.Show();
                }
                else
                    if (VarEstado == "PENDIENTE" && VarTipoOperacion == "Monterey")
                    {
                        RbfAdjudicacion adjudicacion = new RbfAdjudicacion();
                        adjudicacion.EntradaAdjudicacion = "Eliminar";
                        adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                        adjudicacion.Show();
                    }

                    else
                    {
                        MessageBox.Show("Registro No se Puede Eliminar Su Estado Actual es :" + VarEstado, "Eliminar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void BtnCambiarBase_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarEstado == "APROBADO")
            {
                FrmModDatosAdj adjudicacion = new FrmModDatosAdj();
                adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                adjudicacion.ShowDialog();
            }
            else
            {
                MessageBox.Show("Registro No se Puede Cambiar Base Su Estado Actual es :" + VarEstado, "Cambiar Base", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDesistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion a Desistir", "Desistir Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (VarEstado == "APROBADO" && VarTipoOperacion == "Normal")
                {
                    FrmAdjudicacion adjudicacion = new FrmAdjudicacion();
                    adjudicacion.EntradaAdjudicacion = "Desistir";
                    adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                    adjudicacion.Show();
                }
                else
                    if (VarEstado == "APROBADO" && VarTipoOperacion == "Monterey")
                    {
                        RbfAdjudicacion adjudicacion = new RbfAdjudicacion();
                        adjudicacion.EntradaAdjudicacion = "Desistir";
                        adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                        adjudicacion.Show();
                    }
                    else
                    {
                        MessageBox.Show("Registro No se Puede Desistir su Estado actual es :" + VarEstado, "Desistir Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion a Consultar", "Consultar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (VarEstado == "APROBADO" && VarTipoOperacion == "Normal")
                {
                    FrmAdjudicacion adjudicacion = new FrmAdjudicacion();
                    adjudicacion.EntradaAdjudicacion = "Consultar";
                    adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                    adjudicacion.Show();
                }
                else
                    if (VarEstado == "APROBADO" && VarTipoOperacion == "Monterey")
                {
                    RbfAdjudicacion adjudicacion = new RbfAdjudicacion();
                    adjudicacion.EntradaAdjudicacion = "Consultar";
                    adjudicacion.VarIdajudicacion = VarIdAdjudicacion;
                    adjudicacion.Show();
                }

            }
        }

        private void BtnRecaudoDetallado_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion a Consultar", "Consultar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmCnsRecaudos frmCnsRecaudos = new FrmCnsRecaudos();
                frmCnsRecaudos.VarIdInmueble = VarIdInmueble;
                frmCnsRecaudos.VarIdAdjudicacion = VarIdAdjudicacion;
                frmCnsRecaudos.VarCliente = VarCliente;
                frmCnsRecaudos.Show();

            }
        }

        private void BtnRsmCredito_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion a Consultar", "Consultar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmCnsGralCredito frmDesistimiento = new FrmCnsGralCredito();
                frmDesistimiento.VarIdAdjudicacion = VarIdAdjudicacion;
                frmDesistimiento.Text = "Consulta General De Credito";
                frmDesistimiento.Show();

            }
        }

        private void BtnSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void BtnAddMonterey_ItemClick(object sender, ItemClickEventArgs e)
        {
            RbfAdjudicacion Adj = new RbfAdjudicacion();
            Adj.EntradaAdjudicacion = "Adicionar";
            Adj.Show();
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarIdAdjudicacion = gridView1.GetFocusedRowCellValue("IdAdjudicacion").ToString();
            VarEstado = gridView1.GetFocusedRowCellValue("Estado").ToString();
            VarCliente = gridView1.GetFocusedRowCellValue("Cliente").ToString();
            VarIdInmueble = gridView1.GetFocusedRowCellValue("IdInmueble").ToString();
            VarTipoOperacion = gridView1.GetFocusedRowCellValue("TipoOperacion").ToString();
        }

        private void BtnAddMonterey_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            RbfAdjudicacion Adj = new RbfAdjudicacion();
            Adj.EntradaAdjudicacion = "Adicionar";
            Adj.Show();
        }

        private void BtnExportar_ItemClick(object sender, ItemClickEventArgs e)
        {
            conexion.impirmir(gridControl1, "MODULO DE INMUEBLES");
        }

        private void btnPIV_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAdjudicacionPIV adjudicacion = new FrmAdjudicacionPIV();
            adjudicacion.EntradaAdjudicacion = "AdicionarPIV";
            adjudicacion.Show();
        }
    }
}