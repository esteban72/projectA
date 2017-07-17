using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using CarteraGeneral.Modulo_Rbf.Reservas;

namespace CarteraGeneral
{
    public partial class FrmModuloReservasRbf : DevExpress.XtraEditors.XtraForm
    {
        public FrmModuloReservasRbf()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        string VarReserva,VarTipoSemana,VarIdInmueble;
        DataTable DtListado = new DataTable();
        private void FrmModuloReservasRbf_Load(object sender, EventArgs e)
        {            
            CnsReservas();            
            this.Text = "MODULO DE RESERVAS   USUARIO CONECTADO  " + FrmLogeo.Usuario.ToUpper();
            #region PERMISOS
            BtnAddPreferente.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnAddSistematica.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnDel.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, this.Tag.ToString());
            BtnDesistir.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "308");
            BtnAddRecaudos.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "401");
            BtnAdjudicar.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "301");  
            #endregion
            
        }

        private void CnsReservas()
        {
            CargarGrid();
        }       

        private void CargarGrid()
        {
            DtListado = conexion.MtdBuscarDataset("Select scrip from vistas where Vista='CnsReservas'");
            string strconsulta = DtListado.Rows[0]["scrip"].ToString();
            DtListado = conexion.MtdBuscarDataset(strconsulta);
            GrdTerceros.DataSource = DtListado;
        }
        private void BtnMod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarReserva == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Reserva ", "Modificar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmReservasPreferente frmDatosReservas = new FrmReservasPreferente();
                frmDatosReservas.EntradaReserva = 3;
                frmDatosReservas.VarIdReserva = VarReserva;
                frmDatosReservas.VarTipoSemana = VarTipoSemana;
                frmDatosReservas.VarIdInmueble = VarIdInmueble;
                frmDatosReservas.Show();
            }
        }

        private void BtnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             if (VarReserva == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Reserva ", "Eliminar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmReservasPreferente frmDatosReservas = new FrmReservasPreferente();
                frmDatosReservas.EntradaReserva = 5;
                frmDatosReservas.VarIdReserva = VarReserva;
                frmDatosReservas.VarTipoSemana = VarTipoSemana;
                frmDatosReservas.VarIdInmueble = VarIdInmueble;
                frmDatosReservas.Show();
            }
        }

        private void BtnConsultar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             if (VarReserva == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Reserva ", "Consultar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmReservasPreferente frmDatosReservas = new FrmReservasPreferente();
                frmDatosReservas.EntradaReserva = 4;
                frmDatosReservas.VarIdReserva = VarReserva;
                frmDatosReservas.VarTipoSemana = VarTipoSemana;
                frmDatosReservas.VarIdInmueble = VarIdInmueble;
                frmDatosReservas.Show();
            }
        }

        private void BtnAddPreferente_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmReservasPreferente frmDatosReservas = new FrmReservasPreferente();
            frmDatosReservas.EntradaReserva = 2;
            frmDatosReservas.VarTipoSemana = "PREFERENTE";
            frmDatosReservas.Show();
        }

        private void BtnAddSistematica_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmReservasPreferente frmDatosReservas = new FrmReservasPreferente();
            frmDatosReservas.EntradaReserva = 2;
            frmDatosReservas.VarTipoSemana = "SISTEMATICA";
            frmDatosReservas.Show();
        }

        private void BtnDesistir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (VarReserva == null)
            {
                MessageBox.Show("No Se Ha Seleccionado Reserva ", "Desistir Reservas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                FrmReservasPreferente frmDatosReservas = new FrmReservasPreferente();
                frmDatosReservas.EntradaReserva = 6;
                frmDatosReservas.VarIdReserva = VarReserva;
                frmDatosReservas.VarTipoSemana = VarTipoSemana;
                frmDatosReservas.VarIdInmueble = VarIdInmueble;
                frmDatosReservas.Show();
            }
        }

        private void BtnExportar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            conexion.impirmir(GrdTerceros, "MODULO DE RESERVAS");
        }

        private void BtnAddRecaudos_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (VarReserva == null)
            {
                MessageBox.Show("Seleccione Reserva", "Error Seleccione Reserva", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmRecaudoReserva frmRecaudoReserva = new FrmRecaudoReserva();
                frmRecaudoReserva.Show();
                //frmRecaudoReserva.VarIdentificacion = varidentificacion;
                    //negnoradicados.Show();
                               
                
            }
            
        
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarReserva = gridView1.GetFocusedRowCellValue("IdReserva").ToString();
            VarIdInmueble = gridView1.GetFocusedRowCellValue("IdInmueble").ToString();
            VarTipoSemana = gridView1.GetFocusedRowCellValue("TipoSemana").ToString();
        }

        private void FrmModuloReservasRbf_Activated(object sender, EventArgs e)
        {
            CargarGrid();
        }
        
        
    }
}