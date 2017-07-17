using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarteraGeneral
{
    public partial class FrmGestor : Form
    {
        public FrmGestor()
        {
            InitializeComponent();
        }

        #region REGION DE VARIABLES

        public int EntradaTerceros;
        public string VarIdTerceros;
        System.Data.DataTable DtListado = new System.Data.DataTable();
        DataTable DtDatos = new DataTable();
        Terceros terceros = new Terceros();
        ClsIdentificacion conexion = new ClsIdentificacion();
        string DatosInsertar = "";
        List<string> DatosdeErrores = new List<string>();
        double CuentaErrores;

        #endregion


        #region REGION DE EVENTOS

//===================================================================================================================================================
//I N I C I O  D E  E V E N T O   L O A D 
//===================================================================================================================================================
        private void FrmTerceros_Load(object sender, EventArgs e)
        {
            switch (EntradaTerceros)
            {
                case 2:

                    PnlSuperior.Enabled = true;
                    LblTitulo.Text = "ADICIONAR GESTORES";
                    TxtIdentificacion.Enabled = true;
                    TxtIdentificacion.Focus();
                    BtnOk.Text = "Adicionar";

                    break;
                case 3:
                    PnlSuperior.Enabled = true;
                    Activar();
                    TxtIdentificacion.Text = VarIdTerceros;
                    LblTitulo.Text = "MODIFICAR GESTORES";
                    BtnOk.Text = "Modificar";
                    MtdBuscarDatos();
                    break;


                case 4:
                    TxtIdentificacion.Text = VarIdTerceros;
                    LblTitulo.Text = "ELIMINAR GESTORES";
                    PnlSuperior.Enabled = true;
                    MtdBuscarDatos();

                    BtnOk.Text = "Eliminar";
                    break;

                case 5:
                    TxtIdentificacion.Text = VarIdTerceros;
                    LblTitulo.Text = "CONSULTAR GESTORES";
                    MtdBuscarDatos();
                    PnlSuperior.Enabled = true;
                    break;


                default:

                    break;
            }
        }
//===================================================================================================================================================
//F I N A L   D E   E V E N T O   L O A D
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O  D E  E V E N T O  BtnEscape_Click
//===================================================================================================================================================
        private void BtnEscape_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Hide();
        }
//===================================================================================================================================================
//F I N A L   D E   E V E N T O   BtnEscape_Click
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O  E V E N T O   F O R M   C L O S E D
//==================================================================================================================================================
        private void FrmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            EntradaTerceros = 0;
        }
//===================================================================================================================================================
//F I N A L   E V E N T O   F O R M   C L O S E D
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   B O T O N   A C E P T A R
//===================================================================================================================================================
        private void BtnOk_Click_1(object sender, EventArgs e)
        {
            MtdValidar();
            MtdConcatenar();
            switch (EntradaTerceros)
            {
                case 2:
                    MtdAdicionar();

                    break;

                case 3:
                    MtdModificar();
                    break;

                case 4:
                    MtdEliminar();
                    break;

                default:

                    break;
            }
        }
//===================================================================================================================================================
// F I N A L   B O T O N   A C E P T A R
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   B O T O N   N U E V O
//===================================================================================================================================================
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            TxtIdentificacion.Clear();
            panel1.Enabled = true;
            TxtIdentificacion.Enabled = true;
            TxtIdentificacion.Focus();
        }
//===================================================================================================================================================
//F I N A L   D E  B O T O N   N U E  V O
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O  V A L I D A R   I D T E R C E R O 
//===================================================================================================================================================
        private void TxtIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (EntradaTerceros == 2)
            {
                if (e.KeyChar == '\r')
                {
                    if (TxtIdentificacion.Text != "")
                    {
                        MtdValidarTerceros();
                    }
                }
            }
        }
//===================================================================================================================================================
//F I N A L  V A L I D A R   I D T E R C E R O  
//===================================================================================================================================================

        #endregion


        #region REGION DE METODOS

        //===================================================================================================================================================
        // I N I C I O   M E T O D O   V A L I D A R   
        //===================================================================================================================================================
        private void MtdValidar()
        {
            DatosdeErrores.Clear();
            CuentaErrores = 0;

            if (CmbTipoTercero.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccionar Clase Tercero");
            }

            if (CmbCtaRetencion.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Seleccionar Retencion");
            }

            if (TxtRetencion.Text == "")
            {
                CuentaErrores = CuentaErrores + 1;
                DatosdeErrores.Add("Falta Valor Retencion");
            }


        }
        //===================================================================================================================================================
        // F I N A L    M E T O D O   V A L I D A R  
        //===================================================================================================================================================



        //===================================================================================================================================================
        //I N I C I O   M E T O D O   C A P T U R A   D A T O S
        //===================================================================================================================================================
        private void MtdCaptura()
        {

            terceros.cargo="Asesor";
            if (CmbCtaRetencion.Text == "Empleado")
            {
                terceros.cuenta = "23652001";
            }
            else
                if (CmbCtaRetencion.Text == "Independiente")
            {
                terceros.cuenta = "26051001";
            }

            terceros.alta = DtpAlta.Value;
            terceros.apellido2 = TxtApellido2.Text;
            terceros.barrio = TxtBarrio.Text;
            terceros.celular = TxtCelular.Text;
            terceros.ciudad = TxtCiudad.Text;
            terceros.contacto = TxtContacto.Text;
            terceros.direccion = TxtDireccion.Text;
            terceros.dpto = TxtDpto.Text;
            terceros.email = TxtEmail.Text;
            terceros.fechaNac = DtpFechaNaci.Value;
            terceros.idTercero = TxtIdentificacion.Text;
            terceros.nombre1 = TxtNombre1.Text;
            terceros.nombre2 = Txtnombre2.Text;
            terceros.paginaWeb = TxtPaginaWeb.Text;
            terceros.telefono1 = TxtTelefono1.Text;
            terceros.telefono2 = TxtTelefono2.Text;
            terceros.usuario = FrmLogeo.FrmUsuarioIdUsr;
            terceros.fechaOperacion = DateTime.Now;
            terceros.tipoTercero = CmbTipoTercero.Text;
            terceros.nombrecompleto = TxtNombreCompleto.Text;
            terceros.retencion=Convert.ToDouble(TxtRetencion.Text);
            
            if (CmbTipoPersona.Text == "Persona Natural")
            {
                terceros.tipoPersona = 1;
                terceros.apellido1 = TxtApellido1.Text;
            }
            if (CmbTipoPersona.Text == "Persona Juridica")
            {
                terceros.tipoPersona = 2;
                terceros.apellido1 = TxtNombreCompleto.Text;
            }

        }
        //===================================================================================================================================================
        //F I N A L   M E T O D O   C A P T U R A   D A T O S
        //===================================================================================================================================================


        //===================================================================================================================================================
        //I N I C I O   M E T O D O   V A L I D A R   T E R C E R O
        //===================================================================================================================================================
        private void MtdValidarTerceros()
        {
            decimal CuentaTercero = 0;
            //string Mensaje = "";
            terceros.idTercero = TxtIdentificacion.Text;
            CuentaTercero = Convert.ToDecimal(conexion.MtdBscDatos("Select Count(IdTercero)From Contabilidad_alttum.Terceros where idtercero ='" + TxtIdentificacion.Text + "'"));


            if (CuentaTercero == 0)
            {
                Activar();
                Limpiar();
                DtpAlta.Focus();
                if (CmbTipoPersona.Text == "Persona Juridica")
                {
                    TxtNombreCompleto.Enabled = true;
                }
                else
                {
                    TxtNombreCompleto.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Tercero Ya Existe", "Tercero ya Existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MtdBuscarDatos();
            }
        }
        //===================================================================================================================================================
        //F I N A L   M E T O D O   V A L I D A R   T E R C E R O
        //==================================================================================================================================================



        //===================================================================================================================================================
        //I N I C I O   M E T O D O   L I M P I A R
        //===================================================================================================================================================
        public void Limpiar()
        {
            TxtNombre1.Clear();
            Txtnombre2.Clear();
            TxtApellido1.Clear();
            TxtApellido2.Clear();
            TxtDireccion.Clear();
            TxtBarrio.Clear();
            TxtCiudad.Clear();
            TxtDpto.Clear();
            TxtTelefono1.Clear();
            TxtTelefono2.Clear();
            TxtCelular.Clear();
            TxtPaginaWeb.Clear();
            TxtEmail.Clear();
            TxtContacto.Clear();
            TxtNombreCompleto.Clear();

        }
//===================================================================================================================================================
//I N I C I O   M E T O D O  L I M P I A R
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O   A C T I V A R
//===================================================================================================================================================
        public void Activar()
        {
            DtpAlta.Enabled = true;
            TxtNombre1.Enabled = true;
            Txtnombre2.Enabled = true;
            TxtApellido1.Enabled = true;
            TxtApellido2.Enabled = true;
            DtpFechaNaci.Enabled = true;
            TxtDireccion.Enabled = true;
            TxtBarrio.Enabled = true;
            TxtCiudad.Enabled = true;
            TxtDpto.Enabled = true;
            TxtTelefono1.Enabled = true;
            TxtTelefono2.Enabled = true;
            TxtCelular.Enabled = true;
            TxtPaginaWeb.Enabled = true;
            TxtEmail.Enabled = true;
            TxtContacto.Enabled = true;
            BtnOk.Enabled = true;
            CmbTipoTercero.Enabled = true;
            CmbTipoTercero.Enabled = true;
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   A C T I V A R 
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O   D E S A C T I V A R
//===================================================================================================================================================
        public void Desactivar()
        {
            DtpAlta.Enabled = false;
            TxtNombre1.Enabled = false;
            Txtnombre2.Enabled = false;
            TxtApellido1.Enabled = false;
            TxtApellido2.Enabled = false;
            DtpFechaNaci.Enabled = false;
            TxtDireccion.Enabled = false;
            TxtBarrio.Enabled = false;
            TxtCiudad.Enabled = false;
            TxtDpto.Enabled = false;
            TxtTelefono1.Enabled = false;
            TxtTelefono2.Enabled = false;
            TxtCelular.Enabled = false;
            TxtPaginaWeb.Enabled = false;
            TxtEmail.Enabled = false;
            TxtContacto.Enabled = false;
            BtnOk.Enabled = false;
            TxtNombreCompleto.Enabled = false;
            CmbTipoTercero.Enabled = false;

        }
//===================================================================================================================================================
//F I N A L   M E T O D O    D E S A C T I V A R 
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   M E T O D O  B U S C A R   D A T O S
//===================================================================================================================================================
        private void MtdBuscarDatos()
        {
            try
            {
                DtDatos = conexion.MtdBuscarDataset("Select * FROM Contabilidad_alttum.Terceros WHERE IdTercero = '" + VarIdTerceros + "'");


                DtpAlta.Text = DtDatos.Rows[0][2].ToString();
                TxtNombre1.Text = DtDatos.Rows[0][3].ToString();
                Txtnombre2.Text = DtDatos.Rows[0][4].ToString();
                TxtApellido1.Text = DtDatos.Rows[0][5].ToString();
                TxtApellido2.Text = DtDatos.Rows[0][6].ToString();
                DtpFechaNaci.Text = DtDatos.Rows[0][7].ToString();
                TxtDireccion.Text = DtDatos.Rows[0][8].ToString();
                TxtBarrio.Text = DtDatos.Rows[0][9].ToString();
                TxtCiudad.Text = DtDatos.Rows[0][10].ToString();
                TxtDpto.Text = DtDatos.Rows[0][11].ToString();
                TxtTelefono1.Text = DtDatos.Rows[0][12].ToString();
                TxtTelefono2.Text = DtDatos.Rows[0][13].ToString();
                TxtCelular.Text = DtDatos.Rows[0][14].ToString();
                TxtPaginaWeb.Text = DtDatos.Rows[0][15].ToString();
                TxtEmail.Text = DtDatos.Rows[0][16].ToString();
                TxtContacto.Text = DtDatos.Rows[0][17].ToString();
                TxtNombreCompleto.Text = DtDatos.Rows[0][21].ToString();
                CmbTipoTercero.Text = DtDatos.Rows[0][1].ToString();

                if (DtDatos.Rows[0][20].ToString() == "1")
                {
                    CmbTipoPersona.Text = "Persona Natural";
                    MtdPersonaNatural();
                    TxtNombreCompleto.Enabled = false;

                }
                else
                    if (DtDatos.Rows[0][20].ToString() == "2")
                    {
                        CmbTipoPersona.Text = "Persona Juridica";
                        MtdPersonaJuridica();
                        TxtNombreCompleto.Enabled = true;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se Presento el sgte erro:" + ex, "MtdBuscarDatos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
//===================================================================================================================================================
//I N I C I O   M E T O D O   B U S C A R   D A T O S
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   M E T O D O   C O N C A T E N A  R
//===================================================================================================================================================
        private void MtdConcatenar()
        {
            if (CmbTipoPersona.Text == "Persona Natural")
            {

                if ((Txtnombre2.Text == "") & (TxtApellido2.Text == ""))
                {
                    TxtNombreCompleto.Text = TxtNombre1.Text + " " + TxtApellido1.Text;
                }
                else
                    if ((Txtnombre2.Text == "") & (TxtApellido2.Text != ""))
                    {
                        TxtNombreCompleto.Text = TxtNombre1.Text + " " + TxtApellido1.Text + " " + TxtApellido2.Text;
                        TxtNombreCompleto.Text = TxtNombreCompleto.Text.ToUpper();
                    }

                    else

                        if ((Txtnombre2.Text != "") & (TxtApellido2.Text == ""))
                        {
                            TxtNombreCompleto.Text = TxtNombre1.Text + " " + Txtnombre2.Text + " " + TxtApellido1.Text;
                        }
                        else
                        {
                            TxtNombreCompleto.Text = TxtNombre1.Text + " " + Txtnombre2.Text + " " + TxtApellido1.Text + " " + TxtApellido2.Text;
                        }
            }
            TxtNombreCompleto.Text = TxtNombreCompleto.Text.ToUpper();
        }
//===================================================================================================================================================
//F I N A L  I M E T O D O   C O N C A T E N A  R
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   M E T O D O MtdAdicionar
//===================================================================================================================================================
        public void MtdAdicionar()
        {
            TxtNombreCompleto.Text = TxtNombreCompleto.Text.ToUpper();
            if (CuentaErrores > 0)
            {
                FrmMensajeError frmError = new FrmMensajeError();
                frmError.LblErrores.DataSource = DatosdeErrores;
                frmError.ShowDialog();
            }

            else
            {
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Terceros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    MtdCaptura();
                    DatosInsertar = terceros.MtdAddTerceros();
                    if (DatosInsertar == "Ok")
                    {
                        BtnOk.Enabled = false;
                        BtnNuevo.Visible = true;
                        panel1.Enabled = false;
                    }
                }
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   MtdAdicionar
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O MtdModificar
//===================================================================================================================================================
        public void MtdModificar()
        {
            string ResultadoMod = "";
            TxtNombreCompleto.Text = TxtNombreCompleto.Text.ToUpper();
            if (CuentaErrores > 0)
            {
                FrmMensajeError frmError = new FrmMensajeError();
                frmError.LblErrores.DataSource = DatosdeErrores;
                frmError.ShowDialog();
            }

            else
            {
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Modificar Este Registro", "Modificar Terceros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    MtdCaptura();
                    ResultadoMod = terceros.MtdModTerceros();
                    if (ResultadoMod == "OK")
                    {
                        BtnOk.Visible = false;
                    }
                }
            }
        }
//===================================================================================================================================================
//F I N A L   M E T O D O   MtdModificar
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   M E T O D O MtdEliminar
//===================================================================================================================================================
        public void MtdEliminar()
        {
            string ResultadoDel = "";

            DialogResult rest;
            rest = MessageBox.Show("Esta seguro de Eliminar Este Registro", "Eliminar Terceros", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rest == DialogResult.Yes)
            {
                terceros.idTercero = TxtIdentificacion.Text;
                ResultadoDel = terceros.MtdDelTerceros();
                if (ResultadoDel == "OK")
                {
                    BtnOk.Visible = false;
                }
            }

        }
//===================================================================================================================================================
//F I N A L   M E T O D O   MtdEliminar
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O MtdPersonaNatural
//===================================================================================================================================================
        private void MtdPersonaNatural()
        {
            try
            {
                LblNombre1.Visible = true;
                TxtNombre1.Visible = true;
                LblNombre2.Visible = true;
                Txtnombre2.Visible = true;
                LblApellido1.Visible = true;
                TxtApellido1.Visible = true;
                LblApellido2.Visible = true;
                TxtApellido2.Visible = true;

                LblNombre1.Location = new Point(9, 15);
                TxtNombre1.Location = new Point(160, 12);
                LblNombre2.Location = new Point(533, 15);
                Txtnombre2.Location = new Point(666, 12);
                LblApellido1.Location = new Point(9, 45);
                TxtApellido1.Location = new Point(160, 43);
                LblApellido2.Location = new Point(533, 45);
                TxtApellido2.Location = new Point(666, 43);
                LblClase.Location = new Point(533, 80);
                CmbTipoTercero.Location = new Point(666, 77);
                LblNombreCompleto.Location = new Point(9, 80);
                TxtNombreCompleto.Location = new Point(160, 77);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se Presento el sgte erro:" + ex, "MtdPersonaNatural", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
//===================================================================================================================================================
//F I N A L   M E T O D O   MtdPersonaNatural
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   M E T O D O MtdPersonaJuridica
//===================================================================================================================================================
        private void MtdPersonaJuridica()
        {
            try
            {
                LblNombre1.Visible = false;
                TxtNombre1.Visible = false;
                LblNombre2.Visible = false;
                Txtnombre2.Visible = false;
                LblApellido1.Visible = false;
                TxtApellido1.Visible = false;
                LblApellido2.Visible = false;
                TxtApellido2.Visible = false;
                LblClase.Location = new Point(533, 45);
                CmbTipoTercero.Location = new Point(666, 43);
                LblNombreCompleto.Location = new Point(9, 45);
                TxtNombreCompleto.Location = new Point(160, 43);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se Presento el sgte erro:" + ex, "MtdPersonaJuridica", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }       
//===================================================================================================================================================
//F I N A L   M E T O D O  MtdPersonaJuridica
//===================================================================================================================================================

        private void CmbTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbTipoPersona.Text == "Persona Natural")
            {
                MtdPersonaNatural();
                TxtNombreCompleto.Enabled = false;
            }
            else

                if (CmbTipoPersona.Text == "Persona Juridica")
                {
                    MtdPersonaJuridica();
                    TxtNombreCompleto.Enabled = true;
                }
        }

        #endregion
   

    }
}
