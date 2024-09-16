using ClinicaApp.Dominio;
using ClinicaApp.InterfaceService;
using ClinicaApp.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ConsultaService : IConsultaService
{
    private readonly IConsultaRepository _consultaRepository;
    private readonly IClientService _clientService;

    public ConsultaService(IConsultaRepository consultaRepository, IClientService clientService)
    {
        _consultaRepository = consultaRepository;
        _clientService = clientService; 
    }

    public async Task<Cliente> GetByIdClienteAsync(int id)
    {
        return await _consultaRepository.GetByIdClienteAsync(id);
    }

    public async Task<Consulta> GetByIdAsync(int id)
    {
        return await _consultaRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Consulta>> GetAllAsync()
    {
        return await _consultaRepository.GetAllAsync();
    }

    public async Task AddAsync(Consulta consulta)
    {
        // Aqui você pode adicionar lógica de validação ou transformação se necessário
        await _consultaRepository.AddAsync(consulta);
    }

    public async Task UpdateAsync(Consulta consulta)
    {
        // Aqui você pode adicionar lógica de validação ou transformação se necessário
        var existingConsulta = await _consultaRepository.GetByIdAsync(consulta.Id);
        if (existingConsulta == null)
        {
            throw new KeyNotFoundException("Consulta not found.");
        }

        await _consultaRepository.UpdateAsync(consulta);
    }

    public async Task DeleteAsync(int id)
    {
        var consulta = await _consultaRepository.GetByIdAsync(id);
        if (consulta == null)
        {
            throw new KeyNotFoundException("Consulta not found.");
        }

        await _consultaRepository.DeleteAsync(id);
    }
}
