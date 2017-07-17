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
    public partial class FrmCnsRecaudos : Form
    {
        public FrmCnsRecaudos()
        {
            InitializeComponent();
        }
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        public string VarIdAdjudicacion, VarCliente, VarIdInmueble;
        System.Data.DataTable DtListado = new System.Data.DataTable();
        Double SumAprobado, SumPendiente, SumDevuelto,SumTotal;
        int  CuentaAprobado, CuentaPendiente, CuentaDevuelto;
        System.Data.DataTable DtDatos = new System.Data.DataTable();
        string Sentencia ="";
       
       
    private void FrmCnsRecaudos_Load(object sender, EventArgs e)
        {
            TxtAdjudicacion.Text = VarIdAdjudicacion;
            TxtInmueble.Text = VarIdInmueble;
            TxtNombre1.Text = VarCliente;
             Sentencia=
            "Select " +
           "D.NumRecibo, " +
           "D.Fecha," +
           "D.Operacion," +
           "(D.Valor)Total  ," +
           " (SELECT Estado from recaudos where idrecaudo =d.idrecaudo GROUP by idrecaudo ) Estado " +
           "From DatosRecaudos D WHERE   D.IdAdjudicacion = " + VarIdAdjudicacion + " order by NumRecibo";
            pictureBox1.Image = FrmMenuGeneral.Logo;      
            DtListado = NuevoClsIdentificacion.MtdBuscarDataset(Sentencia);
            DatosAdj();
        }


    private void BtnSalir_Click_1(object sender, EventArgs e)
    {
        Close();
    }


    private void BtnExportar_Click(object sender, EventArgs e)
    {
        exporta_a_excel();
    }




//===================================================================================================================================================
// I N I C I O    M E T O D O    D A T O S    A D J U D I C A C I O N 
//===================================================================================================================================================
public void DatosAdj()
{
      
   
    DgvListado.Rows.Clear();

    for (int i = 0; i < (DtListado.Rows.Count); i++)
    {
        DgvListado.Rows.Add(DtListado.Rows[i][0], DtListado.Rows[i][1], DtListado.Rows[i][2], DtListado.Rows[i][3],DtListado.Rows[i][4]);     
    }

    CuentaAprobado = 0;
    CuentaDevuelto = 0;
    CuentaPendiente = 0;
    SumAprobado = 0;
    SumDevuelto = 0;
    SumPendiente = 0;
  
    for (int i = 0; i < (DgvListado.Rows.Count); i++)
    {
        if (Convert.ToString(DgvListado.Rows[i].Cells[4].Value) == "Pendiente")
        {
            SumPendiente += (Convert.ToDouble(DgvListado.Rows[i].Cells[3].Value));
            CuentaPendiente = CuentaPendiente + 1;
            DgvListado.Rows[i].DefaultCellStyle.BackColor = Color.Brown;
        }
        if (Convert.ToString(DgvListado.Rows[i].Cells[4].Value) == "Aprobado")
        {
            SumAprobado += (Convert.ToDouble(DgvListado.Rows[i].Cells[3].Value));
            CuentaAprobado = CuentaAprobado + 1;
        }
        if (Convert.ToString(DgvListado.Rows[i].Cells[4].Value) == "Devuelto")
        {
            SumDevuelto += (Convert.ToDouble(DgvListado.Rows[i].Cells[3].Value));
            CuentaDevuelto += CuentaDevuelto + 1;
            DgvListado.Rows[i].DefaultCellStyle.BackColor = Color.BlueViolet; 
        }

        
        

    }
    TxtAprobado.Text = Convert.ToString(SumAprobado);
    TxtDevuelto.Text  = Convert.ToString(SumDevuelto);
    TxtPendiente.Text  = Convert.ToString(SumPendiente);
    LblCuentaApr.Text = Convert.ToString(CuentaAprobado);
    LblCuentaPend.Text = Convert.ToString(CuentaPendiente);
    LblCuentaDev.Text  = Convert.ToString(CuentaDevuelto);
    SumTotal = SumAprobado + SumDevuelto + SumPendiente;
    LblCuentaTotal.Text = Convert.ToString((CuentaAprobado + CuentaDevuelto + CuentaPendiente));
    TxtTotal.Text = Convert.ToString(SumTotal);
    this.TxtAprobado.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtAprobado.Text));
    this.TxtDevuelto.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtDevuelto.Text));
    this.TxtPendiente.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtPendiente.Text));
    this.TxtTotal.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtTotal.Text));
}
//===================================================================================================================================================
// F I N A L    M E T O D O    D A T O S    A D J U D I C A C I O N
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O    M E T O D O   exporta_a_excel
//===================================================================================================================================================
    private void exporta_a_excel()
    {
        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        excel.Application.Workbooks.Add(true);

        int ColumnIndex = 0;

        excel.Cells[1, 2] = "CONSULTA DE RECAUDOS";
        excel.Cells[3, 1] = "Titular:";
        excel.Cells[3, 2] = TxtNombre1.Text;
        excel.Cells[4, 1] = "Inmueble:";
        excel.Cells[4, 2] = TxtInmueble.Text;
        excel.Cells[5, 1] = "Adjudicacion:";
        excel.Cells[5, 2] = TxtAdjudicacion.Text;

        foreach (DataGridViewColumn col in DgvListado.Columns)
        {
            ColumnIndex++;
            excel.Cells[7, ColumnIndex] = col.Name;
        }

        int rowIndex = 7;

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
        rowIndex = rowIndex + 3;
        excel.Cells[rowIndex, 2] = "TOTAL RECAUDOS";
        excel.Cells[rowIndex, 4] = TxtTotal.Text;

        excel.Visible = true;

        Worksheet Libro = (Worksheet)excel.ActiveSheet;
        Libro.Activate();
    }    
//===================================================================================================================================================
// F I N A L    M E T O D O   exporta_a_excel
//===================================================================================================================================================




    }
}
