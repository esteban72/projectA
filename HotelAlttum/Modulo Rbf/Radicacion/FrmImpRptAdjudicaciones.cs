using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CarteraGeneral
{
    public partial class FrmImpRptAdjudicaciones : Form
    {
        public FrmImpRptAdjudicaciones()
        {
            InitializeComponent();
        }
        public string VarIdTercero, VarIdAdjudicacion, VarEntrada;

        DataTable DtDatosTerceros = new DataTable();
        DataTable DtDatosAdjdicacion = new DataTable();
        ClsIdentificacion conexion = new ClsIdentificacion();
        private void FrmImpRptAdjudicaciones_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            toolStripStatusLabel1.Text = "Usuario Conectado " + FrmLogeo.Usuario;
            this.impcomisionTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;        
            this.impcomisionTableAdapter.Fill(this.CarteraGeneralDataSet.impcomision);
            if (VarEntrada=="Automatica")
            {

                MtdAutomatico();
            }
        }


        private void MtdAutomatico()
        {
            DtDatosTerceros = conexion.MtdBuscarDataset("Select NombreCompleto,Ciudad,Telefono1,Telefono2,Direccion from Contabilidad_alttum.Terceros Where IdTercero = '" + VarIdTercero + "'");
            DtDatosAdjdicacion = conexion.MtdBuscarDataset("Select Fecha,IdInmueble,FormaPago,Contrato,Valor,CuotaInicial,Contado,Financiacion,PlazoFnc,"+
            "TasaFnc,CuotaFnc,Extraordinaria,PlazoExtra,TasaExtra,CuotaExtra,Usuario,FechaOperacion From Adjudicacion  Where IdAdjudicacion = " + VarIdAdjudicacion );

            this.impcomisionTableAdapter.Adapter.SelectCommand.CommandText = "select c.IdAdjudicacion,c.IdCargo Cargo,d.NombreCargo NombreCargo,c.IdTercero IdGestor,t.NombreCompleto as NombreGestor,c.Comision1,c.Comision2 " +
            " from comision c join tablacomision d on d.idcargo=c.idcargo join Contabilidad_alttum.Terceros t on t.IdTercero=c.IdTercero  Where c.IdAdjudicacion = '" + VarIdAdjudicacion + "' Order by t.nombrecompleto";


            string cliente = DtDatosTerceros.Rows[0][0].ToString();
            string ciudad = DtDatosTerceros.Rows[0][1].ToString();
            string telefono1 = DtDatosTerceros.Rows[0][2].ToString();
            string telefono2 = DtDatosTerceros.Rows[0][3].ToString();
            string direccion = DtDatosTerceros.Rows[0][4].ToString();

            string Fecha = String.Format("{0:d/M/yyyy}", DtDatosAdjdicacion.Rows[0][0].ToString());            
            string inmueble = DtDatosAdjdicacion.Rows[0][1].ToString();           
            string formapago = DtDatosAdjdicacion.Rows[0][2].ToString();           
            string contrato = DtDatosAdjdicacion.Rows[0][3].ToString();
            string venta = DtDatosAdjdicacion.Rows[0][4].ToString();
            string cuotainicial = DtDatosAdjdicacion.Rows[0][5].ToString();
            string contado = DtDatosAdjdicacion.Rows[0][6].ToString();
            string financiacion = DtDatosAdjdicacion.Rows[0][7].ToString();
             string plazofnc = DtDatosAdjdicacion.Rows[0][8].ToString();
             string tasafnc = DtDatosAdjdicacion.Rows[0][9].ToString();
            string cuotafnc = DtDatosAdjdicacion.Rows[0][10].ToString();  
            string extraordinario = DtDatosAdjdicacion.Rows[0][11].ToString();
            string plazoextra = DtDatosAdjdicacion.Rows[0][12].ToString();
            string tasaextra = DtDatosAdjdicacion.Rows[0][13].ToString();
            string cuotaextra = DtDatosAdjdicacion.Rows[0][14].ToString();           
            string elaboro = DtDatosAdjdicacion.Rows[0][15].ToString();
            string fechaoperacion = String.Format("{0:d/M/yyyy}", DtDatosAdjdicacion.Rows[0][16].ToString());

            ReportParameter[] parameters = new ReportParameter[23];
            parameters[0] = new ReportParameter("Adjudicacion", VarIdAdjudicacion);
            parameters[1] = new ReportParameter("Cliente", cliente);
            parameters[2] = new ReportParameter("Fecha", Fecha);
            parameters[3] = new ReportParameter("IdTercero", VarIdTercero);
            parameters[4] = new ReportParameter("Inmueble", inmueble);
            parameters[5] = new ReportParameter("Ciudad", ciudad);
            parameters[6] = new ReportParameter("FormaPago", formapago);
            parameters[7] = new ReportParameter("Telefono1", telefono1);
            parameters[8] = new ReportParameter("Telefono2", telefono2);
            parameters[9] = new ReportParameter("Contrato", contrato);
            parameters[10] = new ReportParameter("Venta", venta);
            parameters[11] = new ReportParameter("CuotaInicial", cuotainicial);
            parameters[12] = new ReportParameter("Contado", contado);
            parameters[13] = new ReportParameter("Financiacion", financiacion);
            parameters[14] = new ReportParameter("CuotaFnc", cuotafnc);
            parameters[15] = new ReportParameter("TasaFnc", tasafnc);
            parameters[16] = new ReportParameter("PlazoFnc", plazofnc);
            parameters[17] = new ReportParameter("Extraordinario", extraordinario);
            parameters[18] = new ReportParameter("CuotaExtra", cuotaextra);
            parameters[19] = new ReportParameter("TasaExtra", tasaextra);
            parameters[20] = new ReportParameter("PlazoExtra", plazoextra);
            parameters[21] = new ReportParameter("Direccion", direccion);
            parameters[22] = new ReportParameter("Elaboro", elaboro);
            this.impcomisionTableAdapter.Fill(this.CarteraGeneralDataSet.impcomision);
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        
        }
    }
}
