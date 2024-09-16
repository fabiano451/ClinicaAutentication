using ClinicaApp.Context;
using ClinicaApp.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ConsultaRepository : IConsultaRepository
{
    private readonly ApplicationDbContext _context;

    public ConsultaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Cliente> GetByIdClienteAsync(int id)
    {
        var result = await _context.Clients
            .Include(c => c.Consultas)  // Inclui o cliente associado
            .FirstOrDefaultAsync(c => c.Id == id);

        return result;
    }

    public async Task<Consulta> GetByIdAsync(int id)
    {

        var result = await _context.Consultas
            .Include(c => c.Cliente)  // Inclui o cliente associado
            .FirstOrDefaultAsync(c => c.Id == id);

        return result;
    }

    public async Task<IEnumerable<Consulta>> GetAllAsync()
    {
        return await _context.Consultas
            .Include(c => c.Cliente)  // Inclui o cliente associado
            .ToListAsync();
    }

    public async Task AddAsync(Consulta consulta)
    {
        await _context.Consultas.AddAsync(consulta);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Consulta consulta)
    {
        _context.Consultas.Update(consulta);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var consulta = await _context.Consultas.FindAsync(id);
        if (consulta != null)
        {
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
        }
    }
}
