using System.Globalization;
using Humanizer;
using Repository.Interfaces;
using Repository.Modelos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public partial class FacturaService
    {
        private readonly IFacturaRepository _facturaRepository;

        public FacturaService(IFacturaRepository facturaRepository)
        {
            _facturaRepository = facturaRepository;
        }

        public async Task<bool> Add(FacturaDTO factura)
        {
            try
            {
                factura.TotalIvaCinco = CalculateIva5(factura.Total);
                factura.TotalIvaDiez = CalculateIva10(factura.Total);
                factura.TotalIva = CalculateTotalIva(factura.Total);
                factura.TotalLetras = ConvertNumberToWords((int)factura.Total);
                return await _facturaRepository.Add(factura);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al agregar la factura", ex);
            }
        }

        public async Task<bool> Update(FacturaDTO factura)
        {
            try
            {
                factura.TotalIvaCinco = CalculateIva5(factura.Total);
                factura.TotalIvaDiez = CalculateIva10(factura.Total);
                factura.TotalIva = CalculateTotalIva(factura.Total);
                factura.TotalLetras = ConvertNumberToWords((int)factura.Total);
                return await _facturaRepository.Update(factura);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar la factura", ex);
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                return await _facturaRepository.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar la factura", ex);
            }
        }

        public async Task<FacturaDTO> Get(int id)
        {
            try
            {
                return await _facturaRepository.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la factura", ex);
            }
        }

        public async Task<IEnumerable<FacturaDTO>> List()
        {
            try
            {
                return await _facturaRepository.List();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar las facturas", ex);
            }
        }

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
