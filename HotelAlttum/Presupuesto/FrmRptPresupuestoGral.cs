using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.Reporting.WinForms;

namespace CarteraGeneral
{
    public partial class FrmRptPresupuestoGral : Form
    {
        public FrmRptPresupuestoGral()
        {
            InitializeComponent();
        }
        MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
            
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        ReportParameter[] parameters = new ReportParameter[1];
      
        string MesInicio, MesFinal,VarTitulo;
        string Año;
        string NomTabla;

        

        private void FrmRptPresupuestoGral_Load(object sender, EventArgs e)
        {

        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            
            Año = TxtAño.Text;
            if (CmbMes.Text == "")
            {
                MessageBox.Show("Falta Seleccionar Mes");
            }

            else
            {
                BtnCalcular.Enabled = false;
                BtnCalcular.Cursor = Cursors.AppStarting;
                MtdDatosMes();
                parameters[0] = new ReportParameter("Titulo", VarTitulo);
                this.presupuestogralTableAdapter.Fill(this.CarteraGeneralDataSet.presupuestogral);
                this.presupuestogralTableAdapter.Adapter.SelectCommand.CommandText = "Select * from " + NomTabla;
                this.presupuestogralTableAdapter.Fill(this.CarteraGeneralDataSet.presupuestogral);
                this.reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();
                BtnCalcular.Enabled = true;
                BtnCalcular.Cursor = Cursors.Default;
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

//===================================================================================================================================================
// I N I C I O    M E T O D O   D A T O S   D E L   M E S 
//=================================================================================================================================================== 
        private void MtdDatosMes()
        {


           

            switch (CmbMes.Text)
            {
                case "Enero":
                    MesInicio = "'" + Año + "-01-01'";
                    MesFinal = "'" + Año + "-01-31'";
                    NomTabla = "PresupuestoEnero";
                    break;

                case "Febrero":
                    MesInicio = "'" + Año + "-02-01'";
                    MesFinal = "'" + Año + "-02-28'";
                    NomTabla = "PresupuestoFebrero";

                    break;

                case "Marzo":
                    MesInicio = "'" + Año + "-03-01'";
                    MesFinal = "'" + Año + "-03-31'";
                    NomTabla = "PresupuestoMarzo";
                    break;

                case "Abril":
                    MesInicio = "'" + Año + "-04-01'";
                    MesFinal = "'" + Año + "-04-30'";
                    NomTabla = "PresupuestoAbril";
                    break;
                case "Mayo":
                    MesInicio = "'" + Año + "-05-01'";
                    MesFinal = "'" + Año + "-05-31'";
                    NomTabla = "PresupuestoMayo";
                    break;

                case "Junio":
                    MesInicio = "'" + Año + "-06-01'";
                    MesFinal = "'" + Año + "-06-30'";
                    NomTabla = "PresupuestoJunio";
                    break;

                case "Julio":
                    MesInicio = "'" + Año + "-07-01'";
                    MesFinal = "'" + Año + "-07-31'";
                    NomTabla = "PresupuestoJulio";
                    break;

                case "Agosto":
                    MesInicio = "'" + Año + "-08-01'";
                    MesFinal = "'" + Año + "-08-31'";
                    NomTabla = "PresupuestoAgosto";
                    break;

                case "Septiembre":
                    MesInicio = "'" + Año + "-09-01'";
                    MesFinal = "'" + Año + "-09-30'";
                    NomTabla = "PresupuestoSeptiembre";
                    break;

                case "Octubre":
                    MesInicio = "'" + Año + "-10-01'";
                    MesFinal = "'" + Año + "-10-31'";
                    NomTabla = "PresupuestoOctubre";
                    break;

                case "Noviembre":
                    MesInicio = "'" + Año + "-11-01'";
                    MesFinal = "'" + Año + "-11-30'";
                    NomTabla = "PresupuestoNoviembre";
                    break;

                case "Diciembre":
                    MesInicio = "'" + Año + "-12-01'";
                    MesFinal = "'" + Año + "-12-31'";
                    NomTabla = "PresupuestoDiciembre";
                    break;

                default:

                    break;
            }
            VarTitulo = "PRESUPUESTO DE " + CmbMes.Text.ToUpper() + " DEL AÑO " + TxtAño.Text.ToUpper();
        }
//===================================================================================================================================================
// F I N A L     M E T O D O   D A T O S   D E L   M E S 
//===================================================================================================================================================


    }
}
