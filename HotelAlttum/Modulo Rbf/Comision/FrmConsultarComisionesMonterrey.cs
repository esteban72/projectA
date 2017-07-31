using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using CarteraGeneral.Clases;
using CarteraGeneral.WebServiceTRMColombia;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;

namespace CarteraGeneral.Modulo_Rbf.Comision
{
    public partial class FrmConsultarComisionesMonterrey : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ClsComision comision = new ClsComision();
        string TRM_FechaContrato;
        string contrato;
        public FrmConsultarComisionesMonterrey()
        {
            InitializeComponent();
        }



        private void FrmConsultarComisionesMonterrey_Load(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                dpFecha2Comision.Enabled = false;
                cmbContrato.DataSource = comision.ListaContratos("sp_Monterrey_ContratosComisionados", "Contrato");
                if (comision.ContadorContratos > 0)
                {
                    btnExcel.Enabled = true;
                    btnImprimir.Enabled = true;
                    cmbContrato.Enabled = true;
                    if (cmbContrato.DataSource != null)
                    {
                        pictureBoxVerificar.Image = global::CarteraGeneral.RecursosIconos.comprobado;
                        pictureBoxVerificar.SizeMode = PictureBoxSizeMode.StretchImage;
                        lblMensaje.Text = comision.ContadorContratos + "  c o n t r a t o (s)   c a r g a d o (s).";
                    }
                    else
                    {
                        pictureBoxVerificar.Image = global::CarteraGeneral.RecursosIconos.error;
                        pictureBoxVerificar.SizeMode = PictureBoxSizeMode.StretchImage;
                        lblMensaje.Text = "Error cargando los contratos " + comision.Error;
                    }
                }
                else
                {
                    lblMensaje.Text = "S i n   c o m i s i o n e s   p a g a d a s.";
                    btnExcel.Enabled = false;
                    btnImprimir.Enabled = false;
                    cmbContrato.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sucedio el siguiente inconveniente: " + ex.Message);
            }

        }


        private void chkRangoFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRangoFechas.Checked)
            {
                dpFecha2Comision.Enabled = true;
            }
            else
            {
                dpFecha2Comision.Enabled = false;
            }
        }

        private void cmbContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comision.Contrato = cmbContrato.SelectedValue.ToString();
                txtVecesPagadaComision.Text = "";
                if (comision.ContadorContratos > 0)
                {
                    lblMensaje.Text = comision.ContadorContratos + "  c o n t r a t o (s)   c a r g a d o (s).";

                    if (comision.cargarInformacionContrato() && comision.NumVecesComisionada())
                    {
                        TCRMServicesInterfaceClient client = new TCRMServicesInterfaceClient();
                        tcrmResponse response = default(tcrmResponse);
                        response = client.queryTCRM(comision.FechaContrato);
                        TRM_FechaContrato = response.value.ToString("###,###.###");

                        txtVecesPagadaComision.Text = comision.VecesContratoComisionado;
                        txtCliente.Text = comision.Cliente;
                        txtInmueble.Text = comision.Inmueble;
                        txtFechaContrato.Text = comision.FechaContrato.ToString("dd/MM/yyyy");
                        txtVentaTotal.Text = Convert.ToDouble(comision.TotalVenta).ToString("###,###.###");
                        txtTotalRecaudado.Text = Convert.ToDouble(comision.TotalRecaudado).ToString("###,###.###");
                        txtTRM.Text = TRM_FechaContrato;
                        txtPorcentajeComisionado.Text = Convert.ToDouble(comision.PorcentajeComisionado).ToString() + "%";
                        txtTotalComisionPagada.Text = Convert.ToDouble(comision.TotalPagoComision).ToString("###,###.###");
                        grdConsultarComisiones.DataSource = comision.cargarInformacionComisiones();
                        grdExportar.DataSource = comision.cargaYExportaExcel();
                    }
                }
                else
                {
                    MessageBox.Show("No figuran contratos con comisiones pagadas.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnExcel.Enabled = false;
                    btnImprimir.Enabled = false;
                    cmbContrato.Enabled = false;
                    cmbContrato.Text = "";
                    txtVecesPagadaComision.Text = "";
                    dpFechaComision.Enabled = false;
                    dpFecha2Comision.Enabled = false;
                    txtCliente.Text = "";
                    txtInmueble.Text = "";
                    txtFechaContrato.Text = "";
                    txtVentaTotal.Text = "";
                    txtTotalRecaudado.Text = "";
                    txtTRM.Text = "";
                    txtPorcentajeComisionado.Text = "";
                    txtTotalComisionPagada.Text = "";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ups! Hubo el siguiente inconveniente: " + ex.Message + " " + comision.Error, "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarFecha_Click(object sender, EventArgs e)
        {
            comision.Fecha1Comision = dpFechaComision.Value;
            if (dpFecha2Comision.Enabled == true)
            {
                comision.Fecha2Comision = dpFecha2Comision.Value;
                cmbContrato.DataSource = comision.ContratosXFecha("sp_Monterrey_ContratosXFecha", "Contrato");

            }
            else
            {
                comision.dFecha2Comision = null;
                cmbContrato.DataSource = comision.ContratosXFecha("sp_Monterrey_ContratosXFecha", "Contrato");
            }
            if (comision.ContadorContratos == 0)
            {
                lblMensaje.Text = "0  c o n t r a t o s   e n   l a (s)   f e c h a (s)   s e l e c c i o n a d a (s).";
                btnExcel.Enabled = false;
                btnImprimir.Enabled = false;
                cmbContrato.Enabled = false;
                cmbContrato.Text = "";
                txtVecesPagadaComision.Text = "";
                dpFechaComision.Enabled = false;
                dpFecha2Comision.Enabled = false;
                txtCliente.Text = "";
                txtInmueble.Text = "";
                txtFechaContrato.Text = "";
                txtVentaTotal.Text = "";
                txtTotalRecaudado.Text = "";
                txtTRM.Text = "";
                txtPorcentajeComisionado.Text = "";
                txtTotalComisionPagada.Text = "";
            }
        }

        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                btnExcel.Enabled = false;
                btnImprimir.Enabled = false;
                cmbContrato.Enabled = false;
                cmbContrato.Text = "";
                txtVecesPagadaComision.Text = "";
                dpFechaComision.Enabled = true;
                dpFecha2Comision.Enabled = false;
                txtCliente.Text = "";
                txtInmueble.Text = "";
                txtFechaContrato.Text = "";
                txtVentaTotal.Text = "";
                txtTotalRecaudado.Text = "";
                txtTRM.Text = "";
                txtPorcentajeComisionado.Text = "";
                txtTotalComisionPagada.Text = "";
                lblMensaje.Text = "";
                cmbContrato.DataSource = comision.ListaContratos("sp_Monterrey_ContratosComisionados", "Contrato");
                if (comision.ContadorContratos > 0)
                {
                    btnExcel.Enabled = true;
                    btnImprimir.Enabled = true;
                    cmbContrato.Enabled = true;
                    if (cmbContrato.DataSource != null)
                    {
                        pictureBoxVerificar.Image = global::CarteraGeneral.RecursosIconos.comprobado;
                        pictureBoxVerificar.SizeMode = PictureBoxSizeMode.StretchImage;
                        lblMensaje.Text = comision.ContadorContratos + "  c o n t r a t o (s)   c a r g a d o (s).";
                    }
                    else
                    {
                        pictureBoxVerificar.Image = global::CarteraGeneral.RecursosIconos.error;
                        pictureBoxVerificar.SizeMode = PictureBoxSizeMode.StretchImage;
                        lblMensaje.Text = "Error cargando los contratos " + comision.Error;
                    }
                }
                else
                {
                    lblMensaje.Text = "S i n   c o m i s i o n e s   p a g a d a s.";
                    btnExcel.Enabled = false;
                    btnImprimir.Enabled = false;
                    cmbContrato.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sucedio el siguiente inconveniente: " + ex.Message);
            }
        }

        private void btnExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            comision.exportarArchivo(grdExportar, sender, e);
        }

        private void btnImprimir_ItemClick(object sender, ItemClickEventArgs e)
        {
            imprimir(grdConsultarComisiones, "COMISIONES PAGADAS");
        }

        private void FrmConsultarComisionesMonterrey_FormClosing(object sender, FormClosingEventArgs e)
        {
            comision = null;
        }

        string Titulo;
        private void imprimir(GridControl GrdGrilla, string MiTitulo)
        {
            Titulo = MiTitulo;
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = GrdGrilla;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
            link.CreateDocument();
            link.ShowPreview();
        }
        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            DevExpress.XtraPrinting.TextBrick brick;
            DevExpress.XtraPrinting.ImageBrick imagen;
            brick = e.Graph.DrawString(Titulo, Color.Navy, new RectangleF(160, 0, 455, 60), DevExpress.XtraPrinting.BorderSide.None);
            imagen = e.Graph.DrawImage(global::CarteraGeneral.RecursosIconos.LogoAlttum, new RectangleF(10, 0, 150, 50), DevExpress.XtraPrinting.BorderSide.None, Color.Transparent);
            brick.Font = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
            //brick.BackColor = Color.Blue;
            brick.ForeColor = Color.Gray;
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }

        private void txtFiltrarContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                contrato = txtFiltrarContrato.Text;
                comision.ConsultarContrato("sp_Monterrey_FiltrarContrato", contrato);
                if (comision.ContadorContratos > 0)
                {
                    cmbContrato.Text = contrato;
                    cmbContrato_SelectedIndexChanged(sender, e);
                    lblMensaje.Text = "C o n t r a t o   e n c o n t r a d o.";
                    txtFiltrarContrato.Text = "";
                    btnExcel.Enabled = true;
                    btnImprimir.Enabled = true;
                    cmbContrato.Enabled = true;
                    dpFechaComision.Enabled = true;
                    dpFecha2Comision.Enabled = true;
                    grdConsultarComisiones.Enabled = true;
                    btnBuscarFecha.Enabled = true;
                }
                else
                {
                    cmbContrato.Text = "0";
                    lblMensaje.Text = "E l   c o n t r a t o   q u e   e s t a   b u s c a n d o   n o   r e g i s t r a.";
                    btnExcel.Enabled = false;
                    btnImprimir.Enabled = false;
                    cmbContrato.Enabled = false;
                    txtVecesPagadaComision.Text = "";
                    dpFechaComision.Enabled = false;
                    dpFecha2Comision.Enabled = false;
                    btnBuscarFecha.Enabled = false;
                    txtCliente.Text = "";
                    txtInmueble.Text = "";
                    txtFechaContrato.Text = "";
                    txtVentaTotal.Text = "";
                    txtTotalRecaudado.Text = "";
                    txtTRM.Text = "";
                    txtPorcentajeComisionado.Text = "";
                    txtTotalComisionPagada.Text = "";
                    grdConsultarComisiones.Enabled = false;
                }
            }
        }

        private void FrmConsultarComisionesMonterrey_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            comision = null;
        }

    }
}