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
    public partial class FrmRptCarteraVencida : Form
    {
        public FrmRptCarteraVencida()
        {
            InitializeComponent();
        }
        ReportParameter[] parameters = new ReportParameter[1];
        string scrip =
      "  Select  A1.idadjudicacion, c.Identificacion as Cliente, A1.fecha,NumCuota,Concepto,SaldoCapital,SaldoInteres, (Saldocuota),(Diascpt) from " +
       " ( "+
      "  select f.*, "+ 
       " if(r.Capital is null,0,r.Capital) as RcdCapital, "+ 
       " if(r.InteresCte is null,0,r.InteresCte) as RcdInteres, "+
       " if(r.Cuota is null,0,r.Cuota) as RcdCuota, "+
       " if(r.InteresCnd is null,0,r.InteresCnd) as InteresCnd, "+
       " if(r.MoraCalc is null,0,r.MoraCalc) as MoraCalc, "+
       " if(r.Interesmora is null,0,r.Interesmora) as Interesmora, "+
       " if(r.SaldoIntMora is null,0,r.SaldoIntMora) as SaldoIntMora, "+
       " if(DATEDIFF( curdate(),f.fecha)<=0,0, DATEDIFF( curdate() ,f.fecha))DiasCpt ,"+
       " if(f.UltimaFechaPago<f.fecha, if(DATEDIFF( curdate(),f.fecha)<=0,0, DATEDIFF( curdate() ,f.fecha)), "+
       " if(DATEDIFF( curdate(),f.UltimaFechaPago)<=0,0, DATEDIFF( curdate() ,f.UltimaFechaPago)))DiasLqd "+

       " from financiacion f "+
       " left join 004recaudosresumidos r "+
       " on r.id=f.idcta "+
       " ) "+
       " A1 "+
       " join 004cnsadjudica c "+
       " on  c.idadjudicacion= A1.IdAdjudicacion "+
       " where diascpt >0 And Saldocuota >0 and concepto !='GA' ";


        private void FrmRptCarteraVencida_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'CarteraGeneralDataSet.rptcarteravencida' Puede moverla o quitarla según sea necesario.
            this.rptcarteravencidaTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
            this.rptcarteravencidaTableAdapter.Fill(this.CarteraGeneralDataSet.rptcarteravencida);
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            string scripcartera = "";
            if (CmbTipoCartera.Text == "")
            {
                MessageBox.Show("Falta Seleccionar Tipo Cartera" ,"Cartera Vencida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                BtnCalcular.Enabled = false;
                BtnCalcular.Cursor = Cursors.AppStarting;

                if (CmbTipoCartera.Text == "Comercial")
                {
                    scripcartera = scrip + " And Concepto = 'CI'";
                }

                else
                {
                    scripcartera = scrip + " And Concepto != 'CI'";
                }

                parameters[0] = new ReportParameter("Titulo", "CARTERA  " + CmbTipoCartera.Text.ToUpper() + " VENCIDA");
                this.rptcarteravencidaTableAdapter.Adapter.SelectCommand.CommandText = scripcartera;
                this.rptcarteravencidaTableAdapter.Fill(this.CarteraGeneralDataSet.rptcarteravencida);
                this.reportViewer1.LocalReport.SetParameters(parameters);
                this.reportViewer1.RefreshReport();
                BtnCalcular.Enabled = true;
                BtnCalcular.Cursor = Cursors.Default;

            }
        }

       


    }
}
