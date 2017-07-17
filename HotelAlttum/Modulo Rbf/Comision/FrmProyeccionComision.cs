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
    public partial class FrmProyeccionComision : Form
    {
        public FrmProyeccionComision()
        {
            InitializeComponent();
        }

        #region     REGION DE VARIABLES
        List<string> DatosdeErrores = new List<string>();
        double CuentaErrores = 0;
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        System.Data.DataTable DtListado = new System.Data.DataTable();
        System.Data.DataTable DtRecaudos = new System.Data.DataTable();
        System.Data.DataTable DtComision = new System.Data.DataTable();
        decimal VarBase, VarPorentaje, VarRecMinimo,VarVenta, VarRecaudo, VarRecFaltanteMin,VarRecFaltanteMax,VarRecMaximo, VarComPorPagar;
        string  VarIdAdjudicacion;

        #endregion


        #region  REGION DE EVENTOS

        private void FrmProyeccionComision_Load(object sender, EventArgs e)
        {

            pictureBox1.Image = FrmMenuGeneral.Logo;
            toolStripStatusLabel1.Text = "Usuario Conectado " +FrmLogeo.Usuario;
            DtpFechaIni.Value = DateTime.Today;
            MtdInicio();
        }

        private void DgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvListado.RowCount >1)
            {
                VarIdAdjudicacion = DgvListado.Rows[e.RowIndex].Cells[0].Value.ToString();
                VarVenta = Convert.ToDecimal(DgvListado.Rows[e.RowIndex].Cells[2].Value);
                VarBase = Convert.ToDecimal(DgvListado.Rows[e.RowIndex].Cells[3].Value);
                VarPorentaje = (Convert.ToDecimal(DgvListado.Rows[e.RowIndex].Cells[4].Value))/100;
                LblCliente.Text = DgvListado.Rows[e.RowIndex].Cells[1].Value.ToString();
                VarRecMinimo = (VarPorentaje * VarBase) / 2;
                VarRecMaximo = (VarPorentaje * VarBase);
                LblVrRecaudoMin.Text = VarRecMinimo.ToString();
                LblRcdMaximo.Text = VarRecMaximo.ToString();
                LblVrVenta.Text = VarVenta.ToString();
                LblVrBase.Text = VarBase.ToString();
                LblPorcentaje.Text = VarPorentaje.ToString();
                this.LblVrVenta.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblVrVenta.Text));
                this.LblVrBase.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblVrBase.Text));
                this.LblPorcentaje.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblPorcentaje.Text));
                this.LblRcdMaximo.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblRcdMaximo.Text));
                this.LblVrRecaudoMin.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblVrRecaudoMin.Text));
                DatosRecaudos();
                MtdCnsComision();
                LblComporpagar.Text = VarComPorPagar.ToString();
                this.LblComporpagar.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblComporpagar.Text));
            }

        }

         private void CmbOpcion_SelectedIndexChanged(object sender, EventArgs e)
        {
        switch (CmbOpcion.Text)
            {
                case "Fecha":
             DtpFechaFin.Visible = true; DtpFechaIni.Visible = true   ; TxtAdjudicacion.Visible = false; BtnBuscar.Visible = true;
            DtpFechaIni.Location = new Point(346, 7);
            DtpFechaFin.Location = new Point(456, 7);
            BtnBuscar.Location = new Point(577, 7);

             break;
                case "Adjudicacion":
                DtpFechaFin.Visible = false; DtpFechaIni.Visible = false; TxtAdjudicacion.Visible = true; BtnBuscar.Visible = true;
                TxtAdjudicacion.Location = new Point(346, 7);
                BtnBuscar.Location = new Point(456, 7);

             break;
                case "Cartera Comercial":
                 DtpFechaFin.Visible = false; DtpFechaIni.Visible = false; TxtAdjudicacion.Visible = false; BtnBuscar.Visible = true;
                BtnBuscar.Location = new Point(346, 7);
               

             break;

                    default:

             break;
            }
        }

         private void BtnBuscar_Click(object sender, EventArgs e)
         {
             DgvListado.Rows.Clear();
             DgvComision.Rows.Clear();
             DgvRecaudos.Rows.Clear();
             MtdInicio();
             MtdValidar();
             if (CuentaErrores > 0)
             {
                 FrmMensajeError frmMensajeError = new FrmMensajeError();
                 frmMensajeError.LblErrores.DataSource = DatosdeErrores;
                 frmMensajeError.ShowDialog();
             }
             else
             {

                 BtnBuscar.Cursor = Cursors.AppStarting;
                 BtnBuscar.Enabled = false;
                
                
                 switch (CmbOpcion.Text)
                 {
                     case "Fecha":
                         MtdCarteraFecha();
                         LblTitulo.Text = "CARTERA POR FECHA";

                         break;

                     case "Adjudicacion":
                         LblTitulo.Text = "CARTERA POR ADJUDICACION";
                         MtdCarteraAdjudicacion();
                         break;


                     case "Cartera Comercial":
                         LblTitulo.Text = "CARTERA COMERCIAL";
                         MtdCarteraComercial();
                         break;

                     default:

                         break;
                 }
                 BtnBuscar.Cursor = Cursors.Default;
                 BtnBuscar.Enabled = true;
             }
         }

         private void TxtAdjudicacion_KeyPress(object sender, KeyPressEventArgs e)
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

        #endregion




        #region REGION DE METODOS

//===================================================================================================================================================
// I N I C I O   M E T O D O   I N C I O
//===================================================================================================================================================
         public void MtdInicio()

         {
             LblTitulo.Text = "";
             LblCliente.Text = "";
             LblComporpagar.Text = "0";
             LblPorcentaje.Text = "0";
             LblRcdFaltante.Text = "0";
             LblRcdFaltMax.Text = "0";
             LblRcdMaximo.Text = "0";
             LblRecaudo.Text = "0";
             LblVrBase.Text = "0";
             LblVrRecaudoMin.Text = "0";
             LblVrVenta.Text = "0";
             
             
         }
//===================================================================================================================================================
//F I N A L     M E T O D O  I N I C I O
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O  V A L I D A R
//===================================================================================================================================================
         public void MtdValidar()
         {
            
             DatosdeErrores.Clear();
             CuentaErrores = 0;
             if (CmbOpcion.Text == "Adjudicacion" & TxtAdjudicacion.Text == "")
             {
                 CuentaErrores = CuentaErrores + 1;
                 DatosdeErrores.Add("Falta Anotar Adjudicacion");
             }

             if (CmbOpcion.Text == "Adjudicacion" & TxtAdjudicacion.Text != "")
             {
                decimal cuentaadj =Convert.ToDecimal( NuevoClsIdentificacion.MtdBscDatos("Select Count(IdAdjudicacion) from Adjudicacion where idadjudicacion ="+ TxtAdjudicacion.Text));
                if (cuentaadj == 0)
                {
                    CuentaErrores = CuentaErrores + 1;
                    DatosdeErrores.Add(" Adjudicacion No Existe");
                }
             }
             if (CmbOpcion.Text == "Fecha")
             {
                 int aa = (DtpFechaIni.Value.CompareTo ( DtpFechaFin.Value));
                 if (aa >0)
                 {
                     CuentaErrores = CuentaErrores + 1;
                     DatosdeErrores.Add("Fecha Inicio No puede ser Mayor Fecha Fin");


                 }
             }
         }
//===================================================================================================================================================
//F I N A L     M E T O D O  V A L I D A R 
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O    M E T O D O    C A R T E R A   C O M E R C I A L
//=================================================================================================================================================== 
        public void MtdCarteraComercial()
        {           
            DtListado.Rows.Clear();
            DtListado = NuevoClsIdentificacion.MtdBuscarDataset("select idadjudicacion,Identificacion,Valor,BaseComision,Porcentaje From 004cnsadjudica where "+
            " estado='Aprobado' AND TipoCartera='Comercial'");
            DgvListado.Rows.Clear();

            for (int i = 0; i < (DtListado.Rows.Count); i++)
            {
                DgvListado.Rows.Add(DtListado.Rows[i][0], DtListado.Rows[i][1], DtListado.Rows[i][2], DtListado.Rows[i][3], DtListado.Rows[i][4]);

            }           
        }        
//===================================================================================================================================================
// F I N A L    M E T O D O    D A T O S    A D J U D I C A  C I O N
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O    M E T O D O    C A R T E R A   C O M E R C I A L
//=================================================================================================================================================== 
        public void MtdCarteraAdjudicacion()
        {
            
            DtListado.Rows.Clear();
            DtListado = NuevoClsIdentificacion.MtdBuscarDataset("select idadjudicacion,Identificacion,Valor,BaseComision,Porcentaje From 004cnsadjudica where " +
            "IdAdjudicacion= "+TxtAdjudicacion.Text);
            DgvListado.Rows.Clear();

            for (int i = 0; i < (DtListado.Rows.Count); i++)
            {
                DgvListado.Rows.Add(DtListado.Rows[i][0], DtListado.Rows[i][1], DtListado.Rows[i][2], DtListado.Rows[i][3], DtListado.Rows[i][4]);

            }
        }
//===================================================================================================================================================
// F I N A L    M E T O D O    C A R T E R A   A D J U D I C A C I O N
//===================================================================================================================================================


//===================================================================================================================================================
        // I N I C I O    M E T O D O    C A R T E R A   F E C H A
//=================================================================================================================================================== 
        public void MtdCarteraFecha()
        {
          
            DtListado.Rows.Clear();
            DtListado = NuevoClsIdentificacion.MtdBuscarDataset("select idadjudicacion,Identificacion,Valor,BaseComision,Porcentaje From 004cnsadjudica where"+
                        " IDADJUDICACION IN(SELECT DISTINCTROW(IDADJUDICACION) FROM datosrecaudos WHERE FECHA>='"+NuevoClsIdentificacion.MtdVldFchPed(DtpFechaIni.Value)+
                        "'  AND FECHA <='"+NuevoClsIdentificacion.MtdVldFchPed(DtpFechaFin.Value)+"')");
            DgvListado.Rows.Clear();

            for (int i = 0; i < (DtListado.Rows.Count); i++)
            {
                DgvListado.Rows.Add(DtListado.Rows[i][0], DtListado.Rows[i][1], DtListado.Rows[i][2], DtListado.Rows[i][3], DtListado.Rows[i][4]);

            }
        }
//===================================================================================================================================================
        // F I N A L    M E T O D O    C A R T E R A   F E C H A
//===================================================================================================================================================



       
 //===================================================================================================================================================
// I N I C I O    M E T O D O    D A T O S    R E C A U D O S
//=================================================================================================================================================== 
        public void DatosRecaudos()
        {
            VarRecaudo = 0;
            decimal  Recaudos=0;
            
            DtRecaudos.Rows.Clear();
        DtRecaudos = NuevoClsIdentificacion.MtdBuscarDataset( 
        "Select " +
        "D.NumRecibo, " +
        "D.Fecha," +
        "D.Operacion," +
        "(D.Valor)Total  ," +
        " (SELECT Estado from recaudos where idrecaudo =d.idrecaudo GROUP by idrecaudo ) Estado " +
        "From DatosRecaudos D WHERE   D.IdAdjudicacion = " + VarIdAdjudicacion +" order by NumRecibo");

        DgvRecaudos.Rows.Clear();

        for (int i = 0; i < (DtRecaudos.Rows.Count); i++)
            {
                DgvRecaudos.Rows.Add(DtRecaudos.Rows[i][0], DtRecaudos.Rows[i][1], DtRecaudos.Rows[i][2], DtRecaudos.Rows[i][3], DtRecaudos.Rows[i][4]);

            }

        for (int i = 0; i < (DgvRecaudos.Rows.Count); i++)
        {
            Recaudos = Recaudos + Convert.ToDecimal(DgvRecaudos.Rows[i].Cells[3].Value);

            if ((Convert.ToString(DgvRecaudos.Rows[i].Cells[4].Value) == "Aprobado")&(Convert.ToString(DgvRecaudos.Rows[i].Cells[2].Value) == "Cuota Inicial"))
            {
                VarRecaudo = VarRecaudo + Convert.ToDecimal(DgvRecaudos.Rows[i].Cells[3].Value);
            }
            else
            if (Convert.ToString(DgvRecaudos.Rows[i].Cells[4].Value) == "Pendiente")
            {
                DgvRecaudos.Rows[i].DefaultCellStyle.BackColor = Color.BlueViolet; 
            }
        }

        int a = DgvRecaudos.Rows.Count - 1;
        DgvRecaudos.Rows[a].Cells[2].Value = "T O T A L  . .";
        DgvRecaudos.Rows[a].Cells[3].Value = Recaudos;
        DgvRecaudos.Rows[a].DefaultCellStyle.BackColor = Color.Silver; 
        VarRecFaltanteMin = VarRecMinimo - VarRecaudo;
        VarRecFaltanteMax = VarRecMaximo - VarRecaudo;
        if (VarRecFaltanteMin < 0)
        {
            VarRecFaltanteMin = 0;
        }

        if (VarRecFaltanteMax < 0)
        {
            VarRecFaltanteMax = 0;
        }

       
        LblRecaudo.Text = VarRecaudo.ToString();
        LblRcdFaltante.Text = VarRecFaltanteMin.ToString();
        LblRcdFaltMax.Text = VarRecFaltanteMax.ToString();
        this.LblRcdFaltMax.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblRcdFaltMax.Text));
        this.LblRecaudo.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblRecaudo.Text));
        this.LblRcdFaltante.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.LblRcdFaltante.Text)); 

        }        
//===================================================================================================================================================
// F I N A L    M E T O D O    D A T O S    R E C A U D O S
//===================================================================================================================================================




//===================================================================================================================================================
// I N I C I O   M E T O D O   C O N S U L T A R   C O M I S  I O N
//===================================================================================================================================================
        public void MtdCnsComision()
        {
            DtComision.Clear();
            DgvComision.Rows.Clear();
            decimal VarpagoCom = 0;
            decimal VarCom1 = 0;
            decimal VarCom2 = 0;
            decimal VarComPag = 0;
            decimal VarPor1 = 0;
            decimal VarPor2= 0;
            decimal VarReten = 0;
            decimal VarAntic = 0;
            decimal VarNeto = 0;
            DtComision = NuevoClsIdentificacion.MtdBuscarDataset("Select Nombres,NombreCargo,Comision1,Comision2,LqdCom1,LqdCom2,PagoComision,TotalComision,Retencion,SaldoAnticipo,PagoNeto" +
            "  From 006comisionxPagar WHERE IdAdjudicacion= " + (VarIdAdjudicacion) +" Order by IdCargo");
            {
                for (int i = 0; i < (DtComision.Rows.Count); i++)
                {
                    DgvComision.Rows.Add(DtComision.Rows[i][0], DtComision.Rows[i][1], DtComision.Rows[i][2], DtComision.Rows[i][3], DtComision.Rows[i][4], DtComision.Rows[i][5], DtComision.Rows[i][6], DtComision.Rows[i][7],
                        DtComision.Rows[i][8], DtComision.Rows[i][9], DtComision.Rows[i][10]);
                }
            }


            for (int i = 0; i < (DgvComision.Rows.Count); i++)
            {
                VarPor1 = VarPor1 + Convert.ToDecimal(DgvComision.Rows[i].Cells[2].Value);
                VarPor2 = VarPor2 + Convert.ToDecimal(DgvComision.Rows[i].Cells[3].Value);
                VarCom1 = VarCom1 + Convert.ToDecimal(DgvComision.Rows[i].Cells[4].Value);
                VarCom2 = VarCom2 + Convert.ToDecimal(DgvComision.Rows[i].Cells[5].Value);
                VarComPag = VarComPag + Convert.ToDecimal(DgvComision.Rows[i].Cells[6].Value);
                VarpagoCom = VarpagoCom + Convert.ToDecimal(DgvComision.Rows[i].Cells[7].Value);
                VarReten = VarReten + Convert.ToDecimal(DgvComision.Rows[i].Cells[8].Value);
                VarAntic = VarAntic + Convert.ToDecimal(DgvComision.Rows[i].Cells[9].Value);
                VarNeto = VarNeto + Convert.ToDecimal(DgvComision.Rows[i].Cells[10].Value);
               

           }

            int a = DgvComision.Rows.Count - 1;
            DgvComision.Rows[a].Cells[1].Value = "T O T A L  . .";
            DgvComision.Rows[a].Cells[2].Value = VarPor1;
            DgvComision.Rows[a].Cells[3].Value = VarPor2;
            DgvComision.Rows[a].Cells[4].Value = VarCom1;
            DgvComision.Rows[a].Cells[5].Value = VarCom2;
            DgvComision.Rows[a].Cells[6].Value = VarComPag;
            DgvComision.Rows[a].Cells[7].Value = VarpagoCom;
            DgvComision.Rows[a].Cells[8].Value = VarReten;
            DgvComision.Rows[a].Cells[9].Value = VarAntic;
            DgvComision.Rows[a].Cells[10].Value = VarNeto;
            VarComPorPagar = VarpagoCom;
            DgvComision.Rows[a].DefaultCellStyle.BackColor = Color.Silver; 
        }
//===================================================================================================================================================
//F I N A L     M E T O D O   C O N S U L T A R    C O  M I S I O N
//===================================================================================================================================================

        #endregion



    }
}
