using Microsoft.AspNetCore.Identity;

namespace ClinicaApp.Dominio
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Medico { get; set; } = string.Empty;
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; } 
}
}
