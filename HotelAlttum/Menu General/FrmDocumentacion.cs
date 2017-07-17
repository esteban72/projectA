using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace CarteraGeneral
{
    public partial class FrmDocumentacion : Form
    {
        public FrmDocumentacion()
        {
            InitializeComponent();
        }
        public string EntradaDocumentacion;
        public static int IdDocumentacion;
        ClsIdentificacion NuevoClsIdentificacion = new ClsIdentificacion();
        string TextoBusquedad,  VarIdAdjudicacion ,  VarCliente,VarEstado,VarOpciones ;
        System.Data.DataTable DtListado = new System.Data.DataTable();
        int CuentaRecibidos = 0;
        int CuentaPendientes = 0;

        string Scrip =

                "select Id, " +
                " a.IdAdjudicacion, "+ 
                "c.Identificacion,  " +
                "c.Direccion,  " +
                "c.Ciudad,  " +
                "c.Telefono1,  " +
                "c.IdInmueble,  " +
                "c.Celular,  " +
                "a.Estado, " +
                "a.Operacion,  " +
                "DATEDIFF(curdate(),a.FechaRecibe)Dias " +
                "from Documentacion a join 004cnsadjudica c " +
                "on a.IdAdjudicacion= c.IdAdjudicacion ";

        string Scrip1 =
           
            "  select  " +
            "  c.IdAdjudicacion, "+ 
            "  c.Identificacion,  "+
            "  c.Direccion,  "+
            "  c.Ciudad,  "+
            "  c.Telefono1,  "+
            "  c.IdInmueble,  "+
            "  c.Celular,  "+
            "  if ((Select d.Operacion  From Documentacion d where d.IdAdjudicacion=c.IdAdjudicacion and d.estado ='Enviado')   "+
            "  is null,c.Estado,(Select d.Operacion  From Documentacion d where d.IdAdjudicacion=c.IdAdjudicacion and d.estado ='Enviado'))Estado  "+
            "  from   004cnsadjudica c   ";



        string Scrip2 =          
            "  select  "+
            "  IdReserva,  "+
            " r.Clientes, "+
            " r.Ciudad,  "+
            " r.Direccion, "+ 
            " r.Telefono1,  "+
            " r.IdInmueble,  "+
            " r.Celular,  "+
            " r.Estado  "+
            " from 003cnsreservas r  ";

        private void FrmDocumentacion_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = FrmMenuGeneral.Logo;

            switch (EntradaDocumentacion)
            {

                case "Pagado":
                    LblTituloSumenu.Text = "DOCUMENTOS PAGADOS";
                    BtnDevolver.Visible = false;
                    BtnEnviar.Text = "Enviar a Tramite";
                    MtdDocumentacion();
                    break;


                case "Tramite Escritura":
                    LblTituloSumenu.Text = "DOCUMENTOS EN TRAMITE ESCRITURACION";
                    BtnEnviar.Text = "Enviar a Escriturado";
                    MtdDocumentacion();
                    break;

                case "Escriturado":
                    LblTituloSumenu.Text = "DOCUMENTOS ESCRITURADOS";
                    BtnEnviar.Text = "Enviar a Archivo";
                    MtdDocumentacion();
                    break;

                case "Archivado":
                    LblTituloSumenu.Text = "DOCUMENTOS ARCHIVADOS";
                    BtnEnviar.Text = "Cerrar";
                    MtdDocumentacion();
                    break;


                case "Juridico":
                    LblTituloSumenu.Text = "DOCUMENTOS EN COBRO JURIDICO";
                    BtnEnviar.Text = "Enviar a Cartera";
                    MtdDocumentacion();
                    break;

                case "DesistidoJuridico":
                    LblTituloSumenu.Text = "DOCUMENTOS EN COBRO JURIDICO";
                    BtnEnviar.Text = "Enviar a Desistido";
                    MtdDocumentacion();
                    break;


                case "Aprobado":
                    LblTituloSumenu.Text = "ENVIAR DOCUMENTOS A COBRO JURIDICO";
                    BtnEnviar.Text = "Enviar Juridico";
                    BtnAceptar.Visible = false;
                    MtdJuridicoAdj();
                    break;

                case "Desistido":
                    LblTituloSumenu.Text = "ENVIAR NEGOCIOS DESISTIDOS A COBRO JURIDICO";
                    BtnEnviar.Text = "Enviar Juridico";
                    BtnAceptar.Visible = false;
                    MtdJuridicoDes();
                    break;             
                default:

                    break;





            }
        }

        private void MtdDocumentacion()
        {
            DgvListado.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(Scrip + " Where a.Operacion = '" + EntradaDocumentacion + "'" +
                       " And (a.Estado ='Enviado' or a.Estado= 'Aceptado')");
            TxtRegistros.Text = Convert.ToString(DgvListado.Rows.Count);

            if ((DgvListado.Rows.Count) == 0)
            {
                BtnEnviar.Enabled = false;
                BtnAceptar.Enabled = false;
                BtnDevolver.Enabled = false;
                BtnExportar.Enabled = false;

            }
            MtdDatosGrilla();
        }


        private void MtdJuridicoAdj()
        {
            DgvListado.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(Scrip1 + " Where Estado = '" + EntradaDocumentacion + "'");
            TxtRegistros.Text = Convert.ToString(DgvListado.Rows.Count);

            if ((DgvListado.Rows.Count) == 0)
            {
                BtnEnviar.Enabled = false;
                BtnAceptar.Enabled = false;
                BtnDevolver.Enabled = false;
                BtnExportar.Enabled = false;

            }
            else
            {
                BtnAceptar.Enabled = false;
                BtnDevolver.Enabled = false;
            }

        }


        private void MtdJuridicoDes()
        {
            DgvListado.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(Scrip1 + " Where Estado = '" + EntradaDocumentacion + "'");
            TxtRegistros.Text = Convert.ToString(DgvListado.Rows.Count);

            if ((DgvListado.Rows.Count) == 0)
            {
                BtnEnviar.Enabled = false;
                BtnAceptar.Enabled = false;
                BtnDevolver.Enabled = false;
                BtnExportar.Enabled = false;

            }
            else
            {
                BtnAceptar.Enabled = false;
                BtnDevolver.Enabled = false;
            }

        }

            
     



        private void FrmDocumentacion_Activated(object sender, EventArgs e)
        {
            switch (EntradaDocumentacion)
            {

                case "Pagado":
                    LblTituloSumenu.Text = "DOCUMENTOS PAGADOS";
                    BtnDevolver.Visible = false;
                    BtnEnviar.Text = "Enviar a Tramite";

                    break;


                case "Tramite Escritura":
                    LblTituloSumenu.Text = "DOCUMENTOS EN TRAMITE ESCRITURACION";
                    BtnEnviar.Text = "Enviar a Escriturado";
                    break;

                case "Escriturado":
                    LblTituloSumenu.Text = "DOCUMENTOS ESCRITURADOS";
                    BtnEnviar.Text = "Enviar a Archivo";
                    break;

                case "Archivado":
                    LblTituloSumenu.Text = "DOCUMENTOS ARCHIVADOS";
                    BtnEnviar.Text = "Cerrar";
                    break;


                case "Juridico":
                    LblTituloSumenu.Text = "DOCUMENTOS EN COBRO JURIDICO";
                    BtnEnviar.Text = "Enviar a Cartera";
                    break;

                case "DesistidoJuridico":
                    LblTituloSumenu.Text = "DOCUMENTOS EN COBRO JURIDICO";
                    BtnEnviar.Text = "Enviar a Desistido";
                    break;


                case "Aprobado":
                    LblTituloSumenu.Text = "ENVIAR DOCUMENTOS A COBRO JURIDICO";
                    BtnEnviar.Text = "Enviar Juridico";
                    BtnAceptar.Visible = false;
                    break;

                case "Desistido":
                    LblTituloSumenu.Text = "ENVIAR NEGOCIOS DESISTIDOS A COBRO JURIDICO";
                    BtnEnviar.Text = "Enviar Juridico";
                    BtnAceptar.Visible = false;
                    break;
                default:

                    break;

            }

            if (EntradaDocumentacion == "Aprobado" || EntradaDocumentacion == "Desistido")
            {
                DgvListado.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(Scrip1 + " Where Estado = '" + EntradaDocumentacion + "'");
                TxtRegistros.Text = Convert.ToString(DgvListado.Rows.Count);

                if ((DgvListado.Rows.Count) == 0)
                {
                    BtnEnviar.Enabled = false;
                    BtnAceptar.Enabled = false;
                    BtnDevolver.Enabled = false;
                    BtnExportar.Enabled = false;

                }
                else
                {
                    BtnAceptar.Enabled = false;
                    BtnDevolver.Enabled = false;
                }

            }

            else
            {
                DgvListado.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(Scrip + " Where a.Operacion = '" + EntradaDocumentacion + "'" +
                " And (a.Estado ='Enviado' or a.Estado= 'Aceptado')");
                TxtRegistros.Text = Convert.ToString(DgvListado.Rows.Count);

                if ((DgvListado.Rows.Count) == 0)
                {
                    BtnEnviar.Enabled = false;
                    BtnAceptar.Enabled = false;
                    BtnDevolver.Enabled = false;
                    BtnExportar.Enabled = false;

                }
                MtdDatosGrilla();

            }
        }

        //===================================================================================================================================================
        //I N I C I O   M E T O D O   E X P O R T A R   A    E X C E L 
        //===================================================================================================================================================
        public void exporta_a_excel()
        {
            //Microsoft.Office.Interop.Excel.ApplicationClass excel = new ApplicationClass();
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

            excel.Application.Workbooks.Add(true);

            int ColumnIndex = 0;

            foreach (DataGridViewColumn col in DgvListado.Columns)
            {
                ColumnIndex++;
                excel.Cells[1, ColumnIndex] = col.Name;
            }

            int rowIndex = 0;

            foreach (DataGridViewRow row in DgvListado.Rows)
            {
                rowIndex++;
                ColumnIndex = 0;
                foreach (DataGridViewColumn col in DgvListado.Columns)
                {
                    ColumnIndex++;
                    excel.Cells[rowIndex + 1, ColumnIndex] = row.Cells[col.Name].Value;
                }

            }

            excel.Visible = true;

            Worksheet Libro = (Worksheet)excel.ActiveSheet;

            //Libro.Activate();

        }
        //===================================================================================================================================================
        //F I N A L    M E T O D O   E X P O R T A R    A     E X C E L 
        //===================================================================================================================================================



        //===================================================================================================================================================
        // I N I C I O    E V E N T O  TxtBusqueda_TextChanged
        //===================================================================================================================================================
        private void TxtBusqueda_TextChanged(object sender, EventArgs e)
        {

            if (CmbBusqueda.Text == "")
            {
                MessageBox.Show("Debe Seleccionar Parametro de busquedad", "Error en Busquedad", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                switch (CmbBusqueda.Text)
                {
                    case "Tercero1":
                        TextoBusquedad = "IdTercero1";
                        break;

                    case "Tercero2":
                        TextoBusquedad = "IdTercero2";
                        break;

                    case "Cliente":
                        TextoBusquedad = "Identificacion";
                        break;


                    case "Adjudicacion":
                        TextoBusquedad = "IdAdjudicacion";

                        break;

                    case "Inmueble":
                        TextoBusquedad = "IdInmueble";
                        break;

                    case "Contrato":
                        TextoBusquedad = "Contrato";
                        break;

                    case "Estado":
                        TextoBusquedad = "Estado";
                        break;

                    default:

                        break;
                }

            }








            string SentenciaBsc =
            Scrip + " Where  a.Operacion = '" + EntradaDocumentacion + "'" + " And (a.Estado ='Enviado' or a.Estado= 'Aceptado')" +
             " And  c." + TextoBusquedad + " Like  '" + TxtBusqueda.Text + "%' order by mid(c.idadjudicacion,4,10)+0";
            DgvListado.DataSource = NuevoClsIdentificacion.MtdBuscarDataset(SentenciaBsc);

            TxtRegistros.Text = Convert.ToString(DgvListado.Rows.Count);
        }
        //===================================================================================================================================================
        // F I N A L    E V E N T O    TxtBusqueda_TextChanged
        //===================================================================================================================================================




        //===================================================================================================================================================
        // I N I C I O    M E T O D O    D A T O S   G R I L L A
        //===================================================================================================================================================
        public void MtdDatosGrilla()
        {

            CuentaPendientes = 0;
            CuentaRecibidos = 0;

            for (int i = 0; i < (DgvListado.Rows.Count); i++)
            {
                if (Convert.ToString(DgvListado.Rows[i].Cells[8].Value) == "Enviado")
                {
                    CuentaPendientes = CuentaPendientes + 1;
                    DgvListado.Rows[i].DefaultCellStyle.BackColor = Color.Silver;


                }
                if (Convert.ToString(DgvListado.Rows[i].Cells[8].Value) == "Aceptado")
                {
                    CuentaRecibidos = CuentaRecibidos + 1;
                    DgvListado.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                if (Convert.ToString(DgvListado.Rows[i].Cells[4].Value) == "Devuelto")
                {

                }

            }
            TxtPendientes.Text = Convert.ToString(CuentaPendientes);
            TxtAceptados.Text = Convert.ToString(CuentaRecibidos);
        }
        //===================================================================================================================================================
        // F I N A L    M E T O D O    D A T O S   G R I L L A
        //===================================================================================================================================================



        //===================================================================================================================================================
        // I N I C I O    E V E N T O   B O T O N   S A L I R
        //===================================================================================================================================================
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        //===================================================================================================================================================
        // F I N A L    E V E N T O   B O T O N   S A L I R 
        //===================================================================================================================================================



        //===================================================================================================================================================
        // I N I C I O    E V E N T O   DgvListado_CellEnter
        //===================================================================================================================================================
        private void DgvListado_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (  EntradaDocumentacion == "Aprobado" ||   EntradaDocumentacion == "Desistido")
            {
                  VarIdAdjudicacion = DgvListado.Rows[e.RowIndex].Cells[0].Value.ToString();
                  VarCliente = DgvListado.Rows[e.RowIndex].Cells[1].Value.ToString();

            }



            else
            {
                IdDocumentacion = Convert.ToInt16(DgvListado.Rows[e.RowIndex].Cells[0].Value.ToString());
                VarIdAdjudicacion = DgvListado.Rows[e.RowIndex].Cells[1].Value.ToString();
                VarCliente = DgvListado.Rows[e.RowIndex].Cells[2].Value.ToString();
                VarEstado = DgvListado.Rows[e.RowIndex].Cells[9].Value.ToString();


                if (DgvListado.Rows[e.RowIndex].Cells[8].Value.ToString() == "Aceptado")
                {
                    BtnAceptar.Enabled = false;
                    BtnDevolver.Enabled = false;
                    BtnEnviar.Enabled = true;
                }
                else
                    if (DgvListado.Rows[e.RowIndex].Cells[8].Value.ToString() == "Enviado")
                    {
                        BtnAceptar.Enabled = true;
                        BtnDevolver.Enabled = true;
                        BtnEnviar.Enabled = false;
                    }
                    else
                        if (DgvListado.Rows[e.RowIndex].Cells[8].Value.ToString() == "Devuleto")
                        {
                            BtnAceptar.Enabled = false;
                            BtnDevolver.Enabled = false;
                            BtnEnviar.Enabled = true;
                        }



                MtdDatosGrilla();

            }


        }
        //===================================================================================================================================================
        // F I N A L    E V E N T O  DgvListado_CellEnter
        //===================================================================================================================================================



        //===================================================================================================================================================
        // I N I C I O    E V E N T O   B O T O N   A C E P T A R
        //===================================================================================================================================================
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            FrmEnvioEscrituracion frmEnvioEscrituracion = new FrmEnvioEscrituracion();
            frmEnvioEscrituracion.Opciones = "Aceptar";
            frmEnvioEscrituracion.VarCliente = VarCliente;
            frmEnvioEscrituracion.VarIdAdjudicacion = VarIdAdjudicacion;
            frmEnvioEscrituracion.EntradaDocumentacion = EntradaDocumentacion;
            frmEnvioEscrituracion.MdiParent = this.MdiParent;
            frmEnvioEscrituracion.Show();
        }
        //===================================================================================================================================================
        // F I N A L    E V E N T O  A C E P T A R
        //===================================================================================================================================================



        //===================================================================================================================================================
        // I N I C I O    E V E N T O   BtnExportar_Click
        //===================================================================================================================================================
        private void BtnExportar_Click(object sender, EventArgs e)
        {
            exporta_a_excel();
        }
        //===================================================================================================================================================
        // F I N A L    E V E N T O BtnExportar_Click
        //===================================================================================================================================================



//===================================================================================================================================================
// I N I C I O    E V E N T O   E N V I A R 
//===================================================================================================================================================
        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            switch (EntradaDocumentacion)
            {
                case "Pagado":
                   VarOpciones = "Tramite";
                    break;

                case "Tramite Escritura":
                   VarOpciones = "Escriturado";
                    break;

                case "Escriturado":
                   VarOpciones = "Archivado";
                    break;

                case "Archivado":
                   VarOpciones = "Cerrado";
                    break;

                case "Juridico":
                   VarOpciones = "DvAprobado";
                    break;

                case "DesistidoJuridico":
                   VarOpciones = "DvDesistido";
                    break;

                case "Aprobado":
                   VarOpciones = "Juridico";
                    break;
                case "Desistido":
                   VarOpciones = "DesistidoJuridico";
                    break;

                default:
                    break;
            }

           
            FrmEnvioEscrituracion frmEnvioEscrituracion = new FrmEnvioEscrituracion();
            frmEnvioEscrituracion.Opciones = VarOpciones;
            frmEnvioEscrituracion.VarCliente = VarCliente;
            frmEnvioEscrituracion.VarIdAdjudicacion = VarIdAdjudicacion;
            frmEnvioEscrituracion.EntradaDocumentacion = EntradaDocumentacion;
            frmEnvioEscrituracion.MdiParent = this.MdiParent;
            frmEnvioEscrituracion.Show();

        }
//===================================================================================================================================================
// F I N A L    E V E N T O   E N V I A R
//===================================================================================================================================================



        //===================================================================================================================================================
        // I N I C I O    E V E N T O  BtnDevolver_Click
        //===================================================================================================================================================
        private void BtnDevolver_Click(object sender, EventArgs e)
        {
            switch (EntradaDocumentacion)
            {


                case "Tramite Escritura":
                   VarOpciones = "DvPagado";
                    break;

                case "Escriturado":
                   VarOpciones = "DvTramite";
                    break;

                case "Archivado":
                   VarOpciones = "DvEscrituado";
                    break;

                case "Juridico":
                   VarOpciones = "DvAprobado";
                    break;


                case "DesistidoJuridico":
                   VarOpciones = "DvDesistido";
                    break;

                case "Aprobado":
                   VarOpciones = "DvJuridico";
                    break;
                default:
                    break;
            }

            FrmEnvioEscrituracion frmEnvioEscrituracion = new FrmEnvioEscrituracion();
            frmEnvioEscrituracion.Opciones = VarOpciones;
            frmEnvioEscrituracion.VarCliente = VarCliente;
            frmEnvioEscrituracion.VarIdAdjudicacion = VarIdAdjudicacion;
            frmEnvioEscrituracion.EntradaDocumentacion = EntradaDocumentacion;
            frmEnvioEscrituracion.MdiParent = this.MdiParent;
            frmEnvioEscrituracion.Show();

        }
        //===================================================================================================================================================
        // F I N A L    E V E N T O  BtnDevolver_Click
        //===================================================================================================================================================

    }
}
