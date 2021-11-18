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

            var directory = Directory.GetCurrentDirectory();
            var directoryPath =  Directory.GetParent(directory).Parent.Parent.FullName;

            var filesDirectoryPath = $"{directoryPath}\\Metadata";            

            // Examina cada carpeta en la raiz, en busca de mas carpetas.
            CarpetasRecursiva(filesDirectoryPath);

            static void CarpetasRecursiva(string path)
            {
                var carpetas = Directory.GetDirectories(path);

                // Genera facturas de carpeta raiz.
                GenerarFacturas(path);

                if (!carpetas.Any()) return;
                // Si hay carpetas en la carpeta raiz, las analiza y genera facturas.
                foreach (var carpetaPath in carpetas)
                {
                    CarpetasRecursiva(carpetaPath);
                }
            }

            static void GenerarFacturas(string carpetaPath)
            {
                var archivos = Directory.GetFiles(carpetaPath, "*.txt");

                foreach (var file in archivos)
                {
                    var fileNameOutput = $"{file}-Salida.csv";

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
}
