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
    public partial class FrmCnsComisionxPagar : Form
    {
        public FrmCnsComisionxPagar()
        {
            InitializeComponent();
        }
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        System.Data.DataTable DtDatos = new System.Data.DataTable();
       
        //string Sentencia =
        //" select " +
        //"IdAdjudicacion, " +
        //"Cliente, " +
        //"Nombres as Gestor, " +
        //"Upper(Nombrecargo) as Cargo, " +       
        //"comision1 as Com1," +
        //"Comision2 as Com2," +        
        //"LqdCom1," +
        //"LqdCom2," +
        //"pagocomision," +
        //"TotalComision," +
        //"Retencion," +
        //"SaldoAnticipo," +
        //"PagoNeto " +
        //"from 006comisionxpagar where TotalComision >5 ";



        private void FrmCnsComisionxPagar_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            DtDatos = NuevoClsIdentificacion.MtdBuscarDataset(MisConsultas.ComisionesPorPagarNetas);
            if (DtDatos.Rows.Count > 0)
            {
                DatosAdj();
            }
        }


//===================================================================================================================================================
// I N I C I O    M E T O D O    D A T O S    DatosAdj
//===================================================================================================================================================
        public void DatosAdj()
        {
            decimal SumTotalValor = 0;
            decimal Valor13=0,Valor14=0 ,Valor12 = 0, Valor11 = 0, Valor10 = 0, Valor9 = 0, Valor8 = 0, Valor7 = 0, Valor6 = 0, Valor5 = 0, Valor4 = 0;
            DgvListado.Rows.Clear();
            int VarAdj, a=0;
            VarAdj = Convert.ToInt16(DtDatos.Rows[0][0]);
            {
                for (int i = 0; i< (DtDatos.Rows.Count); i++)
                {
                    if (VarAdj == Convert.ToInt16(DtDatos.Rows[i][0]))
                    {
                      
                        DgvListado.Rows.Add(DtDatos.Rows[i][0], DtDatos.Rows[i][1], DtDatos.Rows[i][2], DtDatos.Rows[i][3], DtDatos.Rows[i][4], DtDatos.Rows[i][5],
                        DtDatos.Rows[i][6], DtDatos.Rows[i][7], DtDatos.Rows[i][8], DtDatos.Rows[i][9], DtDatos.Rows[i][10], DtDatos.Rows[i][11], DtDatos.Rows[i][12],
                        DtDatos.Rows[i][13],DtDatos.Rows[i][14]);
                    
                        a = DgvListado.Rows.Count - 1;

                        Valor13 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[13].Value));
                        Valor14 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[14].Value));
                        Valor12 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[12].Value));
                        Valor11 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[11].Value));
                        Valor10 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[10].Value));
                        Valor9 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[9].Value));
                        Valor8 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[8].Value));
                        Valor7 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[7].Value));
                        Valor6 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[6].Value));
                        Valor5 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[5].Value));
                        Valor4 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[4].Value));
                    }

                    else
                    {
                        DgvListado.Rows.Add();
                        a = DgvListado.Rows.Count - 1;
                        DgvListado.Rows[a].Cells[2].Value = "T O T A L  . .";
                        DgvListado.Rows[a].Cells[13].Value = Valor13;
                        DgvListado.Rows[a].Cells[14].Value = Valor14;

                        DgvListado.Rows[a].Cells[12].Value = Valor12;
                        DgvListado.Rows[a].Cells[11].Value = Valor11;
                        DgvListado.Rows[a].Cells[10].Value = Valor10;
                        DgvListado.Rows[a].Cells[9].Value = Valor9;
                        DgvListado.Rows[a].Cells[8].Value = Valor8;
                        DgvListado.Rows[a].Cells[7].Value = Valor7;
                        DgvListado.Rows[a].Cells[6].Value = Valor6;
                        DgvListado.Rows[a].Cells[5].Value = Valor5;
                        DgvListado.Rows[a].Cells[4].Value = Valor4;
                        DgvListado.Rows[a].DefaultCellStyle.BackColor = Color.SteelBlue;
                        DgvListado.Rows[a].DefaultCellStyle.ForeColor = Color.White;
                        DgvListado.Rows.Add();
                        VarAdj = Convert.ToInt16(DtDatos.Rows[i][0]);
                        Valor12 = 0; Valor11 = 0; Valor10 = 0; Valor9 = 0; Valor8 = 0; Valor7 = 0; Valor6 = 0; Valor5 = 0; Valor4 = 0;
                        Valor13 = 0; Valor14 = 0;
                        DgvListado.Rows.Add(DtDatos.Rows[i][0], DtDatos.Rows[i][1], DtDatos.Rows[i][2], DtDatos.Rows[i][3], DtDatos.Rows[i][4], DtDatos.Rows[i][5],
                        DtDatos.Rows[i][6], DtDatos.Rows[i][7], DtDatos.Rows[i][8], DtDatos.Rows[i][9], DtDatos.Rows[i][10], DtDatos.Rows[i][11], DtDatos.Rows[i][12],
                        DtDatos.Rows[i][13], DtDatos.Rows[i][14]);
                        a = DgvListado.Rows.Count - 1;
                        Valor13 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[13].Value));
                        Valor14 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[14].Value));
                        Valor12 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[12].Value));
                        Valor11 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[11].Value));
                        Valor10 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[10].Value));
                        Valor9 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[9].Value));
                        Valor8 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[8].Value));
                        Valor7 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[7].Value));
                        Valor6 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[6].Value));
                        Valor5 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[5].Value));
                        Valor4 += (Convert.ToDecimal(DgvListado.Rows[a].Cells[4].Value));
                    }

                   }
                 DgvListado.Rows.Add();
                a = DgvListado.Rows.Count - 1;
                DgvListado.Rows[a].Cells[2].Value = "T O T A L  . .";
                DgvListado.Rows[a].Cells[13].Value = Valor13;
                DgvListado.Rows[a].Cells[14].Value = Valor14;
                DgvListado.Rows[a].Cells[12].Value = Valor12;
                DgvListado.Rows[a].Cells[11].Value = Valor11;
                DgvListado.Rows[a].Cells[10].Value = Valor10;
                DgvListado.Rows[a].Cells[9].Value = Valor9;
                DgvListado.Rows[a].Cells[8].Value = Valor8;
                DgvListado.Rows[a].Cells[7].Value = Valor7;
                DgvListado.Rows[a].Cells[6].Value = Valor6;
                DgvListado.Rows[a].Cells[5].Value = Valor5;
                DgvListado.Rows[a].Cells[4].Value = Valor4;
                DgvListado.Rows[a].DefaultCellStyle.BackColor = Color.SteelBlue;
                DgvListado.Rows[a].DefaultCellStyle.ForeColor = Color.White;
                DgvListado.Rows.Add();
               
              
                
                
            }
        LblNumRegistros.Text = Convert.ToString(DtDatos.Rows.Count);
            
            for (int i = 0; i < (DtDatos.Rows.Count); i++)
            {
                SumTotalValor += Convert.ToDecimal(DtDatos.Rows[i][14]);

            }
           LblTotalComision.Text = Convert.ToString(SumTotalValor);
           this.LblTotalComision.Text = String.Format("{0:#,##0.00;-#,##0.00;0.00}", decimal.Parse(this.LblTotalComision.Text));

        }
//===================================================================================================================================================
// F I N A L    M E T O D O    D A T O S    DatosAdj
//===================================================================================================================================================

//===================================================================================================================================================
//I N I C I O   M E T O D O   E X P O R T A R   A    E X C E L 
//===================================================================================================================================================
        public void exporta_a_excel()
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            foreach (DataGridViewColumn col in DgvListado.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }

            int rowIndex = 0;

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
//F I N A L    M E T O D O   E X P O R T A R    A     E X C E L 
//===================================================================================================================================================



        private void TsmExportar_Click(object sender, EventArgs e)
        {
            exporta_a_excel();
        }

        private void TsmSalir_Click(object sender, EventArgs e)
        {
            Close();
        }


      
    }
}
