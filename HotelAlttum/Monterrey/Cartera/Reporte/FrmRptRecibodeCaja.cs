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
    public partial class FrmRptRecibodeCaja : Form
    {
        public FrmRptRecibodeCaja()
        {
            InitializeComponent();
        }
        public string VarBenef, VarNit, VarRecibo, VarMotivo, VarValor, NumComprobante, VarFuente, VarTitulo;
        string transaccion, NomElabora;
        ClsNumaLetras numletras = new ClsNumaLetras();
        ClsIdentificacion conexion = new ClsIdentificacion();   
        private void FrmRptRecibodeCaja_Load(object sender, EventArgs e)
        {
            this.impdocumentoTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
      
            // TODO: esta línea de código carga datos en la tabla 'CarteraGeneralDataSet.impdocumento' Puede moverla o quitarla según sea necesario.
            this.impdocumentoTableAdapter.Fill(this.CarteraGeneralDataSet.impdocumento);
    
            this.VarValor = String.Format("{0:###0.00;-###0.00;0.00}", decimal.Parse(this.VarValor));
            VarValor = numletras.Convertir(VarValor, true);
            transaccion = conexion.MtdBscDatos("select Transaccion  from Contabilidad_alttum.diario d where estado =1 and IdDocumento = " + NumComprobante + " and Fuente = '" + VarFuente + "'");
            NomElabora = conexion.MtdBscDatos("Select Usuario From Contabilidad_alttum.Transacciones where IdTransaccion= " + transaccion);
            ReportParameter[] parameters = new ReportParameter[7];
            parameters[0] = new ReportParameter("Benef", VarBenef);
            parameters[1] = new ReportParameter("Nit", VarNit);
            parameters[2] = new ReportParameter("Recibo", VarRecibo);
            parameters[3] = new ReportParameter("Motivo", VarMotivo);
            parameters[4] = new ReportParameter("VrLetra", VarValor);
            parameters[5] = new ReportParameter("Elaboro", NomElabora);
            parameters[6] = new ReportParameter("Titulo", VarTitulo);

            this.impdocumentoTableAdapter.Adapter.SelectCommand.CommandText = "select d.* from 007diario d where estado =1 and IdDocumento = " + NumComprobante + " and Fuente = '" + VarFuente + "'";
            this.impdocumentoTableAdapter.Fill(this.CarteraGeneralDataSet.impdocumento);
       
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();  
            
        }
    }
}
