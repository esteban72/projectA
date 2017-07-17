using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace CarteraGeneral
{
    class ClsReservas
    {
        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
        MySqlConnection ConexionClas = new MySqlConnection(FrmLogeo.StrConexion);



//---------------------------------------------------------------------------------------------------------------------------------------------------
// I N I C I O   V A R I A B L E S   Y  P R O P I E D A D E S    A D J U D I C A C I O N
//---------------------------------------------------------------------------------------------------------------------------------------------------
#region Variables Reservas


        private int IdReserva;

        private DateTime Fecha;

        private string Contrato;

        private string IdProyecto;

        private string IdInmueble;

        private string IdTercero1;

        private string IdGestor;

        private double ValorContrato;

        private double Pago1;

        private DateTime FechaInicio;

        private string Letra;

        private string Temporada;

        private string Usuario;

        private DateTime FechaOperacion;

        private string TipoReserva;

        private string IdInmuebleAnterior;

        public int idReserva
        {
            get { return IdReserva; }
            set { IdReserva = value; }
        }

        public DateTime fecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }

        public string contrato
        {
            get { return Contrato; }
            set { Contrato = value; }
        }

        public string idProyecto
        {
            get { return IdProyecto; }
            set { IdProyecto = value; }
        }

        public string idInmueble
        {
            get { return IdInmueble; }
            set { IdInmueble = value; }
        }

        public string idTercero1
        {
            get { return IdTercero1; }
            set { IdTercero1 = value; }
        }       

        public string idGestor
        {
            get { return IdGestor; }
            set { IdGestor = value; }
        }

        public double valorContrato
        {
            get { return ValorContrato; }
            set { ValorContrato = value; }
        }

        public double pago1
        {
            get { return Pago1; }
            set { Pago1 = value; }
        }

        public DateTime fechaInicio
        {
            get { return FechaInicio; }
            set { FechaInicio = value; }
        }

        public string letra
        {
            get { return Letra; }
            set { Letra = value; }
        }

        public string temporada
        {
            get { return Temporada; }
            set { Temporada = value; }
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


        public string tipoReserva
        {
            get { return TipoReserva; }
            set { TipoReserva = value; }
        }

        public string idInmuebleAnterior
        {
            get { return IdInmuebleAnterior; }
            set { IdInmuebleAnterior = value; }
        }
        

        #endregion
//---------------------------------------------------------------------------------------------------------------------------------------------------
// F I N A L   V A R I A B L E S     Y  P R O P I E D A D E S    A D J U D I C A C I O N
//---------------------------------------------------------------------------------------------------------------------------------------------------




//===================================================================================================================================================
//(1) I N I C I O  M E T O D O    A D I C I O N A R   R E S E R V A S
//===================================================================================================================================================
        public string MtdAddReservas()
        {
            
            MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
            string Salida = "";
            string StrAddReservas = "INSERT INTO Reservas (IdReserva,TipoReserva, Fecha, Contrato, IdProyecto, IdInmueble, IdTercero1, IdGestor, ValorContrato, ValorPago1, FechaInicio, Letra,Temporada, Usuario,  FechaOperacion) VALUES "+
                            "(@IdReserva,@TipoReserva, @Fecha, @Contrato, @IdProyecto, @IdInmueble, @IdTercero1, @IdGestor, @ValorContrato, @ValorPago1, @FechaInicio, @Letra,@Temporada ,@Usuario,  @FechaOperacion)";

            string StrInmueble = "Update Inmuebles Set Estado = 'Reservado' Where IdInmueble = @IdInmueble";

           
            string StrConsReserva = "Update consecutivos Set Consecutivo =  (Consecutivo+1) where  Nombre = 'Reservas' ";

            MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            CmdAddPrm.Connection = MysqlConexion;
            CmdAddPrm.Transaction = myTrans;
            try
            {
                CmdAddPrm.Parameters.Add("@IdReserva", MySql.Data.MySqlClient.MySqlDbType.Int16);
                CmdAddPrm.Parameters.Add("@TipoReserva", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@Contrato", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@IdProyecto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@IdTercero1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@IdGestor", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@ValorContrato", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                CmdAddPrm.Parameters.Add("@ValorPago1", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                CmdAddPrm.Parameters.Add("@FechaInicio", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@Letra", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Temporada", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);


                CmdAddPrm.Parameters["@IdReserva"].Value = idReserva;
                CmdAddPrm.Parameters["@TipoReserva"].Value = tipoReserva;
                CmdAddPrm.Parameters["@Fecha"].Value = fecha;
                CmdAddPrm.Parameters["@Contrato"].Value = contrato;
                CmdAddPrm.Parameters["@IdProyecto"].Value = idProyecto;
                CmdAddPrm.Parameters["@IdInmueble"].Value = idInmueble;
                CmdAddPrm.Parameters["@IdTercero1"].Value = idTercero1;
                CmdAddPrm.Parameters["@IdGestor"].Value = idGestor;
                CmdAddPrm.Parameters["@ValorContrato"].Value = valorContrato;
                CmdAddPrm.Parameters["@ValorPago1"].Value = pago1;
                CmdAddPrm.Parameters["@FechaInicio"].Value = fechaInicio;
                CmdAddPrm.Parameters["@Letra"].Value = letra;
                CmdAddPrm.Parameters["@Temporada"].Value = temporada;
                CmdAddPrm.Parameters["@Usuario"].Value = usuario;
                CmdAddPrm.Parameters["@FechaOperacion"].Value = fechaOperacion;
             
                CmdAddPrm.CommandText =  StrAddReservas;
                CmdAddPrm.ExecuteNonQuery();


                CmdAddPrm.CommandText = StrInmueble;
                    CmdAddPrm.ExecuteNonQuery();
                
               

                CmdAddPrm.CommandText = StrConsReserva;
                CmdAddPrm.ExecuteNonQuery();

                myTrans.Commit();
                MessageBox.Show("Registro Adicionado", "Adicionar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Salida = "Ok";

            }
            catch (MySqlException ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Salida = "Error";
            }
            finally
            {
                MysqlConexion.Close();

            }
            return Salida;

        }
//===================================================================================================================================================
//(1)F I N A L  M E T O D O  A D I C I O N A R   R E S E R V A S
//===================================================================================================================================================




//===================================================================================================================================================
//(2) I N I C I O  M E T O D O   M O D I F I C A R   R E SE R V A S
//===================================================================================================================================================
        public string MtdModReservas()
        {

            MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
            string Salida = "";

            string StrAddReservasMod = "Insert into ReservasMod (Select * From Reservas where IdReserva =@IdReserva )";

            string StrDelReservas = "Delete From Reservas Where idReserva=@IdReserva";

            //string StrModReservas = "Update  Reservas  set IdReserva = @IdReserva ,TipoReserva = @TipoReserva, Fecha = @Fecha, Contrato = @Contrato , IdProyecto = @IdProyecto, "+
            //    "IdInmueble = @IdInmueble, IdTercero1= @IdTercero1, IdGestor = @IdGestor, ValorContrato = @ValorContrato, ValorPago1 = @ValorPago1, FechaInicio = @FechaInicio  where idreserva=@IdReserva";
            string StrModReservas = "INSERT INTO Reservas (IdReserva,TipoReserva, Fecha, Contrato, IdProyecto, IdInmueble, IdTercero1, IdGestor, ValorContrato, ValorPago1, FechaInicio, Letra,Temporada, Usuario,  FechaOperacion) VALUES " +
                            "(@IdReserva,@TipoReserva, @Fecha, @Contrato, @IdProyecto, @IdInmueble, @IdTercero1, @IdGestor, @ValorContrato, @ValorPago1, @FechaInicio, @Letra, @Temporada ,@Usuario,  @FechaOperacion)";


            string StrInmueble = "Update Inmuebles Set Estado = 'Reservado' Where IdInmueble = @IdInmueble";

            string StrInmueblelibre = "Update Inmuebles Set Estado = 'Libre' Where IdInmueble ='" + idInmuebleAnterior + "'";

           



            MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            CmdAddPrm.Connection = MysqlConexion;
            CmdAddPrm.Transaction = myTrans;
            try
            {
                CmdAddPrm.Parameters.Add("@IdReserva", MySql.Data.MySqlClient.MySqlDbType.Int16);
                CmdAddPrm.Parameters.Add("@TipoReserva", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@Contrato", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@IdProyecto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@IdTercero1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@IdGestor", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@ValorContrato", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                CmdAddPrm.Parameters.Add("@ValorPago1", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                CmdAddPrm.Parameters.Add("@FechaInicio", MySql.Data.MySqlClient.MySqlDbType.Date);
                CmdAddPrm.Parameters.Add("@Letra", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Temporada", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);


                CmdAddPrm.Parameters["@IdReserva"].Value = idReserva;
                CmdAddPrm.Parameters["@TipoReserva"].Value = tipoReserva;
                CmdAddPrm.Parameters["@Fecha"].Value = fecha;
                CmdAddPrm.Parameters["@Contrato"].Value = contrato;
                CmdAddPrm.Parameters["@IdProyecto"].Value = idProyecto;
                CmdAddPrm.Parameters["@IdInmueble"].Value = idInmueble;
                CmdAddPrm.Parameters["@IdTercero1"].Value = idTercero1;
                CmdAddPrm.Parameters["@IdGestor"].Value = idGestor;
                CmdAddPrm.Parameters["@ValorContrato"].Value = valorContrato;
                CmdAddPrm.Parameters["@ValorPago1"].Value = pago1;
                CmdAddPrm.Parameters["@FechaInicio"].Value = fechaInicio;
                CmdAddPrm.Parameters["@Letra"].Value = letra;
                CmdAddPrm.Parameters["@Temporada"].Value = temporada;
                CmdAddPrm.Parameters["@Usuario"].Value = usuario;
                CmdAddPrm.Parameters["@FechaOperacion"].Value = fechaOperacion;

                CmdAddPrm.CommandText = StrAddReservasMod;
                CmdAddPrm.ExecuteNonQuery();

                CmdAddPrm.CommandText = StrDelReservas;
                CmdAddPrm.ExecuteNonQuery();

                CmdAddPrm.CommandText = StrModReservas;
                CmdAddPrm.ExecuteNonQuery();

                CmdAddPrm.CommandText = StrInmueble;
                CmdAddPrm.ExecuteNonQuery();


                if (IdInmueble != idInmuebleAnterior)
                {
                    CmdAddPrm.CommandText = StrInmueblelibre;
                    CmdAddPrm.ExecuteNonQuery();
                }
                   

               

                myTrans.Commit();
                MessageBox.Show("Registro Modificado", "Modificar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Salida = "Ok";

            }
            catch (MySqlException ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Modificar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Salida = "Error";
            }
            finally
            {
                MysqlConexion.Close();

            }
            return Salida;

        }
//===================================================================================================================================================
//(2)F I N A L  M E T O D O  M O D I F I C A R   R E S E R V A S
//===================================================================================================================================================



//===================================================================================================================================================
//(3) I N I C I O  M E T O D O   E L I M I N A R   R E SE R V A S
//===================================================================================================================================================
        public string MtddELReservas()
        {

            MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
            string Salida = "";

            string StrAddReservasMod = "Insert into ReservasMod (Select * From Reservas where IdReserva =@IdReserva )";

            string StrDelReservas =    "Update Reservas Set Estado = 'Eliminado',Usuario=@Usuario,FechaOperacion=@FechaOperacion  where idreserva = @IdReserva";

            string StrInmueblelibre = "Update Inmuebles Set Estado = 'Libre' Where IdInmueble = @IdInmueble";

          



            MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            CmdAddPrm.Connection = MysqlConexion;
            CmdAddPrm.Transaction = myTrans;
            try
            {
                CmdAddPrm.Parameters.Add("@IdReserva", MySql.Data.MySqlClient.MySqlDbType.Int16);               
                CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);


                CmdAddPrm.Parameters["@IdReserva"].Value = idReserva;              
                CmdAddPrm.Parameters["@IdInmueble"].Value = idInmueble;
                CmdAddPrm.Parameters["@Usuario"].Value = usuario;
                CmdAddPrm.Parameters["@FechaOperacion"].Value = fechaOperacion;

                CmdAddPrm.CommandText = StrAddReservasMod;
                CmdAddPrm.ExecuteNonQuery();

                CmdAddPrm.CommandText = StrDelReservas;
                CmdAddPrm.ExecuteNonQuery();


                CmdAddPrm.CommandText = StrInmueblelibre;
                CmdAddPrm.ExecuteNonQuery();
                    
               



                myTrans.Commit();
                MessageBox.Show("Registro Eliminado", "Eliminar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Salida = "Ok";

            }
            catch (MySqlException ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Eliminar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Salida = "Error";
            }
            finally
            {
                MysqlConexion.Close();

            }
            return Salida;

        }
//===================================================================================================================================================
//(3)F I N A L  M E T O D O E L I M I N A R  R E S E R V A S
//===================================================================================================================================================




//===================================================================================================================================================
//(4) I N I C I O  M E T O D O   D E S I S I T I R   R E SE R V A S
//===================================================================================================================================================
        public string MtdDesReservas()
        {

            MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
            string Salida = "";

            string StrAddReservasMod = "Insert into ReservasMod (Select * From Reservas where IdReserva =@IdReserva )";

            string StrDesReservas = "Update Reservas Set Estado = 'Desistido',Usuario=@Usuario,FechaOperacion=@FechaOperacion  where idreserva = @IdReserva";

            string StrInmuebleDesistir = "Update Inmuebles Set Estado = 'Libre' Where IdInmueble = @IdInmueble";

           



            MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
            MysqlConexion.Open();
            MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = MysqlConexion.BeginTransaction();
            CmdAddPrm.Connection = MysqlConexion;
            CmdAddPrm.Transaction = myTrans;
            try
            {
                CmdAddPrm.Parameters.Add("@IdReserva", MySql.Data.MySqlClient.MySqlDbType.Int16);
                CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);


                CmdAddPrm.Parameters["@IdReserva"].Value = idReserva;
                CmdAddPrm.Parameters["@IdInmueble"].Value = idInmueble;
                CmdAddPrm.Parameters["@Usuario"].Value = usuario;
                CmdAddPrm.Parameters["@FechaOperacion"].Value = fechaOperacion;

                CmdAddPrm.CommandText = StrAddReservasMod;
                CmdAddPrm.ExecuteNonQuery();

                CmdAddPrm.CommandText = StrDesReservas;
                CmdAddPrm.ExecuteNonQuery();

                CmdAddPrm.CommandText = StrInmuebleDesistir;
                CmdAddPrm.ExecuteNonQuery();

                


                myTrans.Commit();
                MessageBox.Show("Registro Desistido", "Desistir Reservas", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Salida = "Ok";

            }
            catch (MySqlException ex)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Eliminar Reservas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Salida = "Error";
            }
            finally
            {
                MysqlConexion.Close();

            }
            return Salida;

        }
//===================================================================================================================================================
//(3)F I N A L  M E T O D O    D E S I S T I R    R E S E R V A S
//===================================================================================================================================================






      
        


    }
}
