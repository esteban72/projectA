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
    public partial class FrmCatalogoReservas : Form
    {
        public FrmCatalogoReservas()
        {
            InitializeComponent();
        }
        DataTable DtReservas = new DataTable();        
        ClsIdentificacion conexion = new ClsIdentificacion();
        public static string VarContrato, VarIdInmueble, VarIdTercero, VarCliente, VarTipoReserva, VarIdReserva, VarFecha;

        string SentenciaCnsReserva = "Select r.IdReserva,r.TipoReserva,r.Fecha,r.Contrato,r.IdInmueble,r.IdTercero1,t.NombreCompleto  From Reservas r left join Contabilidad_alttum.Terceros t  On t.idtercero = r.idtercero1 Where r.Estado='Pendiente' ";


        private void FrmCatalogoReservas_Load(object sender, EventArgs e)
        {           
            DtReservas = conexion.MtdBuscarDataset(SentenciaCnsReserva);
            mtddatos();            
        }

        private void mtddatos()
        {
            DgvListado.Rows.Clear();

            for (int i = 0; i < (DtReservas.Rows.Count); i++)
            {
                DgvListado.Rows.Add(DtReservas.Rows[i][0], DtReservas.Rows[i][1], DtReservas.Rows[i][2], DtReservas.Rows[i][3], DtReservas.Rows[i][4], DtReservas.Rows[i][5], DtReservas.Rows[i][6]);

            }
            LblRegistros.Text = DgvListado.Rows.Count.ToString();
        }

        private void FrmCatalogoReservas_Activated(object sender, EventArgs e)
        {
            DtReservas = conexion.MtdBuscarDataset(SentenciaCnsReserva);
            mtddatos();
        }

        private void TxtNombreCompleto_TextChanged(object sender, EventArgs e)
        {
            IEnumerable<DataRow> productsQuery =
            from Reserv in DtReservas.AsEnumerable()
            select Reserv;
            IEnumerable<DataRow> BuscarNombre =
            productsQuery.Where(p => p.Field<string>("NombreCompleto").Contains(TxtNombreCompleto.Text.ToUpper()));
         DgvListado.Rows.Clear();
            foreach (DataRow product in BuscarNombre)
            {
                DgvListado.Rows.Add(product.Field<int>("IdReserva"), product.Field<string>("TipoReserva"), product.Field<DateTime>("Fecha"), product.Field<string>("Contrato"), product.Field<string>("IdInmueble"),product.Field<string>("IdTercero1"),product.Field<string>("NombreCompleto"));
            }
        }

        private void DgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            VarIdReserva = DgvListado.Rows[e.RowIndex].Cells[0].Value.ToString();
            VarTipoReserva = DgvListado.Rows[e.RowIndex].Cells[1].Value.ToString();
            VarContrato = DgvListado.Rows[e.RowIndex].Cells[3].Value.ToString();
            VarIdInmueble = DgvListado.Rows[e.RowIndex].Cells[4].Value.ToString();
            VarIdTercero = DgvListado.Rows[e.RowIndex].Cells[5].Value.ToString();
            VarCliente = DgvListado.Rows[e.RowIndex].Cells[6].Value.ToString();
           
            
        }

        private void DgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Close();
        }
        
    }
}
