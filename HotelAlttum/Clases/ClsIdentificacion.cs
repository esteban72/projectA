using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using System.Drawing;
namespace CarteraGeneral
{
    class ClsIdentificacion
    {

        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
        string Titulo;
        public void impirmir(GridControl GrdGrilla, string MiTitulo)
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
            imagen = e.Graph.DrawImage(global::CarteraGeneral.Properties.Resources.logo, new RectangleF(10, 0, 150, 50), DevExpress.XtraPrinting.BorderSide.None, Color.Transparent);
            brick.Font = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
            //brick.BackColor = Color.Blue;
            brick.ForeColor = Color.Gray;
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }



        public void impirmir1(GridControl GrdGrilla, string MiTitulo)
        {
            Titulo = MiTitulo;
            PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
            link.Component = GrdGrilla;
            link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea1);
            link.CreateDocument();
            link.ShowPreview();
        }
        private void Link_CreateMarginalHeaderArea1(object sender, CreateAreaEventArgs e)
        {
            DevExpress.XtraPrinting.TextBrick brick;
           
          //  DevExpress.XtraPrinting.ImageBrick imagen;
            brick = e.Graph.DrawString(Titulo, Color.Navy, new RectangleF(2, 5, 455, 80), DevExpress.XtraPrinting.BorderSide.None);
           // imagen = e.Graph.DrawImage(global::CarteraGeneral.Properties.Resources.Logo_del_poblado_02, new RectangleF(10, 0, 150, 50), DevExpress.XtraPrinting.BorderSide.None, Color.Transparent);
            brick.Font = new Font("Arial", 10, System.Drawing.FontStyle.Bold);
            //brick.BackColor = Color.Blue;
            brick.ForeColor = Color.Black;
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Near);
        }



        public string MtdCalculoCuota(double capital, double tasaInteres, double periodo, double plazo,int decimales)
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
                CuotaFijaCalculada = Math.Round((capital / plazo), decimales);

            }
            return Convert.ToString(Math.Round(CuotaFijaCalculada,decimales));
        }

        public DataTable MtdCuotas(double capital, double tasaInteres, int periodo, double plazo,  int decimales,DateTime fechaInicio)
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
                CuotaFijaCalculada = Math.Round(((capital) * (tasaInteres / (periodo * 100)) / x), decimales);
            }

            else
            {
                CuotaFijaCalculada = Math.Round((capital / plazo), decimales);
            }

            double CapitalCuota, InteresCuota, SaldoCuota, CuotaCuota;
            DateTime Fecha;
            SaldoCuota = capital;

            System.Data.DataTable table = new System.Data.DataTable();
            table.Columns.Add("Fecha", typeof(DateTime));
            table.Columns.Add("NumCuota", typeof(int));            
            table.Columns.Add("Capital", typeof(double));
            table.Columns.Add("Interes", typeof(double));
            table.Columns.Add("Cuota", typeof(double));
            table.Columns.Add("Saldo", typeof(double));
            for (int i = 1; i < plazo + 1; i++)
            {
                Fecha = fechaInicio.AddMonths(12 / periodo * (i - 1));
                InteresCuota = Math.Round(((SaldoCuota * (12 / periodo * 30) * tasaInteres) / 36000), decimales);
                CapitalCuota = Math.Round((CuotaFijaCalculada - InteresCuota), decimales);


                if (i == plazo)
                {
                    CuotaCuota = Math.Round((SaldoCuota + InteresCuota), decimales);
                    table.Rows.Add(Fecha, i, SaldoCuota, InteresCuota, CuotaCuota, SaldoCuota);
                    SaldoCuota = 0;
                }
                else
                {
                    CuotaCuota = Math.Round((CapitalCuota + InteresCuota), decimales);
                    SaldoCuota = Math.Round((SaldoCuota - CapitalCuota), decimales);
                    table.Rows.Add(Fecha, i, CapitalCuota, InteresCuota, CuotaCuota, SaldoCuota);
                }
            }

            return table;
        }

//===================================================================================================================================================
// (1)I N I C I O    A D I C I O N A R   M O D I F I C A R   E L I M I N A R
//===================================================================================================================================================
        public string MtdAddSentencia(string Sentencia)
        {
            string Msj;

            MySqlCommand CmdAddSentencia = new MySqlCommand(Sentencia, FrmLogeo.MysqlConexion);
            try
            {
                FrmLogeo.MysqlConexion.Open();
                CmdAddSentencia.ExecuteNonQuery();
                return "OK";
            }

            catch (MySqlException E)
            {
                Msj = E.Message;
                return Msj;
            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }

        }
//===================================================================================================================================================
// (1)F I N A L     A D I C I O N A R   M O D I F I C A R   E L I M I N A R
//===================================================================================================================================================





     public DataTable MtdBuscarDataset(string Sentencia)
     {
         MySqlConnection MysqlConexion = new MySqlConnection();
         MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
         MySqlDataAdapter DtaBuscarDataset = new MySqlDataAdapter();
         DataSet DtsBuscarDataset = new DataSet();
         MySqlCommand cmd = new MySqlCommand(Sentencia, MysqlConexion);
         cmd.CommandTimeout = 0;
         DtaBuscarDataset.SelectCommand = cmd;
         DtsBuscarDataset.Tables.Clear();
  
         try
         {
             DtaBuscarDataset.Fill(DtsBuscarDataset, "BuscarDataset");


             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         catch (Exception e)
         {
             MessageBox.Show("Ha Ocurrido el Sgte Error: " + e.Message + " ", " " + "MtdBuscarDataset", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         finally
         {
             MysqlConexion.Close();
         }
     }

     /// <summary>
     /// Metodo que devuelve consulta mysql en una Tabla
     /// </summary>
     /// <param name="Sentencia"></param>
     /// Sentencia
     /// <param name="VarConexion"></param>
     /// Parametro 1 String
     /// <param name="Parametro1"></param>
     /// <returns></returns>
     public DataTable MtdBuscarDataset(string Sentencia, string Parametro1)
     {
         MySqlConnection MysqlConexion = new MySqlConnection();
         MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
         MySqlDataAdapter DtaBuscarDataset = new MySqlDataAdapter();
         DataSet DtsBuscarDataset = new DataSet();

         MySqlCommand cmd = new MySqlCommand(Sentencia, MysqlConexion);

         cmd.Parameters.Add("@Parametro1", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = Parametro1;

         DtaBuscarDataset.SelectCommand = cmd;
         DtsBuscarDataset.Tables.Clear();

         try
         {
             DtaBuscarDataset.Fill(DtsBuscarDataset, "BuscarDataset");
             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         catch (Exception e)
         {
             MessageBox.Show("Ha Ocurrido el Sgte Error: " + e.Message + " ", " " + "MtdBuscarDataset", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         finally
         {
             //MysqlConexion.Close();

         }
     }


     public DataTable MtdBuscarDataset(string Sentencia, string IdAdjudicacion,decimal Mora)
     {
         MySqlConnection MysqlConexion = new MySqlConnection();
         MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
         MySqlDataAdapter DtaBuscarDataset = new MySqlDataAdapter();
         DataSet DtsBuscarDataset = new DataSet();

         MySqlCommand cmd = new MySqlCommand(Sentencia, MysqlConexion);

         cmd.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = IdAdjudicacion;
         cmd.Parameters.Add("@Mora", MySql.Data.MySqlClient.MySqlDbType.Decimal).Value = Mora;

         DtaBuscarDataset.SelectCommand = cmd;
         DtsBuscarDataset.Tables.Clear();

         try
         {
             DtaBuscarDataset.Fill(DtsBuscarDataset, "BuscarDataset");
             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         catch (Exception e)
         {
             MessageBox.Show("Ha Ocurrido el Sgte Error: " + e.Message + " ", " " + "MtdBuscarDataset", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         finally
         {
             //MysqlConexion.Close();

         }
     }

     public DataTable MtdBuscarDataset(string Sentencia, DateTime Fecha)
     {
         MySqlConnection MysqlConexion = new MySqlConnection();
         MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
         MySqlDataAdapter DtaBuscarDataset = new MySqlDataAdapter();
         DataSet DtsBuscarDataset = new DataSet();

         MySqlCommand cmd = new MySqlCommand(Sentencia, MysqlConexion);

         cmd.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = Fecha;

         DtaBuscarDataset.SelectCommand = cmd;
         DtsBuscarDataset.Tables.Clear();

         try
         {
             DtaBuscarDataset.Fill(DtsBuscarDataset, "BuscarDataset");
             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         catch (Exception e)
         {
             MessageBox.Show("Ha Ocurrido el Sgte Error: " + e.Message + " ", " " + "MtdBuscarDataset", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         finally
         {
             //MysqlConexion.Close();

         }
     }

     public DataTable MtdBuscarDataset(string Sentencia, DateTime FechaInicial,DateTime FechaFinal)
     {
         MySqlConnection MysqlConexion = new MySqlConnection();
         MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
         MySqlDataAdapter DtaBuscarDataset = new MySqlDataAdapter();
         DataSet DtsBuscarDataset = new DataSet();

         MySqlCommand cmd = new MySqlCommand(Sentencia, MysqlConexion);

         cmd.Parameters.Add("@FechaInicial", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = FechaInicial;
         cmd.Parameters.Add("@FechaFinal", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = FechaFinal;

         DtaBuscarDataset.SelectCommand = cmd;
         DtsBuscarDataset.Tables.Clear();

         try
         {
             DtaBuscarDataset.Fill(DtsBuscarDataset, "BuscarDataset");
             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         catch (Exception e)
         {
             MessageBox.Show("Ha Ocurrido el Sgte Error: " + e.Message + " ", " " + "MtdBuscarDataset", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return DtsBuscarDataset.Tables[("BuscarDataset")];
         }
         finally
         {
             //MysqlConexion.Close();

         }
     }



//===================================================================================================================================================
// (12)I N I C I O  M E T O D O   B U S C A R   P E R M I S O S   P O R   L I S T A S 
//===================================================================================================================================================
     public List<string> MtdListaCuenta(string Cuenta)
     {
         string StrTexto = "Select Descripcion,Terceros,CCosto,BaseMin,Porcentaje from  puc where Codigo = '" + Cuenta + "'";
         MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
         List<string> ListaBscPer = new List<string>();
         MySqlCommand CmdListaBscPer = new MySqlCommand(StrTexto, MysqlConexion);
         MySqlDataReader DrdListaBscPer;
         MysqlConexion.Open();

         DrdListaBscPer = CmdListaBscPer.ExecuteReader();
         while (DrdListaBscPer.Read())
         {
             ListaBscPer.Add(DrdListaBscPer["Descripcion"].ToString());
             ListaBscPer.Add(DrdListaBscPer["Terceros"].ToString());
             ListaBscPer.Add(DrdListaBscPer["CCosto"].ToString());
             ListaBscPer.Add(DrdListaBscPer["BaseMin"].ToString());
             ListaBscPer.Add(DrdListaBscPer["Porcentaje"].ToString());

         }
         MysqlConexion.Close();
         return ListaBscPer;
     }
//===================================================================================================================================================
// (12)F I N   M E T O D O   B U S C A R   P E R M I S O S   P O R   L I S T A S 
//===================================================================================================================================================


        
    

//===================================================================================================================================================
//(3) I N I C I O  M E T O D O   B U S C A R   D A T O S
//===================================================================================================================================================
        public string MtdBscDatos(string Sentencia)
        {
            string Msj;
            try
            {
                MysqlConexion.Open();
                MySqlCommand CmdBscTerNom = new MySqlCommand(Sentencia, MysqlConexion);
                CmdBscTerNom.Connection = MysqlConexion;
                object result = CmdBscTerNom.ExecuteScalar();
                return Convert.ToString(result);
            }
            catch (Exception x)
            {
               Msj = x.Message;
                return Msj;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }
//===================================================================================================================================================
//(3) F I N A L   M  E T O D O   B U S C A R   D A T O S
//===================================================================================================================================================

        public string MtdBscDatos(string Sentencia,string IdAdjudicacion)
        {


            string Msj;
            try
            {
                MysqlConexion.Open();
                MySqlCommand CmdBscTerNom = new MySqlCommand(Sentencia, MysqlConexion);
                CmdBscTerNom.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = IdAdjudicacion;
                CmdBscTerNom.Connection = MysqlConexion;
                object result = CmdBscTerNom.ExecuteScalar();
                return Convert.ToString(result);
            }
            catch (Exception x)
            {
               Msj = x.Message;
                return Msj;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }

        public string MtdBscDatos(string Sentencia, DateTime fecha)
        {


            string Msj;
            try
            {
                MysqlConexion.Open();
                MySqlCommand CmdBscTerNom = new MySqlCommand(Sentencia, MysqlConexion);
                CmdBscTerNom.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = fecha;
                CmdBscTerNom.Connection = MysqlConexion;
                object result = CmdBscTerNom.ExecuteScalar();
                return Convert.ToString(result);
            }
            catch (Exception x)
            {
                Msj = x.Message;
                return Msj;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }
//===================================================================================================================================================
//(4) I N I C I O   V A L I D A R   F E C H A  P E D I D A 
//===================================================================================================================================================
        public string MtdVldFchPed(DateTime fecha)
        {
            string ano, mes, dia, Varfecha;
            ano = Convert.ToString(fecha.Year);
            mes = Convert.ToString(fecha.Month);
            dia = Convert.ToString(fecha.Day);
            Varfecha = ano + "-" + mes + "-" + dia;
            return Varfecha;
        }
//===================================================================================================================================================
//(4)F I N A L     V A L I D A R   F E C H A  P E D I D A 
//===================================================================================================================================================




//===================================================================================================================================================
//(5) I N I C I O     V A L I D A R  F E C H A
//===================================================================================================================================================
       public string MtdVldFch()
        {
            string año, mes, dia, fecha;
            año = Convert.ToString(DateTime.Now.Year);
            mes = Convert.ToString(DateTime.Now.Month);
            dia = Convert.ToString(DateTime.Now.Day);
            fecha = año + "-" + mes + "-" + dia;
            return fecha;
        }
//===================================================================================================================================================
//(5)F I N A L       V A L I D A R  F E C H A
//===================================================================================================================================================




//===================================================================================================================================================
//(6)I N I C I O   B U S C A R    N O M B R E S   P O R   I D T E R C E R O
//===================================================================================================================================================
       public string MtdBscNombres(string IdTercero)
       {
           string StrTexto = "select NombreCompleto from Contabilidad_alttum.Terceros where Idtercero = " + "'" + IdTercero + "'";

           string Msj;

           try
           {
               MysqlConexion.Open();
               MySqlCommand CmdBscNombres = new MySqlCommand(StrTexto, MysqlConexion);
               CmdBscNombres.Connection = MysqlConexion;
               object result = CmdBscNombres.ExecuteScalar();
               return Convert.ToString(result);
           }


           catch (Exception x)
           {
               Msj = x.Message;
               return "No Existe Tercero";
           }

           finally
           {
               MysqlConexion.Close();
           }
       }
//===================================================================================================================================================
//(6) F I N    B U S C A R    N O M B R E S   P O R  I D T E R C E R O
//===================================================================================================================================================




//===================================================================================================================================================
// (7)I N I C I O   M E T  O D  O  C O N T A R   F O R M U L A R I O  I D F O R M  U L A R I O 
//===================================================================================================================================================
       public bool MtdBscFrmIdFrm(string Campo, string IdUsuario, string IdFormulario)
       {
           string Msj1;
           string SqlBscFrmIdFrm = "SELECT " + Campo + " from permisos  where IdUsuario  = " + "'" + IdUsuario + "' and Modulo = " +  IdFormulario ;
           try
           {
               FrmLogeo.MysqlConexion.Open();
               MySqlCommand CmdBscFrmIdFrm = new MySqlCommand(SqlBscFrmIdFrm, FrmLogeo.MysqlConexion);

               object result = CmdBscFrmIdFrm.ExecuteScalar();
               return Convert.ToBoolean(result);
           }
           catch (Exception E)
           {
               Msj1 = E.Message;
               return false;
           }
           finally
           {
               FrmLogeo.MysqlConexion.Close();
           }
       }
//===================================================================================================================================================
// (7)F I N   M E T  O D  O    C O N T A R F O R M U L A R I O     I D F O R M U  L A R I O 
//===================================================================================================================================================




//===================================================================================================================================================
//(8) I N I C I O   L I S T A D O   D E   P R O Y E C T O S
//===================================================================================================================================================
       public List<string> MtdListaPro()
       {
           List<string> ListaPro = new List<string>();
           MySqlCommand CmdListaPro = new MySqlCommand("Select * from proyectos", FrmLogeo.MysqlConexion);
           MySqlDataReader DrdListaPro;
           FrmLogeo.MysqlConexion.Open();
           DrdListaPro = CmdListaPro.ExecuteReader();
           while (DrdListaPro.Read())
           {
               ListaPro.Add(DrdListaPro["IdProyecto"].ToString());
           }
           FrmLogeo.MysqlConexion.Close();
           return ListaPro;
       }
//===================================================================================================================================================
//(8)F I N A L      L I S T A D O   D E   P R O Y E C T O S
//===================================================================================================================================================



//===================================================================================================================================================
//(9)I N I C I O  M E T O D O   B U S C A R   U S U A R I O    P O R   L I S T  A
//===================================================================================================================================================
       public List<string> MtdListaBscUsr(string IdUsuario)
       {
           List<string> ListaBscUsr = new List<string>();
           string StrTexto = "Select NombreUsuario,Clave from Usuario where IdUsuario =" + "'" + IdUsuario + "'";
           MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
           MySqlCommand CmdListaBscUsr = new MySqlCommand(StrTexto, FrmLogeo.MysqlConexion);
           MySqlDataReader DrdListaBscUsr;
           FrmLogeo.MysqlConexion.Open();
           DrdListaBscUsr = CmdListaBscUsr.ExecuteReader();
           while (DrdListaBscUsr.Read())
           {
               ListaBscUsr.Add(DrdListaBscUsr["NombreUsuario"].ToString());
               ListaBscUsr.Add(DrdListaBscUsr["Clave"].ToString());
           }
           FrmLogeo.MysqlConexion.Close();
           return ListaBscUsr;
       }
//===================================================================================================================================================
//(9)F I N A L   M E T O D O   B U S C A R   U S U A R I O    P O R   L I S T  A
//===================================================================================================================================================



//===================================================================================================================================================
// (10) I N I C I O   B U S C A R  C A M P O S
//===================================================================================================================================================
       public List<string> MtdBscCampos(string Tabla, string Campo)
       {
           List<string> listaBscCampos = new List<string>();
           MySql.Data.MySqlClient.MySqlCommand CmdBscCsc = new MySql.Data.MySqlClient.MySqlCommand("describe" + " " + Tabla, MysqlConexion);
           MySql.Data.MySqlClient.MySqlDataReader DrdBscCsc;
           MysqlConexion.Open();
           DrdBscCsc = CmdBscCsc.ExecuteReader();

           while (DrdBscCsc.Read())
           {
               listaBscCampos.Add(DrdBscCsc[Campo].ToString());
           }
           MysqlConexion.Close();
           return listaBscCampos;
       }
//===================================================================================================================================================
// (10)F I N     B U S C A R  C A M P O S
//===================================================================================================================================================



//===================================================================================================================================================
//(11) I N I C I O   L I S T A D O   D E   P R O Y E C T O S
//===================================================================================================================================================
       public List<string> MtdListaCampos(string Tabla, string Campo)
       {

           List<string> ListaZonas = new List<string>();
           MySqlCommand CmdListaPro = new MySqlCommand("Select " + Campo+ " from " + Tabla + " order by  " + Campo, MysqlConexion);
           MySqlDataReader DrdListaPro;
           MysqlConexion.Open();
           DrdListaPro = CmdListaPro.ExecuteReader();
           while (DrdListaPro.Read())
           {
               ListaZonas.Add(DrdListaPro[Campo].ToString());
           }
           MysqlConexion.Close();
           return ListaZonas;
       }
//===================================================================================================================================================
//(11)F I N A L   L I S T A D O   D E P R O Y E C T O S
//===================================================================================================================================================



//===================================================================================================================================================
//(11) I N I C I O   L I S T A D O   D E   P R O Y E C T O S
//===================================================================================================================================================
       public List<string> MtdListaCamposSent(string Sentencia,string Campo)
       {

           List<string> ListaZonas = new List<string>();
           MySqlCommand CmdListaPro = new MySqlCommand(Sentencia , MysqlConexion);
           MySqlDataReader DrdListaPro;
           MysqlConexion.Open();
           DrdListaPro = CmdListaPro.ExecuteReader();
           while (DrdListaPro.Read())
           {
               ListaZonas.Add(DrdListaPro[Campo].ToString());
           }
           MysqlConexion.Close();
           return ListaZonas;
       }
//===================================================================================================================================================
//(11)F I N A L   L I S T A D O   D E P R O Y E C T O S
//===================================================================================================================================================



//===================================================================================================================================================
// (12)I N I C I O  M E T O D O   B U S C A R   P E R M I S O S   P O R   L I S T A S 
//===================================================================================================================================================
       public List<string> MtdListaBscPer(string IdUsuario, string IdFormulario)
       {
           string StrTexto = "Select Ver,Adicionar,Modificar,Eliminar from permisos where IdUsuario = '" + IdUsuario + "' and IdFormulario = '" + IdFormulario + "'";
           MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
           List<string> ListaBscPer = new List<string>();
           MySqlCommand CmdListaBscPer = new MySqlCommand(StrTexto, FrmLogeo.MysqlConexion);
           MySqlDataReader DrdListaBscPer;
           FrmLogeo.MysqlConexion.Open();

           DrdListaBscPer = CmdListaBscPer.ExecuteReader();
           while (DrdListaBscPer.Read())
           {
               ListaBscPer.Add(DrdListaBscPer["Ver"].ToString());
               ListaBscPer.Add(DrdListaBscPer["Adicionar"].ToString());
               ListaBscPer.Add(DrdListaBscPer["Modificar"].ToString());
               ListaBscPer.Add(DrdListaBscPer["Eliminar"].ToString());
           }
           FrmLogeo.MysqlConexion.Close();
           return ListaBscPer;
       }
//===================================================================================================================================================
// (12)F I N   M E T O D O   B U S C A R   P E R M I S O S   P O R   L I S T A S 
//===================================================================================================================================================



//===================================================================================================================================================
// (13)I N I C I O    L I S T A    I N M U E B L E S     P O R  I D    I N M U E B L E S
//===================================================================================================================================================
       public List<string> MtdListaInmIdInm(string IdInmueble)
       {
           List<string> ListaInmIdInm = new List<string>();
           MySqlCommand CmdInmIdInm = new MySqlCommand("select * from inmuebles where IdInmueble ='" + IdInmueble + "'", MysqlConexion);
           MySqlDataReader DrdListaInmIdInm;
           MysqlConexion.Open();
           DrdListaInmIdInm = CmdInmIdInm.ExecuteReader();

           while (DrdListaInmIdInm.Read())
           {
               ListaInmIdInm.Add(DrdListaInmIdInm["ManzanaNumero"].ToString());
               ListaInmIdInm.Add(DrdListaInmIdInm["LoteNumero"].ToString());
               ListaInmIdInm.Add(DrdListaInmIdInm["IdProyecto"].ToString());
           }
           MysqlConexion.Close();
           return ListaInmIdInm;
       }
//===================================================================================================================================================
//(13)F I N     L I S T A    I N M U E B L E S     P O R  I D    I N M U E B L E S
//===================================================================================================================================================


//===================================================================================================================================================
//(14) I N  I C I O   A D I C I O N A R   D A T O S   R E C A U D O S   P O R   P R O C E D I M I E N T O S 
//===================================================================================================================================================
       public string MtdAddDtsRcdPrc(string IdRecaudo,
                                   string IdAdjudicacion,
                                   string Fecha,
                                   string NumRecibo,
                                   string IdTercero,
                                   string Operacion,
                                   double Efectivo,
                                   double Cheque,
                                   string CodBanco,
                                   double TarjetaDebito,
                                   string BancoTDb,
                                   double TarjetaCredito,
                                   string BancoTCr,
                                   double Transferencia,
                                   string BancoTrf,
                                   double Otros,
                                   string DatosOtros,
                                   double ChequeGerencia,
                                   string BancoChequeGer,
                                   int VarConsecutivo,
                                   string Usuario,
                                   string FechaOperacion)
       {


           MySqlCommand CmdAddDtsRcd;

           CmdAddDtsRcd = new MySqlCommand();

           CmdAddDtsRcd.CommandType = CommandType.StoredProcedure;
           CmdAddDtsRcd.CommandText = "AddRecaudos";
           CmdAddDtsRcd.Connection = MysqlConexion;


           string Msj;

           CmdAddDtsRcd.Parameters.Add("IdRecaudo", MySqlDbType.VarChar);
           CmdAddDtsRcd.Parameters.Add("IdAdjudicacion", MySqlDbType.VarChar);
           CmdAddDtsRcd.Parameters.Add("Fecha", MySqlDbType.DateTime);
           CmdAddDtsRcd.Parameters.Add("NumRecibo", MySqlDbType.VarChar);

           CmdAddDtsRcd.Parameters.Add("IdTercero", MySqlDbType.VarChar);
           CmdAddDtsRcd.Parameters.Add("Operacion", MySqlDbType.VarChar);

           CmdAddDtsRcd.Parameters.Add("Efectivo", MySqlDbType.Double);

           CmdAddDtsRcd.Parameters.Add("Cheque", MySqlDbType.Double);
           CmdAddDtsRcd.Parameters.Add("CodBanco", MySqlDbType.VarChar);

           CmdAddDtsRcd.Parameters.Add("TarjetaDebito", MySqlDbType.Double);
           CmdAddDtsRcd.Parameters.Add("BancoTDb", MySqlDbType.VarChar);

           CmdAddDtsRcd.Parameters.Add("TarjetaCredito", MySqlDbType.Double);
           CmdAddDtsRcd.Parameters.Add("BancoTCr", MySqlDbType.VarChar);

           CmdAddDtsRcd.Parameters.Add("Transferencia", MySqlDbType.Double);
           CmdAddDtsRcd.Parameters.Add("BancoTrf", MySqlDbType.VarChar);


           CmdAddDtsRcd.Parameters.Add("Otros", MySqlDbType.Decimal);
           CmdAddDtsRcd.Parameters.Add("DatosOtros", MySqlDbType.VarChar);
           CmdAddDtsRcd.Parameters.Add("ChequeGer", MySqlDbType.Decimal);
           CmdAddDtsRcd.Parameters.Add("BancoChequeGer", MySqlDbType.VarChar);

           CmdAddDtsRcd.Parameters.Add("VarConsecutivo", MySqlDbType.Int16);

           CmdAddDtsRcd.Parameters.Add("Usuario", MySqlDbType.VarChar);
           CmdAddDtsRcd.Parameters.Add("FechaOperacion", MySqlDbType.DateTime);


           CmdAddDtsRcd.Parameters["IdRecaudo"].Value = IdRecaudo;
           CmdAddDtsRcd.Parameters["IdAdjudicacion"].Value = IdAdjudicacion;
           CmdAddDtsRcd.Parameters["Fecha"].Value = Fecha;
           CmdAddDtsRcd.Parameters["NumRecibo"].Value = NumRecibo;
           CmdAddDtsRcd.Parameters["IdTercero"].Value = IdTercero;
           CmdAddDtsRcd.Parameters["Operacion"].Value = Operacion;
           CmdAddDtsRcd.Parameters["Efectivo"].Value = Efectivo;
           CmdAddDtsRcd.Parameters["Cheque"].Value = Cheque;
           CmdAddDtsRcd.Parameters["CodBanco"].Value = CodBanco;
           CmdAddDtsRcd.Parameters["TarjetaDebito"].Value = TarjetaDebito;
           CmdAddDtsRcd.Parameters["BancoTDb"].Value = BancoTDb;
           CmdAddDtsRcd.Parameters["TarjetaCredito"].Value = TarjetaCredito;
           CmdAddDtsRcd.Parameters["BancoTCr"].Value = BancoTCr;
           CmdAddDtsRcd.Parameters["Transferencia"].Value = Transferencia;
           CmdAddDtsRcd.Parameters["BancoTrf"].Value = BancoTrf;
           CmdAddDtsRcd.Parameters["Otros"].Value = Otros;
           CmdAddDtsRcd.Parameters["DatosOtros"].Value = DatosOtros;
           CmdAddDtsRcd.Parameters["ChequeGer"].Value = ChequeGerencia;
           CmdAddDtsRcd.Parameters["BancoChequeGer"].Value = BancoChequeGer;

           CmdAddDtsRcd.Parameters["VarConsecutivo"].Value = VarConsecutivo;


           CmdAddDtsRcd.Parameters["Usuario"].Value = Usuario;
           CmdAddDtsRcd.Parameters["FechaOperacion"].Value = FechaOperacion;

           try
           {
               MysqlConexion.Open();
               CmdAddDtsRcd.ExecuteNonQuery();
               return "OK";
           }
           catch (Exception x)
           {
               Msj = x.Message;
               return Msj;
           }

           finally
           {
               MysqlConexion.Close();
           }
       }
//===================================================================================================================================================
//(14) F I  N A L   A D I C I O N A R   D A T O S   R E C A U D O S   P O R   P R O C E D I M I E N T O S 
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   M E T O D O   S C R I P
//===================================================================================================================================================
       public  string Mtdscrip(DateTime DtpFechaCorte,DateTime DtpFechaFin)
       {

       string     FechaCorte = "'" + MtdVldFchPed(DtpFechaCorte) + "'";
       string FechaFinal = "'" + MtdVldFchPed(DtpFechaFin) + "'";
        string    SentenciaPrs =
             "select " +
             "Car.CuotaNum, " +
             "Car.Fecha, " +
             "Car.IdAdjudicacion, " +
             "Car.FechaRec as UltPago," +
             "tipo.Cliente as Cliente, " +
             "Car.Concepto, " +
             "Car.Capital, " +
             "Car.Interes, " +
             "Car.Cuota, " +
             "Car.DiasCpt, " +
             "Car.Diaslqd, " +
             "Car.Mora, " +
             "tipo.TipoCartera  " +

             " from " +
               " ( " +
               "SELECT " +
               "rr.Id, " +
               "rr.Idadjudicacion, " +
               "rr.Concepto, " +
               "rr.CuotaNum, " +
               " Max(rr.Fecha)Fecha, " +
               "if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec))FechaRec, " +
               "sum(rr.Capital)Capital, " +
               "sum(rr.Interes)Interes, " +
               "sum(rr.cuota)Cuota, " +
               " if(DATEDIFF(" + FechaCorte + ",rr.fecha)<=0,0, DATEDIFF(" + FechaCorte + ",rr.fecha))DiasCpt,  " +
               "sum(rr.SaldointeMora)SaldoInteMora," +
               "if((rr.Fecha > max(rr.fechaRec)), (if(DATEDIFF(" + FechaCorte + ",rr.fecha)<=0,0, DATEDIFF(" + FechaCorte + ",rr.fecha))), " +
               "(if(DATEDIFF(" + FechaCorte + ",if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec)))<=0,0, DATEDIFF(" + FechaCorte + ",if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec))))))DiasLqd, " +
               "if(rr.concepto='CI',0,round((sum(rr.cuota) * " +
               "if((rr.Fecha > max(rr.fechaRec)), (if(DATEDIFF(" + FechaCorte + ",rr.fecha)<=0,0, DATEDIFF(" + FechaCorte + ",rr.fecha))), " +
               "(if(DATEDIFF(" + FechaCorte + ",if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec)))<=0,0, DATEDIFF(" + FechaCorte + ",if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec))))))" +
               "*" + FrmMenuGeneral.Mora + ")/36000,2)) Mora, " +
               " rr.tipo " +
               "from " +

               //Region rr
           #region rr

               "( " +

               "SELECT IdCta AS Id," +
               "f.IdAdjudicacion ," +
               "Concepto AS Concepto," +
               "f.NumCuota CuotaNum ," +
               "f.Fecha ," +
               "null FechaRec," +
               "f.Capital ," +
               "f.Interes AS Interes  ," +
               "f.Cuota," +
               "0 AS InteresMora," +
               "0 AS InteresCnd," +
               "0 AS MoraCalc," +
               "0 SaldoInteMora," +
               "'Cta' as Tipo " +
               "FROM financiacion f " +
               "WHERE F.Fecha <= " + FechaFinal + 

              


               "UNION " +

               "SELECT " +
               "IdFinanciacion AS Id, " +
               "r.IdAdjudicacion , " +
               "r.Concepto AS concepto, " +
               "r.NumCuota AS CuotaNum, " +
               "null fecha, " +
               "r.Fecha FechaRec, " +
               "Sum(-r.Capital) AS Capital, " +
               "Sum(-r.InteresCte) AS InteresCte, " +
               "sum(-(r.Capital) - r.InteresCte) AS Cuota, " +
               "sum(-r.InteresMora) AS InteresMora, " +
               "sum(r.InteresCnd) AS InteresCnd, " +
               "sum(r.VrMoraCalc) AS MoraCalc, " +
               "sum((r.VrMoraCalc - r.InteresCnd) - r.InteresMora) AS SaldoIntMora, " +
               "'Rcd' as Tipo " +
               "FROM recaudos r " +
               "where r.Estado = 'Aprobado' and r.Fecha <= " + FechaCorte + " group by id " +
               " UNION " +

                "SELECT IdFinanciacion AS Id, " +
               "d.IdAdjudicacion AS IdAdjudicacion, " +
               "d.Concepto AS concepto, " +
               "d.NumCuota AS CuotaNum, " +
               "null Fecha, " +
               "d.Fecha AS FechaRec, " +
               "sum(-d.Capital) AS Capital, " +
               "sum(-d.Interes) AS InteresCte, " +
               "sum(-d.Cuota) as Cuota, " +
               "0 AS InteresMora, " +
               "0 AS InteresCnd, " +
               "0 AS MoraCalc, " +
               "0 AS SaldoInteMora, " +
               "'Dto' as Tipo " +
               "FROM descuento d " +
               "where   d.Fecha <= " + FechaCorte + " group by id " +
               "UNION " +



               "SELECT IdFinanciacion AS Id, " +
               "d.IdAdjudicacion AS IdAdjudicacion, " +
               "d.Concepto AS concepto, " +
               "d.NumCuota AS CuotaNum, " +
               "null Fecha, " +
               "d.Fecha AS FechaRec, " +
               "sum(-d.Capital) AS Capital, " +
               "sum(-d.Interes) AS InteresCte, " +
               "sum(-d.Cuota) as Cuota, " +
               "0 AS InteresMora, " +
               "0 AS InteresCnd, " +
               "0 AS MoraCalc, " +
               "0 AS SaldoInteMora, " +
               "'Can' as Tipo " +
               "FROM Canje d " +
                "where   d.Fecha <= " + FechaCorte + " group by id " +

               ")RR " +
               "group by rr.id " +
           #endregion
               //Region rr

              ")Car " +


               "join " +


           #region Tipo

        "( " +
            " SELECT a.IdAdjudicacion,a.Cliente,a.Estado, if((sum(a.Valor) > 0),'Comercial','Administrativa') AS TipoCartera " +
            "FROM " + 
            "( " +
            " select b.IdAdjudicacion,b.Identificacion as Cliente,b.Estado,b.BaseInicial Valor FROM 004cnsadjudicainicial b "+
            " UNION " +
            " SELECT r.IdAdjudicacion,''Cliente,'' Estado, sum(-r.Capital)Valor FROM recaudos r " +
            " where r.estado ='Aprobado' and r.concepto = 'ci' AND R.fecha<= " + FechaCorte  +
            " group by r.idadjudicacion "+
            ")a " +
            " GROUP BY a.idadjudicacion " +
            ")Tipo " +

           #endregion


 " on tipo.idadjudicacion=car.IdAdjudicacion " ;

           return SentenciaPrs;
       }
//===================================================================================================================================================
//F I N AL  M E T O D O   S C R I P
//===================================================================================================================================================






//===================================================================================================================================================
//I N I C I O   M E T O D O   S C R I P     R E C A U D O S
//===================================================================================================================================================
       public string MtdNuevoScripRecaudo(string Adjudicacion,decimal Mora,int Decimales)
       {
          string  SentenciaPrs=
                  "select  " +
                  " Car.IdAdjudicacion,  " +
                  " Car.Concepto,  " +
                  " Car.CuotaNum,  " +
                  " Car.Fecha,  " +
                  " Car.Capital as SdoCapital,  " +
                  " Car.Interes as SdoInteresCte, " +
                  " Car.Cuota as SdoCuota,  " +
                  " Car.FechaRec as FechaUltPago, " +
                  " Car.SaldoInteMora as IntMoraPdte, " +
                  " Car.Mora as IntMoraLq, " +
                  " (Car.SaldoInteMora+Car.Mora)VrMora," +
                  " Car.Diaslqd as DiasMoraLq,  " +
                  " Car.DiasCpt as DiasMoraCpt,  " +
                 "  (Car.Mora+Car.SaldoInteMora) as IntMoralq,  " +
                  "  if((Cn.Condonacion +Car.InteresCnd) is null,0,(Cn.Condonacion +Car.InteresCnd)) as Condonacion,  " +
                   " (Car.Cuota+Car.Mora+Car.SaldoInteMora-if((Cn.Condonacion +Car.InteresCnd) is null,0,(Cn.Condonacion +Car.InteresCnd))) as TotalCuota,  " +


                  " tipo.TipoCartera " +

                   " from  " +
                    "  (  " +
                    " SELECT  " +
                    " rr.Id,  " +
                    " rr.Idadjudicacion,  " +
                    " rr.Concepto,  " +
                    " rr.CuotaNum,  " +
                    "  Max(rr.Fecha)Fecha,  " +
                    " if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec))FechaRec,   " +
                    " sum(rr.Capital)Capital,   " +
                    " sum(rr.Interes)Interes,   " +
                    " sum(rr.cuota)Cuota,   " +
                     " if(DATEDIFF( curdate(),rr.fecha)<=0,0, DATEDIFF( curdate() ,rr.fecha))DiasCpt,   " +
                    " sum(rr.SaldointeMora)SaldoInteMora,  " +
                    "  sum(rr.InteresCnd)InteresCnd,  " +
                    " if((rr.Fecha > max(rr.fechaRec)), (if(DATEDIFF( curdate() ,rr.fecha)<=0,0, DATEDIFF( curdate() ,rr.fecha))),   " +
                    " (if(DATEDIFF( curdate() ,if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec)))<=0,0, DATEDIFF( curdate() ,if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec))))))DiasLqd,   " +
                    " if((rr.concepto='CI')or (rr.concepto='GA'),0,round((sum(rr.cuota) *   " +
                    " if((rr.Fecha > max(rr.fechaRec)), (if(DATEDIFF( curdate() ,rr.fecha)<=0,0, DATEDIFF( curdate(),rr.fecha))),   " +
                    " (if(DATEDIFF( curdate() ,if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec)))<=0,0, DATEDIFF( curdate() ,if(Max(rr.FechaRec)is null,rr.Fecha,Max(rr.FechaRec)))))) " +
                    " * "+Mora+" )/36000,"+Decimales+")) Mora,   " +
                     " rr.tipo   " +
                    " from   " +


                   "  (  " +

                    " SELECT IdCta AS Id, " +
                    " f.IdAdjudicacion ,  " +
                    "  Concepto, " +
                    " f.NumCuota AS CuotaNum ,  " +
                    " f.Fecha ,  " +
                    " UltimaFechaPago FechaRec,  " +
                    " f.Capital , " +
                    " f.Interes AS Interes  , " +
                    " f.Cuota,  " +
                    " 0 AS InteresMora,  " +
                    " 0 AS InteresCnd,  " +
                    " 0 AS MoraCalc, " +
                    " 0 SaldoInteMora, " +
                    " 'Cta' as Tipo   " +
                    " FROM financiacion f   " +


                    " UNION  " +

                    " SELECT   " +
                    " IdFinanciacion AS Id,   " +
                    " r.IdAdjudicacion ,   " +
                    " r.Concepto AS concepto," +
                    " r.NumCuota AS CuotaNum,  " +
                    " null fecha,   " +
                    " Max(r.Fecha) FechaRec,   " +
                    " Sum(-r.Capital) AS Capital," +
                    " Sum(-r.InteresCte) AS InteresCte,   " +
                    " sum(-(r.Capital) - r.InteresCte) AS Cuota,   " +
                    " sum(-r.InteresMora) AS InteresMora,  " +
                    " sum(-r.InteresCnd) AS InteresCnd,   " +
                    " sum(r.VrMoraCalc) AS MoraCalc,   " +
                    " sum((r.VrMoraCalc - r.InteresCnd) - r.InteresMora) AS SaldoIntMora,   " +
                    " 'Rcd' as Tipo  " +
                    " FROM recaudos r  " +
                    " where r.Estado != 'Devuelto'  group by IdFinanciacion  " +


                     " UNION " +

                   "   SELECT  IdFinanciacion Id,   " +
                    " d.IdAdjudicacion AS IdAdjudicacion,   " +
                    " d.Concepto AS concepto,   " +
                    " d.NumCuota AS CuotaNum,   " +
                    " null Fecha,   " +
                    " d.Fecha AS FechaRec,   " +
                    " sum(-d.Capital) AS Capital,  " +
                    " sum(-d.Interes) AS InteresCte, " +
                    " sum(-d.Cuota) as Cuota,   " +
                    " 0 AS InteresMora,   " +
                    " 0 AS InteresCnd,   " +
                    " 0 AS MoraCalc,   " +
                    " 0 AS SaldoInteMora," +
                    " 'Dto' as Tipo  " +
                    " FROM descuento d " +
                     "     group by d.IdFinanciacion   " +
                    " UNION   " +



                   "  SELECT IdFinanciacion Id,   " +
                    " d.IdAdjudicacion AS IdAdjudicacion," +
                    " d.Concepto AS concepto,  " +
                    " d.NumCuota AS CuotaNum,  " +
                    " null Fecha,   " +
                    " d.Fecha AS FechaRec," +
                    " sum(-d.Capital) AS Capital, " +
                    " sum(-d.Interes) AS InteresCte," +
                    " sum(-d.Cuota) as Cuota,   " +
                    " 0 AS InteresMora,  " +
                    " 0 AS InteresCnd,  " +
                    " 0 AS MoraCalc,   " +
                    " 0 AS SaldoInteMora,   " +
                    " 'Can' as Tipo   " +
                    " FROM Canje d  " +
                    "  group by id   " +

                    " )RR   " +
                    " group by rr.id   " +


                   " )Car   " +


                   "  join   " +




                    "(   " +
                    " select IdAdjudicacion, if((sum(ss.Cuota) <= 0),'Administrativa','Comercial') AS TipoCartera   " +
                   "  from   " +
                    " (   " +
                    " SELECT IdCta AS Id, " +
                    " f.IdAdjudicacion ,  " +
                    "  Concepto, " +
                    " f.NumCuota AS CuotaNum ,  " +
                    " f.Fecha ,  " +
                    " UltimaFechaPago FechaRec,  " +
                    " f.Capital , " +
                    " f.Interes AS Interes  , " +
                    " f.Cuota,  " +
                    " 0 AS InteresMora,  " +
                    " 0 AS InteresCnd,  " +
                    " 0 AS MoraCalc, " +
                    " 0 SaldoInteMora, " +
                    " 'Cta' as Tipo   " +
                    " FROM financiacion f   " +
                   " Where f.concepto='CI'" +

                    " UNION  " +

                     " SELECT   " +
                   "  IdFinanciacion AS Id,  " +
                   "  r.IdAdjudicacion ,   " +
                   "  r.Concepto AS concepto," +
                   "  r.NumCuota AS CuotaNum,  " +
                   "  null fecha,   " +
                   "  Max(r.Fecha) FechaRec,   " +
                   "  Sum(-r.Capital) AS Capital,   " +
                   "  Sum(-r.InteresCte) AS InteresCte,   " +
                   "  sum(-(r.Capital) - r.InteresCte) AS Cuota,   " +
                   "  sum(-r.InteresMora) AS InteresMora,  " +
                   "  sum(-r.InteresCnd) AS InteresCnd,   " +
                   "  sum(r.VrMoraCalc) AS MoraCalc,   " +
                   "  sum((r.VrMoraCalc - r.InteresCnd) - r.InteresMora) AS SaldoIntMora,   " +
                    " 'Rcd' as Tipo  " +
                   "  FROM recaudos r   " +
                  "   where r.Estado != 'Devuelto' And r.concepto='CI' group by IdFinanciacion " +


                    "  UNION  " +

                    "  SELECT  IdFinanciacion Id,   " +
                    " d.IdAdjudicacion AS IdAdjudicacion,  " +
                    " d.Concepto AS concepto,   " +
                    " d.NumCuota AS CuotaNum,   " +
                    " null Fecha,   " +
                    " d.Fecha AS FechaRec,   " +
                    " sum(-d.Capital) AS Capital,  " +
                    " sum(-d.Interes) AS InteresCte, " +
                    " sum(-d.Cuota) as Cuota,   " +
                    " 0 AS InteresMora,   " +
                    " 0 AS InteresCnd,   " +
                    " 0 AS MoraCalc,   " +
                    " 0 AS SaldoInteMora," +
                    " 'Dto' as Tipo  " +
                    " FROM descuento d " +

                     "     where  d.concepto='CI'   group by IdFinanciacion   " +
                     " UNION   " +

                     "SELECT IdFinanciacion Id,   " +
                     "d.IdAdjudicacion AS IdAdjudicacion,   " +
                     "d.Concepto AS concepto,   " +
                     "d.NumCuota AS CuotaNum,   " +
                     "null Fecha,   " +
                     "d.Fecha AS FechaRec,   " +
                     "sum(-d.Capital) AS Capital,   " +
                     "sum(-d.Interes) AS InteresCte,  " +
                     "sum(-d.Cuota) as Cuota,   " +
                     "0 AS InteresMora,  " +
                     "0 AS InteresCnd,   " +
                     "0 AS MoraCalc,   " +
                     "0 AS SaldoInteMora," +
                    " 'Can' as Tipo   " +
                    " FROM Canje d    " +

                    "  where  d.concepto='CI'   group by IdFinanciacion   " +

                     ")ss  " +

                     " group by ss.IdAdjudicacion   " +


                    " )Tipo    " +


      " on tipo.idadjudicacion=car.IdAdjudicacion   " +
        " Join 004CnsAdjudica A on A.Idadjudicacion = Car.IdAdjudicacion Left Join 004condonacion cn  on cn.idFinanciacion=Car.Id   " +
          "   where A.Idadjudicacion = '"+
          Adjudicacion +
          "' and Car.Cuota> 0 ";
            return SentenciaPrs;  
       
       
       }
//===================================================================================================================================================
//F I N A L  M E T O D O   S C R I P     R E C A U D OS
//===================================================================================================================================================

       public int siguienteAdjudicacion(string Sentencia)
       {
           int sigAdjudicacion;
           MySqlCommand Query = new MySqlCommand();
           MySqlDataReader consultar;
           try
           {
               MysqlConexion.Open();
               Query.CommandText = Sentencia;

               Query.Connection = MysqlConexion;
               consultar = Query.ExecuteReader();
               if (consultar.Read())
               {
                   return sigAdjudicacion = Convert.ToInt32(consultar.GetString(0));
               }
               else
               {
                   return 0;
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show("Ups! Hubo un inconveniente: "+ex.Message, "¡ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
               return 0;
           }
           finally
           {
               MysqlConexion.Close();
           }
       }


    }
}
