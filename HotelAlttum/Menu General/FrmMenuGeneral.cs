using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarteraGeneral
{
    public partial class FrmMenuGeneral : Form
    {
        public FrmMenuGeneral()
        {
            InitializeComponent();
        }
        public static decimal Mora;
        public static Image Logo;
        ClsIdentificacion conexion = new ClsIdentificacion();
        private void FrmMenuGeneral_Load(object sender, EventArgs e)
        {

            string a = ProductVersion.ToString();
            toolStripStatusLabel1.Text= "USUARIO CONECTADO " + FrmLogeo.Usuario.ToUpper() + "    NOMBRE USUARIO: " + FrmLogeo.DtDatosUsuario.Rows[0]["NombreUsuario"].ToString().ToUpper() +"              VERSION DEL ENSAMBLADO: " +a;
            TsmParametros.Enabled =   conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "904");
            TsmTablaComisiones.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "905");
            TsmAprobarVentas.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "306");
            TsmmontarPresupuesto.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "409");
            TsmModificarComision.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "503");
            TsmCondonarInteres.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "402");
            TsmCambioConsecutivos.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "906");
            TsmPagado.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "601");
            TsmTramiteEscritura.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "602");
            TsmEscriturado.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "603");
            TsmArchivados.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "604");
            TsmJuridico.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "602");
            TsmDesistidoJuridico.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "605");
            TsmEnvNegcioVigJuridico.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "701");
            TsmEnvNegDesJuridico.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "701");
        }

        private void FrmMenuGeneral_Activated(object sender, EventArgs e)
        {
            TsmParametros.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "904");
            TsmTablaComisiones.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "905");
            TsmAprobarVentas.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "306");
            TsmmontarPresupuesto.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "409");
            TsmModificarComision.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "503");
            TsmCondonarInteres.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "402");
        }

            
        private void TsmModuloAdjudicacion_Click(object sender, EventArgs e)
        {
            FrmModuloAdjudicacionRbf moduloadjudicacion = new FrmModuloAdjudicacionRbf();
            moduloadjudicacion.Show();
        }

       
        private void TsmSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

      

        private void TsmParametros_Click(object sender, EventArgs e)
        {
            FrmParametros parametro =new FrmParametros ();
            parametro.ShowDialog();
        }

        private void TsmTablaComisiones_Click(object sender, EventArgs e)
        {
            FrmModuloTablaComisiones tablacomisiones = new FrmModuloTablaComisiones();
            tablacomisiones.ShowDialog();
        }

    

        private void pagoDeAnticipoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagodeAnticipos pagoanticipo = new FrmPagodeAnticipos();
            pagoanticipo.Show();
        }

      
        private void TsmCnsComisionesxPagar_Click(object sender, EventArgs e)
        {
            FrmCnsComisionxPagar consulta = new FrmCnsComisionxPagar();
            consulta.Show();
        }

        private void TsmRptComisionesxPagar_Click(object sender, EventArgs e)
        {
            FrmRptComisionesxPagar comisiones = new FrmRptComisionesxPagar();
            comisiones.Show();
        }

        private void TsmRsmPagoDia_Click(object sender, EventArgs e)
        {
            FrmRsmPagoComision comision = new FrmRsmPagoComision();
            comision.Show();
        }

        private void TsmCnsComPgdAsesor_Click(object sender, EventArgs e)
        {
            FrmRptPagoCmsPorAsesor consullta = new FrmRptPagoCmsPorAsesor();
            consullta.Show();
        }

        private void TsmCmsPagCliente_Click(object sender, EventArgs e)
        {
            FrmRptCnsPagoCmsPorCliente comision = new FrmRptCnsPagoCmsPorCliente();
            comision.Show();
        }

    

        private void TsmProyeccionComisiones_Click(object sender, EventArgs e)
        {
            FrmProyeccionComision proyeccion = new FrmProyeccionComision();
            proyeccion.Show();
        }

        private void TsmAnticipoporFecha_Click(object sender, EventArgs e)
        {
            FrmRptAnticipoFecha anticipo = new FrmRptAnticipoFecha();
            anticipo.Show();
        }

        private void TstAnticipoporAdj_Click(object sender, EventArgs e)
        {
            FrmRptAnticipoporAdj anticipo = new FrmRptAnticipoporAdj();
            anticipo.Show();
        }

      

        private void TsmCambiodeClave_Click(object sender, EventArgs e)
        {
            FrmCambioClave cambio = new FrmCambioClave();
            cambio.Show();
        }

        private void BtnSegCarteraADdmdin_Click(object sender, EventArgs e)
        {
            FrmSegCartera segcartera = new FrmSegCartera();
            segcartera.EntradaSeguimiento = "Administrativa";
            segcartera.Show();
        }

        private void TsmModificarComision_Click(object sender, EventArgs e)
        {
            FrmModuloComision comisionmod = new FrmModuloComision();
            comisionmod.Show();
        }

        private void TsmRcdFecha_Click(object sender, EventArgs e)
        {
            FrmCnsRcdFecha recaudo = new FrmCnsRcdFecha();
            recaudo.Show();
        }

        private void TsmSegCarteraComercial_Click(object sender, EventArgs e)
        {
            FrmSegCartera segcartera = new FrmSegCartera();
            segcartera.EntradaSeguimiento = "Comercial";
            segcartera.Show();
        }

        private void TsmmontarPresupuesto_Click(object sender, EventArgs e)
        {
            FrmPresupuesto presupuesto = new FrmPresupuesto();
            presupuesto.Show();
        }

        private void TsmPresGralMontado_Click(object sender, EventArgs e)
        {
            FrmRptPresupuestoGral presupuesto = new FrmRptPresupuestoGral();
            presupuesto.Show();
        }

        private void TsmSegPresupuesto_Click(object sender, EventArgs e)
        {
            FrmRptSegPresupuesto segimiento = new FrmRptSegPresupuesto();
            segimiento.Show();
        }

        private void TsmRcdFueraPresupuesto_Click(object sender, EventArgs e)
        {
            FrmRptFueraPresupuesto presupuesto = new FrmRptFueraPresupuesto();
            presupuesto.EntradaRango = "Recaudo Fuera";
            presupuesto.Show();
        }

        private void TsmRcdExponNoPresu_Click(object sender, EventArgs e)
        {
            FrmRptFueraPresupuesto presupuesto = new FrmRptFueraPresupuesto();
            presupuesto.EntradaRango = "Expontaneo Fuera";
            presupuesto.Show();
        }

        private void TsmRcdExpPresup_Click(object sender, EventArgs e)
        {
            FrmRptFueraPresupuesto presupuesto = new FrmRptFueraPresupuesto();
            presupuesto.EntradaRango = "Expontaneo Dentro";
            presupuesto.Show();
        }

        private void TsmCondonarInteres_Click(object sender, EventArgs e)
        {
            FrmCondonacion condonar = new FrmCondonacion();
            condonar.ShowDialog();
        }

        private void TsmCambioConsecutivos_Click(object sender, EventArgs e)
        {
            FrmCambioConsecutivos cambio = new FrmCambioConsecutivos();
            cambio.Show();
        }

        private void TsmPagado_Click(object sender, EventArgs e)
        {          
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Pagado";
            frmDocumentacion.Show();
        }

        private void TsmTramiteEscritura_Click(object sender, EventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Tramite Escritura";
            frmDocumentacion.Show();
        }

        private void TsmEscriturado_Click(object sender, EventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Escriturado";
            frmDocumentacion.Show();
        }

        private void TsmArchivados_Click(object sender, EventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Archivado";
            frmDocumentacion.Show();
        }

       

        

        private void TsmEnvNegcioVigJuridico_Click(object sender, EventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Aprobado";
            frmDocumentacion.Show();
        }

        private void TsmEnvNegDesJuridico_Click(object sender, EventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Desistido";
            frmDocumentacion.Show();
        }

        private void TsmJuridico_Click(object sender, EventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "Juridico";
            frmDocumentacion.Show();
        }

        private void TsmDesistidoJuridico_Click(object sender, EventArgs e)
        {
            FrmDocumentacion frmDocumentacion = new FrmDocumentacion();
            frmDocumentacion.EntradaDocumentacion = "DesistidoJuridico";
            frmDocumentacion.Show();
        }

        private void TsmLiberarCanje_Click(object sender, EventArgs e)
        {
            FrmLiberarCan libear = new FrmLiberarCan();
            libear.ShowDialog();
        }

        private void TsmProyeccionResumida_Click(object sender, EventArgs e)
        {
            FrmProyeccionDetalle proyeccion = new FrmProyeccionDetalle();
            proyeccion.Show();
        }

        private void TsmProyeccionDetallada_Click(object sender, EventArgs e)
        {
            FrmRptDetalleGeneralProyecccion proyeccion = new FrmRptDetalleGeneralProyecccion();
            proyeccion.Show();
        }

        private void TsmSaldoGralCartera_Click(object sender, EventArgs e)
        {
            FrmSaldoCartera saldo = new FrmSaldoCartera();
            saldo.Show();
        }

        private void TsmCarteraVencida_Click(object sender, EventArgs e)
        {
            FrmRptCarteraVencida cartera = new FrmRptCarteraVencida();
            cartera.Show();
        }

        private void BtnCnsComisionesMonterey_Click(object sender, EventArgs e)
        {
            FrmComisionesxPagarMonterey comision = new FrmComisionesxPagarMonterey();
            comision.EntradaComision = "Enganche";
            comision.Show();
        }

        private void comisionesAlttumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagodeComisiones pagocomision = new FrmPagodeComisiones();           
            pagocomision.Show();
        }

        private void comisionesMontereyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagoComisionesMonterey pagocomision = new FrmPagoComisionesMonterey();
            pagocomision.EntradaComision = "Enganche";
            pagocomision.Show();
        }

        private void comisionesPorPagarMonterreyPorTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmComisionesxPagarMonterey comision = new FrmComisionesxPagarMonterey();
            comision.EntradaComision = "Tiempo";
            comision.Show();
        }

        private void comisionesMontereyTiempoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPagoComisionesMonterey pagocomision = new FrmPagoComisionesMonterey();
            pagocomision.EntradaComision = "Tiempo";
            pagocomision.Show();
        }

        private void guardarTRMDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTRM TRM = new FrmTRM();
            TRM.strEntrada = "Adicionar";
            TRM.Show();
        }

        private void modificarTRMDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTRM TRM = new FrmTRM();
            TRM.strEntrada = "Modificar";
            TRM.Show();
        }

        private void adicionarLotesEnvioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLotesEnvio lotesenvio = new FrmLotesEnvio();
            lotesenvio.ShowDialog();
        }

   

        private void recaydisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarteraGeneral.Cartera.Frm_Recaudos Recaudos = new Cartera.Frm_Recaudos();
            Recaudos.Show();
        }

        

        private void BntNegociosMonterey_Click(object sender, EventArgs e)
        {
            FrmModuloEnviosMonterey envios = new FrmModuloEnviosMonterey();
            envios.Show();
        }

        private void BtnNegociosAlttum_Click(object sender, EventArgs e)
        {
            FrmModuloEnviosAlttumMonterey envios = new FrmModuloEnviosAlttumMonterey();
            envios.Show();
        }

        private void BtnSaldosFondosMonterey_Click(object sender, EventArgs e)
        {
            FrmCnsSaldoFondo fondos = new FrmCnsSaldoFondo();
            fondos.Show();
        }

       

      


        
       
       

        
       
      
    }
}
