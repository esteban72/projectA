using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CarteraGeneral
{
    public partial class FrmRptAnticipoporAdj : Form
    {
        public FrmRptAnticipoporAdj()
        {
            InitializeComponent();
        }
        ClsIdentificacion conexion = new ClsIdentificacion();
        int cant;
        private void FrmRptAnticipoporAdj_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            // TODO: esta línea de código carga datos en la tabla 'CarteraGeneralDataSet.rptpagoanticipo' Puede moverla o quitarla según sea necesario.
            this.rptpagoanticipoTableAdapter.Connection.ConnectionString = FrmLogeo.StrConexion;
            this.rptpagoanticipoTableAdapter.Fill(this.CarteraGeneralDataSet.rptpagoanticipo);

            
        }

        private void TxtAdjudicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                MtdValidadAdj();
            }
            else
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }

            }
        }


        private void MtdValidadAdj()
        {
            cant =Convert.ToInt16( conexion.MtdBscDatos("Select if(Count(IdAdjudicacion) is null,0,Count(IdAdjudicacion)) From 004cnsadjudica Where idadjudicacion= " + TxtAdjudicacion.Text ));
        if (cant==0)
        {
            MessageBox.Show("No Existe Adjudicacion","Anticipo por Adjudicacion",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        else

        {
            LblCliente.Text = conexion.MtdBscDatos("Select Identificacion From 004cnsadjudica Where idadjudicacion= "+TxtAdjudicacion.Text );
            BtnBusqueda2.Focus();
        }

        }

        private void BtnBusqueda2_Click(object sender, EventArgs e)
        {
            cant = Convert.ToInt16(conexion.MtdBscDatos("Select if(Count(IdAdjudicacion) is null,0,Count(IdAdjudicacion)) From 004cnsadjudica Where idadjudicacion=  " + TxtAdjudicacion.Text  ));
            if (cant == 0)
            {
                MessageBox.Show("No Existe Adjudicacion", "Anticipo por Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string Sentencia;

                Sentencia = " select p.Id,p.IdFinanciacion,p.IdAdjudicacion,c.Identificacion as Cliente,p.Fecha,p.IdCargo," +
                " t.NombreCargo,p.idtercero,g.Nombres,p.Valor From pagoanticipo p join 004cnsadjudica c on c.idadjudicacion=p.idadjudicacion " +
            " join tablacomision t on t.idcargo=p.idcargo join 001cnsgestor g on g.idtercero=p.idtercero where p.IdAdjudicacion= " + TxtAdjudicacion.Text;



                this.rptpagoanticipoTableAdapter.Adapter.SelectCommand.CommandText = Sentencia;
                this.rptpagoanticipoTableAdapter.Fill(this.CarteraGeneralDataSet.rptpagoanticipo);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
