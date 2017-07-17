using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
namespace CarteraGeneral
    {
    class ClsTereros
    {
        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
        MySqlConnection ConexionClas = new MySqlConnection(FrmLogeo.StrConexion);

//===================================================================================================================================================
//I N I C I O   V A R I A B L E S
//===================================================================================================================================================
        #region Variables
        private string Cargo;
        private string Cuenta;
        private string IdTercero;
        private string TipoTercero;
        private DateTime Alta;
        private string StrAlta;
        private string Nombre1;
        private string Nombre2;
        private string Apellido1;
        private string Apellido2;
        private DateTime FechaNac;
        private string StFechaNac;
        private string Direccion;
        private string Barrio;
        private string Ciudad;
        private string Dpto;
        private string Telefono1;
        private string Telefono2;
        private string Celular;
        private string PaginaWeb;
        private string Email;
        private string Contacto;
        private string Usuario;
        private double Retencion;
        private DateTime FechaOperacion;
            private string StrFechaOperacion;
        #endregion
//===================================================================================================================================================
//F I N A L    V A R I A B L E S
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I A L   A S I G N A R     V A R I A B L E S
//===================================================================================================================================================
#region Asignar Variables


            public string cargo
            {
                get { return Cargo; }
                set { Cargo = value; }
            }

            public string cuenta
            {
                get { return Cuenta; }
                set { Cuenta = value; }
            }
            public string idTercero
            {
                get { return IdTercero; }
                set { IdTercero = value; }
            }

            public string tipoTercero
            {
                get { return TipoTercero; }
                set { TipoTercero = value; }
            }

            public DateTime alta
            {
                get { return Alta; }
                set { Alta = value; }
            }

            public string strAlta
            {
                get {
                    StrAlta = MtdVldFchPed(alta);
                    return StrAlta;                    
                    }
                set { StrAlta = value; }
            }
                 
            public string nombre1
            {
                get { return Nombre1; }
                set { Nombre1 = value; }
            }

            public string nombre2
            {
                get { return Nombre2; }
                set { Nombre2 = value; }
            }

            public string apellido1
            {
                get { return Apellido1; }
                set { Apellido1 = value; }
            }

            public string apellido2
            {
                get { return Apellido2; }
                set { Apellido2 = value; }
            }

            public DateTime fechaNac
            {
                get { return FechaNac; }
                set { FechaNac = value; }
            }


            public string strFechaNac
            {
                get
                {
                    StFechaNac = MtdVldFchPed(fechaNac);
                    return StFechaNac;
                }
                set { StFechaNac = value; }
            }


            public string direccion
            {
                get { return Direccion; }
                set { Direccion = value; }
            }


            public string barrio
            {
                get { return Barrio; }
                set { Barrio = value; }
            }


            public string ciudad
            {
                get { return Ciudad; }
                set { Ciudad = value; }
            }


            public string dpto
            {
                get { return Dpto; }
                set { Dpto = value; }
            }



            public string telefono1
            {
                get { return Telefono1; }
                set { Telefono1 = value; }
            }


            public string telefono2
            {
                get { return Telefono2; }
                set { Telefono2 = value; }
            }

            public string celular
            {
                get { return Celular; }
                set { Celular = value; }
            }

            public string paginaWeb
            {
                get { return PaginaWeb; }
                set { PaginaWeb = value; }
            }


            public string email
            {
                get { return Email; }
                set { Email = value; }
            }


            public string contacto
            {
                get { return Contacto; }
                set { Contacto = value; }
            }


            public string usuario
            {
                get { return FrmLogeo.Usuario;; }
                set { Usuario = value; }
            }


            public DateTime fechaOperacion
            {
                get { return FechaOperacion; }
                set { FechaOperacion = value; }
            }


            public string strFechaOperacion
            {
                get
                {
                    StrFechaOperacion = MtdVldFchPed(fechaOperacion);
                    return StrFechaOperacion;
                }
                set { StrFechaOperacion = value; }
            }

            public double  retencion
            {
                get { return Retencion; }
                set { Retencion = value; }
            }
  
#endregion
//===================================================================================================================================================
//F I N A L  A S I G N A R   V A R I A B L E S
//===================================================================================================================================================





        #region Metodos

//===================================================================================================================================================
//(1) I N I C I O   V A L I D A R   F E C H A  P E D I D A 
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
//(1)F I N A L     V A L I D A R   F E C H A  P E D I D A 
//===================================================================================================================================================



//===================================================================================================================================================
//(2) I N I C I O     V A L I D A R  F E C H A
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
//(2)F I N A L       V A L I D A R  F E C H A
//===================================================================================================================================================



//===================================================================================================================================================
//(1) I N I C I O  M E T O D O    A D I C I O N A R   T E R C E R O S
//===================================================================================================================================================
        public string MtdAddTerceros()
        {
            string SentenciaAddTer = "insert into Terceros values ('" +
            idTercero + "' , '" +
            tipoTercero + "', '" +
            strAlta + " ', '" +
            nombre1 + "','" +
            nombre2 + "', '" +
            apellido1 + "','" +
            apellido2 + "','" +
            strFechaNac + "','" +
            direccion + "','" +
            barrio + "','" +
            ciudad + "','" +
            dpto + "','" +
            telefono1 + "','" +
            telefono2 + "','" +
            celular + "','" +
            paginaWeb + "','" +
            email + "','" +
            contacto + "','" +
            usuario + "','" +
            strFechaOperacion + "')";
            string SentenciaCargo = "Insert into Gestor(IdGestor,Cargo,Retencion,Cuenta) Values('" + idTercero + "','"+  cargo +"'," + retencion +",'"+cuenta+"')"; 
              
            string MensajeSalida = "";

            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.CommandText = SentenciaAddTer;
                myCommand.ExecuteNonQuery();
                if (TipoTercero == "Gestor")
                {
                    myCommand.CommandText = SentenciaCargo;
                    myCommand.ExecuteNonQuery();
                }
                myTrans.Commit();
                MensajeSalida = "OK";
            }

            catch (Exception e)
            {
                
                MensajeSalida = "Ha ocurrido el sgte error " + e.Message +
                                                             " was encountered while attempting to roll back the transaction.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;

        }
//===================================================================================================================================================
//(1)F I N A L  M E T O D O   A D I C I O N A R   T E R C E R O S
//===================================================================================================================================================


//===================================================================================================================================================
//(2) I N I C I O  M E T O D O    M O D I F I C A R   T E R C E R O S
//===================================================================================================================================================
    public string MtdModTerceros()
        {
            string SentenciaModTer = "Update Terceros set IdTercero =  '" +
            idTercero + "' ,TipoTercero =  '" +
            tipoTercero + "', Alta = '" +
            strAlta + " ',Nombre1 = '" +
            nombre1 + "',Nombre2 = '" +
            nombre2 + "', Apellido1 = '" +
            apellido1 + "', Apellido2 =  '" +
            apellido2 + "',FechaNac =  '" +
            strFechaNac + "', Direccion = '" +
            direccion + "',Barrio = '" +
            barrio + "',Ciudad = '" +
            ciudad + "', Dpto= '" +
            dpto + "',Telefono1 = '" +
            telefono1 + "',Telefono2 = '" +
            telefono2 + "',Celular = '" +
            celular + "', PaginaWeb = '" +
            paginaWeb + "',Email = '" +
            email + "', Contacto ='" +
            contacto + "', Usuario = '" +
            usuario + "', FechaOperacion = '" +
            strFechaOperacion + "' Where IdTercero = '"+idTercero+"'";

            string SentenciaModCargo="Update Gestor set Cargo = '"+ cargo +"', Retencion = " +retencion +", Cuenta ='"+cuenta +"' Where IdGestor = '" + idTercero + "'"; 
            string MensajeSalida = "";

            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                if (TipoTercero != "Cliente")
                {
                    myCommand.CommandText = SentenciaModCargo;
                    myCommand.ExecuteNonQuery();
                }
                myCommand.CommandText = SentenciaModTer;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MensajeSalida = "OK";
            }

            catch (Exception e)
            {

                MensajeSalida = "Ha ocurrido el sgte error " + e.Message +
                                                             " was encountered while attempting to roll back the transaction.";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return MensajeSalida;
        }
//===================================================================================================================================================
//(2)F I N A L  M E T O D O   M O D I F I C A R    T E R C E R O S
//===================================================================================================================================================



//===================================================================================================================================================
//(3) I N I C I O  M E T O D O   E L I M I N A R   T E R C E R O S
//===================================================================================================================================================
    public string MtdDelTerceros()
    {
        string SentenciaDelTer = "Delete From Contabilidad_alttum.Terceros  Where IdTercero = '" + idTercero + "'";
        string SentenciaDelCargo = "Delete From Gestor  Where IdGestor = '" + idTercero + "'";

        string MensajeSalida = "";

        MysqlConexion.Open();
        MySqlCommand myCommand = MysqlConexion.CreateCommand();
        MySqlTransaction myTrans;

        myTrans = MysqlConexion.BeginTransaction();
        myCommand.Connection = MysqlConexion;
        myCommand.Transaction = myTrans;

        try
        {
            if (TipoTercero != "Cliente")
            {
                myCommand.CommandText = SentenciaDelCargo;
                myCommand.ExecuteNonQuery();
            }
            myCommand.CommandText = SentenciaDelTer;
            myCommand.ExecuteNonQuery();
            myTrans.Commit();
            MensajeSalida = "OK";
        }

        catch (Exception e)
        {

            MensajeSalida = "Ha ocurrido el sgte error " + e.Message +
                                                         " was encountered while attempting to roll back the transaction.";
        }
        finally
        {
            MysqlConexion.Close();
        }
        return MensajeSalida;
    }
//===================================================================================================================================================
//(3)F I N A L  M E T O D O   E L I M I N A R    T E R C E R O S
//===================================================================================================================================================


        #endregion
    }
}
