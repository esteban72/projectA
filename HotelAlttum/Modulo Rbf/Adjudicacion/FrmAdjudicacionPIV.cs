using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;
using System.Globalization;
using CarteraGeneral.WebServiceTRMColombia;

namespace CarteraGeneral.Modulo_Rbf.Adjudicacion
{
    public partial class FrmAdjudicacionPIV : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmAdjudicacionPIV()
        {
            InitializeComponent();
        }

        #region "Variables"
        public string EntradaAdjudicacion;
        double SumValorInicial = 0;
        double valorDolar;
        public double valorContrato = 0;
        int CuentaErrores, Consecutivo, numCuotasGridView = 0, contFila;
        int diaCtaInicial, mesCtaInicial, añoCtaInicial;
        DateTime fechaCuotaInicial;
        TCRMServicesInterfaceClient client = new TCRMServicesInterfaceClient();
        tcrmResponse response = default(tcrmResponse);

        System.Data.DataTable DtInmueble = new System.Data.DataTable();
        ClsIdentificacion conexion = new ClsIdentificacion();
        System.Data.DataTable DtTarifas = new System.Data.DataTable();
        #endregion

        #region "Load"

        private void FrmAdjudicacionPIV_Load(object sender, EventArgs e)
        {
            CmbGrado.Text = "Oro";
            CmbFormaPago.Text = "Credito";
            btnAdicionarAdj.Enabled = false;
            fechaCuotaInicial = dtpFechaCtaInicial.Value;
            diaCtaInicial = fechaCuotaInicial.Day;
            mesCtaInicial = fechaCuotaInicial.Month;
            añoCtaInicial = fechaCuotaInicial.Year;
            MtdLimpiar();
            MessageBox.Show("Si la adjudicación que va a ingresar no tiene pagos iniciales, \npor favor indiquelo en el cajón de observaciones\n" +
            "y deje el campo de N° de cuotas pagadas en 0.", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region "Botones"

        private void BtnBscReserva_Click(object sender, EventArgs e)
        {
            FrmCatalogoReservas reservas = new FrmCatalogoReservas();
            reservas.ShowDialog();
            TxtReserva.Text = FrmCatalogoReservas.VarIdReserva;
            TxtContrato.Text = FrmCatalogoReservas.VarContrato;
            TxtTitular1.Text = FrmCatalogoReservas.VarIdTercero;
            LblNombreTitular.Text = FrmCatalogoReservas.VarCliente;
            TxtInmueble.Text = FrmCatalogoReservas.VarIdInmueble;
            lblTipo.Text = FrmCatalogoReservas.VarTipoReserva;
            valorContrato = Convert.ToDouble(conexion.valorContrato("select ValorContrato from reservas where contrato = '" + TxtContrato.Text + "'"));
            TxtValorContrato.Text = valorContrato.ToString();
            if (TxtInmueble.Text != "")
            {
                DtInmueble = conexion.MtdBuscarDataset("Select Villa,Unidad,Semana,Temporada from Inmuebles  Where IdInmueble = '" + TxtInmueble.Text + "'");
                lblVilla.Text = DtInmueble.Rows[0][0].ToString();
                lblUnidad.Text = DtInmueble.Rows[0][1].ToString();
                lblSemana.Text = DtInmueble.Rows[0][2].ToString();
                lblTemporada.Text = DtInmueble.Rows[0][3].ToString();
                MtdValidarTarifas(lblTipo.Text, CmbGrado.Text.ToUpper(), lblTemporada.Text);
                TxtObservacion.Focus();
            }

            lblMensajeContrato.Text = "";
            lblErrorTitular1.Text = "";
        }

        private void BtnBuscarTitular1_Click(object sender, EventArgs e)
        {
            FrmCatalogoTerceros catalogo = new FrmCatalogoTerceros();
            catalogo.VarTipoTercero = "Clientes";
            catalogo.ShowDialog();
            TxtTitular1.Text = FrmCatalogoTerceros.VarIdTercero;
            LblNombreTitular.Text = FrmCatalogoTerceros.VarNombreTercero;
        }

        private void BtnBuscarTitular2_Click(object sender, EventArgs e)
        {
            FrmCatalogoTerceros catalogo = new FrmCatalogoTerceros();
            catalogo.VarTipoTercero = "Clientes";
            catalogo.ShowDialog();
            TxtTitular2.Text = FrmCatalogoTerceros.VarIdTercero;
            LblNombreTitular2.Text = FrmCatalogoTerceros.VarNombreTercero;
        }

        private void BtnBuscarTitular3_Click(object sender, EventArgs e)
        {
            FrmCatalogoTerceros catalogo = new FrmCatalogoTerceros();
            catalogo.VarTipoTercero = "Clientes";
            catalogo.ShowDialog();
            TxtTitular3.Text = FrmCatalogoTerceros.VarIdTercero;
            LblNombreTitular3.Text = FrmCatalogoTerceros.VarNombreTercero;
        }

        private void btnAdicionar_ItemClick(object sender, ItemClickEventArgs e)
        {
            MtdAdicionar();
        }

        private void btnValidar_ItemClick(object sender, ItemClickEventArgs e)
        {
            sumaValoresDvgCtaInicial();
            MtdValidarAdd();
            calcularFinanciacion();
            calcularValorCuotas();
            if (validarFilas(DgvCtaInicial))
            {
                if (CuentaErrores == 0)
                {
                    double cuotaInicial = 0, Financiacion = 0, totalFinanciacion = 0;
                    if (txtValorIni.Text == "")
                    {
                        cuotaInicial = 0;
                        
                    }
                    else
                    {
                        cuotaInicial = Convert.ToDouble(txtValorIni.Text);
                    }
                    Financiacion = Convert.ToDouble(lblValorTotalFnc.Text);
                    totalFinanciacion = cuotaInicial + Financiacion;                    
                    txtTotalFinanciacion.Text = totalFinanciacion.ToString("###,###");
                    double dolarTope = Convert.ToDouble(txtDolarTope.Text);
                    if (chkDolarTope.Checked && dolarTope > 0)
                    {
                        txtTRMContrato.Text = txtDolarTope.Text;
                        valorDolar = Convert.ToDouble(txtDolarTope.Text);
                    }
                    else
                    {
                        DateTime fechaContrato;
                        fechaContrato = DtpFechaContrato.Value;
                        response = client.queryTCRM(fechaContrato);
                        string TRM_FechaContrato = response.value.ToString("###,###.###");
                        txtTRMContrato.Text = TRM_FechaContrato;
                        valorDolar = response.value;
                    }

                    //double valContrato = Convert.ToDouble(TxtValorContrato.Text);
                    txtValContratoPesos.Text = (Convert.ToDouble(TxtValorContrato.Text) * valorDolar).ToString("###,###.###");
                    switch (CmbFormaPago.Text)
                    {
                        case "Credicontado":
                            MtdoDatosCredito();
                            break;

                        case "Credito":
                            MtdoDatosCredito();
                            break;

                        default:
                            break;
                    }
                }
            }
            else
            {
                MessageBox.Show("No pueden haber cuotas con valores en 0.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdicionarAdj.Enabled = false;
            }
        }

        private void btnLimpiar_ItemClick(object sender, ItemClickEventArgs e)
        {
            MtdLimpiar();
            MtdLimpiar();
        }

        private void btnConsultarTRM_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTRM TRM = new FrmTRM();
            TRM.Show();
        }

        private void btnEliminarFila_Click(object sender, EventArgs e)
        {
            try
            {
                if (DgvCtaInicial.Rows.Count - 1 > 0)
                {
                    EliminarFilas();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se puede eliminar esta fila.\n" +
                "Verificar que haya una fila seleccionada.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region "Metodos"

        private void EliminarFilas()
        {
            contFila = Convert.ToInt32(DgvCtaInicial.CurrentRow.Index.ToString());
            if (Convert.ToString(DgvCtaInicial.Rows[contFila].Cells[0].Value) != "" || Convert.ToString(DgvCtaInicial.Rows[contFila].Cells[1].Value) != "" ||
                Convert.ToString(DgvCtaInicial.Rows[contFila].Cells[2].Value) != "" || Convert.ToString(DgvCtaInicial.Rows[contFila].Cells[3].Value) != "")
            {
                DgvCtaInicial.Rows.RemoveAt(DgvCtaInicial.CurrentRow.Index);
                numCuotasGridView--;
                sumaValoresDvgCtaInicial();
                mesCtaInicial--;
                if (mesCtaInicial == 0 && añoCtaInicial > Convert.ToInt32(DgvCtaInicial.Rows[contFila - 1].Cells[2].Value))
                {
                    añoCtaInicial--;
                }
                lblMensajeNumCuotas.Text = "Se han ingresado " + numCuotasGridView + " cuotas iniciales.";

            }
            else
            {
                SumValorInicial -= double.Parse(DgvCtaInicial.Rows[contFila].Cells[3].Value.ToString(), CultureInfo.InvariantCulture);
                SumValorInicial = Math.Round(SumValorInicial);
                txtValorIni.Text = SumValorInicial.ToString("###,###.###");
                DgvCtaInicial.Rows.RemoveAt(DgvCtaInicial.CurrentRow.Index);
                numCuotasGridView--;
                mesCtaInicial--;
                if (mesCtaInicial == 0)
                {
                    añoCtaInicial--;
                }

                if ((DgvCtaInicial.Rows.Count - 1) > 1)
                {
                    CalcularNumCuotas();
                }
                else
                {
                    lblMensajeNumCuotas.Text = "Se han ingresado " + numCuotasGridView + " cuotas iniciales.";
                }
                if ((DgvCtaInicial.Rows.Count - 1) == 0)
                {
                    txtValorIni.Text = "0";
                }
            }
        }

        public void MtdValidarTarifas(string categ, string grado, string temporada)
        {
            decimal valorcon = 0;
            var query = (from DtCargos1 in DtTarifas.AsEnumerable()
                         where DtCargos1.Field<string>("Categoria") == categ && DtCargos1.Field<string>("Grado") == grado && DtCargos1.Field<string>("Temporada") == temporada
                         select new
                         {
                             valorsemana = DtCargos1.Field<decimal>("Valor"),
                         });

            foreach (var order in query)
            {
                valorcon = order.valorsemana;
            }

            //TxtValorContrato.Text = valorcon.ToString();

            //this.TxtValorContrato.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtValorContrato.Text));
        }

        private void MtdValidarAdd()
        {
            try
            {
                CuentaErrores = 0;
                lblMensajeValor.Text = "";
                lblErrorTitular1.Text = "";
                lblMensajeContrato.Text = "";
                lblMensajeGrado.Text = "";
                lblMensajeValor.Text = "";
                lblMensajeFormaPago.Text = "";
                lblErrorValorFnc.Text = "";
                lblErrorCtaInicial.Text = "";

                if (TxtTitular1.Text == "" && TxtTitular2.Text == "" && TxtTitular3.Text == "")
                {
                    lblErrorTitular1.Text = "Tiene que haber por lo menos un titular.";
                    CuentaErrores++;
                }

                if (Convert.ToDecimal(TxtValorContrato.Text) <= 0)
                {
                    lblMensajeValor.Text = "El valor no puede ser 0.";
                    CuentaErrores++;
                }

                if (TxtContrato.Text == "" || TxtContrato.Text == "0")
                {
                    lblMensajeContrato.Text = "Ingrese número de contrato.";
                    CuentaErrores++;
                }


                if (CmbFormaPago.Text == "")
                {
                    lblMensajeFormaPago.Text = "Seleccione la forma de pago.";
                    CuentaErrores++;
                }

                if (TxtValorFnc.Text == "0" || TxtValorFnc.Text == "")
                {
                    lblErrorValorFnc.Text = "Ingrese el valor\ncorrecto.";
                    CuentaErrores++;
                    if (PnlDatosFnc.Enabled == false && (DgvCtaInicial.Rows.Count - 1) > 1)
                    {
                        lblErrorValorFnc.Text = "";
                        CuentaErrores--;
                    }
                }

                if (CmbGrado.Text == "")
                {
                    lblMensajeGrado.Text = "Seleccione el \ngrado del contrato.";
                    CuentaErrores++;
                }


                if (Convert.ToDouble(TxtValorFnc.Text) > Convert.ToDouble(TxtValorContrato.Text))
                {
                    lblErrorValorFnc.Text = "El valor de la financiación no\npuede ser mayor al valor del contrato.";
                    CuentaErrores++;
                }

                for (int i = 0; i < (DgvCtaInicial.Rows.Count - 1); i++)
                {
                    if (DgvCtaInicial.Rows[i].Cells[0].Value == null || Convert.ToString(DgvCtaInicial.Rows[i].Cells[0].Value) == ""
                        || DgvCtaInicial.Rows[i].Cells[1].Value == null || Convert.ToString(DgvCtaInicial.Rows[i].Cells[1].Value) == ""
                        || DgvCtaInicial.Rows[i].Cells[2].Value == null || Convert.ToString(DgvCtaInicial.Rows[i].Cells[2].Value) == "")
                    {

                        lblErrorCtaInicial.Text = "Las fechas de la couta inicial no pueden tener valores en blanco.";
                        CuentaErrores++;
                    }
                    if ((Convert.ToDouble(DgvCtaInicial.Rows[i].Cells[3].Value) != 0 && Convert.ToInt32(DgvCtaInicial.Rows[i].Cells[5].Value) == 0)
                        || (Convert.ToDouble(DgvCtaInicial.Rows[i].Cells[3].Value) != 0 && DgvCtaInicial.Rows[i].Cells[5].Value == null)
                    || (Convert.ToDouble(DgvCtaInicial.Rows[i].Cells[3].Value) != 0 && Convert.ToString(DgvCtaInicial.Rows[i].Cells[5].Value) == ""))
                    {
                        lblErrorCtaInicial.Text = "El número del recibo no puede estar en 0 o en blanco.";
                        CuentaErrores++;
                    }
                }


                if (chkDolarTope.Checked == true && (txtDolarTope.Text == "0" || txtDolarTope.Text == ""))
                {
                    lblDolarTope.Text = "Este campo esta\nhabilitado, por lo\ntanto no puede\ntener valores\nen 0.";
                    CuentaErrores++;
                }


                if (CuentaErrores == 0)
                {
                    btnAdicionarAdj.Enabled = true;
                    DgvCuotas.Enabled = true;
                }
                else
                {
                    DgvCuotas.Enabled = false;
                    btnAdicionarAdj.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Recuerde no dejar campos en blanco.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MtdLimpiar()
        {
            TxtReserva.Text = "";
            TxtContrato.Text = "";
            lblMensajeContrato.Text = "";
            TxtTitular1.Text = "";
            lblErrorTitular1.Text = "";
            LblNombreTitular.Text = "";
            TxtTitular2.Text = "";
            LblNombreTitular2.Text = "";
            TxtTitular3.Text = "";
            LblNombreTitular3.Text = "";
            TxtInmueble.Text = "";
            lblVilla.Text = "";
            lblUnidad.Text = "";
            lblSemana.Text = "";
            lblTemporada.Text = "";
            lblTipo.Text = "";
            TxtObservacion.Text = "";
            CmbGrado.Text = "";
            lblMensajeGrado.Text = "";
            TxtValorContrato.Text = "0";
            lblMensajeValor.Text = "";
            CmbFormaPago.Text = "";
            lblMensajeFormaPago.Text = "";
            txtValorIni.Text = "0";
            DgvCuotas.Text = "0";
            TxtValorFnc.Text = "0";
            lblErrorValorFnc.Text = "";
            lblValorTotalFnc.Text = "0";
            lblMensajeNumCuotas.Text = "";
            lblErrorCtaInicial.Text = "";
            lblErrorCtaInicial.Text = "";
            txtCtasFnc.Text = "0";
            txtTotalFinanciacion.Text = "0";
            txtTRMContrato.Text = "0";
            txtValContratoPesos.Text = "0";
            lblDolarTope.Text = "";
            txtDolarTope.Text = "0";
            lblErrorCuotasFnc.Text = "";
            DgvCtaInicial.Rows.Clear();
            DgvCuotas.Rows.Clear();
            btnAdicionarAdj.Enabled = false;
        }

        private void CalcularNumCuotas()
        {
            try
            {
                numCuotasGridView = DgvCtaInicial.Rows.Count - 1;
                if (numCuotasGridView == 1)
                {
                    lblMensajeNumCuotas.Text = "Se ha ingresado 1 cuota inicial.";
                }
                else
                {
                    lblMensajeNumCuotas.Text = "Se han ingresado " + numCuotasGridView + " cuotas iniciales.";
                }

                if (numCuotasGridView > 24)
                {
                    EliminarFilas();
                    MessageBox.Show("No se pueden ingresar más de 24 cuotas iniciales.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                lblMensajeNumCuotas.Text = "Error: " + ex.Message;
            }
        }

        private void MtdoDatosCredito()
        {
            int contCuotasSinPago = (DgvCtaInicial.Rows.Count - 1);
            int ctasFnc = Convert.ToInt32(txtCtasFnc.Text);
            int periodo = 0;
            int dia, mes, año;

            double SumaCapital = 0, sumaCuotas = 0, sumaCapitalUSD = 0, sumaCuotasUSD = 0;
            System.Data.DataTable credito = new System.Data.DataTable();
            DateTime FechaIni, FechaFnc;
            double CapitalIni = 0, valorRestoCuotas = 0;
            int NumCuota = 0, NumRecibo = 0;

            switch (CmbPeriodoFnc.Text)
            {
                case "30":
                    periodo = 1;
                    break;
                case "60":
                    periodo = 2;
                    break;
                case "90":
                    periodo = 3;
                    break;
                case "120":
                    periodo = 4;
                    break;
                case "150":
                    periodo = 5;
                    break;
                default:
                    break;
            }

            DgvCuotas.Rows.Clear();
            if (contCuotasSinPago > 0)
            {
                int siguiente = 0;
                for (int i = 0; i < contCuotasSinPago; i++)
                {
                    NumCuota++;
                    FechaIni = Convert.ToDateTime(Convert.ToString(DgvCtaInicial.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[2].Value));
                    CapitalIni = Math.Round(double.Parse(DgvCtaInicial.Rows[i].Cells[3].Value.ToString(), CultureInfo.InvariantCulture), 2);
                    valorRestoCuotas = Convert.ToDouble(DgvCtaInicial.Rows[i].Cells[4].Value.ToString());
                    NumRecibo = Convert.ToInt32(DgvCtaInicial.Rows[i].Cells[5].Value.ToString());
                    DgvCuotas.Rows.Add("CI", NumCuota, FechaIni, CapitalIni, (CapitalIni * valorDolar), valorRestoCuotas, (valorRestoCuotas * valorDolar), NumRecibo);
                    siguiente++;
                }

                if (ctasFnc > 0)
                {
                    FechaFnc = DtpInicioFnc.Value;
                    int indexFechaSinPago = (DgvCtaInicial.Rows.Count - 2);
                    dia = FechaFnc.Day;
                    mes = FechaFnc.Month;
                    año = FechaFnc.Year;
                    int cont = periodo;
                    for (int i = 0; i < ctasFnc; i++)
                    {
                        NumCuota++;
                        switch (mes)
                        {
                            case 13:
                                mes = 1;
                                año++;
                                break;
                            case 14:
                                mes = 2;
                                año++;
                                break;
                            case 15:
                                mes = 3;
                                año++;
                                break;
                            case 16:
                                mes = 4;
                                año++;
                                break;
                            default:
                                break;
                        }

                        if (dia >= 29 && mes == 2)
                        {
                            dia = 28;
                        }
                        else
                        {
                            dia = FechaFnc.Day;
                        }

                        FechaIni = Convert.ToDateTime(dia + "-" + mes + "-" + año);
                        DgvCuotas.Rows.Add("FN", NumCuota, FechaIni, 0, 0, Convert.ToDouble(TxtValorFnc.Text), Math.Round(Convert.ToDouble(TxtValorFnc.Text) * valorDolar, 2));
                        mes += periodo;

                    }
                }
            }
            else
            {
                if (ctasFnc > 0)
                {
                    FechaFnc = DtpInicioFnc.Value;
                    int indexFechaSinPago = (DgvCtaInicial.Rows.Count - 2);
                    dia = FechaFnc.Day;
                    mes = FechaFnc.Month;
                    año = FechaFnc.Year;
                    int cont = periodo;
                    for (int i = 0; i < ctasFnc; i++)
                    {
                        NumCuota++;
                        switch (mes)
                        {
                            case 13:
                                mes = 1;
                                año++;
                                break;
                            case 14:
                                mes = 2;
                                año++;
                                break;
                            case 15:
                                mes = 3;
                                año++;
                                break;
                            case 16:
                                mes = 4;
                                año++;
                                break;
                            default:
                                break;
                        }

                        if (dia >= 29 && mes == 2)
                        {
                            dia = 28;
                        }
                        else
                        {
                            dia = FechaFnc.Day;
                        }

                        FechaIni = Convert.ToDateTime(dia + "-" + mes + "-" + año);
                        DgvCuotas.Rows.Add("FN", NumCuota, FechaIni, 0, 0, Convert.ToDouble(TxtValorFnc.Text), Math.Round(Convert.ToDouble(TxtValorFnc.Text) * valorDolar, 2));
                        mes += periodo;

                    }
                }
            }
            for (int i = 0; i < (DgvCuotas.Rows.Count); i++)
            {
                sumaCapitalUSD += Convert.ToDouble(DgvCuotas.Rows[i].Cells[3].Value);
                SumaCapital += Convert.ToDouble(DgvCuotas.Rows[i].Cells[4].Value);
                sumaCuotasUSD += Convert.ToDouble(DgvCuotas.Rows[i].Cells[5].Value);
                sumaCuotas += Convert.ToDouble(DgvCuotas.Rows[i].Cells[6].Value);
            }
            int contFilasDvgCuotas = DgvCuotas.Rows.Count - 1;
            DgvCuotas.Rows[contFilasDvgCuotas].Cells[2].Value = "T O T A L  . .";
            DgvCuotas.Rows[contFilasDvgCuotas].Cells[3].Value = sumaCapitalUSD;
            DgvCuotas.Rows[contFilasDvgCuotas].Cells[4].Value = SumaCapital;
            DgvCuotas.Rows[contFilasDvgCuotas].Cells[5].Value = sumaCuotasUSD;
            DgvCuotas.Rows[contFilasDvgCuotas].Cells[6].Value = sumaCuotas;
            DgvCuotas.Rows[contFilasDvgCuotas].DefaultCellStyle.BackColor = Color.Blue;
            DgvCuotas.Rows[contFilasDvgCuotas].DefaultCellStyle.ForeColor = Color.White;

        }

        private void calcularFinanciacion()
        {
            double valorFinanciacion = Convert.ToDouble(TxtValorFnc.Text);
            double valorContrato = Convert.ToDouble(TxtValorContrato.Text);
            double valorInicial = Convert.ToDouble(txtValorIni.Text);
            double numCuotasFnc = Convert.ToDouble(txtCtasFnc.Text);
            double totalFnc = 0;
            if (valorFinanciacion > 0 && numCuotasFnc > 0)
            {
                lblErrorValorFnc.Text = "";
                totalFnc = valorContrato - valorInicial;
                lblValorTotalFnc.Text = totalFnc.ToString("###,###.###");
            }

            if (valorFinanciacion > 0)
            {
                lblErrorValorFnc.Text = "";
            }
            else
            {
                lblErrorValorFnc.Text = "Ingrese el valor correcto.";
            }
        }

        private void calcularValorCuotas()
        {
            try
            {
                double valorFinanciacion = Convert.ToDouble(TxtValorFnc.Text);
                double numCuotasFnc = Convert.ToDouble(txtCtasFnc.Text);
                double totalFnc = 0;
                if (valorFinanciacion > 0 && numCuotasFnc > 0)
                {
                    lblErrorValorFnc.Text = "";
                    totalFnc = valorFinanciacion * numCuotasFnc;
                    txtSumaFnc.Text = totalFnc.ToString("###,###.###");
                }

                if (valorFinanciacion > 0)
                {
                    lblErrorValorFnc.Text = "";
                }
                else
                {
                    lblErrorValorFnc.Text = "Ingrese el valor correcto.";
                }
            }
            catch (Exception)
            {
                lblErrorValorFnc.Text = "Ingrese el valor correcto.";
            }
        }

        private bool validarFilas(DataGridView grid)
        {
            int filas = grid.Rows.Count - 1;
            for (int i = 0; i < filas; i++)
            {
                if (Convert.ToDouble(grid.Rows[i].Cells[3].Value) == 0 && Convert.ToDouble(grid.Rows[i].Cells[4].Value) == 0)
                {
                    lblErrorCtaInicial.Text = "Hay registros que tienen los 2 campos 'Pagado' y 'Pendiente pago' en 0.";
                    CuentaErrores++;
                    return false;
                }
            }
            return true;
        }

        private void sumaValoresDvgCtaInicial()
        {
            SumValorInicial = 0;
            int filas = DgvCtaInicial.Rows.Count - 1;
            for (int i = 0; i < filas; i++)
            {
                if ((Convert.ToString(DgvCtaInicial.Rows[i].Cells[4].Value)) == "")
                {
                    DgvCtaInicial.Rows[i].Cells[4].Value = 0;
                }
                else
                {
                    SumValorInicial += Convert.ToDouble(DgvCtaInicial.Rows[i].Cells[3].Value);
                }
                if(Convert.ToDouble(DgvCtaInicial.Rows[i].Cells[4].Value) > 0){
                    SumValorInicial += Convert.ToDouble(DgvCtaInicial.Rows[i].Cells[4].Value);
                }
            }
            if(SumValorInicial > 0){
                SumValorInicial = Math.Round(SumValorInicial, 3);
                txtValorIni.Text = SumValorInicial.ToString("###,###.###");
            }
            else
            {
                txtValorIni.Text = "0";
            }
            
        }

        private void validarCasillas()
        {
            double valorContrato = Convert.ToDouble(TxtValorContrato.Text);

            if (valorContrato > 0)
            {
                PnlCtaInicialSinPagar.Enabled = true;
                PnlDatosFnc.Enabled = true;
                PnlTotalFnc.Enabled = true;
                lblMensajeValor.Text = "";
            }
            else
            {
                lblMensajeValor.Text = "Debe ingresar el valor\ndel contrato.";
                PnlCtaInicialSinPagar.Enabled = false;
                PnlDatosFnc.Enabled = false;
                PnlTotalFnc.Enabled = false;
            }

        }

        private void MtdAdicionar()
        {
            string VarIdCta, VarConcepto, idtransacciones, ConsecutivoRecaudo, mesConvertido = "";
            decimal VarCapital, VarCuota, varCapitalUSD, varCuotaUSD;
            int VarNumcuota, contCI = 0, contConsecutivo = 0, mesCuota;
            DateTime VarFecha;
            MtdValidarAdd();
            if (CuentaErrores > 0)
            {
                MessageBox.Show("Por favor corrija los campos con error.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Adicionar este registro", "Adicionar Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    Consecutivo = conexion.siguienteAdjudicacion("select if(max(IdAdjudicacion)is null,1,max(IdAdjudicacion+1)) as 'Sig consecutivo Adj' from Adjudicacion");
                    idtransacciones = conexion.MtdBscDatos("Select Consecutivo from Contabilidad_alttum.Documento where IdComprobante = 99");
                    ConsecutivoRecaudo = conexion.MtdBscDatos("select if(max(IdRecaudo)is null,1,max(IdRecaudo+1))from datosrecaudos");
                    if (Consecutivo != 0)
                    {


                        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                        string StrAddAdjudicacion = " INSERT INTO adjudicacion (IdAdjudicacion, Fecha, FechaContrato, Contrato, IdProyecto, IdTercero1, IdTercero2, Idtercero3," +
                        "IdInmueble, TipodeAdjudicacion, Temporada, Grado, FormaPago, Valor, CuotaInicial, Financiacion, PlazoFnc, " +
                        "CuotaFnc, InicioFnc, Estado, Usuario, FechaOperacion, Porcentaje, TipoOperacion, Observacion, Trm, ValorContratoUSD, CuotaInicialUSD, FinanciacionUSD, CuotaFncUSD, MarcaDolarTecho) " +

                        "VALUES ( @IdAdjudicacion, @Fecha, @FechaContrato, @Contrato, @IdProyecto, @IdTercero1, @IdTercero2, @Idtercero3, @IdInmueble, @TipodeAdjudicacion, @Temporada, @Grado," +
                        "@FormaPago, @Valor, @CuotaInicial, @Financiacion, @PlazoFnc, @CuotaFnc, @InicioFnc, @Estado, @Usuario, @FechaOperacion, " +
                        "@Porcentaje, @TipoOperacion, @Observacion, @Trm, @ValorContratoUSD, @CuotaInicialUSD, @FinanciacionUSD, @CuotaFncUSD, @MarcaDolarTecho)";

                        string StrAddFnc = "insert into financiacion (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital_USD, Capital,Cuota_USD,Cuota,SaldoCapital,SaldoCuota,UltimaFechaPago,Usuario,FechaOperacion) " +
                                                         "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital_USD,@Capital,@Cuota_USD,@Cuota,@Capital,@Cuota,@FechaFnc,@Usuario,@FechaOperacion)";

                        string StrModReserva = "Update Reservas Set Estado = 'Adjudicado',IdAdjudicacion =@IdAdjudicacion Where idReserva ='" + TxtReserva.Text + "'";

                        string StrModInmuebles = "Update Inmuebles Set Estado = 'Adjudicado' Where IdInmueble ='" + TxtInmueble.Text + "'";

                        MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                        MysqlConexion.Open();
                        MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                        MySqlTransaction myTrans;
                        myTrans = MysqlConexion.BeginTransaction();
                        CmdAddPrm.Connection = MysqlConexion;
                        CmdAddPrm.Transaction = myTrans;
                        try
                        {
                            CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                            CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                            CmdAddPrm.Parameters.Add("@FechaContrato", MySql.Data.MySqlClient.MySqlDbType.Date);
                            CmdAddPrm.Parameters.Add("@Contrato", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@IdProyecto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@TipodeAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Temporada", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Grado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@IdTercero1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@IdTercero2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@IdTercero3", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@FormaPago", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Double);
                            CmdAddPrm.Parameters.Add("@CuotaInicial", MySql.Data.MySqlClient.MySqlDbType.Double);
                            CmdAddPrm.Parameters.Add("@Financiacion", MySql.Data.MySqlClient.MySqlDbType.Double);
                            CmdAddPrm.Parameters.Add("@PlazoFnc", MySql.Data.MySqlClient.MySqlDbType.Int16);
                            CmdAddPrm.Parameters.Add("@CuotaFnc", MySql.Data.MySqlClient.MySqlDbType.Double);
                            CmdAddPrm.Parameters.Add("@InicioFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                            CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                            CmdAddPrm.Parameters.Add("@Porcentaje", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                            CmdAddPrm.Parameters.Add("@TipoOperacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Observacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@IdCta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@FechaFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                            CmdAddPrm.Parameters.Add("@Capital_USD", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                            CmdAddPrm.Parameters.Add("@Capital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                            CmdAddPrm.Parameters.Add("@Cuota_USD", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                            CmdAddPrm.Parameters.Add("@Cuota", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                            CmdAddPrm.Parameters.Add("@NumCuota", MySql.Data.MySqlClient.MySqlDbType.Int16);
                            CmdAddPrm.Parameters.Add("@Trm", MySql.Data.MySqlClient.MySqlDbType.Double);
                            CmdAddPrm.Parameters.Add("@ValorContratoUSD", MySql.Data.MySqlClient.MySqlDbType.Double);
                            CmdAddPrm.Parameters.Add("@CuotaInicialUSD", MySql.Data.MySqlClient.MySqlDbType.Double);
                            CmdAddPrm.Parameters.Add("@FinanciacionUSD", MySql.Data.MySqlClient.MySqlDbType.Double);
                            CmdAddPrm.Parameters.Add("@CuotaFncUSD", MySql.Data.MySqlClient.MySqlDbType.Double);
                            CmdAddPrm.Parameters.Add("@MarcaDolarTecho", MySql.Data.MySqlClient.MySqlDbType.Binary);

                            //Variables de abajo para la insercion en datosrecaudos
                            CmdAddPrm.Parameters.Add("@IdRecaudo", MySql.Data.MySqlClient.MySqlDbType.Int32);
                            CmdAddPrm.Parameters.Add("@NumRecibo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@DetalleRec", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                            CmdAddPrm.Parameters.Add("@Transaccion", MySql.Data.MySqlClient.MySqlDbType.Int32);

                            //Variables para la insercion en recaudos
                            CmdAddPrm.Parameters.Add("@IdFinanciacion", MySql.Data.MySqlClient.MySqlDbType.String);
                            CmdAddPrm.Parameters.Add("@FechaCuota", MySql.Data.MySqlClient.MySqlDbType.Date);
                            CmdAddPrm.Parameters.Add("@EstadoRec", MySql.Data.MySqlClient.MySqlDbType.String);
                            CmdAddPrm.Parameters.Add("@Periodo", MySql.Data.MySqlClient.MySqlDbType.Int32);

                            CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                            CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                            CmdAddPrm.Parameters["@FechaContrato"].Value = DtpFechaContrato.Value;
                            CmdAddPrm.Parameters["@Contrato"].Value = TxtContrato.Text;
                            CmdAddPrm.Parameters["@IdProyecto"].Value = FrmLogeo.Proyecto;
                            CmdAddPrm.Parameters["@IdInmueble"].Value = TxtInmueble.Text;
                            CmdAddPrm.Parameters["@TipodeAdjudicacion"].Value = lblTipo.Text;
                            CmdAddPrm.Parameters["@Temporada"].Value = lblTemporada.Text;
                            CmdAddPrm.Parameters["@Grado"].Value = CmbGrado.Text;
                            CmdAddPrm.Parameters["@IdTercero1"].Value = TxtTitular1.Text;
                            if (TxtTitular2.Text == "")
                            {
                                CmdAddPrm.Parameters["@IdTercero2"].Value = null;
                            }
                            else
                            {
                                CmdAddPrm.Parameters["@IdTercero2"].Value = TxtTitular2.Text;
                            }
                            if (TxtTitular3.Text == "")
                            {
                                CmdAddPrm.Parameters["@IdTercero3"].Value = null;
                            }
                            else
                            {
                                CmdAddPrm.Parameters["@IdTercero3"].Value = TxtTitular3.Text;
                            }
                            int indexCuotas = Convert.ToInt32(DgvCuotas.Rows.Count - 1);
                            CmdAddPrm.Parameters["@FormaPago"].Value = CmbFormaPago.Text;
                            CmdAddPrm.Parameters["@Valor"].Value = Convert.ToDouble(txtValContratoPesos.Text);
                            CmdAddPrm.Parameters["@CuotaInicial"].Value = Math.Ceiling(Convert.ToDouble(DgvCuotas.Rows[indexCuotas].Cells[4].Value));
                            CmdAddPrm.Parameters["@Financiacion"].Value = Convert.ToDouble(lblValorTotalFnc.Text) * valorDolar;
                            CmdAddPrm.Parameters["@PlazoFnc"].Value = Convert.ToInt16(txtCtasFnc.Text);
                            CmdAddPrm.Parameters["@CuotaFnc"].Value = Convert.ToDouble(TxtValorFnc.Text) * valorDolar;
                            CmdAddPrm.Parameters["@InicioFnc"].Value = DtpInicioFnc.Value;
                            CmdAddPrm.Parameters["@Estado"].Value = "Pendiente";
                            CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                            CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                            CmdAddPrm.Parameters["@TipoOperacion"].Value = "PIV";
                            CmdAddPrm.Parameters["@Porcentaje"].Value = 0;
                            CmdAddPrm.Parameters["@Observacion"].Value = TxtObservacion.Text;
                            if(chkDolarTope.Checked){
                                CmdAddPrm.Parameters["@MarcaDolarTecho"].Value = 1;
                                CmdAddPrm.Parameters["@Trm"].Value = Convert.ToDouble(txtDolarTope.Text);
                            }
                            else
                            {
                                CmdAddPrm.Parameters["@Trm"].Value = Convert.ToDouble(txtTRMContrato.Text);
                            }
                            
                            CmdAddPrm.Parameters["@ValorContratoUSD"].Value = Convert.ToDouble(TxtValorContrato.Text);
                            CmdAddPrm.Parameters["@CuotaInicialUSD"].Value = Convert.ToDouble(txtValorIni.Text);
                            CmdAddPrm.Parameters["@FinanciacionUSD"].Value = Convert.ToDouble(lblValorTotalFnc.Text);
                            CmdAddPrm.Parameters["@CuotaFncUSD"].Value = Convert.ToDouble(TxtValorFnc.Text);

                            CmdAddPrm.CommandText = StrAddAdjudicacion;
                            CmdAddPrm.ExecuteNonQuery();

                            for (int i = 0; i < DgvCuotas.Rows.Count - 1; i++)
                            {
                                if (DgvCuotas.Rows[i].Cells[0].Value.ToString() == "CI" && Convert.ToInt32(DgvCuotas.Rows[i].Cells[7].Value.ToString()) > 0)
                                {
                                    contCI++;
                                }
                                VarConcepto = DgvCuotas.Rows[i].Cells[0].Value.ToString();
                                VarNumcuota = Convert.ToInt16(DgvCuotas.Rows[i].Cells[1].Value);
                                VarIdCta = VarConcepto + VarNumcuota + "ADJ" + Consecutivo;
                                VarFecha = Convert.ToDateTime(DgvCuotas.Rows[i].Cells[2].Value);
                                varCapitalUSD = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[3].Value);
                                VarCapital = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value);
                                varCuotaUSD = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[5].Value);
                                VarCuota = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[6].Value);

                                CmdAddPrm.Parameters["@IdCta"].Value = VarIdCta;
                                CmdAddPrm.Parameters["@Concepto"].Value = VarConcepto;
                                CmdAddPrm.Parameters["@FechaFnc"].Value = VarFecha;
                                CmdAddPrm.Parameters["@Capital_USD"].Value = varCapitalUSD;
                                CmdAddPrm.Parameters["@Capital"].Value = VarCapital;
                                CmdAddPrm.Parameters["@Cuota_USD"].Value = varCuotaUSD;
                                CmdAddPrm.Parameters["@Cuota"].Value = VarCuota;
                                CmdAddPrm.Parameters["@NumCuota"].Value = VarNumcuota;

                                CmdAddPrm.CommandText = StrAddFnc;
                                CmdAddPrm.ExecuteNonQuery();

                                CmdAddPrm.CommandText = StrModReserva;
                                CmdAddPrm.ExecuteNonQuery();

                                CmdAddPrm.CommandText = StrModInmuebles;
                                CmdAddPrm.ExecuteNonQuery();
                            }

                            for (int i = 0; i < contCI; i++)
                            {
                                //Se realiza insercion en datosrecaudos
                                CmdAddPrm.Parameters["@IdRecaudo"].Value = ConsecutivoRecaudo;
                                CmdAddPrm.Parameters["@Fecha"].Value = Convert.ToDateTime(Convert.ToString(DgvCuotas.Rows[i].Cells[2].Value));
                                CmdAddPrm.Parameters["@NumRecibo"].Value = DgvCuotas.Rows[i].Cells[7].Value.ToString();
                                CmdAddPrm.Parameters["@IdTercero"].Value = TxtTitular1.Text;
                                CmdAddPrm.Parameters["@Operacion"].Value = "Cuota Inicial";
                                CmdAddPrm.Parameters["@Valor"].Value = Convert.ToDecimal(Convert.ToString(DgvCuotas.Rows[i].Cells[4].Value));
                                CmdAddPrm.Parameters["@FormaPago"].Value = "Bancolombia";
                                CmdAddPrm.Parameters["@DetalleRec"].Value = "ABONO CUOTA INICIAL";
                                CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.FrmUsuarioIdUsr;
                                CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                                CmdAddPrm.Parameters["@Transaccion"].Value = idtransacciones;

                                string SentenciaDatosRcd = "insert into datosrecaudos (IdRecaudo, IdAdjudicacion, Fecha, NumRecibo, IdTercero, Operacion, Valor, FormaPago, Detalle, Usuario, FechaOperacion, Transaccion) " +
                                                                              "Values (@IdRecaudo, @IdAdjudicacion, @Fecha, @NumRecibo, @IdTercero, @Operacion, @Valor, @FormaPago, @DetalleRec, @Usuario, @FechaOperacion, @Transaccion)";

                                CmdAddPrm.CommandText = SentenciaDatosRcd;
                                CmdAddPrm.ExecuteNonQuery();
                                
                                CmdAddPrm.Parameters["@IdFinanciacion"].Value = ("CI" + Convert.ToString(DgvCuotas.Rows[i].Cells[1].Value) + "ADJ" + Consecutivo);
                                CmdAddPrm.Parameters["@NumCuota"].Value = Convert.ToInt16(DgvCuotas.Rows[i].Cells[1].Value);
                                CmdAddPrm.Parameters["@Concepto"].Value = Convert.ToString(DgvCuotas.Rows[i].Cells[0].Value);
                                CmdAddPrm.Parameters["@Capital"].Value = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value);
                                CmdAddPrm.Parameters["@EstadoRec"].Value = "Aprobado";
                                mesCuota = Convert.ToInt32(DgvCtaInicial.Rows[i].Cells[1].Value);
                                if (mesCuota < 10)
                                {
                                    mesConvertido = "0" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[1].Value);
                                }
                                CmdAddPrm.Parameters["@Periodo"].Value = Convert.ToInt32(Convert.ToString(DgvCtaInicial.Rows[i].Cells[2].Value) + "" + mesConvertido);
                                CmdAddPrm.Parameters["@FechaCuota"].Value = Convert.ToDateTime(DgvCuotas.Rows[i].Cells[2].Value);
                                

                                CmdAddPrm.CommandText = "Insert into recaudos (IdRecaudo, IdAdjudicacion, IdFinanciacion, Recibo, Fecha, NumCuota, Concepto," +
                                                        "Capital, FechaOperacion, Usuario, Estado, Periodo, FechaCuota)" +
                                                        "Values (@IdRecaudo, @IdAdjudicacion, @IdFinanciacion, @NumRecibo, @Fecha, @NumCuota, @Concepto," +
                                                        "@Capital, @FechaOperacion, @Usuario, @EstadoRec, @Periodo, @FechaCuota)";
                                CmdAddPrm.ExecuteNonQuery();

                                contConsecutivo = Convert.ToInt32(ConsecutivoRecaudo);
                                contConsecutivo++;
                                ConsecutivoRecaudo = contConsecutivo.ToString();
                            }

                            myTrans.Commit();
                            MessageBox.Show("                  Registro Adicionado.\nEsta adjudicación queda con la número: " + Consecutivo.ToString(), "Adicionar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            btnAdicionarAdj.Enabled = false;
                            MtdLimpiar();

                        }
                        catch (MySqlException ex)
                        {
                            myTrans.Rollback();
                            MessageBox.Show("Ha ocurrido el siguiente error: " + ex.Message + "", "" + "Adicionar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        finally
                        {
                            MysqlConexion.Close();

                        }
                    }
                }
            }
        }
        #endregion

        #region "Eventos"

        private void TxtValorContrato_TextChanged(object sender, EventArgs e)
        {
            try
            {
                validarCasillas();
            }
            catch (Exception)
            {
                lblMensajeValor.Text = "Este campo no puede tener\nvalores negativos ni 0.";
                PnlCtaInicialSinPagar.Enabled = false;
                PnlDatosFnc.Enabled = false;
                PnlTotalFnc.Enabled = false;
            }
        }

        private void TxtValorFnc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calcularFinanciacion();
            }
            catch (Exception)
            {
                lblErrorValorFnc.Text = "Revisar que no hayan\ncampos en blanco.";
            }
        } 

        private void DgvCtaInicial_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sumaValoresDvgCtaInicial();
            if ((Convert.ToString(DgvCtaInicial.CurrentRow.Cells[3].Value)) == "")
            {
                DgvCtaInicial.CurrentRow.Cells[3].Value = 0;
            }
            if ((Convert.ToString(DgvCtaInicial.CurrentRow.Cells[4].Value)) == "")
            {
                DgvCtaInicial.CurrentRow.Cells[4].Value = 0;
            }
            mesCtaInicial++;
            if (chkFechaConsecutiva.Checked)
            {
                if (mesCtaInicial == 1 && chkFechaConsecutiva.Checked)
                {
                    añoCtaInicial++;
                }
                if (mesCtaInicial > 12)
                {
                    mesCtaInicial = 1;
                    añoCtaInicial++;
                }
                if (diaCtaInicial >= 29 && mesCtaInicial == 2)
                {
                    diaCtaInicial = 28;
                }
                DgvCtaInicial.Rows.Add(diaCtaInicial, mesCtaInicial, añoCtaInicial, 0, 0, 0);
                
            }
        }

        private void dtpFechaCtaInicial_CloseUp(object sender, EventArgs e)
        {
            fechaCuotaInicial = dtpFechaCtaInicial.Value;
            diaCtaInicial = fechaCuotaInicial.Day;
            mesCtaInicial = fechaCuotaInicial.Month;
            añoCtaInicial = fechaCuotaInicial.Year;

            if (mesCtaInicial > 12)
            {
                mesCtaInicial = 1;
                añoCtaInicial++;
            }
            if (diaCtaInicial >= 29 && mesCtaInicial == 2)
            {
                diaCtaInicial = 28;
            }

            DgvCtaInicial.Rows.Add(diaCtaInicial, mesCtaInicial, añoCtaInicial, 0, 0, 0);

        }

        private void chkDolarTope_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDolarTope.Checked == true)
            {
                txtDolarTope.Enabled = true;
            }
            else
            {
                txtDolarTope.Enabled = false;
            }
        }

        private void txtCtasFnc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                calcularFinanciacion();
            }
            catch (Exception)
            {
                lblErrorCuotasFnc.Text = "Ingrese el número de cuotas correcto.";
            }
        }

        private void DgvCtaInicial_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcularNumCuotas();
        }

        #endregion

    }
}
