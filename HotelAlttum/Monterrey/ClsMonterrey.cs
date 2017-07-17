using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarteraGeneral
{

    class ClsMonterrey
    {
        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

        #region Propiedades
        public string IdEnvio {get;set;}
        public DateTime Fecha { get; set; }
        public string IdAdjudicacion {get;set;}
        public string Contrato {get;set;}
        public decimal ValorContrato {get;set;}
        public string IdLote {get;set;}
        public string Estado {get;set;}
        public string ReferenciaMonterey {get;set;}
        public DataTable dtDetalle {get;set;}
#endregion

        public string MtdGuardarEnvio()
        {
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            Estado = "Pendiente";

            myCommand.Parameters.Add("@IdEnvio",MySqlDbType.VarChar);
            myCommand.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = Fecha;
            myCommand.Parameters.Add("@IdAdjudicacion",MySqlDbType.VarChar);
            myCommand.Parameters.Add("@Contrato",MySqlDbType.VarChar);
            myCommand.Parameters.Add("@ValorContrato",MySqlDbType.Decimal);
            myCommand.Parameters.Add("@IdLote",MySqlDbType.VarChar).Value = IdLote;
            myCommand.Parameters.Add("@Estado",MySqlDbType.VarChar).Value= Estado;
            myCommand.Parameters.Add("@ReferenciaMonterey",MySqlDbType.VarChar);
            myCommand.Parameters.Add("@Cuota", MySqlDbType.Decimal);
            myCommand.Parameters.Add("@Financiacion", MySqlDbType.Decimal);
            myCommand.Parameters.Add("@FechaOperacion", MySqlDbType.DateTime).Value = DateTime.Now;
            myCommand.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = FrmLogeo.Usuario;


            try
            {
                for (int i = 0; i < dtDetalle.Rows.Count - 1; i++)
			    {
                    myCommand.Parameters["@IdAdjudicacion"].Value =  dtDetalle.Rows[i][0].ToString();
                    myCommand.Parameters["@Contrato"].Value =  dtDetalle.Rows[i][2].ToString();
                    myCommand.Parameters["@ValorContrato"].Value =  dtDetalle.Rows[i][4].ToString();
                    myCommand.Parameters["@Cuota"].Value = dtDetalle.Rows[i][7].ToString();
                    myCommand.Parameters["@Financiacion"].Value = dtDetalle.Rows[i][6].ToString();


			        myCommand.CommandText = "INSERT INTO enviosmonterey (IdAdjudicacion,Fecha,Contrato,ValorContrato,IdLote,Estado,Usuario,FechaOperacion,Cuota,Financiacion) VALUES (@IdAdjudicacion,@Fecha,@Contrato,@ValorContrato,@IdLote,@Estado,@Usuario,@FechaOperacion,@Cuota,@Financiacion)";
                    myCommand.ExecuteNonQuery();

                    myCommand.CommandText = "UPDATE adjudicacion SET negociacion='Enviado' WHERE IdAdjudicacion=@IdAdjudicacion";
                    myCommand.ExecuteNonQuery();
			    }

                
                myTrans.Commit();
                return "OK";
            }

            catch (Exception e)
            {

                return "Ha ocurrido el sgte error " + e.Message;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }


        public string MtdModificarEnvio()
        {
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            Estado = "Pendiente";

            myCommand.Parameters.Add("@IdEnvio", MySqlDbType.VarChar);
            myCommand.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = Fecha;
            myCommand.Parameters.Add("@IdAdjudicacion", MySqlDbType.VarChar);
            myCommand.Parameters.Add("@Contrato", MySqlDbType.VarChar);
            myCommand.Parameters.Add("@ValorContrato", MySqlDbType.Decimal);
            myCommand.Parameters.Add("@IdLote", MySqlDbType.VarChar).Value = IdLote;
            myCommand.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = Estado;
            myCommand.Parameters.Add("@ReferenciaMonterey", MySqlDbType.VarChar);
            myCommand.Parameters.Add("@Cuota", MySqlDbType.Decimal);
            myCommand.Parameters.Add("@Financiacion", MySqlDbType.Decimal);
            myCommand.Parameters.Add("@FechaOperacion", MySqlDbType.DateTime).Value = DateTime.Now;
            myCommand.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = FrmLogeo.Usuario;

            try
            {
                myCommand.CommandText = "Insert Into modenviosmonterey Select * from enviosmonterey Where idLote=@IdLote";
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = "Delete  from enviosmonterey Where idLote=@IdLote";
                myCommand.ExecuteNonQuery();

                for (int i = 0; i < dtDetalle.Rows.Count - 1; i++)
                {
                    myCommand.Parameters["@IdAdjudicacion"].Value = dtDetalle.Rows[i][0].ToString();
                    myCommand.Parameters["@Contrato"].Value = dtDetalle.Rows[i][2].ToString();
                    myCommand.Parameters["@ValorContrato"].Value = dtDetalle.Rows[i][4].ToString();
                    myCommand.Parameters["@Cuota"].Value = dtDetalle.Rows[i][7].ToString();
                    myCommand.Parameters["@Financiacion"].Value = dtDetalle.Rows[i][6].ToString();

                    myCommand.CommandText = "INSERT INTO enviosmonterey (IdAdjudicacion,Fecha,Contrato,ValorContrato,IdLote,Estado,Usuario,FechaOperacion,Cuota,Financiacion) VALUES (@IdAdjudicacion,@Fecha,@Contrato,@ValorContrato,@IdLote,@Estado,@Usuario,@FechaOperacion,@Cuota,@Financiacion)";
                    myCommand.ExecuteNonQuery();

                    myCommand.CommandText = "UPDATE adjudicacion SET negociacion='Enviado' WHERE IdAdjudicacion=@IdAdjudicacion";
                    myCommand.ExecuteNonQuery();
                }


                myTrans.Commit();
                return "OK";
            }

            catch (Exception e)
            {

                return "Ha ocurrido el sgte error " + e.Message;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }



        public string MtdGuardarEnvioNormal()
        {
            MysqlConexion.Open();
            MySqlCommand myCommand = MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = MysqlConexion.BeginTransaction();
            myCommand.Connection = MysqlConexion;
            myCommand.Transaction = myTrans;

            Estado = "Pendiente";

            myCommand.Parameters.Add("@IdEnvio", MySqlDbType.VarChar);
            myCommand.Parameters.Add("@Fecha", MySqlDbType.DateTime).Value = Fecha;
            myCommand.Parameters.Add("@IdAdjudicacion", MySqlDbType.VarChar);
            myCommand.Parameters.Add("@Contrato", MySqlDbType.VarChar);
            myCommand.Parameters.Add("@ValorContrato", MySqlDbType.Decimal);
            myCommand.Parameters.Add("@IdLote", MySqlDbType.VarChar).Value = IdLote;
            myCommand.Parameters.Add("@Estado", MySqlDbType.VarChar).Value = Estado;
            myCommand.Parameters.Add("@ReferenciaMonterey", MySqlDbType.VarChar);
            myCommand.Parameters.Add("@FechaOperacion", MySqlDbType.DateTime).Value = DateTime.Now;
            myCommand.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = FrmLogeo.Usuario;


            try
            {
                for (int i = 0; i < dtDetalle.Rows.Count - 1; i++)
                {
                    myCommand.Parameters["@IdAdjudicacion"].Value = dtDetalle.Rows[i][0].ToString();
                    myCommand.Parameters["@Contrato"].Value = dtDetalle.Rows[i][2].ToString();
                    myCommand.Parameters["@ValorContrato"].Value = dtDetalle.Rows[i][4].ToString();


                    myCommand.CommandText = "INSERT INTO enviosmonterey (IdAdjudicacion,Fecha,Contrato,ValorContrato,IdLote,Estado,Usuario,FechaOperacion) VALUES (@IdAdjudicacion,@Fecha,@Contrato,@ValorContrato,@IdLote,@Estado,@Usuario,@FechaOperacion)";
                    myCommand.ExecuteNonQuery();

                    myCommand.CommandText = "UPDATE adjudicacion SET TipoOperacion='AlttumMonterey' , negociacion='Enviado' WHERE IdAdjudicacion=@IdAdjudicacion";
                    myCommand.ExecuteNonQuery();


                }


                myTrans.Commit();
                return "OK";
            }

            catch (Exception e)
            {

                return "Ha ocurrido el sgte error " + e.Message;
            }
            finally
            {
                MysqlConexion.Close();
            }
        }
    }

   

}
