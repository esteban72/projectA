using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace CarteraGeneral
{
    public partial class FrmCnsRcdFecha : Form
    {
        public FrmCnsRcdFecha()
        {
            InitializeComponent();
        }
        System.Data.DataTable DtDatosReg = new System.Data.DataTable();
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        double SumaAprobado, SumaDevuelto, SumaPendiente, CuentaAprobado, CuentaDevuelto, CuentaPendiente = 0, SumaTotal;
        string Sentencia;
       //string  Scrip =
       //   "Select " +
       //    "D.idAdjudicacion," +
       //    "C.Identificacion as Cliente," +
       //    "D.NumRecibo, " +
       //    "D.Fecha, " +
       //    "D.Operacion, " +
       //    "D.Valor as Total, "+
       //    "D.FormaPago," +
       //    "(SELECT Estado from recaudos where idrecaudo =d.idrecaudo GROUP by idrecaudo ) Estado,  " +
       //    "C.TipoOperacion"+
       //    "From DatosRecaudos D left join  004cnsadjudica C on c.idadjudicacion=d.idadjudicacion ";

        string Scrip ="Select D.idAdjudicacion, C.Identificacion as Cliente, D.NumRecibo, D.Fecha, D.Operacion, D.Valor as Total, D.FormaPago, (SELECT Estado from recaudos where idrecaudo =d.idrecaudo GROUP by idrecaudo ) Estado, C.TipoOperacion From DatosRecaudos D left join  004cnsadjudica C on c.idadjudicacion=d.idadjudicacion ";
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }




//===================================================================================================================================================
// I N I C I O    M E T O D O    D A T O S    R E C A U D O S
//=================================================================================================================================================== 
        public void MtdDatosRecaudos()
        {
            SumaAprobado = 0;
            SumaTotal = 0;
            SumaDevuelto = 0;
            SumaPendiente = 0;
            CuentaAprobado = 0;
            CuentaDevuelto = 0;
            CuentaPendiente = 0;

            for (int i = 0; i < (DgvConslta.Rows.Count); i++)
            {
                if (Convert.ToString(DgvConslta.Rows[i].Cells[7].Value) == "Aprobado")
                {
                    SumaAprobado += (Convert.ToDouble(DgvConslta.Rows[i].Cells[5].Value));
                    CuentaAprobado = CuentaAprobado + 1;
                }
                if (Convert.ToString(DgvConslta.Rows[i].Cells[7].Value) == "Devuelto")
                {
                    SumaDevuelto += (Convert.ToDouble(DgvConslta.Rows[i].Cells[5].Value));
                    DgvConslta.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    CuentaDevuelto = CuentaDevuelto + 1;
                }
                if (Convert.ToString(DgvConslta.Rows[i].Cells[7].Value) == "Pendiente")
                {
                    CuentaPendiente = CuentaPendiente + 1;
                    SumaPendiente += (Convert.ToDouble(DgvConslta.Rows[i].Cells[5].Value));
                    DgvConslta.Rows[i].DefaultCellStyle.BackColor = Color.Khaki;
                }
                SumaTotal += (Convert.ToDouble(DgvConslta.Rows[i].Cells[5].Value));
            }


            TxtCtaAprobado.Text = Convert.ToString(CuentaAprobado);
            TxtAprobados.Text = Convert.ToString(SumaAprobado);
            this.TxtAprobados.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtAprobados.Text));
            TxtCtaDev.Text = Convert.ToString(CuentaDevuelto);
            TxtDevueltos.Text = Convert.ToString(SumaDevuelto);
            this.TxtDevueltos.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtDevueltos.Text));
            TxtCtaPdte.Text = Convert.ToString(CuentaPendiente);
            TxtPendientes.Text = Convert.ToString(SumaPendiente);
            this.TxtPendientes.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtPendientes.Text));
            TxtTotal.Text = Convert.ToString(SumaTotal);
            TxtCtaTotal.Text = Convert.ToString(DgvConslta.Rows.Count);
            this.TxtTotal.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtTotal.Text));

        }
//===================================================================================================================================================
// F I N A L    M E T O D O    D A T O S    R E C A U D O S
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   M E T O D O   E X P O R T A R   A    E X C E L 
//===================================================================================================================================================
        public void exporta_a_excel()
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null; 

            try 
            { 
 

           // excel.Application.Workbooks.Add(true);

            worksheet = workbook.ActiveSheet;

            worksheet.Name = "ExportedFromDatGrid"; 

            int ColumnIndex = 0;

            foreach (DataGridViewColumn col in DgvConslta.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }

            int rowIndex = 0;

            foreach (DataGridViewRow row in DgvConslta.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvConslta.Columns)
                {
                    ColumnIndex++;
                 //   excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                    worksheet.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;

                }

            }

            //Getting the location and file name of the excel to save from user. 
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveDialog.FilterIndex = 2;

            if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                workbook.SaveAs(saveDialog.FileName);
                MessageBox.Show("Export Successful");
            }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            } 

        // excel.Visible = true;
           
           

      //  Worksheet Libro = (Worksheet)excel.ActiveSheet;

       

            //Libro.Activate();

        }
//===================================================================================================================================================
//F I N A L    M E T O D O   E X P O R T A R    A     E X C E L 
//===================================================================================================================================================

//===================================================================================================================================================
// I N I C I O    M E T O D O    D A T O S
//===================================================================================================================================================
        public void MtdDatosReg()
        {
            
            DgvConslta.Rows.Clear();
            for (int i = 0; i < (DtDatosReg.Rows.Count); i++)
            {

                DgvConslta.Rows.Add(DtDatosReg.Rows[i][0], DtDatosReg.Rows[i][1], DtDatosReg.Rows[i][2], DtDatosReg.Rows[i][3], DtDatosReg.Rows[i][4], DtDatosReg.Rows[i][5], DtDatosReg.Rows[i][6], DtDatosReg.Rows[i][7], DtDatosReg.Rows[i][8]);

            }

            gridControl1.DataSource = DtDatosReg;

        }
//===================================================================================================================================================
// F I N A L    M E T O D O    D A T O S
//===================================================================================================================================================


        private void FrmCnsRcdFecha_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            toolStripStatusLabel1.Text = "Usuario Conectado " ;

        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {

            if (CmbTipoCartera.Text == "")
            {
                MessageBox.Show("Falta seleccionar tipo cartera", "Recaudos Por Fecha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                BtnCalcular.Enabled = false;
                BtnCalcular.Cursor = Cursors.AppStarting;



                switch (CmbTipoCartera.Text)
                {
                    case "Cuota Inicial":
                        Sentencia = Scrip + "WHERE D.fecha >= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' And D.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value) + "' " +
                        " and Operacion = 'Cuota Inicial' order by NumRecibo;";

                        break;

                    case "Financiacion":
                        Sentencia = Scrip + "WHERE D.fecha >= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' And D.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value) + "' " +
                     " and Operacion = 'Financiacion' order by NumRecibo;";
                        break;


                    case "Contado":
                        Sentencia = Scrip + "WHERE D.fecha >= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' And D.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value) + "' " +
                 " and Operacion = 'Contado' order by NumRecibo;";


                        break;

                    case "Extraordinaria":

                        Sentencia = Scrip + "WHERE D.fecha >= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' And D.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value) + "' " +
                 " and Operacion = 'Extraordinaria' order by NumRecibo;";
                        break;



                    case "Administrativa":

                        Sentencia = Scrip + "WHERE D.fecha >= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' And D.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value) + "' " +
                 " and Operacion != 'Cuota Inicial' order by NumRecibo;";
                        break;



                    case "Todos":
                        Sentencia = Scrip + "WHERE D.fecha >= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' And D.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value) + "' " +
                   "  order by NumRecibo;";
                        break;

                    case "Anulados":
                        Sentencia = Scrip + "WHERE D.fecha >= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaCorte.Value) + "' And D.Fecha <= '" + NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value) + "' " +
                 " and C.TipoOperacion IS Null order by NumRecibo;";
                        break;


                    default:

                        break;


                }
               DtDatosReg= NuevoClsIdentificacion.MtdBuscarDataset(Sentencia);
               MtdDatosReg();
                MtdDatosRecaudos();
                BtnCalcular.Enabled = true;
                BtnCalcular.Cursor = Cursors.Default;
            }
        }

        private void BtnExportar_Click(object sender, EventArgs e)
        {
            //exporta_a_excel();

                PrintableComponentLink link = new PrintableComponentLink(new PrintingSystem());
                 link.Component = gridControl1;
                 link.CreateMarginalHeaderArea += new CreateAreaEventHandler(Link_CreateMarginalHeaderArea);
                 link.CreateDocument();
                 link.ShowPreview();
        }

        private void Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            DevExpress.XtraPrinting.TextBrick brick;
            DevExpress.XtraPrinting.ImageBrick imagen;
            brick = e.Graph.DrawString("RECAUDOS POR FECHA ", Color.Navy, new RectangleF(160, 0, 455, 60), DevExpress.XtraPrinting.BorderSide.None);
          //  imagen = e.Graph.DrawImage(global::HotelAlttum.Properties.Resources.Logo_del_poblado_02, new RectangleF(10, 0, 150, 50), DevExpress.XtraPrinting.BorderSide.None, Color.Transparent);
       //     brick.Font = new Font("Arial", 10, FontStyle.Bold);
            //brick.BackColor = Color.Blue;
            brick.ForeColor = Color.Gray;
            brick.StringFormat = new DevExpress.XtraPrinting.BrickStringFormat(StringAlignment.Center);
        }


    }
}
