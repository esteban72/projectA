﻿using System;
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
        int CuentaErrores, Consecutivo, numCuotasGridView, numRestoCuotas, contFila, cuotasPagadas;
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
            btnCalcularCuotasSinPagar.Enabled = false;
            fechaCuotaInicial = dtpFechaCtaInicial.Value;
            diaCtaInicial = fechaCuotaInicial.Day;
            mesCtaInicial = fechaCuotaInicial.Month;
            añoCtaInicial = fechaCuotaInicial.Year;
            MtdLimpiar();
            MessageBox.Show("Si la adjudicación que va a ingresar no tiene pagos iniciales, \npor favor indiquelo en el cajón de observaciones\n" +
            "y deje el campo de N° de cuotas pagadas en 0.", "¡ADVERTENCIA!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        //private void MtdDatosCtaIni()
        //{
        //    DgvCtaInicial.AutoGenerateColumns = false;
        //    DgvCtaInicial.Columns[0].DataPropertyName = "Dia";
        //    DgvCtaInicial.Columns[1].DataPropertyName = "Mes";
        //    DgvCtaInicial.Columns[2].DataPropertyName = "Ano";
        //    DgvCtaInicial.Columns[3].DataPropertyName = "Valor";
        //    System.Data.DataTable DtDatosReg = conexion.MtdBuscarDataset("select day(fecha) Dia , MONTH(fecha) Mes,year(fecha) Ano," +
        //    "Capital from financiacion where Concepto= 'CI' AND idadjudicacion='" + LblAdjudicacion.Text + "'");
        //    for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
        //    {
        //        DgvCtaInicial.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3]);

        //    }

        //    CuentaIni = DgvCtaInicial.RowCount - 1;
        //}

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
            sumaValoresDvg1();
            sumaValoresDvg2();
            MtdValidarAdd();
            if (validarFilas(DgvCtaInicial) && validarFilas(DgvCtaInicialSinPagar))
            {
                if (CuentaErrores == 0)
                {
                    btnCalcularCuotasSinPagar_ItemClick(sender, e);
                    DateTime fechaContrato;

                    fechaContrato = DtpFechaContrato.Value;
                    response = client.queryTCRM(fechaContrato);
                    string TRM_FechaContrato = response.value.ToString("###,###.###");
                    txtTRMContrato.Text = TRM_FechaContrato;
                    valorDolar = response.value;
                    //double valContrato = Convert.ToDouble(TxtValorContrato.Text);
                    txtValContratoPesos.Text = (Math.Round(Convert.ToDouble(TxtValorContrato.Text) * valorDolar, 1)).ToString("###,###.###");
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
            if (Convert.ToString(DgvCtaInicial.Rows[contFila + 1].Cells[0].Value) != "" || Convert.ToString(DgvCtaInicial.Rows[contFila + 1].Cells[1].Value) != "" ||
                Convert.ToString(DgvCtaInicial.Rows[contFila + 1].Cells[2].Value) != "" || Convert.ToString(DgvCtaInicial.Rows[contFila + 1].Cells[3].Value) != "")
            {
                DgvCtaInicial.Rows.RemoveAt(DgvCtaInicial.CurrentRow.Index);
                numCuotasGridView--;
                lblMensajeNumCuotas.Text = "Se han ingresado " + numCuotasGridView + " cuotas iniciales.";
            }
            else
            {
                SumValorInicial -= double.Parse(DgvCtaInicial.Rows[contFila].Cells[3].Value.ToString(), CultureInfo.InvariantCulture);
                SumValorInicial = Math.Round(SumValorInicial);
                TxtValorIni.Text = SumValorInicial.ToString("###,###.###");
                DgvCtaInicial.Rows.RemoveAt(DgvCtaInicial.CurrentRow.Index);
                numCuotasGridView--;
                CalcularNumCuotas();
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

            TxtValorContrato.Text = valorcon.ToString();

            this.TxtValorContrato.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtValorContrato.Text));
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
                lblMensajeCuotas.Text = "";
                lblErrorCtaInicialPagada.Text = "";
                lblErrorCtaInicialSinPagar.Text = "";

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
                    lblErrorValorFnc.Text = "Ingrese el valor correcto.";
                    CuentaErrores++;
                    if (PnlDatosFnc.Enabled == false && (DgvCtaInicialSinPagar.Rows.Count - 1) > 1)
                    {
                        lblErrorValorFnc.Text = "";
                        CuentaErrores--;
                    }
                }

                if (txtNumCuotas.Text == "0" || txtNumCuotas.Text == "")
                {
                    lblMensajeCuotas.Text = "Ingrese el valor correcto.";
                    CuentaErrores++;
                }

                if (CmbGrado.Text == "")
                {
                    lblMensajeGrado.Text = "Seleccione el \ngrado del contrato.";
                    CuentaErrores++;
                }

                if (txtNumCuotas.Text == "0" || txtNumCuotas.Text == "")
                {
                    lblMensajeCuotas.Text = "Ingrese el número de\ncuotas de forma correcta.";
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

                        lblErrorCtaInicialPagada.Text = "Las fechas de la couta inicial no pueden tener valores en blanco.";
                        CuentaErrores++;
                    }
                }

                if ((DgvCtaInicial.Rows.Count - 1) < 24 && (DgvCtaInicialSinPagar.Rows.Count - 1) <= 1)
                {
                    lblErrorCtaInicialSinPagar.Text = "Tienen que haber cuotas en este formulario.";
                    CuentaErrores++;
                }


                if (Convert.ToInt32(txtNumCuotas.Text) > 120)
                {
                    lblMensajeCuotas.Text = "No se pueden ingresar\nmás de 120 cuotas.";
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
            TxtValorIni.Text = "0";
            DgvCuotas.Text = "0";
            TxtValorFnc.Text = "0";
            lblErrorValorFnc.Text = "";
            txtNumCuotas.Text = "0";
            lblMensajeCuotas.Text = "";
            lblValorTotalFnc.Text = "0";
            lblMensajeNumCuotas.Text = "";
            lblMensajeNumCuotas2.Text = "";
            lblErrorCtaInicialPagada.Text = "";
            lblErrorCtaInicialSinPagar.Text = "";
            lblMensajeCalculoCuotas.Text = "";
            txtValorSinPagar.Text = "0";
            txtCtasFnc.Text = "0";
            txtTotalFinanciacion.Text = "0";
            txtTRMContrato.Text = "0";
            txtValContratoPesos.Text = "0";
            DgvCtaInicial.Rows.Clear();
            DgvCtaInicialSinPagar.Rows.Clear();
            DgvCuotas.Rows.Clear();
            btnAdicionarAdj.Enabled = false;
            PnlCtaInicialSinPagar.Enabled = false;
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

                if (numCuotasGridView == 24)
                {
                    PnlCtaInicialSinPagar.Enabled = false;
                    TxtValorFnc.Enabled = false;
                    txtCtasFnc.Enabled = false;
                }
                else
                {
                    PnlCtaInicialSinPagar.Enabled = true;
                    TxtValorFnc.Enabled = true;
                    txtCtasFnc.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                lblMensajeNumCuotas.Text = "Error: " + ex.Message;
            }
        }



        private void MtdoDatosCredito()
        {
            int contCuotaInicial = (DgvCtaInicial.Rows.Count - 1);
            int contCuotasSinPago = (DgvCtaInicialSinPagar.Rows.Count - 1);
            int ctasFnc = Convert.ToInt32(txtCtasFnc.Text);
            int periodo = 0;
            int dia, mes, año;

            double SumaCapital = 0, sumaCuotas = 0;
            System.Data.DataTable credito = new System.Data.DataTable();
            //credito = MtdCuotas(Convert.ToDouble(TxtTasaFnc.Text), Convert.ToInt16(txtRestoCuotas.Text), Convert.ToDouble(TxtValorFnc.Text), Convert.ToInt16(30 / Convert.ToDouble(CmbPeriodoFnc.Text) * 12), DtpInicioFnc.Value);
            DateTime FechaIni, FechaFnc;
            double CapitalIni = 0;
            int NumCuota = 0;

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
            if (contCuotaInicial > 0)
            {
                for (int i = 0; i < contCuotaInicial; i++)
                {
                    NumCuota++;
                    FechaIni = Convert.ToDateTime(Convert.ToString(DgvCtaInicial.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[2].Value));
                    CapitalIni = Math.Round(double.Parse(DgvCtaInicial.Rows[i].Cells[3].Value.ToString(), CultureInfo.InvariantCulture), 2);
                    DgvCuotas.Rows.Add("CI", NumCuota, FechaIni, (CapitalIni * valorDolar), 0, 0);
                }
            }
            if (contCuotasSinPago > 0)
            {
                for (int i = 0; i < contCuotasSinPago; i++)
                {
                    NumCuota++;
                    FechaIni = Convert.ToDateTime(Convert.ToString(DgvCtaInicialSinPagar.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvCtaInicialSinPagar.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvCtaInicialSinPagar.Rows[i].Cells[2].Value));
                    DgvCuotas.Rows.Add("CI", NumCuota, FechaIni, 0, 0, Math.Round(Convert.ToDouble(DgvCtaInicialSinPagar.Rows[i].Cells[3].Value) * valorDolar, 2));
                }
                if (ctasFnc > 0)
                {
                    //DateTime fechaCuotasSinPagar

                    FechaFnc = DtpInicioFnc.Value;
                    int indexFechaSinPago = (DgvCtaInicialSinPagar.Rows.Count - 2);
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
                        //if (mes > 12)
                        //{
                        //    mes = 1;
                        //    restoCont = periodo - cont;
                        //    mes = restoCont;
                        //    año++;
                        //}

                        FechaIni = Convert.ToDateTime(dia + "-" + mes + "-" + año);
                        DgvCuotas.Rows.Add("FN", NumCuota, FechaIni, 0, 0, Math.Round(Convert.ToDouble(TxtValorFnc.Text) * valorDolar, 2));
                        mes += periodo;
                        
                    }
                }
            }
            for (int i = 0; i < (DgvCuotas.Rows.Count); i++)
            {
                SumaCapital += Convert.ToDouble(DgvCuotas.Rows[i].Cells[3].Value);
                //SumaCapital = Math.Round(SumaCapital,1);
                sumaCuotas += Convert.ToDouble(DgvCuotas.Rows[i].Cells[5].Value);
                //sumaCuotas = Math.Round(sumaCuotas,1);
            }
            int contFilasDvgCuotas = DgvCuotas.Rows.Count - 1;
            DgvCuotas.Rows[contFilasDvgCuotas].Cells[2].Value = "T O T A L  . .";
            DgvCuotas.Rows[contFilasDvgCuotas].Cells[3].Value = SumaCapital;
            DgvCuotas.Rows[contFilasDvgCuotas].Cells[5].Value = sumaCuotas;
            DgvCuotas.Rows[contFilasDvgCuotas].DefaultCellStyle.BackColor = Color.Blue;
            DgvCuotas.Rows[contFilasDvgCuotas].DefaultCellStyle.ForeColor = Color.White;
            //ValidacionCapital = SumaCapital;

        }

        public System.Data.DataTable MtdCuotas(double tasaInteres, int plazo, double capital, int periodo, DateTime fechaInicio)
        {
            double CuotaFijaCalculada;

            //if (tasaInteres > 0)
            //{
            //    double a, b, x;

            //    a = (1 + tasaInteres / (periodo * 100));
            //    b = plazo;
            //    x = Math.Pow(a, b);
            //    x = 1 / x;
            //    x = 1 - x;
            //    CuotaFijaCalculada = Math.Round(((capital) * (tasaInteres / (periodo * 100)) / x), Convert.ToInt16(LblDecimal.Text));
            //}

            //else
            //{
            //    CuotaFijaCalculada = Math.Round((capital / plazo), Convert.ToInt16(LblDecimal.Text));
            //}

            double CapitalCuota, InteresCuota, SaldoCuota, CuotaCuota;
            DateTime Fecha;
            SaldoCuota = capital;

            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("Mes", typeof(DateTime));
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Valor", typeof(double));
            table.Columns.Add("Capital", typeof(double));
            table.Columns.Add("Interes", typeof(double));
            table.Columns.Add("Saldo", typeof(double));
            //for (int i = 1; i < plazo + 1; i++)
            //{
            //    Fecha = fechaInicio.AddMonths(12 / periodo * (i - 1));
            //    InteresCuota = Math.Round(((SaldoCuota * (12 / periodo * 30) * tasaInteres) / 36000), Convert.ToInt16(LblDecimal.Text));
            //    CapitalCuota = Math.Round((CuotaFijaCalculada - InteresCuota), Convert.ToInt16(LblDecimal.Text));


            //    if (i == plazo)
            //    {
            //        CuotaCuota = Math.Round((SaldoCuota + InteresCuota), Convert.ToInt16(LblDecimal.Text));
            //        table.Rows.Add(Fecha, i, CuotaCuota, SaldoCuota, InteresCuota, SaldoCuota);
            //        SaldoCuota = 0;
            //    }
            //    else
            //    {
            //        CuotaCuota = Math.Round((CapitalCuota + InteresCuota), Convert.ToInt16(LblDecimal.Text));
            //        SaldoCuota = Math.Round((SaldoCuota - CapitalCuota), Convert.ToInt16(LblDecimal.Text));
            //        table.Rows.Add(Fecha, i, CuotaCuota, CapitalCuota, InteresCuota, SaldoCuota);
            //    }
            //}

            return table;
        }

        private void sumaValoresDvg1()
        {
            SumValorInicial = 0;
            int filas = DgvCtaInicial.Rows.Count - 1;
            for (int i = 0; i < filas; i++)
            {
                if ((Convert.ToString(DgvCtaInicial.Rows[i].Cells[3].Value)) == "")
                {
                    DgvCtaInicial.Rows[i].Cells[3].Value = 0;
                }
                else
                {
                    SumValorInicial += double.Parse(DgvCtaInicial.Rows[i].Cells[3].Value.ToString(), CultureInfo.InvariantCulture);
                }
            }
            SumValorInicial = Math.Round(SumValorInicial);
            TxtValorIni.Text = SumValorInicial.ToString("###,###.###");
        }

        private void sumaValoresDvg2()
        {
            SumValorInicial = 0;
            int filas = DgvCtaInicialSinPagar.Rows.Count - 1;
            for (int i = 0; i < filas; i++)
            {
                if ((Convert.ToString(DgvCtaInicialSinPagar.Rows[i].Cells[3].Value)) == "")
                {
                    DgvCtaInicialSinPagar.Rows[i].Cells[3].Value = 0;
                }
                else
                {
                    SumValorInicial += Convert.ToDouble(DgvCtaInicialSinPagar.Rows[i].Cells[3].Value);
                }
            }
            SumValorInicial = Math.Round(SumValorInicial, 3);
            txtValorSinPagar.Text = SumValorInicial.ToString("###,###.###");
        }

        #endregion

        #region "Metodo principal add"
        private void MtdAdicionar()
        {
            string VarIdCta, VarConcepto;
            decimal VarCapital, VarCuota;
            int VarNumcuota;
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
                    if (Consecutivo != 0)
                    {


                        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

                        string StrAddAdjudicacion = " INSERT INTO adjudicacion (IdAdjudicacion, Fecha, FechaContrato, Contrato, IdProyecto, IdTercero1, IdTercero2, Idtercero3," +
                        "IdInmueble, TipodeAdjudicacion, Temporada, Grado, FormaPago, Valor, CuotaInicial, Financiacion, PlazoFnc, " +
                        "CuotaFnc, InicioFnc, Estado, Usuario, FechaOperacion, Porcentaje, TipoOperacion, Observacion) " +

                        "VALUES ( @IdAdjudicacion, @Fecha, @FechaContrato, @Contrato, @IdProyecto, @IdTercero1, @IdTercero2, @Idtercero3, @IdInmueble, @TipodeAdjudicacion, @Temporada, @Grado," +
                        "@FormaPago, @Valor, @CuotaInicial, @Financiacion, @PlazoFnc, @CuotaFnc, @InicioFnc, @Estado, @Usuario, @FechaOperacion, " +
                        "@Porcentaje, @TipoOperacion, @Observacion)";


                        string StrAddFnc = "insert into financiacion (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Cuota,SaldoCapital,SaldoCuota,UltimaFechaPago,Usuario,FechaOperacion) " +
                                                         "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital,@Cuota,@Capital,@Cuota,@FechaFnc,@Usuario,@FechaOperacion)";

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
                            CmdAddPrm.Parameters.Add("@Capital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                            CmdAddPrm.Parameters.Add("@Cuota", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                            CmdAddPrm.Parameters.Add("@NumCuota", MySql.Data.MySqlClient.MySqlDbType.Int16);


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

                            CmdAddPrm.Parameters["@FormaPago"].Value = CmbFormaPago.Text;
                            CmdAddPrm.Parameters["@Valor"].Value = Convert.ToDouble(TxtValorContrato.Text)*response.value;
                            CmdAddPrm.Parameters["@CuotaInicial"].Value = Convert.ToDouble(TxtValorIni.Text) * response.value;
                            CmdAddPrm.Parameters["@Financiacion"].Value = Convert.ToDouble(txtTotalFinanciacion.Text) * response.value;
                            CmdAddPrm.Parameters["@PlazoFnc"].Value = Convert.ToInt16(txtNumCuotas.Text);
                            CmdAddPrm.Parameters["@CuotaFnc"].Value = Convert.ToDouble(TxtValorFnc.Text) * response.value;
                            CmdAddPrm.Parameters["@InicioFnc"].Value = DtpInicioFnc.Value;
                            CmdAddPrm.Parameters["@Estado"].Value = "Pendiente";
                            CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                            CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                            CmdAddPrm.Parameters["@TipoOperacion"].Value = "PIV";
                            CmdAddPrm.Parameters["@Porcentaje"].Value = 0;
                            CmdAddPrm.Parameters["@Observacion"].Value = TxtObservacion.Text;

                            CmdAddPrm.CommandText = StrAddAdjudicacion;
                            CmdAddPrm.ExecuteNonQuery();

                            for (int i = 0; i < DgvCuotas.Rows.Count - 1; i++)
                            {

                                VarConcepto = DgvCuotas.Rows[i].Cells[0].Value.ToString();
                                VarNumcuota = Convert.ToInt16(DgvCuotas.Rows[i].Cells[1].Value);
                                VarIdCta = VarConcepto + VarNumcuota + "ADJ" + Consecutivo;
                                VarFecha = Convert.ToDateTime(DgvCuotas.Rows[i].Cells[2].Value);
                                VarCapital = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[3].Value);
                                VarCuota = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[5].Value);

                                CmdAddPrm.Parameters["@IdCta"].Value = VarIdCta;
                                CmdAddPrm.Parameters["@Concepto"].Value = VarConcepto;
                                CmdAddPrm.Parameters["@FechaFnc"].Value = VarFecha;
                                CmdAddPrm.Parameters["@Capital"].Value = VarCapital;
                                CmdAddPrm.Parameters["@Cuota"].Value = VarCuota;
                                CmdAddPrm.Parameters["@NumCuota"].Value = VarNumcuota;

                                CmdAddPrm.CommandText = StrAddFnc;
                                CmdAddPrm.ExecuteNonQuery();

                                CmdAddPrm.CommandText = StrModReserva;
                                CmdAddPrm.ExecuteNonQuery();

                                CmdAddPrm.CommandText = StrModInmuebles;
                                CmdAddPrm.ExecuteNonQuery();
                            }
                            myTrans.Commit();
                            MessageBox.Show("Registro Adicionado.\nEsta adjudicación queda con la número: " + Consecutivo.ToString(), "Adicionar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            btnValidarInformacion.Enabled = false;
                            btnCalcularCuotasSinPagar.Enabled = false;
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

        //private void DgvCtaInicial_SelectionChanged(object sender, System.EventArgs e)
        //{
        //    //contFila = Convert.ToInt32(DgvCtaInicial.CurrentRow.Index.ToString());

        //}

        private void DgvCtaInicial_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CalcularNumCuotas();
        }


        private void DgvCtaInicial_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnCalcularCuotasSinPagar.Enabled = true;
                int indexFila = DgvCtaInicial.Rows.Count - 2;
                if (Convert.ToDouble(DgvCtaInicial.CurrentRow.Cells[3].Value) == 0)
                {
                    lblErrorCtaInicialPagada.Text = "El valor no puede ser 0.";
                }
                else
                {
                    lblErrorCtaInicialPagada.Text = "";
                    sumaValoresDvg1();
                    int cuotasIniciales = DgvCtaInicial.Rows.Count - 2;
                    if (Convert.ToDouble(TxtValorIni.Text) == Convert.ToDouble(TxtValorContrato.Text))
                    {
                        btnCalcularCuotasSinPagar.Enabled = false;
                        PnlCtaInicialSinPagar.Enabled = false;
                    }
                    else if (Convert.ToDouble(TxtValorIni.Text) > Convert.ToDouble(TxtValorContrato.Text))
                    {
                        EliminarFilas();
                        PnlCtaInicialSinPagar.Enabled = false;
                        btnCalcularCuotasSinPagar.Enabled = false;
                        lblErrorCtaInicialPagada.Text = "La suma de las cuotas no puede exceder el valor del contrato.";
                    }
                    else
                    {
                        btnCalcularCuotasSinPagar.Enabled = true;
                        PnlCtaInicialSinPagar.Enabled = true;
                        lblErrorCtaInicialPagada.Text = "";
                    }

                    if (Convert.ToString(DgvCtaInicial.CurrentRow.Cells[1].Value) != "")
                    {
                        mesCtaInicial = Convert.ToInt32(DgvCtaInicial.CurrentRow.Cells[1].Value);
                        if (chkFechaConsecutiva.Checked == true)
                        {
                            mesCtaInicial++;
                            DgvCtaInicial.Rows.Add(diaCtaInicial, mesCtaInicial, añoCtaInicial, 0);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor revise que todos los valores esten correctos.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtValorContrato_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int CuotasPagoContrato = Convert.ToInt32(txtNumCuotas.Text);
                double valorContrato = Convert.ToDouble(TxtValorContrato.Text);
                if (valorContrato > 0)
                {
                    lblMensajeValor.Text = "";
                }
                if (CuotasPagoContrato > 0 && valorContrato > 0)
                {
                    btnCalcularCuotasSinPagar.Enabled = true;
                }
                else
                {
                    btnCalcularCuotasSinPagar.Enabled = false;
                }
            }
            catch (Exception)
            {
                lblMensajeValor.Text = "Este campo no puede tener valores negativos ni en 0.";
            }
        }

        private void TxtValorFnc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double valorFinanciacion = Convert.ToDouble(TxtValorFnc.Text);
                if (valorFinanciacion > 0)
                {
                    lblErrorValorFnc.Text = "";
                }
            }
            catch (Exception)
            {
                lblErrorValorFnc.Text = "Este campo no puede\ntener valores negativos ni en 0.";
            }
        }



        private void txtNumCuotas_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int CuotasPagoContrato = Convert.ToInt32(txtNumCuotas.Text);
                double valContrato = Convert.ToDouble(TxtValorContrato.Text);
                if (CuotasPagoContrato > 23)
                {
                    lblMensajeCuotas.Text = "";
                    PnlCtaInicialPagada.Enabled = true;
                    PnlCtaInicialSinPagar.Enabled = true;
                    PnlDatosFnc.Enabled = true;
                }
                else
                {
                    lblMensajeCuotas.Text = "Ingrese valores mayores\no iguales a 24.";
                    PnlCtaInicialPagada.Enabled = false;
                    PnlCtaInicialSinPagar.Enabled = false;
                    PnlDatosFnc.Enabled = false;
                }
                if (CuotasPagoContrato > 23 && valContrato > 0)
                {
                    btnCalcularCuotasSinPagar.Enabled = true;
                }
                else
                {
                    btnCalcularCuotasSinPagar.Enabled = false;
                }
            }
            catch (Exception)
            {
                lblMensajeCuotas.Text = "Este campo no puede tener\nvalores negativos ni en 0.";
                PnlCtaInicialPagada.Enabled = false;
                PnlCtaInicialSinPagar.Enabled = false;
                PnlDatosFnc.Enabled = false;
            }
        }

        private bool validarFilas(DataGridView grid)
        {
            int filas = grid.Rows.Count - 1;
            for (int i = 0; i < filas; i++)
            {
                if (Convert.ToDouble(grid.Rows[i].Cells[3].Value) == 0)
                {
                    btnCalcularCuotasSinPagar.Enabled = false;
                    CuentaErrores++;
                    return false;
                }
            }
            return true;
        }

        #endregion

        private void btnCalcularCuotasSinPagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                lblErrorCtaInicialSinPagar.Text = "";
                DgvCtaInicialSinPagar.Rows.Clear();
                int CuotasPagoContrato = Convert.ToInt32(txtNumCuotas.Text);
                int indexCuotasIniciales = 0;
                int restoCuotas = 24 - numCuotasGridView;
                int restoPagoCuotas = CuotasPagoContrato - numCuotasGridView;
                int ctsFnc = CuotasPagoContrato - 24;
                double valorCuotas = 0;
                double valorContrato = double.Parse(TxtValorContrato.Text, CultureInfo.InvariantCulture);
                txtCtasFnc.Enabled = true;
                int salir = 0;
                int dia;
                int mes;
                int año;
                if ((DgvCtaInicial.Rows.Count - 1) > 1 && (DgvCtaInicial.Rows.Count - 1) < 25)
                {
                    dia = Convert.ToInt32(DgvCtaInicial.Rows[DgvCtaInicial.Rows.Count - 2].Cells[0].Value);
                    mes = Convert.ToInt32(DgvCtaInicial.Rows[DgvCtaInicial.Rows.Count - 2].Cells[1].Value);
                    año = Convert.ToInt32(DgvCtaInicial.Rows[DgvCtaInicial.Rows.Count - 2].Cells[2].Value);
                    mes++;
                    dtpFechaCtaSinPagar.Value = new DateTime(año, mes, dia);

                    sumaValoresDvg1();
                    if (Convert.ToDouble(TxtValorIni.Text) >= valorContrato)
                    {
                        MessageBox.Show("No se pueden agregar cuotas sin pagar ya que la suma de las\n" +
                                        "cuotas iniciales pagadas es igual o mayor al valor del contrato.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        DateTime fechaInicioCtaSinPagar = dtpFechaCtaSinPagar.Value;
                        indexCuotasIniciales = DgvCtaInicial.Rows.Count - 2; //indice para grid DgvCtaInicial

                        valorCuotas = Math.Round((valorContrato - double.Parse(TxtValorIni.Text, CultureInfo.InvariantCulture)) / restoPagoCuotas, 3);
                        dia = fechaInicioCtaSinPagar.Day;
                        mes = fechaInicioCtaSinPagar.Month;
                        año = fechaInicioCtaSinPagar.Year;
                        lblErrorCtaInicialSinPagar.Text = "";
                        for (int i = 0; i < restoCuotas; i++)
                        {
                            if (salir > 0)
                            {
                                break;
                            }
                            if (mes > 12)
                            {
                                año++;
                                mes = 1;
                            }
                            DgvCtaInicialSinPagar.Rows.Add(dia, mes, año, valorCuotas);

                            DateTime fechaSinPagar = new DateTime(año, mes, dia);
                            DateTime fechaInicio;
                            int cuotasInicio = Convert.ToInt32(DgvCtaInicial.Rows.Count - 1);
                            for (int j = 0; j < cuotasInicio; j++)
                            {

                                fechaInicio = new DateTime(Convert.ToInt32(DgvCtaInicial.Rows[j].Cells[2].Value), Convert.ToInt32(DgvCtaInicial.Rows[j].Cells[1].Value), Convert.ToInt32(DgvCtaInicial.Rows[j].Cells[0].Value));
                                if (fechaSinPagar == fechaInicio)
                                {
                                    DgvCtaInicialSinPagar.Rows.Clear();
                                    lblErrorCtaInicialSinPagar.Text = "Hay un cruce de fechas por lo que no se pudo realizar el calculo, por favor revisar. La fecha con error fue: " + fechaInicio.ToString("dd/MM/yyyy");
                                    salir++;
                                    break;
                                }
                            }
                            mes++;
                        }
                        int indexCuotasSinPagar = DgvCtaInicialSinPagar.Rows.Count - 2;
                        dia = Convert.ToInt32(DgvCtaInicialSinPagar.Rows[indexCuotasSinPagar].Cells[0].Value);
                        mes = Convert.ToInt32(DgvCtaInicialSinPagar.Rows[indexCuotasSinPagar].Cells[1].Value);
                        mes++;
                        año = Convert.ToInt32(DgvCtaInicialSinPagar.Rows[indexCuotasSinPagar].Cells[2].Value);
                        DateTime fechaFnc = new DateTime(año, mes, dia);
                        DtpInicioFnc.Value = fechaFnc;
                        sumaValoresDvg2();
                        
                        if (ctsFnc > 0 && numCuotasGridView == 24)
                        {
                            PnlDatosFnc.Enabled = true;
                        }
                        else if (ctsFnc > 0 && (DgvCtaInicialSinPagar.Rows.Count - 1) > 1)
                        {
                            PnlDatosFnc.Enabled = true;
                            double valorFnc = Convert.ToDouble(DgvCtaInicialSinPagar.Rows[DgvCtaInicial.Rows.Count - 1].Cells[3].Value);
                            TxtValorFnc.Text = Convert.ToString(valorFnc);
                            txtCtasFnc.Text = Convert.ToString(ctsFnc);
                            lblValorTotalFnc.Text = (valorFnc * ctsFnc).ToString("###,###.###");
                            txtCtasFnc.Enabled = false;
                        }
                        else
                        {
                            PnlDatosFnc.Enabled = false;
                        }
                    }
                }
                if (validarFilas(DgvCtaInicial))
                {

                    if (numCuotasGridView == 0)
                    {
                        restoCuotas = 24;
                        DateTime fechaCuotas = dtpFechaCtaSinPagar.Value;

                        valorCuotas = Math.Round(valorContrato / CuotasPagoContrato, 3);
                        dia = fechaCuotas.Day;
                        mes = fechaCuotas.Month;
                        año = fechaCuotas.Year;

                        for (int i = 0; i < restoCuotas; i++)
                        {
                            if (mes > 12)
                            {
                                año++;
                                mes = 1;
                            }
                            DgvCtaInicialSinPagar.Rows.Add(dia, mes, año, valorCuotas);
                            mes++;
                        }

                        lblMensajeNumCuotas2.Text = "Se han cargado " + restoCuotas + " cuotas.";
                        sumaValoresDvg2();
                        if (ctsFnc > 0)
                        {
                            dia = Convert.ToInt32(DgvCtaInicialSinPagar.Rows[DgvCtaInicialSinPagar.Rows.Count - 2].Cells[0].Value);
                            mes = Convert.ToInt32(DgvCtaInicialSinPagar.Rows[DgvCtaInicialSinPagar.Rows.Count - 2].Cells[1].Value);
                            año = Convert.ToInt32(DgvCtaInicialSinPagar.Rows[DgvCtaInicialSinPagar.Rows.Count - 2].Cells[2].Value);
                            mes++;
                            DtpInicioFnc.Value = new DateTime(año, mes, dia);
                            double valorFnc = Convert.ToDouble(DgvCtaInicialSinPagar.Rows[DgvCtaInicial.Rows.Count - 1].Cells[3].Value);
                            TxtValorFnc.Text = Convert.ToString(valorFnc);
                            txtCtasFnc.Text = Convert.ToString(ctsFnc);
                            lblValorTotalFnc.Text = (valorFnc * ctsFnc).ToString("###,###.###");
                            PnlDatosFnc.Enabled = true;
                            txtCtasFnc.Enabled = false;
                        }
                        else
                        {
                            PnlDatosFnc.Enabled = false;
                        }

                    }
                    if ((DgvCtaInicialSinPagar.Rows.Count - 1) > 1)
                    {
                        lblMensajeNumCuotas2.Text = "Se han cargado " + restoCuotas + " cuotas.";
                        lblMensajeCalculoCuotas.Text = "El calculo de las cuotas se hizo sobre" +
                                                       "\nel restante de las cuotas por pagar, es decir " + restoPagoCuotas + ".";
                    }

                    double totalCuotasSinPagar = 0, totalFinanciacion = 0, sumaTotales = 0;
                    totalCuotasSinPagar = Convert.ToDouble(txtValorSinPagar.Text);
                    //double.Parse(TxtValorContrato.Text, CultureInfo.InvariantCulture);
                    totalFinanciacion = Convert.ToDouble(lblValorTotalFnc.Text);
                    sumaTotales = totalCuotasSinPagar + totalFinanciacion;
                    sumaTotales = Math.Round(sumaTotales);
                    txtTotalFinanciacion.Text = sumaTotales.ToString("###,###.###");

                }
                else
                {
                    MessageBox.Show("No pueden haber cuotas con valores en 0.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAdicionarAdj.Enabled = false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Verifique que los valores de las cuotas iniciales sean correctos.", "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCtaInicialSinPagar_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            sumaValoresDvg2();
        }

        private void btnConsultarTRM_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTRM TRM = new FrmTRM();
            TRM.Show();
        }



        private void dtpFechaCtaInicial_CloseUp(object sender, EventArgs e)
        {
            fechaCuotaInicial = dtpFechaCtaInicial.Value;
            diaCtaInicial = fechaCuotaInicial.Day;
            mesCtaInicial = fechaCuotaInicial.Month;
            añoCtaInicial = fechaCuotaInicial.Year;
            if (chkFechaConsecutiva.Checked == true)
            {
                if (mesCtaInicial > 12)
                {
                    mesCtaInicial = 1;
                    añoCtaInicial++;
                }
                DgvCtaInicial.Rows.Add(diaCtaInicial, mesCtaInicial, añoCtaInicial, 0);
                mesCtaInicial++;
            }
            else
            {
                if (mesCtaInicial > 12)
                {
                    mesCtaInicial = 1;
                    añoCtaInicial++;
                }
                DgvCtaInicial.Rows.Add(diaCtaInicial, mesCtaInicial, añoCtaInicial, 0);
            }
        }






    }
}