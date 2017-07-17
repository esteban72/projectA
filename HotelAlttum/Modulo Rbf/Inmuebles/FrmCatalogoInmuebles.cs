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
    public partial class FrmCatalogoInmuebles : Form
    {
        public FrmCatalogoInmuebles()
        {
            InitializeComponent();
        }

        public string TipodeSemana;
      
        public static string VarIdInmueble,VarVilla,VarSemana,VarUnidad,VarTipoSemana,VarTemporada;

        DataTable Inmuebles = new DataTable();

        ClsIdentificacion conexion = new ClsIdentificacion();       


        private void FrmCatalogoInmuebles_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;

            if (TipodeSemana == "SISTEMATICA")
            {
                Inmuebles = conexion.MtdBuscarDataset("Select IdInmueble,Villa,Unidad,Semana,TipodeSemana,Temporada,CnsCompra from Inmuebles Where Estado='Libre' And TipodeSemana='SISTEMATICA'");
            }
            else
                if (TipodeSemana == "PREFERENTE")
                {
                    Inmuebles = conexion.MtdBuscarDataset("Select IdInmueble,Villa,Unidad,Semana,TipodeSemana,Temporada,CnsCompra from Inmuebles Where Estado='Libre' And TipodeSemana='PREFERENTE'");
                }

       

            DgvTerceros.Rows.Clear();
            for (int i = 0; i < (Inmuebles.Rows.Count); i++)
            {
                DgvTerceros.Rows.Add(Inmuebles.Rows[i][0], Inmuebles.Rows[i][1], Inmuebles.Rows[i][2], Inmuebles.Rows[i][3], Inmuebles.Rows[i][4], Inmuebles.Rows[i][5], Inmuebles.Rows[i][6]);

            }
        }

        private void DgvTerceros_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            VarIdInmueble = DgvTerceros.Rows[e.RowIndex].Cells[0].Value.ToString();
            VarVilla = DgvTerceros.Rows[e.RowIndex].Cells[1].Value.ToString();
            VarSemana = DgvTerceros.Rows[e.RowIndex].Cells[3].Value.ToString();
            VarUnidad = DgvTerceros.Rows[e.RowIndex].Cells[2].Value.ToString();
            VarTipoSemana = DgvTerceros.Rows[e.RowIndex].Cells[4].Value.ToString();
            VarTemporada = DgvTerceros.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void DgvTerceros_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            VarIdInmueble = DgvTerceros.Rows[e.RowIndex].Cells[0].Value.ToString();
            VarVilla = DgvTerceros.Rows[e.RowIndex].Cells[1].Value.ToString();
            VarSemana = DgvTerceros.Rows[e.RowIndex].Cells[3].Value.ToString();
            VarUnidad = DgvTerceros.Rows[e.RowIndex].Cells[2].Value.ToString();
            VarTipoSemana = DgvTerceros.Rows[e.RowIndex].Cells[4].Value.ToString();
            VarTemporada = DgvTerceros.Rows[e.RowIndex].Cells[5].Value.ToString();
            Close();
        }

        private void TxtNombreCompleto_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<DataRow> productsQuery =
            from Terceros1 in Inmuebles.AsEnumerable()
            select Terceros1;
            IEnumerable<DataRow> BuscarNombre =
            productsQuery.Where(p => p.Field<string>(CmbBusquedad.Text).Contains(TxtNombreCompleto.Text.ToUpper()));
            DgvTerceros.Rows.Clear();
            foreach (DataRow product in BuscarNombre)
            {
                DgvTerceros.Rows.Add(product.Field<string>("IdInmueble"), product.Field<string>("Villa"), product.Field<string>("Unidad"), product.Field<string>("Semana"), product.Field<string>("TipodeSemana"), product.Field<string>("Temporada"));
            }
        }

    }
}
