using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Office.Interop.Excel;

namespace CarteraGeneral
{
    public partial class Permisos : Form
    {
        public Permisos()
        {
            InitializeComponent();
        }


        System.Data.DataTable DtPermisos = new System.Data.DataTable();
        List<string> DatosdeErrores = new List<string>();
       
        public string EntradaPermisos = "",VarIdUsuario,VarNombreUsuario,VarNombreModulo;
      
        int VarModulo;
        double CuentaErrores;
        bool VarAdicionar, VarModificar, VarEliminar;
        ClsIdentificacion conexion = new ClsIdentificacion();


        #region REGION DE METODOS

        private void MtdDatosPermisos()

        {
            DtPermisos = conexion.MtdBuscarDataset("Select Modulo,Nombre,Adicionar,Modificar,Eliminar From Permisos Where IdUsuario='" + VarIdUsuario + "'");
            DgvPermisos.Rows.Clear();
            for (int i = 0; i < (DtPermisos.Rows.Count); i++)
            {
                DgvPermisos.Rows.Add(DtPermisos.Rows[i][0], DtPermisos.Rows[i][1], DtPermisos.Rows[i][2], DtPermisos.Rows[i][3], DtPermisos.Rows[i][4]);

            }
            TxtUsuario.Enabled = false;
            TxtClave.Enabled = false;
            TxtConfClave.Enabled = false;
            TxtUsuario.Text = VarIdUsuario;
            TxtNombreUsuario.Text = VarNombreUsuario;
        }

        private void MtdDatosNuevos()
        {
            DtPermisos = conexion.MtdBuscarDataset("Select Modulo,NombreModulo,0,0,0 From Modulos");
            DgvPermisos.Rows.Clear();
            for (int i = 0; i < (DtPermisos.Rows.Count); i++)
            {
                DgvPermisos.Rows.Add(DtPermisos.Rows[i][0], DtPermisos.Rows[i][1], DtPermisos.Rows[i][2], DtPermisos.Rows[i][3], DtPermisos.Rows[i][4]);

            }
        }

        private void MtdInicio()
        {
            switch (EntradaPermisos)
            {
                case "Adicionar":
                    BtnAceptar.Text = "Adicionar";
                    LblTitulo.Text = "ADICIONAR USUARIOS";
                    TxtUsuario.Focus();
                    MtdDatosNuevos(); 
                    break;


                case "Modificar":
                    BtnAceptar.Text = "Modificar";
                    LblTitulo.Text = "MODIFICAR USUARIOS";
                    MtdDatosPermisos();

                    break;

                case "Eliminar":
                    BtnAceptar.Text = "Eliminar";
                    LblTitulo.Text = "ELIMINAR USUARIOS"; 
                    MtdDatosPermisos();
                    break;

                case "Consultar":                   
                    TxtNombreUsuario.Enabled = false;
                    BtnAceptar.Visible = false;
                    MtdDatosPermisos();
                    DgvPermisos.ReadOnly = true;
                    break;

                default:

                    break;
            }
        }

        private void MtdDatosDesMarcados()
        {
            for (int i = 0; i < (DgvPermisos.Rows.Count); i++)
            {
                DgvPermisos.Rows[i].Cells[2].Value = 0;
                DgvPermisos.Rows[i].Cells[3].Value = 0;
                DgvPermisos.Rows[i].Cells[4].Value = 0;
            }            
        }

        private void MtdDatosMarcados()
        {
            for (int i = 0; i < (DgvPermisos.Rows.Count); i++)
            {
                DgvPermisos.Rows[i].Cells[2].Value = 1;
                DgvPermisos.Rows[i].Cells[3].Value = 1;
                DgvPermisos.Rows[i].Cells[4].Value = 1;
            }
        }      
        
        private void MtdAddUsuario()
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

                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    
                    FrmLogeo.MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = FrmLogeo.MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = FrmLogeo.MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                        CmdAddPrm.Parameters.Add("@IdUsuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@NombreUsuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Clave", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@IdAutoriza", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaAutoriza", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Modulo", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Nombre", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Adicionar", MySql.Data.MySqlClient.MySqlDbType.Bit);
                        CmdAddPrm.Parameters.Add("@Modificar", MySql.Data.MySqlClient.MySqlDbType.Bit);
                        CmdAddPrm.Parameters.Add("@Eliminar", MySql.Data.MySqlClient.MySqlDbType.Bit);

                        CmdAddPrm.Parameters["@IdUsuario"].Value = TxtUsuario.Text;
                        CmdAddPrm.Parameters["@NombreUsuario"].Value = TxtNombreUsuario.Text;
                        CmdAddPrm.Parameters["@Clave"].Value = TxtClave.Text;
                        CmdAddPrm.Parameters["@Fecha"].Value = DtpFecha.Value;
                        CmdAddPrm.Parameters["@IdAutoriza"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaAutoriza"].Value = DateTime.Now;




                        CmdAddPrm.CommandText = "INSERT INTO Usuario (IdUsuario,NombreUsuario,Clave,Fecha,IdAutoriza,FechaAutoriza) " +
                        " Values (@IdUsuario,@NombreUsuario,(SELECT PASSWORD(@Clave)),@Fecha,@IdAutoriza,@FechaAutoriza)";
                        CmdAddPrm.ExecuteNonQuery();

                        for (int i = 0; i < DgvPermisos.Rows.Count; i++)
                        {

                            VarModulo = Convert.ToInt16(DgvPermisos.Rows[i].Cells[0].Value);
                            VarNombreModulo = Convert.ToString(DgvPermisos.Rows[i].Cells[1].Value);
                            VarAdicionar = Convert.ToBoolean(DgvPermisos.Rows[i].Cells[2].Value);
                            VarModificar = Convert.ToBoolean(DgvPermisos.Rows[i].Cells[3].Value);
                            VarEliminar = Convert.ToBoolean(DgvPermisos.Rows[i].Cells[4].Value);

                            CmdAddPrm.Parameters["@Modulo"].Value = VarModulo;
                            CmdAddPrm.Parameters["@Nombre"].Value = VarNombreModulo;
                            CmdAddPrm.Parameters["@Adicionar"].Value = VarAdicionar;
                            CmdAddPrm.Parameters["@Modificar"].Value = VarModificar;
                            CmdAddPrm.Parameters["@Eliminar"].Value = VarEliminar;

                            CmdAddPrm.CommandText = "INSERT INTO Permisos (IdUsuario,Modulo,Nombre,Adicionar,Modificar,Eliminar,IdAutoriza,FechaAutoriza)  " +
                           " VALUES(@IdUsuario,@Modulo,@Nombre,@Adicionar,@Modificar,@Eliminar,@IdAutoriza,@FechaAutoriza)";
                            CmdAddPrm.ExecuteNonQuery();

                        }

                        myTrans.Commit();
                        MessageBox.Show("Registro Adicionado", "Adicionar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnAceptar.Enabled = false;
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();

                        MessageBox.Show("Se Presento el sgte Error: " + ex.Message, "Adicionar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        FrmLogeo.MysqlConexion.Close();
                    }
                }
            }
        }

        private void MtdModUsuario()
        {
            

                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {

                    FrmLogeo.MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = FrmLogeo.MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = FrmLogeo.MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                        CmdAddPrm.Parameters.Add("@IdUsuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@NombreUsuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Clave", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@IdAutoriza", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@FechaAutoriza", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Modulo", MySql.Data.MySqlClient.MySqlDbType.Int16);
                        CmdAddPrm.Parameters.Add("@Nombre", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Adicionar", MySql.Data.MySqlClient.MySqlDbType.Bit);
                        CmdAddPrm.Parameters.Add("@Modificar", MySql.Data.MySqlClient.MySqlDbType.Bit);
                        CmdAddPrm.Parameters.Add("@Eliminar", MySql.Data.MySqlClient.MySqlDbType.Bit);

                        CmdAddPrm.Parameters["@IdUsuario"].Value = TxtUsuario.Text;
                        CmdAddPrm.Parameters["@NombreUsuario"].Value = TxtNombreUsuario.Text;
                        CmdAddPrm.Parameters["@Clave"].Value = TxtClave.Text;
                        CmdAddPrm.Parameters["@Fecha"].Value = DtpFecha.Value;
                        CmdAddPrm.Parameters["@IdAutoriza"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@FechaAutoriza"].Value = DateTime.Now;




                        CmdAddPrm.CommandText = "Update  Usuario set NombreUsuario=@NombreUsuario,IdAutoriza=@IdAutoriza,FechaAutoriza=@FechaAutoriza where idusuario=@idusuario";                    
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = "Insert Into PermisosMod (Select * From Permisos where idusuario=@idusuario)";
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = "delete From Permisos where IdUsuario = @IdUsuario";
                        CmdAddPrm.ExecuteNonQuery();


                        for (int i = 0; i < DgvPermisos.Rows.Count; i++)
                        {

                            VarModulo = Convert.ToInt16(DgvPermisos.Rows[i].Cells[0].Value);
                            VarNombreModulo = Convert.ToString(DgvPermisos.Rows[i].Cells[1].Value);
                            VarAdicionar = Convert.ToBoolean(DgvPermisos.Rows[i].Cells[2].Value);
                            VarModificar = Convert.ToBoolean(DgvPermisos.Rows[i].Cells[3].Value);
                            VarEliminar = Convert.ToBoolean(DgvPermisos.Rows[i].Cells[4].Value);

                            CmdAddPrm.Parameters["@Modulo"].Value = VarModulo;
                            CmdAddPrm.Parameters["@Nombre"].Value = VarNombreModulo;
                            CmdAddPrm.Parameters["@Adicionar"].Value = VarAdicionar;
                            CmdAddPrm.Parameters["@Modificar"].Value = VarModificar;
                            CmdAddPrm.Parameters["@Eliminar"].Value = VarEliminar;

                            CmdAddPrm.CommandText = "INSERT INTO Permisos (IdUsuario,Modulo,Nombre,Adicionar,Modificar,Eliminar,IdAutoriza,FechaAutoriza)  " +
                           " VALUES(@IdUsuario,@Modulo,@Nombre,@Adicionar,@Modificar,@Eliminar,@IdAutoriza,@FechaAutoriza)";
                            CmdAddPrm.ExecuteNonQuery();

                        }

                        myTrans.Commit();
                        MessageBox.Show("Registro Modificado", "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        BtnAceptar.Enabled = false;
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();

                        MessageBox.Show("Se Presento el sgte Error: " + ex.Message, "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        FrmLogeo.MysqlConexion.Close();
                    }
                
            }
        }

        private void MtdDelUsuario()
        {
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Eliminar Este Registro", "Eliminar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);            
            
            if (rest == DialogResult.Yes)
            {
                FrmLogeo.MysqlConexion.Open();
                MySqlCommand CmdAddPrm = FrmLogeo.MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = FrmLogeo.MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {
                    CmdAddPrm.Parameters.Add("@IdUsuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@NombreUsuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Clave", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@IdAutoriza", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@FechaAutoriza", MySql.Data.MySqlClient.MySqlDbType.Date);

                    CmdAddPrm.Parameters["@IdUsuario"].Value = TxtUsuario.Text;
                    CmdAddPrm.Parameters["@NombreUsuario"].Value = TxtNombreUsuario.Text;
                    CmdAddPrm.Parameters["@Clave"].Value = TxtClave.Text;
                    CmdAddPrm.Parameters["@Fecha"].Value = DtpFecha.Value;
                    CmdAddPrm.Parameters["@IdAutoriza"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@FechaAutoriza"].Value = DateTime.Now;

                    CmdAddPrm.CommandText = "Insert Into PermisosMod (Select * From Permisos where idusuario=@idusuario)";
                    CmdAddPrm.ExecuteNonQuery();

                    CmdAddPrm.CommandText = "Update  Permisos Set Estado ='Eliminado', IdAutoriza=@IdAutoriza,FechaAutoriza=@FechaAutoriza where IdUsuario = @IdUsuario";
                    CmdAddPrm.ExecuteNonQuery();

                    CmdAddPrm.CommandText = "Update  Usuario Set Estado ='Eliminado', IdAutoriza=@IdAutoriza,FechaAutoriza=@FechaAutoriza where IdUsuario = @IdUsuario";
                    CmdAddPrm.ExecuteNonQuery();
                    myTrans.Commit();
                    MessageBox.Show("Registro Eliminado", "Eliminar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    BtnAceptar.Enabled = false;
                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Se Presento el sgte Error: " + ex.Message, "Modificar Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    FrmLogeo.MysqlConexion.Close();
                }

            }
        }

        private void MtdValidarAdd()
        {
            DatosdeErrores.Clear();
            CuentaErrores = 0;

            if (TxtUsuario.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Agregar Id de Usuario");
            }

            if (TxtNombreUsuario.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Agregar Nombre de Usuario");
            }
            if (TxtClave.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Agregar Clave");
            }

            if (TxtConfClave.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Agregar Confirmar Clave");
            }

            if (TxtConfClave.Text != TxtClave.Text)
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Confirmar Clave diferente a Clave");
            }
        }

        private void exporta_a_excel()
        {           
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;            

            excel.Cells[1, 2] = "CONSULTA GENERAL DE USUARIO";
            excel.Cells[3, 1] = "Usuario:";       
            excel.Cells[3, 2] = TxtUsuario.Text;         
            excel.Cells[3, 3] = "Nombre de Usuario:";   
            excel.Cells[3, 4] = TxtNombreUsuario.Text;
            excel.Cells[3, 5] = "Fecha:";   
            excel.Cells[3, 6] = DtpFecha.Text;
           
            foreach (DataGridViewColumn col in DgvPermisos.Columns)
            {
                ColumnIndex++;
                excel.Cells[5, ColumnIndex] = col.Name;
            }

            int rowIndex = 4;

            foreach (DataGridViewRow row in DgvPermisos.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvPermisos.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }
            }
            excel.Visible = true;

            Worksheet Libro = (Worksheet)excel.ActiveSheet;
            //Libro.Activate();
        }

        #endregion


        #region REGION DE EVENTOS

        private void Permisos_Load(object sender, EventArgs e)
        {

            MtdInicio();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (EntradaPermisos)
            {
                case "Adicionar":
                    MtdAddUsuario();
                    break;
                    

                case "Modificar":
                    MtdModUsuario();

                    break;

                case "Eliminar":
                    MtdDelUsuario();
                    break;

                

                default:

                    break;
            }
        }

      

        private void BtnEscape_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbMarcar.Checked == false)
            {
                ChbMarcar.Text = "Marcar Todos";
                MtdDatosDesMarcados();
            }
            else
            {
                ChbMarcar.Text = "Desmarcar Todos";
                MtdDatosMarcados();
            }
        }

        #endregion

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            exporta_a_excel();
        }

    }
}
