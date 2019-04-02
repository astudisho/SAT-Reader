using System;
using System.Linq;

namespace PDF_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Facturas !!!");

            var reader = new FacturaReader();

            var facturas = reader.LeerFacturas("factura.txt");

            facturas = facturas.OrderBy(f => f.EfectoComprobante)
                .ThenBy(f => f.Estatus)
                .ThenBy(f => f.FechaEmision);

            var exito = reader.EscribirFacturasACsv(facturas, "facturasFormat.txt");
        }
    }
}
