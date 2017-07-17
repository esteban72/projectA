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


namespace CarteraGeneral
{
    public partial class FrmModuloRecaudosRbf : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmModuloRecaudosRbf()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        string VarIdAdjudicacion, VarEstado, VarIdInmueble, VarCliente, VarTipoOperacion;
        
        private void FrmModuloRecaudosRbf_Load(object sender, EventArgs e)
        {
            this.Text = "MODULO DE REACUOS USUARIO CONECTADO: " + FrmLogeo.Usuario.ToUpper();
            GrdCartera.DataSource = conexion.MtdBuscarDataset(RscRecaudos.DatosAdjudicacion);
            BtnAdd.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "401");            
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, "401");
            BtnDel.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, "401");          
            BtnAddOtrosi.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "407");
          
        }


        private void BtnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Adicionar Recaudo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            {
                FrmFuenteRecibo frmFuenteManual = new FrmFuenteRecibo();
                FrmRecaudoPorCuotas frmRecaudoPorCuotas = new FrmRecaudoPorCuotas();


                frmFuenteManual.ShowDialog();
                string strpres = FrmFuenteRecibo.botonpresionado;
                string strfuente = FrmFuenteRecibo.strfuente;

                if (strpres == "ACEPTAR")
                {

                    frmRecaudoPorCuotas.EntradaRecaudos = 2;
                    frmRecaudoPorCuotas.tipor = strfuente;
                    frmRecaudoPorCuotas.VarIdAdjudicacion = VarIdAdjudicacion;
                    frmRecaudoPorCuotas.Show();
                  
                }
                FrmFuenteRecibo.botonpresionado = "";
                FrmFuenteRecibo.strfuente = "";   
               
            }
        }

        private void BtnMod_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Modificar Recaudo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmModificarRecaudos frmModRecaudos = new FrmModificarRecaudos();
                frmModRecaudos.VarIdAdjudicacion = VarIdAdjudicacion;
                frmModRecaudos.VarCliente = VarCliente;
                frmModRecaudos.VarIdInmueble = VarIdInmueble;
                frmModRecaudos.EntradaRecaudos = 3;
                frmModRecaudos.Show();
            }
        }

        private void BtnDel_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Eliminar Recaudo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmModificarRecaudos frmModRecaudos = new FrmModificarRecaudos();
                frmModRecaudos.VarIdAdjudicacion = VarIdAdjudicacion;
                frmModRecaudos.VarCliente = VarCliente;
                frmModRecaudos.VarIdInmueble = VarIdInmueble;
                frmModRecaudos.EntradaRecaudos = 4;
                frmModRecaudos.Show();
            }
        }

        private void BtnAnular_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRecaudoPorCuotas frmRecaudoPorCuotas = new FrmRecaudoPorCuotas();
            frmRecaudoPorCuotas.EntradaRecaudos = 11;
            frmRecaudoPorCuotas.Show();
        }

        private void BtnAddOtrosi_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Adicionar Otrosi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmOtrosi otrosi = new FrmOtrosi();
                otrosi.EntradaOtrosi = "Adicionar";
                otrosi.VarIdAdjudicacion = VarIdAdjudicacion;
                otrosi.ShowDialog();
            }
        }

        private void BtnExtracto_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Extracto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmExtracto frmextracto = new FrmExtracto();
                frmextracto.Opciones = "Automatico";
                frmextracto.VarIdAdjudicacion = VarIdAdjudicacion;
                frmextracto.VarCliente = VarCliente;
                frmextracto.Show();
            }
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
           if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Recaudos Detalados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            else
            {
                FrmCnsRecaudos frmCnsRecaudos = new FrmCnsRecaudos();
                frmCnsRecaudos.VarIdInmueble = VarIdInmueble;
                frmCnsRecaudos.VarIdAdjudicacion = VarIdAdjudicacion;
                frmCnsRecaudos.VarCliente = VarCliente;
                frmCnsRecaudos.ShowDialog();
            }
        }

        private void BtnRsmCredito_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (VarIdAdjudicacion == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Adjudicacion ", "Resumen Credito", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmCnsGralCredito frmDesistimiento = new FrmCnsGralCredito();
                frmDesistimiento.VarIdAdjudicacion = VarIdAdjudicacion;
                frmDesistimiento.Text = "Consulta General De Credito";

                frmDesistimiento.Show();
            }
        }

        private void BtnRecaudosFecha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCnsRcdFecha recaudosfecha = new FrmCnsRcdFecha();
            recaudosfecha.Show();   
        }

        private void gridView1_CustomRowCellEditForEditing_1(object sender, CustomRowCellEditEventArgs e)
        {
            VarIdAdjudicacion = gridView1.GetFocusedRowCellValue("IdAdjudicacion").ToString();
            VarEstado = gridView1.GetFocusedRowCellValue("Estado").ToString();
            VarCliente = gridView1.GetFocusedRowCellValue("Cliente").ToString();
            VarIdInmueble = gridView1.GetFocusedRowCellValue("IdInmueble").ToString();
            VarTipoOperacion = gridView1.GetFocusedRowCellValue("TipoOperacion").ToString();
        }
    }
}