namespace  SharedProject.DTOs
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public int DatosGeneralesId { get; set; }
        public int? RolId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Estado { get; set; }

    }
}
