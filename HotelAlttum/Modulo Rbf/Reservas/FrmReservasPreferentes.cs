using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CarteraGeneral.Modulo_Rbf.Adjudicacion;


namespace CarteraGeneral
{
    public partial class FrmReservasPreferente : Form
    {

      #region  REGION DE VARIABLES

        public string VarTipoSemana, VarIdReserva,VarIdInmueble;
        public int EntradaReserva;
        public double valorContrato = 0;
        
        decimal CuentaErrores;
        int consecutivo = 0;
        string IdInmuebleAnt = "", VarTitular1 = "", VarTitular2 = "";

        List<string> DatosdeErrores = new List<string>();
        DataTable DtDatosReserva = new DataTable();
        DataTable DtDatosInmueble = new DataTable();

        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);

        ClsReservas NuevaVentas = new ClsReservas();         
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();        
       
        
        #endregion


        public FrmReservasPreferente()
        {
            InitializeComponent();
        }


       #region Metodos


//===================================================================================================================================================
//I N I C I O   E V E N T O    L O A D 
//===================================================================================================================================================
        private void FrmDatosReservas_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            Limpiar();
            if (EntradaReserva == 2)
            {
                LblTitulo.Text = "ADICIONAR RESERVAS " + VarTipoSemana.ToUpper();
                BtnOk.Text = "Adicionar";

            }
            if (EntradaReserva == 3)
            {
                MtdDatosMod();
                LblTitulo.Text = "MODIFICAR RESERVAS " + VarTipoSemana.ToUpper();
                BtnOk.Text = "Modificar";

            }

            if (EntradaReserva == 4)
            {
                MtdDatosMod();
                LblTitulo.Text = "CONSULTAR RESERVAS " + VarTipoSemana.ToUpper();
                BtnOk.Visible = false;
                PnlSuperior.Enabled = false;
            }
            if (EntradaReserva == 5)
            {
                MtdDatosMod();
                LblTitulo.Text = "ELIMINAR RESERVAS " + VarTipoSemana.ToUpper();
                BtnOk.Text = "Eliminar";
                PnlSuperior.Enabled = false;
            }

            if (EntradaReserva == 6)
            {
                MtdDatosMod();
                LblTitulo.Text = "DESISTIR RESERVAS " + VarTipoSemana.ToUpper();
                BtnOk.Text = "Desistir";
                PnlSuperior.Enabled = false;
            }
        }
//===================================================================================================================================================
// F I N   E V E N T O   L  O A D
//===================================================================================================================================================
 


//===================================================================================================================================================
//  I N I C I O   L I M P I A R   C O N T R O L E S
//===================================================================================================================================================
        private void Limpiar()
        {
            LblNombreTitular.Text = "";
            TxtVilla.Text = "";
            LblAsesor.Text = "";
            TxtContrato.Clear();
            TxtIdAdj.Text = "";
            TxtInmueble.Clear();
            LblTipo.Text = "";
            TxtUnidad.Text = "";
            TxtSemana.Text = "";
            TxtTitular1.Clear();
            TxtAsesor.Clear();
            TxtValor.Text = "0";
            LblTemporada.Text = "";
            DtpFecha.Value = DateTime.Now;
            DtpFechaInicio.Value = DateTime.Now;
        }
//===================================================================================================================================================
// F I N   L I M P I A R  C O N T R O L E S
//===================================================================================================================================================




//===============================================================================================================================
//I N I C I O   M E T O D O   T O M A   D E   D A T O S     P A R A   M O D I F I C A R
//===============================================================================================================================
        public void MtdDatosMod()
        {
            DtDatosReserva = NuevoClsIdentificacion.MtdBuscarDataset("Select * from Reservas where Idreserva= " + VarIdReserva + "");
            DtDatosInmueble = NuevoClsIdentificacion.MtdBuscarDataset("Select Villa,Semana,Unidad,TipodeSemana,Temporada from Inmuebles where IdInmueble = '" + VarIdInmueble + "'");
            TxtIdAdj.Text = DtDatosReserva.Rows[0][0].ToString();
            DtpFecha.Text = DtDatosReserva.Rows[0][2].ToString();
            TxtContrato.Text = DtDatosReserva.Rows[0][3].ToString();
            TxtTitular1.Text = DtDatosReserva.Rows[0][6].ToString();
            TxtAsesor.Text = DtDatosReserva.Rows[0][7].ToString();
            IdInmuebleAnt = DtDatosReserva.Rows[0][5].ToString();
            TxtInmueble.Text = DtDatosReserva.Rows[0][5].ToString();
            TxtValor.Text = DtDatosReserva.Rows[0][8].ToString();
            DtpFechaInicio.Text = DtDatosReserva.Rows[0][10].ToString();
            TxtPago1.Text = DtDatosReserva.Rows[0][9].ToString();
            TxtTitulo.Text = DtDatosReserva.Rows[0][11].ToString();
            LblNombreTitular.Text = NuevoClsIdentificacion.MtdBscDatos("select NombreCompleto from Contabilidad_alttum.Terceros where idtercero = '" + TxtTitular1.Text + "'");
            LblAsesor.Text = NuevoClsIdentificacion.MtdBscDatos("select NombreCompleto from Contabilidad_alttum.Terceros where idtercero = '" + TxtAsesor.Text + "'");
            TxtVilla.Text = DtDatosInmueble.Rows[0][0].ToString();
            TxtSemana.Text = DtDatosInmueble.Rows[0][1].ToString();
            TxtUnidad.Text = DtDatosInmueble.Rows[0][2].ToString();
            LblTipo.Text = DtDatosInmueble.Rows[0][3].ToString();
            LblTemporada.Text = DtDatosInmueble.Rows[0][4].ToString();
        }
//===============================================================================================================================
//F I N AL   M E T O D O   T O M A   D E   D A T O S     P A R A   M O D I F I C A R
//===============================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O   T O M A   D E   D A  T O S
//===================================================================================================================================================
        public void MtdTomaDatos()
        {
            NuevaVentas.idReserva = consecutivo;
            NuevaVentas.fecha = DtpFecha.Value;
            NuevaVentas.fechaInicio = DtpFechaInicio.Value;
            NuevaVentas.contrato = TxtContrato.Text;
            NuevaVentas.idProyecto = FrmLogeo.Proyecto;
            NuevaVentas.idInmueble = TxtInmueble.Text;
            NuevaVentas.idTercero1 = TxtTitular1.Text;
            NuevaVentas.idGestor = TxtAsesor.Text;
            NuevaVentas.valorContrato = Convert.ToDouble(TxtValor.Text);
            NuevaVentas.pago1 = Convert.ToDouble(TxtPago1.Text);
            NuevaVentas.letra = TxtTitulo.Text;
            NuevaVentas.fechaOperacion = DateTime.Now;
            NuevaVentas.usuario = FrmLogeo.Usuario;
            NuevaVentas.tipoReserva = VarTipoSemana;
            NuevaVentas.temporada = LblTemporada.Text;

        }
//===================================================================================================================================================
//F I N A L   M E T O D O   T O M A   D E   D A  T O S
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O   A D I C I O N A R   R E S E R V A
//===================================================================================================================================================
        public void MtdAddReserva()
        {
         
             consecutivo = Convert.ToInt16(NuevoClsIdentificacion.MtdBscDatos("select if(max(IdReserva)is null,1,max(IdReserva+1))from Reservas"));
             MtdValidarAdd();
             if (CuentaErrores > 0)
             {
                 FrmMensajeError frmMensajeError = new FrmMensajeError();
                 frmMensajeError.LblErrores.DataSource = DatosdeErrores;
                 frmMensajeError.ShowDialog();
             }
             else
             {

                 MtdTomaDatos();

                 DialogResult rest;
                 rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Reservas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                 if (rest == DialogResult.Yes)
                 {
                     string Mensaje01 = "";
                     Mensaje01 = NuevaVentas.MtdAddReservas();
                     if (Mensaje01 == "Ok")
                     {
                         BtnOk.Visible = false;
                         BtnNuevo.Visible = true;
                         PnlSuperior.Enabled = false;
                     }
                 }
             }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   A D I C I O N A R   R E S E R V A
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O   M O D I F I C A R    R E S E R V A
//===================================================================================================================================================
        public void MtdModReserva()
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
                 string Mensaje2 = "";
                 MtdTomaDatos();
                 NuevaVentas.idReserva = Convert.ToInt32(TxtIdAdj.Text);
                 NuevaVentas.idInmuebleAnterior = IdInmuebleAnt;
                 DialogResult rest;
                 rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Reservas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                 if (rest == DialogResult.Yes)
                 {
                     Mensaje2 = NuevaVentas.MtdModReservas();


                     if (Mensaje2 == "Ok")
                     {
                         BtnOk.Visible = false;
                         PnlSuperior.Enabled = false;
                     }

                 }
             }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   M O D I  F I  C A R  R E S E R V A
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O   E L I M I N A R   R E S E R V A
//===================================================================================================================================================
        public void MtdDelReserva()
        {
            NuevaVentas.idReserva = Convert.ToInt32( TxtIdAdj.Text);
            NuevaVentas.idInmueble = TxtInmueble.Text;
            NuevaVentas.tipoReserva = VarTipoSemana;
            NuevaVentas.fechaOperacion = DateTime.Now;
            NuevaVentas.usuario = FrmLogeo.Usuario;
            string Mensaje3 = "";

            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Eliminar Este Registro", "Eliminar Reservas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                Mensaje3 = NuevaVentas.MtddELReservas();


                if (Mensaje3 == "Ok")
                {                     
                    BtnOk.Visible = false;
                    PnlSuperior.Enabled = false;
                }
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  E L I M I N A R  R E S E R V A
//===================================================================================================================================================




//===================================================================================================================================================
//I N I C I O   M E T O D O   D E S I S T I R   R E S E R V A
//===================================================================================================================================================
        public void MtdDesReserva()
        {
            NuevaVentas.idReserva = Convert.ToInt32(TxtIdAdj.Text);
            NuevaVentas.idInmueble = TxtInmueble.Text;
            NuevaVentas.tipoReserva = VarTipoSemana;
            NuevaVentas.fechaOperacion = DateTime.Now;
            NuevaVentas.usuario = FrmLogeo.Usuario;
            string Mensaje3 = "";

            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Desistir Esta Reserva", "Desistir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                Mensaje3 = NuevaVentas.MtdDesReservas();


                if (Mensaje3 == "Ok")
                {                    
                    BtnOk.Visible = false;
                    PnlSuperior.Enabled = false;
                }

            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O  D E S I S T I R  R E S E R V A
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I A L   M E T O D O MtdValidarAdd
//===================================================================================================================================================
        private void MtdValidarAdd()
        {
            DatosdeErrores.Clear();
            CuentaErrores = 0;

            if (TxtInmueble.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Ingresar Inmueble");
            }

            if (TxtContrato.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Ingresar Contrato");
            }

            if (TxtTitular1.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Ingresar Cliente");
            }

            if (TxtAsesor.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Ingresar Asesor");
            }

        }
//===================================================================================================================================================
//F I N A L   M E T O D O   MtdValidarAdd
//===================================================================================================================================================




       #endregion


        #region  EVENTOS


        private void button1_Click(object sender, EventArgs e)
        {
            FrmCatalogoTerceros catalogo = new FrmCatalogoTerceros();
            catalogo.VarTipoTercero = "Clientes";
            catalogo.ShowDialog();
            TxtTitular1.Text = FrmCatalogoTerceros.VarIdTercero;
            LblNombreTitular.Text = FrmCatalogoTerceros.VarNombreTercero;
        }

        private void BtnBusqueda2_Click(object sender, EventArgs e)
        {
            FrmCatalogoTerceros catalogo = new FrmCatalogoTerceros();
            catalogo.VarTipoTercero = "Gestor";
            catalogo.ShowDialog();
            TxtAsesor.Text = FrmCatalogoTerceros.VarIdTercero;
            LblAsesor.Text = FrmCatalogoTerceros.VarNombreTercero;
        }

        private void BtnBusqueda3_Click(object sender, EventArgs e)
        {
            FrmCatalogoInmuebles inmuebles = new FrmCatalogoInmuebles();
            inmuebles.TipodeSemana = VarTipoSemana;
            inmuebles.ShowDialog();
            TxtInmueble.Text = FrmCatalogoInmuebles.VarIdInmueble;
            TxtVilla.Text = FrmCatalogoInmuebles.VarVilla;
            TxtSemana.Text = FrmCatalogoInmuebles.VarSemana;
            TxtUnidad.Text = FrmCatalogoInmuebles.VarUnidad;
            LblTipo.Text = FrmCatalogoInmuebles.VarTipoSemana;
            LblTemporada.Text = FrmCatalogoInmuebles.VarTemporada;
        }

        private void TxtValor_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {
                DtpFechaInicio.Focus();
            }



            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;


            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void TxtValor_Enter(object sender, EventArgs e)
        {
            TxtValor.BackColor = Color.White;
        }

        private void TxtValor_Leave(object sender, EventArgs e)
        {
            TxtValor.BackColor = Color.Gainsboro;
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            PnlSuperior.Enabled = true;
            Limpiar();
            BtnNuevo.Visible = false;
            BtnOk.Visible = true;
        }

        private void TxtPago1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtTitulo.Focus();
            }



            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;


            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        private void TxtPago1_Leave(object sender, EventArgs e)
        {
            TxtPago1.BackColor = Color.Gainsboro;
        }

        private void TxtPago1_Enter(object sender, EventArgs e)
        {
            TxtPago1.BackColor = Color.White;
        }    

        private void TxtTitular1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {
                VarTitular1 = NuevoClsIdentificacion.MtdBscDatos("select NombreCompleto from Contabilidad_alttum.Terceros where idtercero = '" + TxtTitular1.Text + "'");
                if (VarTitular1 == "")
                {
                    MessageBox.Show("Cliente No Existe", "Error de Terceros");
                }
                else
                {
                    LblNombreTitular.Text = VarTitular1;
                    TxtAsesor.Focus();
                }
            }
        }

        private void TxtTitular1_Enter(object sender, EventArgs e)
        {
            TxtTitular1.BackColor = Color.White;
        }

        private void TxtTitular1_Leave(object sender, EventArgs e)
        {
            TxtTitular1.BackColor = Color.Gainsboro;
        }

        private void TxtAsesor_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == '\r')
            {
                VarTitular2 = NuevoClsIdentificacion.MtdBscDatos("select NombreCompleto from Contabilidad_alttum.Terceros where idtercero = '" + TxtAsesor.Text + "'");
                if (VarTitular2 == "")
                {
                    MessageBox.Show("Cliente No Existe", "Error de Terceros");
                }
                else
                {
                    LblAsesor.Text = VarTitular2;
                    TxtInmueble.Focus();
                }

            }

        }

        private void TxtAsesor_Leave(object sender, EventArgs e)
        {
            TxtAsesor.BackColor = Color.Gainsboro;
        }

        private void TxtAsesor_Enter(object sender, EventArgs e)
        {
            TxtAsesor.BackColor = Color.White;
        }

        private void TxtInmueble_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtValor.Focus();
            }
        }

        private void TxtInmueble_Enter(object sender, EventArgs e)
        {
            TxtInmueble.BackColor = Color.White;
        }

        private void TxtInmueble_Leave(object sender, EventArgs e)
        {
            TxtInmueble.BackColor = Color.Gainsboro;
        }

        private void DtpFechaInicio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtPago1.Focus();
            }
        }

        private void TxtTitulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                BtnOk.Focus();
            }
        }

        private void TxtTitulo_Leave(object sender, EventArgs e)
        {
            TxtTitulo.BackColor = Color.Gainsboro;
        }

        private void TxtTitulo_Enter(object sender, EventArgs e)
        {
            TxtTitulo.BackColor = Color.White;
        }

        private void DtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtContrato.Focus();
            }
        }

        private void TxtContrato_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtTitular1.Focus();
            }
        }

        private void TxtContrato_Enter(object sender, EventArgs e)
        {
            TxtContrato.BackColor = Color.White;
        }

        private void TxtContrato_Leave(object sender, EventArgs e)
        {
            TxtContrato.BackColor = Color.Gainsboro;
        }          
      
        private void BtnOk_Click(object sender, EventArgs e)
        {
            valorContrato = Convert.ToDouble(TxtValor.Text);
            if (EntradaReserva == 2)
            {
                MtdAddReserva();
            }

            if (EntradaReserva == 3)
            {
                MtdModReserva();
            }
            if (EntradaReserva == 5)
            {
                MtdDelReserva();
            }
            if (EntradaReserva == 6)
            {
                MtdDesReserva();
            }
        }

        private void BtnOk_Enter(object sender, EventArgs e)
        {
            BtnOk.BackColor = Color.White;
        }

        private void BtnOk_Leave(object sender, EventArgs e)
        {
            BtnOk.BackColor = Color.Gainsboro;
        }

        private void BtnEscape_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnEscape_Enter(object sender, EventArgs e)
        {
            BtnEscape.BackColor = Color.White;
        }

        private void BtnEscape_Leave(object sender, EventArgs e)
        {
            BtnEscape.BackColor = Color.Gainsboro;
        }

        #endregion


    }
}
