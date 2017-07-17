using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarteraGeneral.Clases
{
    public class ClsRadicacion
    {
        #region "Metodos"      

        //Este metodo se utiliza para obtener el Id del Cargo que se encuentra en tablacomision
        public string ConsultarIdCargo(string cargo)
        {
            string conexion = FrmLogeo.StrConexion;
            MySqlConnection conn = new MySqlConnection(conexion);
            conn.Open();
            string query = "Select IdCargo From tablacomisiones Where NombreCargo = '"+cargo+"'";
            MySqlCommand mycomand = new MySqlCommand(query, conn);
            MySqlDataReader myreader = mycomand.ExecuteReader();
            string IdCargo = "";
            if (myreader.Read())
            {
                IdCargo = myreader["IdCargo"].ToString();	
            }
            
            return IdCargo;
        }

        #endregion
    }
}
