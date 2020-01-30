using System;
using System.Collections.Generic;
using System.Text;

namespace PDF_Reader
{
    internal static class Constants
    {
        internal readonly static char Separador = '~';
        internal readonly static char SeparadorComa = ',';

        internal enum IndiceCampos
        {
            Uuid,
            RfcEmisor,
            NombreEmisor,
            RfcReceptor,
            NombreReceptor,
            RfcPac,
            FechaEmision,
            FechaCertificacionSat,
            Monto,
            EfectoComprobante,
            Estatus,
            FechaCancelacion
        }

        internal readonly static string CabeceraCsv = "Razon Social~Monto~Fecha~RFC emisor~Concepto~Folio~Efecto~Estatus";
        internal readonly static string CabeceraCsvComa = "Razon Social,Monto,Fecha,RFC emisor,Concepto,Folio,Efecto,Estatus";
    }
}
