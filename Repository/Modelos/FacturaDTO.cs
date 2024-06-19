using System.ComponentModel.DataAnnotations;

namespace Repository.Modelos
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{6}$", ErrorMessage = "El número de factura debe ser numérico y contener 12 dígitos.")]
        public string NroFactura { get; set; }
        private DateTime _fechaHora;

        public DateTime FechaHora
        {
            get => _fechaHora;
            set => _fechaHora = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public decimal Total { get; set; }
        public decimal TotalIvaCinco { get; set; }
        public decimal TotalIvaDiez { get; set; }
        public decimal TotalIva { get; set; }
        public string TotalLetras { get; set; }
        public string Sucursal { get; set; }

    }
}