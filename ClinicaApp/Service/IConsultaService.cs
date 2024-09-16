using ClinicaApp.Dominio;

namespace ClinicaApp.Service
{
    public interface IConsultaService
    {
        Task<Consulta> GetByIdAsync(int id);
        Task<IEnumerable<Consulta>> GetAllAsync();
        Task AddAsync(Consulta consulta);
        Task UpdateAsync(Consulta consulta);
        Task DeleteAsync(int id);
        Task<Cliente> GetByIdClienteAsync(int id);
    }
}
