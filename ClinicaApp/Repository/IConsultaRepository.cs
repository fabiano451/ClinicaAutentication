using ClinicaApp.Dominio;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IConsultaRepository
{
    Task<Consulta> GetByIdAsync(int id);
    Task<IEnumerable<Consulta>> GetAllAsync();
    Task AddAsync(Consulta consulta);
    Task UpdateAsync(Consulta consulta);
    Task DeleteAsync(int id);
    Task<Cliente> GetByIdClienteAsync(int id);
}
