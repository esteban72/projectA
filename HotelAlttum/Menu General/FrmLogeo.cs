
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Configuration;
using DevExpress.LookAndFeel;
using System;
using DevExpress.XtraSplashScreen;
using System.Threading;

namespace CarteraGeneral
{
    public partial class FrmLogeo : Form
    {
        public FrmLogeo()
        {          
            InitializeComponent();         
        }

        #region Variables Logeo

        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        DataTable DtListado = new DataTable();
        //Panama 
        public static string StrConexion = "server=192.168.0.200;User Id=root;password=elpobladosa;Persist Security Info=True;database=hotelalttum";
       //Medellin
       //public static string StrConexion = "server=app-server;User Id=root;password=elpobladosa;Persist Security Info=True;database=HotelAlttum";
        //public static string StrConexion = "server=127.0.0.1;User Id=root;password=D3sarrollador.;Persist Security Info=True;database=hotelalttum";
        
        public static string FrmUsuarioIdUsr;
        public static string FrmUsuarioClave;
        public static MySqlConnection MysqlConexion;
        public static string Usuario;
        public static int CentroCosto;
        public static string Proyecto;
        public static string Pais;
        public static Image LogoFondo;      
        //public static DateTime DtpFecha;
       
            
        int veces;
        public static  DataTable DtDatosUsuario = new DataTable();

        #endregion


        #region Region de Metodos y Eventos

        private void TxtClave_KeyPress(object sender, KeyPressEventArgs e)
        {           
            if (e.KeyChar == '\r')
            {
             BtnAceptar.Focus();
            }
        }       
        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                TxtClave.Focus();
            }
        }
        private void TxtUsuario_Enter(object sender, EventArgs e)
        {
            TxtUsuario.BackColor = Color.White;
            toolStripStatusLabel1.Text = "Digite Su Usuario";
        }
        private void TxtUsuario_Leave(object sender, EventArgs e)
        {
            TxtUsuario.BackColor = Color.White;
        }
        private void TxtClave_Enter(object sender, EventArgs e)
        {
            TxtClave.BackColor = Color.White;
            toolStripStatusLabel1.Text = "Digite Su Clave";
        }
        private void TxtClave_Leave(object sender, EventArgs e)
        {
            TxtClave.BackColor = Color.White;
        }
        private void BtnAceptar_Enter(object sender, EventArgs e)
        {
            BtnAceptar.BackColor = Color.White;
            toolStripStatusLabel1.Text = "Presione Enter para Ingresar";
        }
        private void BtnAceptar_Leave(object sender, EventArgs e)
        {
            BtnAceptar.BackColor = Color.White;
        }
        private void BtnAceptarUsr_Click(object sender, EventArgs e)
        {
            if (TxtUsuario.Text == "" | TxtClave.Text == "")
            {
                toolStripStatusLabel1.Text = "Ingrese Usuario y Contraseña";
            }

            else
            {
                FrmUsuarioIdUsr = TxtUsuario.Text;
                FrmUsuarioClave = TxtClave.Text;
                MysqlConexion = new MySqlConnection(StrConexion);
                DtDatosUsuario = NuevoClsIdentificacion.MtdBuscarDataset("Select * from Usuario Where Estado='Vigente'and IdUsuario = '" + TxtUsuario.Text +
                    "' and Clave  IN(SELECT PASSWORD('" + TxtClave.Text + "'))");                 
                        
                if (DtDatosUsuario.Rows.Count != 0)
                {
                    Usuario = TxtUsuario.Text;
                  
                    this.DialogResult = DialogResult.OK;
                   
                    string strSkin = NuevoClsIdentificacion.MtdBscDatos("select tema from usuario where idusuario= '"+TxtUsuario.Text+"'");
                    
                    if (strSkin != null || strSkin != "")
                    {
                        UserLookAndFeel.Default.SkinName = strSkin;
                    }
                }
                else
                {
                   veces = veces + 1;
                    if (veces < 6)
                    {
                        toolStripStatusLabel1.Text = "Usuario o Clave Errada";
                        return;
                    }
                    this.DialogResult = DialogResult.No;
                }
                Hide();
            }
        }      
        private void FrmLogeo_Load(object sender, EventArgs e)
        {
            NombreProyecto();
            //Open Wait Form
            SplashScreenManager.ShowForm(this, typeof(FrmSmarTime), true, true, false);

            //The Wait Form is opened in a separate thread. To change its Description, use the SetWaitFormDescription method.
            for (int i = 1; i <= 100; i++)
            {
                //SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "%");
                Thread.Sleep(25);
            }

            //Close Wait Form
            SplashScreenManager.CloseForm(false);
            //CultureInfo forceDotCulture;
            //forceDotCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            //forceDotCulture.NumberFormat.NumberDecimalSeparator = ".";
            //forceDotCulture.NumberFormat.NumberGroupSeparator = ",";
            //Application.CurrentCulture = forceDotCulture;

            FrmMenuGeneral.Logo = global::CarteraGeneral.Properties.Resources.logo;
            pictureBox2.Image = FrmMenuGeneral.Logo;
        }

        private void NombreProyecto()
        {
            DtListado = NuevoClsIdentificacion.MtdBuscarDataset("Select Scrip from Vistas where Vista='CnsNombreProyecto'");
            string strconsulta = DtListado.Rows[0]["Scrip"].ToString();

            DtListado = NuevoClsIdentificacion.MtdBuscarDataset(strconsulta);
            Proyecto = DtListado.Rows[0]["NombreProyecto"].ToString();
            
        }

        #endregion

    }
}
