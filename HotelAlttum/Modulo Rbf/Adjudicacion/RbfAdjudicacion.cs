using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraGrid;
using MySql.Data.MySqlClient;
namespace CarteraGeneral
{
    public partial class RbfAdjudicacion : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RbfAdjudicacion()
        {
            InitializeComponent();           
        }
        List<string> DatosdeErrores = new List<string>();
        public string EntradaAdjudicacion, VarIdajudicacion;
        ClsVentas ventas = new ClsVentas();
        DataTable table = new DataTable();
        DataTable DtDatos = new DataTable();
        DataTable DtCuotasIni = new DataTable();
        DataTable DtParametro = new DataTable();
        DataTable DtTerceros = new DataTable();
        DataTable DtReservas = new DataTable();
        DataTable DtAsesores = new DataTable();
        DataTable dtasesos = new DataTable();
        DataTable dtcargo = new DataTable();
        ClsIdentificacion conexion = new ClsIdentificacion();
        decimal Vrenganche = 5, CuentaErrores=0;
        int Consecutivo;
        private void RbfAdjudicacion_Load(object sender, EventArgs e)
        {
           
            MtdDatosInicio();
            if(EntradaAdjudicacion=="Aprobar")
            {
                this.Text = "APROBACION ADJUDICACION NUMERO :" +VarIdajudicacion +" PROYECTO " + FrmLogeo.Proyecto.ToUpper();
                
                MtdModificar();
            }
            else
            if (EntradaAdjudicacion == "Consultar")
            {   
                this.Text = "CONSULTAR ADJUDICACION NUMERO :" + VarIdajudicacion + " PROYECTO " + FrmLogeo.Proyecto.ToUpper();
                MtdModificar();                
                BtnOk.Visible = false;
                BtnValidar.Visible = false;              
            }

            if (EntradaAdjudicacion == "Desistir")
            {
                this.Text = "DESISTIR ADJUDICACION NUMERO :" + VarIdajudicacion + " PROYECTO " + FrmLogeo.Proyecto.ToUpper();

                MtdModificar();
            }
        }

     


        void MtdDatosInicio()
        {
            table.Columns.Add("Fecha", typeof(DateTime));
            table.Columns.Add("Concepto", typeof(string));
            table.Columns.Add("NumCuota", typeof(int));
            table.Columns.Add("Capital", typeof(double));
            table.Columns.Add("InteresCte", typeof(double));
            table.Columns.Add("Cuota", typeof(double));

            Capital.DisplayFormat.FormatType = FormatType.Numeric;
            Capital.DisplayFormat.FormatString = "n";

           InteresCte.DisplayFormat.FormatType = FormatType.Numeric;
           InteresCte.DisplayFormat.FormatString = "n";

           Cuota.DisplayFormat.FormatType = FormatType.Numeric;
           Cuota.DisplayFormat.FormatString = "n";

           GridGroupSummaryItem item = new GridGroupSummaryItem();
           item.FieldName = "Concepto";
           item.SummaryType = DevExpress.Data.SummaryItemType.Count;
           GrvCuotas.GroupSummary.Add(item);

           GridGroupSummaryItem item2 = new GridGroupSummaryItem();
           item2.FieldName = "Capital";
           item2.SummaryType = DevExpress.Data.SummaryItemType.Sum;
           item2.DisplayFormat = "Capital {0:n}";
           item2.ShowInGroupColumnFooter = Cuota;
          GrvCuotas.GroupSummary.Add(item2);


          GrvCuotas.Columns["Capital"].Summary.Clear();
          GrvCuotas.Columns["Concepto"].Summary.Clear();
          GrvCuotas.Columns["Capital"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Capital", "Total={0:n2}");

          GrvCuotas.Columns["Concepto"].Summary.Add(DevExpress.Data.SummaryItemType.Count, "Concepto", "Cant={0}");
          //GridColumnSummaryItem item3 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max, "Cuota", "Max={0:n2}");
          //GrvCuotas.Columns["Cuota"].Summary.Add(item3);

            RpsGrado.Items.Add("Diamante");
            RpsGrado.Items.Add("Zafiro");
            RpsGrado.Items.Add("Platino");
            RpsGrado.Items.Add("Oro");
            RpsGrado.Items.Add("Plata");

            ValorFncMfs.Properties.Format.FormatType = FormatType.Numeric;
            ValorFncMfs.Properties.Format.FormatString = "c2";

            CuotaFncMfs.Properties.Format.FormatType = FormatType.Numeric;
            CuotaFncMfs.Properties.Format.FormatString = "c2";




            CuotaFncPh.Properties.Format.FormatType = FormatType.Numeric;
            CuotaFncPh.Properties.Format.FormatString = "c2";

            ValorFncPh.Properties.Format.FormatType = FormatType.Numeric;
            ValorFncPh.Properties.Format.FormatString = "c2";
            
            DtCuotasIni.Columns.Add("Fecha", typeof(DateTime));
            DtCuotasIni.Columns.Add("Valor", typeof(double));
            DtParametro = conexion.MtdBuscarDataset("Select * From parametromonterey");
            GrdFinanciacionMfs.DataSource = conexion.MtdBuscarDataset("select 0.00 ValorFncMfs,          0 TasaFncMfs, 12 PlazoFncMfs, 0.00 CuotaFncMfs,30 PeriodoFncMfs ,curdate() FechaFncMfs from Mora");
            GrdFinanciacionP.DataSource = conexion.MtdBuscarDataset(  "select 0.00 ValorFncPh,            0 TasaFncPh, 12 PlazoFncPh,  0.00 CuotaFncPh, 30 PeriodoFncPh  ,curdate() FechaFncPh  from Mora");

            GrvCuotaInicial.Columns[1].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            GrvCuotaInicial.Columns[1].SummaryItem.DisplayFormat = "{0:n2}";
          

            GrdCuotaInicial.DataSource = DtCuotasIni;
            GrvCuotaInicial.AddNewRow();
            GrvCuotaInicial.FocusedRowHandle = 0;

            DtTerceros = conexion.MtdBuscarDataset("Select idtercero,nombrecompleto from Contabilidad_alttum.terceros", FrmLogeo.StrConexion);
            DtReservas = conexion.MtdBuscarDataset("Select IdReserva, IdInmueble,TipoReserva,Contrato,Temporada,IdTercero1 From Reservas Where Estado='Pendiente'");
           
            RpsTitular1.DataSource = DtTerceros.DefaultView;
            RpsTitular2.DataSource = DtTerceros.DefaultView;
            RpsTitular3.DataSource = DtTerceros.DefaultView;
            RpsReservas.DataSource = DtReservas;

            RpsTitular1.DisplayMember = DtTerceros.DataSet.Tables[0].Columns[1].ToString();
            RpsTitular1.ValueMember = DtTerceros.DataSet.Tables[0].Columns[0].ToString();

            RpsTitular2.DisplayMember = DtTerceros.DataSet.Tables[0].Columns[1].ToString();
            RpsTitular2.ValueMember = DtTerceros.DataSet.Tables[0].Columns[0].ToString();

            RpsTitular3.DisplayMember = DtTerceros.DataSet.Tables[0].Columns[1].ToString();
            RpsTitular3.ValueMember = DtTerceros.DataSet.Tables[0].Columns[0].ToString();

            RpsReservas.DisplayMember =DtReservas.DataSet.Tables[0].Columns[0].ToString();
            RpsReservas.ValueMember = DtReservas.DataSet.Tables[0].Columns[0].ToString();         


            dtcargo = conexion.MtdBuscarDataset("Select IdCargo,NombreCargo From tablacomisiones where Comision2=0");
            dtasesos = conexion.MtdBuscarDataset("Select IdTercero,NombreCompleto From Contabilidad_alttum.Terceros Where TipoTercero='Gestor'");          
 
        
        }

        private void GrvCuotaInicial_HiddenEditor(object sender, EventArgs e)
        {
            string strDato1, strDato2;

            if (GrvCuotaInicial.FocusedRowHandle == GrvCuotaInicial.RowCount - 1)
            {
                GrvCuotaInicial.CloseEditor();
                
                strDato1 = GrvCuotaInicial.GetRowCellValue(GrvCuotaInicial.FocusedRowHandle, GrvCuotaInicial.Columns[0]).ToString();
                strDato2 = GrvCuotaInicial.GetRowCellValue(GrvCuotaInicial.FocusedRowHandle, GrvCuotaInicial.Columns[1]).ToString();

                if (strDato1 != "" && strDato2 != "")
                {
                    GrvCuotaInicial.AddNewRow();
                }
            }
            TxtCuotaInicial.EditValue = GrvCuotaInicial.Columns[1].SummaryItem.SummaryValue;
        }
        private void GrvCuotaInicial_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GrvCuotaInicial.CloseEditor();
            TxtCuotaInicial.EditValue = GrvCuotaInicial.Columns[1].SummaryItem.SummaryValue;
            MtdDiferencia();
        }
       private void MtdReservas(int IdReserva)
        {
                    
            var query = (
            from DtReservas1 in DtReservas.AsEnumerable()
            where DtReservas1.Field<int>("IdReserva") == IdReserva
            select new

            {
                tiporeserva = DtReservas1.Field<string>("TipoReserva"),
                inmueble = DtReservas1.Field<string>("IdInmueble"),
                contrato = DtReservas1.Field<string>("Contrato"),
                temporada = DtReservas1.Field<string>("Temporada"),
                titular = DtReservas1.Field<string>("IdTercero1")
            });

            foreach (var order in query)
            {
                TxtTipoSemana.EditValue = order.tiporeserva;
                TxtInmueble.EditValue = order.inmueble;
                TxtContrato.EditValue = order.contrato;
                TxtTemporada.EditValue = order.temporada;
               CmbTitular1.EditValue = order.titular;
            }

             
        }


        private void MtdDiferencia()
        {

            TxtDiferencia.EditValue= (Convert.ToDecimal(TxtValorContrato.EditValue.ToString())-
                Convert.ToDecimal( TxtCuotaInicial.EditValue.ToString())-
               Convert.ToDecimal(TxtFinanciacionMFS.EditValue.ToString())-
              Convert.ToDecimal( TxtFinanciacionPH.EditValue.ToString()));
        }

       private void MtdValidarAdd()
       {
           DatosdeErrores.Clear();
           CuentaErrores = 0;
           if (Convert.ToDecimal( TxtDiferencia.EditValue.ToString()) != 0)
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Documento Descuadrado");
           }
           if (TxtValorContrato.EditValue.ToString()=="0")
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Ingresar Valor Contrato");
           }

           if (TxtInmueble.EditValue==null)
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Seleccionar Inmueble");
           }

           if (CmbGrado.EditValue == null)
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Grado");
           }
           if (TxtTrm.EditValue.ToString() == "0")
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Adicionar Trm");
           }
           if(DtpFechaElaboracion.EditValue==null)
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Fecha Elaboracion");
           }

           if (DtpFechaContrato.EditValue == null)
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Fecha Contrato");
           }

           //if (DtpFechaEntrega.EditValue == null)
           //{
           //    CuentaErrores = CuentaErrores + 1;
           //    DatosdeErrores.Add("Falta Fecha Entrega");
           //}

           if (TxtCuotaInicial.EditValue.ToString()=="0")
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Cuota Inicial");
           }

           if (TxtGastosLegal.EditValue.ToString() == "0")
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Gasto Legal");
           }

           if ( Convert.ToDecimal((TxtBaseComision.EditValue.ToString())) == 0)
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Base Comision");
           }

           if (TxtFinanciacionMFS.EditValue.ToString()=="0")
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Financiacion Monterey");
           }
           if (TxtFinanciacionPH.EditValue.ToString() == "0")
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Falta Financiacion Poblado");
           }
           decimal cuuotaInic, enganche;
           cuuotaInic = Convert.ToDecimal(TxtCuotaInicial.EditValue.ToString());
           enganche = Vrenganche * Convert.ToDecimal(TxtValorContrato.EditValue.ToString()) / 100;

           if (cuuotaInic < enganche)
           {
               CuentaErrores = CuentaErrores + 1;
               DatosdeErrores.Add("Cuota Inicial No puede ser Menor "+enganche+ " Por Ciento" );

           }
         
          
       }

       private void MtdAdicionar()
       {
           string VarIdCta, VarConcepto;
           decimal VarCapital, VarInteres, VarCuota;
           int VarNumcuota, Consecutivo;
           DateTime VarFecha;
           MtdValidarAdd();
           if (CuentaErrores > 0)
           {
               FrmMensajeError frmMensajeError = new FrmMensajeError();
               frmMensajeError.LblErrores.DataSource = DatosdeErrores;
               frmMensajeError.ShowDialog();
           }
           else
           {
               DialogResult rest;
               rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

               if (rest == DialogResult.Yes)
               {
                   Consecutivo = Convert.ToInt16(conexion.MtdBscDatos("select if(max(IdAdjudicacion)is null,1,max(IdAdjudicacion+1))from Adjudicacion"));

                   MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);




                   string StrAddAdjudicacion = " INSERT INTO adjudicacion ( IdAdjudicacion, Fecha, Contrato, IdProyecto, IdInmueble, TipodeAdjudicacion, Temporada, Grado, IdTercero1," +
                   "IdTercero2, Idtercero3, FormaPago, Valor, GastosLegales, CuotaInicial, contado, Financiacion, PlazoFnc, TasaFnc, CuotaFnc, InicioFnc, Extraordinaria, PlazoExtra, TasaExtra, CuotaExtra," +
                   "InicioExtra, Estado, Usuario, FechaOperacion, Porcentaje, BaseComision,Observacion,FechaContrato,TipoOperacion,Trm,FinanciacionMfs,CuotaMfs)" +
                    " VALUES ( @IdAdjudicacion, @Fecha, @Contrato, @IdProyecto, @IdInmueble, @TipodeAdjudicacion, @Temporada, @Grado, @IdTercero1, @IdTercero2, @Idtercero3, @FormaPago," +
                    " @Valor, @GastosLegales, @CuotaInicial, @contado, @Financiacion, @PlazoFnc, @TasaFnc, @CuotaFnc, @InicioFnc, @Extraordinaria, @PlazoExtra, @TasaExtra, @CuotaExtra," +
                   "@InicioExtra, @Estado, @Usuario, @FechaOperacion, @Porcentaje, @BaseComision,@Observacion,@FechaContrato,@TipoOperacion,@Trm,@FinanciacionMfs,@CuotaMfs)";


                   string StrAddFnc = "insert into financiacion (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,UltimaFechaPago,Usuario,FechaOperacion) " +
                           "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital,@Interes,@Cuota,@Capital,@Interes,@Cuota,@FechaFnc,@Usuario,@FechaOperacion)";

                   string StrGastosLegal = "insert into financiacion (IdCta,IdAdjudicacion,Concepto,NumCuota,Fecha,Capital,Interes,Cuota,SaldoCapital,SaldoInteres,SaldoCuota,UltimaFechaPago,Usuario,FechaOperacion) " +
                         "Values (@IdCta,@IdAdjudicacion,@Concepto,@NumCuota,@FechaFnc,@Capital,@Interes,@Cuota,@Capital,@Interes,@Cuota,@FechaFnc,@Usuario,@FechaOperacion)";

                   string StrModReserva = "Update Reservas Set Estado = 'Adjudicado',IdAdjudicacion =@IdAdjudicacion Where idReserva ='" + CmbReserva.EditValue + "'";

                   string StrModInmuebles = "Update Inmuebles Set Estado = 'Adjudicado' Where IdInmueble ='" +TxtInmueble.EditValue.ToString() +"'";

                   MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                   MysqlConexion.Open();
                   MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                   MySqlTransaction myTrans;
                   myTrans = MysqlConexion.BeginTransaction();
                   CmdAddPrm.Connection = MysqlConexion;
                   CmdAddPrm.Transaction = myTrans;
                   try
                   {
                       CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                       CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.Date);
                       CmdAddPrm.Parameters.Add("@FechaContrato", MySql.Data.MySqlClient.MySqlDbType.Date);
                       CmdAddPrm.Parameters.Add("@Contrato", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@IdProyecto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@TipodeAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@Temporada", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@Grado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@IdTercero1", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@IdTercero2", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@IdTercero3", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@FormaPago", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@Valor", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@GastosLegales", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@CuotaInicial", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@Contado", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@Financiacion", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@FinanciacionMfs", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@PlazoFnc", MySql.Data.MySqlClient.MySqlDbType.Int16);
                       CmdAddPrm.Parameters.Add("@TasaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@CuotaFnc", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@InicioFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                       CmdAddPrm.Parameters.Add("@Extraordinaria", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@PlazoExtra", MySql.Data.MySqlClient.MySqlDbType.Int16);
                       CmdAddPrm.Parameters.Add("@TasaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@CuotaExtra", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@InicioExtra", MySql.Data.MySqlClient.MySqlDbType.Date);
                       CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                       CmdAddPrm.Parameters.Add("@Porcentaje", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@BaseComision", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@Observacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@IdCta", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@Concepto", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@FechaFnc", MySql.Data.MySqlClient.MySqlDbType.Date);
                       CmdAddPrm.Parameters.Add("@Capital", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@CuotaMfs", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@Interes", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@Cuota", MySql.Data.MySqlClient.MySqlDbType.Decimal);
                       CmdAddPrm.Parameters.Add("@NumCuota", MySql.Data.MySqlClient.MySqlDbType.Int16);
                       CmdAddPrm.Parameters.Add("@TipoOperacion", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                       CmdAddPrm.Parameters.Add("@Trm", MySql.Data.MySqlClient.MySqlDbType.Decimal);

                       CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                       CmdAddPrm.Parameters["@Fecha"].Value =Convert.ToDateTime( DtpFechaElaboracion.EditValue);
                       CmdAddPrm.Parameters["@FechaContrato"].Value = Convert.ToDateTime(DtpFechaContrato.EditValue);
                       CmdAddPrm.Parameters["@Contrato"].Value =TxtContrato.EditValue.ToString();
                       CmdAddPrm.Parameters["@IdProyecto"].Value = FrmLogeo.Proyecto;
                       CmdAddPrm.Parameters["@IdInmueble"].Value = TxtInmueble.EditValue.ToString();
                       CmdAddPrm.Parameters["@TipodeAdjudicacion"].Value = TxtTipoSemana.EditValue.ToString(); ;
                       CmdAddPrm.Parameters["@Temporada"].Value = TxtTemporada.EditValue.ToString();
                       CmdAddPrm.Parameters["@Grado"].Value = CmbGrado.EditValue.ToString(); ;
                       CmdAddPrm.Parameters["@IdTercero1"].Value = CmbTitular1.EditValue;      
                       CmdAddPrm.Parameters["@IdTercero2"].Value =CmbTitular2.EditValue;
                       CmdAddPrm.Parameters["@IdTercero3"].Value = CmbTitular3.EditValue;
                      

                       CmdAddPrm.Parameters["@FormaPago"].Value = "Credito";
                       CmdAddPrm.Parameters["@Valor"].Value = Convert.ToDecimal(TxtValorContrato.EditValue.ToString());
                       CmdAddPrm.Parameters["@GastosLegales"].Value = Convert.ToDecimal(TxtGastosLegal.EditValue.ToString());
                       CmdAddPrm.Parameters["@CuotaInicial"].Value = Convert.ToDecimal(TxtCuotaInicial.EditValue.ToString());
                       CmdAddPrm.Parameters["@Contado"].Value = 0;
                       CmdAddPrm.Parameters["@FinanciacionMfs"].Value = Convert.ToDecimal(TxtFinanciacionMFS.EditValue.ToString());
                       CmdAddPrm.Parameters["@Financiacion"].Value = Convert.ToDecimal(TxtFinanciacionPH.EditValue.ToString());
                       CmdAddPrm.Parameters["@PlazoFnc"].Value = Convert.ToInt16(PlazoFncPh.Properties.Value);
                       CmdAddPrm.Parameters["@TasaFnc"].Value = Convert.ToDecimal(TasaFncPh.Properties.Value);
                       CmdAddPrm.Parameters["@CuotaFnc"].Value = Convert.ToDecimal(CuotaFncPh.Properties.Value);
                       CmdAddPrm.Parameters["@InicioFnc"].Value =Convert.ToDateTime( FechaFncPh.Properties.Value);
                       CmdAddPrm.Parameters["@Extraordinaria"].Value = 0;
                       CmdAddPrm.Parameters["@PlazoExtra"].Value =0 ;
                       CmdAddPrm.Parameters["@TasaExtra"].Value = 0;
                       CmdAddPrm.Parameters["@CuotaExtra"].Value = 0;
                       CmdAddPrm.Parameters["@InicioExtra"].Value =null;
                       CmdAddPrm.Parameters["@Estado"].Value = "Pendiente";
                       CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                       CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                       CmdAddPrm.Parameters["@Porcentaje"].Value =30;
                       CmdAddPrm.Parameters["@BaseComision"].Value = Convert.ToDecimal(TxtBaseComision.EditValue.ToString());
                       CmdAddPrm.Parameters["@Observacion"].Value = "";
                       CmdAddPrm.Parameters["@TipoOperacion"].Value = "Monterey";
                       CmdAddPrm.Parameters["@Trm"].Value = Convert.ToDecimal( TxtTrm.EditValue.ToString());
                       CmdAddPrm.Parameters["@CuotaMfs"].Value = Convert.ToDecimal(CuotaFncMfs.Properties.Value);

                       
                       CmdAddPrm.CommandText = StrAddAdjudicacion;
                       CmdAddPrm.ExecuteNonQuery();

                       if (Convert.ToDecimal(TxtGastosLegal.EditValue.ToString()) > 0)
                       {
                           CmdAddPrm.Parameters["@IdCta"].Value = "GA1ADJ" + Consecutivo;
                           CmdAddPrm.Parameters["@Concepto"].Value = "GA";
                           CmdAddPrm.Parameters["@FechaFnc"].Value = Convert.ToDateTime( DtpFechaContrato.EditValue);
                           CmdAddPrm.Parameters["@Capital"].Value = Convert.ToDecimal(TxtGastosLegal.EditValue.ToString());
                           CmdAddPrm.Parameters["@Interes"].Value = 0;
                           CmdAddPrm.Parameters["@Cuota"].Value = Convert.ToDecimal(TxtGastosLegal.EditValue.ToString());
                           CmdAddPrm.Parameters["@NumCuota"].Value = 1;

                           CmdAddPrm.CommandText = StrGastosLegal;
                           CmdAddPrm.ExecuteNonQuery();
                       }

                       for (int i = 0; i <table.Rows.Count ; i++)
                       {

                           VarConcepto = table.Rows[i][1].ToString();
                           VarNumcuota = Convert.ToInt16(table.Rows[i][2].ToString());
                           VarIdCta = VarConcepto + VarNumcuota + "ADJ" + Consecutivo;
                           VarFecha = Convert.ToDateTime(table.Rows[i][0].ToString());
                           VarCapital = Convert.ToDecimal(table.Rows[i][3].ToString());
                           VarInteres = Convert.ToDecimal(table.Rows[i][4].ToString());
                           VarCuota = Convert.ToDecimal(table.Rows[i][5].ToString());

                           CmdAddPrm.Parameters["@IdCta"].Value = VarIdCta;
                           CmdAddPrm.Parameters["@Concepto"].Value = VarConcepto;
                           CmdAddPrm.Parameters["@FechaFnc"].Value = VarFecha;
                           CmdAddPrm.Parameters["@Capital"].Value = VarCapital;
                           CmdAddPrm.Parameters["@Interes"].Value = VarInteres;
                           CmdAddPrm.Parameters["@Cuota"].Value = VarCuota;
                           CmdAddPrm.Parameters["@NumCuota"].Value = VarNumcuota;

                           CmdAddPrm.CommandText = StrAddFnc;
                           CmdAddPrm.ExecuteNonQuery();

                           CmdAddPrm.CommandText = StrModReserva;
                           CmdAddPrm.ExecuteNonQuery();

                           CmdAddPrm.CommandText = StrModInmuebles;
                           CmdAddPrm.ExecuteNonQuery();
                       }
                       myTrans.Commit();
                       MessageBox.Show("Registro Adicionado", "Adicionar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                       BtnOk.Enabled = false;
                       BtnValidar.Enabled = false;
                       //LblAdjudicacion.Text = Consecutivo.ToString();
                   }
                   catch (MySqlException ex)
                   {
                       myTrans.Rollback();
                       MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Adicionar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                   }
                   finally
                   {
                       MysqlConexion.Close();

                   }
               }
           }
       }
       private void CmbReserva_EditValueChanged(object sender, EventArgs e)
       {
           if (CmbReserva.EditValue != null)
           {
               MtdReservas(Convert.ToInt32(CmbReserva.EditValue.ToString()));
           }
       }

       private void skinRibbonGalleryBarItem1_GalleryPopupClose(object sender, DevExpress.XtraBars.Ribbon.InplaceGalleryEventArgs e)
       {
           {
               conexion.MtdAddSentencia("update usuario set tema= '" + UserLookAndFeel.Default.SkinName.ToString() + "' where idusuario = '" + FrmLogeo.Usuario + "'");
           }
       }

       private void GrdFinanciacionMfs_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
       {
          
           TxtFinanciacionMFS.EditValue = ValorFncMfs.Properties.Value;
          CuotaFncMfs.Properties.Value= conexion.MtdCalculoCuota(Convert.ToDouble(ValorFncMfs.Properties.Value),Convert.ToDouble(TasaFncMfs.Properties.Value),Convert.ToDouble(PeriodoFncMfs.Properties.Value),Convert.ToDouble( PlazoFncMfs.Properties.Value),2
              ); MtdDiferencia();
       }

       private void GrdFinanciacionP_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
       {
           TxtFinanciacionPH.EditValue = ValorFncPh.Properties.Value;
           CuotaFncPh.Properties.Value = conexion.MtdCalculoCuota(Convert.ToDouble(ValorFncPh.Properties.Value), Convert.ToDouble(TasaFncPh.Properties.Value), Convert.ToDouble(PeriodoFncPh.Properties.Value), Convert.ToDouble(PlazoFncPh.Properties.Value), 2    );
           MtdDiferencia();
       }

       private void TxtValorContrato_EditValueChanged(object sender, EventArgs e)
       {
          
       }

       private void simpleButton1_Click(object sender, EventArgs e)
       {
           MtdDiferencia();
           table.Clear();
           MtdValidarAdd();
          if (CuentaErrores > 0)
           {
               FrmMensajeError error = new FrmMensajeError();
               error.LblErrores.DataSource = DatosdeErrores;
               error.Show();
           }
          else
          {
              BtnImprimir.Visible = true;
              BtnOk.Visible = true;
              BtnSalir.Visible = true;
              
             
              DataTable DtMonterey = new DataTable();
              DataTable DtPoblado = new DataTable();
              DtMonterey = conexion.MtdCuotas(Convert.ToDouble(ValorFncMfs.Properties.Value), Convert.ToDouble(TasaFncMfs.Properties.Value), Convert.ToInt32(PeriodoFncMfs.Properties.Value), Convert.ToDouble(PlazoFncMfs.Properties.Value), 2,Convert.ToDateTime( FechaFncMfs.Properties.Value));
              DtPoblado = conexion.MtdCuotas(Convert.ToDouble(ValorFncPh.Properties.Value), Convert.ToDouble(TasaFncPh.Properties.Value), Convert.ToInt32(PeriodoFncPh.Properties.Value), Convert.ToDouble(PlazoFncPh.Properties.Value), 2, Convert.ToDateTime(FechaFncPh.Properties.Value));

              for (int i = 0; i < (DtCuotasIni.Rows.Count)-1; i++)
              {
                  table.Rows.Add(DtCuotasIni.Rows[i][0], "CI", i + 1, DtCuotasIni.Rows[i][1], 0, DtCuotasIni.Rows[i][1]);
              }
              
              for (int i = 0; i < (DtMonterey.Rows.Count); i++)
              {
                  table.Rows.Add(DtMonterey.Rows[i][0], "CM", DtMonterey.Rows[i][1], DtMonterey.Rows[i][2], DtMonterey.Rows[i][3], DtMonterey.Rows[i][4]);
              }

              for (int i = 0; i < (DtPoblado.Rows.Count); i++)
              {
                  table.Rows.Add(DtPoblado.Rows[i][0], "FN", DtPoblado.Rows[i][1], DtPoblado.Rows[i][2], DtPoblado.Rows[i][3], DtPoblado.Rows[i][4]);
              }
              GrdCuotas.DataSource = table;

          }
       }

       private void BtnOk_Click(object sender, EventArgs e)
       {
           if (EntradaAdjudicacion == "Adicionar")
           {
               MtdAdicionar();
           }
           else
               if (EntradaAdjudicacion == "Aprobar")
               {
                   MtdAprobar();
               }

           if (EntradaAdjudicacion == "Desistir")
           {
               MtdDesistir();
           }

       }

       private void BtnSalir_Click(object sender, EventArgs e)
       {
           Close();
       }

       private void GrvCuotaInicial_KeyUp(object sender, KeyEventArgs e)
       {
           if (e.KeyCode == Keys.Delete)
           {
               if (GrvCuotaInicial.GetRowCellValue(GrvCuotaInicial.FocusedRowHandle, GrvCuotaInicial.Columns[0]).ToString() != "")
               {
                   GrvCuotaInicial.DeleteRow(GrvCuotaInicial.FocusedRowHandle);
                  
               }
               
           }
           if (e.KeyCode == Keys.Enter)
           {
                string strDato1, strDato2;

            if (GrvCuotaInicial.FocusedRowHandle == GrvCuotaInicial.RowCount - 1)
            {
                GrvCuotaInicial.CloseEditor();
                strDato1 = GrvCuotaInicial.GetRowCellValue(GrvCuotaInicial.FocusedRowHandle, GrvCuotaInicial.Columns[0]).ToString();
                strDato2 = GrvCuotaInicial.GetRowCellValue(GrvCuotaInicial.FocusedRowHandle, GrvCuotaInicial.Columns[1]).ToString();

                if (strDato1 != "" && strDato2 != "")
                {
                    GrvCuotaInicial.AddNewRow();
                }
            }
            
           }
           TxtCuotaInicial.EditValue = GrvCuotaInicial.Columns[1].SummaryItem.SummaryValue;
           MtdDiferencia();
       }

       private void DtpFechaContrato_EditValueChanged(object sender, EventArgs e)
       {
           TxtTrm.EditValue = conexion.MtdBscDatos("Select if(sum(Valor) is null,1,Valor) From Trm Where Fecha=@Fecha", Convert.ToDateTime(DtpFechaContrato.EditValue.ToString()));
       }

       private void TxtValorContrato_HiddenEditor(object sender, ItemClickEventArgs e)
       {

       }

       private void TxtValorContrato_EditValueChanged_1(object sender, EventArgs e)
       {
           MtdDiferencia();
       }

       private void ribbon_Click(object sender, EventArgs e)
       {

       }


       private void MtdAprobar()
       {
           
               DialogResult rest;
               rest = MessageBox.Show("Esta seguro de Aprobar Este Registro", "Aprobar Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

               if (rest == DialogResult.Yes)
               {


                   string StrAprobar = "Update Adjudicacion set Estado='Aprobado' Where IdAdjudicacion=@IdAdjudicacion";
                   string Documentacion = "Insert into documentacion(Fecha,Operacion,IdAdjudicacion,UsuarioEnvio,Estado)Values(@Fecha,@Operacion,@IdAdjudicacion,@UsuarioEnvio,@Estado)";
                   MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);
                   MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
                   MysqlConexion.Open();
                   MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
                   MySqlTransaction myTrans;
                   myTrans = MysqlConexion.BeginTransaction();
                   CmdAddPrm.Connection = MysqlConexion;
                   CmdAddPrm.Transaction = myTrans;
                   try
                   {
                       CmdAddPrm.Parameters.Add("@Fecha", MySql.Data.MySqlClient.MySqlDbType.DateTime).Value = DateTime.Now;
                       CmdAddPrm.Parameters.Add("@Operacion", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = "Aprobacion";
                       CmdAddPrm.Parameters.Add("@UsuarioEnvio", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = FrmLogeo.Usuario;
                       CmdAddPrm.Parameters.Add("@Estado", MySql.Data.MySqlClient.MySqlDbType.VarChar).Value = "Aceptado";
                       CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16).Value=VarIdajudicacion;

                       CmdAddPrm.CommandText = StrAprobar;
                       CmdAddPrm.ExecuteNonQuery();

                       CmdAddPrm.CommandText = Documentacion;
                       CmdAddPrm.ExecuteNonQuery();

                       myTrans.Commit();
                       MessageBox.Show("Registro Aprobado", "Aprobar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                       BtnOk.Enabled = false;
                       BtnValidar.Enabled = false;
                       //LblAdjudicacion.Text = Consecutivo.ToString();
                   }
                   catch (MySqlException ex)
                   {
                       myTrans.Rollback();
                       MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Aprobar Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                   }
                   finally
                   {
                       MysqlConexion.Close();

                   }
               }
           
       }

       private void MtdDesistir()
       {

           DialogResult rest;
           rest = MessageBox.Show("Esta seguro de Desistir Este Registro", "Desistir Adjudicacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

           if (rest == DialogResult.Yes)
           {
               Consecutivo = Convert.ToInt16(VarIdajudicacion);

               MySqlConnection MysqlConexion = new MySqlConnection(FrmLogeo.StrConexion);


               string ModAdjudicacion = "insert into modadjudicacion (Select * from Adjudicacion where idadjudicacion=@IdAdjudicacion)";
               string StrModAdjudicacion = "Update Adjudicacion Set Estado='Desistido',Usuario=@Usuario,FechaOperacion=@FechaOperacion Where IdAdjudicacion=@IdAdjudicacion ";
               string StrModInmuebles = "Update inmuebles Set Estado='Libre',Usuario=@Usuario,FechaOperacion=@FechaOperacion Where IdInmueble=@IdInmueble ";


               MysqlConexion.ConnectionString = FrmLogeo.StrConexion;
               MysqlConexion.Open();
               MySqlCommand CmdAddPrm = MysqlConexion.CreateCommand();
               MySqlTransaction myTrans;
               myTrans = MysqlConexion.BeginTransaction();
               CmdAddPrm.Connection = MysqlConexion;
               CmdAddPrm.Transaction = myTrans;
               try
               {
                   CmdAddPrm.Parameters.Add("@IdAdjudicacion", MySql.Data.MySqlClient.MySqlDbType.Int16);
                   CmdAddPrm.Parameters.Add("@Usuario", MySql.Data.MySqlClient.MySqlDbType.VarChar);
                   CmdAddPrm.Parameters.Add("@FechaOperacion", MySql.Data.MySqlClient.MySqlDbType.Date);
                   CmdAddPrm.Parameters.Add("@IdInmueble", MySql.Data.MySqlClient.MySqlDbType.VarChar);

                   CmdAddPrm.Parameters["@IdAdjudicacion"].Value = Consecutivo;
                   CmdAddPrm.Parameters["@Usuario"].Value = FrmLogeo.Usuario;
                   CmdAddPrm.Parameters["@FechaOperacion"].Value = DateTime.Now.Date;
                   CmdAddPrm.Parameters["@IdInmueble"].Value = TxtInmueble.EditValue;

                   CmdAddPrm.CommandText = ModAdjudicacion;
                   CmdAddPrm.ExecuteNonQuery();
                   CmdAddPrm.CommandText = StrModAdjudicacion;
                   CmdAddPrm.ExecuteNonQuery();
                   CmdAddPrm.CommandText = StrModInmuebles;
                   CmdAddPrm.ExecuteNonQuery();




                   myTrans.Commit();
                   MessageBox.Show("Registro Desistido", "Desistir Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                   BtnOk.Enabled = false;
                   BtnValidar.Enabled = false;
                   //    LblAdjudicacion.Text = Consecutivo.ToString();
               }
               catch (MySqlException ex)
               {
                   myTrans.Rollback();
                   MessageBox.Show("Ha Ocurrido el Sgte Error: " + ex.Message + "", "" + "Desistir Adjudicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

               }
               finally
               {
                   MysqlConexion.Close();

               }
           }
       }
       
        void MtdModificar()
       {
          
           GrdCuotas.DataSource = conexion.MtdBuscarDataset(RscAdjudicacion.CnsDatosFinanciacionxAdj, VarIdajudicacion);
           GrdFinanciacionMfs.DataSource = conexion.MtdBuscarDataset(RscAdjudicacion.CnsDatosFncMontereyxAdj, VarIdajudicacion);
           GrdFinanciacionP.DataSource = conexion.MtdBuscarDataset(RscAdjudicacion.CnsDatosFncPobladoxAdj, VarIdajudicacion);
           GrdCuotaInicial.DataSource = conexion.MtdBuscarDataset(RscAdjudicacion.CnsDatosCuotaInicialxAdj,VarIdajudicacion);
           GrvCuotaInicial.AddNewRow();
           DtDatos = conexion.MtdBuscarDataset(RscAdjudicacion.CnsDatosAdjudicacionxAdj, VarIdajudicacion);
           CmbGrado.EditValue = DtDatos.Rows[0]["Grado"].ToString();
           CmbTitular1.EditValue = DtDatos.Rows[0]["IdTercero1"].ToString();
           CmbTitular2.EditValue = DtDatos.Rows[0]["IdTercero2"].ToString();
           CmbTitular3.EditValue = DtDatos.Rows[0]["IdTercero3"].ToString();
           TxtTipoSemana.EditValue  = DtDatos.Rows[0]["TipoSemana"].ToString();
           TxtInmueble.EditValue = DtDatos.Rows[0]["IdInmueble"].ToString();
           TxtTemporada.EditValue = DtDatos.Rows[0]["Temporada"].ToString();
           TxtContrato.EditValue = DtDatos.Rows[0]["Contrato"].ToString();
           TxtTrm.EditValue = DtDatos.Rows[0]["Trm"].ToString();
           TxtBaseComision.EditValue = DtDatos.Rows[0]["BaseComision"].ToString();
           TxtValorContrato.EditValue = DtDatos.Rows[0]["ValorContrato"].ToString();
           TxtGastosLegal.EditValue = DtDatos.Rows[0]["GastosLegales"].ToString();
           TxtCuotaInicial.EditValue = DtDatos.Rows[0]["CuotaInicial"].ToString();
           TxtFinanciacionMFS.EditValue = DtDatos.Rows[0]["FinanciacionMfs"].ToString();
           TxtFinanciacionPH.EditValue = DtDatos.Rows[0]["Financiacion"].ToString();
           DtpFechaContrato.EditValue = DtDatos.Rows[0]["FechaContrato"].ToString();
           DtpFechaElaboracion.EditValue = DtDatos.Rows[0]["FechaElaboracion"].ToString();
           CmbReserva.EditValue = DtDatos.Rows[0]["IdReserva"].ToString();
           CmbReserva.Edit.ReadOnly = true;
           DtpFechaContrato.Edit.ReadOnly = true;
           DtpFechaElaboracion.Edit.ReadOnly = true;
           TxtValorContrato.Edit.ReadOnly = true;
           MtdDiferencia();
           BtnValidar.Visible = false;
           BtnOk.Visible = true;
           BtnOk.Text = "Aprobar";

           if (EntradaAdjudicacion == "Desistir")
           {
               BtnOk.Text = "Desistir";
           }

             

            if(EntradaAdjudicacion=="Aprobar")
            {
                GrdAsesores.Visible = true;
                GrvCuotaInicial.OptionsBehavior.Editable = false;
                GrdFinanciacionMfs.OptionsBehavior.Editable = false;
                GrdFinanciacionMfs.OptionsBehavior.Editable = false;
                GrdAsesores.DataSource = conexion.MtdBuscarDataset(MisConsultas.CnsDatosComisionxAdj, VarIdajudicacion);
            }




       }
       

       
      

      
      
    }
}