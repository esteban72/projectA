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
    public partial class FrmModuloTablaComisiones : Form
    {
        public FrmModuloTablaComisiones()
        {
            InitializeComponent();
        }
        System.Data.DataTable DtComision = new System.Data.DataTable();
        decimal SumComision = 0;
        decimal SumComisionMonterrey = 0;

        string Sentencia = "Select c.idcargo,c.NombreCargo,c.IdTercero,t.NombreCompleto,c.Comision,c.Comision2, c.Recaudo1,c.Anticipo1,c.Recaudo2,c.Anticipo2 " +
                           " From tablacomisiones c Left join Contabilidad_alttum.Terceros t on t.idtercero=c.idtercero ";
        string VarId, VarIdTercero, VarNombreAsesor, VarNombreCargo, VarComision, VarRecaudo1, VarAnticipo1, VarRecaudo2, VarAnticipo2, VarComision2;
      
      
       
        ClsIdentificacion conexion = new ClsIdentificacion();


        private void FrmModuloTablaComisiones_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo; ;
            DtComision = conexion.MtdBuscarDataset(Sentencia);
            DgvListado.Rows.Clear();
            for (int i = 0; i < (DtComision.Rows.Count); i++)
            {
                DgvListado.Rows.Add(DtComision.Rows[i][0], DtComision.Rows[i][1], DtComision.Rows[i][2], DtComision.Rows[i][3], DtComision.Rows[i][4], DtComision.Rows[i][5],
                    DtComision.Rows[i][6], DtComision.Rows[i][7], DtComision.Rows[i][8], DtComision.Rows[i][9]);
            }
            LblRegistros.Text = DgvListado.Rows.Count.ToString();
            SumComision = 0;
            for (int i = 0; i < (DgvListado.Rows.Count); i++)
            {
                SumComision += (Convert.ToDecimal(DgvListado.Rows[i].Cells[4].Value));    
            }
            LblSumaComision.Text = Convert.ToString(SumComision);       
            this.LblSumaComision.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSumaComision.Text));
            btnAdd.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "905");
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, "905");
            BtnElm.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, "905");          

        }

        private void DgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            VarId = DgvListado.Rows[e.RowIndex].Cells[0].Value.ToString();
            VarNombreCargo = DgvListado.Rows[e.RowIndex].Cells[1].Value.ToString();
            VarIdTercero = DgvListado.Rows[e.RowIndex].Cells[2].Value.ToString();
            VarNombreAsesor = DgvListado.Rows[e.RowIndex].Cells[3].Value.ToString();
            VarComision = DgvListado.Rows[e.RowIndex].Cells[4].Value.ToString();
            VarComision2 = DgvListado.Rows[e.RowIndex].Cells[5].Value.ToString();
            VarRecaudo1 = DgvListado.Rows[e.RowIndex].Cells[6].Value.ToString();
            VarAnticipo1 = DgvListado.Rows[e.RowIndex].Cells[7].Value.ToString();
            VarRecaudo2 = DgvListado.Rows[e.RowIndex].Cells[8].Value.ToString();
            VarAnticipo2 = DgvListado.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmTablaComisiones comision = new FrmTablaComisiones();
            comision.Entrada = "Adicionar";
            comision.ShowDialog();
        }

        private void BtnMod_Click(object sender, EventArgs e)
        {
            FrmTablaComisiones comision = new FrmTablaComisiones();
            comision.Entrada = "Modificar";
            comision.VarId = VarId;
            comision.VarNombreCargo = VarNombreCargo;
            comision.VarComision = VarComision;
            comision.VarComision2 = VarComision2;
            comision.VarIdTercero = VarIdTercero;
            comision.VarNombreAsesor=VarNombreAsesor;
            comision.VarRecaudo1 = VarRecaudo1;
            comision.VarAnticipo1 = VarAnticipo1;
            comision.VarRecaudo2 = VarRecaudo2;
            comision.VarAnticipo2 = VarAnticipo2;
            comision.ShowDialog();

        }

        private void BtnElm_Click(object sender, EventArgs e)
        {
            FrmTablaComisiones comision = new FrmTablaComisiones();
            comision.Entrada = "Eliminar";
            comision.VarId = VarId;
            comision.VarNombreCargo = VarNombreCargo;
            comision.VarComision = VarComision;
            comision.VarComision2 = VarComision2;
            comision.VarIdTercero = VarIdTercero;
            comision.VarNombreAsesor = VarNombreAsesor;
            comision.VarRecaudo1 = VarRecaudo1;
            comision.VarAnticipo1 = VarAnticipo1;
            comision.VarRecaudo2 = VarRecaudo2;
            comision.VarAnticipo2 = VarAnticipo2;
            comision.ShowDialog();
        }

        private void BtnCns_Click(object sender, EventArgs e)
        {
            FrmTablaComisiones comision = new FrmTablaComisiones();
            comision.Entrada = "Consultar";
            comision.VarId = VarId;
            comision.VarNombreCargo = VarNombreCargo;
            comision.VarComision = VarComision;
            comision.VarComision2 = VarComision2;
            comision.VarIdTercero = VarIdTercero;
            comision.VarNombreAsesor = VarNombreAsesor;
            comision.VarRecaudo1 = VarRecaudo1;
            comision.VarAnticipo1 = VarAnticipo1;
            comision.VarRecaudo2 = VarRecaudo2;
            comision.VarAnticipo2 = VarAnticipo2;
            comision.ShowDialog();
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            exporta_a_excel();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmModuloTablaComisiones_Activated(object sender, EventArgs e)
        {
            DtComision = conexion.MtdBuscarDataset(Sentencia);
            DgvListado.Rows.Clear();
            for (int i = 0; i < (DtComision.Rows.Count); i++)
            {
                DgvListado.Rows.Add(DtComision.Rows[i][0], DtComision.Rows[i][1], DtComision.Rows[i][2], DtComision.Rows[i][3], DtComision.Rows[i][4], DtComision.Rows[i][5],
                DtComision.Rows[i][6], DtComision.Rows[i][7], DtComision.Rows[i][8], DtComision.Rows[i][9]);
            }
            SumComision = 0;
            LblRegistros.Text = DgvListado.Rows.Count.ToString();
            for (int i = 0; i < (DgvListado.Rows.Count); i++)
            {
                SumComision += (Convert.ToDecimal(DgvListado.Rows[i].Cells[4].Value));
                SumComisionMonterrey += (Convert.ToDecimal(DgvListado.Rows[i].Cells[5].Value));
            }
            LblSumaComision.Text = Convert.ToString(SumComision);
            LblComMonterrey.Text = Convert.ToString(SumComisionMonterrey);
            this.LblSumaComision.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblSumaComision.Text));
            this.LblComMonterrey.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblComMonterrey.Text));
            btnAdd.Enabled = conexion.MtdBscFrmIdFrm("Adicionar", FrmLogeo.FrmUsuarioIdUsr, "905");
            BtnMod.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, "905");
            BtnElm.Enabled = conexion.MtdBscFrmIdFrm("Eliminar", FrmLogeo.FrmUsuarioIdUsr, "905"); 
        }


//===============================================================================================================================
//I N I C I O   M E T O D O   E X P O R T A R   A    E X C E L 
//===============================================================================================================================
        public void exporta_a_excel()
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            excel.Cells[1, 3] = "TABLA GENERAL DE COMISIONES";
                                 

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
//===============================================================================================================================
//F I N A L    M E T O D O   E X P O R T A R    A     E X C E L 
//===============================================================================================================================

    }
}
