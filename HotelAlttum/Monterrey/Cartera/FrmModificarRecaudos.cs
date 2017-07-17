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
    public partial class FrmModificarRecaudos : Form
    {
        public FrmModificarRecaudos()
        {
            InitializeComponent();
        }


//===============================================================================================================================  
// I N I C I O   D E   V A R I A B L E S
//===============================================================================================================================
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        public string VarIdAdjudicacion,VarIdInmueble,VarCliente;
        public int EntradaRecaudos;
        DataTable DtGrilla = new DataTable();
        DataTable DtDatos = new DataTable();
        DataTable DtRecaudos = new DataTable();
        DataTable DtParametros = new DataTable();
        string IdRecaudoDgv, Fuente, FormaPago;
        string ValorTotal = "";
        string Estado = "";
        string  TransaccionDt;
        string StrInteresCte, StrInteresMora, StrPeriodo, StrDiaMora, StrDecimales;
//===============================================================================================================================
//F I N A L   D E   V A R I A B L E S
//===============================================================================================================================



//===================================================================================================================================================
// I N I C I O  E V E N T O   L O A D
//===================================================================================================================================================
        private void FrmModRecaudos_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            DtParametros = NuevoClsIdentificacion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
            StrInteresCte = DtParametros.Rows[0][0].ToString();
            StrInteresMora = DtParametros.Rows[0][1].ToString();
            StrPeriodo = DtParametros.Rows[0][2].ToString();
            StrDiaMora = DtParametros.Rows[0][3].ToString();
            Fuente = DtParametros.Rows[0][6].ToString();            
            TxtAdjudicacion.Text = VarIdAdjudicacion;
            TxtInmueble.Text = VarIdInmueble;
            TxtNombre1.Text = VarCliente;
            CmbFormaPago.DataSource = NuevoClsIdentificacion.MtdListaCamposSent("(SELECT * FROM Contabilidad_alttum.datoscuenta WHERE IdTransaccionesAuto =1 AND (documento= '" + Fuente + "' OR documento ='PF'))", "Operacion");
          
            MtdDatosInicio();
                
        }
//===================================================================================================================================================
// F I N A L   E V E N T O   L O A D
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  E V E N T O   BtnSalir_Click
//===================================================================================================================================================
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
//===================================================================================================================================================
// F I N A L E V E N T O  BtnSalir_Click
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O S   I N I C I O
//===================================================================================================================================================
public void MtdDatosInicio()
        {
            int Opcion = EntradaRecaudos;
           TxtAdjudicacion.Text = VarIdAdjudicacion;
            string Sentencia2 = "Select d.IdRecaudo,d.Transaccion, d.NumRecibo,d.Fecha ,d.Operacion,d.Valor as Total " +
            "From datosrecaudos d Where  d.idadjudicacion =" + TxtAdjudicacion.Text + " order by d.NumRecibo";
            DtGrilla = NuevoClsIdentificacion.MtdBuscarDataset(Sentencia2);
            MtdDatosGrilla();
         
            DtpFecha.Focus();

            switch (EntradaRecaudos)
            {

                case 3:

                    break;

                case 4:
                    CmbFormaPago.Enabled = false;
                    BtnAceptar.Text = "Eliminar";
                    LblTitulo.Text = "ELIMINAR RECAUDOS";
                    TxtidRecaudo.ReadOnly = true;
                    DtpFecha.Enabled = false;
                    TxtRecibo.ReadOnly = true;

                    break;

                default:

                    break;
            }
        }
//===================================================================================================================================================
// F I N   M E T O D O   D A T O  S   I N I C I O
//===================================================================================================================================================





//===================================================================================================================================================
//I N I C I O    M E T O D O   O C U L T A R
//===================================================================================================================================================
public void MtdOcultar()
        {
            TxtValor.Enabled = false;            
            LblValor.ForeColor = Color.Black;          
            TxtValor.Text = "0";
           
        }
//===================================================================================================================================================
//F I N A L  M E T O D O   O C U L T A R
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   D A T O  S   G R I L L A
//===================================================================================================================================================
        public void MtdDatosGrilla()
        {
            DgvDatosRecaudos.Rows.Clear();
            for (int i = 0; i < (DtGrilla.Rows.Count); i++)
            {
                DgvDatosRecaudos.Rows.Add(DtGrilla.Rows[i][0], DtGrilla.Rows[i][1], DtGrilla.Rows[i][2], DtGrilla.Rows[i][3], DtGrilla.Rows[i][4],
                DtGrilla.Rows[i][5]);
            }           
        }
//===================================================================================================================================================
// F I N   M E T O D O   D A T O  S   G R I L L A
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O    M E T O D O   V A L I D A R   F E C H A
//===================================================================================================================================================
        public string MtdVldFch(DateTime fecha)
        {
            string ano, mes, dia, Varfecha;
            ano = Convert.ToString(fecha.Year);
            mes = Convert.ToString(fecha.Month);
            dia = Convert.ToString(fecha.Day);
            Varfecha = ano + "-" + mes + "-" + dia;
            return Varfecha;
        }
//===================================================================================================================================================
//F I N A L   V A L I D A R   F  E C H A
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O  M E T O D  O  M O D I F I C A R   R E C A U D O S
//===================================================================================================================================================
        public void MtdModRecaudos()
        {
            string Periodo = NuevoClsIdentificacion.MtdBscDatos("select EXTRACT(YEAR_MONTH from '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "')");
            string ModDatoReacaudos = "Update datosrecaudos set NumRecibo =@Recibo , FormaPago=@FormaPago, Fecha = @Fecha,Usuario=@Usuario,FechaOperacion=@FechaOperacion Where IdRecaudo = @IdRecaudo";

            string ModRecaudos = "Update Recaudos Set Fecha = @Fecha, Recibo =@Recibo,Periodo=@Periodo,Usuario=@Usuario,FechaOperacion=@FechaOperacion Where IdRecaudo = @IdRecaudo";


            string ModDiario = "Update Contabilidad_alttum.diario Set Fecha=@Fecha, Cheque =@Recibo,Periodo=@Periodo Where Transaccion = @Transaccion";
           
            FrmLogeo.MysqlConexion.Open();
            MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;
            myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
            myCommand.Connection = FrmLogeo.MysqlConexion;
            myCommand.Transaction = myTrans;

            try
            {
                myCommand.Parameters.Add("@IdRecaudo", MySql.Data.MySqlClient.MySqlDbType.Int32);              
                myCommand.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@Recibo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Transaccion", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@FormaPago", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@Periodo", MySql.Data.MySqlClient.MySqlDbType.Int32);

                myCommand.Parameters["@IdRecaudo"].Value = Convert.ToInt32(TxtidRecaudo.Text);
                myCommand.Parameters["@Fecha"].Value = DtpFecha.Value;
                myCommand.Parameters["@Recibo"].Value = TxtRecibo.Text;
                myCommand.Parameters["@FormaPago"].Value = CmbFormaPago.Text;
                myCommand.Parameters["@Usuario"].Value = FrmLogeo.FrmUsuarioIdUsr;
                myCommand.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                myCommand.Parameters["@Transaccion"].Value = TransaccionDt;              
                myCommand.Parameters["@Periodo"].Value = Convert.ToInt32(Periodo);



                myCommand.CommandText = ModDatoReacaudos;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = ModRecaudos;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = ModDiario;
                myCommand.ExecuteNonQuery();
                myTrans.Commit();
                MessageBox.Show("Registro Modificado " , "Modificar Recaudos", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                BtnAceptar.Enabled = false;

            }
            catch (Exception e)
            {
                myTrans.Rollback();
                MessageBox.Show("Ocurrio el sgte Error: "+ e.Message, "Modificar Recaudos", MessageBoxButtons.OK, MessageBoxIcon.Error);                 
            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
            }            
        }
//===================================================================================================================================================
//F I N A L M E T O D  O  M O D I F I C A R   R E C A U D O S
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O  M E T O D  O  E L I M I N A R   R E C A U D O S
//===================================================================================================================================================
        public void MtdDelRecaudos()
        {
            string Periodo = NuevoClsIdentificacion.MtdBscDatos("select EXTRACT(YEAR_MONTH from '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFecha.Value) + "')");
            string ModDatoReacaudos = "Delete FROM datosrecaudos  Where IdRecaudo = @IdRecaudo";

            string ModRecaudos = "Delete FROM Recaudos  Where IdRecaudo = @IdRecaudo";

            string DelDiario = "Update Contabilidad_alttum.Diario set Estado =3 Where Transaccion = @Transaccion";

            string ActDelRecaudo = "UPDATE recaudoeliminado  SET UsuarioElimina = '" + FrmLogeo.Usuario + "'  WHERE IdRecaudo = '" + TxtidRecaudo.Text + "'"; 

            FrmLogeo.MysqlConexion.Open();
            MySqlCommand myCommand = FrmLogeo.MysqlConexion.CreateCommand();
            MySqlTransaction myTrans;

            myTrans = FrmLogeo.MysqlConexion.BeginTransaction();
            myCommand.Connection = FrmLogeo.MysqlConexion;


            myCommand.Transaction = myTrans;

            try
            {
                myCommand.Parameters.Add("@IdRecaudo", MySql.Data.MySqlClient.MySqlDbType.Int32);                
                myCommand.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@Recibo", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@Transaccion", MySql.Data.MySqlClient.MySqlDbType.Int32);
                myCommand.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@FormaPago", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                myCommand.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                myCommand.Parameters.Add("@Periodo", MySql.Data.MySqlClient.MySqlDbType.Int32);

                myCommand.Parameters["@IdRecaudo"].Value = Convert.ToInt32(TxtidRecaudo.Text);
                myCommand.Parameters["@Fecha"].Value = DtpFecha.Value;
                myCommand.Parameters["@Recibo"].Value = TxtRecibo.Text;
                myCommand.Parameters["@FormaPago"].Value = CmbFormaPago.Text;
                myCommand.Parameters["@Usuario"].Value = FrmLogeo.FrmUsuarioIdUsr;
                myCommand.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                myCommand.Parameters["@Transaccion"].Value = TransaccionDt;              
                myCommand.Parameters["@Periodo"].Value = Convert.ToInt32(Periodo);

                myCommand.CommandText = ModRecaudos;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = ModDatoReacaudos;
                myCommand.ExecuteNonQuery();
                myCommand.CommandText = DelDiario;
                myCommand.ExecuteNonQuery();

                myCommand.CommandText = ActDelRecaudo;
                myCommand.ExecuteNonQuery();

                myTrans.Commit();

                MessageBox.Show("Recaudo Eliminado", "Recaudo Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);               
                MtdDatosInicio();

            }
            catch (Exception e)
            {
                myTrans.Rollback();
                MessageBox.Show("Ha Ocurrido el Sgte Error: "+e.Message, "Recaudo Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                 
            }
            finally
            {
                FrmLogeo.MysqlConexion.Close();
              
            }

            
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  E L I M I N A R   R E C A U D O S
//===================================================================================================================================================




//===================================================================================================================================================
//I N I C I O   E V E N T O   DgvDatosRecaudos_CellEnter
//===================================================================================================================================================
        private void DgvDatosRecaudos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            MtdOcultar();
            int C = DgvDatosRecaudos.Rows.Count;
            IdRecaudoDgv = DgvDatosRecaudos.Rows[e.RowIndex].Cells[0].Value.ToString();
            ValorTotal = DgvDatosRecaudos.Rows[e.RowIndex].Cells[4].Value.ToString();
            TransaccionDt = DgvDatosRecaudos.Rows[e.RowIndex].Cells[1].Value.ToString();
            DtRecaudos = NuevoClsIdentificacion.MtdBuscarDataset("Select * From datosrecaudos WHERE IdRecaudo = '" + IdRecaudoDgv + "'");


            TxtidRecaudo.Text = DtRecaudos.Rows[0][0].ToString();
        
            DtpFecha.Text = DtRecaudos.Rows[0][2].ToString();
            TxtRecibo.Text = DtRecaudos.Rows[0][3].ToString();
            CmbFormaPago.Text = DtRecaudos.Rows[0][8].ToString();
            TxtOperacion.Text = DtRecaudos.Rows[0][5].ToString();
            TxtCodBanco.Text = DtRecaudos.Rows[0][7].ToString();
            TxtValor.Text = DtRecaudos.Rows[0][6].ToString();
            FormaPago = CmbFormaPago.Text;  
            
        
        }
//===================================================================================================================================================
///F I N A L  E V E N T O DgvDatosRecaudos_CellEnter
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O E V E N T O CmbFormaPago_SelectedIndexChanged
//===================================================================================================================================================
        private void CmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            MtdOcultar();            
            
            Estado = "Aprobado";
            switch (FormaPago)
            {


                case "Cheque":
                    Estado = "Pendiente";
                    break;
                

               
                default:

                    break;

            }
        }
//===================================================================================================================================================
//F I N A L E V E N T O CmbFormaPago_SelectedIndexChanged
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   A C E P T A R
//===================================================================================================================================================
private void BtnAceptar_Click(object sender, EventArgs e)
        {
            int Opcion1 = EntradaRecaudos;
            switch (Opcion1)
            {
                case 3:
                    DialogResult Mod;
                    Mod = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Recaudos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Mod == DialogResult.Yes)
                    {
                        MtdModRecaudos();
                        MtdDatosInicio();
                    }
                    break;

                case 4:
                    DialogResult Del;
                    Del = MessageBox.Show("Esta seguro de Eliminar Este Registro", "Eliminar Recaudos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Del == DialogResult.Yes)
                    {
                        MtdDelRecaudos();
                    }
                    break;

                default:

                    break;
            }

        }
//===================================================================================================================================================
//F I N A L   A C E P T A R
//===================================================================================================================================================
 

    }
}
