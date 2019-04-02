using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace PDF_Reader
{
    public class FacturaReader
    {
        internal IEnumerable<Factura> LeerFacturas(string fileName)
        {
            List<Factura> facturas = new List<Factura>();
            try
            {
                var lineas = File.ReadAllLines(fileName).ToList();
                lineas.RemoveAt(0);

                foreach (var linea in lineas)
                {
                    try
                    {
                        var campos = linea.Split(Constants.Separador);

                        var factura = new Factura()
                        {
                            Uuid = Guid.Parse(campos[(int)Constants.IndiceCampos.Uuid]),
                            RfcEmisor = campos[(int)Constants.IndiceCampos.RfcEmisor],
                            NombreEmisor = campos[(int)Constants.IndiceCampos.NombreEmisor],
                            RfcReceptor = campos[(int)Constants.IndiceCampos.RfcReceptor],
                            RfcPac = campos[(int)Constants.IndiceCampos.RfcPac],
                            FechaEmision = DateTime.Parse(campos[(int)Constants.IndiceCampos.FechaEmision]),
                            FechaCertificacionSat = DateTime.Parse(campos[(int)Constants.IndiceCampos.FechaCertificacionSat]),
                            Monto = decimal.Parse(campos[(int)Constants.IndiceCampos.Monto]),
                            EfectoComprobanteChar = char.Parse(campos[(int)Constants.IndiceCampos.EfectoComprobante]),
                            Estatus = campos[(int)Constants.IndiceCampos.Estatus] != "0" ? true : false,
                            FechaCancelacion = DateTime.TryParse(campos[(int)Constants.IndiceCampos.FechaCancelacion], out DateTime dateTime)
                                ? dateTime
                                : default(DateTime)
                        };

                        facturas.Add(factura);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }

                return facturas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal bool EscribirFacturasACsv(IEnumerable<Factura> facturas, string fileName)
        {
            try
            {                
                List<string> lineas = new List<string>() { Constants.CabeceraCsv };

                foreach (var factura in facturas)
                {
                    var linea = $"{factura.NombreEmisor}" +
                    $"~{factura.Monto}" +
                    $"~{factura.FechaEmision}" +
                    $"~{factura.RfcEmisor}" +
                    $"~" +
                    $"~{factura.Uuid}" +
                    $"~{factura.EfectoComprobante.ToString()}" +
                    $"~{factura.Estatus}";

                    lineas.Add(linea);
                }

                File.WriteAllLines(fileName, lineas);

                return true;
            }
            catch (Exception)
            {
                return false;                
            }
        }
    }
}
