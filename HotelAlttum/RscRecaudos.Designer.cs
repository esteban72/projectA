﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarteraGeneral {
    using System;
    
    
    /// <summary>
    ///   Clase de recurso fuertemente tipado, para buscar cadenas traducidas, etc.
    /// </summary>
    // StronglyTypedResourceBuilder generó automáticamente esta clase
    // a través de una herramienta como ResGen o Visual Studio.
    // Para agregar o quitar un miembro, edite el archivo .ResX y, a continuación, vuelva a ejecutar ResGen
    // con la opción /str o recompile su proyecto de VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class RscRecaudos {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RscRecaudos() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CarteraGeneral.RscRecaudos", typeof(RscRecaudos).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Reemplaza la propiedad CurrentUICulture del subproceso actual para todas las
        ///   búsquedas de recursos mediante esta clase de recurso fuertemente tipado.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT a.IdAdjudicacion,a.IdTercero1,t.NombreCompleto Cliente,
        ///t2.NombreCompleto Cliente2,
        ///a.Fecha,a.Contrato,a.IdInmueble,
        ///a.TipodeAdjudicacion,a.Temporada, UPPER(a.Grado)Grado,
        /// a.Valor, UPPER(a.Estado)Estado,TipoOperacion
        ///FROM Adjudicacion a
        ///LEFT JOIN Contabilidad_alttum.Terceros t ON t.IdTercero=a.IdTercero1
        ///LEFT JOIN Contabilidad_alttum.Terceros t2 ON t2.IdTercero=a.IdTercero2
        ///WHERE Estado= &apos;Aprobado&apos;.
        /// </summary>
        internal static string DatosAdjudicacion {
            get {
                return ResourceManager.GetString("DatosAdjudicacion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT a.IdAdjudicacion,a.IdTercero1,t.NombreCompleto Cliente,
        ///t2.NombreCompleto Cliente2,
        ///a.Fecha,a.Contrato,a.IdInmueble,
        ///a.TipodeAdjudicacion,a.Temporada, UPPER(a.Grado)Grado,
        /// a.Valor, UPPER(a.Estado)Estado,TipoOperacion
        ///FROM Adjudicacion a
        ///LEFT JOIN Contabilidad_alttum.Terceros t ON t.IdTercero=a.IdTercero1
        ///LEFT JOIN Contabilidad_alttum.Terceros t2 ON t2.IdTercero=a.IdTercero2
        /// .
        /// </summary>
        internal static string DatosAdjudicacionesTodas {
            get {
                return ResourceManager.GetString("DatosAdjudicacionesTodas", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select IdAdjudicacion, IdTercero1,Identificacion,TipodeAdjudicacion,Temporada,Grado,IdInmueble From 004cnsadjudica WHERE IdAdjudicacion =@Parametro1.
        /// </summary>
        internal static string DatosGeneral {
            get {
                return ResourceManager.GetString("DatosGeneral", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a select l.*,
        ///l.SaldoIntMora+l.Mora as TotalMora,
        ///l.SaldoIntMora+l.Mora+l.SaldoCuota as TotalCuota,
        ///0 as Recaudo
        ///FROM
        ///(
        ///SELECT S.*,
        ///convert(if((s.concepto=&apos;CI&apos;)or (s.concepto=&apos;GA&apos;),0,
        ///(s.Saldocuota*@Mora*s.DiasLqd/36000)),dec(18,2)) as Mora
        ///FROM
        ///(
        ////*004SaldoCuotas*/
        ///SELECT f.IdCta AS IdCta,f.IdAdjudicacion AS IdAdjudicacion,f.Concepto AS Concepto,f.NumCuota AS NumCuota,f.Fecha AS Fecha,f.Capital AS Capital,f.Interes AS Interes,f.Cuota AS Cuota,f.SaldoCapital AS SaldoCapital,f.SaldoInteres AS Saldo [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string SaldoCuota {
            get {
                return ResourceManager.GetString("SaldoCuota", resourceCulture);
            }
        }
    }
}
