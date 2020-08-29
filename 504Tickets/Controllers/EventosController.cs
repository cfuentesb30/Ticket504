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
    public class EventosController : ControllerBase
    {
        private readonly TicketDataContext _context;

        public EventosController(TicketDataContext context)
        {
            _context = context;
        }

        // GET: api/Eventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            return await _context.Eventos.Include(q => q.Proveedor).Include(q => q.Categoria).Include(q => q.VerificadoresEventos).ToListAsync();
        }

        // GET: api/Eventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            var evento = await _context.Eventos.Include(q => q.Proveedor).Include(q => q.Categoria).Include(q => q.VerificadoresEventos).FirstOrDefaultAsync(q => q.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        // PUT: api/Eventos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, Evento evento)
        {
            evento.FechaCreacion = DateTime.Today;
            if (id != evento.Id)
            {
                return BadRequest();
            }
            else if(evento.Nombre.Length < 1 || evento.Ilustracion.Length < 1 || evento.CiudadEvento.Length < 1 || evento.DireccionEvento.Length < 1 || evento.Descripcion.Length < 1 || evento.Fecha.ToString().Length < 1 || evento.IdProveedor.ToString().Length < 1 || evento.IdCategoria.ToString().Length < 1)
            {
                return NotFound("Todos los campos deben ser completados");
            }
            else if (evento.Fecha <= evento.FechaCreacion)
            {
                return NotFound("La fecha ingresada es una fecha no valida");
            }
            else
            {
                _context.Entry(evento).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(id))
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

        // POST: api/Eventos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Evento>> PostEvento(Evento evento)
        {            
            evento.FechaCreacion = DateTime.Today;
            if (evento.Nombre.Length <1 || evento.Ilustracion.Length <1 || evento.CiudadEvento.Length <1 || evento.DireccionEvento.Length < 1 || evento.Descripcion.Length < 1 || evento.Fecha.ToString().Length <1 || evento.IdProveedor.ToString().Length < 1 || evento.IdCategoria.ToString().Length < 1)
            {
                return NotFound("Todos los campos deben ser completados");
            }
            else if(evento.Fecha <= evento.FechaCreacion)
            {
                return NotFound("La fecha ingresada es una fecha no valida");
            }
            else
            {
                _context.Eventos.Add(evento);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetEvento", new { id = evento.Id }, evento);
            }
            
        }

        // DELETE: api/Eventos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evento>> DeleteEvento(int id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            await _context.SaveChangesAsync();

            return evento;
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.Id == id);
        }
    }
}
