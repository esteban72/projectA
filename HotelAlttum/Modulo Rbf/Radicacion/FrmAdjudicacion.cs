using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using MySql.Data.MySqlClient;
using CarteraGeneral.Clases;

namespace CarteraGeneral
{
    public partial class FrmAdjudicacion : Form
    {
        public FrmAdjudicacion()
        {
            InitializeComponent();
        }

        #region REGION DE VARIABLES
        double CuentaIni = 0;
        int Consecutivo;
        decimal  Diferencia,ValidacionCapital;
        decimal CuentaErrores;
        double SumValorInicial;
        double SumValorContado;
        double SumValorExtraVariado;
        public string EntradaAdjudicacion, tipoContrato;
        public string VarIdajudicacion;
        System.Data.DataTable DtComisiones = new System.Data.DataTable();
        System.Data.DataTable DtFinanciacion = new System.Data.DataTable();
        System.Data.DataTable DtParametro = new System.Data.DataTable();
        System.Data.DataTable DtComisionesMod = new System.Data.DataTable();
        System.Data.DataTable DtInmueble = new System.Data.DataTable();
        System.Data.DataTable DtTarifas = new System.Data.DataTable();

      System.Data.DataTable  DatosAdjudicacion=new System.Data.DataTable ();
        List<string> DatosdeErrores = new List<string>();

        ClsIdentificacion conexion = new ClsIdentificacion();
        ClsComision consultar = new ClsComision();

        #endregion


        private void FrmAdjudicacion_Load(object sender, EventArgs e)
        {
            LblAdjudicacion.Text = VarIdajudicacion;
            pictureBox1.Image = FrmLogeo.LogoFondo;
            DtTarifas = conexion.MtdBuscarDataset("select * from  tarifas");
            DtParametro = conexion.MtdBuscarDataset("select InteresCte,Porcentaje,decimales From Parametro Where Estado='Vigente'");
            TxtInteresCte.Text = DtParametro.Rows[0][0].ToString();
            TxtPorcentaje.Text = DtParametro.Rows[0][1].ToString();
            LblDecimal.Text = DtParametro.Rows[0][2].ToString();
            DtComisiones.Columns.Add("IdCargo", typeof(string));
            DtComisiones.Columns.Add("IdGestor", typeof(string));
            DtComisiones.Columns.Add("Comision", typeof(decimal));
            MtdLimpiar();
            CmbFormaPago.Text = "Credito";
            MtdInicio();
        }

        private void FrmAdjudicacion_Activated(object sender, EventArgs e)
        {
            DtTarifas = conexion.MtdBuscarDataset("select *from  tarifas");
            DtParametro = conexion.MtdBuscarDataset("select InteresCte,Porcentaje,Decimales From Parametro Where Estado='Vigente'");
            TxtInteresCte.Text = DtParametro.Rows[0][0].ToString();
            TxtPorcentaje.Text = DtParametro.Rows[0][1].ToString();
            LblDecimal.Text = DtParametro.Rows[0][2].ToString();
        }



        #region REGION DE METODOS


//===================================================================================================================================================
// I N I C I O   M E T O D O   I N I C I O
//===================================================================================================================================================
        private void MtdInicio()
        {
        
         if (EntradaAdjudicacion == "Adicionar")
            {
                LblTitulo.Text = "ADICIONAR ADJUDICACION";
                BtnOk.Text = "Adicionar";
                LblNombreTitular.Text = "";
            }
            else

             if (EntradaAdjudicacion == "Modificar")
                {
                    Lbltituloreserva.Visible = false;
                    TxtReserva.Visible = false;
                    BtnBscReserva.Visible = false;
                     MtdLimpiar();
                     LblAdjudicacion.Text = VarIdajudicacion;
                     MtdDatosAdjudicacion();
                    LblTitulo.Text = "MODIFICAR ADJUDICACION";
                    BtnOk.Text = "Modificar";
                    MtdLoadMod();
                }
                else
                 if (EntradaAdjudicacion == "Eliminar")
                    {                        
                        MtdLimpiar();
                        Lbltituloreserva.Visible = false;
                        TxtReserva.Visible = false;
                        BtnBscReserva.Visible = false;
                        BtnValidar.Visible = false;
                        LblTitulo.Text = "ELIMINAR ADJUDICACION";
                        BtnOk.Text = "Eliminar";
                       
                        MtdLoadMod();
                        BtnOk.Enabled = true;
                    }
                    else

                     if (EntradaAdjudicacion == "Consultar" && tipoContrato != "PIV")
                        {
                            MtdLimpiar();
                            Lbltituloreserva.Visible = false;
                            TxtReserva.Visible = false;
                            BtnBscReserva.Visible = false;
                            MtdLoadMod();
                            LblTitulo.Text = "CONSULTAR ADJUDICACION";                           
                            BtnOk.Visible = false;
                            BtnValidar.Visible = false;
                        }
                     else

                         if (EntradaAdjudicacion == "Consultar" && tipoContrato == "PIV")
                         {
                             MtdLimpiar();
                             Lbltituloreserva.Visible = false;
                             TxtReserva.Visible = false;
                             BtnBscReserva.Visible = false;
                             MtdLoadPIV();
                             LblTitulo.Text = "CONSULTAR ADJUDICACION";
                             BtnOk.Visible = true;
                             BtnOk.Text = "Aprobar";
                             BtnValidar.Visible = false;
                             BtnOk.Enabled = true;
                         }
                         else

                             if (EntradaAdjudicacion == "Aprobar" && tipoContrato != "PIV")
                             {
                                 MtdLimpiar();
                                 Lbltituloreserva.Visible = false;
                                 TxtReserva.Visible = false;
                                 BtnBscReserva.Visible = false;
                                 MtdLoadMod();
                                 LblTitulo.Text = "APROBAR ADJUDICACION";
                                 BtnOk.Visible = true;
                                 BtnOk.Text = "Aprobar";
                                 BtnValidar.Visible = false;
                                 BtnOk.Enabled = true;
                             }
                     else

                         if (EntradaAdjudicacion == "Aprobar" && tipoContrato == "PIV")
                         {
                             MtdLimpiar();
                             Lbltituloreserva.Visible = false;
                             TxtReserva.Visible = false;
                             BtnBscReserva.Visible = false;
                             MtdLoadPIV();
                             LblTitulo.Text = "APROBAR ADJUDICACION";
                             BtnOk.Visible = true;
                             BtnOk.Text = "Aprobar";
                             BtnValidar.Visible = false;
                             BtnOk.Enabled = true;
                         }
            else
         if (EntradaAdjudicacion == "Desistir")
         {
             MtdLimpiar();
             Lbltituloreserva.Visible = false;
             TxtReserva.Visible = false;
             BtnBscReserva.Visible = false;
             BtnValidar.Visible = false;
             LblTitulo.Text = "DESISTIR ADJUDICACION";
             MtdLoadMod();
             BtnOk.Enabled = true;
             BtnOk.Text = "Desistir";
         }
        }
//===================================================================================================================================================
// F I N A L    M E T O D O    I N I C I O
//===================================================================================================================================================


//==================================================================================================================================================
// I N I C I O   M E T O D O   D A T O S   A D J U D I C A C I O N
//===================================================================================================================================================
        private void MtdDatosAdjudicacion()
        {
            if(tipoContrato == "PIV"){
                DatosAdjudicacion = conexion.MtdBuscarDataset("Select Fecha,Contrato,IdInmueble,IdTercero1,IdTercero2,IdTercero3,Observacion,Grado,FormaPago,ValorContratoUSD," +
            "GastosLegales,CuotaInicialUSD,Contado,FinanciacionUSD,PlazoFnc,TasaFnc,CuotaFncUSD,InicioFnc,Extraordinaria,PlazoExtra,TasaExtra,CuotaExtra,InicioExtra," +
            "Porcentaje,TipodeAdjudicacion ,FechaContrato, BaseComision from Adjudicacion where IdAdjudicacion = " + VarIdajudicacion);
                DtFinanciacion = conexion.MtdBuscarDataset("Select Concepto,NumCuota,Fecha,Capital_USD,Interes,Cuota_USD From Financiacion Where IdAdjudicacion=" + VarIdajudicacion);
            }
            else
            {
                DatosAdjudicacion = conexion.MtdBuscarDataset("Select Fecha,Contrato,IdInmueble,IdTercero1,IdTercero2,IdTercero3,Observacion,Grado,FormaPago,Valor," +
            "GastosLegales,CuotaInicial,Contado,Financiacion,PlazoFnc,TasaFnc,CuotaFnc,InicioFnc,Extraordinaria,PlazoExtra,TasaExtra,CuotaExtra,InicioExtra," +
            "Porcentaje,TipodeAdjudicacion ,FechaContrato, BaseComision  from Adjudicacion where IdAdjudicacion = " + VarIdajudicacion);
                DtFinanciacion = conexion.MtdBuscarDataset("Select Concepto,NumCuota,Fecha,Capital,Interes,Cuota From Financiacion Where IdAdjudicacion=" + VarIdajudicacion);
            }
                       
            DtpFecha.Text = DatosAdjudicacion.Rows[0][0].ToString();
            DtpFechaContrato.Text = DatosAdjudicacion.Rows[0][25].ToString();
            TxtContrato.Text = DatosAdjudicacion.Rows[0][1].ToString();
            TxtInmueble.Text = DatosAdjudicacion.Rows[0][2].ToString();
            TxtTitular1.Text = DatosAdjudicacion.Rows[0][3].ToString();
            TxtTitular2.Text = DatosAdjudicacion.Rows[0][4].ToString();
            TxtTitular3.Text = DatosAdjudicacion.Rows[0][5].ToString();
            TxtValorBase.Text = DatosAdjudicacion.Rows[0][26].ToString();
            LblNombreTitular.Text = conexion.MtdBscNombres(TxtTitular1.Text);

            if (TxtTitular2.Text != "")
            {
                LblNombreTitular2.Text = conexion.MtdBscNombres(TxtTitular2.Text);
            }
            if (TxtTitular3.Text != "")
            {
                LblNombreTitular3.Text = conexion.MtdBscNombres(TxtTitular3.Text);
            }
            TxtObservacion.Text = DatosAdjudicacion.Rows[0][6].ToString();
            CmbColor.Text = DatosAdjudicacion.Rows[0][7].ToString();          
            CmbFormaPago.Text = DatosAdjudicacion.Rows[0][8].ToString();
            TxtValorContrato.Text = DatosAdjudicacion.Rows[0][9].ToString();
            this.TxtValorContrato.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorContrato.Text));
            TxtGastoLegal.Text= DatosAdjudicacion.Rows[0][10].ToString();
             this.TxtGastoLegal.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtGastoLegal.Text));
             TxtValorIni.Text = DatosAdjudicacion.Rows[0][11].ToString();
             this.TxtValorIni.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorIni.Text));
            TxtValorContado.Text = DatosAdjudicacion.Rows[0][12].ToString();
            this.TxtValorContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorContado.Text));           
            TxtValorFnc.Text = DatosAdjudicacion.Rows[0][13].ToString();
            this.TxtValorFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorFnc.Text));            
            TxtPlazoFnc.Text = DatosAdjudicacion.Rows[0][14].ToString();
            TxtTasaFnc.Text = DatosAdjudicacion.Rows[0][15].ToString();
            TxtCuotaFnc.Text = DatosAdjudicacion.Rows[0][16].ToString();
            DtpInicioFnc.Text = DatosAdjudicacion.Rows[0][17].ToString();


             if (CmbFormaPago.Text == "Extraordinario")
            {
                TxtValorExtra.Text = DatosAdjudicacion.Rows[0][18].ToString(); 
            }
             else
                  if (CmbFormaPago.Text == "Extraordinario Variado")
            {
                TxtValorExtraVariado.Text = DatosAdjudicacion.Rows[0][18].ToString();
            }
            TxtPlazoExtra.Text = DatosAdjudicacion.Rows[0][19].ToString();
            TxtTasaExtra.Text = DatosAdjudicacion.Rows[0][20].ToString();
            TxtCuotaExtra.Text = DatosAdjudicacion.Rows[0][21].ToString();
            DtpInicioExtra.Text = DatosAdjudicacion.Rows[0][22].ToString();
            TxtPorcentaje.Text = DatosAdjudicacion.Rows[0][23].ToString();
            TxtTipo.Text = DatosAdjudicacion.Rows[0][24].ToString();
            if (TxtInmueble.Text != "")
            {
                DtInmueble = conexion.MtdBuscarDataset("Select Villa,Unidad,Semana,Temporada from Inmuebles  Where IdInmueble = '" + TxtInmueble.Text + "'");
                TxtVilla.Text = DtInmueble.Rows[0][0].ToString();
                TxtUnidad.Text = DtInmueble.Rows[0][1].ToString();
                TxtSemana.Text = DtInmueble.Rows[0][2].ToString();
                TxtTemporada.Text = DtInmueble.Rows[0][3].ToString();
                
            }
            DgvCuotas.Rows.Clear();
            for (int i = 0; i < (DtFinanciacion.Rows.Count); i++)
            {
                DgvCuotas.Rows.Add(DtFinanciacion.Rows[i][0], DtFinanciacion.Rows[i][1], DtFinanciacion.Rows[i][2], DtFinanciacion.Rows[i][3], DtFinanciacion.Rows[i][4], DtFinanciacion.Rows[i][5]);

            }
            MtdTotal();
        }
//===================================================================================================================================================
// F I N A L     M E T O D O   D A T O S   A D J U D I C A C I O N
//===================================================================================================================================================

        private void MtdLoadMod()
        {
         
            MtdDatosAdjudicacion();
            MtdDatosCtaIni();
            MtdDatosContado();
            MtdDatosExtraVariado();
         
            switch (CmbFormaPago.Text)
            {
                case "Contado":
                    MtdContado();
                    break;

                case "Credicontado":
                    MtdCredicontado();
                    break;

                case "Credito":
                    MtdCredito();
                    break;

                case "Extraordinario":
                    MtdExtraordinario();
                    break;

                case "Extraordinario Variado":
                    MtdExtraordinarioVariado();
                    break;
                default:

                    break;
            }
            MtdDiferencia();
        }

        private void MtdLoadPIV()
        {

            MtdDatosAdjudicacion();
            MtdDatosCtaIni();
            MtdDatosContado();

            switch (CmbFormaPago.Text)
            {
                case "Credicontado":
                    MtdCredicontado();
                    break;

                case "Credito":
                    MtdCredito();
                    break;
                default:
                    break;
            }
            MtdDiferencia();
        }
        //===================================================================================================================================================
        // I N I C I O   M E T O D O   D A T O S   C T A   I N I C I A L
        //===================================================================================================================================================
        private void MtdDatosCtaIni()
        {
            DgvCtaInicial.AutoGenerateColumns = false;
            DgvCtaInicial.Columns[0].DataPropertyName = "Dia";
            DgvCtaInicial.Columns[1].DataPropertyName = "Mes";
            DgvCtaInicial.Columns[2].DataPropertyName = "Ano";
            DgvCtaInicial.Columns[3].DataPropertyName = "Valor";
            System.Data.DataTable DtDatosReg;
            if (tipoContrato == "PIV")
            {
                DtDatosReg = conexion.MtdBuscarDataset("select day(fecha) Dia , MONTH(fecha) Mes,year(fecha) Ano," +
            "Capital_USD, Cuota_USD from financiacion where Concepto= 'CI' AND idadjudicacion='" + LblAdjudicacion.Text + "'");
                for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
                {
                    DgvCtaInicial.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3],
                        DtDatosReg.Rows[i][4]);

                }
            }
            else
            {
                DtDatosReg = conexion.MtdBuscarDataset("select day(fecha) Dia , MONTH(fecha) Mes,year(fecha) Ano," +
            "Capital from financiacion where Concepto= 'CI' AND idadjudicacion='" + LblAdjudicacion.Text + "'");
                for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
                {
                    DgvCtaInicial.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3]);

                }
            }
            
            
            CuentaIni = DgvCtaInicial.RowCount - 1;
        }
        //===================================================================================================================================================
        //  F I N A L   M E T O D O   D A T O S   C U O T A   I N I C I A L
        //===================================================================================================================================================


        //===================================================================================================================================================
        // I N I C I O   M E T O D O   D A T O S   C O N T A D O
        //===================================================================================================================================================
        private void MtdDatosContado()
        {
            DgvContado.AutoGenerateColumns = false;
            DgvContado.Columns[0].DataPropertyName = "Dia";
            DgvContado.Columns[1].DataPropertyName = "Mes";
            DgvContado.Columns[2].DataPropertyName = "Ano";
            DgvContado.Columns[3].DataPropertyName = "Valor";



            System.Data.DataTable DtDatosReg = conexion.MtdBuscarDataset("select day(fecha) Dia , MONTH(fecha) Mes,year(fecha) Ano," +
             "Capital from financiacion where Concepto= 'CO' AND idadjudicacion='" + LblAdjudicacion.Text + "'");
            for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
            {
                DgvContado.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3]);

            }

            CuentaIni = DgvContado.RowCount - 1;
        }
        //===================================================================================================================================================
        //  F I N A L   M E T O D O   D A T O S   C O N T A D O
        //===================================================================================================================================================



        //===================================================================================================================================================
        // I N I C I O   M E T O D O   D A T O S  E X T R A   V A R I A D O
        //===================================================================================================================================================
        private void MtdDatosExtraVariado()
        {
            DgvCuotaExtraVariado.AutoGenerateColumns = false;
            DgvCuotaExtraVariado.Columns[0].DataPropertyName = "Dia";
            DgvCuotaExtraVariado.Columns[1].DataPropertyName = "Mes";
            DgvCuotaExtraVariado.Columns[2].DataPropertyName = "Ano";
            DgvCuotaExtraVariado.Columns[3].DataPropertyName = "Capital";
            System.Data.DataTable DtDatosReg = conexion.MtdBuscarDataset("select day(fecha) Dia , MONTH(fecha) Mes,year(fecha) Ano," +
            "Capital from financiacion where Concepto= 'CE' AND idadjudicacion='" + LblAdjudicacion.Text + "'");
            for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
            {
                DgvCuotaExtraVariado.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3]);

            }

            CuentaIni = DgvCuotaExtraVariado.RowCount - 1;
        }
        //===================================================================================================================================================
        //  F I N A L   M E T O D O   D A T O S  E X T R A   V A R I A D O
        //===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   L I M P I A R
//===================================================================================================================================================
        private void MtdLimpiar()
        {
            TxtReserva.Text = "";
            TxtContrato.Text = "";
            TxtTitular1.Text = "";
            LblNombreTitular.Text = "";
            TxtTitular2.Text = "";
            LblNombreTitular2.Text = "";
            TxtTitular3.Text = "";
            LblNombreTitular3.Text = "";
            TxtInmueble.Text = "";
            TxtVilla.Text = "";
            TxtUnidad.Text = "";
            TxtSemana.Text = "";
            TxtTemporada.Text = "";
            TxtTipo.Text = "";
            CmbColor.Text = "";
            TxtTemporada.Text = "";
            TxtValorContrato.Text = "0";
            TxtGastoLegal.Text = "0";
            TxtObservacion.Text = "";
            TxtValorExtra.Text = "0";
            TxtValorFnc.Text = "0";
            TxtValorContado.Text = "0";
            TxtValorExtraVariado.Text = "0";
            TxtPlazoExtra.Text = "0";
            TxtPlazoFnc.Text = "0";
            TxtCuotaExtra.Text = "0";
            TxtCuotaFnc.Text = "0";
          }
//===================================================================================================================================================
// F I N A L    M E T O D O   L I M P I A R
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O    V A L I D A R  T A R I F A S
//===================================================================================================================================================
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
//===================================================================================================================================================
// F I N A L    M E T O D O    V A L I D A R   T A R I F A S 
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdContado
//===================================================================================================================================================
        private void MtdContado()
        {
            PnlDatosContado.Visible = true;
            PnlDatosExtra.Visible = false;
            PnlDatosFnc.Visible = false;
            PnlDatosExtraVariado.Visible = false;
            PnlDatosContado.Location = new System.Drawing.Point(358, 238);
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdContado
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdCredicontado
//===================================================================================================================================================
        private void MtdCredicontado()
        {
            PnlDatosContado.Visible = false;
            PnlDatosExtra.Visible = false;
            PnlDatosExtraVariado.Visible = false;     
            PnlDatosFnc.Visible = true;
            TxtTasaFnc.Text = "0";
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdCredicontado
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdCredito
//===================================================================================================================================================
        private void MtdCredito()
        {
            PnlDatosContado.Visible = false;
            PnlDatosExtra.Visible = false;
            PnlDatosExtraVariado.Visible = false;
            PnlDatosFnc.Visible = true;
           TxtTasaFnc.Text = TxtInteresCte.Text;
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdCredito
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdExtraordinario
//===================================================================================================================================================
        private void MtdExtraordinario()
        {
            PnlDatosExtraVariado.Visible = false;
            PnlDatosContado.Visible = false;
            PnlDatosExtra.Visible = true;
            PnlDatosFnc.Visible = true;
            TxtTasaFnc.Text = TxtInteresCte.Text;
            PnlDatosExtra.Location = new System.Drawing.Point(15, 447);
            TxtTasaExtra.Text = Text = TxtInteresCte.Text;
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdExtraordinario
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdExtraordinarioVariado
//===================================================================================================================================================
        private void MtdExtraordinarioVariado()
        {
            PnlDatosContado.Visible = false;
            PnlDatosExtra.Visible = false;
            PnlDatosExtraVariado.Visible = true;
            PnlDatosExtraVariado.Location = new System.Drawing.Point(15, 447);
            PnlDatosFnc.Visible = true;
            TxtTasaFnc.Text = TxtInteresCte.Text;

        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdExtraordinarioVariado
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdLimpiarCambio
//===================================================================================================================================================
        private void MtdLimpiarCambio()
        {
            TxtValorExtra.Text = "0";
            TxtValorFnc.Text = "0";
            TxtValorContado.Text = "0";
            TxtValorExtraVariado.Text = "0";
            TxtPlazoExtra.Text = "0";
            TxtPlazoFnc.Text = "0";
            TxtCuotaExtra.Text = "0";
            TxtCuotaFnc.Text = "0";
            if (DgvContado.RowCount > 1)
            {
                DgvContado.Rows.Clear();
            }
            if (DgvCuotaExtraVariado.RowCount > 1)
            {
                DgvCuotaExtraVariado.Rows.Clear();
            }
            MtdDiferencia();
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdLimpiarCambio
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdDiferencia
//===================================================================================================================================================
        private void MtdDiferencia()
        {
            Diferencia = Convert.ToDecimal(TxtValorContrato.Text) - Convert.ToDecimal(TxtValorContado.Text) - Convert.ToDecimal(TxtValorFnc.Text) - Convert.ToDecimal(TxtValorExtra.Text) -
            Convert.ToDecimal(TxtValorIni.Text) - Convert.ToDecimal(TxtValorExtraVariado.Text);
            LblDiferencia.Text = Convert.ToString(Diferencia);
            this.LblDiferencia.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblDiferencia.Text));
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdDiferencia
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdCalculoCuotaExtra
//===================================================================================================================================================
        private void MtdCalculoCuotaExtra()
        {
            TxtCuotaExtra.Text = MtdCalculoCuota(Convert.ToDouble(TxtValorExtra.Text), Convert.ToDouble(TxtTasaExtra.Text),
                    Convert.ToDouble(CmbPeriodoExtra.Text), Convert.ToDouble(TxtPlazoExtra.Text));
            this.TxtCuotaExtra.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtCuotaExtra.Text));
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdCalculoCuotaExtra
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdCalculoCuota
//===================================================================================================================================================
        public string MtdCalculoCuota(double capital, double tasaInteres, double periodo, double plazo)
        {
            double CuotaFijaCalculada;
            periodo = (30 / periodo) * 12;
            if (tasaInteres > 0)
            {

                double a, b, x;

                a = (1 + tasaInteres / (periodo * 100));
                b = plazo;
                x = Math.Pow(a, b);
                x = 1 / x;
                x = 1 - x;
                CuotaFijaCalculada = (capital) * (tasaInteres / (periodo * 100)) / x;

            }
            else
            {
                CuotaFijaCalculada = Math.Round((capital / plazo), Convert.ToInt16(LblDecimal.Text));

            }
            return Convert.ToString(Math.Round(CuotaFijaCalculada, Convert.ToInt16(LblDecimal.Text)));
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdCalculoCuota
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdCalculoCuotaFnc
//===================================================================================================================================================
        private void MtdCalculoCuotaFnc()
        {           
            TxtCuotaFnc.Text = MtdCalculoCuota(Convert.ToDouble(TxtValorFnc.Text), Convert.ToDouble(TxtTasaFnc.Text),
            Convert.ToDouble(CmbPeriodoFnc.Text), Convert.ToDouble(TxtPlazoFnc.Text));
            
            this.TxtCuotaFnc.Text = String.Format("{0:#,##0.00; -$#,##0.00 ;0.00}", decimal.Parse(this.TxtCuotaFnc.Text));
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdCalculoCuotaFnc
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   MtdValidarAdd
//===================================================================================================================================================
        private void MtdValidarAdd()
        {
            DatosdeErrores.Clear();
            CuentaErrores = 0;
            decimal Mininicial= Math.Round((Convert.ToDecimal(TxtValorContrato.Text) * Convert.ToDecimal(TxtPorcentaje.Text)/100),Convert.ToInt16( LblDecimal.Text));

                
            if (Convert.ToDecimal(TxtValorContrato.Text) <= 0)
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Valor de Venta No Puede Ser 0");
                TxtValorContrato.BackColor = Color.Blue;
            }

            if (Convert.ToDecimal(TxtValorBase.Text) <= 0)
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Valor de Base No Puede Ser 0");
                TxtValorBase.BackColor = Color.Blue;
            }

            
            if (TxtContrato.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Ingresar Numero Contrato");
                TxtContrato.BackColor = Color.Blue;
            }
           
            if (Convert.ToDouble(LblDiferencia.Text) != 0)
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Documento Descuadrado");
            }
            if (Convert.ToDecimal(TxtValorIni.Text) <Mininicial )
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Cuota Inicial es Menor al " + TxtPorcentaje.Text + "%");
            }

            if (CmbFormaPago.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccion Forma de pago");
                CmbFormaPago.BackColor = Color.Blue;
            }

            if ((CmbFormaPago.Text == "Credito") & (TxtPlazoFnc.Text == "0"))
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Plazo de Financiacion No puede ser 0");
                TxtPlazoFnc.BackColor = Color.Blue;
            }

            if ((CmbFormaPago.Text == "Credicontado") & (TxtPlazoFnc.Text == "0"))
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Plazo de Financiacion No puede ser 0");
                TxtPlazoFnc.BackColor = Color.Blue;
            }

            if ((CmbFormaPago.Text == "Extraordinario") & (TxtPlazoExtra.Text == "0"))
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Plazo de Extraordinario No puede ser 0");
                TxtPlazoExtra.BackColor = Color.Blue;
            }

            if ((CmbFormaPago.Text == "Extraordinario") & (TxtPlazoFnc.Text == "0"))
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Plazo de Financiacion No puede ser 0");
                TxtPlazoFnc.BackColor = Color.Blue;
            }
            
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   MtdValidarAdd
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   C U O T A S
//===================================================================================================================================================
        public System.Data.DataTable MtdCuotas(double tasaInteres, int plazo, double capital, int periodo, DateTime fechaInicio)
        {
            double CuotaFijaCalculada;

            if (tasaInteres > 0)
            {
                double a, b, x;

                a = (1 + tasaInteres / (periodo * 100));
                b = plazo;
                x = Math.Pow(a, b);
                x = 1 / x;
                x = 1 - x;
                CuotaFijaCalculada = Math.Round(((capital) * (tasaInteres / (periodo * 100)) / x), Convert.ToInt16(LblDecimal.Text));
            }

            else
            {
                CuotaFijaCalculada = Math.Round((capital / plazo), Convert.ToInt16(LblDecimal.Text));
            }

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
            for (int i = 1; i < plazo + 1; i++)
            {
                Fecha = fechaInicio.AddMonths(12 / periodo * (i - 1));
                InteresCuota = Math.Round(((SaldoCuota * (12 / periodo * 30) * tasaInteres) / 36000), Convert.ToInt16(LblDecimal.Text));
                CapitalCuota = Math.Round((CuotaFijaCalculada - InteresCuota), Convert.ToInt16(LblDecimal.Text));
               
               
                if (i==plazo)
                {
                    CuotaCuota = Math.Round((SaldoCuota + InteresCuota), Convert.ToInt16(LblDecimal.Text));
                    table.Rows.Add(Fecha, i, CuotaCuota, SaldoCuota, InteresCuota, SaldoCuota);
                    SaldoCuota = 0;
                }
                else
                {
                    CuotaCuota = Math.Round((CapitalCuota + InteresCuota), Convert.ToInt16(LblDecimal.Text));
                    SaldoCuota = Math.Round((SaldoCuota - CapitalCuota), Convert.ToInt16(LblDecimal.Text));
                    table.Rows.Add(Fecha, i, CuotaCuota, CapitalCuota, InteresCuota, SaldoCuota);
                }
            }

            return table;
        }
//===================================================================================================================================================
//F I N A L    M E T O D O   C U O T A S
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O  MtdoDatosCredito
//=================================================================================================================================================== 
        private void MtdoDatosCredito()
        {
            string cot = "0";
            DgvCuotas.Visible = true;
            decimal SumaCapital = 0, SumaInteres = 0;
            System.Data.DataTable credito = new System.Data.DataTable();
            credito = MtdCuotas(Convert.ToDouble(TxtTasaFnc.Text), Convert.ToInt16(TxtPlazoFnc.Text), Convert.ToDouble(TxtValorFnc.Text), Convert.ToInt16(30 / Convert.ToDouble(CmbPeriodoFnc.Text) * 12), DtpInicioFnc.Value);
            DateTime FechaIni;
            decimal CapitalIni=0;
            int CTAIN = 0;

            DgvCuotas.Rows.Clear();

            for (int i = 0; i < (DgvCtaInicial.Rows.Count - 1); i++)
            {
                CTAIN = CTAIN + 1;

                if (DgvCtaInicial.Rows[i].Cells[0].Value == null || DgvCtaInicial.Rows[i].Cells[0].Value == "" || DgvCtaInicial.Rows[i].Cells[1].Value == null || DgvCtaInicial.Rows[i].Cells[1].Value == "" || DgvCtaInicial.Rows[i].Cells[2].Value == null || DgvCtaInicial.Rows[i].Cells[2].Value == "")
                {
                   
                    MessageBox.Show("Las fechas de la couta inicial no pueden tener valores en blanco ", "" + "Nueva adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    cot = "1";

                }
                else

                {
                    FechaIni = Convert.ToDateTime((Convert.ToString(DgvCtaInicial.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[2].Value)));
                    CapitalIni = Convert.ToDecimal(DgvCtaInicial.Rows[i].Cells[3].Value);
                    DgvCuotas.Rows.Add("CI", CTAIN, FechaIni, CapitalIni, 0, CapitalIni);
                
                }
                 
            }
            if (cot == "0") { 
            for (int i = 0; i < (credito.Rows.Count); i++)
            {
                DgvCuotas.Rows.Add("FN", credito.Rows[i][1], credito.Rows[i][0], credito.Rows[i][3], credito.Rows[i][4], credito.Rows[i][2]);
            }
            }


             if (cot == "0") { 
            for (int i = 0; i < (DgvCuotas.Rows.Count); i++)
            {
                SumaCapital += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[3].Value));
                SumaInteres += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value));
            }
            int a = DgvCuotas.Rows.Count - 1;
            DgvCuotas.Rows[a].Cells[2].Value = "T O T A L  . .";
            DgvCuotas.Rows[a].Cells[3].Value = SumaCapital;
            DgvCuotas.Rows[a].Cells[4].Value = SumaInteres;
            DgvCuotas.Rows[a].DefaultCellStyle.ForeColor = Color.Black;
            ValidacionCapital = SumaCapital;
             }
        }
//===================================================================================================================================================
//F I N A L    M E T O D O   MtdoDatosCredito
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O  MtdoDatosExtraordinario
//=================================================================================================================================================== 
        private void MtdoDatosExtraordinario()
        {
            DgvCuotas.Visible = true;
           
            System.Data.DataTable Extraordinario = new System.Data.DataTable();
            System.Data.DataTable credito = new System.Data.DataTable();
            DateTime FechaIni;
            decimal CapitalIni = 0;
            credito = MtdCuotas(Convert.ToDouble(TxtTasaFnc.Text), Convert.ToInt16(TxtPlazoFnc.Text), Convert.ToDouble(TxtValorFnc.Text), Convert.ToInt16(30 / Convert.ToDouble(CmbPeriodoFnc.Text) * 12), DtpInicioFnc.Value);

            Extraordinario = MtdCuotas(Convert.ToDouble(TxtTasaExtra.Text), Convert.ToInt16(TxtPlazoExtra.Text), Convert.ToDouble(TxtValorExtra.Text), Convert.ToInt16(30 / Convert.ToDouble(CmbPeriodoExtra.Text) * 12), DtpInicioExtra.Value);

            int CTAIN = 0;


            DgvCuotas.Rows.Clear();

            for (int i = 0; i < (DgvCtaInicial.Rows.Count - 1); i++)
            {
                CTAIN = CTAIN + 1;
                FechaIni = Convert.ToDateTime((Convert.ToString(DgvCtaInicial.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[2].Value)));
                CapitalIni = Convert.ToDecimal(DgvCtaInicial.Rows[i].Cells[3].Value);
                DgvCuotas.Rows.Add("CI", CTAIN, FechaIni, CapitalIni, 0, CapitalIni);
            }


            for (int i = 0; i < (credito.Rows.Count); i++)
            {
                DgvCuotas.Rows.Add("FN", credito.Rows[i][1], credito.Rows[i][0], credito.Rows[i][3], credito.Rows[i][4], credito.Rows[i][2]);

            }
            for (int i = 0; i < (Extraordinario.Rows.Count); i++)
            {
                DgvCuotas.Rows.Add("CE", Extraordinario.Rows[i][1], Extraordinario.Rows[i][0], Extraordinario.Rows[i][3], Extraordinario.Rows[i][4], Extraordinario.Rows[i][2]);

            }

            MtdTotal();
        }
//===================================================================================================================================================
//F I N A L    M E T O D O   MtdoDatosExtraordinario
//===================================================================================================================================================



        private void MtdTotal()
        {
            decimal SumaCapital = 0, SumaInteres = 0;
            for (int i = 0; i < (DgvCuotas.Rows.Count); i++)
            {
                SumaCapital += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[3].Value));
                SumaInteres += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value));
            }
            int a = DgvCuotas.Rows.Count - 1;
            DgvCuotas.Rows[a].Cells[2].Value = "T O T A L  . .";
            DgvCuotas.Rows[a].Cells[3].Value = SumaCapital;
            DgvCuotas.Rows[a].Cells[4].Value = SumaInteres;
            DgvCuotas.Rows[a].DefaultCellStyle.ForeColor = Color.Black;
            ValidacionCapital = SumaCapital;
        }


//===================================================================================================================================================
// I N I C I O   M E T O D O  MtdoDatosContado
//===================================================================================================================================================
        private void MtdoDatosContado()
        {

            decimal SumaCapital = 0, SumaInteres = 0;
            int CTAIN = 0;
            int CTACON = 0;
            DateTime FechaIni,FechaContado;
            decimal CapitalIni = 0,CapitalContado;
            DgvCuotas.Rows.Clear();

            for (int i = 0; i < (DgvCtaInicial.Rows.Count - 1); i++)
            {
                CTAIN = CTAIN + 1;
                FechaIni = Convert.ToDateTime((Convert.ToString(DgvCtaInicial.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[2].Value)));
                CapitalIni = Convert.ToDecimal(DgvCtaInicial.Rows[i].Cells[3].Value);
                DgvCuotas.Rows.Add("CI", CTAIN, FechaIni, CapitalIni, 0, CapitalIni);

            }

            for (int i = 0; i < (DgvContado.Rows.Count - 1); i++)
            {
                CTACON = CTACON + 1;
                FechaContado = Convert.ToDateTime((Convert.ToString(DgvContado.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvContado.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvContado.Rows[i].Cells[2].Value)));
                CapitalContado = Convert.ToDecimal(DgvContado.Rows[i].Cells[3].Value);
                DgvCuotas.Rows.Add("CO", CTACON, FechaContado, CapitalContado, 0, CapitalContado);

            }


            for (int i = 0; i < (DgvCuotas.Rows.Count); i++)
            {
                SumaCapital += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[3].Value));
                SumaInteres += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value));
            }
            int a = DgvCuotas.Rows.Count - 1;
            DgvCuotas.Rows[a].Cells[2].Value = "T O T A L  . .";
            DgvCuotas.Rows[a].Cells[3].Value = SumaCapital;
            DgvCuotas.Rows[a].Cells[4].Value = SumaInteres;
            DgvCuotas.Rows[a].DefaultCellStyle.ForeColor = Color.Black;
            ValidacionCapital = SumaCapital;
        }
//===================================================================================================================================================
//F I N A L    M E T O D O   MtdoDatosContado
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O  MtdoDatoExtraVariado
//===================================================================================================================================================
        private void MtdoDatoExtraVariado()
        {
            DgvCuotas.Visible = true;
            decimal SumaCapital = 0, SumaInteres = 0;
            System.Data.DataTable credito = new System.Data.DataTable();
            credito = MtdCuotas(Convert.ToDouble(TxtTasaFnc.Text), Convert.ToInt16(TxtPlazoFnc.Text), Convert.ToDouble(TxtValorFnc.Text), Convert.ToInt16(30 / Convert.ToDouble(CmbPeriodoFnc.Text) * 12), DtpInicioFnc.Value);

            int CTAIN = 0;
            int CTAEXT = 0;
            DateTime FechaIni, Fechaextra;
            decimal CapitalIni = 0, Capitalextra;
            DgvCuotas.Rows.Clear();

            for (int i = 0; i < (DgvCtaInicial.Rows.Count - 1); i++)
            {
                CTAIN = CTAIN + 1;
                FechaIni = Convert.ToDateTime((Convert.ToString(DgvCtaInicial.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvCtaInicial.Rows[i].Cells[2].Value)));
                CapitalIni = Convert.ToDecimal(DgvCtaInicial.Rows[i].Cells[3].Value);
                DgvCuotas.Rows.Add("CI", CTAIN, FechaIni, CapitalIni, 0, CapitalIni);

            }


            for (int i = 0; i < (credito.Rows.Count); i++)
            {
                DgvCuotas.Rows.Add("FN", credito.Rows[i][1], credito.Rows[i][0], credito.Rows[i][3], credito.Rows[i][4], credito.Rows[i][2]);

            }


            for (int i = 0; i < (DgvCuotaExtraVariado.Rows.Count - 1); i++)
            {
                CTAEXT = CTAEXT + 1;
                Fechaextra = Convert.ToDateTime((Convert.ToString(DgvCuotaExtraVariado.Rows[i].Cells[0].Value) + "-" + Convert.ToString(DgvCuotaExtraVariado.Rows[i].Cells[1].Value) + "-" + Convert.ToString(DgvCuotaExtraVariado.Rows[i].Cells[2].Value)));
                Capitalextra = Convert.ToDecimal(DgvCuotaExtraVariado.Rows[i].Cells[3].Value);
                DgvCuotas.Rows.Add("CE", CTAEXT, Fechaextra, Capitalextra, 0, Capitalextra);
            }            

            

            for (int i = 0; i < (DgvCuotas.Rows.Count); i++)
            {
                SumaCapital += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[3].Value));
                SumaInteres += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value));
            }


            int a = DgvCuotas.Rows.Count - 1;
            DgvCuotas.Rows[a].Cells[2].Value = "T O T A L  . .";
            DgvCuotas.Rows[a].Cells[3].Value = SumaCapital;
            DgvCuotas.Rows[a].Cells[4].Value = SumaInteres;
            DgvCuotas.Rows[a].DefaultCellStyle.ForeColor = Color.Black;
            ValidacionCapital = SumaCapital;
        }
//===================================================================================================================================================
//F I N A L    M E T O D O   MtdoDatoExtraVariado
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D O   A D I C I O N A R   A D J U D I C A C I O N
//===================================================================================================================================================
        private void MtdAdicionar()
        {
            string VarIdCta, VarConcepto;
            decimal VarCapital, VarInteres, VarCuota;
            int VarNumcuota;
            DateTime VarFecha;
            MtdValidarAdd();
            if (CuentaErrores > 0)
            {
                FrmMensajeError frmMensajeError = new FrmMensajeError();
                frmMensajeError.LblErrores.DataSource = DatosdeErrores;
                frmMensajeError.ShowDialog();
            }
            else
            {
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    Consecutivo = Convert.ToInt16(conexion.MtdBscDatos("select if(max(IdAdjudicacion)is null,1,max(IdAdjudicacion+1))from Adjudicacion"));

                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);




                string StrAddAdjudicacion = " INSERT INTO adjudicacion ( IdAdjudicacion, Fecha, Contrato, IdProyecto, IdInmueble, TipodeAdjudicacion, Temporada, Grado, IdTercero1,"+
                "IdTercero2, Idtercero3, FormaPago, Valor, GastosLegales, CuotaInicial, contado, Financiacion, PlazoFnc, TasaFnc, CuotaFnc, InicioFnc, Extraordinaria, PlazoExtra, TasaExtra, CuotaExtra,"+
                "InicioExtra, Estado, Usuario, FechaOperacion, Porcentaje, BaseComision,Observacion,FechaContrato)" +
                 " VALUES ( @IdAdjudicacion, @Fecha, @Contrato, @IdProyecto, @IdInmueble, @TipodeAdjudicacion, @Temporada, @Grado, @IdTercero1, @IdTercero2, @Idtercero3, @FormaPago,"+
                 " @Valor, @GastosLegales, @CuotaInicial, @contado, @Financiacion, @PlazoFnc, @TasaFnc, @CuotaFnc, @InicioFnc, @Extraordinaria, @PlazoExtra, @TasaExtra, @CuotaExtra," +
                "@InicioExtra, @Estado, @Usuario, @FechaOperacion, @Porcentaje, @BaseComision,@Observacion,@FechaContrato)";


                string StrAddFnc = "insert into financiacion (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,UltimaFechaPago,Usuario,FechaOperacion) " +
                        "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital,@Interes,@Cuota,@Capital,@Interes,@Cuota,@FechaFnc,@Usuario,@FechaOperacion)";

                string StrGastosLegal = "insert into financiacion (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,UltimaFechaPago,Usuario,FechaOperacion) " +
                      "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital,@Interes,@Cuota,@Capital,@Interes,@Cuota,@FechaFnc,@Usuario,@FechaOperacion)";

                    string StrModReserva = "Update Reservas Set Estado = 'Adjudicado',IdAdjudicacion =@IdAdjudicacion Where idReserva ='"+TxtReserva.Text+"'";

                    string StrModInmuebles = "Update Inmuebles Set Estado = 'Adjudicado' Where IdInmueble ='" +TxtInmueble.Text + "'";

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
                        CmdAddPrm.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@GastosLegales", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaInicial", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Contado", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Financiacion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoFnc", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Extraordinaria", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoExtra", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioExtra", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Porcentaje", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@BaseComision", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Observacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@IdCta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Capital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Interes", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Cuota", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@NumCuota", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        

                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                        CmdAddPrm.Parameters["@Fecha"].Value = DtpFecha.Value;
                        CmdAddPrm.Parameters["@FechaContrato"].Value = DtpFechaContrato.Value;
                        CmdAddPrm.Parameters["@Contrato"].Value =TxtContrato.Text ;
                        CmdAddPrm.Parameters["@IdProyecto"].Value =FrmLogeo.Proyecto ;
                        CmdAddPrm.Parameters["@IdInmueble"].Value = TxtInmueble.Text;
                        CmdAddPrm.Parameters["@TipodeAdjudicacion"].Value = TxtTipo.Text;
                        CmdAddPrm.Parameters["@Temporada"].Value =TxtTemporada.Text ;
                        CmdAddPrm.Parameters["@Grado"].Value = CmbColor.Text;
                        CmdAddPrm.Parameters["@IdTercero1"].Value = TxtTitular1.Text;
                        if (TxtTitular2.Text == "")
                        {
                            CmdAddPrm.Parameters["@IdTercero2"].Value = null;
                        }
                        else
                        {
                            CmdAddPrm.Parameters["@IdTercero2"].Value = TxtTitular2.Text;
                        }
                        if (TxtTitular2.Text == "")
                        {
                            CmdAddPrm.Parameters["@IdTercero3"].Value = null;
                        }
                        else
                        {
                            CmdAddPrm.Parameters["@IdTercero3"].Value = TxtTitular3.Text;
                        }                        
                        
                        CmdAddPrm.Parameters["@FormaPago"].Value = CmbFormaPago.Text;
                        CmdAddPrm.Parameters["@Valor"].Value = Convert.ToDecimal(TxtValorContrato.Text);
                        CmdAddPrm.Parameters["@GastosLegales"].Value = Convert.ToDecimal(TxtGastoLegal.Text);
                        CmdAddPrm.Parameters["@CuotaInicial"].Value = Convert.ToDecimal( TxtValorIni.Text);
                        CmdAddPrm.Parameters["@Contado"].Value = Convert.ToDecimal( TxtValorContado.Text);
                        CmdAddPrm.Parameters["@Financiacion"].Value = Convert.ToDecimal( TxtValorFnc.Text);
                        CmdAddPrm.Parameters["@PlazoFnc"].Value = Convert.ToInt16( TxtPlazoFnc.Text);
                        CmdAddPrm.Parameters["@TasaFnc"].Value = Convert.ToDecimal( TxtTasaFnc.Text);
                        CmdAddPrm.Parameters["@CuotaFnc"].Value =Convert.ToDecimal( TxtCuotaFnc.Text);
                        CmdAddPrm.Parameters["@InicioFnc"].Value = DtpInicioFnc.Value;
                        CmdAddPrm.Parameters["@Extraordinaria"].Value = (Convert.ToDecimal(TxtValorExtra.Text) + Convert.ToDecimal(TxtValorExtraVariado.Text));
                        CmdAddPrm.Parameters["@PlazoExtra"].Value = Convert.ToInt16(TxtPlazoExtra.Text); ;
                        CmdAddPrm.Parameters["@TasaExtra"].Value = Convert.ToDecimal(TxtTasaExtra.Text);  
                        CmdAddPrm.Parameters["@CuotaExtra"].Value = Convert.ToDecimal(TxtCuotaExtra.Text);  
                        CmdAddPrm.Parameters["@InicioExtra"].Value =DtpInicioExtra.Value ;
                        CmdAddPrm.Parameters["@Estado"].Value ="Pendiente" ;
                        CmdAddPrm.Parameters["@Usuario"].Value =FrmLogeo.Usuario ;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value =DateTime.Now.Date ;
                        CmdAddPrm.Parameters["@Porcentaje"].Value = Convert.ToDecimal( TxtPorcentaje.Text);
                        CmdAddPrm.Parameters["@BaseComision"].Value = Convert.ToDecimal(TxtValorBase.Text);
                        CmdAddPrm.Parameters["@Observacion"].Value = TxtObservacion.Text;

                        CmdAddPrm.CommandText = StrAddAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();

                        if (Convert.ToDecimal(TxtGastoLegal.Text) > 0)
                        {
                            CmdAddPrm.Parameters["@IdCta"].Value = "GA1ADJ" + Consecutivo;
                            CmdAddPrm.Parameters["@Concepto"].Value = "GA";
                            CmdAddPrm.Parameters["@FechaFnc"].Value = DtpFecha.Value;
                            CmdAddPrm.Parameters["@Capital"].Value = Convert.ToDecimal(TxtGastoLegal.Text);
                            CmdAddPrm.Parameters["@Interes"].Value = 0;
                            CmdAddPrm.Parameters["@Cuota"].Value = Convert.ToDecimal(TxtGastoLegal.Text);
                            CmdAddPrm.Parameters["@NumCuota"].Value = 1;

                            CmdAddPrm.CommandText = StrGastosLegal;
                            CmdAddPrm.ExecuteNonQuery();
                        }

                        for (int i = 0; i < DgvCuotas.Rows.Count-1; i++)
                        {                         

                            VarConcepto = DgvCuotas.Rows[i].Cells[0].Value.ToString();
                            VarNumcuota = Convert.ToInt16(DgvCuotas.Rows[i].Cells[1].Value);
                            VarIdCta = VarConcepto + VarNumcuota + "ADJ" + Consecutivo;
                            VarFecha = Convert.ToDateTime(DgvCuotas.Rows[i].Cells[2].Value);
                            VarCapital = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[3].Value);
                            VarInteres = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value);
                            VarCuota = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[5].Value);

                            CmdAddPrm.Parameters["@IdCta"].Value = VarIdCta;
                            CmdAddPrm.Parameters["@Concepto"].Value = VarConcepto;
                            CmdAddPrm.Parameters["@FechaFnc"].Value = VarFecha;
                            CmdAddPrm.Parameters["@Capital"].Value = VarCapital;
                            CmdAddPrm.Parameters["@Interes"].Value = VarInteres;
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
                        MessageBox.Show("Registro Adicionado", "Adicionar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                        BtnValidar.Enabled = false;
                        LblAdjudicacion.Text = Consecutivo.ToString();
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }
                }
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    A D I C I O N A R   A D J U D I C A C I O N
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O  M E T O D O   M O D I F I C A R   A D J U D I C A C I O N
//===================================================================================================================================================
        private void MtdModificar()
        {
            string VarIdCta, VarConcepto;
            decimal VarCapital, VarInteres, VarCuota;
            int VarNumcuota;
            DateTime VarFecha;
            MtdValidarAdd();
            if (CuentaErrores > 0)
            {
                FrmMensajeError frmMensajeError = new FrmMensajeError();
                frmMensajeError.LblErrores.DataSource = DatosdeErrores;
                frmMensajeError.ShowDialog();
            }
            else
            {
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    Consecutivo = Convert.ToInt16( VarIdajudicacion);

                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);


                    string ModAdjudicacion = "insert into modadjudicacion (Select * from Adjudicacion where idadjudicacion=@IdAdjudicacion)";
                    string DelAdjudicacion = "Delete  from Adjudicacion where idadjudicacion=@IdAdjudicacion";
                    string ModFinanaciacion = "insert into modfinanciacion (Select * from financiacion where idadjudicacion=@IdAdjudicacion)";
                    string DelFinanaciacion = "Delete from financiacion where idadjudicacion=@IdAdjudicacion";

                    string StrAddAdjudicacion = " INSERT INTO adjudicacion ( IdAdjudicacion, Fecha, Contrato, IdProyecto, IdInmueble, TipodeAdjudicacion, Temporada, Grado, IdTercero1," +
                    "IdTercero2, Idtercero3, FormaPago, Valor, GastosLegales, CuotaInicial, contado, Financiacion, PlazoFnc, TasaFnc, CuotaFnc, InicioFnc, Extraordinaria, PlazoExtra, TasaExtra, CuotaExtra," +
                    "InicioExtra, Estado, Usuario, FechaOperacion, Porcentaje, BaseComision,Observacion,FechaContrato)" +
                     " VALUES ( @IdAdjudicacion, @Fecha, @Contrato, @IdProyecto, @IdInmueble, @TipodeAdjudicacion, @Temporada, @Grado, @IdTercero1, @IdTercero2, @Idtercero3, @FormaPago," +
                     " @Valor, @GastosLegales, @CuotaInicial, @contado, @Financiacion, @PlazoFnc, @TasaFnc, @CuotaFnc, @InicioFnc, @Extraordinaria, @PlazoExtra, @TasaExtra, @CuotaExtra," +
                    "@InicioExtra, @Estado, @Usuario, @FechaOperacion, @Porcentaje, @BaseComision,@Observacion,@FechaContrato)";


                    string StrAddFnc = "insert into financiacion (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,Usuario,FechaOperacion) " +
                        "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital,@Interes,@Cuota,@Capital,@Interes,@Cuota,@Usuario,@FechaOperacion)";

                    string StrGastosLegal = "insert into financiacion (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,Usuario,FechaOperacion) " +
                      "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital,@Interes,@Cuota,@Capital,@Interes,@Cuota,@Usuario,@FechaOperacion)";

                 

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
                        CmdAddPrm.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@GastosLegales", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaInicial", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Contado", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Financiacion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoFnc", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Extraordinaria", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@PlazoExtra", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@TasaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@CuotaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@InicioExtra", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Porcentaje", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@BaseComision", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Observacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@IdCta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Capital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Interes", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@Cuota", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                        CmdAddPrm.Parameters.Add("@NumCuota", MySql.Data.MySqlClient.MySqlDbType.Int16);


                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                        CmdAddPrm.Parameters["@Fecha"].Value = DtpFecha.Value;
                        CmdAddPrm.Parameters["@FechaContrato"].Value = DtpFechaContrato.Value;
                        CmdAddPrm.Parameters["@Contrato"].Value = TxtContrato.Text;
                        CmdAddPrm.Parameters["@IdProyecto"].Value = FrmLogeo.Proyecto;
                        CmdAddPrm.Parameters["@IdInmueble"].Value = TxtInmueble.Text;
                        CmdAddPrm.Parameters["@TipodeAdjudicacion"].Value = TxtTipo.Text;
                        CmdAddPrm.Parameters["@Temporada"].Value = TxtTemporada.Text;
                        CmdAddPrm.Parameters["@Grado"].Value = CmbColor.Text;
                        CmdAddPrm.Parameters["@IdTercero1"].Value = TxtTitular1.Text;
                        if (TxtTitular2.Text == "")
                        {
                            CmdAddPrm.Parameters["@IdTercero2"].Value = null;
                        }
                        else
                        {
                            CmdAddPrm.Parameters["@IdTercero2"].Value = TxtTitular2.Text;
                        }
                        if (TxtTitular2.Text == "")
                        {
                            CmdAddPrm.Parameters["@IdTercero3"].Value = null;
                        }
                        else
                        {
                            CmdAddPrm.Parameters["@IdTercero3"].Value = TxtTitular3.Text;
                        }

                        CmdAddPrm.Parameters["@FormaPago"].Value = CmbFormaPago.Text;
                        CmdAddPrm.Parameters["@Valor"].Value = Convert.ToDecimal(TxtValorContrato.Text);
                        CmdAddPrm.Parameters["@GastosLegales"].Value = Convert.ToDecimal(TxtGastoLegal.Text);
                        CmdAddPrm.Parameters["@CuotaInicial"].Value = Convert.ToDecimal(TxtValorIni.Text);
                        CmdAddPrm.Parameters["@Contado"].Value = Convert.ToDecimal(TxtValorContado.Text);
                        CmdAddPrm.Parameters["@Financiacion"].Value = Convert.ToDecimal(TxtValorFnc.Text);
                        CmdAddPrm.Parameters["@PlazoFnc"].Value = Convert.ToInt16(TxtPlazoFnc.Text);
                        CmdAddPrm.Parameters["@TasaFnc"].Value = Convert.ToDecimal(TxtTasaFnc.Text);
                        CmdAddPrm.Parameters["@CuotaFnc"].Value = Convert.ToDecimal(TxtCuotaFnc.Text);
                        CmdAddPrm.Parameters["@InicioFnc"].Value = DtpInicioFnc.Value;
                        CmdAddPrm.Parameters["@Extraordinaria"].Value = (Convert.ToDecimal(TxtValorExtra.Text) + Convert.ToDecimal(TxtValorExtraVariado.Text));
                        CmdAddPrm.Parameters["@PlazoExtra"].Value = Convert.ToInt16(TxtPlazoExtra.Text); ;
                        CmdAddPrm.Parameters["@TasaExtra"].Value = Convert.ToDecimal(TxtTasaExtra.Text);
                        CmdAddPrm.Parameters["@CuotaExtra"].Value = Convert.ToDecimal(TxtCuotaExtra.Text);
                        CmdAddPrm.Parameters["@InicioExtra"].Value = DtpInicioExtra.Value;
                        CmdAddPrm.Parameters["@Estado"].Value = "Pendiente";
                        CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                        CmdAddPrm.Parameters["@Porcentaje"].Value = Convert.ToDecimal(TxtPorcentaje.Text);
                        CmdAddPrm.Parameters["@BaseComision"].Value = Convert.ToDecimal(TxtValorBase.Text);
                        CmdAddPrm.Parameters["@Observacion"].Value = TxtObservacion.Text;


                        CmdAddPrm.CommandText = ModAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();
                        CmdAddPrm.CommandText = DelAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();
                        CmdAddPrm.CommandText = ModFinanaciacion;
                        CmdAddPrm.ExecuteNonQuery();
                        CmdAddPrm.CommandText = DelFinanaciacion;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = StrAddAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();

                        if (Convert.ToDecimal(TxtGastoLegal.Text) > 0)
                        {
                            CmdAddPrm.Parameters["@IdCta"].Value = "GA1ADJ" + Consecutivo;
                            CmdAddPrm.Parameters["@Concepto"].Value = "GA";
                            CmdAddPrm.Parameters["@FechaFnc"].Value = DtpFecha.Value;
                            CmdAddPrm.Parameters["@Capital"].Value = Convert.ToDecimal(TxtGastoLegal.Text);
                            CmdAddPrm.Parameters["@Interes"].Value = 0;
                            CmdAddPrm.Parameters["@Cuota"].Value = Convert.ToDecimal(TxtGastoLegal.Text);
                            CmdAddPrm.Parameters["@NumCuota"].Value = 1;

                            CmdAddPrm.CommandText = StrGastosLegal;
                            CmdAddPrm.ExecuteNonQuery();
                        }

                        for (int i = 0; i < DgvCuotas.Rows.Count - 1; i++)
                        {

                            VarConcepto = DgvCuotas.Rows[i].Cells[0].Value.ToString();
                            VarNumcuota = Convert.ToInt16(DgvCuotas.Rows[i].Cells[1].Value);
                            VarIdCta = VarConcepto + VarNumcuota + "ADJ" + Consecutivo;
                            VarFecha = Convert.ToDateTime(DgvCuotas.Rows[i].Cells[2].Value);
                            VarCapital = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[3].Value);
                            VarInteres = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value);
                            VarCuota = Convert.ToDecimal(DgvCuotas.Rows[i].Cells[5].Value);

                            CmdAddPrm.Parameters["@IdCta"].Value = VarIdCta;
                            CmdAddPrm.Parameters["@Concepto"].Value = VarConcepto;
                            CmdAddPrm.Parameters["@FechaFnc"].Value = VarFecha;
                            CmdAddPrm.Parameters["@Capital"].Value = VarCapital;
                            CmdAddPrm.Parameters["@Interes"].Value = VarInteres;
                            CmdAddPrm.Parameters["@Cuota"].Value = VarCuota;
                            CmdAddPrm.Parameters["@NumCuota"].Value = VarNumcuota;

                            CmdAddPrm.CommandText = StrAddFnc;
                            CmdAddPrm.ExecuteNonQuery();

                           

                        }
                        myTrans.Commit();
                        MessageBox.Show("Registro Modificado", "Modificar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                        BtnValidar.Enabled = false;
                        LblAdjudicacion.Text = Consecutivo.ToString();
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }
                }
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    M O D I F I C A R  A D J U D I C A C I O N
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O  M E T O D O   E L I M I N A R   A D J U D I C A C I O N
//===================================================================================================================================================
        private void MtdEliminar()
        {          
            
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Eliminar Este Registro", "Eliminar Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    Consecutivo = Convert.ToInt16(VarIdajudicacion);

                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);


                    string ModAdjudicacion = "insert into modadjudicacion (Select * from Adjudicacion where idadjudicacion=@IdAdjudicacion)";                   
                    string ModFinanaciacion = "insert into modfinanciacion (Select * from financiacion where idadjudicacion=@IdAdjudicacion)";
                    string StrModAdjudicacion = "Update Adjudicacion Set Estado='Eliminado',Usuario=@Usuario,FechaOperacion=@FechaOperacion Where IdAdjudicacion=@IdAdjudicacion ";
                    string StrModFinanciacion = "Delete From Financiacion Where IdAdjudicacion=@IdAdjudicacion ";
                   

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
                        CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);


                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                        CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;


                        CmdAddPrm.CommandText = ModAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();
                        CmdAddPrm.CommandText = StrModAdjudicacion;
                        CmdAddPrm.ExecuteNonQuery();
                        CmdAddPrm.CommandText = ModFinanaciacion;
                        CmdAddPrm.ExecuteNonQuery();
                        CmdAddPrm.CommandText = StrModFinanciacion;
                        CmdAddPrm.ExecuteNonQuery();

                     
                     

                        
                        myTrans.Commit();
                        MessageBox.Show("Registro Eliminado", "Eliminar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnOk.Enabled = false;
                        BtnValidar.Enabled = false;
                        LblAdjudicacion.Text = Consecutivo.ToString();
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Eliminar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }               
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    E L I M I N A R  A D J U D I C A C I O N
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O  M E T O D O   D E S I S I T I R   A D J U D I C A C I O N
//===================================================================================================================================================
        private void MtdDesistir()
        {

            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Desistir Este Registro", "Desistir Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                Consecutivo = Convert.ToInt16(VarIdajudicacion);

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);


                string ModAdjudicacion =    "insert into modadjudicacion (Select * from Adjudicacion where idadjudicacion=@IdAdjudicacion)";
                string StrModAdjudicacion = "Update Adjudicacion Set Estado='Desistido',Usuario=@Usuario,FechaOperacion=@FechaOperacion Where IdAdjudicacion=@IdAdjudicacion ";
                string StrModInmuebles =    "Update inmuebles Set Estado='Libre',Usuario=@Usuario,FechaOperacion=@FechaOperacion Where IdInmueble=@IdInmueble ";


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
                    CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                    CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@IdInmueble"].Value = TxtInmueble.Text;

                    CmdAddPrm.CommandText = ModAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();
                    CmdAddPrm.CommandText = StrModAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();
                    CmdAddPrm.CommandText = StrModInmuebles;
                    CmdAddPrm.ExecuteNonQuery();
                   



                    myTrans.Commit();
                    MessageBox.Show("Registro Desistido", "Desistir Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    BtnOk.Enabled = false;
                    BtnValidar.Enabled = false;
                    LblAdjudicacion.Text = Consecutivo.ToString();
                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Desistir Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   D E S I S I T I R  A D J U D I C A C I O N
//===================================================================================================================================================

//===================================================================================================================================================
// I N I C I O  M E T O D O   A P R O B A R    A D J U D I C A C I O N
//===================================================================================================================================================
        private void MtdAprobar()
        {

            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Aprobar Este Registro", "Aprobar Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                Consecutivo = Convert.ToInt16(VarIdajudicacion);

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);


                string ModAdjudicacion = "insert into modadjudicacion (Select * from Adjudicacion where idadjudicacion=@IdAdjudicacion)";
                string StrModAdjudicacion = "Update Adjudicacion Set Estado='Aprobado',Usuario=@Usuario,FechaOperacion=@FechaOperacion Where IdAdjudicacion=@IdAdjudicacion ";



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
                    CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);


                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                    CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;


                    CmdAddPrm.CommandText = ModAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();
                    CmdAddPrm.CommandText = StrModAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();




                    myTrans.Commit();
                    MessageBox.Show("Registro Aprobado", "Aprobar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    BtnOk.Enabled = false;
                    BtnValidar.Enabled = false;
                    LblAdjudicacion.Text = Consecutivo.ToString();
                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Aprobar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   A P R O B A R  A D J U D I C A C I O N
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O  M E T O D O  exporta_a_excel
//===================================================================================================================================================
        private void exporta_a_excel()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            excel.Cells[1, 2] = "CONSULTA DE CUOTAS DE ADJUDICACION";
            excel.Cells[3, 1] = "Titular:";
            excel.Cells[3, 2] = LblNombreTitular.Text;
            excel.Cells[3, 3] = "Valor Contrato:";
            excel.Cells[3, 4] = TxtValorContrato.Text;
            excel.Cells[3, 5] = "Contrato:";
            excel.Cells[3, 6] = TxtContrato.Text;
            excel.Cells[4, 1] = "Unidad:";
            excel.Cells[4, 2] = TxtInmueble.Text;
            excel.Cells[4, 3] = "Cuota Incial:";
            excel.Cells[4, 4] = TxtValorIni.Text;
            excel.Cells[4, 5] = "Financiacion:";
            excel.Cells[4, 6] = TxtValorFnc.Text;

            foreach (DataGridViewColumn col in DgvCuotas.Columns)
            {
                ColumnIndex++;
                excel.Cells[5, ColumnIndex] = col.Name;
            }

            int rowIndex = 4;

            foreach (DataGridViewRow row in DgvCuotas.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvCuotas.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }
            }
            excel.Visible = true;

            Worksheet Libro = (Worksheet)excel.ActiveSheet;
            //Libro.Activate();
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    exporta_a_excel
//===================================================================================================================================================






        #endregion

        #region REGION DE EVENTOS DATOS

        private void TxtReserva_Enter(object sender, EventArgs e)
        {
            TxtReserva.BackColor = Color.White;
        }

        private void TxtReserva_Leave(object sender, EventArgs e)
        {
            TxtReserva.BackColor = Color.Gainsboro;
        }      

        private void DtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtContrato.Focus();
            }
        }

        private void BtnBscReserva_Click(object sender, EventArgs e)
        {
            FrmCatalogoReservas reservas = new FrmCatalogoReservas();
            reservas.ShowDialog();
            TxtReserva.Text = FrmCatalogoReservas.VarIdReserva;
            TxtContrato.Text = FrmCatalogoReservas.VarContrato;
            TxtTitular1.Text = FrmCatalogoReservas.VarIdTercero;
            LblNombreTitular.Text = FrmCatalogoReservas.VarCliente;
            TxtInmueble.Text = FrmCatalogoReservas.VarIdInmueble;
            TxtTipo.Text = FrmCatalogoReservas.VarTipoReserva;
            if (TxtInmueble.Text != "")
            {
                DtInmueble = conexion.MtdBuscarDataset("Select Villa,Unidad,Semana,Temporada from Inmuebles  Where IdInmueble = '" + TxtInmueble.Text + "'");
                TxtVilla.Text = DtInmueble.Rows[0][0].ToString();
                TxtUnidad.Text = DtInmueble.Rows[0][1].ToString();
                TxtSemana.Text = DtInmueble.Rows[0][2].ToString();
                TxtTemporada.Text = DtInmueble.Rows[0][3].ToString();
                MtdValidarTarifas(TxtTipo.Text, CmbColor.Text.ToUpper(), TxtTemporada.Text);
                TxtObservacion.Focus();
            }
        }

        private void TxtReserva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtObservacion.Focus();
            }
        }

        private void TxtContrato_Enter(object sender, EventArgs e)
        {
            TxtContrato.BackColor = Color.White; ;
        }

        private void TxtContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtTitular1.Focus();
            }
        }

        private void TxtContrato_Leave(object sender, EventArgs e)
        {
            TxtContrato.BackColor = Color.Gainsboro;
        }

        private void TxtTitular_Enter(object sender, EventArgs e)
        {
            TxtTitular1.BackColor = Color.White;
        }

        private void TxtTitular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtTitular2.Focus();
            }
        }

        private void TxtTitular_Leave(object sender, EventArgs e)
        {
            TxtTitular1.BackColor = Color.Gainsboro;
        }

        private void CmbTipo_Enter(object sender, EventArgs e)
        {
            TxtTipo.BackColor = Color.White;
        }

        private void CmbTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbColor.Focus();
            }
        }

        private void CmbTipo_Leave(object sender, EventArgs e)
        {
            TxtTipo.BackColor = Color.Gainsboro;
        }

        private void TxtInmueble_Enter(object sender, EventArgs e)
        {
            CmbColor.BackColor = Color.White;
        }

        private void TxtInmueble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbColor.Focus();
            }
        }

        private void TxtInmueble_Leave(object sender, EventArgs e)
        {
            TxtInmueble.BackColor = Color.Gainsboro;
        }

        private void CmbColor_Enter(object sender, EventArgs e)
        {
            CmbColor.BackColor = Color.White;
        }

        private void CmbColor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtValorContrato.Focus();
            }
        }

        private void CmbColor_Leave(object sender, EventArgs e)
        {
            CmbColor.BackColor = Color.Gainsboro;
        }

        private void CmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdValidarTarifas(TxtTipo.Text, CmbColor.Text.ToUpper(), TxtTemporada.Text);
            MtdDiferencia();
          
        }

        private void TxtValorContrato_Enter(object sender, EventArgs e)
        {
            TxtValorContrato.BackColor = Color.White;
        }

        private void TxtValorContrato_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {
                TxtGastoLegal.Focus();                
            }

            else
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                bool IsDec = false;

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }          
        }

        private void TxtValorContrato_Leave(object sender, EventArgs e)
        {
            TxtValorContrato.BackColor = Color.Gainsboro;
            if (TxtValorContrato.Text == "")
            {
                CmbFormaPago.Text = "0";
            }
            this.TxtValorContrato.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtValorContrato.Text));
            MtdDiferencia();
        }

        private void CmbFormaPago_Enter(object sender, EventArgs e)
        {
            CmbFormaPago.BackColor = Color.White;
        }

        private void CmbFormaPago_Leave(object sender, EventArgs e)
        {
            CmbFormaPago.BackColor = Color.Gainsboro;
        }

        private void CmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdLimpiarCambio();
            TxtValorContado.Text = "0";
            TxtValorExtraVariado.Text = "0";
            BtnOk.Enabled = false;
            DgvCuotas.Rows.Clear();
            switch (CmbFormaPago.Text)
            {
                case "Contado":

                    MtdContado();
                    break;
                case "Credicontado":
                    MtdCredicontado();
                    break;

                case "Extraordinario":
                    MtdExtraordinario();
                    break;

                case "Credito":
                    MtdCredito();
                    break;


                case "Extraordinario Variado":
                    MtdExtraordinarioVariado();
                    break;



                default:

                    break;
            }


        }

        private void CmbFormaPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DgvCtaInicial.Focus();
            }
        }

        private void TxtGastoLegal_Enter(object sender, EventArgs e)
        {
            TxtGastoLegal.BackColor = Color.White;
        }

        private void TxtGastoLegal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbFormaPago.Focus();
            }
            else
            {
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }

                bool IsDec = false;

                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
        }

        private void TxtGastoLegal_Leave(object sender, EventArgs e)
        {
            TxtGastoLegal.BackColor = Color.Gainsboro;
            if (TxtGastoLegal.Text == "")
            {
                TxtGastoLegal.Text = "0";
            }
            this.TxtGastoLegal.Text = String.Format("{0:#,##0.00;-$#,##0.00;0.00}", decimal.Parse(this.TxtGastoLegal.Text));
        }

        private void TxtObservacion_Enter(object sender, EventArgs e)
        {
            TxtObservacion.BackColor = Color.White;
            
        }

        private void TxtObservacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                CmbColor.Focus();
            }
        }

        private void TxtObservacion_Leave(object sender, EventArgs e)
        {
            TxtObservacion.BackColor = Color.Gainsboro;
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

        private void TxtValorFnc_Enter(object sender, EventArgs e)
        {
            TxtValorFnc.BackColor = Color.White;
        }

        private void TxtValorFnc_Leave(object sender, EventArgs e)
        {
            if (TxtValorFnc.Text == "")
            {
                TxtValorFnc.Text = "0";
                TxtCuotaFnc.Text = "0";
            }
            else
                if (Convert.ToDecimal(TxtValorFnc.Text) == 0)
                {
                    TxtCuotaFnc.Text = "0";
                }
                else
                {
                    if (Convert.ToDecimal(TxtPlazoFnc.Text) == 0)
                    {
                        TxtCuotaFnc.Text = "0";
                    }
                    else
                    {
                        MtdCalculoCuotaFnc();
                    }


                }
            this.TxtValorFnc.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorFnc.Text));
            MtdDiferencia();
            TxtValorFnc.BackColor = Color.Gainsboro;
        }

        private void TxtValorFnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtPlazoFnc.Focus();
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtValorFnc.Text.Length; i++)
            {
                if (TxtValorFnc.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void CmbPeriodoFnc_Enter(object sender, EventArgs e)
        {
            CmbPeriodoFnc.BackColor = Color.White;
        }

        private void CmbPeriodoFnc_Leave(object sender, EventArgs e)
        {
            MtdDiferencia();
            if (Convert.ToDouble(TxtPlazoFnc.Text) > 0)
            {
                MtdCalculoCuotaFnc();
            }
            else
            {
                TxtCuotaFnc.Text = "0";
            }
            CmbPeriodoFnc.BackColor = Color.Gainsboro;
        }

        private void CmbPeriodoFnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DtpInicioFnc.Focus();
            }
        }

        private void CmbPeriodoFnc_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdDiferencia();
            if (Convert.ToDouble(TxtPlazoFnc.Text) > 0)
            {
                MtdCalculoCuotaFnc();
            }
            else
            {
                TxtCuotaFnc.Text = "0";
            }
        }

        private void TxtPlazoFnc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
              CmbPeriodoFnc.Focus();
            }
            else
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void TxtPlazoFnc_Enter(object sender, EventArgs e)
        {
            TxtPlazoFnc.BackColor = Color.White;
        }

        private void TxtPlazoFnc_Leave(object sender, EventArgs e)
        {
            
            if (TxtPlazoFnc.Text == "")
            {
                TxtPlazoFnc.Text = "0";
            }

            if (Convert.ToDouble(TxtPlazoFnc.Text) > 0)
            {
                               MtdDiferencia();
                MtdCalculoCuotaFnc();
               
            }
            TxtPlazoFnc.BackColor = Color.Gainsboro;
        }

        private void TxtValorExtra_Enter(object sender, EventArgs e)
        {
            TxtValorExtra.BackColor = Color.White;
        }

        private void TxtValorExtra_Leave(object sender, EventArgs e)
        {
            if (TxtValorExtra.Text == "")
            {
                TxtValorExtra.Text = "0";
                TxtCuotaExtra.Text = "0";
            }

            else
                if (Convert.ToDouble(TxtValorExtra.Text) == 0)
                {
                    TxtCuotaExtra.Text = "0";
                }
                else
                {
                    if (Convert.ToDouble(TxtPlazoExtra.Text) == 0)
                    {
                        TxtCuotaExtra.Text = "0";
                    }
                    else
                    {
                        MtdCalculoCuotaExtra();
                    }
                }
            MtdDiferencia();
            this.TxtValorExtra.Text = String.Format("{0:#,##0.00; -#,##0.00;0.00}", decimal.Parse(this.TxtValorExtra.Text));
            TxtValorExtra.BackColor = Color.Gainsboro;
        }

        private void CmbPeriodoExtra_Leave(object sender, EventArgs e)
        {
            MtdDiferencia();
            if (Convert.ToDouble(TxtPlazoExtra.Text) > 0)
            {
                MtdCalculoCuotaExtra();
            }
            else
            {
                TxtCuotaExtra.Text = "0";
            }
            CmbPeriodoExtra.BackColor = Color.Gainsboro;
        }

        private void CmbPeriodoExtra_Enter(object sender, EventArgs e)
        {
            CmbPeriodoExtra.BackColor = Color.White;
        }

        private void CmbPeriodoExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                DtpInicioExtra.Focus();
            }
        }

        private void CmbPeriodoExtra_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdDiferencia();
            if (Convert.ToDouble(TxtPlazoExtra.Text) > 0)
            {
                MtdCalculoCuotaExtra();
            }
            else
            {
                TxtCuotaExtra.Text = "0";
            }
        }

        private void TxtPlazoExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
               CmbPeriodoExtra.Focus();
            }
            else
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void TxtPlazoExtra_Enter(object sender, EventArgs e)
        {
            TxtPlazoExtra.BackColor = Color.White;
        }

        private void TxtPlazoExtra_Leave(object sender, EventArgs e)
        {
            if (TxtPlazoExtra.Text == "")
            {
                TxtPlazoExtra.Text = "0";
            }
            MtdDiferencia();
            if (Convert.ToDouble(TxtPlazoExtra.Text) > 0)
            {
                MtdCalculoCuotaExtra();
            }
            else
            {
                TxtCuotaExtra.Text = "0";
            }
            TxtPlazoExtra.BackColor = Color.Gainsboro;
        }

        private void TxtValorExtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtPlazoExtra.Focus();
            }

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < TxtValorExtra.Text.Length; i++)
            {
                if (TxtValorExtra.Text[i] == '.')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
                {
                    e.Handled = true;
                    return;
                }


            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void DgvCtaInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (DgvCtaInicial.CurrentCell.ColumnIndex == 3)
            {
                bool IsDec = false;
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
            else
            {

                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
        }

        private void DgvCtaInicial_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvCtaInicial.CurrentCell.ColumnIndex == 0)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                }

            }
            else if (DgvCtaInicial.CurrentCell.ColumnIndex == 1)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                }

            }
            else if (DgvCtaInicial.CurrentCell.ColumnIndex == 2)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                }

            }

            else if (DgvCtaInicial.CurrentCell.ColumnIndex == 3)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCtaInicial_KeyPress);
                }

            }

        }

        private void DgvCtaInicial_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvCtaInicial.CurrentCell.ColumnIndex == 3)
            {
                SumValorInicial = 0;
                for (int i = 0; i < (DgvCtaInicial.Rows.Count); i++)
                {
                    if ((Convert.ToString(DgvCtaInicial.Rows[i].Cells[3].Value)) == "")
                    {
                        DgvCtaInicial.Rows[i].Cells[3].Value = 0;
                    }
                    else
                    {
                        SumValorInicial += Convert.ToDouble(Convert.ToString(DgvCtaInicial.Rows[i].Cells[3].Value));
                        TxtValorIni.Text = Convert.ToString(SumValorInicial);
                        this.TxtValorIni.Text = String.Format("{0:#,##0.00; -#,##0.00;0.00}", decimal.Parse(this.TxtValorIni.Text));

                    }
                }
            }
        }

        private void DgvCtaInicial_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SumValorInicial = 0;
            for (int i = 0; i < (DgvCtaInicial.Rows.Count); i++)
            {
                if ((Convert.ToString(DgvCtaInicial.Rows[i].Cells[3].Value)) == "")
                {
                    DgvCtaInicial.Rows[i].Cells[3].Value = 0;
                }
                else
                {
                    SumValorInicial += Convert.ToDouble(Convert.ToString(DgvCtaInicial.Rows[i].Cells[3].Value));
                    TxtValorIni.Text = Convert.ToString(SumValorInicial);

                }
            }
        }

        private void DgvContado_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (DgvContado.CurrentCell.ColumnIndex == 3)
            {

                bool IsDec = false;
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
            else
            {

                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
        }

        private void DgvContado_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvContado.CurrentCell.ColumnIndex == 0)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvContado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvContado_KeyPress);
                }

            }
            else if (DgvContado.CurrentCell.ColumnIndex == 1)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvContado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvContado_KeyPress);
                }

            }
            else if (DgvContado.CurrentCell.ColumnIndex == 2)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvContado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvContado_KeyPress);
                }

            }

            else if (DgvContado.CurrentCell.ColumnIndex == 3)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvContado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvContado_KeyPress);
                }

            }
        }

        private void DgvContado_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvContado.CurrentCell.ColumnIndex == 3)
            {
                SumValorContado = 0;
                for (int i = 0; i < (DgvContado.Rows.Count); i++)
                {
                    if ((Convert.ToString(DgvContado.Rows[i].Cells[3].Value)) == "")
                    {
                        DgvContado.Rows[i].Cells[3].Value = 0;
                    }
                    else
                    {
                        SumValorContado += Convert.ToDouble(Convert.ToString(DgvContado.Rows[i].Cells[3].Value));
                        TxtValorContado.Text = Convert.ToString(SumValorContado);
                        this.TxtValorContado.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.TxtValorContado.Text));

                    }
                }
            }
        }

        private void DgvContado_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SumValorContado = 0;
            for (int i = 0; i < (DgvContado.Rows.Count); i++)
            {
                if ((Convert.ToString(DgvContado.Rows[i].Cells[3].Value)) == "")
                {
                    DgvContado.Rows[i].Cells[3].Value = 0;
                }
                else
                {
                    SumValorContado += Convert.ToDouble(Convert.ToString(DgvContado.Rows[i].Cells[3].Value));
                    TxtValorContado.Text = Convert.ToString(SumValorContado);
                }
            }
        }

        private void DgvCuotaExtraVariado_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (DgvCuotaExtraVariado.CurrentCell.ColumnIndex == 3)
            {

                bool IsDec = false;
                if (e.KeyChar == 8)
                {
                    e.Handled = false;
                    return;
                }
                if (e.KeyChar >= 48 && e.KeyChar <= 57)
                    e.Handled = false;
                else if (e.KeyChar == 46)
                    e.Handled = (IsDec) ? true : false;
                else
                    e.Handled = true;
            }
            else
            {

                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
        }

        private void DgvCuotaExtraVariado_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (DgvCuotaExtraVariado.CurrentCell.ColumnIndex == 0)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCuotaExtraVariado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCuotaExtraVariado_KeyPress);
                }

            }
            else if (DgvCuotaExtraVariado.CurrentCell.ColumnIndex == 1)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCuotaExtraVariado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCuotaExtraVariado_KeyPress);
                }

            }
            else if (DgvCuotaExtraVariado.CurrentCell.ColumnIndex == 2)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCuotaExtraVariado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCuotaExtraVariado_KeyPress);
                }

            }

            else if (DgvCuotaExtraVariado.CurrentCell.ColumnIndex == 3)
            {
                System.Windows.Forms.TextBox txt = e.Control as System.Windows.Forms.TextBox;

                if (txt != null)
                {
                    txt.KeyPress -= new KeyPressEventHandler(DgvCuotaExtraVariado_KeyPress);
                    txt.KeyPress += new KeyPressEventHandler(DgvCuotaExtraVariado_KeyPress);
                }

            }
        }

        private void DgvCuotaExtraVariado_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvCuotaExtraVariado.CurrentCell.ColumnIndex == 3)
            {
                SumValorExtraVariado = 0;
                for (int i = 0; i < (DgvCuotaExtraVariado.Rows.Count); i++)
                {
                    if ((Convert.ToString(DgvCuotaExtraVariado.Rows[i].Cells[3].Value)) == "")
                    {
                        DgvCuotaExtraVariado.Rows[i].Cells[3].Value = 0;
                    }
                    else
                    {
                        SumValorExtraVariado += Convert.ToDouble(Convert.ToString(DgvCuotaExtraVariado.Rows[i].Cells[3].Value));
                        TxtValorExtraVariado.Text = Convert.ToString(SumValorExtraVariado);

                    }
                }
            }
        }

        private void DgvCuotaExtraVariado_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            SumValorExtraVariado = 0;
            for (int i = 0; i < (DgvCuotaExtraVariado.Rows.Count); i++)
            {
                if ((Convert.ToString(DgvCuotaExtraVariado.Rows[i].Cells[3].Value)) == "")
                {
                    DgvCuotaExtraVariado.Rows[i].Cells[3].Value = 0;
                }
                else
                {
                    SumValorExtraVariado += Convert.ToDouble(Convert.ToString(DgvCuotaExtraVariado.Rows[i].Cells[3].Value));
                    TxtValorExtraVariado.Text = Convert.ToString(SumValorExtraVariado);
                }
            }
        }

        private void TxtValorIni_TextChanged(object sender, EventArgs e)
        {
            MtdDiferencia();
        }

        private void TxtValorExtraVariado_TextChanged(object sender, EventArgs e)
        {
            MtdDiferencia();
        }

        private void TxtValorContado_TextChanged(object sender, EventArgs e)
        {
            MtdDiferencia();
        }

        private void BtnValidar_Click(object sender, EventArgs e)
        {
            MtdValidarAdd();

            if (CuentaErrores > 0)
            {
                FrmMensajeError frmMensajeError = new FrmMensajeError();
                frmMensajeError.LblErrores.DataSource = DatosdeErrores;
                frmMensajeError.ShowDialog();
            }
            else
            {
                switch (CmbFormaPago.Text)
                {
                    case "Contado":

                        MtdoDatosContado();
                        break;
                    case "Credicontado":
                        MtdoDatosCredito();
                        break;

                    case "Extraordinario":
                        MtdoDatosExtraordinario();
                        break;

                    case "Credito":
                        MtdoDatosCredito();
                        break;


                    case "Extraordinario Variado":
                        MtdoDatoExtraVariado();
                        break;



                    default:

                        break;
                }
                if (ValidacionCapital != Convert.ToDecimal( TxtValorContrato.Text))
                {
                    MessageBox.Show("Revisar Capitales ", "Validar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    BtnOk.Enabled = true;
                }
            }

          DgvCuotas.Sort(Fecha, System.ComponentModel.ListSortDirection.Ascending);
        }

        private void BtnEscape_Click(object sender, EventArgs e)
        {
            Close();
        }
       
        private void BtnExportar_Click(object sender, EventArgs e)
        {
            if (DgvCuotas.Rows.Count > 1)
            {
                exporta_a_excel();
            }

            else
            {
                MessageBox.Show("No hay infomracion para exportar", "Exportar a Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnInforme_Click(object sender, EventArgs e)
        {
            FrmImpRptAdjudicaciones rptadjudica = new FrmImpRptAdjudicaciones();
            rptadjudica.VarIdAdjudicacion=LblAdjudicacion.Text;
            rptadjudica.VarIdTercero=TxtTitular1.Text;
            rptadjudica.VarEntrada = "Automatica";
            rptadjudica.Show();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (EntradaAdjudicacion == "Adicionar")
            {
                MtdAdicionar();
            }
            else

                if (EntradaAdjudicacion == "Modificar")
                {
                    MtdModificar();
                }
                else
                    if (EntradaAdjudicacion == "Eliminar")
                    {
                        MtdEliminar();
                    }
                    else
                        if (EntradaAdjudicacion == "Desistir")
                        {
                            MtdDesistir();
                        }
                        else
                            if (EntradaAdjudicacion == "Aprobar")
                            {
                               MtdAprobar();
                            }
        }

        #endregion

        private void FrmAdjudicacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            conexion = null;
            consultar = null;
        }

        

        

    }
}
