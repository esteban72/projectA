﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34014
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
    internal class RscComisiones {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RscComisiones() {
        }
        
        /// <summary>
        ///   Devuelve la instancia de ResourceManager almacenada en caché utilizada por esta clase.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CarteraGeneral.RscComisiones", typeof(RscComisiones).Assembly);
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
        ///   Busca una cadena traducida similar a 
        ///Select operacion,Debe ,Haber,Documento  From Contabilidad_alttum.datoscuenta Where Operacion= &apos;PagoComision&apos;
        ///union
        ///Select operacion,debe,Haber,Documento   From Contabilidad_alttum.datoscuenta Where Operacion= &apos;PagoComision&apos;
        ///union
        ///Select operacion,Debe ,haber ,Documento  From Contabilidad_alttum.datoscuenta Where Operacion= &apos;Anticipo Comision&apos;
        ///union
        ///Select operacion,debe, Haber,Documento   From Contabilidad_alttum.datoscuenta Where Operacion= &apos;Descuento Fondo&apos;.
        /// </summary>
        internal static string CuentasComisiones {
            get {
                return ResourceManager.GetString("CuentasComisiones", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Busca una cadena traducida similar a SELECT
        ///	p.Id,
        ///	P.IdFinanciacion,
        ///	p.IdAdjudicacion,
        ///	p.Fecha,
        ///	p.IdTercero,
        ///	p.idcargo,
        ///	p.tasacomision,
        ///	sum(p.Comision) Comision,
        ///	sum(p.Retencion) Retencion,
        ///	sum(p.DctoAnticipo) DctoAnticipo,
        ///	Sum(p.PagoNeto) PagoNeto,
        ///	p.Usuario,
        ///	p.FechaOperacion,
        ///	p.Transaccion,
        ///	a.NombreComPleto AS Cliente,
        ///	g.NombreCompleto AS Asesor
        ///FROM pagocomision P
        ///LEFT JOIN Contabilidad_alttum.terceros g ON g.idtercero = p.idtercero
        ///LEFT JOIN adjudicacion t ON t.idadjudicacion = p.idadjudicacion
        ///LEFT JOIN contabi [resto de la cadena truncado]&quot;;.
        /// </summary>
        internal static string RsmComisiones {
            get {
                return ResourceManager.GetString("RsmComisiones", resourceCulture);
            }
        }
    }
}
