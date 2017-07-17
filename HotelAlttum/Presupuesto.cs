using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CarteraGeneral
{
    class Presupuesto
    {
        public DataTable DtProyecto = new DataTable();
        public DataTable DtRangoCartera = new DataTable();
        ClsIdentificacion conexion = new ClsIdentificacion();
        public DataTable DtPresupuesto = new DataTable();
        public DateTime FechaInicial = new DateTime();
        public DateTime FechaFinal = new DateTime();
        public List<string> ListaMes = new List<string>();
        public List<string> datos = new List<string>();
        public string Titulo;
        string NomTabla;
        public int Desde, Hasta;
        string TablaPresGral, TablaPresPost, VarMes, VarPeriodo, VarConexion, VarCodigo, VarBasedatos, Varproyecto;
        #region REGION DE METODOS PRIVADOS

        void MtdDatosMes(string Mes, string Año)
        {
            string fechaini = "", fechafin = "";
            switch (Mes)
            {
                case "Enero":
                    VarMes = "01";
                    fechaini = Año + "-01-01";
                    fechafin = Año + "-01-31";
                    TablaPresGral = "presupuestogeneralenero" + Año;
                    TablaPresPost = "presupuestogeneralfebrero" + Año;
                    break;

                case "Febrero":
                    VarMes = "02";
                    fechaini = Año + "-02-01";
                    fechafin = Año + "-02-28";
                    TablaPresGral = "presupuestogeneralfebrero" + Año;
                    TablaPresPost = "presupuestogeneralmarzo" + Año;
                    break;

                case "Marzo":
                    VarMes = "03";
                    fechaini = Año + "-03-01";
                    fechafin = Año + "-03-31";
                    TablaPresGral = "presupuestogeneralmarzo" + Año;
                    TablaPresPost = "presupuestogeneralabril" + Año;
                    break;

                case "Abril":
                    VarMes = "04";
                    fechaini = Año + "-04-01";
                    fechafin = Año + "-04-30";
                    TablaPresGral = "presupuestogeneralabril" + Año;
                    TablaPresPost = "presupuestogeneralmayo" + Año;
                    break;
                case "Mayo":
                    VarMes = "05";
                    fechaini = Año + "-05-01";
                    fechafin = Año + "-05-31";
                    TablaPresGral = "presupuestogeneralmayo" + Año;
                    TablaPresPost = "presupuestogeneraljunio" + Año;
                    break;

                case "Junio":
                    VarMes = "06";
                    fechaini = Año + "-06-01";
                    fechafin = Año + "-06-30";
                    TablaPresGral = "presupuestogeneraljunio" + Año;
                    TablaPresPost = "presupuestogeneraljulio" + Año;

                    break;

                case "Julio":
                    VarMes = "07";
                    fechaini = Año + "-07-01";
                    fechafin = Año + "-07-31";
                    TablaPresGral = "presupuestogeneraljulio" + Año;
                    TablaPresPost = "presupuestogeneralagosto" + Año;
                    break;

                case "Agosto":
                    VarMes = "08";
                    fechaini = Año + "-08-01";
                    fechafin = Año + "-08-31";

                    TablaPresGral = "presupuestogeneralagosto" + Año;
                    TablaPresPost = "presupuestogeneralseptiembre" + Año;
                    break;

                case "Septiembre":
                    VarMes = "09";
                    fechaini = Año + "-09-01";
                    fechafin = Año + "-09-30";
                    TablaPresGral = "presupuestogeneralseptiembre" + Año;
                    TablaPresPost = "presupuestogeneraloctubre" + Año;
                    break;

                case "Octubre":
                    VarMes = "10";
                    fechaini = Año + "-10-01";
                    fechafin = Año + "-10-31";
                    TablaPresGral = "presupuestogeneraloctubre" + Año;
                    TablaPresPost = "presupuestogeneralnoviembre" + Año;
                    break;

                case "Noviembre":
                    VarMes = "11";
                    fechaini = Año + "-11-01";
                    fechafin = Año + "-11-30";
                    TablaPresGral = "presupuestogeneralnoviembre" + Año;
                    TablaPresPost = "presupuestogeneraldiciembre" + Año;
                    break;

                case "Diciembre":
                    VarMes = "12";
                    fechaini = Año + "-12-01";
                    fechafin = Año + "-12-31";
                    TablaPresGral = "presupuestogeneraldiciembre" + Año;
                    TablaPresPost = "presupuestogeneralenero" + (Año + 1);
                    break;

                default:

                    break;
            }
            VarPeriodo = Año + VarMes;
            //fechaprimermes =Año + "-01-01";
            //DtpFechaIniProyecto.Value = Convert.ToDateTime("2000-01-01");
            FechaInicial = Convert.ToDateTime(fechaini);
            FechaFinal = Convert.ToDateTime(fechafin);

        }
        public void MtdRango()
        {
            DtRangoCartera = conexion.MtdBuscarDataset("Select * from cartera.rangocartera Where Id != 99", FrmLogeo.StrConexion);
        }
        public void MtdListaMeses()
        {
            ListaMes.Clear();
            ListaMes.Add("Enero");
            ListaMes.Add("Febrero");
            ListaMes.Add("Marzo");
            ListaMes.Add("Abril");
            ListaMes.Add("Mayo");
            ListaMes.Add("Junio");
            ListaMes.Add("Julio");
            ListaMes.Add("Agosto");
            ListaMes.Add("Septiembre");
            ListaMes.Add("Octubre");
            ListaMes.Add("Noviembre");
            ListaMes.Add("Diciembre");
        }

        #endregion
        public DataTable MtdCnsPresupuesto(DateTime DtpFechaIni, DateTime DtpFechaFin, String StrConexion)
        {

            FechaInicial = DtpFechaIni;
            FechaFinal = DtpFechaFin;
            DtPresupuesto = conexion.MtdBuscarDataset(RscPresupuesto.PresupuestoGral,  DtpFechaIni, DtpFechaFin);

            return DtPresupuesto;

        }

   

        private void MtdNombreTabla()
        {

            int Mes = FechaFinal.Month;
            int ano = FechaFinal.Year;
            switch (Mes)
            {
                case 1:
                    NomTabla = "PresupuestogeneralEnero" + ano;
                    break;

                case 2:

                    NomTabla = "PresupuestogeneralFebrero" + ano;

                    break;

                case 3:
                    NomTabla = "PresupuestogeneralMarzo" + ano;
                    break;

                case 4:
                    NomTabla = "PresupuestogeneralAbril" + ano;
                    break;
                case 5:
                    NomTabla = "PresupuestogeneralMayo" + ano;
                    break;

                case 6:
                    NomTabla = "PresupuestogeneralJunio" + ano;
                    break;

                case 7:
                    NomTabla = "PresupuestogeneralJulio" + ano;
                    break;

                case 8:
                    NomTabla = "PresupuestogeneralAgosto" + ano;
                    break;

                case 9:
                    NomTabla = "PresupuestogeneralSeptiembre" + ano;
                    break;

                case 10:
                    NomTabla = "PresupuestogeneralOctubre" + ano;
                    break;

                case 11:
                    NomTabla = "PresupuestogeneralNoviembre" + ano;
                    break;

                case 12:
                    NomTabla = "PresupuestogeneralDiciembre" + ano;
                    break;

                default:

                    break;
            }

        }

        private void MtdNombreTabla(int mes, int ano)
        {


            switch (mes)
            {
                case 1:
                    NomTabla = "PresupuestogeneralEnero" + ano;
                    break;

                case 2:

                    NomTabla = "PresupuestogeneralFebrero" + ano;

                    break;

                case 3:
                    NomTabla = "PresupuestogeneralMarzo" + ano;
                    break;

                case 4:
                    NomTabla = "PresupuestogeneralAbril" + ano;
                    break;
                case 5:
                    NomTabla = "PresupuestogeneralMayo" + ano;
                    break;

                case 6:
                    NomTabla = "PresupuestogeneralJunio" + ano;
                    break;

                case 7:
                    NomTabla = "PresupuestogeneralJulio" + ano;
                    break;

                case 8:
                    NomTabla = "PresupuestogeneralAgosto" + ano;
                    break;

                case 9:
                    NomTabla = "PresupuestogeneralSeptiembre" + ano;
                    break;

                case 10:
                    NomTabla = "PresupuestogeneralOctubre" + ano;
                    break;

                case 11:
                    NomTabla = "PresupuestogeneralNoviembre" + ano;
                    break;

                case 12:
                    NomTabla = "PresupuestogeneralDiciembre" + ano;
                    break;

                default:

                    break;
            }

        }
        private void MtdNombreTablaPreliminar()
        {

            int Mes = FechaFinal.Month;
            int ano = FechaFinal.Year;
            switch (Mes)
            {
                case 1:
                    NomTabla = "PresupuestoPreliminarEnero" + ano;
                    break;

                case 2:

                    NomTabla = "PresupuestoPreliminarFebrero" + ano;

                    break;

                case 3:
                    NomTabla = "PresupuestoPreliminarEneroMarzo" + ano;
                    break;

                case 4:
                    NomTabla = "PresupuestoPreliminarAbril" + ano;
                    break;
                case 5:
                    NomTabla = "PresupuestoPreliminarMayo" + ano;
                    break;

                case 6:
                    NomTabla = "PresupuestoPreliminarJunio" + ano;
                    break;

                case 7:
                    NomTabla = "PresupuestoPreliminarJulio" + ano;
                    break;

                case 8:
                    NomTabla = "PresupuestoPreliminarAgosto" + ano;
                    break;

                case 9:
                    NomTabla = "PresupuestoPreliminarSeptiembre" + ano;
                    break;

                case 10:
                    NomTabla = "PresupuestoPreliminarOctubre" + ano;
                    break;

                case 11:
                    NomTabla = "PresupuestoPreliminarNoviembre" + ano;
                    break;

                case 12:
                    NomTabla = "PresupuestoPreliminarDiciembre" + ano;
                    break;

                default:

                    break;
            }

        }

       

        public DataTable MtdCnsCumplimientoPresupuestoMeta(string ano, string mes)
        {

            MtdDatosMes(mes, ano);
            string ok;
            string SentenciaDelPto = "delete from cartera_comercial.presupuestogeneralInfo";
            string SentenciaInsPto = "Insert into cartera_comercial.presupuestogeneralInfo  select * from cartera_comercial. " + TablaPresGral + " where tipoCartera='Administrativa' and Estado='Aprobado' ";
            ok = conexion.MtdAddSentencia(SentenciaDelPto);
            ok = conexion.MtdAddSentencia(SentenciaInsPto);
            return conexion.MtdBuscarDataset(RscPresupuesto.CumplimientoPresupustoMetas, FechaInicial, FechaFinal);
        }


        public DataTable MtdCnsCumplimientoPresupuestoMeta(string ano, string mes, int rango)
        {
            MtdRangoCartera(rango);
            MtdDatosMes(mes, ano);
            string ok;

            string SentenciaDelPto = "delete from cartera_comercial.presupuestogeneralInfo";
            string SentenciaInsPto = "Insert into presupuestogeneralInfo  select * from cartera_comercial. " + TablaPresGral + " where tipoCartera='Administrativa' and Estado='Aprobado' ";

            ok = conexion.MtdAddSentencia(SentenciaDelPto);
            ok = conexion.MtdAddSentencia(SentenciaInsPto);
            return conexion.MtdBuscarDataset(RscPresupuesto.CumplimientoPresupustoMetas + " Where diascpt >= " + Desde + " and diascpt <= " + Hasta,FechaInicial, FechaFinal);
        }
  
        public void MtdRangoCartera(int RangoCart)
        {

            var query = (
            from IdRango in DtRangoCartera.AsEnumerable()
            where IdRango.Field<int>("Id") == RangoCart

            select new
            {
                desde = IdRango.Field<int>("Desde"),
                hasta = IdRango.Field<int>("Hasta")
            });

            foreach (var order in query)
            {
                Desde = order.desde;
                Hasta = order.hasta;
            }
        }


    }
}
