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
using System.Globalization;

namespace CarteraGeneral.Modulo_Rbf.Comision
{
    public partial class FrmPagoComision : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ClsComision comision = new ClsComision();
        string TRM_FechaContrato;
        public FrmPagoComision()
        {
            InitializeComponent();
        }

        public void btnPagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Int32 contVecesQuePuedeComisionar = 0;
            contVecesQuePuedeComisionar = cmbVecesPagoComision.Items.Count;
            if (cmbContrato.Text != "" && (cmbVecesPagoComision.SelectedText != "" || cmbVecesPagoComision.Text != "") && Convert.ToInt32(cmbVecesPagoComision.Text) > 0)
            {
                if (!cmbVecesPagoComision.Text.Equals("0") && Convert.ToInt32(cmbVecesPagoComision.Text) >= 1
                && Convert.ToInt32(cmbVecesPagoComision.Text) <= contVecesQuePuedeComisionar)
                {
                    DialogResult respuesta;
                    respuesta = MessageBox.Show("            Esta seguro de realizar este pago?\n"
                        + "Recuerde: El valor para pagar esta comisión es de: \n\t        "
                        + "*** $" + Convert.ToString(comision.TotalPagoComision.ToString("###,###.###"))+" ***", 
                        "Confirmación realizar pago.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        try
                        {
                            if (comision.PagoComision(cmbContrato.SelectedValue.ToString(), cmbVecesPagoComision.Text))
                            {
                                MessageBox.Show("Se realizó el registro del pago exitosamente.", "REGISTRO EXITOSO!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                btnPagar.Enabled = false;
                                cmbVecesPagoComision.Enabled = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ups! Hubo el siguiente inconveniente: " + ex.Message + " " + comision.Error, "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El número de veces del pago del contrato debe estar entre 1 y 4 dependiendo del contrato.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor verificar que se haya seleccionado un contrato y que se \nhaya elegido el número de veces que se va a pagar dicho contrato.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmPagoComision_Load(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                lblMensajeComision.Text = "";
                cmbVecesPagoComision.Text = "";
                cmbContrato.DataSource = comision.ListaContratos("sp_Alttum_Contratos", "Contrato");
                if (comision.ContadorContratos > 0)
                {
                    btnPagar.Enabled = true;
                    cmbVecesPagoComision.Enabled = true;
                    cmbContrato.Enabled = true;
                    lblMensaje.Text = "E l i g a   u n   c o n t r a t o.";
                    if (cmbContrato.DataSource != null)
                    {
                        pictureBoxVerificar.Image = global::CarteraGeneral.RecursosIconos.comprobado;
                        pictureBoxVerificar.SizeMode = PictureBoxSizeMode.StretchImage;
                        lblMensaje.Text = "C a r g a   E x i t o s a.";
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
                    lblMensaje.Text = "S i n   c o m i s i o n e s   p e n d i e n t e s   p o r   p a g a r.";
                    btnPagar.Enabled = false;
                    cmbVecesPagoComision.Enabled = false;
                    cmbContrato.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sucedio el siguiente inconveniente: " + ex.Message);
            }

        }

        private void cmbContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            comision.Contrato = cmbContrato.SelectedValue.ToString();
            cmbVecesPagoComision.Text = "";
            cmbVecesPagoComision.Items.Clear();
            if (comision.ContadorContratos > 0)
            {
                cantidadVecesQuePuedeComisionarContrato();

                if (comision.cargarInformacionContrato())
                {
                    TCRMServicesInterfaceClient client = new TCRMServicesInterfaceClient();
                    tcrmResponse response = default(tcrmResponse);
                    response = client.queryTCRM(comision.FechaContrato);
                    TRM_FechaContrato = response.value.ToString("###,###.###");

                    txtCliente.Text = comision.Cliente;
                    txtInmueble.Text = comision.Inmueble;
                    txtFechaContrato.Text = comision.FechaContrato.ToString("dd/MM/yyyy");
                    txtVentaTotal.Text = Convert.ToDouble(comision.TotalVenta).ToString("###,###.###");
                    txtTotalRecaudado.Text = Convert.ToDouble(comision.TotalRecaudado).ToString("###,###.###");
                    txtTRM.Text = TRM_FechaContrato;
                    txtPorcentajeComisionado.Text = Convert.ToDouble(comision.PorcentajeComisionado).ToString() + "%";
                    grwComisiones.DataSource = comision.cargarInformacionComisiones();
                    if (txtPorcentajeComisionado.Text == "100%")
                    {
                        btnPagar.Enabled = false;
                    }
                    else
                    {
                        btnPagar.Enabled = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay contratos para pagar comisión actualmente.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnPagar.Enabled = false;
                cmbVecesPagoComision.Enabled = false;
                cmbContrato.Enabled = false;
                cmbContrato.Text = "";
                txtCliente.Text = "";
                txtInmueble.Text = "";
                txtFechaContrato.Text = "";
                txtVentaTotal.Text = "";
                txtTotalRecaudado.Text = "";
                txtTRM.Text = "";
                txtPorcentajeComisionado.Text = "";
                grwComisiones = null;
            }
        }

        private void cantidadVecesQuePuedeComisionarContrato()
        {
            if (comision.vecesPagoComisionContrato(cmbContrato.SelectedValue.ToString()))
            {
                switch (comision.VecesPuedeComisionarContrato)
                {
                    case "0-1":
                        cmbVecesPagoComision.Items.Add("1");
                        lblMensajeComision.Text = "S o l o  s e   p u e d e   r e a l i z a r   u n  p a g o.";
                        cmbVecesPagoComision.Text = "1";
                        break;
                    case "0-2":
                        cmbVecesPagoComision.Items.Add("1");
                        cmbVecesPagoComision.Items.Add("2");
                        lblMensajeComision.Text = "S e   p u e d e n   r e a l i z a r  2  p a g o s.";
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "0-3":
                        cmbVecesPagoComision.Items.Add("1");
                        cmbVecesPagoComision.Items.Add("2");
                        cmbVecesPagoComision.Items.Add("3");
                        lblMensajeComision.Text = "S e   p u e d e  r e a l i z a r   e l   p a g o   " +
                            "c o m p l e t o   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "1-2":
                        cmbVecesPagoComision.Items.Add("1");
                        lblMensajeComision.Text = "S o l o   s e   p u e d e   r e a l i z a r   " +
                            "e l   s e g u n d o   p a g o.";
                        cmbVecesPagoComision.Text = "1";
                        break;
                    case "1-3":
                        cmbVecesPagoComision.Items.Add("1");
                        cmbVecesPagoComision.Items.Add("2");
                        lblMensajeComision.Text = "S e   p u e d e n   r e a l i z a r  " +
                            "l o s   2   ú l t i m o s   p a g o s.";
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "2-3":
                        cmbVecesPagoComision.Items.Add("1");
                        lblMensajeComision.Text = "Ú l t i m o   p a g o   d e   l a   c o m i s i ó n.";
                        cmbVecesPagoComision.Text = "1";
                        break;
                    case "0-4":
                        cmbVecesPagoComision.Items.Add("1");
                        cmbVecesPagoComision.Items.Add("2");
                        cmbVecesPagoComision.Items.Add("3");
                        cmbVecesPagoComision.Items.Add("4");
                        lblMensajeComision.Text = "S e   p u e d e    p a g a r   e l   t o t a l   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "4";
                        break; 
                }
                
            }
        }

        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                lblMensajeComision.Text = "";
                cmbVecesPagoComision.Text = "";
                cmbContrato.DataSource = comision.ListaContratos("sp_Alttum_Contratos", "Contrato");
                if (comision.ContadorContratos > 0)
                {
                    btnPagar.Enabled = true;
                    cmbVecesPagoComision.Enabled = true;
                    cmbContrato.Enabled = true;
                    lblMensaje.Text = "E l i g a   u n   c o n t r a t o.";
                    if (cmbContrato.DataSource != null)
                    {
                        pictureBoxVerificar.Image = global::CarteraGeneral.RecursosIconos.comprobado;
                        pictureBoxVerificar.SizeMode = PictureBoxSizeMode.StretchImage;
                        lblMensaje.Text = "C a r g a   E x i t o s a.";
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
                    MessageBox.Show("No hay contratos para pagar comisión actualmente.", "Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblMensaje.Text = "S i n   c o m i s i o n e s   p e n d i e n t e s   p o r   p a g a r.";
                    cmbVecesPagoComision.Enabled = false;
                    cmbContrato.Enabled = false;
                    cmbContrato.Text = "";
                    txtCliente.Text = "";
                    txtInmueble.Text = "";
                    txtFechaContrato.Text = "";
                    txtVentaTotal.Text = "";
                    txtTotalRecaudado.Text = "";
                    txtTRM.Text = "";
                    txtPorcentajeComisionado.Text = "";
                    grwComisiones = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Sucedio el siguiente inconveniente: " + ex.Message);

            }
        }

        private void cmbVecesPagoComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Int32 contVecesQuePuedeComisionar = 0;
                contVecesQuePuedeComisionar = cmbVecesPagoComision.Items.Count;
                if (!cmbVecesPagoComision.Text.Equals("0") && Convert.ToInt32(cmbVecesPagoComision.Text) >= 1
                        && Convert.ToInt32(cmbVecesPagoComision.Text) <= contVecesQuePuedeComisionar)
                {
                    if (comision.calcularPagoComision(cmbVecesPagoComision.Text))
                    {
                        txtTotalPagarComision.Text = Convert.ToString(comision.TotalPagoComision.ToString("###,###.###"));
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ver el número de veces que puede comisionar este contrato.\n"
                        +"Nota: Este contrato puede comisionar en "+contVecesQuePuedeComisionar+" ocasion(es).", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                //Este catch se esta utilizando para que cuando se borre el campo de vecesPagoComision, el campo queda
                //null y genera un error, este catch permite que no se reviente el programa
            }
        }

        private void FrmPagoComision_FormClosing(object sender, FormClosingEventArgs e)
        {
            comision = null;
        }
    }
}