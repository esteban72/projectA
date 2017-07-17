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
    public partial class FrmRptCnsPagoCmsPorCliente : Form
    {
        public FrmRptCnsPagoCmsPorCliente()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
       
        ReportParameter[] parameters = new ReportParameter[2];
        private void FrmRptCnsPagoCmsPorCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'CarteraGeneralDataSet.rptpagocomision' Puede moverla o quitarla según sea necesario.
            this.rptpagocomisionTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
            this.rptpagocomisionTableAdapter.Fill(this.CarteraGeneralDataSet.rptpagocomision);
            pictureBox1.Image = FrmMenuGeneral.Logo;
            
        }

        private void Btnok_Click(object sender, EventArgs e)
        {
           string Sentencia = "SELECT p.Id,P.IdFinanciacion,p.IdAdjudicacion,p.Fecha,p.idtercero,p.idcargo,p.tasacomision, " +
                    "(p.Comision)Comision,(p.Retencion)Retencion, (p.DctoAnticipo)DctoAnticipo,(p.PagoNeto)PagoNeto,p.Usuario,p.FechaOperacion,p.Transaccion, " +
                    "t.Identificacion as Cliente, g.Nombres as Asesor, a.NombreCargo  FROM pagocomision P " +
                    "join 001cnsgestor g on g.idtercero=p.idtercero " +
                    "join 004cnsadjudica t " +
                    "on t.idadjudicacion=p.idadjudicacion join TablaComision a on a.IdCargo=p.IdCargo " +
                     "where p.Fecha >='" + conexion.MtdVldFchPed(DtpFechaInicio.Value) + "'and p.Fecha  <='" + conexion.MtdVldFchPed(DtpFechaFin.Value) + "' order by p.idadjudicacion";

            string VarFechaIni = String.Format("{0:d/M/yyyy}", DtpFechaInicio.Value);
            string VarFechaFin = String.Format("{0:d/M/yyyy}", DtpFechaFin.Value);

            parameters[0] = new ReportParameter("VarFechaInicial", VarFechaIni);
            parameters[1] = new ReportParameter("VarFechaFinal", VarFechaFin);         

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
