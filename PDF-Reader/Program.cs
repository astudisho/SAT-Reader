using System;
using System.IO;
using System.Linq;

namespace PDF_Reader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Facturas !!!");

            string fileNameInput = "factura.txt", fileNameOutput =  $"facturaSalida.csv";

            Console.WriteLine(args.Count());

            if (args.Count() > 0)
            {
                fileNameInput = args[0];
            }
            if(args.Count() > 1)
            {
                fileNameOutput = args[1];
            }

            var directoryNameInput = "J:\\Users\\javie\\Documents\\csharp\\SAT-Reader\\PDF-Reader\\Metadata\\";

            var archivos = Directory.GetFiles(directoryNameInput, "*.txt");

            foreach (var file in archivos)
            {
                fileNameOutput = $"{file}-Salida.csv";

                Console.WriteLine($"Archivo entrada: {file}");
                Console.WriteLine($"Archivo salida: {fileNameOutput}");

                var reader = new FacturaReader();

                var facturas = reader.LeerFacturas(file);

                facturas = facturas.OrderBy(f => f.EfectoComprobante)
                    .ThenBy(f => f.Estatus)
                    .ThenBy(f => f.FechaEmision);

                var exito = reader.EscribirFacturasACsv(facturas, fileNameOutput);

                Console.WriteLine("Factura generada!!!"); 
            }
        }
    }
}
