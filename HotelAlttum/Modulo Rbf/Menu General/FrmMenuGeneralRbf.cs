﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.LookAndFeel;
using CarteraGeneral.Modulo_Rbf.Terceros;
using CarteraGeneral.Modulo_Rbf.Inmuebles;
using CarteraGeneral.Modulo_Rbf.Comision;

namespace CarteraGeneral
{
    public partial class FrmMenuGeneralRbf : DevExpress.XtraBars.Ribbon.RibbonForm
    {
  
        public FrmMenuGeneralRbf()
        {
            InitializeComponent();
        }

         ClsIdentificacion conexion = new ClsIdentificacion();
        private void FrmMenuGeneralRbf_Load(object sender, EventArgs e)
        {
            BtnParametros.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "904");
            BtnTablaComision.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "905");
            BtnAprobarVentas.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "306");
            BtnModComisionTabla.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "503");
            BtnCondonar.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "402");
            BtnCambioConsecutivo.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "906");
            BtnPagados.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "601");
            BtnTramiteEscritura.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "602");
            BtnEscriturados.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "603");
            BtnArchivados.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "604");
            BtnJuridico.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "602");
            BtnDesistidoJuridico.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "605");
            BtnJuridicosVigentes.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "701");
            BtnJuridicosDesistidos.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "701");

            #region MONTERREY
            BtnEnviosDirecto.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "413");
            BtnEnviosMontereyAdmin.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "414");
            #endregion

            Text = "MENU GENERAL " + FrmLogeo.Proyecto;
        }
        private void BtnClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloTercerosRbf moduloterceros = new FrmModuloTercerosRbf();
            moduloterceros.Show();
        }

        private void BtnGestor_ItemClick(object sender, ItemClickEventArgs e)
        {
            RbfModuloAsesoresRbf asesores = new RbfModuloAsesoresRbf();
            asesores.Show();
        }

        private void skinRibbonGalleryBarItem1_GalleryPopupClose(object sender, DevExpress.XtraBars.Ribbon.InplaceGalleryEventArgs e)
        {
            conexion.MtdAddSentencia("update usuario set tema= '" + UserLookAndFeel.Default.SkinName.ToString() + "' where idusuario = '" + FrmLogeo.Usuario + "'");
        }

        private void BtnClientes_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FrmModuloTercerosRbf moduloterceros = new FrmModuloTercerosRbf();
            moduloterceros.Show();
        }

        private void BtnSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult exit;
            exit = MessageBox.Show("Esta seguro de Salir Aplicacion ", "Menu General", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exit == DialogResult.Yes)
            {
                Close();
            }
        }

        private void BtnInmuebles_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmInmueblesRbf inmuebles = new FrmInmueblesRbf();
            inmuebles.Show();
        }

        private void BtnReservas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloReservasRbf reservas=new FrmModuloReservasRbf  ();
            reservas.Show();
        }

        private void BtnModuloAdjudicacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloAdjudicacionRbf moduloadjudicacion = new FrmModuloAdjudicacionRbf();
            moduloadjudicacion.Show();
        }

        private void BtnAprobarVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmAprobarVentasRbf aprobar = new FrmAprobarVentasRbf();
            aprobar.Show();
        }

        private void BtnRadicar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloRadicacionRbf radicacion = new FrmModuloRadicacionRbf();
            radicacion.Show();
        }

        private void BtnRecaudos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloRecaudosRbf modulo = new FrmModuloRecaudosRbf();
            modulo.Show();
        }

        private void BtnCondonar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCondonacion condonar = new FrmCondonacion();
            condonar.ShowDialog();
        }

        private void BtnSeguimientoCarteraADmin_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSegCartera segcartera = new FrmSegCartera();
            segcartera.EntradaSeguimiento = "Administrativa";
            segcartera.Show();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmLiberarCan libear = new FrmLiberarCan();
            libear.ShowDialog();
        }

        private void BtnRecaudosPorFecha_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCnsRcdFecha recaudo = new FrmCnsRcdFecha();
            recaudo.Show();
        }

        private void BtnModuloOtrosi_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloOtrosiRbf otrosi = new FrmModuloOtrosiRbf();
            otrosi.Show();
        }

        private void BtnPagoComisionAlttum_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPagoComision pagocomision = new FrmPagoComision();
            pagocomision.Show();
        }

        private void BtnPagoComisionTiempo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPagoComisionesMonterey pagocomision = new FrmPagoComisionesMonterey();
            pagocomision.EntradaComision = "Tiempo";
            pagocomision.Show();
        }

        private void BtnPagoComisionEngache_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPagoComisionesMonterey pagocomision = new FrmPagoComisionesMonterey();
            pagocomision.EntradaComision = "Enganche";
            pagocomision.Show();
        }

        private void BtnPagoAnticipo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPagodeAnticipos pagoanticipo = new FrmPagodeAnticipos();
            pagoanticipo.Show();
        }

        private void BtnProyeccionComision_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmProyeccionComision proyeccion = new FrmProyeccionComision();
            proyeccion.Show();
        }

        private void BtnComisionesporPagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCnsComisionxPagar consulta = new FrmCnsComisionxPagar();
            consulta.Show();
        }

        private void BtnComisioneesporPagarEnganche_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmComisionesxPagarMonterey comision = new FrmComisionesxPagarMonterey();
            comision.EntradaComision = "Enganche";
            comision.Show();
        }

        private void BtnComisionesporPagarTiempo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmComisionesxPagarMonterey comision = new FrmComisionesxPagarMonterey();
            comision.EntradaComision = "Tiempo";
            comision.Show();
        }

        private void BtnRptComisionesporPagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRptComisionesxPagar comisiones = new FrmRptComisionesxPagar();
            comisiones.Show();
        }

        private void BtnRptResumenPagoDia_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRsmPagoComision comision = new FrmRsmPagoComision();
            comision.Show();
        }

        private void BtnRptComisionPagadaAsesor_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRptPagoCmsPorAsesor consullta = new FrmRptPagoCmsPorAsesor();
            consullta.Show();
        }

        private void BtnRptComisionPagadaCliente_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRptCnsPagoCmsPorCliente comision = new FrmRptCnsPagoCmsPorCliente();
            comision.Show();
        }

        private void BtnRptAntcipoFechas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRptAnticipoFecha anticipo = new FrmRptAnticipoFecha();
            anticipo.Show();
        }

        private void BtnRptAnticipoAdjudicacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRptAnticipoporAdj anticipo = new FrmRptAnticipoporAdj();
            anticipo.Show();
        }

        private void BtnModComisionTabla_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloComision comisionmod = new FrmModuloComision();
            comisionmod.Show();
        }

        private void BtnCumplimientoPresupuesto_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCumplimientoPresupuesto cumplimiento = new FrmCumplimientoPresupuesto();
            cumplimiento.Show();
        }

        private void BtnPagados_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Pagado";
            frmDocumentacion.Show();
        }

        private void BtnTramiteEscritura_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Tramite Escritura";
            frmDocumentacion.Show();
        }

        private void BtnEscriturados_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Escriturado";
            frmDocumentacion.Show();
        }

        private void BtnArchivados_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Archivado";
            frmDocumentacion.Show();
        }

        private void BtnJuridicosVigentes_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Aprobado";
            frmDocumentacion.Show();
        }

        private void BtnJuridicosDesistidos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Desistido";
            frmDocumentacion.Show();
        }

        private void BtnJuridico_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Juridico";
            frmDocumentacion.Show();
        }

        private void BtnDesistidoJuridico_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "DesistidoJuridico";
            frmDocumentacion.Show();
        }

        private void BtnUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloUsuariosRbf usuarios = new FrmModuloUsuariosRbf();
            usuarios.Show();
        }

        private void BtnParametros_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmParametros parametro = new FrmParametros();
            parametro.ShowDialog();
        }

        private void BtnTablaComision_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloTablaComisiones tablacomisiones = new FrmModuloTablaComisiones();
            tablacomisiones.ShowDialog();
        }

        private void BtnCambioClave_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCambioClave cambio = new FrmCambioClave();
            cambio.Show();
        }

        private void BtnCambioConsecutivo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCambioConsecutivos cambio = new FrmCambioConsecutivos();
            cambio.Show();
        }

        private void BtnTrmAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTRM TRM = new FrmTRM();
            TRM.Show();
        }
                
        private void BtnAddLotesEnvio_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmLotesEnvio lotesenvio = new FrmLotesEnvio();
            lotesenvio.ShowDialog();
        }

        private void BtnEnviosMonterey_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloEnviosMonterey envios = new FrmModuloEnviosMonterey();
            envios.Show();
        }

        private void BtnEnviosMontereyAdmin_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmModuloEnviosAlttumMonterey envios = new FrmModuloEnviosAlttumMonterey();
            envios.Show();
        }

        private void BtnSaldosFondos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCnsSaldoFondo fondos = new FrmCnsSaldoFondo();
            fondos.Show();
        }

        private void BtnCnsPagos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCnsPagoPorClientesRbf clientes = new FrmCnsPagoPorClientesRbf();
            clientes.Show();
        }

        private void BtnEnviosDirecto_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            FrmAdjudicacionMonterey adjMonterey = new FrmAdjudicacionMonterey();
            adjMonterey.Show();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmRecaudoNegociosNoRadicados RcdNegNoRadicado = new FrmRecaudoNegociosNoRadicados();
            RcdNegNoRadicado.Show();
        }

        private void btnConsultaComisiones_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmConsultarComisiones consultaComisiones = new FrmConsultarComisiones();
            consultaComisiones.Show();
        }

        private void btnPagoComisionMonterrey_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPagoComisionMonterrey MonterreyComisiones = new FrmPagoComisionMonterrey();
            MonterreyComisiones.Show();
        }

        private void btnConsultasMonterrey_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmConsultarComisionesMonterrey ConsultarComisionesMonterrey = new FrmConsultarComisionesMonterrey();
            ConsultarComisionesMonterrey.Show();
        }

        private void btnPagoComisionSobre75_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPagoComisiones75 comision75 = new FrmPagoComisiones75();
            comision75.Show();
        }

        private void btnPagoComisionesPIV_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPagoComisionPIV piv = new FrmPagoComisionPIV();
            piv.Show();
        }

        

        

    }
}