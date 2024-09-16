using ClinicaApp.Dominio;

namespace ClinicaApp.InterfaceService
{
    public interface IClientService
    {
        Task<IEnumerable<Cliente>> GetClientsAsync();
        Task<Cliente> GetClientByIdAsync(int id);
        Task AddClientAsync(Cliente client);
        Task UpdateClientAsync(Cliente client);
        Task DeleteClientAsync(int id);
    }
}
