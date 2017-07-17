using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace CarteraGeneral
{
    class Terceros
    {
       
        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
        //===================================================================================================================================================
        // I N I C I O   V A R I A B L E S   Y   P R O P I E D A D E S
        //===================================================================================================================================================
        #region Variables Y Propiedades

        private double Retencion;
        private string Cargo;
        private string Cuenta;
        private string IdTercero;
        private string TipoTercero;
        private int TipoPersona;
        private string Nombrecompleto;
        private DateTime Alta;
        private string Nombre1;
        private string Nombre2;
        private string Apellido1;
        private string Apellido2;
        private DateTime FechaNac;
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
        private DateTime FechaOperacion;
        private string Codigo;
        private string Tipo;

        public double retencion
        {
            get { return Retencion; }
            set { Retencion = value; }
        }

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



        public string nombrecompleto
        {
            get { return Nombrecompleto; }
            set { Nombrecompleto = value; }
        }

        public int tipoPersona
        {
            get { return TipoPersona; }
            set { TipoPersona = value; }
        }

        public string codigo
        {
            get { return Codigo; }
            set { Codigo = value; }
        }


        public string tipo
        {
            get { return Tipo; }
            set { Tipo = value; }
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
            get { return Usuario; }
            set { Usuario = value; }
        }


        public DateTime fechaOperacion
        {
            get { return FechaOperacion; }
            set { FechaOperacion = value; }
        }



        #endregion
        //===================================================================================================================================================
        //F I N A L   V A R I A B L E S   Y   P R O P I E D A D E S
        //===================================================================================================================================================




        //===================================================================================================================================================
        // I N I C I O   M E T O D O   V A L I D A R   T E R C E R O S
        //===================================================================================================================================================
        public string MtdValidarTerceos()
        {
            string StrTexto = "select count(IdTercero) from Contabilidad_alttum.Terceros where Idtercero = " + "'" + idTercero + "'";

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
                return "Error";
            }

            finally
            {

                MysqlConexion.Close();
            }
        }
        //===================================================================================================================================================
        // F I N A L   M E T O D O   V A L I D A R    T E R C E R O S
        //===================================================================================================================================================


        //===================================================================================================================================================
        //I N I C I O  B U S C A R   D A T A S E T 
        //===================================================================================================================================================
        MySql.Data.MySqlClient.MySqlCommandBuilder CmbBuscarDataset;
        MySql.Data.MySqlClient.MySqlDataAdapter DtaBuscarDataset;
        DataSet DtsBuscarDataset = new DataSet();
        public DataTable MtdBuscarDataset(string Sentencia)
        {

            DtsBuscarDataset.Tables.Clear();
            DtaBuscarDataset = new MySqlDataAdapter(Sentencia, MysqlConexion);

            DtaBuscarDataset.Fill(DtsBuscarDataset, "BuscarDataset");
            CmbBuscarDataset = new MySqlCommandBuilder(DtaBuscarDataset);
            return DtsBuscarDataset.Tables[("BuscarDataset")];
        }
        //===================================================================================================================================================
        // FI N   B U S C A R   D A T A S E T
        //===================================================================================================================================================




        //===================================================================================================================================================
        //(1) I N I C I O  M E T O D O    A D I C I O N A R   T E R C E R O S
        //===================================================================================================================================================
        public string MtdAddTerceros()
        {

            MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
            string Salida = "";
            string StrTexto = "Insert into Contabilidad_alttum.Terceros (IdTercero,TipoTercero,Alta,Nombre1,Nombre2,Apellido1,Apellido2,FechaNac,Direccion,Barrio,Ciudad,Dpto,Telefono1,Telefono2," +
             "Celular,PaginaWeb,Email,Contacto,Usuario,FechaOperacion,TipoPersona,NombreCompleto) Values(@IdTercero,@TipoTercero,@Alta,@Nombre1,@Nombre2,@Apellido1,@Apellido2,@FechaNac," +
            "@Direccion,@Barrio,@Ciudad,@Dpto,@Telefono1,@Telefono2,@Celular,@PaginaWeb,@Email,@Contacto,@Usuario,@FechaOperacion,@TipoPersona,@NombreCompleto)";


            string SentenciaCargo = "Insert into Gestor(IdGestor,Cargo,Retencion,Cuenta) Values('" + idTercero + "','" + cargo + "'," + retencion + ",'" + cuenta + "')";




            MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            CmdAddPrm.Connection = MysqlConexion;
            CmdAddPrm.Transaction = myTrans;
            try
            {
                CmdAddPrm.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@TipoTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Alta", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@Nombre1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Nombre2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Apellido1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Apellido2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@FechaNac", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@Direccion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Barrio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Ciudad", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Dpto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Telefono1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Telefono2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Celular", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@PaginaWeb", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Email", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Contacto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@TipoPersona", MySql.Data.MySqlClient.MySqlDbType.Int16);
                CmdAddPrm.Parameters.Add("@NombreCompleto", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                CmdAddPrm.Parameters["@IdTercero"].Value = idTercero;
                CmdAddPrm.Parameters["@TipoTercero"].Value = tipoTercero;
                CmdAddPrm.Parameters["@Alta"].Value = Alta;
                CmdAddPrm.Parameters["@Nombre1"].Value = nombre1;
                CmdAddPrm.Parameters["@Nombre2"].Value = nombre2;
                CmdAddPrm.Parameters["@Apellido1"].Value = apellido1;
                CmdAddPrm.Parameters["@Apellido2"].Value = apellido2;
                CmdAddPrm.Parameters["@FechaNac"].Value = fechaNac;
                CmdAddPrm.Parameters["@Direccion"].Value = direccion;
                CmdAddPrm.Parameters["@Barrio"].Value = barrio;
                CmdAddPrm.Parameters["@Ciudad"].Value = ciudad;
                CmdAddPrm.Parameters["@Dpto"].Value = dpto;
                CmdAddPrm.Parameters["@Telefono1"].Value = telefono1;
                CmdAddPrm.Parameters["@Telefono2"].Value = telefono2;
                CmdAddPrm.Parameters["@Celular"].Value = celular;
                CmdAddPrm.Parameters["@PaginaWeb"].Value = paginaWeb;
                CmdAddPrm.Parameters["@Email"].Value = email;
                CmdAddPrm.Parameters["@Contacto"].Value = contacto;
                CmdAddPrm.Parameters["@Usuario"].Value = usuario;
                CmdAddPrm.Parameters["@FechaOperacion"].Value = fechaOperacion;
                CmdAddPrm.Parameters["@TipoPersona"].Value = tipoPersona;
                CmdAddPrm.Parameters["@NombreCompleto"].Value = nombrecompleto;
                CmdAddPrm.CommandText = StrTexto;
                object result = CmdAddPrm.ExecuteNonQuery();

                if (TipoTercero == "Gestor")
                {
                    CmdAddPrm.CommandText = SentenciaCargo;
                    CmdAddPrm.ExecuteNonQuery();
                }

                myTrans.Commit();
                MessageBox.Show("Registro Adicionado", "Adicionar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Salida = "Ok";

            }
            catch (MySqlException ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Salida = "Error";
            }
            finally
            {
                MysqlConexion.Close();

            }
            return Salida;

        }
        //===================================================================================================================================================
        //(1)F I N A L  M E T O D O   A D I C I O N A R   T E R C E R O S
        //===================================================================================================================================================


        //===================================================================================================================================================
        //(2) I N I C I O  M E T O D O    M O D I F I C A R   T E R C E R O S
        //===================================================================================================================================================
        public string MtdModTerceros()
        {
            MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
            string Salida = "";
            string StrTexto = "Update Contabilidad_alttum.Terceros set TipoTercero=@TipoTercero,Alta=@Alta,Nombre1=@Nombre1,Nombre2=@Nombre2," +
            "Apellido1=@Apellido1,Apellido2=@Apellido2,FechaNac=@FechaNac,Direccion=@Direccion,Barrio=@Barrio,Ciudad=@Ciudad,Dpto=@Dpto,Telefono1=@Telefono1," +
            "Telefono2=@Telefono2,Celular=@Celular,PaginaWeb=@PaginaWeb,Email=@Email,Contacto=@Contacto,Usuario=@Usuario,FechaOperacion=@FechaOperacion," +
            "TipoPersona=@TipoPersona,NombreCompleto=@NombreCompleto where IdTercero = @IdTercero";

            string SentenciaModCargo = "Update Gestor set Cargo = '" + cargo + "', Retencion = " + retencion + ", Cuenta ='" + cuenta + "' Where IdGestor = '" + idTercero + "'";
            MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            CmdAddPrm.Connection = MysqlConexion;
            CmdAddPrm.Transaction = myTrans;
            try
            {
                CmdAddPrm.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@TipoTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Alta", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@Nombre1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Nombre2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Apellido1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Apellido2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@FechaNac", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@Direccion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Barrio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Ciudad", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Dpto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Telefono1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Telefono2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Celular", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@PaginaWeb", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Email", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Contacto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@TipoPersona", MySql.Data.MySqlClient.MySqlDbType.Int16);
                CmdAddPrm.Parameters.Add("@NombreCompleto", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                CmdAddPrm.Parameters["@IdTercero"].Value = idTercero;
                CmdAddPrm.Parameters["@TipoTercero"].Value = tipoTercero;
                CmdAddPrm.Parameters["@Alta"].Value = Alta;
                CmdAddPrm.Parameters["@Nombre1"].Value = nombre1;
                CmdAddPrm.Parameters["@Nombre2"].Value = nombre2;
                CmdAddPrm.Parameters["@Apellido1"].Value = apellido1;
                CmdAddPrm.Parameters["@Apellido2"].Value = apellido2;
                CmdAddPrm.Parameters["@FechaNac"].Value = fechaNac;
                CmdAddPrm.Parameters["@Direccion"].Value = direccion;
                CmdAddPrm.Parameters["@Barrio"].Value = barrio;
                CmdAddPrm.Parameters["@Ciudad"].Value = ciudad;
                CmdAddPrm.Parameters["@Dpto"].Value = dpto;
                CmdAddPrm.Parameters["@Telefono1"].Value = telefono1;
                CmdAddPrm.Parameters["@Telefono2"].Value = telefono2;
                CmdAddPrm.Parameters["@Celular"].Value = celular;
                CmdAddPrm.Parameters["@PaginaWeb"].Value = paginaWeb;
                CmdAddPrm.Parameters["@Email"].Value = email;
                CmdAddPrm.Parameters["@Contacto"].Value = contacto;
                CmdAddPrm.Parameters["@Usuario"].Value = usuario;
                CmdAddPrm.Parameters["@FechaOperacion"].Value = fechaOperacion;
                CmdAddPrm.Parameters["@TipoPersona"].Value = tipoPersona;
                CmdAddPrm.Parameters["@NombreCompleto"].Value = nombrecompleto;
                CmdAddPrm.CommandText = StrTexto;
                CmdAddPrm.ExecuteNonQuery();
                if (tipoTercero == "Gestor")
                {
                    CmdAddPrm.CommandText = SentenciaModCargo;
                    CmdAddPrm.ExecuteNonQuery();
                }

                myTrans.Commit();
                MessageBox.Show("Registro Modificado", "Modificar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Salida = "Ok";

            }
            catch (MySqlException ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Salida = "Error";
            }
            finally
            {
                MysqlConexion.Close();

            }
            return Salida;
        }
        //===================================================================================================================================================
        //(2)F I N A L  M E T O D O   M O D I F I C A R    T E R C E R O S
        //===================================================================================================================================================



        //===================================================================================================================================================
        //(3) I N I C I O  M E T O D O   E L I M I N A R   T E R C E R O S
        //===================================================================================================================================================
        public string MtdDelTerceros()
        {

            MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
            string Salida = "";
            string StrTexto = "Delete From Contabilidad_alttum.Terceros where IdTercero = @IdTercero";
            string StrTextoGestor = "Delete From Gestor where IdGestor = @IdTercero";


            MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            CmdAddPrm.Connection = MysqlConexion;
            CmdAddPrm.Transaction = myTrans;

            try
            {
                CmdAddPrm.Parameters.Add("@IdTercero", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters["@IdTercero"].Value = idTercero;


                if (tipoTercero == "Gestor")
                {
                    CmdAddPrm.CommandText = StrTextoGestor;
                    CmdAddPrm.ExecuteNonQuery();
                }
                CmdAddPrm.CommandText = StrTexto;
                CmdAddPrm.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Registro Eliminado", "Eliminar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Salida = "OK";
            }

            catch (Exception ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Eliminar Terceros", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Salida = "Error";
            }
            finally
            {
                MysqlConexion.Close();
            }
            return Salida;
        }
        //===================================================================================================================================================
        //(3)F I N A L  M E T O D O   E L I M I N A R    T E R C E R O S
        //===================================================================================================================================================



        //===================================================================================================================================================
        //(2) I N I C I O  M E T O D O    M O D I F I C A R   C O D I G O
        //===================================================================================================================================================
        public string MtdModCodigo()
        {
            string SentenciaModTer = "Update Codigo set IdTercero =  '" +
            idTercero + "' , Usuario = '" +
            usuario + "', FechaOperacion = curdate(), tipo = '" + tipo + "'  Where Codigo = '" + codigo + "'";

            string MensajeSalida = "";

            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {

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
        //(2)F I N A L  M E T O D O   M O D I F I C A R   C O D I G O
        //===================================================================================================================================================




        //===============================================================================================================================
        //I N I C I O   C O N V E R T I R   F E C H A   A   S T R I N G
        //===============================================================================================================================
        public string MtdConvertFechaStr(DateTime fecha)
        {
            string ano, mes, dia, Varfecha;
            ano = Convert.ToString(fecha.Year);
            mes = Convert.ToString(fecha.Month);
            dia = Convert.ToString(fecha.Day);
            Varfecha = "'" + ano + "-" + mes + "-" + dia + "'";
            return Varfecha;
        }
        //===============================================================================================================================
        //I N I C I O   C O N V E R T I R   F E C H A   A   S T R I N G
        //===============================================================================================================================


    }
}
