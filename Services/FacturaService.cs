using System.Globalization;
using System.Text.RegularExpressions;
using Humanizer;
using Repository.Interfaces;
using Repository.Modelos;

namespace Services
{
    public partial class FacturaService
    {

        private readonly IFacturaRepository _facturaRepository;
        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }
        public bool add(FacturaDTO factura)
        {
            try
            {
                factura.TotalIvaCinco = CalculateIva5(factura.Total);
                factura.TotalIvaDiez = CalculateIva10(factura.Total);
                factura.TotalIva = CalculateTotalIva(factura.Total);
                factura.TotalLetras = ConvertNumberToWords((int)factura.Total);
                if (_facturaRepository.Add(factura))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool update(FacturaDTO factura)
        {
            try
            {
                factura.TotalIvaCinco = CalculateIva5(factura.Total);
                factura.TotalIvaDiez = CalculateIva10(factura.Total);
                factura.TotalIva = CalculateTotalIva(factura.Total);
                if (_facturaRepository.Update(factura))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool remove(int id)
        {
            try
            {
                if (_facturaRepository.Remove(id))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public FacturaDTO get(int id)
        {
            try
            {
                return _facturaRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEnumerable<FacturaDTO> list()
        {
            try
            {
                return _facturaRepository.List();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string FormatInvoiceNumber(string invoiceNumber) 
            => $"{invoiceNumber[..3]}-{invoiceNumber.Substring(3, 3)}-{invoiceNumber.Substring(6, 6)}";

        public static decimal CalculateIva5(decimal amount) 
            => amount * 0.05m; // 5% de IVA
        
        public static decimal CalculateIva10(decimal amount) 
            => amount * 0.10m; // 10% de IVA
        

        public static decimal CalculateTotalIva(decimal amount)
        {
            decimal iva5 = CalculateIva5(amount);
            decimal iva10 = CalculateIva10(amount);
            return iva5 + iva10;
        }

        public static string ConvertNumberToWords(int number) 
            => number.ToWords(new CultureInfo("es"));
        
    }
}
