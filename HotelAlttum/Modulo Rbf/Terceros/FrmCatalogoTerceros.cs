using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace CarteraGeneral
{
    public partial class FrmCatalogoTerceros : Form
    {
        public FrmCatalogoTerceros()
        {
            InitializeComponent();
        }

        public static string VarIdTercero,VarNombreTercero ;
        public string VarTipoTercero;
        ClsIdentificacion conexion = new ClsIdentificacion();
        DataTable Terceros = new DataTable();
        private void FrmCatalogoTerceros_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;

            Terceros = conexion.MtdBuscarDataset("Select IdTercero,NombreCompleto from Contabilidad_alttum.Terceros  Where TipoTercero='" + VarTipoTercero + "' Order by NombreCompleto");
            DgvTerceros.Rows.Clear();
            for (int i = 0; i < (Terceros.Rows.Count); i++)
            {
                DgvTerceros.Rows.Add(Terceros.Rows[i][0], Terceros.Rows[i][1]);

            }
        }

        private void TxtNombreProductos_TextChanged(object sender, EventArgs e)
        {          
            IEnumerable<DataRow> productsQuery =
            from Terceros1 in Terceros.AsEnumerable()
            select Terceros1;
            IEnumerable<DataRow> BuscarNombre =
            productsQuery.Where(p => p.Field<string>("NombreCompleto").Contains(TxtNombreCompleto.Text.ToUpper()));
            DgvTerceros.Rows.Clear();
            foreach (DataRow product in BuscarNombre)
            {
                DgvTerceros.Rows.Add(product.Field<string>("IdTercero"), product.Field<string>("NombreCompleto"));
            }
        }

        private void DgvTerceros_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            VarIdTercero =     DgvTerceros.Rows[e.RowIndex].Cells[0].Value.ToString();
            VarNombreTercero = DgvTerceros.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void DgvTerceros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VarIdTercero =     DgvTerceros.Rows[e.RowIndex].Cells[0].Value.ToString();
            VarNombreTercero = DgvTerceros.Rows[e.RowIndex].Cells[1].Value.ToString();
            Close();
        }

        private void DgvTerceros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                Close();
            }
            else
            {
                e.Handled = false;
            }
        }

        private void BtnAddTercero_Click(object sender, EventArgs e)
        {
            //bool ValMod = conexion.MtdBscFormDesconectado("101", "Adicionar");
            //if (ValMod == false)
            //{
            //    MessageBox.Show("No Tiene Permiso Para Modificar", "Error Permisos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            //}
            //else
            //{
            //    FrmLogeo.Entrada = "Adicionar";
            //    FrmTerceros AddClientes = new FrmTerceros();
            //    AddClientes.ShowDialog();
            //}
        }

        private void FrmCatalogoTerceros_Activated(object sender, EventArgs e)
        {
            Terceros = conexion.MtdBuscarDataset("Select IdTercero,NombreCompleto from Contabilidad_alttum.Terceros  Where TipoTercero='" + VarTipoTercero + "' Order by NombreCompleto");
            DgvTerceros.Rows.Clear();
            for (int i = 0; i < (Terceros.Rows.Count); i++)
            {
                DgvTerceros.Rows.Add(Terceros.Rows[i][0], Terceros.Rows[i][1]);

            }
        }

       
    }
}
