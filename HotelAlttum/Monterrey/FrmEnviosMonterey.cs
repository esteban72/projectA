using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
 
namespace CarteraGeneral
{
    public partial class FrmEnviosMonterey : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmEnviosMonterey()
        {
            InitializeComponent();
        }
        public string Entrada,VarIdLote;
        ClsIdentificacion conexion = new ClsIdentificacion();
        ClsMonterrey EnviosMont = new ClsMonterrey();
        DataTable DtEnvio = new DataTable();
        string Varid,strResultado;
        DataTable DtLotes = new DataTable();
        DataTable DtDatos = new DataTable();
        private void FrmEnviosMonterey_Load(object sender, EventArgs e)
        {
            if (Entrada == "Adicionar")
            {
                DtDatos = conexion.MtdBuscarDataset(MisConsultas.negociosnoenviadomonterey);
                DtLotes = conexion.MtdBuscarDataset("Select * from lotesenvio");
                DtEnvio = conexion.MtdBuscarDataset(MisConsultas.NegociosNoenviadovacio);

                RpsLotes.DataSource = DtLotes.AsDataView();
                RpsLotes.DisplayMember = DtLotes.DataSet.Tables[0].Columns[0].ToString();
                RpsLotes.ValueMember = DtLotes.DataSet.Tables[0].Columns[0].ToString();

                GrdEnviosMonterey.DataSource = DtEnvio;
                RpsAdjduicacion.DataSource = DtDatos.AsDataView();
                RpsAdjduicacion.DisplayMember = DtDatos.DataSet.Tables[0].Columns[0].ToString();
                RpsAdjduicacion.ValueMember = DtDatos.DataSet.Tables[0].Columns[0].ToString();
                gridView1.AddNewRow();
                gridView1.FocusedRowHandle = 0;
            }

            else
                if (Entrada=="Modificar")
                {
                    DtDatos = conexion.MtdBuscarDataset(MisConsultas.CnsModNegocionsNoEnviadoMonterey,VarIdLote);
                    DtLotes = conexion.MtdBuscarDataset("Select * from lotesenvio where id =@Parametro1",VarIdLote);
                    DtEnvio = conexion.MtdBuscarDataset(MisConsultas.CnsEnviosxIdLote, VarIdLote);

                    RpsLotes.DataSource = DtLotes.AsDataView();
                    RpsLotes.DisplayMember = DtLotes.DataSet.Tables[0].Columns[0].ToString();
                    RpsLotes.ValueMember = DtLotes.DataSet.Tables[0].Columns[0].ToString();
                    CmbLote.EditValue = VarIdLote;
                    CmbLote.Edit.ReadOnly = true;
                    GrdEnviosMonterey.DataSource = DtEnvio;

                    RpsAdjduicacion.DataSource = DtDatos.AsDataView();
                    RpsAdjduicacion.DisplayMember = DtDatos.DataSet.Tables[0].Columns[0].ToString();
                    RpsAdjduicacion.ValueMember = DtDatos.DataSet.Tables[0].Columns[0].ToString();
                    gridView1.AddNewRow();
                    gridView1.FocusedRowHandle = 0;
                }



        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {        
            
              
           
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            Boolean BNoEsta = false;
            if (e.Column.FieldName=="IdAdjudicacion")
            {
                Varid = e.Value.ToString();
                for (int i = 0; i < gridView1.RowCount - 1; i++)
                {
                    if (i != e.RowHandle)
                    {
                        if (Varid == gridView1.GetRowCellValue(i, gridView1.Columns[0]).ToString())
                        {
                            MessageBox.Show("Ya fue seleccionado");
                            BNoEsta = true;
                        }
                    }
                }
                if (BNoEsta == false)
                {
                    for (int i = 0; i < (DtDatos.Rows.Count); i++)
                    {
                        if (Varid == DtDatos.Rows[i][0].ToString())
                        {
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[1], DtDatos.Rows[i]["IdTercero1"].ToString());
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[2], DtDatos.Rows[i]["Cliente"].ToString());
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[3], DtDatos.Rows[i]["FechaContrato"].ToString());
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[4], DtDatos.Rows[i]["Contrato"].ToString());
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[5], DtDatos.Rows[i]["Trm"].ToString());
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[6], DtDatos.Rows[i]["Valor"].ToString());
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[7], DtDatos.Rows[i]["ValorMonedaLocal"].ToString());
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[8], DtDatos.Rows[i]["FinanciacionMfs"].ToString());
                            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns[9], DtDatos.Rows[i]["CuotaMfs"].ToString());
                            
                        }
                    }
                    if (e.RowHandle == gridView1.RowCount - 1)
                    {
                        gridView1.AddNewRow();
                    }
                }
                
            }
        }

        private void BtnGuardar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (Entrada == "Adicionar")
            {
                if (MtdValidar() == false)
                {
                    if (MessageBox.Show("¿Enviar a Monterey?", "Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        EnviosMont.IdLote = CmbLote.EditValue.ToString();
                        EnviosMont.Fecha = Convert.ToDateTime(DtpFecha.EditValue.ToString());
                        EnviosMont.dtDetalle = DtEnvio;

                        strResultado = EnviosMont.MtdGuardarEnvio();
                        if (strResultado == "OK")
                        {
                            MessageBox.Show("Datos Enviados", "Envio Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(strResultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }


            else

                if (Entrada == "Modificar")
                {
                    if (MtdValidar() == false)
                    {
                        if (MessageBox.Show("¿Enviar a Monterey?", "Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                        {
                            EnviosMont.IdLote = CmbLote.EditValue.ToString();
                            EnviosMont.Fecha = Convert.ToDateTime(DtpFecha.EditValue.ToString());
                            EnviosMont.dtDetalle = DtEnvio;

                            strResultado = EnviosMont.MtdModificarEnvio();
                            if (strResultado == "OK")
                            {
                                MessageBox.Show("Datos Enviados", "Envio Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show(strResultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                }
        }

        Boolean MtdValidar()
        {
            Boolean HayError = false;
            if (DtpFecha.EditValue == null)
            {
                MessageBox.Show("Seleccione la fecha de envio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HayError = true;
            }
            else if (CmbLote.EditValue == null)
            {
                MessageBox.Show("Seleccione el lote", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HayError = true;
                
            }else if (gridView1.RowCount < 1)
            {
                MessageBox.Show("Seleccione los contratos a enviar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HayError = true;
            }
            return HayError;
        }

        private void gridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (gridView1.FocusedRowHandle != gridView1.RowCount - 1)
                {
                    if (MessageBox.Show("¿Desea Eliminar el Contrato?", "Confirmacion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
                    {
                        gridView1.DeleteRow(gridView1.FocusedRowHandle);
                    }
                }
            }
        }
    }
}