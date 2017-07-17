using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace CarteraGeneral
{
    class ClsRecaudos
    {
        ClsIdentificacion conexion = new ClsIdentificacion();
        string IdAdjudicacion { get; set; }
        public decimal MaxDiasMora { get; set; }
        public decimal TotalMora { get; set; }
        public decimal PagoMinimo { get; set; }
        public decimal PagoTotal { get; set; }
        public string UltFechaPago { get; set; }
        public decimal InteresesMora { get; set; }
        decimal TasaMora { get; set; }
        int Decimales { get; set; }
        int  Periodo { get; set; }
        int DiasMora { get; set; }
        public DataTable DtDatosGeneral { get; set; }
        public DataTable DtDatosCuota { get; set; }
         DataTable DtParametros = new DataTable();
        public ClsRecaudos(string VarIdAdjudicacion)
        {
            IdAdjudicacion = VarIdAdjudicacion;
            MtdDatosGeneral();
            MtdParametros();
            MtdDatosGrilla();
        }
       
      private void MtdParametros()
        {
            DtParametros = conexion.MtdBuscarDataset("Select * From Parametro Where Estado='Vigente'");
            TasaMora = Convert.ToDecimal(DtParametros.Rows[0][2].ToString());            
            Periodo= Convert.ToInt32(DtParametros.Rows[0][3].ToString());
            DiasMora = Convert.ToInt32(DtParametros.Rows[0][4].ToString());
            Decimales = Convert.ToInt32(DtParametros.Rows[0][6].ToString());
            UltFechaPago = conexion.MtdBscDatos("Select max(Fecha) From Recaudos Where IdAdjudicacion=@IdAdjudicacion", IdAdjudicacion);
          
        }
        private void MtdDatosGeneral()
        {
            DtDatosGeneral= conexion.MtdBuscarDataset(RscRecaudos.DatosGeneral, IdAdjudicacion);
            DtDatosCuota = conexion.MtdBuscarDataset(RscRecaudos.SaldoCuota, IdAdjudicacion.ToString(), TasaMora);
        }
         void MtdDatosGrilla()
        {
            MaxDiasMora = 0;
            TotalMora = 0;
            PagoTotal = 0;
            InteresesMora = 0;
            for (int i = 0; i < (DtDatosCuota.Rows.Count); i++)
            {
                if ((Convert.ToInt16(DtDatosCuota.Rows[i][22]) > MaxDiasMora))
                {
                    MaxDiasMora = Convert.ToInt16(DtDatosCuota.Rows[i][22]);
                }               
              
                if ((Convert.ToDateTime(DtDatosCuota.Rows[i][4]) <= DateTime.Now))
                {
                    PagoMinimo+= Convert.ToDecimal(DtDatosCuota.Rows[i][26]);
                }

              
                InteresesMora += Convert.ToDecimal(DtDatosCuota.Rows[i][24]);
                TotalMora += Convert.ToDecimal(DtDatosCuota.Rows[i][25]);
                PagoTotal += Convert.ToDecimal(DtDatosCuota.Rows[i][26]);
            }
           

        }
    }
}