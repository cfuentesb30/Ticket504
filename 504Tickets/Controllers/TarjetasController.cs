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
    public class TarjetasController : ControllerBase
    {
        private readonly TicketDataContext _context;

        public TarjetasController(TicketDataContext context)
        {
            _context = context;
        }

        // GET: api/Tarjetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarjeta>>> GetTarjetas()
        {
            return await _context.Tarjetas.Include(q => q.Usuarios).ToListAsync();
        }

        // GET: api/Tarjetas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarjeta>> GetTarjeta(int id)
        {
            var tarjeta = await _context.Tarjetas.Include(q => q.Usuarios).FirstOrDefaultAsync(q => q.Id ==id);

            if (tarjeta == null)
            {
                return NotFound();
            }

            return tarjeta;
        }

        // PUT: api/Tarjetas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTarjeta(int id, Tarjeta tarjeta)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(q => q.Id == tarjeta.IdUsuario);
            if (id != tarjeta.Id)
            {
                return BadRequest();
            }

            else if (tarjeta.NumTarjeta.ToString().Length < 1 || tarjeta.CardHolder.Length < 1 || tarjeta.YearExp.ToString().Length < 1 || tarjeta.MonthExp.ToString().Length < 1 || tarjeta.CodigoCVV.ToString().Length < 1 || tarjeta.IdUsuario.ToString().Length < 1)
            {
                return NotFound("Todos los datos de la tarjeta correspondientes a la tarjeta deben de ser ingresados");
            }

            else if (usuario == null)
            {
                return NotFound("El id de usuario ingresado no coincide con ningun usuario existente");
            }
            else
            {
                _context.Entry(tarjeta).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarjetaExists(id))
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

            

        // POST: api/Tarjetas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tarjeta>> PostTarjeta(Tarjeta tarjeta)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(q => q.Id == tarjeta.IdUsuario);
            if (tarjeta.NumTarjeta.ToString().Length <1 || tarjeta.CardHolder.Length <1 || tarjeta.YearExp.ToString().Length <1 || tarjeta.MonthExp.ToString().Length <1 || tarjeta.CodigoCVV.ToString().Length <1 || tarjeta.IdUsuario.ToString().Length <1)
            {
                return NotFound("Todos los datos de la tarjeta correspondientes a la tarjeta deben de ser ingresados");
            }
            else if(usuario == null)
            {
                return NotFound("El id de usuario ingresado no coincide con ningun usuario existente");
            }
            else
            {
                _context.Tarjetas.Add(tarjeta);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTarjeta", new { id = tarjeta.Id }, tarjeta);
            }
            
        }

        // DELETE: api/Tarjetas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tarjeta>> DeleteTarjeta(int id)
        {
            var tarjeta = await _context.Tarjetas.FindAsync(id);
            if (tarjeta == null)
            {
                return NotFound();
            }

            _context.Tarjetas.Remove(tarjeta);
            await _context.SaveChangesAsync();

            return tarjeta;
        }

        private bool TarjetaExists(int id)
        {
            return _context.Tarjetas.Any(e => e.Id == id);
        }
    }
}
