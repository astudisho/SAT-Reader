using System;

namespace PDF_Reader
{
    internal class Factura
    {
        internal Guid Uuid { get; set; }
        internal string RfcEmisor { get; set; }
        internal string NombreEmisor { get; set; }
        internal string RfcReceptor { get; set; }
        internal string NombreReceptor { get; set; }
        internal string RfcPac { get; set; }
        internal DateTime FechaEmision { get; set; }
        internal DateTime FechaCertificacionSat { get; set; }
        internal decimal Monto { get; set; }
        internal EfectoComprobante EfectoComprobante { get; private set; }
        internal bool Estatus { get; set; }
        internal DateTime FechaCancelacion { get; set; }

        private char efectoComprobanteChar;

        internal char EfectoComprobanteChar {
            set
            {
                if (value == 'I') EfectoComprobante = EfectoComprobante.Ingreso;
                else if (value == 'E') EfectoComprobante = EfectoComprobante.Egreso;
                else if (value == 'N') EfectoComprobante = EfectoComprobante.Nomina;
                else if (value == 'P') EfectoComprobante = EfectoComprobante.Pago;
                else EfectoComprobante = EfectoComprobante.Indefinido;

                efectoComprobanteChar = value;
            }
            get { return efectoComprobanteChar; }
        }

        public override string ToString()
        {
            return $"{NombreEmisor} {Monto} {EfectoComprobante}";
        }
    }

    internal enum EfectoComprobante
    {
        Indefinido, Ingreso, Egreso, Nomina, Pago
    }
}
