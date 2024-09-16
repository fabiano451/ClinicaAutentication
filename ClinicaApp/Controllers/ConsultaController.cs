using ClinicaApp.Dominio;
using ClinicaApp.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
//[Authorize]
public class ConsultaController : ControllerBase
{
    private readonly IConsultaService _consultaService;

    public ConsultaController(IConsultaService consultaService)
    {
        _consultaService = consultaService;
    }

    // GET: api/consulta/{id}
    [HttpGet("{id}")]
    [Produces("application/json")]
    // [Authorize]
    public async Task<ActionResult<Consulta>>  GetById(int id)
    {
        var consulta = await _consultaService.GetByIdAsync(id);
        if (consulta == null)
        {
            return NotFound();
        }
        return Ok(consulta);
    }

    // GET: api/consulta
    [HttpGet]
    //[Authorize]
    public async Task<ActionResult<IEnumerable<Consulta>>> GetAll()
    {
        var consultas = await _consultaService.GetAllAsync();
        return Ok(consultas);
    }

    // POST: api/consulta
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] Consulta consulta)
    {
        if (consulta == null)
        {
            return BadRequest("Consulta cannot be null.");
        }

        await _consultaService.AddAsync(consulta);
        return CreatedAtAction(nameof(GetById), new { id = consulta.Id }, consulta);
    }

    // PUT: api/consulta/{id}
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] Consulta consulta)
    {
        if (id != consulta.Id)
        {
            return BadRequest("Consulta ID mismatch.");
        }

        try
        {
            await _consultaService.UpdateAsync(consulta);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/consulta/{id}
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _consultaService.DeleteAsync(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
