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
    public partial class FrmRptPagoCmsPorAsesor : Form
    {
        public FrmRptPagoCmsPorAsesor()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        DataTable DtTerceros = new DataTable();
        ReportParameter[] parameters = new ReportParameter[4];

        private void FrmRptPagoCmsPorAsesor_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            LblAsesor.Text = "";
            DtTerceros = conexion.MtdBuscarDataset("Select * from 001cnsgestor");
            // TODO: esta línea de código carga datos en la tabla 'CarteraGeneralDataSet.rptpagocomision' Puede moverla o quitarla según sea necesario.
            this.rptpagocomisionTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
            this.rptpagocomisionTableAdapter.Fill(this.CarteraGeneralDataSet.rptpagocomision);

            this.reportViewer1.RefreshReport();
        }


        private void BtnBusqueda2_Click(object sender, EventArgs e)
        {
            FrmCatalogoTerceros catalogo = new FrmCatalogoTerceros();
            catalogo.VarTipoTercero = "Gestor";
            catalogo.ShowDialog();
            TxtAsesor.Text = FrmCatalogoTerceros.VarIdTercero;
            LblAsesor.Text = FrmCatalogoTerceros.VarNombreTercero;
            Btnok.Focus();
        }

        private void TxtAsesor_KeyPress(object sender, KeyPressEventArgs e)
        {
            int cunta = 0;
            if (e.KeyChar == '\r')
            {
                cunta =Convert.ToInt16( conexion.MtdBscDatos("Select count(Idtercero)from 001cnsgestor where idtercero='"+TxtAsesor.Text+"'")) ;
                if (cunta == 0)
                {
                    LblAsesor.Text = "";
                    MessageBox.Show("No existe Documento", "Consulta Comision por Asesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LblAsesor.Text = ValidarGestor(TxtAsesor.Text);
                    Btnok.Focus();
                }
            }
        }


//===================================================================================================================================================
// I N I C I O   M E T O D O    V A L I D A R  T E R C E R O S
//===================================================================================================================================================
        public string ValidarGestor(string IdTerceros)
        {
            string NombreTerceros = "";
            
            var query = (
            from DtTerceros1 in DtTerceros.AsEnumerable()
            where DtTerceros1.Field<string>("IdTercero") == IdTerceros
            select new

            {
                NombreCompleto1 = DtTerceros1.Field<string>("Nombres"),
            });

            foreach (var order in query)
            {
                NombreTerceros = order.NombreCompleto1;
            }

            return NombreTerceros;
        }
//===================================================================================================================================================
// F I N A L    M E T O D O  V A L I D A R   T E R C E R O S 
//===================================================================================================================================================


        private void TxtAsesor_Enter(object sender, EventArgs e)
        {
            TxtAsesor.BackColor = Color.White;
        }

        private void TxtAsesor_Leave(object sender, EventArgs e)
        {
            TxtAsesor.BackColor = Color.Gainsboro;
        }

        private void Btnok_Click(object sender, EventArgs e)
        {
             int cunta = 0;
             string Sentencia;
                cunta =Convert.ToInt16( conexion.MtdBscDatos("Select count(Idtercero)from 001cnsgestor where idtercero='"+TxtAsesor.Text+"'")) ;
                if (cunta == 0)
                {
                    LblAsesor.Text = "";
                    MessageBox.Show("No existe Documento", "Consulta Comision por Asesor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtAsesor.Focus();
                }
                else
                {
                     Sentencia = "SELECT p.Id,P.IdFinanciacion,p.IdAdjudicacion,p.Fecha,p.idtercero,p.idcargo,p.tasacomision, " +
                     "(p.Comision)Comision,(p.Retencion)Retencion, (p.DctoAnticipo)DctoAnticipo,(p.PagoNeto)PagoNeto,p.Usuario,p.FechaOperacion,p.Transaccion, " +
                     "t.Identificacion as Cliente, g.Nombres as Asesor, a.NombreCargo  FROM pagocomision P " +
                     "join 001cnsgestor g on g.idtercero=p.idtercero " +
                     "join 004cnsadjudica t " +
                     "on t.idadjudicacion=p.idadjudicacion join TablaComision a on a.IdCargo=p.IdCargo " +
                      "where p.Fecha >='" + conexion.MtdVldFchPed(DtpFechaInicio.Value) + "'and p.Fecha  <='" + conexion.MtdVldFchPed(DtpFechaFin.Value) + "'And p.IdTercero ='" +
                      TxtAsesor.Text + "'";

                    string VarFechaIni = String.Format("{0:d/M/yyyy}", DtpFechaInicio.Value);
                    string VarFechaFin = String.Format("{0:d/M/yyyy}", DtpFechaFin.Value);


                    
                    parameters[0] = new ReportParameter("VarFechaInicial", VarFechaIni);
                    parameters[1] = new ReportParameter("VarFechaFinal", VarFechaFin);
                    parameters[2] = new ReportParameter("VarAsesor", LblAsesor.Text);
                    parameters[3] = new ReportParameter("VarDocumento", TxtAsesor.Text);

                    this.rptpagocomisionTableAdapter.Adapter.SelectCommand.CommandText = Sentencia;
                    this.rptpagocomisionTableAdapter.Fill(this.CarteraGeneralDataSet.rptpagocomision);
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    this.reportViewer1.RefreshReport();
                }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
