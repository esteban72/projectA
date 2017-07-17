using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MySql.Data.MySqlClient;
using System.Data;
namespace CarteraGeneral
{
    class Simulador
    {

        MySqlConnection MysqlConexion = new MySqlConnection (FrmLogeo.StrConexion);
        MySqlConnection ConexionClas = new MySqlConnection(FrmLogeo.StrConexion);

        private double Capital;
        private double TasaInteres;
        private int Periodo;
        private int Plazo;
        private double Cuota;
        private DateTime FechaInicio;

        private double CapitalExtra;
        private double TasaInteresExtra;
        private int PeriodoExtra;
        private int PlazoExtra;
        private double CuotaExtra;
        private DateTime FechaInicioExtra;

        public double capital
        {
            get { return Capital; }
            set { Capital = value; }
        }

        public double tasaInteres
        {
            get { return TasaInteres; }
            set { TasaInteres = value; }
        }

        public int periodo
        {
            get { return Periodo; }
            set { Periodo = value; }
        }

        public int plazo
        {
            get { return Plazo; }
            set { Plazo = value; }
        }

        public double cuota
        {
            get { return Cuota; }
            set { Cuota = value; }
        }

        public DateTime fechaInicio
        {
            get { return FechaInicio; }
            set { FechaInicio = value; }
        }


        public double capitalExtra
        {
            get { return CapitalExtra; }
            set { CapitalExtra = value; }
        }

        public double tasaInteresExtra
        {
            get { return TasaInteresExtra; }
            set { TasaInteresExtra = value; }
        }

        public int periodoExtra
        {
            get { return PeriodoExtra; }
            set { PeriodoExtra = value; }
        }

        public int plazoExtra
        {
            get { return PlazoExtra; }
            set { PlazoExtra = value; }
        }

        public double cuotaExtra
        {
            get { return CuotaExtra; }
            set { CuotaExtra = value; }
        }

        public DateTime fechaInicioExtra
        {
            get { return FechaInicioExtra; }
            set { FechaInicioExtra = value; }
        }




//===================================================================================================================================================
// I N I C I O   C A L C U L O   C U O T A   F I J A
//===================================================================================================================================================
        public double CalculoCuotaFija()
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
                CuotaFijaCalculada = (capital) * (tasaInteres / (periodo * 100)) / x;

            }
            else
            {
                CuotaFijaCalculada = Math.Round((capital / plazo), 0);

            }
            return Math.Round(CuotaFijaCalculada, 0);
        }
//===================================================================================================================================================
//F I N A L      C A L C U L O   C U O T A   F I J A
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O   C A L C U L O   D E   C A P I T A L
//===================================================================================================================================================
        public double CalcularCapital(double Cuota, double Plazo, double TasaInteres, int Periodo)
        {
            double a, b, x;
            double Capital;
            a = (1 + TasaInteres / (Periodo * 100));
            b = Plazo;
            x = Math.Pow(a, b);
            x = 1 / x;
            x = 1 - x;
            Capital = Cuota / ((TasaInteres / (Periodo * 100)) / x);
            return Math.Round(Capital, 0);
        }
//===================================================================================================================================================
//F I N A L      C A L C U L O   D E    C A P I T A L
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   C U O T A S
//===================================================================================================================================================
      public DataTable MtdCuotasExtra()
        {


            double CapitalCuota, InteresCuota, SaldoCuota, CuotaCuota;
            DateTime Fecha;
            SaldoCuota = capital;

            DataTable table = new DataTable();
            table.Columns.Add("Mes", typeof(DateTime));
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Valor", typeof(double));
            table.Columns.Add("Capital", typeof(double));
            table.Columns.Add("Interes", typeof(double));
            table.Columns.Add("Saldo", typeof(double));
            for (int i = 1; i < plazo + 1; i++)
            {
                Fecha = fechaInicio.AddMonths(12 / periodo * (i - 1));
                InteresCuota = Math.Round(((SaldoCuota * (12 / periodo * 30) * tasaInteres) / 36000), 0);
                CapitalCuota = Math.Round((cuota - InteresCuota), 0);
                SaldoCuota = Math.Round((SaldoCuota - CapitalCuota), 0);
                CuotaCuota = Math.Round((CapitalCuota + InteresCuota), 0);
                table.Rows.Add(Fecha, i, CuotaCuota, CapitalCuota, InteresCuota, SaldoCuota);


            }
            SaldoCuota = capitalExtra;
            for (int i = 1; i < plazoExtra + 1; i++)
            {
                Fecha = fechaInicio.AddMonths(12 / periodo * (i - 1));
                InteresCuota = Math.Round(((SaldoCuota * (12 / periodoExtra * 30) * tasaInteresExtra) / 36000), 0);
                CapitalCuota = Math.Round((cuotaExtra - InteresCuota), 0);
                SaldoCuota = Math.Round((SaldoCuota - CapitalCuota), 0);
                CuotaCuota = Math.Round((CapitalCuota + InteresCuota), 0);
                table.Rows.Add(Fecha, i, CuotaCuota, CapitalCuota, InteresCuota, SaldoCuota);


            }



            return table;
        }
//===================================================================================================================================================
//F I N A L    M E TODO CUOTAS
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O   C U O T A S
//===================================================================================================================================================
        public DataTable MtdCuotas()
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
                CuotaFijaCalculada = Math.Round(((capital) * (tasaInteres / (periodo * 100)) / x), 0);
            }

            else
            {
                CuotaFijaCalculada = Math.Round((capital / plazo), 2);
            }

            double CapitalCuota, InteresCuota, SaldoCuota, CuotaCuota;
            DateTime Fecha;
            SaldoCuota = capital;

            DataTable table = new DataTable();
            table.Columns.Add("Mes", typeof(DateTime));
            table.Columns.Add("Num", typeof(int));
            table.Columns.Add("Valor", typeof(double));
            table.Columns.Add("Capital", typeof(double));
            table.Columns.Add("Interes", typeof(double));
            table.Columns.Add("Saldo", typeof(double));
            for (int i = 1; i < plazo + 1; i++)
            {
                Fecha = fechaInicio.AddMonths(12 / periodo * (i - 1));
                InteresCuota = Math.Round(((SaldoCuota * (12 / periodo * 30) * tasaInteres) / 36000), 0);
                CapitalCuota = Math.Round((CuotaFijaCalculada - InteresCuota), 0);
                SaldoCuota = Math.Round((SaldoCuota - CapitalCuota), 0);
                CuotaCuota = Math.Round((CapitalCuota + InteresCuota), 0);
                table.Rows.Add(Fecha, i, CuotaCuota, CapitalCuota, InteresCuota, SaldoCuota);


            }

            return table;
        }
//===================================================================================================================================================
//F I N A L    M E TODO CUOTAS
//===================================================================================================================================================

    }
}
