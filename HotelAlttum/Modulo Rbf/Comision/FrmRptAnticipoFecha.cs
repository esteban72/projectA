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
    public partial class FrmRptAnticipoFecha : Form
    {
        public FrmRptAnticipoFecha()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        ReportParameter[] parameters = new ReportParameter[2];
        private void FrmRptAnticipoFecha_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            // TODO: esta línea de código carga datos en la tabla 'CarteraGeneralDataSet.rptpagoanticipo' Puede moverla o quitarla según sea necesario.
            this.rptpagoanticipoTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
            this.rptpagoanticipoTableAdapter.Fill(this.CarteraGeneralDataSet.rptpagoanticipo);

            
        }

        private void BtnBusqueda2_Click(object sender, EventArgs e)
        {
            
            string Sentencia;

            Sentencia = " select p.Id,p.IdFinanciacion,p.IdAdjudicacion,c.Identificacion as Cliente,p.Fecha,p.IdCargo," +
            " t.NombreCargo,p.idtercero,g.Nombres,p.Valor From pagoanticipo p join 004cnsadjudica c on c.idadjudicacion=p.idadjudicacion " +
        " join tablacomision t on t.idcargo=p.idcargo join 001cnsgestor g on g.idtercero=p.idtercero where p.Fecha >='" +
        conexion.MtdVldFchPed(DtpFechaInicio.Value) + "'and p.Fecha  <='" + conexion.MtdVldFchPed(DtpFechaFin.Value) + "'";

            string VarFechaIni = String.Format("{0:d/M/yyyy}", DtpFechaInicio.Value);
            string VarFechaFin = String.Format("{0:d/M/yyyy}", DtpFechaFin.Value);
            parameters[0] = new ReportParameter("VarFechaInicial", VarFechaIni);
            parameters[1] = new ReportParameter("VarFechaFinal", VarFechaFin);

            this.rptpagoanticipoTableAdapter.Adapter.SelectCommand.CommandText = Sentencia;
            this.rptpagoanticipoTableAdapter.Fill(this.CarteraGeneralDataSet.rptpagoanticipo);
            this.reportViewer1.LocalReport.SetParameters(parameters);
            this.reportViewer1.RefreshReport();
        }
    }
}
