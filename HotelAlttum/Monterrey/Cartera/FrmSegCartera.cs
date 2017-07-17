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
    public partial class FrmSegCartera : Form
    {
        public FrmSegCartera()
        {
            InitializeComponent();
        }

        #region REGION DE VARIABLES 
        string VarIdAdjudicacion;
        DataTable DtCuotas = new DataTable();
        DataTable DtParametros = new DataTable();
        DataTable DtSeguimiento = new DataTable();
        string StrInteresCte, StrInteresMora, StrPeriodo, StrDiaMora, StrDecimales;
        DataTable DtDatos = new DataTable();
        string SentenciaCuotas = "";
        string SentenciaSeguimiento = "";
        string SentenciaDatos = "";
        string SentenciaRecaudos = "";
        public string EntradaSeguimiento;
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        string DatosNombre;
        DataTable DtListado = new DataTable();
        Double SumAprobado, SumPendiente, SumDevuelto,PagoMinimo;
        int CuentaAprobado, CuentaPendiente, CuentaDevuelto;

        string scrip=" Select f.IdAdjudicacion as Adj, j.Identificacion as Nombre,f.Concepto as Cto, f.DiasMoraInt as Dias,f.Tipocartera as Gestion "+
                        "from "+
                        "( "+
                        " select "+ 
                        " f.IdAdjudicacion AS IdAdjudicacion, "+
                        " f.Concepto AS Concepto, "+
                        " f.NumCuota AS CuotaNum,"+
                        " min(f.Fecha) AS Fecha,"+
                        " sum(f.Capital) AS TtCapital,"+
                        " sum(f.Interes) AS TtInteresCte,"+
                        " sum(f.SaldoCuota) AS TtCuotas,"+
                        " max(f.UltimaFechaPago) AS UltimoPago,"+
                        " sum(f.RcdCapital) AS TtRcdCapital,"+
                        " sum(f.RcdInteres) AS TtRcdInteresCte,"+
                        " sum(f.RcdCuota) AS TtRcdCuota,"+
                        " sum(f.MoraCalc) AS TtMoraCal,"+
                        " sum(f.SaldoCapital) AS TtSdoCapital,"+
                        " sum(f.SaldoInteres) AS TtSdoInteres,"+
                        " sum(f.SaldoCuota) AS TtSdoCuota,"+
                        " sum(f.SaldoIntMora) AS TtSaldoIntMora,"+
                        " f.DiasCpt AS DiasMoraInt,"+
                        " if(((f.DiasCpt >= -(2)) and (f.DiasCpt <= 0)),'L1',if(((f.DiasCpt >= 1) and (f.DiasCpt < 10)),'L2',if(((f.DiasCpt >= 10) and (f.DiasCpt <= 15)),'L3',if(((f.DiasCpt >= 16) and (f.DiasCpt <= 30)),'C1',if(((f.DiasCpt >= 31) and (f.DiasCpt <= 60)),'C2',if(((f.DiasCpt >= 61) and (f.DiasCpt <= 90)),'C3',if(((f.DiasCpt >= 91) and (f.DiasCpt <= 99)),'C4',if(((f.DiasCpt >= 100) and (f.DiasCpt <= 104)),'PJ',if(((f.DiasCpt >= 105) and (f.DiasCpt <= 119)),'J1',if(((f.DiasCpt >= 120) and (f.DiasCpt <= 149)),'J2',if((f.DiasCpt >= 150),'DM','Aldia'))))))))))) AS TipoCartera "+
                        " from 004saldocuotas f"+
                        " where DiasCpt >-61 and f.SaldoCuota>0 and Concepto !='CI'"+
                        " group by f.IdAdjudicacion"+
                        ")F"+
                        " join 004cnsadjudica j"+
                        " on f.IdAdjudicacion= j.IdAdjudicacion"+
                        " where j.tipocartera='Administrativa'and j.estado='Aprobado'"+
                        " order by DiasMoraInt "; 

       // string scrip = "   Select Adj as Adj, Nombre as Nombre,Cto as Cto, Dias as Dias, Gestion as Gestion from 007segcaradm order by Dias";


        string scripcomercial = " Select f.IdAdjudicacion as Adj, j.Identificacion as Nombre,f.Concepto as Cto, f.DiasMoraInt as Dias,f.Tipocartera as Gestion " +
                       "from " +
                       "( " +
                       " select " +
                       " f.IdAdjudicacion AS IdAdjudicacion, " +
                       " f.Concepto AS Concepto, " +
                       " f.NumCuota AS CuotaNum," +
                       " min(f.Fecha) AS Fecha," +
                       " sum(f.Capital) AS TtCapital," +
                       " sum(f.Interes) AS TtInteresCte," +
                       " sum(f.SaldoCuota) AS TtCuotas," +
                       " max(f.UltimaFechaPago) AS UltimoPago," +
                       " sum(f.RcdCapital) AS TtRcdCapital," +
                       " sum(f.RcdInteres) AS TtRcdInteresCte," +
                       " sum(f.RcdCuota) AS TtRcdCuota," +
                       " sum(f.MoraCalc) AS TtMoraCal," +
                       " sum(f.SaldoCapital) AS TtSdoCapital," +
                       " sum(f.SaldoInteres) AS TtSdoInteres," +
                       " sum(f.SaldoCuota) AS TtSdoCuota," +
                       " sum(f.SaldoIntMora) AS TtSaldoIntMora," +
                       " f.DiasCpt AS DiasMoraInt," +
                       " if(((f.DiasCpt >= -(2)) and (f.DiasCpt <= 0)),'L1',if(((f.DiasCpt >= 1) and (f.DiasCpt < 10)),'L2',if(((f.DiasCpt >= 10) and (f.DiasCpt <= 15)),'L3',if(((f.DiasCpt >= 16) and (f.DiasCpt <= 30)),'C1',if(((f.DiasCpt >= 31) and (f.DiasCpt <= 60)),'C2',if(((f.DiasCpt >= 61) and (f.DiasCpt <= 90)),'C3',if(((f.DiasCpt >= 91) and (f.DiasCpt <= 99)),'C4',if(((f.DiasCpt >= 100) and (f.DiasCpt <= 104)),'PJ',if(((f.DiasCpt >= 105) and (f.DiasCpt <= 119)),'J1',if(((f.DiasCpt >= 120) and (f.DiasCpt <= 149)),'J2',if((f.DiasCpt >= 150),'DM','Aldia'))))))))))) AS TipoCartera " +
                       " from 004saldocuotas f" +
                       " where DiasCpt >-61 and f.SaldoCuota>0 and Concepto ='CI'" +
                       " group by f.IdAdjudicacion" +
                       ")F" +
                       " join 004cnsadjudica j" +
                       " on f.IdAdjudicacion= j.IdAdjudicacion" +
                       " where j.tipocartera='Comercial'and j.estado='Aprobado'" +
                       " order by DiasMoraInt ";

        #endregion 

        #region REGION DE EVENTOS


//===================================================================================================================================================
//I N I C I O   D E L   E V E N T O  L O A D  D E L   F O R M U L A R I O
//===================================================================================================================================================
        private void FrmSegCartera_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;
            DtParametros = NuevoClsIdentificacion.MtdBuscarDataset("Select InteresCte,Mora,Periodo,DiasMoras,Porcentaje,Decimales,Fuente,CentroCosto,Subcentro From Parametro Where Estado ='Vigente'");
            string ok = NuevoClsIdentificacion.MtdBscDatos("update financiacion f,004recaudosresumidos r set f.saldocapital=f.capital+r.Capital,f.SaldoInteres=f.interes+r.Interescte," +
                                                    " f.saldocuota=f.cuota+r.cuota where f.idcta=r.id");
            StrInteresCte = DtParametros.Rows[0][0].ToString();
            StrInteresMora = DtParametros.Rows[0][1].ToString();
            StrPeriodo = DtParametros.Rows[0][2].ToString();
            StrDiaMora = DtParametros.Rows[0][3].ToString();
            StrDecimales = DtParametros.Rows[0][5].ToString();
            TxtAdjudicacion.Visible = false;
            LblDatos.Visible = false;
            BtnConsultar.Visible = false;
            if (EntradaSeguimiento == "Administrativa")
            {                
                DgvInicial.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(scrip);              
            }
            else
                if (EntradaSeguimiento == "Comercial")
                {
                    DgvInicial.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(scripcomercial);  
                }
            
            
        }
//===================================================================================================================================================
//F I N A L    D E L   E V E N T O   L O A D  D E L   F O R M U L A R I O
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   D E L   E V E N T O  CmbOpciones_SelectedIndexChanged
//===================================================================================================================================================
         private void CmbOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbOpciones.Text == "Individual")
            {
                TxtAdjudicacion.Visible = true;
                LblDatos.Visible = true;
                BtnConsultar.Visible = true;
            }

            if (CmbOpciones.Text == "Todos")
            {
                TxtAdjudicacion.Visible = false;
                LblDatos.Visible = false;
                BtnConsultar.Visible = false;
                
                DgvInicial.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(scrip);
            }

        }
//===================================================================================================================================================
//F I N A L    D E L   E V E N T O   CmbOpciones_SelectedIndexChanged
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   D E L   E V E N T O  BtnSalir_Click
//===================================================================================================================================================
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
//===================================================================================================================================================
//F I N A L    D E L   E V E N T O   BtnSalir_Click
//===================================================================================================================================================


//===================================================================================================================================================
//I N I C I O   D E L   E V E N T O  TxtAdjudicacion_KeyPress
//===================================================================================================================================================  
        private void TxtAdjudicacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (TxtAdjudicacion.Text != "")
                {
                    Mtdbuscar();
                } 
            }            
        }
//===================================================================================================================================================
//F I N A L    D E L   E V E N T O   TxtAdjudicacion_KeyPress
//===================================================================================================================================================



//===================================================================================================================================================
//I N I C I O   D E L   E V E N T O  BtnConsultar_Click
//===================================================================================================================================================
        private void BtnConsultar_Click(object sender, EventArgs e)
        {
            Mtdbuscar();
        }
//===================================================================================================================================================
//F I N A L    D E L   E V E N T O   BtnConsultar_Click
//===================================================================================================================================================



//===============================================================================================================================
//I N I C I O   D E L   E V E N T O  DgvInicial_CellContentDoubleClick
//===============================================================================================================================        
    private void DgvInicial_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VarIdAdjudicacion = DgvInicial.Rows[e.RowIndex].Cells[0].Value.ToString();
            FrmSeguimiento Seguimiento = new FrmSeguimiento();
            Seguimiento.VarIdadjudicacion = VarIdAdjudicacion;
            Seguimiento.VarIdInmueble = TxtInmueble.Text;
            Seguimiento.VarNombreCliente = TxtCliente.Text;
            Seguimiento.ShowDialog();
        }
//===============================================================================================================================
// F I N A L   D E L   E V E N T O  DgvInicial_CellContentDoubleClick
//===============================================================================================================================        


//===============================================================================================================================
//I N I C I O   D E L   E V E N T O  DgvInicial_CellDoubleClick
//===============================================================================================================================        
        private void DgvInicial_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VarIdAdjudicacion = DgvInicial.Rows[e.RowIndex].Cells[0].Value.ToString();
            FrmSeguimiento Seguimiento = new FrmSeguimiento();
            Seguimiento.VarIdadjudicacion = VarIdAdjudicacion;
            Seguimiento.VarIdInmueble = TxtInmueble.Text;
            Seguimiento.VarNombreCliente = TxtCliente.Text;
            Seguimiento.ShowDialog();
        }
//===============================================================================================================================
//F I N A L   D E L   E V E N T O  DgvInicial_CellDoubleClick
//===============================================================================================================================        


//===============================================================================================================================
//F I N A L   D E L   E V E N T O  DgvInicial_CellEnter
//===============================================================================================================================        
        private void DgvInicial_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            int C = DgvInicial.Rows.Count;
            VarIdAdjudicacion = DgvInicial.Rows[e.RowIndex].Cells[0].Value.ToString();
            DatosNombre = NuevoClsIdentificacion.MtdBscDatos("select idtercero1 from Adjudicacion where idadjudicacion = " + VarIdAdjudicacion );
            
          
            MtdDatosAdj();
            
            MtdCuotaGrilla();
            SentenciaSeguimiento = "Select * from Seguimiento where IdAdjudicacion = '" + VarIdAdjudicacion + "' order by Fecha DESC";
            MtdCuotaSeguimiento();
            SentenciaDatos = "SELECT Direccion,Telefono1,Telefono2,Celular,Ciudad,IdInmueble,Identificacion,Valor FROM 004cnsadjudica where IdAdjudicacion = '" + VarIdAdjudicacion + "'";
            MtdDatos();
            
        }
//===============================================================================================================================
//F I N A L   D E L   E V E N T O  DgvInicial_CellEnter
//===============================================================================================================================        


//===================================================================================================================================================
// I N I C I O   M E T O D O S C R I P
//===================================================================================================================================================
        public string MtdScripExt(string IdAdjudica)
        {
            string Sentencia1 = "";
            Sentencia1 =
            "select  r.Concepto,r.NumCuota,c.Fecha as Vencimiento, C.Cuota as VrCuota, r.Recibo,r.Fecha as FechaPago, r.capital,R.InteresCte,r.Cuota,R.InteresMora " +
            " from (" +
            " Select r.Id, r.Concepto,r.cuotanum as numcuota,r.Recibo,r.Fecha,-(r.capital)capital,-(R.InteresCte) InteresCte ,-(r.cuota)Cuota," +
            " -(R.InteresMora)InteresMora  from 004cnsadjudica A  join 004recaudosdetallados R on " +
            " A.idadjudicacion=r.idadjudicacion where a.idadjudicacion= " + VarIdAdjudicacion +
            " )r" +
            " join Financiacion c on c.idcta=r.id order by c.fecha";
            return Sentencia1;
        }
//===================================================================================================================================================
// F I N   M E T O D O   M E T O D O S C R I P
//===================================================================================================================================================

      




#endregion

        #region REGION DE METODOS

//===================================================================================================================================================
// I N I C I O    M E T O D O    B U S C A R
//===================================================================================================================================================
        public void Mtdbuscar()
        {
            if (CmbOpciones.Text == "Individual")
            {
                string SentenciaInd = "select IdAdjudicacion Adj,Identificacion as Nombre,TipoCartera from 004cnsadjudicaestado where IdAdjudicacion='" +
                   VarIdAdjudicacion+ "'";
                DgvInicial.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaInd);
                TxtAdjudicacion.Visible = true;
                LblDatos.Visible = true;
            }

            if (CmbOpciones.Text == "Todos")
            {
                TxtAdjudicacion.Visible = false;
                LblDatos.Visible = false;
                if (EntradaSeguimiento  == "Administrativa")
                {
                    string Sentencia = NuevoClsIdentificacion.MtdBscDatos("Select scrip from Vistas where vista ='004diasmoramanual'");
                    DgvInicial.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(Sentencia);

                }

                if (EntradaSeguimiento == "Comercial")
                {
                    string Sentencia = NuevoClsIdentificacion.MtdBscDatos("Select scrip from Vistas where vista ='004CarteraCial'");
                    DgvInicial.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(Sentencia);
                }
            }
        }
//===================================================================================================================================================
// F I N A L    M E T O D O     B U S C A R
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O    M E T O D O    D A T O S    A D J U D I C A C I O N 
//===================================================================================================================================================
        public void MtdDatosAdj()
        {
            DataTable DtExtracto = NuevoClsIdentificacion.MtdBuscarDataset(MtdScripExt(VarIdAdjudicacion));

             DgvExtracto.Rows.Clear();

            for (int i = 0; i < (DtExtracto.Rows.Count); i++)
            {
                DgvExtracto.Rows.Add(DtExtracto.Rows[i][0], DtExtracto.Rows[i][1], DtExtracto.Rows[i][2], DtExtracto.Rows[i][3], DtExtracto.Rows[i][4],
                DtExtracto.Rows[i][5], DtExtracto.Rows[i][6], DtExtracto.Rows[i][7], DtExtracto.Rows[i][8], DtExtracto.Rows[i][9]);
            }
            
               
                
                decimal     SumRcdTotal = 0;
               

                for (int i = 0; i < (DgvExtracto.Rows.Count); i++)
                {
                    SumRcdTotal += (Convert.ToDecimal(DgvExtracto.Rows[i].Cells[6].Value));

                    if (i == 0)
                    {
                        DgvExtracto.Rows[i].Cells[10].Value = Convert.ToDecimal(TxtVenta.Text) - Convert.ToDecimal(DgvExtracto.Rows[i].Cells[6].Value);
                    }
                    else
                    {
                        DgvExtracto.Rows[i].Cells[10].Value = Convert.ToDecimal(DgvExtracto.Rows[i - 1].Cells[10].Value) - Convert.ToDecimal(DgvExtracto.Rows[i].Cells[6].Value);
                    }
                }

        }
//===================================================================================================================================================
// F I N A L    M E T O D O    D A T O S    A D J U D I C A C I O N
//===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O   M E T O D O   C U O T A    G R I L L A
//===================================================================================================================================================
        public void MtdCuotaGrilla()
        {
            DtCuotas = NuevoClsIdentificacion.MtdBuscarDataset("Select S.Concepto,S.NumCuota,S.Fecha,S.UltimaFechaPago,S.SaldoCapital,S.SaldoInteres,"+
            " S.SaldoCuota,DiasCpt ,(round((((`s`.`DiasLqd` * `s`.`SaldoCuota`) * if((s.Concepto = 'CI' OR Concepto='GA'),0," + StrInteresMora + ")) / 36000),"
            + StrDecimales + ") + s.SaldoIntMora) AS TotalIntMora from 004saldocuotas s where IdAdjudicacion = " + VarIdAdjudicacion+ " And saldoCuota>0 order by Fecha");

            DgvCuotas.Rows.Clear();

            for (int i = 0; i < (DtCuotas.Rows.Count); i++)
            {
                DgvCuotas.Rows.Add(DtCuotas.Rows[i][0], DtCuotas.Rows[i][1], DtCuotas.Rows[i][2], DtCuotas.Rows[i][3], DtCuotas.Rows[i][4],
                DtCuotas.Rows[i][5], DtCuotas.Rows[i][6], DtCuotas.Rows[i][7], DtCuotas.Rows[i][8]);
            }
            MtdTotal();
        }
//===================================================================================================================================================
// F I N   M E T O D O   C U O T A   G R I L L A
//==================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O  S E G U I M I E N T O   G R I L L A
//==================================================================================================================================================
        public void MtdCuotaSeguimiento()
        {
            DtSeguimiento = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaSeguimiento);
            DgvSeguimiento.AutoGenerateColumns = false;
            DgvSeguimiento.Columns[0].DataPropertyName = "Fecha";
            DgvSeguimiento.Columns[1].DataPropertyName = "Accion";
            DgvSeguimiento.Columns[2].DataPropertyName = "Compromiso";
            DgvSeguimiento.Columns[3].DataPropertyName = "FechaCompromiso";
            DgvSeguimiento.DataSource = DtSeguimiento;
        }
//===================================================================================================================================================
// F I N   M E T O D O  S E G U I M I E N T O  G R I L L A
//===================================================================================================================================================


//===================================================================================================================================================
// I N I C I O   M E T O D O  D A T O S
//===================================================================================================================================================
    public void MtdDatos()
        {

            //PagoMinimo = 0;
            //for (int i = 0; i < (DgvCuotas.Rows.Count); i++)
            //{
            //    PagoMinimo = PagoMinimo + (Convert.ToDouble(DgvCuotas.Rows[i].Cells[6].Value)) + (Convert.ToDouble(DgvCuotas.Rows[i].Cells[9].Value));

            //}
            DtDatos = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaDatos);
            TxtDireccion.Text = DtDatos.Rows[0][0].ToString();
            TxtTelefono1.Text = DtDatos.Rows[0][1].ToString();
            TxtTelefono2.Text = DtDatos.Rows[0][2].ToString();
            TxtCelular.Text = DtDatos.Rows[0][3].ToString();
            TxtCiudad.Text = DtDatos.Rows[0][4].ToString();
            TxtInmueble.Text = DtDatos.Rows[0][5].ToString();
            TxtCliente.Text = DtDatos.Rows[0][6].ToString();
            TxtVenta.Text = DtDatos.Rows[0][7].ToString();
            TxtPagoMinimo.Text = Convert.ToString(PagoMinimo);
            TxtRecaudos.Text = NuevoClsIdentificacion.MtdBscDatos("Select if(sum(capital) is null,0,sum(capital)) from Recaudos where idadjudicacion = '" + VarIdAdjudicacion + "'");
            TxtSaldo.Text = Convert.ToString(Convert.ToDouble(TxtVenta.Text) - Convert.ToDouble(TxtRecaudos.Text));
            this.TxtVenta.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtVenta.Text));
            this.TxtRecaudos.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtRecaudos.Text));
            this.TxtSaldo.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtSaldo.Text));
            this.TxtPagoMinimo.Text = String.Format("{0:#,##0.00;($#,##0.00);0.00}", decimal.Parse(this.TxtPagoMinimo.Text));
            

        }
//===================================================================================================================================================
// F I N   M E T O D O  D A T O S
//===================================================================================================================================================

    //===================================================================================================================================================
    // I N I C I O   M E T O D O  MtdTotal
    //===================================================================================================================================================
    private void MtdTotal()
    {


        decimal SumaCapital = 0; decimal SumaInteres = 0;
         
        for (int i = 0; i < (DgvCuotas.Rows.Count); i++)
        {
            SumaCapital += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[4].Value));
            SumaInteres += (Convert.ToDecimal(DgvCuotas.Rows[i].Cells[5].Value));
        }
        int b = DgvCuotas.Rows.Count - 1;
        DgvCuotas.Rows[b].Cells[2].Value = "T O T A L  . .";
        DgvCuotas.Rows[b].Cells[4].Value = SumaCapital;
        DgvCuotas.Rows[b].Cells[5].Value = SumaInteres;
        DgvCuotas.Rows[b].DefaultCellStyle.BackColor = Color.Lavender;
       


        


    }
        //===================================================================================================================================================
        //F I N A L    M E T O D O   MtdTotal
        //===================================================================================================================================================



        #endregion

    }
}
