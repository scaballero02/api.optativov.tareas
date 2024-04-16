using System.ComponentModel.DataAnnotations;

namespace Repository.Modelos
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public int IdBanco { get; set; }
        [Required(ErrorMessage = "El nombre es requerido.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe tener un mínimo de 3 caracteres.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe tener un mínimo de 3 caracteres.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El documento es requerido.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El apellido debe tener un mínimo de 3 caracteres.")]
        public string Documento { get; set; }
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El número de celular es obligatorio.")]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "El número de celular debe ser numérico y contener 10 dígitos.")]
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
    }
}
