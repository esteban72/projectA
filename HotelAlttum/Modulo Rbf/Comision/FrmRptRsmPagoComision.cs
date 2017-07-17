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
    public partial class FrmRptRsmPagoComision : Form
    {
        public FrmRptRsmPagoComision()
        {
            InitializeComponent();
        }
        string Sentencia;
        ClsIdentificacion conexion =new  ClsIdentificacion();
        private void FrmRptRsmPagoComision_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;  
            // TODO: esta línea de código carga datos en la tabla 'CarteraGeneralDataSet.rptpagocomision' Puede moverla o quitarla según sea necesario.
            this.rptpagocomisionTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
            this.rptpagocomisionTableAdapter.Fill(this.CarteraGeneralDataSet.rptpagocomision);
           
            
        }

        private void Btnok_Click(object sender, EventArgs e)
        {
            Sentencia = "SELECT p.Id,P.IdFinanciacion,p.IdAdjudicacion,p.Fecha,p.idtercero,p.idcargo,p.tasacomision, " +
             "sum(p.Comision)Comision,sum(p.Retencion)Retencion, sum(p.DctoAnticipo)DctoAnticipo,Sum(p.PagoNeto)PagoNeto,p.Usuario,p.FechaOperacion,p.Transaccion, " +
             "t.Identificacion as Cliente, g.Nombres as Asesor  FROM pagocomision P " +
             "join 001cnsgestor g on g.idtercero=p.idtercero " +
             "join 004cnsadjudica t " +
             "on t.idadjudicacion=p.idadjudicacion " +
              "where p.Fecha='" + conexion.MtdVldFchPed(DtpFecha.Value) + "' group by p.idtercero ";
            string VarFecha = String.Format("{0:d/M/yyyy}",DtpFecha.Value);
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("VarFecha", VarFecha);

            this.rptpagocomisionTableAdapter.Adapter.SelectCommand.CommandText = Sentencia;
            this.rptpagocomisionTableAdapter.Fill(this.CarteraGeneralDataSet.rptpagocomision);
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        
    }
}
