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
    public partial class FrmImpRecibo : Form
    {
        public FrmImpRecibo()
        {
            InitializeComponent();
        }
        public string IdRecaudo, Concepto;
        DataTable DtDatos = new DataTable();
        string VarValor, NumRecibo, Titular, Inmueble, Direccion, Telefono, Ciudad, Fecha, FormaPago;
        ReportParameter[] parameters = new ReportParameter[11];
        ClsIdentificacion conexion = new ClsIdentificacion();   
        private void FrmImpRecibo_Load(object sender, EventArgs e)
        {
           

            // TODO: esta línea de código carga datos en la tabla 'Cartera.empresa' Puede moverla o quitarla según sea necesario.

            DtDatos = conexion.MtdBuscarDataset("SELECT d.IdAdjudicacion,d.Fecha,d.Valor,d.CodBanco,d.FormaPago, "+
            " c.Identificacion,c.IdInmueble,c.Direccion,c.Telefono1,c.Ciudad ,d.NumRecibo FROM  datosrecaudos d  "+
             " JOIN 004cnsadjudica c on c.idadjudicacion= d.idadjudicacion  WHERE IDRECAUDO= "+ IdRecaudo   );

            
            this.impreciboTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
             
            Fecha = String.Format("{0:d/M/yyyy}", Convert.ToDateTime(DtDatos.Rows[0][1].ToString()));
            VarValor = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(DtDatos.Rows[0][2].ToString()));
            Titular = DtDatos.Rows[0][5].ToString();
            Inmueble = DtDatos.Rows[0][6].ToString();
            Direccion = DtDatos.Rows[0][7].ToString();
            Telefono = DtDatos.Rows[0][8].ToString();
            Ciudad = DtDatos.Rows[0][9].ToString();
            FormaPago = DtDatos.Rows[0][4].ToString();
            NumRecibo = DtDatos.Rows[0][10].ToString();

            parameters[0] = new ReportParameter("Valor", VarValor);
            parameters[1] = new ReportParameter("NumRecibo", NumRecibo);
            parameters[2] = new ReportParameter("Titular", Titular);
            parameters[3] = new ReportParameter("Inmueble", Inmueble);
            parameters[4] = new ReportParameter("FormaPago", FormaPago);
            parameters[5] = new ReportParameter("Direccion", Direccion);
            parameters[6] = new ReportParameter("Telefono", Telefono);
            parameters[7] = new ReportParameter("Ciudad", Ciudad);
            parameters[8] = new ReportParameter("Concepto", Concepto);
            parameters[9] = new ReportParameter("Usuario", FrmLogeo.Usuario);
            parameters[10] = new ReportParameter("Fecha", Fecha);

            this.impreciboTableAdapter.Fill(this.CarteraGeneralDataSet.imprecibo);
            this.impreciboTableAdapter.Adapter.SelectCommand.CommandText =
            "select r.FechaCuota,r.Concepto,r.NumCuota, " +
            "   if(Estado='Aprobado',(d.saldocuota+r.capital+r.interescte),d.saldocuota) " +
            "  SaldoCuota, " +
            "  (r.Capital+R.InteresCte)RecaudoCuota,d.InteresMora," +
            " (r.Capital+r.InteresCte+r.InteresMora)PagoTotal , " +
            " if(Estado='Aprobado',d.SaldoCuota,(d.saldocuota-r.capital-r.interescte))NueVoSaldo " +
            "  From Recaudos r   join 004saldocuotas  d  on r.IdFinanciacion =d.IdCta  where idrecaudo=" + IdRecaudo;
           
            this.impreciboTableAdapter.Fill(this.CarteraGeneralDataSet.imprecibo);
            this.reportViewer1.LocalReport.SetParameters(parameters);

            this.reportViewer1.RefreshReport();

        }
    }
}
