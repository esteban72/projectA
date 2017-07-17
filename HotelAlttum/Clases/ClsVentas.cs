using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace CarteraGeneral
{
    class ClsVentas
    {
        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
        MySqlConnection ConexionClas = new MySqlConnection(FrmLogeo.StrConexion);



//---------------------------------------------------------------------------------------------------------------------------------------------------
// I N I C I O   V A R I A B L E S   Y  P R O P I E D A D E S    A D J U D I C A C I O N
//---------------------------------------------------------------------------------------------------------------------------------------------------
#region Variables Adjudicacion

        public DataTable DtComisiones;
        private string FechaExtra;
        private string FechaCon;
        private int CuotaNumCon;
        private int CuotaNumExt;
        private DataTable DatosContado;
        private DataTable DatosExtraVariado;
        private DateTime Fecha;
        private string IdAdjudicacion;
        private string IdReserva;
        private int Letra;
        private double Pago1;
        private string Contrato;
        private string IdProyecto;
        private string IdInmueble;
        private string IdTercero1;
        private string IdTercero2;
        private string IdTercero3;
        private string FormaPago;
        private double Valor;
        private double GastosLegales;
        private double VrContado;
        private double CuotaInicial;
        private double Financiacion;
        private int PlazoFnc;
        private double TasaFnc;
        private double CuotaFncAdj;
        private DateTime InicioFnc;
        private DateTime FechaEntrega;
        private string StrFechaEntrega;
        private double Extraordinaria;
        private int PlazoExtra;
        private double TasaExtra;
        private double CuotaExtra;
        private double CuotaExtraVariada;
        private DateTime InicioExtra;
        private string Usuario;
        private string Estado;
        private DateTime FechaOperacion;
        private decimal Pocentaje;
        private string StrInicioExtra;
        private string AddIdreserva;
        private string Titulo;
        private double Factor;
        private string ModIdReserva;
        private string IdInmuebleAnt;
        private string InmReserva;
        private string AccionOtrosi;
        private DataTable DtGastosAdmin;



        public double gastosLegales
        {
            get { return GastosLegales; }
            set { GastosLegales = value; }
        }


        public DataTable dtGastosAdmin
        {
            get { return DtGastosAdmin; }
            set { DtGastosAdmin = value; }
        }

        public DataTable dtComisiones
        {
            get { return DtComisiones; }
            set { DtComisiones = value; }
        }

        public string modIdReserva
        {
            get { return ModIdReserva; }
            set { ModIdReserva = value; }
        }
        public string inmReserva
        {
            get { return "'"+ InmReserva+"'"; }
            set { InmReserva = value; }

            


        }
        public string idInmuebleAnt
        {
            get { return IdInmuebleAnt; }
            set { IdInmuebleAnt = value; }
        }

        public double factor
        {
            get { return Factor; }
            set { Factor = value; }
        }

        public DateTime fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }

        public string id
        {
            get
            {
                Id = Convert.ToString(MtdCscAdj());
                return Id;
            }
            set { Id = value; }
        }

        public string idAdjudicacion
        {
            get   {return IdAdjudicacion ; }
            set { IdAdjudicacion = value; }
        }

        public string idReserva
        {
            get
            {
                IdReserva = MtdCscReserva();
                return "Rsv" + IdReserva;
            }
            set { IdReserva = value; }
        }

        public string idAdjudicacionMod
        {
            get
            {

                return "'" + IdAdjudicacionMod + "'";
            }
            set { IdAdjudicacionMod = value; }
        }

        public string contrato
        {
            get { return "'" + Contrato + "'"; }
            set { Contrato = value; }
        }

        public string idProyecto
        {
            get { return "'" + IdProyecto + "'"; }
            set { IdProyecto = value; }
        }

        public string idInmueble
        {
            get { return "'" + IdInmueble + "'"; }
            set { IdInmueble = value; }
        }

        public string idTercero1
        {
            get { return "'" + IdTercero1 + "'"; }
            set { IdTercero1 = value; }
        }

        public string idTercero2
        {
            get
            {
                if (IdTercero2 == "")
                {
                    return "null";
                }
                else
                {
                    return "'" + IdTercero2 + "'";
                }
            }
            set { IdTercero2 = value; }
        }


        public string idTercero3
        {
            get
            {
                if (IdTercero3 == "")
                {
                    return "null";
                }
                else
                {
                    return "'" + IdTercero3 + "'";
                }
            }
            set { IdTercero3 = value; }
        }
        public string formaPago
        {
            get { return "'" + FormaPago + "'"; }
            set { FormaPago = value; }
        }

        public double valor
        {
            get { return Valor; }
            set { Valor = value; }
        }

        public double vrContado
        {
            get { return VrContado; }
            set { VrContado = value; }
        }
        public double pago1
        {
            get { return Pago1; }
            set { Pago1 = value; }
        }
        public int letra
        {
            get { return Letra; }
            set { Letra = value; }
        }
        public string titulo
        {
            get { return Titulo; }
            set { Titulo = value; }
        }
        public double cuotaInicial
        {
            get { return CuotaInicial; }
            set { CuotaInicial = value; }
        }

        public double financiacion
        {
            get { return Financiacion; }
            set { Financiacion = value; }
        }

        public decimal pocentaje
        {
            get { return Pocentaje; }
            set { Pocentaje = value; }
        }

        public string usuario
        {
            get { return "'" + Usuario + "'"; }
            set { Usuario = value; }
        }

        public DateTime fechaOperacion
        {
            get { return FechaOperacion; }
            set { FechaOperacion = value; }
        }

        public string estado
        {
            get { return "'" + Estado + "'"; }
            set { Estado = value; }

        }

        public string strFecha
        {
            get
            {
                StrFecha = MtdConvertFechaStr(Fecha);
                return StrFecha;
            }
            set { StrFecha = value; }
        }

        public string strInicioFnc
        {
            get
            {
                StrInicioFnc = MtdConvertFechaStr(InicioFnc);
                return StrInicioFnc;
            }

            set { StrInicioFnc = value; }
        }

        public string strInicioExtra
        {
            get
            {
                StrInicioExtra = MtdConvertFechaStr(inicioExtra);
                return StrInicioExtra;
            }
            set
            {
                StrInicioExtra = value;
            }
        }

        public string strFechaOperacion
        {
            get
            {
                StrFechaOperacion = MtdConvertFechaStr(FechaOperacion);
                return StrFechaOperacion;
            }

            set { StrFechaOperacion = value; }
        }

        private string Periodo;

        private double InPeriodoExtra;

        public string periodo
        {
            get { return Periodo; }
            set { Periodo = value; }
        }
        public string addIdreserva
        {
            get { return AddIdreserva; }
            set { AddIdreserva = value; }
        }
        public double inPeriodoExtra
        {
            get
            {
                InPeriodoExtra = 30 / InPeriodoExtra * 12;
                return InPeriodoExtra;

            }
            set { InPeriodoExtra = value; }
        }

        private double InPeriodoFnc;

        public double inPeriodoFnc
        {
            get
            {
                
                return InPeriodoFnc;

            }
            set { InPeriodoFnc = value; }
        }

        public int plazoFnc
        {
            get { return PlazoFnc; }
            set { PlazoFnc = value; }
        }

        public double tasaFnc
        {
            get { return TasaFnc; }
            set { TasaFnc = value; }
        }

        public double cuotaFncAdj
        {
            get { return CuotaFncAdj; }
            set { CuotaFncAdj = value; }
        }

        public DateTime inicioFnc
        {
            get { return InicioFnc; }
            set { InicioFnc = value; }
        }

        public double extraordinaria
        {
            get { return Extraordinaria; }
            set { Extraordinaria = value; }
        }

        public int plazoExtra
        {
            get { return PlazoExtra; }
            set { PlazoExtra = value; }
        }

        public double tasaExtra
        {
            get { return TasaExtra; }
            set { TasaExtra = value; }
        }

        public double cuotaExtra
        {
            get { return CuotaExtra; }
            set { CuotaExtra = value; }
        }

        public double cuotaExtraVariada
        {
            get { return CuotaExtraVariada; }
            set { CuotaExtraVariada = value; }
        }

        public DateTime inicioExtra
        {
            get
            {
                return InicioExtra;
            }

            set
            {
                InicioExtra = value;
            }

        }
        public DateTime fechaEntrega
        {
            get
            {
                return FechaEntrega;
            }

            set
            {
                FechaEntrega = value;
            }

        }

        public string strFechaEntrega
        {
            get
            {
                StrFechaEntrega = MtdConvertFechaStr(FechaEntrega);
                return StrFechaEntrega;
            }

            set { StrFechaEntrega = value; }
        }

        public DataTable datosContado
        {

            get { return DatosContado; }
            set { DatosContado = value; }
        }
        public DataTable datosExtraVariado
        {

            get { return DatosExtraVariado; }
            set { DatosExtraVariado = value; }
        }
        public string accionOtrosi
        {
            get { return  AccionOtrosi ; }
            set { AccionOtrosi = value; }
        }
      

        #endregion
//---------------------------------------------------------------------------------------------------------------------------------------------------
// F I N A L   V A R I A B L E S     Y  P R O P I E D A D E S    A D J U D I C A C I O N
//---------------------------------------------------------------------------------------------------------------------------------------------------



//---------------------------------------------------------------------------------------------------------------------------------------------------
// I N I C I O  V A R I A B L E S     Y  P R O P I E D A D E S    O T R O S I
//---------------------------------------------------------------------------------------------------------------------------------------------------
        #region otrosi


        private double ValorOtrosi;
        private double NuevaCuotaInicial;
        private double CuotaInicialOtrosi;
        private double NuevaFinanciacion;
        private double FinanciacionOtrosi;
        private double ExtraordinariaOtrosi;
        private double NuevaExtraordinaria;
       

        private int PlazoFncOtrosi;
        private double TasaFncOtrosi;
        private double CuotaFncAdjOtrosi;
        private DateTime InicioFncOtrosi;

        private int PlazoExtraOtrosi;
        private double TasaExtraOtrosi;
        private double CuotaExtraOtrosi;
        private DateTime InicioExtraOtrosi;

        private int UltimaCuotaFnc;
        private int UltimaCuotaExtra;
        private int UltimaCuotaInicial;

        private int NumCuotaAbnCapital;

        private int IdOtrosi;

        private int OtrosiInicial;
        private int OtrosiFnc;
        private int OtrosiExtra;

        private double AbonoCapital;
        private double RecaudoTotal;
        private double NuevoCapital;

        private double SdoIntCteFnc;
        private double SdoCptFnc;
        private double SdoCuotaFnc;

        private double SdoIntCteIni;
        private double SdoCptIni;
        private double SdoCuotaIni;

        private double SdoIntCteExtra;
        private double SdoCptExtra;
        private double SdoCuotaExtra;

        private string FechaPagoExtra;

        public string fechaPagoExtra
        {
            get { return FechaPagoExtra; }
            set { FechaPagoExtra = value; }
        }

        public double valorOtrosi
        {
            get { return ValorOtrosi; }
            set { ValorOtrosi = value; }
        }

        public double cuotaInicialOtrosi
        {
            get { return CuotaInicialOtrosi; }
            set { CuotaInicialOtrosi = value; }
        }

        public double financiacionOtrosi
        {
            get { return FinanciacionOtrosi; }
            set { FinanciacionOtrosi = value; }
        }

        public double nuevaCuotaInicial
        {
            get { return NuevaCuotaInicial; }
            set { NuevaCuotaInicial = value; }
        }
        public double nuevaFinanciacion
        {
            get { return NuevaFinanciacion; }
            set { NuevaFinanciacion = value; }
        }

        public double extraordinariaOtrosi
        {
            get { return ExtraordinariaOtrosi; }
            set { ExtraordinariaOtrosi = value; }
        }


        public double nuevaExtraordinaria
        {
            get { return NuevaExtraordinaria; }
            set { NuevaExtraordinaria = value; }
        }

        public int plazoFncOtrosi
        {
            get { return PlazoFncOtrosi; }
            set { PlazoFncOtrosi = value; }
        }

        public double tasaFncOtrosi
        {
            get { return TasaFncOtrosi; }
            set { TasaFncOtrosi = value; }
        }

        public double cuotaFncAdjOtrosi
        {
            get { return CuotaFncAdjOtrosi; }
            set { CuotaFncAdjOtrosi = value; }
        }

        public DateTime inicioFncOtrosi
        {
            get { return InicioFncOtrosi; }
            set { InicioFncOtrosi = value; }
        }

        public int plazoExtraOtrosi
        {
            get { return PlazoExtraOtrosi; }
            set { PlazoExtraOtrosi = value; }
        }

        public double tasaExtraOtrosi
        {
            get { return TasaExtraOtrosi; }
            set { TasaExtraOtrosi = value; }
        }

        public double cuotaExtraOtrosi
        {
            get { return CuotaExtraOtrosi; }
            set { CuotaExtraOtrosi = value; }
        }

        public DateTime inicioExtraOtrosi
        {
            get
            {
                return InicioExtraOtrosi;
            }

            set
            {
                InicioExtraOtrosi = value;
            }

        }

        public int ultimaCuotaFnc
        {
            get { return UltimaCuotaFnc; }
            set { UltimaCuotaFnc = value; }
        }

        public int ultimaCuotaExtra
        {
            get { return UltimaCuotaExtra; }
            set { UltimaCuotaExtra = value; }
        }

        public int ultimaCuotaInicial
        {
            get { return UltimaCuotaInicial; }
            set { UltimaCuotaInicial = value; }
        }

        public int numCuotaAbnCapital
        {
            get
            {

                return NumCuotaAbnCapital;

            }
            set { NumCuotaAbnCapital = value; }
        }

        public int idOtrosi
        {
            get { return IdOtrosi; }
            set { IdOtrosi = value; }
        }

        public int otrosiInicial
        {
            get { return OtrosiInicial; }
            set { OtrosiInicial = value; }
        }

        public int otrosiFnc
        {
            get { return OtrosiFnc; }
            set { OtrosiFnc = value; }
        }

        public int otrosiExtra
        {
            get { return OtrosiExtra; }
            set { OtrosiExtra = value; }
        }

        public double abonoCapital
        {
            get { return AbonoCapital; }
            set { AbonoCapital = value; }
        }

        public double recaudoTotal
        {
            get { return RecaudoTotal; }
            set { RecaudoTotal = value; }
        }

        public double nuevoCapital
        {
            get { return NuevoCapital; }
            set { NuevoCapital = value; }
        }

        public double sdoIntCteFnc
        {
            get { return SdoIntCteFnc; }
            set { SdoIntCteFnc = value; }
        }

        public double sdoCptFnc
        {
            get { return SdoCptFnc; }
            set { SdoCptFnc = value; }
        }

        public double sdoCuotaFnc
        {
            get { return SdoCuotaFnc; }
            set { SdoCuotaFnc = value; }
        }


        public double sdoIntCteIni
        {
            get { return SdoIntCteIni; }
            set { SdoIntCteIni = value; }
        }

        public double sdoCptIni
        {
            get { return SdoCptIni; }
            set { SdoCptIni = value; }
        }

        public double sdoCuotaIni
        {
            get { return SdoCuotaIni; }
            set { SdoCuotaIni = value; }
        }



        public double sdoIntCteExtra
        {
            get { return SdoIntCteExtra; }
            set { SdoIntCteExtra = value; }
        }

        public double sdoCptExtra
        {
            get { return SdoCptExtra; }
            set { SdoCptExtra = value; }
        }

        public double sdoCuotaExtra
        {
            get { return SdoCuotaExtra; }
            set { SdoCuotaExtra = value; }
        }



        #endregion
//---------------------------------------------------------------------------------------------------------------------------------------------------
// F I N A L   V A R I A B L E S     Y  P R O P I E D A D E S     O T R O S I
//---------------------------------------------------------------------------------------------------------------------------------------------------


//---------------------------------------------------------------------------------------------------------------------------------------------------
//I N I C I AL   V A R I A B L E S  Y  P R O P I E D A D E S   D E  C U O T A   I N I C I A L
//---------------------------------------------------------------------------------------------------------------------------------------------------
        #region Variables CuotaInicial

        private int CuotaNumIni;
        private string FechaIni;
        private double ValorIni;
        private DataTable DatosCuotaInicial;

        private string VarDia;
        private string VarMes;
        private string VarAno;
        private double VarValor = 0;

        private string IdAdjudicacionMod;
        private string ModIn;
        private string Id;


        string StrFecha;
        string StrInicioFnc;
        string StrFechaOperacion;



        public int cuotaNumIni
        {
            get { return CuotaNumIni; }
            set { CuotaNumIni = value; }
        }
        public string fechaIni
        {
            get
            {
                return "'" + FechaIni + "'";
            }
            set { FechaIni = value; }
        }
        public double valorini
        {
            get { return ValorIni; }
            set { ValorIni = value; }
        }
        public DataTable datosCuotaInicial
        {

            get { return DatosCuotaInicial; }
            set { DatosCuotaInicial = value; }
        }
        #endregion
//---------------------------------------------------------------------------------------------------------------------------------------------------
// F I N A L   V A R I A B L E S  Y P R O P I E D A D E S   D E   C U O T A   I N I C I A L
//---------------------------------------------------------------------------------------------------------------------------------------------------


//---------------------------------------------------------------------------------------------------------------------------------------------------
//I N I C I O  P R O P I E D A D E S    C A M B I O  D E  C O N S E C  U T I V O S
//---------------------------------------------------------------------------------------------------------------------------------------------------
        #region Cambio de Consecutivos

        private string NvoCscAdj;
        private string NvoCscFnc;
        private string NvoCscIni;
        private string NvoCscExtra;
        private string NvoCscCon;
        private string NvoCscReserva;
        public string nvoCscAdj
        {
            get
            {
                NvoCscAdj = Convert.ToString(Convert.ToInt16(MtdCscAdj()) + 1);
                return NvoCscAdj;
            }
            set { NvoCscAdj = value; }
        }
        public string nvoCscFnc
        {
            get
            {
                NvoCscFnc = Convert.ToString(Convert.ToInt16(MtdCscFnc()) + 1);
                return NvoCscFnc;
            }
            set { NvoCscFnc = value; }
        }
        public string nvoCscIni
        {
            get
            {
                NvoCscIni = Convert.ToString(Convert.ToInt16(MtdCscInicial()) + 1);
                return NvoCscIni;
            }
            set { NvoCscIni = value; }
        }
        public string nvoCscExtra
        {
            get
            {
                NvoCscExtra = Convert.ToString(Convert.ToInt16(MtdCscExtra()) + 1);
                return NvoCscExtra;
            }
            set { NvoCscExtra = value; }
        }
        public string nvoCscCon
        {
            get
            {
                NvoCscCon = Convert.ToString(Convert.ToInt16(MtdCscCont()) + 1);
                return NvoCscCon;
            }
            set { NvoCscCon = value; }



        }

        public string nvoCscReserva
        {
            get
            {
                NvoCscReserva = Convert.ToString(Convert.ToInt16(MtdCscReserva()) + 1);
                return NvoCscReserva;
            }
            set { NvoCscReserva = value; }



        }


        #endregion
//---------------------------------------------------------------------------------------------------------------------------------------------------
//F I N A L  P R O P I E D A D E S   C A M B I O   D E   C O N S E C  U T I V O S
//---------------------------------------------------------------------------------------------------------------------------------------------------


//---------------------------------------------------------------------------------------------------------------------------------------------------
//I N I C I O  P R O P I E D A D E S   Y   V A R I A B L E S   D E    C O M I S I O N E S
//---------------------------------------------------------------------------------------------------------------------------------------------------
        #region Propiedades Comisiones


        private string IdAsesor;
        private decimal ComIdAsesor;
        private string IdCargo;
        private string Idcomision;       
        private string OrigenVenta;
        private string TipoOrigen;
        private string CredAdmin;
         public string modIn
        {
            get { return ModIn; }
            set { ModIn = value; }
        }

        public string idcomision
        {
            get { return  Idcomision ; }
            set { Idcomision = value; }
        }


        public string idcargo
        {
            get { return  IdCargo ; }
            set { IdCargo = value; }
        }
        public string idAsesor
        {
            get { return  IdAsesor ; }
            set { IdAsesor = value; }
        }
        

        
        public decimal comIdAsesor
        {
            get { return ComIdAsesor; }
            set { ComIdAsesor = value; }
        }


       

        public string origenVenta
        {
            get { return OrigenVenta; }
            set { OrigenVenta = value; }
        }

        public string tipoOrigen
            {
                get { return TipoOrigen; }
                set { TipoOrigen = value; }
            }


        public string credAdmin
        {
            get { return CredAdmin; }
            set { CredAdmin = value; }
        }

        #endregion
//---------------------------------------------------------------------------------------------------------------------------------------------------
//F I N A L  P R O P I E D A D E S Y   V A R I A B L E S   D E    C O M I S I O N E S
//---------------------------------------------------------------------------------------------------------------------------------------------------



//---------------------------------------------------------------------------------------------------------------------------------------------------
//I N I C I O   R E G I O O N   D E   M E T O D O S
//---------------------------------------------------------------------------------------------------------------------------------------------------
#region   M E T O D O S


//===================================================================================================================================================
//I N I C I O  M E T O D  O   A D I C I O N A R  V E N T A S
//===================================================================================================================================================
        public string MtdAddVentas()
        {
            string MensajeSalida;


            string SentenciaComNormal = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, Normal,Normal,'Pendiente' From tablacomision Where Normal > 0)";
            string SentenciaComNormalMiramar = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, Normal,Normal,Normal,Normal,Normal,5,'Pendiente' From tablacomision Where Normal > 0)";

            string SentenciaComComercial = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, Comercial,Comercial, 'Pendiente' From tablacomision Where Comercial > 0)";
            string SentenciaComGerenteGral = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, GerenteGral,GerenteGral, 'Pendiente' From tablacomision Where GerenteGral > 0)";
            string SentenciaComGerenteFin = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, GerenteFin,GerenteFin, 'Pendiente' From tablacomision Where GerenteFin > 0)";
            
            string SentenciaAddAdjudicacion = " Insert into adjudicacion (Fecha ,  IdAdjudicacion ,  Contrato ,  IdProyecto ,  IdInmueble ,  IdTercero1 ,  IdTercero2 , IdTercero3, FormaPago ,  Valor ,  contado ,  CuotaInicial ,  Financiacion ,  PlazoFnc ,  TasaFnc ,"+  
            "CuotaFnc ,  InicioFnc ,  Extraordinaria,  PlazoExtra ,  TasaExtra,  CuotaExtra ,  InicioExtra ,  Usuario ,  Estado ,  FechaOperacion,  Porcentaje,  FechaEntrega ,   OrigenVenta ,  TipoOrigen ,  BaseComision )"+ 
            
           " Values (" + strFecha + ",'" + idAdjudicacion + "'," + contrato + "," + idProyecto +
                                   "," + idInmueble + "," + idTercero1 + "," + idTercero2 + "," + idTercero3 + "," + formaPago + "," + valor + "," + vrContado + "," + cuotaInicial + "," + financiacion + "," + plazoFnc + "," + tasaFnc + "," + cuotaFncAdj +
                                   "," + strInicioFnc + "," + extraordinaria + "," + plazoExtra + "," + tasaExtra + "," + (cuotaExtra + cuotaExtraVariada) + "," + strInicioExtra + "," +
                                    usuario + "," + estado + "," + strFechaOperacion + "," + Pocentaje + ","+strFechaEntrega + ",'" +origenVenta+ "','" + tipoOrigen + "' ,"+valor+")";

            

            string SentenciaAddFnc = "call AddFinanciacion('" + idAdjudicacion + "','" + idAdjudicacion + "'," + idProyecto + "," + strInicioFnc + "," +
                                   financiacion + "," + tasaFnc + "," + plazoFnc + "," + usuario + "," +inPeriodoFnc + ")";

            string SentenciaAddFncMira = "call AddFncFactor('" + idAdjudicacion + "','" + idAdjudicacion + "'," + idProyecto + "," + strInicioFnc + "," +
                                  financiacion + "," + tasaFnc + "," + plazoFnc + "," + usuario + "," + inPeriodoFnc +","+ factor +")";

            string SentenciaAddExtra = "call AddExtra('" + idAdjudicacion + "','" + idAdjudicacion + "'," + idProyecto + "," + strInicioExtra + "," + extraordinaria +
                                   "," + tasaExtra + "," + plazoExtra + "," + usuario + "," + (inPeriodoExtra) + ")";

            

            string SentenciaModEstadoInmuebles = "update inmuebles set Estado ='Adjudicado' WHERE IdInmueble = " + idInmueble;
            string SentenciaModEstadoRsv = "Update Reservas set Estado = '" + idAdjudicacion + "' where idreserva = '" + AddIdreserva + "'";
            string EstadoLibre = "update inmuebles set Estado ='Libre' WHERE IdInmueble = " + inmReserva ;
            int A = datosCuotaInicial.Rows.Count;


            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;
            

            try
            {
                myCommand.CommandText = SentenciaAddAdjudicacion;
                myCommand.ExecuteNonQuery();
            
                myCommand.CommandText = SentenciaModEstadoInmuebles;
                myCommand.ExecuteNonQuery();       

                myCommand.CommandText = SentenciaModEstadoRsv;
                myCommand.ExecuteNonQuery();

                if(idInmueble!=inmReserva)
                {
                    myCommand.CommandText = EstadoLibre;
                    myCommand.ExecuteNonQuery();
                }

                switch (formaPago)
                {
                    case "'Contado'":

                        for (int i = 0; i < datosContado.Rows.Count; i++)
                        {
                            VarDia = datosContado.Rows[i][0].ToString();
                            VarMes = datosContado.Rows[i][1].ToString();
                            VarAno = datosContado.Rows[i][2].ToString();
                            VarValor = Convert.ToDouble(datosContado.Rows[i][3].ToString());
                            FechaCon = ("'" +VarAno + "-" + VarMes + "-" + VarDia+ "'");
                            CuotaNumCon = (i + 1);

                            myCommand.CommandText = " Insert into Contado (IdCuotaInicial,IdAdjudicacion,IdProyecto,CuotaNum,Fecha,Valor,Usuario,FechaOperacion)  Values (Concat('CO','" + CuotaNumCon +"','"+ idAdjudicacion + "'),'" + idAdjudicacion + "'," + idProyecto + "," +
                                            CuotaNumCon + "," + FechaCon + "," + VarValor + "," + usuario + "," + strFechaOperacion + ")";
                            myCommand.ExecuteNonQuery();
                        }

                        break;

                    case "'Credicontado'":
                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        break;


                    case "'Extraordinario'":
                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = SentenciaAddExtra;
                        myCommand.ExecuteNonQuery();
                        break;

                    case "'Credito'":

                        if (FrmLogeo.Pais=="Panama")
                        {
                            myCommand.CommandText = SentenciaAddFncMira;
                            myCommand.ExecuteNonQuery();
                        }

                        else
                        {
                            myCommand.CommandText = SentenciaAddFnc;
                            myCommand.ExecuteNonQuery();
                        }

                        break
                            ;
                    case "'Extraordinario Variado'":

                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();

                        for (int i = 0; i < datosExtraVariado.Rows.Count; i++)
                        {
                            VarDia = datosExtraVariado.Rows[i][0].ToString();
                            VarMes = datosExtraVariado.Rows[i][1].ToString();
                            VarAno = datosExtraVariado.Rows[i][2].ToString();
                            VarValor = Convert.ToDouble(datosExtraVariado.Rows[i][3].ToString());
                            FechaExtra = ("'" + VarAno + "-" + VarMes + "-" + VarDia + "'");
                            CuotaNumExt = (i + 1);

                            myCommand.CommandText = " Insert into cuotaextra Values (Concat('CE','" + CuotaNumExt +"','" +idAdjudicacion + "'),'" + idAdjudicacion + "'," + idProyecto + "," +
                            CuotaNumExt + "," + FechaExtra + "," + VarValor + ",0," + VarValor + "," + usuario + "," + strFechaOperacion + ")";
                            myCommand.ExecuteNonQuery();
                        }
                        break;
                   
                }
                
                if (A > 0)
                {
                    for (int i = 0; i < datosCuotaInicial.Rows.Count; i++)
                    {

                        VarDia = datosCuotaInicial.Rows[i][0].ToString();
                        VarMes = datosCuotaInicial.Rows[i][1].ToString();
                        VarAno = datosCuotaInicial.Rows[i][2].ToString();
                        VarValor = Convert.ToDouble(datosCuotaInicial.Rows[i][3].ToString());
                        fechaIni = (VarAno + "-" + VarMes + "-" + VarDia);
                        cuotaNumIni = (i + 1);

                        myCommand.CommandText = " Insert into cuotainicial Values (Concat('CI','" + cuotaNumIni +"','" +idAdjudicacion + "'),'" + idAdjudicacion + "'," + idProyecto + "," +
                        cuotaNumIni + "," + fechaIni + "," + VarValor + "," + usuario + "," + strFechaOperacion + ")";
                        myCommand.ExecuteNonQuery();
                    }
                }
                myCommand.CommandText = "Update Consecutivos set Consecutivo = Consecutivo +1 Where Prefijo ='Adj'";
                myCommand.ExecuteNonQuery();

                switch (origenVenta)
                {
                    case "Normal":

                        if (FrmLogeo.Proyecto.ToUpper() == "MIRAMAR")
                        {
                            myCommand.CommandText = SentenciaComNormalMiramar;
                            myCommand.ExecuteNonQuery();

                            for (int i = 0; i < dtComisiones.Rows.Count; i++)
                            {

                                idcomision = dtComisiones.Rows[i][0].ToString() + idAdjudicacion;
                                idcargo = dtComisiones.Rows[i][0].ToString();
                                idAsesor = dtComisiones.Rows[i][1].ToString();
                                comIdAsesor = Convert.ToDecimal(dtComisiones.Rows[i][2].ToString());
                                myCommand.CommandText = " INSERT INTO comision1 VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," + comIdAsesor + "," + comIdAsesor + "," + comIdAsesor + "," + comIdAsesor + "," + comIdAsesor + ",5, 'Pendiente' )";
                                myCommand.ExecuteNonQuery();
                            }

                        }

                        else
                        {
                            myCommand.CommandText = SentenciaComNormal;
                            myCommand.ExecuteNonQuery();

                            for (int i = 0; i < dtComisiones.Rows.Count; i++)
                            {
                                idcomision = dtComisiones.Rows[i][0].ToString() + idAdjudicacion;
                                idcargo = dtComisiones.Rows[i][0].ToString();
                                idAsesor = dtComisiones.Rows[i][1].ToString();
                                comIdAsesor = Convert.ToDecimal(dtComisiones.Rows[i][2].ToString());
                                myCommand.CommandText = " INSERT INTO comision1 VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," + comIdAsesor + "," + comIdAsesor + ", 'Pendiente' )";
                                myCommand.ExecuteNonQuery();
                            }
                        }
                        break;


                    case "De Promocion":
                  
                        myCommand.CommandText = SentenciaComNormal;
                        myCommand.ExecuteNonQuery();
                        break;


                    case "Comercial":
                        myCommand.CommandText = SentenciaComComercial;
                        myCommand.ExecuteNonQuery();

                        for (int i = 0; i < dtComisiones.Rows.Count; i++)
                        {
                            idcomision = dtComisiones.Rows[i][0].ToString() + idAdjudicacion;
                            idcargo = dtComisiones.Rows[i][0].ToString();
                            idAsesor = dtComisiones.Rows[i][1].ToString();
                            comIdAsesor = Convert.ToDecimal(dtComisiones.Rows[i][2].ToString());
                            myCommand.CommandText = " INSERT INTO comision1 VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," + comIdAsesor + "," + comIdAsesor + ", 'Pendiente' )";
                            myCommand.ExecuteNonQuery();
                        }
                        break;

                    case "Administrativo":

                        if (credAdmin == "Gerente General")
                        {
                            myCommand.CommandText = SentenciaComGerenteGral;
                            myCommand.ExecuteNonQuery();
                        }
                        else

                            if (credAdmin == "Gerente Financiero")
                            {
                                myCommand.CommandText = SentenciaComGerenteFin;
                                myCommand.ExecuteNonQuery();
                            }
                        break;


                    default:

                        break;

                }


                myTrans.Commit();
                MensajeSalida = "OK";

            }

            catch (Exception e)
            {
                myTrans.Rollback();
                MensajeSalida = "Se presento el Sgte Error" + e.Message + " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L M E T O D O   A D I C I O N A R   V E N T A S
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O  M E T O D  O M O D I F I C A R   V E N T A S
//===================================================================================================================================================
        public string MtdModVentas()
        {
            string MensajeSalida;
                   
            
            string SentenciaComNormal = "INSERT INTO comision1 (SELECT Concat(IdCarg," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + strFecha + ",Titular,IdCarg, Normal,Normal,'Pendiente' From tablacomision Where Normal > 0)";
            string SentenciaComComercial = "INSERT INTO comision1 (SELECT Concat(IdCarg," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + strFecha + ",Titular,IdCarg, Comercial,Comercial, 'Pendiente' From tablacomision Where Comercial > 0)";
            string SentenciaComGerenteGral = "INSERT INTO comision1 (SELECT Concat(IdCarg," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + strFecha + ",Titular,IdCarg, GerenteGral,GerenteGral, 'Pendiente' From tablacomision Where GerenteGral > 0)";
            string SentenciaComGerenteFin = "INSERT INTO comision1 (SELECT Concat(IdCarg," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + strFecha + ",Titular,IdCarg, GerenteFin,GerenteFin, 'Pendiente' From tablacomision Where GerenteFin > 0)";

            string SentenciaComNormalMiramar = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, Normal,Normal,Normal,Normal,Normal,5,'Pendiente' From tablacomision Where Normal > 0)";


            string SentenciaModAdjudicacion = " Insert into adjudicacion (Fecha ,  IdAdjudicacion ,  Contrato ,  IdProyecto ,  IdInmueble ,  IdTercero1 ,  IdTercero2 , IdTercero3, FormaPago ,  Valor ,  contado ,  CuotaInicial ,  Financiacion ,  PlazoFnc ,  TasaFnc ," +
 "CuotaFnc ,  InicioFnc ,  Extraordinaria,  PlazoExtra ,  TasaExtra,  CuotaExtra ,  InicioExtra ,  Usuario ,  Estado ,  FechaOperacion,  Porcentaje,  FechaEntrega ,   OrigenVenta ,  TipoOrigen ,  BaseComision )" +

" Values (" + strFecha + ",'" + idAdjudicacion + "'," + contrato + "," + idProyecto +
                        "," + idInmueble + "," + idTercero1 + "," + idTercero2 + "," + idTercero3 + "," + formaPago + "," + valor + "," + vrContado + "," + cuotaInicial + "," + financiacion + "," + plazoFnc + "," + tasaFnc + "," + cuotaFncAdj +
                        "," + strInicioFnc + "," + extraordinaria + "," + plazoExtra + "," + tasaExtra + "," + (cuotaExtra + cuotaExtraVariada) + "," + strInicioExtra + "," +
                         usuario + "," + estado + "," + strFechaOperacion + "," + Pocentaje + "," + strFechaEntrega + ",'" + origenVenta + "','" + tipoOrigen + "' ," + valor + ")";

            
            
                  string SentenciaAddFnc = "call AddFinanciacion(" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + idProyecto + "," + strInicioFnc + "," +
                                   financiacion + "," + tasaFnc + "," + plazoFnc + "," + usuario + "," + (inPeriodoFnc) + ")";


            string SentenciaAddFncMira = "call AddFncFactor(" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + idProyecto + "," + strInicioFnc + "," +
                                  financiacion + "," + tasaFnc + "," + plazoFnc + "," + usuario + "," + inPeriodoFnc + "," + factor + ")";

            string SentenciaAddExtra = "call AddExtra(" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + idProyecto + "," + strInicioExtra + "," + extraordinaria +
                                   "," + tasaExtra + "," + plazoExtra + "," + usuario + "," + (inPeriodoExtra) + ")";

            string SentenciaModEstadoInmuebles = "update inmuebles set Estado ='Adjudicado' WHERE IdInmueble = " + idInmueble;
            string EstadoLibre = "update inmuebles set Estado ='Libre' WHERE IdInmueble = " + inmReserva ;
            string SentenciaDelContado = "Delete From Contado Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelFnc = "Delete From Financiacion Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelCuotaIni = "Delete From cuotainicial Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelCuotaExtra = "Delete From cuotaextra Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelComision = "Delete From comision1 Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelAdjudicacion = "Delete From Adjudicacion Where IdAdjudicacion = " + idAdjudicacionMod;

            int A = datosCuotaInicial.Rows.Count;



            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;
            try
            {

                myCommand.CommandText = SentenciaDelContado;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelFnc;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelCuotaIni;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelCuotaExtra;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelComision;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelAdjudicacion;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaModAdjudicacion;
                myCommand.ExecuteNonQuery();
           
                myCommand.CommandText = SentenciaModEstadoInmuebles;
                myCommand.ExecuteNonQuery();
                if (idInmueble != inmReserva)
                {
                    myCommand.CommandText = EstadoLibre;
                    myCommand.ExecuteNonQuery();

                }

                switch (formaPago)
                {
                    case "'Contado'":

                        for (int i = 0; i < datosContado.Rows.Count; i++)
                        {

                            VarDia = datosContado.Rows[i][0].ToString();
                            VarMes = datosContado.Rows[i][1].ToString();
                            VarAno = datosContado.Rows[i][2].ToString();
                            VarValor = Convert.ToDouble(datosContado.Rows[i][3].ToString());
                            FechaCon = ("'" + VarAno + "-" + VarMes + "-" + VarDia + "'");
                            CuotaNumCon = (i + 1);



                            myCommand.CommandText = " Insert into Contado Values (Concat('CO','" + CuotaNumCon + "'," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + idProyecto + "," +
                                            CuotaNumCon + "," + FechaCon + "," + VarValor + "," + usuario + "," + strFechaOperacion + ")";
                   
                    
                            myCommand.ExecuteNonQuery();
                        }

                        break;
                    case "'Credicontado'":
                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        break;


                    case "'Extraordinario'":
                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = SentenciaAddExtra;
                        myCommand.ExecuteNonQuery();
                        break;

                    case "'Credito'":
                        if (FrmLogeo.Pais == "Panama")
                        {
                            myCommand.CommandText = SentenciaAddFncMira;
                            myCommand.ExecuteNonQuery();
                        }

                        else
                        {
                            myCommand.CommandText = SentenciaAddFnc;
                            myCommand.ExecuteNonQuery();
                        }

                        break
                            ;
                    case "'Extraordinario Variado'":

                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        for (int i = 0; i < datosExtraVariado.Rows.Count; i++)
                        {

                            VarDia = datosExtraVariado.Rows[i][0].ToString();
                            VarMes = datosExtraVariado.Rows[i][1].ToString();
                            VarAno = datosExtraVariado.Rows[i][2].ToString();
                            VarValor = Convert.ToDouble(datosExtraVariado.Rows[i][3].ToString());
                            FechaExtra = ("'" + VarAno + "-" + VarMes + "-" + VarDia + "'");
                            CuotaNumExt = (i + 1);

                           

                            myCommand.CommandText = " Insert into cuotaextra Values (Concat('CE','" + CuotaNumExt + "'," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + idProyecto + "," +
                           CuotaNumExt + "," + FechaExtra + "," + VarValor + ",0," + VarValor + "," + usuario + "," + strFechaOperacion + ")";

                            myCommand.ExecuteNonQuery();
                        }
                        break;

                    default:

                        break;

                }



                if (A > 0)
                {
                    for (int i = 0; i < datosCuotaInicial.Rows.Count; i++)
                    {

                        VarDia = datosCuotaInicial.Rows[i][0].ToString();
                        VarMes = datosCuotaInicial.Rows[i][1].ToString();
                        VarAno = datosCuotaInicial.Rows[i][2].ToString();
                        VarValor = Convert.ToDouble(datosCuotaInicial.Rows[i][3].ToString());
                        fechaIni = (VarAno + "-" + VarMes + "-" + VarDia);
                        cuotaNumIni = (i + 1);


                        myCommand.CommandText = " Insert into cuotainicial Values (Concat('CI','" + cuotaNumIni + "'," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + idProyecto + "," +
                                        cuotaNumIni + "," + fechaIni + "," + VarValor + "," + usuario + "," + strFechaOperacion + ")";

              
                        myCommand.ExecuteNonQuery();
                    }
                }


                
                

                switch (origenVenta)
                {
                    case "Normal":

                
                        if (FrmLogeo.Pais=="Panama")
                        {
                         


                        }
                        

                        if (FrmLogeo.Proyecto.ToUpper() == "MIRAMAR")
                        {
                            myCommand.CommandText = SentenciaComNormalMiramar;
                            myCommand.ExecuteNonQuery();

                            for (int i = 0; i < dtComisiones.Rows.Count; i++)
                            {

                                idcomision = dtComisiones.Rows[i][0].ToString() + idAdjudicacion;
                                idcargo = dtComisiones.Rows[i][0].ToString();
                                idAsesor = dtComisiones.Rows[i][1].ToString();
                                comIdAsesor = Convert.ToDecimal(dtComisiones.Rows[i][2].ToString());
                                myCommand.CommandText = " INSERT INTO comision1 VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," + comIdAsesor + "," + comIdAsesor + "," + comIdAsesor + "," + comIdAsesor + "," + comIdAsesor + ",5, 'Pendiente' )";
                                myCommand.ExecuteNonQuery();
                            }

                        }

                        else
                        {
                            myCommand.CommandText = SentenciaComNormal;
                            myCommand.ExecuteNonQuery();

                            for (int i = 0; i < dtComisiones.Rows.Count; i++)
                            {

                                idcomision = dtComisiones.Rows[i][0].ToString() + idAdjudicacion;
                                idcargo = dtComisiones.Rows[i][0].ToString();
                                idAsesor = dtComisiones.Rows[i][1].ToString();
                                comIdAsesor = Convert.ToDecimal(dtComisiones.Rows[i][2].ToString());

                                myCommand.CommandText = " INSERT INTO comision1 VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," + comIdAsesor + "," + comIdAsesor + ", 'Pendiente' )";

                                myCommand.ExecuteNonQuery();
                            }
                        }
                        break;

                        
                    case "De Promocion":
                      
                        myCommand.CommandText = SentenciaComNormal;
                        myCommand.ExecuteNonQuery();
                        break;


                    case "Comercial":
                        myCommand.CommandText = SentenciaComComercial;
                        myCommand.ExecuteNonQuery();

                        for (int i = 0; i < dtComisiones.Rows.Count; i++)
                        {
                            idcomision = dtComisiones.Rows[i][0].ToString() + idAdjudicacion;
                            idcargo = dtComisiones.Rows[i][0].ToString();
                            idAsesor = dtComisiones.Rows[i][1].ToString();
                            comIdAsesor = Convert.ToDecimal(dtComisiones.Rows[i][2].ToString());

                            myCommand.CommandText = " INSERT INTO comision1 VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," + comIdAsesor + "," + comIdAsesor + ", 'Pendiente' )";
                            myCommand.ExecuteNonQuery();
                        }
                        break;

                    case "Administrativo":

                        if (credAdmin == "Gerente General")
                        {
                            myCommand.CommandText = SentenciaComGerenteGral;
                            myCommand.ExecuteNonQuery();
                        }
                        else

                            if (credAdmin == "Gerente Financiero")
                            {
                                myCommand.CommandText = SentenciaComGerenteFin;
                                myCommand.ExecuteNonQuery();
                            }
                        break;


                    default:

                        break;

                }


                myTrans.Commit();
                MensajeSalida = "OK";

            }

            catch (Exception e)
            {
                myTrans.Rollback();
                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                             " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L M E T O D  O  M O I F I C A R   V E N T A S
//===================================================================================================================================================









        //===================================================================================================================================================
        //I N I C I O  M E T O D  O   A D I C I O N A R  V E N T A S
        //===================================================================================================================================================
        public string MtdAddVentasAlttum()
        {
            string MensajeSalida;


            string SentenciaGastosLegal = "INSERT INTO gastosadmin (IdCuotaInicial,IdAdjudicacion,IdProyecto,CuotaNum,Fecha,Valor,Usuario,FechaOperacion) Value " +
                "('GA1" + idAdjudicacion + "','" + idAdjudicacion+"',"+idProyecto + ",1," + strFecha + "," + gastosLegales + "," + usuario + ",curdate())";

            string SentenciaComNormal = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, Normal,Normal,'Pendiente' From tablacomision Where Normal > 0)";
            string SentenciaComComercial = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, Comercial,Comercial, 'Pendiente' From tablacomision Where Comercial > 0)";
            string SentenciaComGerenteGral = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, GerenteGral,GerenteGral, 'Pendiente' From tablacomision Where GerenteGral > 0)";
            string SentenciaComGerenteFin = "INSERT INTO comision1 (SELECT Concat(IdCarg,'" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + strFecha + ",Titular,IdCarg, GerenteFin,GerenteFin, 'Pendiente' From tablacomision Where GerenteFin > 0)";

            string SentenciaAddAdjudicacion = " Insert into adjudicacion (Fecha ,  IdAdjudicacion ,  Contrato ,  IdProyecto ,  IdInmueble ,  IdTercero1 ,  IdTercero2 , IdTercero3, FormaPago ,  Valor ,  contado ,  CuotaInicial ,  Financiacion ,  PlazoFnc ,  TasaFnc ," +
            "CuotaFnc ,  InicioFnc ,  Extraordinaria,  PlazoExtra ,  TasaExtra,  CuotaExtra ,  InicioExtra ,  Usuario ,  Estado ,  FechaOperacion,  Porcentaje,  FechaEntrega ,   OrigenVenta ,  TipoOrigen ,  BaseComision )" +

           " Values (" + strFecha + ",'" + idAdjudicacion + "'," + contrato + "," + idProyecto +
                                   "," + idInmueble + "," + idTercero1 + "," + idTercero2 + "," + idTercero3 + "," + formaPago + "," + valor + "," + vrContado + "," + cuotaInicial + "," + financiacion + "," + plazoFnc + "," + tasaFnc + "," + cuotaFncAdj +
                                   "," + strInicioFnc + "," + extraordinaria + "," + plazoExtra + "," + tasaExtra + "," + (cuotaExtra + cuotaExtraVariada) + "," + strInicioExtra + "," +
                                    usuario + "," + estado + "," + strFechaOperacion + "," + Pocentaje + "," + strFechaEntrega + ",'" + origenVenta + "','" + tipoOrigen + "' ," + valor + ")";



            string SentenciaAddFnc = "call AddFinanciacion('" + idAdjudicacion + "','" + idAdjudicacion + "'," + idProyecto + "," + strInicioFnc + "," +
                                   financiacion + "," + tasaFnc + "," + plazoFnc + "," + usuario + "," + inPeriodoFnc + ")";

            string SentenciaAddFncMira = "call AddFncFactor('" + idAdjudicacion + "','" + idAdjudicacion + "'," + idProyecto + "," + strInicioFnc + "," +
                                  financiacion + "," + tasaFnc + "," + plazoFnc + "," + usuario + "," + inPeriodoFnc + "," + factor + ")";

            string SentenciaAddExtra = "call AddExtra('" + idAdjudicacion + "','" + idAdjudicacion + "'," + idProyecto + "," + strInicioExtra + "," + extraordinaria +
                                   "," + tasaExtra + "," + plazoExtra + "," + usuario + "," + (inPeriodoExtra) + ")";



            string SentenciaModEstadoInmuebles = "update inmuebles set Estado ='Adjudicado' WHERE IdInmueble = " + idInmueble;
            string SentenciaModEstadoRsv = "Update Reservas set Estado = '" + idAdjudicacion + "' where idreserva = '" + AddIdreserva + "'";
            string EstadoLibre = "update inmuebles set Estado ='Libre' WHERE IdInmueble = " + inmReserva;
            int A = datosCuotaInicial.Rows.Count;


            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {

                myCommand.CommandText = SentenciaAddAdjudicacion;
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = SentenciaModEstadoInmuebles;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaModEstadoRsv;
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = SentenciaGastosLegal;
                myCommand.ExecuteNonQuery();

                for (int i = 0; i < dtComisiones.Rows.Count; i++)
                {

                    idcomision = dtComisiones.Rows[i][0].ToString() + idAdjudicacion;
                    idcargo = dtComisiones.Rows[i][0].ToString();
                    idAsesor = dtComisiones.Rows[i][1].ToString();
                    comIdAsesor = Convert.ToDecimal(dtComisiones.Rows[i][2].ToString());
                    myCommand.CommandText = " INSERT INTO comision1 VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," + comIdAsesor + "," + comIdAsesor + ", 'Pendiente' )";

                    myCommand.ExecuteNonQuery();
                }

                for (int i = 0; i < DtGastosAdmin.Rows.Count; i++)
                {

                    idcomision = DtGastosAdmin.Rows[i][0].ToString() + idAdjudicacion;
                    idcargo = DtGastosAdmin.Rows[i][0].ToString();
                    idAsesor = DtGastosAdmin.Rows[i][1].ToString();
                    comIdAsesor = Convert.ToDecimal(DtGastosAdmin.Rows[i][2].ToString());
                    myCommand.CommandText = " INSERT INTO comisiong VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," + comIdAsesor + ", 'Pendiente' )";

                    myCommand.ExecuteNonQuery();
                }

                if (idInmueble != inmReserva)
                {
                    myCommand.CommandText = EstadoLibre;
                    myCommand.ExecuteNonQuery();
                }

                switch (formaPago)
                {
                    case "'Contado'":

                        for (int i = 0; i < datosContado.Rows.Count; i++)
                        {
                            VarDia = datosContado.Rows[i][0].ToString();
                            VarMes = datosContado.Rows[i][1].ToString();
                            VarAno = datosContado.Rows[i][2].ToString();
                            VarValor = Convert.ToDouble(datosContado.Rows[i][3].ToString());
                            FechaCon = ("'" + VarAno + "-" + VarMes + "-" + VarDia + "'");
                            CuotaNumCon = (i + 1);

                            myCommand.CommandText = " Insert into Contado Values (Concat('CO','" + CuotaNumCon + "','" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + idProyecto + "," +
                                            CuotaNumCon + "," + FechaCon + "," + VarValor + "," + usuario + "," + strFechaOperacion + ")";
                            myCommand.ExecuteNonQuery();
                        }

                        break;
                    case "'Credicontado'":
                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        break;


                    case "'Extraordinario'":
                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = SentenciaAddExtra;
                        myCommand.ExecuteNonQuery();
                        break;

                    case "'Credito'":

                        if (FrmLogeo.Pais == "Panama")
                        {
                            myCommand.CommandText = SentenciaAddFncMira;
                            myCommand.ExecuteNonQuery();
                        }

                        else
                        {
                            myCommand.CommandText = SentenciaAddFnc;
                            myCommand.ExecuteNonQuery();
                        }

                        break
                            ;
                    case "'Extraordinario Variado'":

                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        for (int i = 0; i < datosExtraVariado.Rows.Count; i++)
                        {

                            VarDia = datosExtraVariado.Rows[i][0].ToString();
                            VarMes = datosExtraVariado.Rows[i][1].ToString();
                            VarAno = datosExtraVariado.Rows[i][2].ToString();
                            VarValor = Convert.ToDouble(datosExtraVariado.Rows[i][3].ToString());
                            FechaExtra = ("'" + VarAno + "-" + VarMes + "-" + VarDia + "'");
                            CuotaNumExt = (i + 1);

                            myCommand.CommandText = " Insert into cuotaextra Values (Concat('CE','" + CuotaNumExt + "','" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + idProyecto + "," +
                                            CuotaNumExt + "," + FechaExtra + "," + VarValor + ",0," + VarValor + "," + usuario + "," + strFechaOperacion + ")";
                            myCommand.ExecuteNonQuery();
                        }
                        break;

                }

                if (A > 0)
                {
                    for (int i = 0; i < datosCuotaInicial.Rows.Count; i++)
                    {

                        VarDia = datosCuotaInicial.Rows[i][0].ToString();
                        VarMes = datosCuotaInicial.Rows[i][1].ToString();
                        VarAno = datosCuotaInicial.Rows[i][2].ToString();
                        VarValor = Convert.ToDouble(datosCuotaInicial.Rows[i][3].ToString());
                        fechaIni = (VarAno + "-" + VarMes + "-" + VarDia);
                        cuotaNumIni = (i + 1);

                        myCommand.CommandText = " Insert into cuotainicial Values (Concat('CI','" + cuotaNumIni + "','" + idAdjudicacion + "'),'" + idAdjudicacion + "'," + idProyecto + "," +
                                        cuotaNumIni + "," + fechaIni + "," + VarValor + "," + usuario + "," + strFechaOperacion + ")";
                        myCommand.ExecuteNonQuery();
                    }
                }
                myCommand.CommandText = "Update Consecutivos set Consecutivo = Consecutivo +1 Where Prefijo ='Adj'";
                myCommand.ExecuteNonQuery();

                switch (origenVenta)
                {
                    case "Normal":

                        myCommand.CommandText = SentenciaComNormal;
                        myCommand.ExecuteNonQuery();

                        break;
                    case "De Promocion":

                        myCommand.CommandText = SentenciaComNormal;
                        myCommand.ExecuteNonQuery();
                        break;


                    case "Comercial":
                        myCommand.CommandText = SentenciaComComercial;
                        myCommand.ExecuteNonQuery();
                        break;

                    case "Administrativo":

                        if (credAdmin == "Gerente General")
                        {
                            myCommand.CommandText = SentenciaComGerenteGral;
                            myCommand.ExecuteNonQuery();
                        }
                        else

                            if (credAdmin == "Gerente Financiero")
                            {
                                myCommand.CommandText = SentenciaComGerenteFin;
                                myCommand.ExecuteNonQuery();
                            }
                        break;


                    default:

                        break;

                }


                myTrans.Commit();
                MensajeSalida = "OK";

            }

            catch (Exception e)
            {
                myTrans.Rollback();
                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                             " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
        //===================================================================================================================================================
        //F I N A L M E T O D O   A D I C I O N A R   V E N T A S
        //===================================================================================================================================================











        //===================================================================================================================================================
        //I N I C I O  M E T O D  O M O D I F I C A R   V E N T A S
        //===================================================================================================================================================
        public string MtdModVentasAlttum()
        {
            string MensajeSalida;


            string SentenciaComNormal = "INSERT INTO comision1 (SELECT Concat(IdCarg," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + strFecha + ",Titular,IdCarg, Normal,Normal,'Pendiente' From tablacomision Where Normal > 0)";
            string SentenciaComComercial = "INSERT INTO comision1 (SELECT Concat(IdCarg," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + strFecha + ",Titular,IdCarg, Comercial,Comercial, 'Pendiente' From tablacomision Where Comercial > 0)";
            string SentenciaComGerenteGral = "INSERT INTO comision1 (SELECT Concat(IdCarg," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + strFecha + ",Titular,IdCarg, GerenteGral,GerenteGral, 'Pendiente' From tablacomision Where GerenteGral > 0)";
            string SentenciaComGerenteFin = "INSERT INTO comision1 (SELECT Concat(IdCarg," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + strFecha + ",Titular,IdCarg, GerenteFin,GerenteFin, 'Pendiente' From tablacomision Where GerenteFin > 0)";



            string SentenciaModAdjudicacion = " Insert into adjudicacion (Fecha ,  IdAdjudicacion ,  Contrato ,  IdProyecto ,  IdInmueble ,  IdTercero1 ,  IdTercero2 , IdTercero3, FormaPago ,  Valor ,  contado ,  CuotaInicial ,  Financiacion ,  PlazoFnc ,  TasaFnc ," +
 "CuotaFnc ,  InicioFnc ,  Extraordinaria,  PlazoExtra ,  TasaExtra,  CuotaExtra ,  InicioExtra ,  Usuario ,  Estado ,  FechaOperacion,  Porcentaje,  FechaEntrega ,   OrigenVenta ,  TipoOrigen ,  BaseComision )" +

" Values (" + strFecha + ",'" + idAdjudicacion + "'," + contrato + "," + idProyecto +
                        "," + idInmueble + "," + idTercero1 + "," + idTercero2 + "," + idTercero3 + "," + formaPago + "," + valor + "," + vrContado + "," + cuotaInicial + "," + financiacion + "," + plazoFnc + "," + tasaFnc + "," + cuotaFncAdj +
                        "," + strInicioFnc + "," + extraordinaria + "," + plazoExtra + "," + tasaExtra + "," + (cuotaExtra + cuotaExtraVariada) + "," + strInicioExtra + "," +
                         usuario + "," + estado + "," + strFechaOperacion + "," + Pocentaje + "," + strFechaEntrega + ",'" + origenVenta + "','" + tipoOrigen + "' ," + valor + ")";



            string SentenciaAddFnc = "call AddFinanciacion(" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + idProyecto + "," + strInicioFnc + "," +
                             financiacion + "," + tasaFnc + "," + plazoFnc + "," + usuario + "," + (inPeriodoFnc) + ")";


            string SentenciaAddFncMira = "call AddFncFactor(" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + idProyecto + "," + strInicioFnc + "," +
                                  financiacion + "," + tasaFnc + "," + plazoFnc + "," + usuario + "," + inPeriodoFnc + "," + factor + ")";

            string SentenciaAddExtra = "call AddExtra(" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + idProyecto + "," + strInicioExtra + "," + extraordinaria +
                                   "," + tasaExtra + "," + plazoExtra + "," + usuario + "," + (inPeriodoExtra) + ")";

            string SentenciaModEstadoInmuebles = "update inmuebles set Estado ='Adjudicado' WHERE IdInmueble = " + idInmueble;
            string EstadoLibre = "update inmuebles set Estado ='Libre' WHERE IdInmueble = " + inmReserva;
            string SentenciaDelContado = "Delete From Contado Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelFnc = "Delete From Financiacion Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelCuotaIni = "Delete From cuotainicial Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelCuotaExtra = "Delete From cuotaextra Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelComision = "Delete From comision1 Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelAdjudicacion = "Delete From Adjudicacion Where IdAdjudicacion = " + idAdjudicacionMod;

            int A = datosCuotaInicial.Rows.Count;



            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;
            try
            {

                myCommand.CommandText = SentenciaDelContado;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelFnc;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelCuotaIni;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelCuotaExtra;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelComision;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelAdjudicacion;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaModAdjudicacion;
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = SentenciaModEstadoInmuebles;
                myCommand.ExecuteNonQuery();
                if (idInmueble != inmReserva)
                {
                    myCommand.CommandText = EstadoLibre;
                    myCommand.ExecuteNonQuery();

                }

                switch (formaPago)
                {
                    case "'Contado'":

                        for (int i = 0; i < datosContado.Rows.Count; i++)
                        {

                            VarDia = datosContado.Rows[i][0].ToString();
                            VarMes = datosContado.Rows[i][1].ToString();
                            VarAno = datosContado.Rows[i][2].ToString();
                            VarValor = Convert.ToDouble(datosContado.Rows[i][3].ToString());
                            FechaCon = ("'" + VarAno + "-" + VarMes + "-" + VarDia + "'");
                            CuotaNumCon = (i + 1);



                            myCommand.CommandText = " Insert into Contado Values (Concat('CO','" + CuotaNumCon + "'," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + idProyecto + "," +
                                            CuotaNumCon + "," + FechaCon + "," + VarValor + "," + usuario + "," + strFechaOperacion + ")";


                            myCommand.ExecuteNonQuery();
                        }

                        break;
                    case "'Credicontado'":
                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        break;


                    case "'Extraordinario'":
                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        myCommand.CommandText = SentenciaAddExtra;
                        myCommand.ExecuteNonQuery();
                        break;

                    case "'Credito'":
                        if (FrmLogeo.Pais == "Panama")
                        {
                            myCommand.CommandText = SentenciaAddFncMira;
                            myCommand.ExecuteNonQuery();
                        }

                        else
                        {
                            myCommand.CommandText = SentenciaAddFnc;
                            myCommand.ExecuteNonQuery();
                        }

                        break
                            ;
                    case "'Extraordinario Variado'":

                        myCommand.CommandText = SentenciaAddFnc;
                        myCommand.ExecuteNonQuery();
                        for (int i = 0; i < datosExtraVariado.Rows.Count; i++)
                        {

                            VarDia = datosExtraVariado.Rows[i][0].ToString();
                            VarMes = datosExtraVariado.Rows[i][1].ToString();
                            VarAno = datosExtraVariado.Rows[i][2].ToString();
                            VarValor = Convert.ToDouble(datosExtraVariado.Rows[i][3].ToString());
                            FechaExtra = ("'" + VarAno + "-" + VarMes + "-" + VarDia + "'");
                            CuotaNumExt = (i + 1);



                            myCommand.CommandText = " Insert into cuotaextra Values (Concat('CE','" + CuotaNumExt + "'," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + idProyecto + "," +
                           CuotaNumExt + "," + FechaExtra + "," + VarValor + ",0," + VarValor + "," + usuario + "," + strFechaOperacion + ")";

                            myCommand.ExecuteNonQuery();
                        }
                        break;

                    default:

                        break;

                }



                if (A > 0)
                {
                    for (int i = 0; i < datosCuotaInicial.Rows.Count; i++)
                    {

                        VarDia = datosCuotaInicial.Rows[i][0].ToString();
                        VarMes = datosCuotaInicial.Rows[i][1].ToString();
                        VarAno = datosCuotaInicial.Rows[i][2].ToString();
                        VarValor = Convert.ToDouble(datosCuotaInicial.Rows[i][3].ToString());
                        fechaIni = (VarAno + "-" + VarMes + "-" + VarDia);
                        cuotaNumIni = (i + 1);


                        myCommand.CommandText = " Insert into cuotainicial Values (Concat('CI','" + cuotaNumIni + "'," + idAdjudicacionMod + ")," + idAdjudicacionMod + "," + idProyecto + "," +
                                        cuotaNumIni + "," + fechaIni + "," + VarValor + "," + usuario + "," + strFechaOperacion + ")";
                        myCommand.ExecuteNonQuery();
                    }
                }


                for (int i = 0; i < dtComisiones.Rows.Count; i++)
                {

                    idcomision = dtComisiones.Rows[i][0].ToString() + idAdjudicacion;
                    idcargo = dtComisiones.Rows[i][0].ToString();
                    idAsesor = dtComisiones.Rows[i][1].ToString();
                    comIdAsesor = Convert.ToDecimal(dtComisiones.Rows[i][2].ToString());
                    myCommand.CommandText = " INSERT INTO comision1 VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," + comIdAsesor + "," + comIdAsesor + ", 'Pendiente' )";

                    myCommand.ExecuteNonQuery();
                }



                for (int i = 0; i <DtGastosAdmin.Rows.Count; i++)
                {

                    idcomision = DtGastosAdmin.Rows[i][0].ToString() + idAdjudicacion;
                    idcargo = DtGastosAdmin.Rows[i][0].ToString();
                    idAsesor = DtGastosAdmin.Rows[i][1].ToString();
                    comIdAsesor = Convert.ToDecimal(DtGastosAdmin.Rows[i][2].ToString());
                    myCommand.CommandText = " INSERT INTO comisiong VAlues ('" + idcomision + "','" + idAdjudicacion + "'," + strFecha + ",'" + idAsesor + "','" + idcargo + "'," +  comIdAsesor + ", 'Pendiente' )";

                    myCommand.ExecuteNonQuery();
                }


                switch (origenVenta)
                {
                    case "Normal":


                        if (FrmLogeo.Pais == "Panama")
                        {



                        }
                        myCommand.CommandText = SentenciaComNormal;
                        myCommand.ExecuteNonQuery();

                        break;
                    case "De Promocion":

                        myCommand.CommandText = SentenciaComNormal;
                        myCommand.ExecuteNonQuery();
                        break;


                    case "Comercial":
                        myCommand.CommandText = SentenciaComComercial;
                        myCommand.ExecuteNonQuery();
                        break;

                    case "Administrativo":

                        if (credAdmin == "Gerente General")
                        {
                            myCommand.CommandText = SentenciaComGerenteGral;
                            myCommand.ExecuteNonQuery();
                        }
                        else

                            if (credAdmin == "Gerente Financiero")
                            {
                                myCommand.CommandText = SentenciaComGerenteFin;
                                myCommand.ExecuteNonQuery();
                            }
                        break;


                    default:

                        break;

                }


                myTrans.Commit();
                MensajeSalida = "OK";

            }

            catch (Exception e)
            {

                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                             " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
        //===================================================================================================================================================
        //F I N A L M E T O D  O  M O I F I C A R   V E N T A S
        //===================================================================================================================================================




//===================================================================================================================================================
//I N I C I O   E L I M I N A R   A D J U D I C A C I O N
//===================================================================================================================================================
        public string MtdDelVentas()
        {

            string SentenciaDelContado = "Delete From Contado Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelFnc = "Delete From Financiacion Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelCuotaIni = "Delete From cuotainicial Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelCuotaExtra = "Delete From cuotaextra Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelComision = "Delete From comision1 Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaDelAdjudicacion = "Delete From Adjudicacion Where IdAdjudicacion = " + idAdjudicacionMod;
            string SentenciaModEstadoInmuebles = "update inmuebles set Estado ='Libre' WHERE IdInmueble = " + idInmueble;

            string MensajeSalida = "";
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = SentenciaDelContado;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelFnc;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelCuotaIni;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelCuotaExtra;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelComision;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaDelAdjudicacion;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = SentenciaModEstadoInmuebles;
                myCommand.ExecuteNonQuery();
                
                myTrans.Commit();
                MensajeSalida = "OK";

            }
            catch (Exception e)
            {
                
                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                              " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L     E L I M I N A R   A D J U D I C A C I O N
//===================================================================================================================================================




//===================================================================================================================================================
//I N I C I O   D E S I S T I R   V E N T A S
//===================================================================================================================================================
        public string MtdDesVenta()
        {
            string DesVenta;
            if (estado == "Juridico")
            {
                DesVenta = " Update Adjudicacion set Estado = 'Desistido Juridico' Where IdAdjudicacion = " + idAdjudicacionMod + "";
            }
            else
            {
                 DesVenta = " Update Adjudicacion set Estado = 'Desistido' Where IdAdjudicacion = " + idAdjudicacionMod + "";
            }

            
            string DesEstado = "update inmuebles set Estado ='Libre' WHERE IdInmueble = " + idInmueble;

            string MensajeSalida = "";
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = DesVenta;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = DesEstado;
                myCommand.ExecuteNonQuery();

                myTrans.Commit();
                MensajeSalida = "OK";

            }
            catch (Exception e)
            {
                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                              " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L     D E S I S T I R    R E S E R V A
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O  M E T O D  O   A P R O B A R   V E N T A S
//===================================================================================================================================================
        public string MtdAprobarVentas()
        {
            string Aprobar = "Update Adjudicacion Set Estado='Aprobado' Where IdAdjudicacion = " + idAdjudicacionMod;
            string MensajeSalida = "";
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = Aprobar;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MensajeSalida = "OK";

            }
            catch (Exception e)
            {

                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                             " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }

            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L M E T O D  O  A P R O B A R   V E N T A S
//===================================================================================================================================================


        

//===================================================================================================================================================
//I N I C I O   A D I C I O N A R  R E S E R V A
//===================================================================================================================================================
        public string MtdAddReserva()
        {

            string Reserva = " Insert into Reservas Values ('" + idReserva + "'," + strFecha + "," + contrato + "," + idProyecto +
                                    "," + idInmueble + "," + idTercero1 + "," + idTercero2 + "," + Valor + "," + pago1 + "," + strInicioFnc + ",'" +
                                   titulo + "'," + usuario + "," + estado + "," + strFechaOperacion + ")";

            string CambioEstado = "update inmuebles set Estado ='Reservado' WHERE IdInmueble = " + idInmueble;
            string MensajeSalida = "";
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = Reserva;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = CambioEstado;
                myCommand.ExecuteNonQuery();

                myTrans.Commit();
                MensajeSalida = "OK";

            }
            catch (Exception e)
            {
             MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                             " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L      A D I C I O N A R  R E S E R V A
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M O D I F I C A R  R E S E R V A
//===================================================================================================================================================
        public string MtdModReserva()
        {

            string ReservaMod = " Update Reservas set Fecha = " + strFecha + ", contrato = " + contrato + ",IdInmueble = " + idInmueble +
                ",IdTercero1 =" + idTercero1 + ",IdGestor = " + idTercero2 + ",ValorContrato = " + Valor + ",ValorPago1= " + pago1 +
                ", FechaInicio = " + strInicioFnc + ", Letra ='" + titulo + "',Usuario = " + usuario + ", Estado = " + estado + ",FechaOperacion =" +
                strFechaOperacion + " Where IdReserva = '" + modIdReserva + "'";

            string EstadoLibre = "update inmuebles set Estado ='Libre' WHERE IdInmueble = '" + idInmuebleAnt + "'";

            string EstadoReserva = "update inmuebles set Estado ='Reservado' WHERE IdInmueble = " + idInmueble;



            string MensajeSalida = "";
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = ReservaMod;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = EstadoLibre;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = EstadoReserva;
                myCommand.ExecuteNonQuery();

                myTrans.Commit();
                MensajeSalida = "OK";

            }
            catch (Exception e)
            {
                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                             " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L     M O D I F I C A R   R E S E R V A
//===================================================================================================================================================




//===================================================================================================================================================
//I N I C I O   E L I M I N A R   R E S E R V A
//===================================================================================================================================================
        public string MtdDelReserva()
        {

            string ReservaDel = " Delete from  Reservas Where IdReserva = '" + modIdReserva + "'";
            string EstadoReserva = "update inmuebles set Estado ='Libre' WHERE IdInmueble = " + idInmueble;
            
            string MensajeSalida = "";
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = ReservaDel;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = EstadoReserva;
                myCommand.ExecuteNonQuery();

                myTrans.Commit();
                MensajeSalida = "OK";

            }
            catch (Exception e)
            {
                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                              " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L     E L I M I N A R    R E S E R V A
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   D E S I S T I R   R E S E R V A
//===================================================================================================================================================
        public string MtdDesReserva()
        {

            string ReservaDes = " Update Reservas set Estado = 'Desistido', Usuario= '"+FrmLogeo.Usuario+"' , FechaOperacion = Curdate()  Where IdReserva = '" + modIdReserva + "'";
            string EstadoReserva = "update inmuebles set Estado ='Libre' WHERE IdInmueble = " + idInmueble;

            string MensajeSalida = "";
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = ReservaDes;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = EstadoReserva;
                myCommand.ExecuteNonQuery();

                myTrans.Commit();
                MensajeSalida = "OK";

            }
            catch (Exception e)
            {
                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                              " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L     D E S I S T I R    R E S E R V A
//===================================================================================================================================================




//===================================================================================================================================================
//I N I C I O  M E T O D O   A D I C I O N A R   O T R O S I
//===================================================================================================================================================
        public string MtdAddOtrosi()
        {

            string MensajeSalida = "";


            string SentModAdj = " UPDATE  adjudicacion SET Valor = " + nuevoCapital + ",cuotainicial =" + cuotaInicialOtrosi + ",Financiacion =" + financiacionOtrosi + ", PlazoFnc =" + plazoFncOtrosi + ", TasaFnc = " + tasaFncOtrosi +
                                 ",CuotaFnc= " + cuotaFncAdjOtrosi + ", InicioFnc = " + strInicioFnc + ", Extraordinaria = " + extraordinariaOtrosi + ",PlazoExtra = " + plazoExtraOtrosi + ", TasaExtra = " +
                                 tasaExtraOtrosi + ",CuotaExtra = " + cuotaExtraOtrosi + ",InicioExtra = " + strInicioExtra + ", Usuario = " + usuario + ",FechaOperacion =" + strFechaOperacion + ", Estado='Otrosi'"
                                 + "Where IdAdjudicacion = " + idAdjudicacionMod;


            string SentModFnc = "call ModFinanciacion(" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + ultimaCuotaFnc + "," + idProyecto + "," + strInicioFnc + "," +
                                    nuevaFinanciacion + "," + tasaFncOtrosi + "," + plazoFncOtrosi + "," + usuario + "," + inPeriodoFnc+")";

            string SentModExtra = "call ModExtra(" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + numCuotaAbnCapital + "," + idProyecto + "," + strInicioExtra + "," + nuevaExtraordinaria +
                                    "," + tasaExtraOtrosi + "," + plazoExtraOtrosi + "," + usuario + "," + (inPeriodoExtra) + ")";


            string SentAddPagExt = "Insert into CuotaExtra value(" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + idProyecto + "," + numCuotaAbnCapital + ",'" + fechaPagoExtra + "'," + abonoCapital +
                                                   "," + 0 + "," + abonoCapital + "," + usuario + "," + strFechaOperacion + ")";

            string SentDelFnc = "Delete from Financiacion Where IdAdjudicacion = " + idAdjudicacionMod + " And CuotaNum > " + ultimaCuotaFnc;

            string SentDelExtra = "Delete from cuotaextra Where IdAdjudicacion = " + idAdjudicacionMod + " And CuotaNum > " + ultimaCuotaExtra;

            string SentDelNuevootrosi = "Delete from NuevoOtrosi where idOtrosi =" + idOtrosi;

            string SentDelIni = "Delete from cuotainicial Where IdAdjudicacion = " + idAdjudicacionMod + " And CuotaNum > " + ultimaCuotaInicial;

            
                string SentAddOtrosi = "Insert into nuevootrosi Value ((select Consecutivo from consecutivos where prefijo ='Otr'),Curdate()," + idAdjudicacionMod + "," + recaudoTotal + "," +
                                      valor + "," + nuevoCapital + "," + financiacion + "," + nuevaFinanciacion + "," + PlazoFnc + "," + plazoFncOtrosi + "," + tasaFnc + "," + tasaFncOtrosi + "," + cuotaFncAdj + "," + cuotaFncAdjOtrosi + "," +
                                     cuotaInicial + "," + nuevaCuotaInicial + "," + extraordinaria + "," + nuevaExtraordinaria + "," + plazoExtra + "," + plazoExtraOtrosi + "," + tasaExtra + "," + tasaExtraOtrosi + "," + cuotaExtra + "," + cuotaExtraOtrosi + "," +
                                     usuario + "," + strFechaOperacion + ",'Pendiente','',0,0,0)";
            
                string SentModOtrosi = "Insert into nuevootrosi Value ("+idOtrosi+",Curdate()," + idAdjudicacionMod + "," + recaudoTotal + "," +
                                      valor + "," + nuevoCapital + "," + financiacion + "," + nuevaFinanciacion + "," + PlazoFnc + "," + plazoFncOtrosi + "," + tasaFnc + "," + tasaFncOtrosi + "," + cuotaFncAdj + "," + cuotaFncAdjOtrosi + "," +
                                     cuotaInicial + "," + nuevaCuotaInicial + "," + extraordinaria + "," + nuevaExtraordinaria + "," + plazoExtra + "," + plazoExtraOtrosi + "," + tasaExtra + "," + tasaExtraOtrosi + "," + cuotaExtra + "," + cuotaExtraOtrosi + "," +
                                     usuario + "," + strFechaOperacion + ",'Pendiente','',0,0,0)";
            



            string SentModCons = "Update Consecutivos set Consecutivo = Consecutivo+1 where prefijo ='Otr'";

            string SentModFncManual = "Update Financiacion set Interes = " + sdoIntCteFnc + ", Capital =" + sdoCptFnc + ", Cuota= " + sdoCuotaFnc + " Where IdAdjudicacion = " + idAdjudicacionMod +
                " And CuotaNum = " + ultimaCuotaFnc;
            int A = datosCuotaInicial.Rows.Count;

            string SentModIniManual = "Update CuotaInicial  set Valor =" + sdoCptIni + " Where IdAdjudicacion = " + idAdjudicacionMod +
               " And CuotaNum = " + ultimaCuotaInicial;
           

            string SentModExtraManual = "Update CuotaExtra set Intereses = " +  SdoIntCteExtra + ", Capital =" + sdoCptExtra + ", ValorTotal= " + sdoCuotaExtra + " Where IdAdjudicacion = " + idAdjudicacionMod +
               " And CuotaNum = " + ultimaCuotaExtra;
           

            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {

                

                if (otrosiFnc == 1)
                {
                    myCommand.CommandText = SentDelFnc;
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = SentModFnc;
                    myCommand.ExecuteNonQuery();
                    if (ultimaCuotaFnc > 0)
                    {
                        myCommand.CommandText = SentModFncManual;
                        myCommand.ExecuteNonQuery();
                    }
                }
                if (otrosiExtra == 1)
                {

                    myCommand.CommandText = SentDelExtra;
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = SentModExtra;
                    myCommand.ExecuteNonQuery();
                    if (ultimaCuotaExtra > 0)
                    {
                        myCommand.CommandText = SentModExtraManual;
                        myCommand.ExecuteNonQuery();
                    }
                }
                if (abonoCapital > 0)
                {

                    myCommand.CommandText = SentAddPagExt;
                    myCommand.ExecuteNonQuery();

                }

                if (otrosiInicial == 1)
                {

                    if (ultimaCuotaInicial > 0)
                    {
                        myCommand.CommandText = SentModIniManual;
                        myCommand.ExecuteNonQuery();
                    }

                    myCommand.CommandText = SentDelIni;
                    myCommand.ExecuteNonQuery();

                    if (A > 0)
                    {
                        for (int i = 0; i < datosCuotaInicial.Rows.Count; i++)
                        {

                            VarDia = datosCuotaInicial.Rows[i][0].ToString();
                            VarMes = datosCuotaInicial.Rows[i][1].ToString();
                            VarAno = datosCuotaInicial.Rows[i][2].ToString();
                            VarValor = Convert.ToDouble(datosCuotaInicial.Rows[i][3].ToString());
                            fechaIni = (VarAno + "-" + VarMes + "-" + VarDia);
                            cuotaNumIni = (i + 1 + ultimaCuotaInicial);

                            myCommand.CommandText = " Insert into cuotainicial Values (" + idAdjudicacionMod + "," + idAdjudicacionMod + "," + idProyecto + "," +
                                            cuotaNumIni + "," + fechaIni + "," + VarValor + "," + usuario + "," + strFechaOperacion + ")";
                            myCommand.ExecuteNonQuery();
                        }
                    }

                }
                myCommand.CommandText = SentModAdj;
                myCommand.ExecuteNonQuery();

                if (accionOtrosi == "Adicionar")
                {
                    myCommand.CommandText = SentAddOtrosi;
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = SentModCons;
                    myCommand.ExecuteNonQuery();

                }
                if (accionOtrosi == "Modificar")
                {
                    myCommand.CommandText = SentDelNuevootrosi;
                    myCommand.ExecuteNonQuery();
                    myCommand.CommandText = SentModOtrosi;
                    myCommand.ExecuteNonQuery();

                }
                

                myTrans.Commit();
                MensajeSalida = "OK";

            }

            catch (Exception e)
            {
                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                              " Esta Transaccion no quedo registrada.";  
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   A D I C I O N A R   O T R O S I
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O  M E T O D O   A P R O B A R   O T R O S I
//===================================================================================================================================================
        public string MtdAprOtrosi()
        {
            string Sentencia230 = "Update Adjudicacion Set Estado='Aprobado' Where IdAdjudicacion = " + idAdjudicacionMod;
            string Sentencia240 = "Update nuevootrosi Set Estado='Aprobado' Where IdOtrosi = " + idOtrosi;


            string MensajeSalida = "";

            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = Sentencia230;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = Sentencia240;
                myCommand.ExecuteNonQuery();

                myTrans.Commit();
                MensajeSalida = "OK";

            }

            catch (Exception e)
            {
                MensajeSalida = "Se presento el Sgte Error" + e.Message +
                                                            " Esta Transaccion no quedo registrada.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;

        }
//===================================================================================================================================================
//F I N A L  M E T O D O   A P R O B A R   O T R O S I
//===================================================================================================================================================





        
//===================================================================================================================================================
//I N I C I O   C O N V E R T I R   F E C H A   A   S T R I N G
//===================================================================================================================================================
        public string MtdConvertFechaStr(DateTime fecha)
        {
            string ano, mes, dia, Varfecha;
            ano = Convert.ToString(fecha.Year);
            mes = Convert.ToString(fecha.Month);
            dia = Convert.ToString(fecha.Day);
            Varfecha = "'" + ano + "-" + mes + "-" + dia + "'";
            return Varfecha;
        }
//===================================================================================================================================================
//I N I C I O   C O N V E R T I R   F E C H A   A   S T R I N G
//===================================================================================================================================================





//===================================================================================================================================================
// I N I C I O  M E T O D  O   B U S C A R   C O N S E C U T I V O S
//===================================================================================================================================================
        public string MtdBscConsecutivos(string Sentencia)
        {
            ConexionClas.Open();
            string Msj;
            try
            {

                MySqlCommand CmdBscConsecutivos = new MySqlCommand(Sentencia, ConexionClas);

                CmdBscConsecutivos.Connection = ConexionClas;

                object result = CmdBscConsecutivos.ExecuteScalar();

                return Convert.ToString(result);
            }


            catch (Exception x)
            {
                Msj = x.Message;

                return Msj;
            }
            finally
            {
                ConexionClas.Close();

            }
        }
//===================================================================================================================================================
// F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S
//===================================================================================================================================================









        #endregion
//---------------------------------------------------------------------------------------------------------------------------------------------------
//F I N A L   R E G I O O N   D E   M E T O D O S
//---------------------------------------------------------------------------------------------------------------------------------------------------



















        //===============================================================================================================================
        //(20) I N I C I O  M E T O D  O   B U S C A R   C O N S E C U T I V O S   A D J U D I C A C I O N
        //===============================================================================================================================
        public string MtdCscAdj()
        {
            return MtdBscConsecutivos("SELECT consecutivo FROM Consecutivos WHERE NombreTabla = 'Adjudicacion'");
        }
        //===============================================================================================================================
        //(20) F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S A D J U D I C A C I O N
        //===============================================================================================================================


        //===============================================================================================================================
        //(21) I N I C I O  M E T O D  O   B U S C A R   C O N S E C U T I V O S   E X T R A O R D I N A R I A S
        //===============================================================================================================================
        public string MtdCscExtra()
        {
            return MtdBscConsecutivos("SELECT consecutivo FROM Consecutivos WHERE NombreTabla = 'SCtaExtr'");
        }
        //===============================================================================================================================
        //(21) F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S  E X T R A O R D I N A R I A S
        //===============================================================================================================================




        //===============================================================================================================================
        //(22) I N I C I O  M E T O D  O   B U S C A R   C O N S E C U T I V O S  I N I C I A L
        //===============================================================================================================================
        public string MtdCscInicial()
        {
            return MtdBscConsecutivos("SELECT consecutivo FROM Consecutivos WHERE NombreTabla = 'CuotaInicial'");
        }
        //===============================================================================================================================
        //(22) F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S  I N I C I A  L
        //===============================================================================================================================




        //===============================================================================================================================
        //(23) I N I C I O  M E T O D  O   B U S C A R   C O N S E C U T I V O S  F I N A N C I A C I O N
        //===============================================================================================================================
        public string MtdCscFnc()
        {
            return MtdBscConsecutivos("SELECT consecutivo FROM Consecutivos WHERE NombreTabla = 'Financiacion'");
        }
        //===============================================================================================================================
        //(23) F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S  F I N A N C I A C I O N
        //===============================================================================================================================




        //===============================================================================================================================
        //(24) I N I C I O  M E T O D  O   B U S C A R   C O N S E C U T I V O S  R E S E R V A
        //===============================================================================================================================
        public string MtdCscReserva()
        {
            return MtdBscConsecutivos("SELECT consecutivo FROM Consecutivos WHERE NombreTabla = 'Reserva'");
        }
        //===============================================================================================================================
        //(24) F I N A L  M E T O D  O   B U S C A R     C O N S E C U T I V O S  R E S E R V A
        //===============================================================================================================================




        //===============================================================================================================================
        //(24) I N I C I O  M E T O D  O   B U S C A R   C O N S E C U T I V O S  CONTADO
        //===============================================================================================================================
        public string MtdCscCont()
        {
            return MtdBscConsecutivos("SELECT consecutivo FROM Consecutivos WHERE NombreTabla = 'Scontado'");
        }
        //===============================================================================================================================
        //(24) F I N A L  M E T O D  O   B U S C A R     C O N S E C U T I V O S  C O N T A D O 
        //===============================================================================================================================


        //===============================================================================================================================
        //(25) I N I C I O  M E T O D  O   M O D I F I C A R   C O N S E C U T I V O S  A D J 
        //===============================================================================================================================
        public void MtdModCscAdj()
        {
            MtdBscConsecutivos("UPDATE consecutivos SET consecutivo ='" + nvoCscAdj + "' WHERE NombreTabla ='Adjudicacion'");
        }
        //===============================================================================================================================
        //(25) F I N A L  M E T O D  O   M O D I F I C A R   C O N S E C U T I V O S  A D J 
        //===============================================================================================================================





        //===============================================================================================================================
        //(26) I N I C I O  M E T O D  O   M O D I F I C A R   C O N S E C U T I V O S  F N C 
        //===============================================================================================================================
        public void MtdModCscFnc()
        {
            MtdBscConsecutivos("UPDATE consecutivos SET consecutivo ='" + nvoCscFnc + "' WHERE NombreTabla ='Financiacion'");
        }
        //===============================================================================================================================
        //(26) F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S  F N C
        //===============================================================================================================================




        //===============================================================================================================================
        //(27) I N I C I O  M E T O D  O   M O D I F I C A R   C O N S E C U T I V O S I N I C I A L
        //===============================================================================================================================
        public void MtdModCscIni()
        {
            MtdBscConsecutivos("UPDATE consecutivos SET consecutivo ='" + nvoCscIni + "' WHERE NombreTabla ='CuotaInicial'");
        }
        //===============================================================================================================================
        //(27) F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S  I N I C I A L
        //===============================================================================================================================





        //===============================================================================================================================
        //(28) I N I C I O  M E T O D  O   M O D I F I C A R   C O N S E C U T I V O  E X T R A 
        //===============================================================================================================================
        public void MtdModCsceExtra()
        {
            MtdBscConsecutivos("UPDATE consecutivos SET consecutivo ='" + nvoCscExtra + "' WHERE NombreTabla ='SCtaExtr'");
        }
        //===============================================================================================================================
        //(28) F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S  E X T R A
        //===============================================================================================================================




        //===============================================================================================================================
        //(29) I N I C I O  M E T O D  O   M O D I F I C A R   C O N S E C U T I V O  C O N T A D O 
        //===============================================================================================================================
        public void MtdModCscCon()
        {
            MtdBscConsecutivos("UPDATE consecutivos SET consecutivo ='" + nvoCscCon + "' WHERE NombreTabla ='SContado'");
        }
        //===============================================================================================================================
        //(29) F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S  C O N T A D O
        //===============================================================================================================================


        //===============================================================================================================================
        //(29) I N I C I O  M E T O D  O   M O D I F I C A R   C O N S E C U T I V O  R E S E R V A
        //===============================================================================================================================
        public void MtdModCscRsv()
        {
            MtdBscConsecutivos("UPDATE consecutivos SET consecutivo ='" + nvoCscReserva + "' WHERE NombreTabla ='Reserva'");
        }
        //===============================================================================================================================
        //(29) F I N A L  M E T O D  O   B U S C A R   C O N S E C U T I V O S  R E S E R V A
        //===============================================================================================================================














      
        


    }
}
