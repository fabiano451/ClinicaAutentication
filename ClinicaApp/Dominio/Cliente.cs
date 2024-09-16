namespace ClinicaApp.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Name { get; set; }= string.Empty;
        public List<Consulta>? Consultas { get; set; }
    }
}
