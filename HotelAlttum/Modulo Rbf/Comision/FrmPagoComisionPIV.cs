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
using CarteraGeneral.Correo;

namespace CarteraGeneral.Modulo_Rbf.Comision
{
    public partial class FrmPagoComisionPIV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        ClsComision comision = new ClsComision();
        string TRM_FechaContrato;
        public FrmPagoComisionPIV()
        {
            InitializeComponent();
        }

        private void FrmPagoComisionPIV_Load(object sender, EventArgs e)
        {
            try
            {
                lblMensaje.Text = "";
                lblMensajeComision.Text = "";
                cmbVecesPagoComision.Text = "";
                cmbContrato.DataSource = comision.ListaContratos("sp_PIV_Contratos", "Contrato");
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

        private void btnPagar_ItemClick(object sender, ItemClickEventArgs e)
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
                        + "*** $" + Convert.ToString(comision.TotalPagoComision.ToString("###,###.###")) + " ***",
                        "Confirmación realizar pago.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.Yes)
                    {
                        try
                        {
                            if (comision.PagoComision("sp_PagoComision_PIV",cmbContrato.SelectedValue.ToString(), cmbVecesPagoComision.Text))
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

        private void btnActualizar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmPagoComisionPIV_Load(sender, e);
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
                    if (comision.MarcaDolarTecho == 1 && comision.valTRMcontrato > 0)
                    {
                        txtTRM.Text = comision.valTRMcontrato.ToString("###,###.###");
                    }
                    else
                    {
                        TCRMServicesInterfaceClient client = new TCRMServicesInterfaceClient();
                        tcrmResponse response = default(tcrmResponse);
                        response = client.queryTCRM(comision.FechaContrato);
                        TRM_FechaContrato = response.value.ToString("###,###.###");
                        txtTRM.Text = TRM_FechaContrato;
                    }
                    

                    txtCliente.Text = comision.Cliente;
                    txtInmueble.Text = comision.Inmueble;
                    txtFechaContrato.Text = comision.FechaContrato.ToString("dd/MM/yyyy");
                    txtVentaTotal.Text = Convert.ToDouble(comision.TotalVenta).ToString("###,###.###");
                    txtTotalRecaudado.Text = Convert.ToDouble(comision.TotalRecaudado).ToString("###,###.###");
                    
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
                        + "Nota: Este contrato puede comisionar en " + contVecesQuePuedeComisionar + " ocasion(es).", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                //Este catch se esta utilizando para que cuando se borre el campo de vecesPagoComision, el campo queda
                //null y genera un error, este catch permite que no se reviente el programa
            }
        }

        

        private void FrmPagoComisionPIV_FormClosing(object sender, FormClosingEventArgs e)
        {
            comision = null;
        }

        private void btnRechazar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                DialogResult respuesta;
                respuesta = MessageBox.Show("Esta seguro de rechazar estos comisionistas por falta de información?\n" +
                "La persona encargada deberá volver a ingresalos.", "Confirmación.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    if (comision.RechazarOperacion(cmbContrato.SelectedValue.ToString(), "Comisionistas"))
                    {
                        DialogResult respuesta2;
                        respuesta2 = MessageBox.Show("Registro rechazado exitosamente.\nDesea enviar un correo notificando el rechazo?",
                            "Envio de correo.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (respuesta2 == DialogResult.Yes)
                        {
                            FrmCorreo correo = new FrmCorreo();
                            correo.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ups! hubo un inconveniente: " + ex.Message, "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cantidadVecesQuePuedeComisionarContrato()
        {
            if (comision.vecesPagoComisionContrato(cmbContrato.SelectedValue.ToString()))
            {
                string mensaje1 = "S e   p u e d e   r e a l i z a r   e l   p a g o   " +
                            "p a r c i a l   d e   l a s   c o m i s i o n e s.";
                switch (comision.VecesPuedeComisionarContrato)
                {
                    #region "Pago Comisiones"
                    #region "Pago ninguna comision"

                    case "0-24":
                        for (int i = 0; i < 24; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e n   r e a l i z a r   e l   p a g o   " +
                            "c o m p l e t o   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "24";
                        break;
                    case "0-23":
                        for (int i = 0; i < 23; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "23";
                        break;
                    case "0-22":
                        for (int i = 0; i < 22; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "22";
                        break;
                    case "0-21":
                        for (int i = 0; i < 21; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "21";
                        break;
                    case "0-20":
                        for (int i = 0; i < 20; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "20";
                        break;
                    case "0-19":
                        for (int i = 0; i < 19; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "19";
                        break;
                    case "0-18":
                        for (int i = 0; i < 18; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "18";
                        break;
                    case "0-17":
                        for (int i = 0; i < 17; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "17";
                        break;
                    case "0-16":
                        for (int i = 0; i < 16; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "16";
                        break;
                    case "0-15":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "0-14":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "0-13":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "0-12":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "0-11":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "0-10":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "0-9":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "0-8":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "0-7":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "0-6":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "0-5":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "0-4":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "0-3":
                        cmbVecesPagoComision.Items.Add("1");
                        cmbVecesPagoComision.Items.Add("2");
                        cmbVecesPagoComision.Items.Add("3");
                        lblMensajeComision.Text = "S e   p u e d e  r e a l i z a r   e l   p a g o   " +
                            "c o m p l e t o   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "0-2":
                        cmbVecesPagoComision.Items.Add("1");
                        cmbVecesPagoComision.Items.Add("2");
                        lblMensajeComision.Text = "S e   p u e d e n   r e a l i z a r  2  p a g o s.";
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "0-1":
                        cmbVecesPagoComision.Items.Add("1");
                        lblMensajeComision.Text = "S o l o  s e   p u e d e   r e a l i z a r   u n  p a g o.";
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 1"
                    case "1-24":
                        for (int i = 0; i < 23; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "23";
                        break;
                    case "1-23":
                        for (int i = 0; i < 22; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "22";
                        break;
                    case "1-22":
                        for (int i = 0; i < 21; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "21";
                        break;
                    case "1-21":
                        for (int i = 0; i < 20; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "20";
                        break;
                    case "1-20":
                        for (int i = 0; i < 19; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "19";
                        break;
                    case "1-19":
                        for (int i = 0; i < 18; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "18";
                        break;
                    case "1-18":
                        for (int i = 0; i < 17; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "17";
                        break;
                    case "1-17":
                        for (int i = 0; i < 16; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "16";
                        break;
                    case "1-16":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "1-15":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "1-14":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "1-13":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "1-12":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "1-11":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "1-10":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "1-9":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "1-8":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "1-7":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "1-6":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "1-5":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "1-4":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "1-3":
                        cmbVecesPagoComision.Items.Add("1");
                        cmbVecesPagoComision.Items.Add("2");
                        lblMensajeComision.Text = "S e   p u e d e   r e a l i z a r  " +
                            "e l   3 e r    p a g o.";
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "1-2":
                        cmbVecesPagoComision.Items.Add("1");
                        lblMensajeComision.Text = "S o l o   s e   p u e d e   r e a l i z a r   " +
                            "e l   s e g u n d o   p a g o.";
                        cmbVecesPagoComision.Text = "1";
                        break;

                    #endregion

                    #region "Pago comision 2"
                    case "2-24":
                        for (int i = 0; i < 22; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "22";
                        break;
                    case "2-23":
                        for (int i = 0; i < 21; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "21";
                        break;
                    case "2-22":
                        for (int i = 0; i < 20; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "20";
                        break;
                    case "2-21":
                        for (int i = 0; i < 19; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "19";
                        break;
                    case "2-20":
                        for (int i = 0; i < 18; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "18";
                        break;
                    case "2-19":
                        for (int i = 0; i < 17; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "17";
                        break;
                    case "2-18":
                        for (int i = 0; i < 16; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "16";
                        break;
                    case "2-17":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "2-16":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "2-15":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "2-14":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "2-13":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "2-12":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "2-11":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "2-10":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "2-9":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "2-8":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "2-7":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "2-6":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "2-5":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "2-4":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "2-3":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                                            
                    #endregion

                    #region "Pago comision 3"
                    
                    case "3-24":
                        for (int i = 0; i < 21; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "21";
                        break;
                    case "3-23":
                        for (int i = 0; i < 20; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "20";
                        break;
                    case "3-22":
                        for (int i = 0; i < 19; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "19";
                        break;
                    case "3-21":
                        for (int i = 0; i < 18; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "18";
                        break;
                    case "3-20":
                        for (int i = 0; i < 17; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "17";
                        break;
                    case "3-19":
                        for (int i = 0; i < 16; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "16";
                        break;
                    case "3-18":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "3-17":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "3-16":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "3-15":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "3-14":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "3-13":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "3-12":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "3-11":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "3-10":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "3-9":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "3-8":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "3-7":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "3-6":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "3-5":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "3-4":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;

                    #endregion

                    #region "Pago comision 4"
                    
                    case "4-24":
                        for (int i = 0; i < 20; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "20";
                        break;
                    case "4-23":
                        for (int i = 0; i < 19; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "19";
                        break;
                    case "4-22":
                        for (int i = 0; i < 18; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "18";
                        break;
                    case "4-21":
                        for (int i = 0; i < 17; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "17";
                        break;
                    case "4-20":
                        for (int i = 0; i < 16; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "16";
                        break;
                    case "4-19":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "4-18":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "4-17":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "4-16":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "4-15":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "4-14":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "4-13":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "4-12":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "4-11":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "4-10":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "4-9":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "4-8":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "4-7":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "4-6":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "4-5":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;

                    #endregion

                    #region "Pago comision 5"
                    
                    case "5-24":
                        for (int i = 0; i < 19; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "19";
                        break;
                    case "5-23":
                        for (int i = 0; i < 18; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "18";
                        break;
                    case "5-22":
                        for (int i = 0; i < 17; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "17";
                        break;
                    case "5-21":
                        for (int i = 0; i < 16; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "16";
                        break;
                    case "5-20":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "5-19":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "5-18":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "5-17":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "5-16":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "5-15":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "5-14":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "5-13":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "5-12":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "5-11":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "5-10":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "5-9":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "5-8":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "5-7":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "5-6":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion
                                                
                    #region "Pago comision 6"
                    
                    case "6-24":
                        for (int i = 0; i < 18; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "18";
                        break;
                    case "6-23":
                        for (int i = 0; i < 17; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "17";
                        break;
                    case "6-22":
                        for (int i = 0; i < 16; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "16";
                        break;
                    case "6-21":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "6-20":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "6-19":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "6-18":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "6-17":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "6-16":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "6-15":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "6-14":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "6-13":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "6-12":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "6-11":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "6-10":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "6-9":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "6-8":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "6-7":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion


                    #region "Pago comision 7"

                    case "7-24":
                        for (int i = 0; i < 17; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "17";
                        break;
                    case "7-23":
                        for (int i = 0; i < 16; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "16";
                        break;
                    case "7-22":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "7-21":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "7-20":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "7-19":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "7-18":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "7-17":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "7-16":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "7-15":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "7-14":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "7-13":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "7-12":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "7-11":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "7-10":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "7-9":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "7-8":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion


                    #region "Pago comision 8"

                    case "8-24":
                        for (int i = 0; i < 16; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "16";
                        break;
                    case "8-23":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "8-22":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "8-21":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "8-20":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "8-19":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "8-18":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "8-17":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "8-16":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "8-15":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "8-14":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "8-13":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "8-12":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "8-11":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "8-10":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "8-9":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 9"

                    case "9-24":
                        for (int i = 0; i < 15; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "15";
                        break;
                    case "9-23":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "9-22":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "9-21":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "9-20":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "9-19":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "9-18":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "9-17":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "9-16":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "9-15":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "9-14":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "9-13":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "9-12":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "9-11":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "9-10":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 10"

                    case "10-24":
                        for (int i = 0; i < 14; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "14";
                        break;
                    case "10-23":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "10-22":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "10-21":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "10-20":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "10-19":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "10-18":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "10-17":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "10-16":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "10-15":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "10-14":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "10-13":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "10-12":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "10-11":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 11"

                    case "11-24":
                        for (int i = 0; i < 13; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "13";
                        break;
                    case "11-23":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "11-22":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "11-21":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "11-20":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "11-19":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "11-18":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "11-17":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "11-16":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "11-15":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "11-14":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "11-13":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "11-12":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 12"

                    case "12-24":
                        for (int i = 0; i < 12; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "12";
                        break;
                    case "12-23":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "12-22":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "12-21":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "12-20":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "12-19":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "12-18":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "12-17":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "12-16":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "12-15":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "12-14":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "12-13":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 13"

                    case "13-24":
                        for (int i = 0; i < 11; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "11";
                        break;
                    case "13-23":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "13-22":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "13-21":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "13-20":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "13-19":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "13-18":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "13-17":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "13-16":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "13-15":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "13-14":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 14"

                    case "14-24":
                        for (int i = 0; i < 10; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "10";
                        break;
                    case "14-23":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "14-22":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "14-21":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "14-20":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "14-19":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "14-18":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "14-17":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "14-16":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "14-15":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 15"

                    case "15-24":
                        for (int i = 0; i < 9; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "9";
                        break;
                    case "15-23":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "15-22":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "15-21":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "15-20":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "15-19":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "15-18":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "15-17":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "15-16":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 16"

                    case "16-24":
                        for (int i = 0; i < 8; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "8";
                        break;
                    case "16-23":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "16-22":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "16-21":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "16-20":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "16-19":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "16-18":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "16-17":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 17"

                    case "17-24":
                        for (int i = 0; i < 7; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "7";
                        break;
                    case "17-23":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "17-22":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "17-21":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "17-20":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "17-19":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "17-18":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 18"

                    case "18-24":
                        for (int i = 0; i < 6; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "6";
                        break;
                    case "18-23":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "18-22":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "18-21":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "18-20":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "18-19":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 19"

                    case "19-24":
                        for (int i = 0; i < 5; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "5";
                        break;
                    case "19-23":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "19-22":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "19-21":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "19-20":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 20"

                    case "20-24":
                        for (int i = 0; i < 4; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "4";
                        break;
                    case "20-23":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "20-22":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "20-21":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 21"

                    case "21-24":
                        for (int i = 0; i < 3; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "3";
                        break;
                    case "21-23":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "21-22":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 22"

                    case "22-24":
                        for (int i = 0; i < 2; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "2";
                        break;
                    case "22-23":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = mensaje1;
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #region "Pago comision 23"

                    case "23-24":
                        for (int i = 0; i < 1; i++)
                        {
                            string vecesComisiona = Convert.ToString(i++);
                            cmbVecesPagoComision.Items.Add(vecesComisiona);
                        }
                        lblMensajeComision.Text = "S e   p u e d e   p a g a r   l a   t o t a l i d a d   d e   l a s   c o m i s i o n e s.";
                        cmbVecesPagoComision.Text = "1";
                        break;
                    #endregion

                    #endregion
                }

            }
        }

                
    }
}