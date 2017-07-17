using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace CarteraGeneral
{
    public partial class FrmEnvioEscrituracion : Form
    {
        public FrmEnvioEscrituracion()
        {
            InitializeComponent();
        }
        string Estado;
        public string VarIdAdjudicacion,VarCliente,Opciones,EntradaDocumentacion;
        ClsIdentificacion clsidentificacion = new ClsIdentificacion();
        string MensajeSalida;


//===================================================================================================================================================
// I N I C I O   E V E N T O    FrmEnvioEscrituracion_Load
//===================================================================================================================================================
        private void FrmEnvioEscrituracion_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = FrmMenuGeneral.Logo;
            TxtAdjudicacion.Text = VarIdAdjudicacion;
            Estado = clsidentificacion.MtdBscDatos("Select Estado From Adjudicacion where idadjudicacion= '" + TxtAdjudicacion.Text + "'");

            TxtCliente.Text = VarCliente;
            switch (Opciones)
            {

                case "Tramite":
                    LblTitulo.Text = "ENVIAR NEGOCIOS A TRAMITE ";
                break;

                case "Escriturado":
                LblTitulo.Text = "ENVIAR NEGOCIOS ESCRITURADO";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
                  break;


                case "Archivado":
                    LblTitulo.Text = "ENVIAR NEGOCIOS ARCHIVOS";
                    RtbComentario.Visible = false;
                    LblComentario.Visible = false;
                break;
                case "Cerrado":
                LblTitulo.Text = "ARCHIVAR NEGOCIOS";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
                break;

                case "Juridico":
                LblTitulo.Text = "ENVIAR NEGOCIOS JURIDICO";            
                break;

                case "DesistidoJuridico":
                LblTitulo.Text = "ENVIAR DESISTIDOS A JURIDICO";            
                break;
                    


                case "Devolver":
                LblTitulo.Text = "DEVOLVER NEGOCIOS A CARTERA";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
                break;
                
                case "Aceptar":
                LblTitulo.Text = "ACEPTAR DOCUMENTOS";
                BtnEnviar.Text = "Aceptar";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
                break;

                    

                case "DvPagado":
                LblTitulo.Text = "DEVOLVER NEGOCIO A PAGADO";
                BtnEnviar.Text = "Devolver";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
                break;

                case "DvTramite":
                LblTitulo.Text = "DEVOLVER NEGOCIO A TRAMITE";
                BtnEnviar.Text = "Devolver";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
                break;

                case "DvEscriturado":
                LblTitulo.Text = "DEVOLVER NEGOCIO A ESCRITURADO";
                BtnEnviar.Text = "Devolver";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
                break;

               
                case "DvAprobado":
                LblTitulo.Text = "DEVOLVER NEGOCIO A CARTERA";
                BtnEnviar.Text = "Devolver";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
                break;

                case "DvDesistido":
                LblTitulo.Text = "DEVOLVER NEGOCIO A DESISTIDO";
                BtnEnviar.Text = "Devolver";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
                break;

                case "DvJuridico":
                    LblTitulo.Text = "DEVOLVER NEGOCIO A JURIDICO";
                BtnEnviar.Text = "Devolver";
                RtbComentario.Visible = false;
                LblComentario.Visible = false;
               
                break;
                default:
                break;



            }

             
        }
//===================================================================================================================================================
// F I N A L  E V E N T O   FrmEnvioEscrituracion_Load
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   E V E N T O    BtnEnviar_Click
//===================================================================================================================================================
        private void BtnEnviar_Click(object sender, EventArgs e)
        {

            switch (Opciones)
            {

                case "Tramite":
                    MtdTramite();
                    break;

                case "Escriturado":
                    MtdEscriturado();
                    break;

                case "Archivado":
                    MtdAarchivado();
                    break;
                case "Cerrado":
                    MtdCerrado();
                    break;
                case "Juridico":
                    MtdJuridico();
                    break;

                case "DesistidoJuridico":
                    MtdDesJuridico();
                    break;
                

                case "DvPagado":
                    MtdDevolve();
                    break;
                case "DvTramite":
                    MtdDevolve();
                    break;

                case "DvEscrituado":
                    MtdDevolve();
                    break;

                case "DvAprobado":
                    MtdDevolverCar();
                    break;

                case "DvDesistido":
                    MtdDevolverDes();
                    break;

                case "DvJuridico":
                    MtdDevolverCar();
                    break;
                case "Aceptar":
                    MtdAceptar();
                    break;

                default:
                    break;
            }


        }
//===================================================================================================================================================
// F I N A L  E V E N T O   BtnEnviar_Click
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   E V E N T O    BtnSalir_Click
//===================================================================================================================================================
    private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
//===================================================================================================================================================
// F I N A L  E V E N T O   BtnSalir_Click
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O   M E T O D O     T R A M I T E
//===================================================================================================================================================
        public void MtdTramite()
        {            
            //Es eenviado por el auxiliar de cartera una vez el credito es pagado en su totalidad
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Eviar a Tramite Escritura", "Enviar Tramite Escritura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string UpdateDocumentacion = "Update documentacion set estado = @Operacion,  FechaCierre =@Fecha, UsuarioCierra = @UsuarioEnvio where id = @Id ";
            string AddDocumentacion = "insert into documentacion (fecha,FechaRecibe,Operacion,IdAdjudicacion,UsuarioEnvio,Estado) VALUES  (@fecha,@FechaRecibe,@Operacion,@IdAdjudicacion,@UsuarioEnvio,@Estado)";
               

                if (rest == DialogResult.Yes)
                {
                  
                    MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);   
                    MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                    MysqlConexion.Open();
                    MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                    MySqlTransaction myTrans;
                    myTrans = MysqlConexion.BeginTransaction();
                    CmdAddPrm.Connection = MysqlConexion;
                    CmdAddPrm.Transaction = myTrans;
                    try
                    {
                         
                        CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                        CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                        CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                        CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                        CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                        CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                        CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                        CmdAddPrm.Parameters["@Operacion"].Value = "Tramite Escritura";
                        CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                        CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                        CmdAddPrm.Parameters["@Estado"].Value = "Enviado";
                        
                        CmdAddPrm.CommandText = UpdateDocumentacion;
                        CmdAddPrm.ExecuteNonQuery();

                        CmdAddPrm.CommandText = AddDocumentacion;
                        CmdAddPrm.ExecuteNonQuery();

                        myTrans.Commit();
                        BtnEnviar.Enabled = false;
                        MessageBox.Show("Registro Enviado", "Enviar Tramite Escritura", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        
                    }
                    catch (MySqlException ex)
                    {
                        myTrans.Rollback();
                        MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Enviar Tramite Escritura", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    finally
                    {
                        MysqlConexion.Close();

                    }
                }
            
        }
//===================================================================================================================================================
// F I N A L  M E T O D O     T R A M I T E
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O   M E T O D O   E S C R I T U R A D O 
//===================================================================================================================================================
        public void MtdEscriturado()
        {
            //Es eenviado por el auxiliar de cartera una vez el credito es pagado en su totalidad
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Eviar a Escrituracion", "Enviar Escrituracion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string UpdateDocumentacion = "Update documentacion set estado = @Operacion,  FechaCierre =@Fecha, UsuarioCierra = @UsuarioEnvio where id = @Id ";
            string AddDocumentacion = "insert into documentacion (fecha,FechaRecibe,Operacion,IdAdjudicacion,UsuarioEnvio,Estado) VALUES  (@fecha,@FechaRecibe,@Operacion,@IdAdjudicacion,@UsuarioEnvio,@Estado)";


            if (rest == DialogResult.Yes)
            {

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {

                    CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Operacion"].Value = "Escriturado";
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@Estado"].Value = "Enviado";

                    CmdAddPrm.CommandText = UpdateDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    CmdAddPrm.CommandText = AddDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    myTrans.Commit();
                    BtnEnviar.Enabled = false;
                    MessageBox.Show("Registro Enviado", "Enviar a Escrituracion", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Enviar a Escrituracion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }
            
        }
//===================================================================================================================================================
// F I N A L  M E T O D O   E S C R I T U R A D O
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O    A R C H I V A D O
//===================================================================================================================================================
        public void MtdAarchivado()
        {
           
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Enviar a  Archivo", "Enviar a Achivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string UpdateDocumentacion = "Update documentacion set estado = @Operacion,  FechaCierre =@Fecha, UsuarioCierra = @UsuarioEnvio where id = @Id ";
            string AddDocumentacion = "insert into documentacion (fecha,FechaRecibe,Operacion,IdAdjudicacion,UsuarioEnvio,Estado) VALUES  (@fecha,@FechaRecibe,@Operacion,@IdAdjudicacion,@UsuarioEnvio,@Estado)";


            if (rest == DialogResult.Yes)
            {

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {

                    CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Operacion"].Value = "Archivado";
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@Estado"].Value = "Enviado";

                    CmdAddPrm.CommandText = UpdateDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    CmdAddPrm.CommandText = AddDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    myTrans.Commit();
                    BtnEnviar.Enabled = false;
                    MessageBox.Show("Registro Enviado", "Enviar a Achivo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Enviar a Achivo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }
        }      
//===================================================================================================================================================
// F I N A L  M E T O D O   A R C H I V A D O
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   C E R R A D O
//===================================================================================================================================================
        public void MtdCerrado()
        {          

            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Archivar", "Archivar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string UpdateDocumentacion = "Update documentacion set estado = @Operacion,  FechaCierre =@Fecha, UsuarioCierra = @UsuarioEnvio where id = @Id ";
            string UpdateAdjudicacion = "Update Adjudicacion set Estado =@Estado Where IdAdjudicacion=@IdAdjudicacion";


            if (rest == DialogResult.Yes)
            {

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {

                    CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Operacion"].Value = "Cerrado";
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@Estado"].Value = "Archivado";

                    CmdAddPrm.CommandText = UpdateDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    CmdAddPrm.CommandText = UpdateAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();

                    myTrans.Commit();
                    BtnEnviar.Enabled = false;
                    MessageBox.Show("Registro Enviado", "Enviar a Achivo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Enviar a Achivo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }

            
        }
//===================================================================================================================================================
// F I N A L  M E T O D O  C E R R A D O
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   A C E P T A R  
//===================================================================================================================================================
        public void MtdAceptar()
        {
            
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Aceptar ", " Aceptar ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string UpdateDocumentacion = "Update documentacion set estado = @Estado,  FechaRecibe =@Fecha , UsuarioRecibe= @UsuarioEnvio where id = @Id";
            string UpdateAdjudicacion = "";

            if (Estado == "Desistido")
            {
                UpdateAdjudicacion = "update Adjudicacion set Estado  = 'DesistidoJuridico',FechaOperacion =@Fecha,Usuario = @UsuarioEnvio where idadjudicacion =@idadjudicacion";
            }
            else
            {
                UpdateAdjudicacion = "update Adjudicacion set Estado  = @Operacion,FechaOperacion =@Fecha,Usuario = @UsuarioEnvio where idadjudicacion =@idadjudicacion";
            }
          

            if (rest == DialogResult.Yes)
            {

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {

                    CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Operacion"].Value = EntradaDocumentacion;
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@Estado"].Value = "Aceptado";

                    CmdAddPrm.CommandText = UpdateDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    CmdAddPrm.CommandText = UpdateAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();

                    myTrans.Commit();
                    BtnEnviar.Enabled = false;
                    MessageBox.Show("Registro Enviado", EntradaDocumentacion, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + EntradaDocumentacion, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }


        }
//===================================================================================================================================================
// F I N A L     M E T O D O   A C E P T A R  
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O   M E T O D O     J U R I D I C O
//===================================================================================================================================================
        public void MtdJuridico()
        {
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Enviar Juridico", "Enviar Juridico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);            
            
            string AddDocumentacion = "insert into documentacion (fecha,FechaRecibe,Operacion,IdAdjudicacion,UsuarioEnvio,Estado) VALUES  (@fecha,@FechaRecibe,@Operacion,@IdAdjudicacion,@UsuarioEnvio,@Estado)";


            if (rest == DialogResult.Yes)
            {

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {

                    CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Operacion"].Value = "Juridico";
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@Estado"].Value = "Enviado";

                  
                    CmdAddPrm.CommandText = AddDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    myTrans.Commit();
                    BtnEnviar.Enabled = false;
                    MessageBox.Show("Registro Enviado", "Enviar Juridico", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Enviar Juridico", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }

        }
//===================================================================================================================================================
// F I N A L    M E T O D O     J U R I D I C O 
//===================================================================================================================================================






//===================================================================================================================================================
// I N I C I O   M E T O D O  D E S I S T I D O S   A    J U R I D I  C O
//===================================================================================================================================================
        public void MtdDesJuridico()
        {
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Enviar Juridico", "Enviar Desistido Juridico", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string AddDocumentacion = "insert into documentacion (fecha,FechaRecibe,Operacion,IdAdjudicacion,UsuarioEnvio,Estado) VALUES  (@fecha,@FechaRecibe,@Operacion,@IdAdjudicacion,@UsuarioEnvio,@Estado)";
            
            if (rest == DialogResult.Yes)
            {

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {
                    CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Operacion"].Value = "DesistidoJuridico";
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@Estado"].Value = "Enviado";

                    CmdAddPrm.CommandText = AddDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    myTrans.Commit();
                    BtnEnviar.Enabled = false;
                    MessageBox.Show("Registro Enviado", "Enviar Desistido Juridico", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Enviar Desistido Juridico", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();
                }
            }
        }
//===================================================================================================================================================
// F I N A L    M E T O D O   D E S I S T I D O S  A  J U R I D I C O 
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   D E V O L V E R   A   C A R T E R A
//===================================================================================================================================================
        public void MtdDevolverCar()
        {
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Enviar Cartera", "Enviar a Cartera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string UpdAdjudicacion = "Update Adjudicacion set Estado = @Estado, FechaOperacion = @Fecha, Usuario = @UsuarioEnvio where idadjudicacion = @idadjudicacion";
            string AddDocumentacion = "Update Documentacion Set Estado=@Operacion,FechaCierre =@Fecha, UsuarioCierra=@UsuarioEnvio Where Id=@Id ";

            if (rest == DialogResult.Yes)
            {

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {

                    CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Operacion"].Value = "Cartera";
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@Estado"].Value = "Aprobado";


                    CmdAddPrm.CommandText = AddDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    CmdAddPrm.CommandText = UpdAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();


                    myTrans.Commit();
                    BtnEnviar.Enabled = false;
                    MessageBox.Show("Registro Enviado", "Enviar a Cartera", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Enviar a Cartera", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }
                          
        }
//===================================================================================================================================================
// F I N A L  B O T O N   D E V O L V E R   A   C A R T E R  A
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   D E V O L V E R   A   D E S I S T I D O 
//===================================================================================================================================================
        public void MtdDevolverDes()
        {

            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Enviar Juridico", "Enviar a Desistido", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            string UpdAdjudicacion = "Update Adjudicacion set Estado = @Estado, FechaOperacion = @Fecha, Usuario = UsuarioEnvio where idadjudicacion = @idadjudicacion";
            string AddDocumentacion = "Update Documentacion Set Estado=@Operacion,FechaCierre =@FechaCierre, UsuarioCierre=@UsuarioEnvio Where Id=@Id ";

            if (rest == DialogResult.Yes)
            {

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {

                    CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Operacion"].Value = "Cartera";
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@Estado"].Value = "Desistido";


                    CmdAddPrm.CommandText = AddDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    CmdAddPrm.CommandText = UpdAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();


                    myTrans.Commit();
                    BtnEnviar.Enabled = false;
                    MessageBox.Show("Registro Enviado", "Enviar a Desistido", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Enviar a Desistido", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }
        }
//===================================================================================================================================================
// F I N A L  B O T O N   D E V O L V E R   A   D E S I S T I D O 
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   D E V O L V E R  
//===================================================================================================================================================
        public void MtdDevolve()
        {
            
            DialogResult rest;
            rest = MessageBox.Show("Esta seguro De Enviar Cartera", "Enviar a Cartera", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            string VarOperacion="";
            string UpdateAdjudicacion = "Update Adjudicacion Set Estado=@Operacion,FechaOperacion=@Fecha,Usuario=@UsuarioEnvio Where IdAdjudicacion=@IdAdjudicacion";
            string UpdateDocumentacion1=  "Update documentacion set estado = @Estado,  FechaCierre =@Fecha,UsuarioCierra=@UsuarioEnvio where id = @Id";
            string UpdateDocumentacion = "";

                switch (Opciones)
                {

                    case "DvPagado":
                    VarOperacion="Pagado";

                    UpdateDocumentacion = "Update documentacion set estado = 'Aceptado',  FechaCierre = @Fecha Where idAdjudicacion = @IdAdjudicacion  And Operacion ='Pagado'";
                            
                    MensajeSalida= "La Adjudicacion ha sido devuelta a Pagado";
                    break;
                    case "DvTramite":
                    VarOperacion="Tramite Escritura";
                        
                            
                    UpdateDocumentacion = "Update documentacion set estado = 'Aceptado',  FechaCierre = @Fecha Where idAdjudicacion = @IdAdjudicacion  And Operacion =' And Operacion ='Tramite Escritura'";
                         
                            
                    MensajeSalida= "La Adjudicacion ha sido devuelta a Tramite Escritura";
                    break;
                          
                    case "DvEscrituado":
                    VarOperacion="Escriturado";
                          

                    UpdateDocumentacion = "Update documentacion set estado = 'Aceptado',  FechaCierre = @Fecha Where idAdjudicacion = @IdAdjudicacion  And Operacion = ' And Operacion ='Escriturado'";
                        
                    MensajeSalida= "La Adjudicacion ha sido devuelta a Escriturado";
                    break;
                    default:
                    break;


                }

            if (rest == DialogResult.Yes)
            {

                MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                MysqlConexion.Open();
                MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                MySqlTransaction myTrans;
                myTrans = MysqlConexion.BeginTransaction();
                CmdAddPrm.Connection = MysqlConexion;
                CmdAddPrm.Transaction = myTrans;
                try
                {

                    CmdAddPrm.Parameters.Add("@Id", MySql.Data.MySqlClient.MySqlDbType.Int32);
                    CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@FechaRecibe", MySql.Data.MySqlClient.MySqlDbType.Date);
                    CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                    CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                    CmdAddPrm.Parameters["@Id"].Value = FrmDocumentacion.IdDocumentacion;
                    CmdAddPrm.Parameters["@Fecha"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@FechaRecibe"].Value = DateTime.Now.Date;
                    CmdAddPrm.Parameters["@Operacion"].Value = VarOperacion;
                    CmdAddPrm.Parameters["@IdAdjudicacion"].Value = TxtAdjudicacion.Text;
                    CmdAddPrm.Parameters["@UsuarioEnvio"].Value = FrmLogeo.Usuario;
                    CmdAddPrm.Parameters["@Estado"].Value = "Devuelto";


                    CmdAddPrm.CommandText = UpdateDocumentacion1;
                    CmdAddPrm.ExecuteNonQuery();

                       CmdAddPrm.CommandText = UpdateDocumentacion;
                    CmdAddPrm.ExecuteNonQuery();

                    CmdAddPrm.CommandText = UpdateAdjudicacion;
                    CmdAddPrm.ExecuteNonQuery();

                    myTrans.Commit();
                    BtnEnviar.Enabled = false;
                    MessageBox.Show( MensajeSalida, "Registro Devuelto", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    myTrans.Rollback();
                    MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Registro Devuelto", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    MysqlConexion.Close();

                }
            }

            

        }
//===================================================================================================================================================
// F I N A L  B O T O N   D E V O L V E R   A   C A R T E R  A
//===================================================================================================================================================


        
    }
}
