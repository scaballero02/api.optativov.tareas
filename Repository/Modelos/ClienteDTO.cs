namespace Repository.Modelos
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public int IdBanco { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Estado { get; set; }
    }
}