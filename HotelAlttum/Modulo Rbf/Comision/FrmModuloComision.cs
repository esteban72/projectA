using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace CarteraGeneral
{
    public partial class FrmModuloComision : Form
    {
        public FrmModuloComision()
        {
            InitializeComponent();
        }
    
        System.Data.DataTable DtComision = new System.Data.DataTable();
        System.Data.DataTable DtDatos = new System.Data.DataTable();
        System.Data.DataTable DtInmueble = new System.Data.DataTable();
        ClsIdentificacion conexion = new ClsIdentificacion();
        string VarIdTercero, VarNombre, VarComision1, VarComision2, VarComision3,VarIdCargo, VarNombreCargo;

        private void FrmModuloComision_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;            
        }


        private void FrmModuloComision_Activated(object sender, EventArgs e)
        {
            if (TxtAdjudicacion.Text != "")
            {
                MtdDatos();
            }
        }       
        private void MtdDatos()
        {

            DtDatos = conexion.MtdBuscarDataset("Select Identificacion,IdInmueble,TipodeAdjudicacion From 004cnsadjudica WHERE IdAdjudicacion = " + TxtAdjudicacion.Text);
            DtComision = conexion.MtdBuscarDataset("select c.idtercero,a.nombrecompleto as Nombre,c.idcargo,t.NombreCargo,c.Comision1,c.Comision2,Comision3 " +
          " From Comision c join tablacomision t on c.idcargo=t.idcargo join Contabilidad_alttum.terceros a on a.idtercero=c.idtercero Where IdAdjudicacion ="
          + TxtAdjudicacion.Text + " Order by c.IdCargo");

            TxtClinte.Text = DtDatos.Rows[0][0].ToString();
            TxtInmueble.Text = DtDatos.Rows[0][1].ToString();
            TxtTipo.Text = DtDatos.Rows[0][2].ToString();
            DtInmueble = conexion.MtdBuscarDataset("Select Villa,Unidad,Semana,Temporada from Inmuebles  Where IdInmueble = '" + TxtInmueble.Text + "'");

            TxtVilla.Text = DtInmueble.Rows[0][0].ToString();
            TxtUnidad.Text = DtInmueble.Rows[0][1].ToString();
            TxtSemana.Text = DtInmueble.Rows[0][2].ToString();
            TxtTemporada.Text = DtInmueble.Rows[0][3].ToString();

            DgvListado.Rows.Clear();

            DgvListado.Rows.Clear();
            for (int i = 0; i < (DtComision.Rows.Count); i++)
            {
                DgvListado.Rows.Add(DtComision.Rows[i][0], DtComision.Rows[i][1], DtComision.Rows[i][2], DtComision.Rows[i][3], DtComision.Rows[i][4], 
                    DtComision.Rows[i][5],DtComision.Rows[i][6]);

            }

            decimal sumcomision1 = 0, sumcomision2 = 0, sumcomision3 = 0;
            for (int i = 0; i < (DgvListado.Rows.Count); i++)
            {
                sumcomision1 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[4].Value));
                sumcomision2 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[5].Value));
                sumcomision3 += (Convert.ToDecimal(DgvListado.Rows[i].Cells[6].Value));
            }
            int b = DgvListado.Rows.Count - 1;
            DgvListado.Rows[b].Cells[3].Value = "T O T A L  . .";
            DgvListado.Rows[b].Cells[4].Value = sumcomision1;
            DgvListado.Rows[b].Cells[5].Value = sumcomision2;
            DgvListado.Rows[b].Cells[6].Value = sumcomision3;

            DgvListado.Rows[b].DefaultCellStyle.BackColor = Color.SteelBlue;
            DgvListado.Rows[b].DefaultCellStyle.ForeColor = Color.White;
            

        }

        private void TxtAdjudicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {

                double Contar = Convert.ToDouble(conexion.MtdBscDatos("select count(identificacion) from 004cnsadjudica where IdAdjudicacion = " +
                  TxtAdjudicacion.Text));

                if (Contar == 0)
                {
                    MessageBox.Show("No Existe Adjudicacion");
                    TxtAdjudicacion.Clear();
                }
                else
                {
                    MtdDatos();

                }
            }

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

        private void TxtAdjudicacion_Leave(object sender, EventArgs e)
        {
            TxtAdjudicacion.BackColor = Color.Gainsboro;
        }

        private void TxtAdjudicacion_Enter(object sender, EventArgs e)
        {
            TxtAdjudicacion.BackColor = Color.White;
        }

        private void DgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            VarIdTercero = DgvListado.Rows[e.RowIndex].Cells[0].Value.ToString();
            VarNombre = DgvListado.Rows[e.RowIndex].Cells[1].Value.ToString();
            VarIdCargo = DgvListado.Rows[e.RowIndex].Cells[2].Value.ToString();
            VarNombreCargo = DgvListado.Rows[e.RowIndex].Cells[3].Value.ToString();
            VarComision1 = DgvListado.Rows[e.RowIndex].Cells[4].Value.ToString();
            VarComision2 = DgvListado.Rows[e.RowIndex].Cells[5].Value.ToString();
            VarComision3= DgvListado.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void TsmAddComision_Click(object sender, EventArgs e)
        {
            if (DgvListado.Rows.Count == 1)
            {
                MessageBox.Show("No Existe Registros para Corregir", "Adicionar Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmModificarComision modcomision = new FrmModificarComision();
                modcomision.VarIdCargo = VarIdCargo;
                modcomision.VarIdTercero = VarIdTercero;
                modcomision.VarNombreCargo = VarNombreCargo;
                modcomision.VarNombre = VarNombre;
                modcomision.VarComision1 = VarComision1;
                modcomision.VarComision2 = VarComision2;
                modcomision.VarComision3 = VarComision3;
                modcomision.VarIdadjudicacion = TxtAdjudicacion.Text;
                modcomision.VarCliente = TxtClinte.Text;
                modcomision.VarEntrada = "Adicionar";
                modcomision.ShowDialog();
            }
        }

        private void TsmModificarCms_Click(object sender, EventArgs e)
        {
            if (DgvListado.Rows.Count == 1)
            {
                MessageBox.Show("No Existe Registros para Corregir", "Modificar Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmModificarComision modcomision = new FrmModificarComision();
                modcomision.VarIdCargo = VarIdCargo;
                modcomision.VarIdTercero = VarIdTercero;
                modcomision.VarNombreCargo = VarNombreCargo;
                modcomision.VarNombre = VarNombre;
                modcomision.VarComision1 = VarComision1;
                modcomision.VarComision2 = VarComision2;
                modcomision.VarComision3 = VarComision3;
                modcomision.VarIdadjudicacion = TxtAdjudicacion.Text;
                modcomision.VarCliente = TxtClinte.Text;
                modcomision.VarEntrada = "Modificar";
                modcomision.ShowDialog();
            }
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListado.Rows.Count == 0)
            {
                MessageBox.Show("No Existe Registros para Corregir", "Modificar Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                FrmModificarComision modcomision = new FrmModificarComision();
                modcomision.VarIdCargo = VarIdCargo;
                modcomision.VarIdTercero = VarIdTercero;
                modcomision.VarNombreCargo = VarNombreCargo;
                modcomision.VarNombre = VarNombre;
                modcomision.VarComision1 = VarComision1;
                modcomision.VarComision2 = VarComision2;
                modcomision.VarComision3 = VarComision3;
                modcomision.VarEntrada = "Modificar";
                modcomision.VarIdadjudicacion = TxtAdjudicacion.Text;
                modcomision.VarCliente = TxtClinte.Text;
                modcomision.ShowDialog();
            }
        }

        private void TsmExportar_Click(object sender, EventArgs e)
        {
            exporta_a_excel();
        }


//===================================================================================================================================================
// I N I C I O  M E T O D O  exporta_a_excel
//===================================================================================================================================================
        private void exporta_a_excel()
        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            excel.Cells[1, 2] = "COMISIONES";
            excel.Cells[3, 1] = "Adjudicacion:";
            excel.Cells[3, 2] = TxtAdjudicacion.Text;
            excel.Cells[3, 3] = "Cliente:";
            excel.Cells[3, 4] = TxtClinte.Text;
            excel.Cells[3, 5] = "Inmueble:";
            excel.Cells[3, 6] =  TxtInmueble.Text;
            excel.Cells[4, 1] = "Villa:";
            excel.Cells[4, 2] = TxtVilla.Text;
            excel.Cells[4, 3] = "Semana:";
            excel.Cells[4, 4] =  TxtSemana.Text;
            excel.Cells[4, 5] = "Temporada:";
            excel.Cells[4, 6] = TxtTemporada.Text;

            foreach (DataGridViewColumn col in DgvListado.Columns)
            {
                ColumnIndex++;
                excel.Cells[5, ColumnIndex] = col.Name;
            }

            int rowIndex = 4;

            foreach (DataGridViewRow row in DgvListado.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvListado.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }
            }
            excel.Visible = true;

            Worksheet Libro = (Worksheet)excel.ActiveSheet;
            //Libro.Activate();
        }
//===================================================================================================================================================
//F I N A L   M E T O D O    exporta_a_excel
//===================================================================================================================================================



        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
