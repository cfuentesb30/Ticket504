﻿using System;
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
    public class VerificadorEventosController : ControllerBase
    {
        private readonly TicketDataContext _context;

        public VerificadorEventosController(TicketDataContext context)
        {
            _context = context;
        }

        // GET: api/VerificadorEventos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VerificadorEvento>>> GetVerificadoresEventos()
        {
            return await _context.VerificadoresEventos.Include(q => q.Eventos).Include(q => q.Verificadores).ToListAsync();
        }

        // GET: api/VerificadorEventos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VerificadorEvento>> GetVerificadorEvento(int id)
        {
            var verificadorEvento = await _context.VerificadoresEventos.Include(q => q.Eventos).Include(q => q.Verificadores).FirstOrDefaultAsync(q => q.Id == id);

            if (verificadorEvento == null)
            {
                return NotFound();
            }

            return verificadorEvento;
        }

        // PUT: api/VerificadorEventos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVerificadorEvento(int id, VerificadorEvento verificadorEvento)
        {
            if (id != verificadorEvento.Id)
            {
                return BadRequest();
            }

            Verificador verificador = await _context.Verificadores.FirstOrDefaultAsync(q => q.Id == verificadorEvento.IdVerificador);
            Evento evento = await _context.Eventos.FirstOrDefaultAsync(q => q.Id == verificadorEvento.IdEvento);
            if (verificadorEvento.IdEvento.ToString().Length < 1 || verificadorEvento.IdVerificador.ToString().Length < 1)
            {
                return NotFound("el Id del evento y el Id del verificador no pueden estar vacios");
            }
            if (verificador == null)
            {
                return NotFound("El id del verificador ingresado no coincide con ningun verificador existente");
            }
            else if (evento == null)
            {
                return NotFound("El id del evento ingresado no coincide con ningun evento creado");
            }
            else
            {
                _context.Entry(verificadorEvento).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VerificadorEventoExists(id))
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

        // POST: api/VerificadorEventos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VerificadorEvento>> PostVerificadorEvento(VerificadorEvento verificadorEvento)
        {
            Verificador verificador = await _context.Verificadores.FirstOrDefaultAsync(q => q.Id == verificadorEvento.IdVerificador);
            Evento evento = await _context.Eventos.FirstOrDefaultAsync(q => q.Id == verificadorEvento.IdEvento);
            if(verificadorEvento.IdEvento.ToString().Length < 1 || verificadorEvento.IdVerificador.ToString().Length < 1)
            {
                return NotFound("el Id del evento y el Id del verificador no pueden estar vacios");
            }
            if(verificador == null)
            {
                return NotFound("El id del verificador ingresado no coincide con ningun verificador existente");
            }
            else if(evento == null)
            {
                return NotFound("El id del evento ingresado no coincide con ningun evento creado");
            }
            else
            {
                _context.VerificadoresEventos.Add(verificadorEvento);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetVerificadorEvento", new { id = verificadorEvento.Id }, verificadorEvento);
            }

        }

        // DELETE: api/VerificadorEventos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VerificadorEvento>> DeleteVerificadorEvento(int id)
        {
            var verificadorEvento = await _context.VerificadoresEventos.FindAsync(id);
            if (verificadorEvento == null)
            {
                return NotFound();
            }

            _context.VerificadoresEventos.Remove(verificadorEvento);
            await _context.SaveChangesAsync();

            return verificadorEvento;
        }

        private bool VerificadorEventoExists(int id)
        {
            return _context.VerificadoresEventos.Any(e => e.Id == id);
        }
    }
}
