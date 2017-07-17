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
    public partial class FrmAdjudicacionMonterey : Form
    {
        public FrmAdjudicacionMonterey()
        {
            InitializeComponent();
        }
        #region VARIABLES
        ClsIdentificacion conexion = new ClsIdentificacion();        
        DataTable DtListado = new DataTable();
        string VarIdAdj;
        #endregion
        private void FrmAdjudicacionMonterey_Load(object sender, EventArgs e)
        {

            #region PERMISOS
            BtnEnvioDirecta.Enabled = conexion.MtdBscFrmIdFrm("Modificar", FrmLogeo.FrmUsuarioIdUsr, "413");            
            #endregion

            this.Text = "MODULO DE ADJUDICACION DE MONTEREY USUARIO: " + FrmLogeo.Usuario.ToUpper();           
            ListadoAdjMonterey();
            

        }

        private void ListadoAdjMonterey()
        {
            DtListado = conexion.MtdBuscarDataset("Select Scrip from Vistas where Vista='CnsAdjMonterey'");
            string strconsulta = DtListado.Rows[0]["Scrip"].ToString();
            DtListado = conexion.MtdBuscarDataset(strconsulta);
            GridModAdjMont.DataSource = DtListado;
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            VarIdAdj = gridView1.GetFocusedRowCellValue("IdAdjudicacion").ToString();
        }

        private void BtnEnvioDirecta_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            DialogResult exit;
            exit = MessageBox.Show("Esta seguro de Enviar ADJ"+VarIdAdj+ "\n De Monterey a Directa", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (exit == DialogResult.Yes)
            {
                conexion.MtdAddSentencia("Update adjudicacion set TipoOperacion='Normal' where idadjudicacion="+VarIdAdj);
                string strFecha = conexion.MtdVldFchPed(DateTime.Now);
                string strinsert = "Insert into documentacion(Fecha,Operacion,IdAdjudicacion,UsuarioEnvio,Estado) Values('" + strFecha + "','Directa','" + VarIdAdj + "','" + FrmLogeo.Usuario.ToUpper() + "','Aceptado')";
                conexion.MtdAddSentencia(strinsert);
                MessageBox.Show("Negocio enviado \n ADJ"+VarIdAdj, Text);
                ListadoAdjMonterey();
            }
        }
    }
}
