using System;
using System.Linq;

namespace PDF_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Facturas !!!");

            string fileNameInput = "factura.txt", fileNameOutput = "facturaSalida.csv";

            Console.WriteLine(args.Count());

            if (args.Count() > 0)
            {
                fileNameInput = args[0];
            }
            if(args.Count() > 1)
            {
                fileNameOutput = args[1];
            }

            Console.WriteLine($"Archivo entrada: {fileNameInput}");
            Console.WriteLine($"Archivo salida: {fileNameOutput}");

            var reader = new FacturaReader();

            var facturas = reader.LeerFacturas(fileNameInput);

            facturas = facturas.OrderBy(f => f.EfectoComprobante)
                .ThenBy(f => f.Estatus)
                .ThenBy(f => f.FechaEmision);

            var exito = reader.EscribirFacturasACsv(facturas, fileNameOutput);

            Console.WriteLine("Factura generada!!!");
        }
    }
}
