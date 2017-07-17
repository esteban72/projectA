using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using MySql.Data.MySqlClient;

namespace CarteraGeneral
{
    public partial class FrmPagoComisionesMonterey : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region    REGION DE VARIABLES
        public FrmPagoComisionesMonterey()
        {
            InitializeComponent();
           

        }
        DataTable DtPago = new DataTable();      
        decimal ValorPago = 0;
        public string EntradaComision;
        ClsIdentificacion conexion = new ClsIdentificacion();
        ClsComisionesMonterey comisiones = new ClsComisionesMonterey();
        string VarCentroCostos = string.Empty, CuentaDebe = string.Empty, CuentaHaber = string.Empty,
        CuentaAnticipo = string.Empty, CuentaFondo = string.Empty, idtransacciones = string.Empty,
        VarFuente = string.Empty, IdDocumento = string.Empty, Motivo = string.Empty, VarPeriodo = string.Empty,
        FechaAsiento = string.Empty;

        #endregion


        #region REGION DE EVENTOS 
        private void FrmPagoComisionesMonterey_Load(object sender, EventArgs e)
        {           
            MtdDatos();
            DtpFechaPago.EditValue = DateTime.Now.Date.ToShortDateString();            
        }     

        private void CmbAdjudicacion_EditValueChanged(object sender, EventArgs e)
        {
            ValorPago = 0;
            comisiones.IdAdjudicacion = Convert.ToInt32(CmbAdjudicacion.EditValue.ToString());
            TxtTrm.EditValue = conexion.MtdBscDatos("Select trm From Adjudicacion Where IdAdjudicacion=@IdAdjudicacion", CmbAdjudicacion.EditValue.ToString());
            GrdComisiones.DataSource = comisiones.MtdCnsPagoComisiones();
            vGridControl1.DataSource = comisiones.DtDatosAdj;
            if (gridView1.Columns.Count >= 0)
            {
                TxtTotalComisionUsa.EditValue = gridView1.Columns[15].SummaryItem.SummaryValue;
            }
            else
            {
                TxtTotalComisionUsa.EditValue = "0.00";
            }

            ValorPago = Convert.ToDecimal(TxtTotalComisionUsa.EditValue.ToString());
            if (ValorPago >= 0)
            {
                BtnPagar.Enabled = true;
            }
            else
            {
                BtnPagar.Enabled = false;
            }
        }

        private void DtpFechaPago_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void TxtTotalComisionUsa_EditValueChanged(object sender, EventArgs e)
        {
            TxtTotalComsion.EditValue = Convert.ToDecimal(TxtTotalComisionUsa.EditValue) * Convert.ToDecimal(TxtTrm.EditValue);
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void BtnPagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            decimal ValorPago = 0;
            ValorPago = Convert.ToDecimal(TxtTotalComisionUsa.EditValue.ToString());
            string Resu;
            if (ValorPago > 0)
            {
                DialogResult rest;
                rest = MessageBox.Show("Esta seguro de Adicionar Este Registro", "Adicionar Comision", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rest == DialogResult.Yes)
                {
                    comisiones.Fecha = Convert.ToDateTime((DtpFechaPago.EditValue.ToString()));
                    comisiones.Trm = Convert.ToDecimal(TxtTrm.EditValue.ToString());

                    Resu = comisiones.MtdAddComision();
                    if (Resu == "OK")
                    {
                        BtnPagar.Enabled = false;
                        comisiones.MtdEntrada(EntradaComision);

                        //gridView1.Columns.Clear();
                        MtdDatos();
                    }

                }
            }

            else
            {
                MessageBox.Show("Comision sin Valores", "Pago Comision", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }


        #endregion


        #region REGION DE METODOS
        private void MtdDatos()
        {
            comisiones.MtdEntrada(EntradaComision);
            RpsAdjudicacion.DataSource = comisiones.DtComisiones.DefaultView;
            RpsAdjudicacion.DisplayMember = comisiones.DtComisiones.DataSet.Tables[0].Columns[1].ToString();
            RpsAdjudicacion.ValueMember = comisiones.DtComisiones.DataSet.Tables[0].Columns[0].ToString();
        }

        #endregion

    }
}