using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _504Tickets.DataContext;
using _504Tickets.Models;

namespace _504Tickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificadorsController : ControllerBase
    {
        private readonly TicketDataContext _context;

        public VerificadorsController(TicketDataContext context)
        {
            _context = context;
        }

        // GET: api/Verificadors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Verificador>>> GetVerificadores()
        {
            return await _context.Verificadores.ToListAsync();
        }

        // GET: api/Verificadors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Verificador>> GetVerificador(int id)
        {
            var verificador = await _context.Verificadores.FindAsync(id);

            if (verificador == null)
            {
                return NotFound();
            }

            return verificador;
        }

        // PUT: api/Verificadors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVerificador(int id, Verificador verificador)
        {
            if (id != verificador.Id)
            {
                return BadRequest();
            }
            if(verificador.Nombre.Length < 1 || verificador.Apellido.Length < 1 || verificador.Correo.Length < 1 || verificador.Password.Length < 1)
            {
                return NotFound("Los campos de nombre, apellido, correo y contraseña no pueden estar vacios");
            }
            else
            {
                _context.Entry(verificador).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerificadorExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }
            
        }

        // POST: api/Verificadors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Verificador>> PostVerificador(Verificador verificador)
        {
            if(verificador.Nombre.Length<1 || verificador.Apellido.Length<1 || verificador.Correo.Length<1 || verificador.Password.Length<1)
            {
                return NotFound("Los campos de nombre, apellido, correo y contraseña no pueden estar vacios");
            }
            else
            {
                _context.Verificadores.Add(verificador);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetVerificador", new { id = verificador.Id }, verificador);
            }            
            
        }

        // DELETE: api/Verificadors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Verificador>> DeleteVerificador(int id)
        {
            var verificador = await _context.Verificadores.FindAsync(id);
            if (verificador == null)
            {
                return NotFound();
            }

            _context.Verificadores.Remove(verificador);
            await _context.SaveChangesAsync();

            return verificador;
        }

        private bool VerificadorExists(int id)
        {
            return _context.Verificadores.Any(e => e.Id == id);
        }
    }
}
