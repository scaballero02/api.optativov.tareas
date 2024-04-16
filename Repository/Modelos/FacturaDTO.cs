using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Repository.Modelos
{
    public class FacturaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El id de cliente es es obligatorio.")]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "El número de factura es obligatorio.")]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "El número de factura debe ser numérico y contener 12 dígitos.")]
        public string NroFactura { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal Total { get; set; }

        [JsonIgnore]
        public decimal TotalIvaCinco { get; set; }
        [JsonIgnore]
        public decimal TotalIvaDiez { get; set; }
        [JsonIgnore]
        public decimal TotalIva { get; set; }
        
        public string TotalLetras { get; set; }
        public string Sucursal { get; set; }
    }
}
