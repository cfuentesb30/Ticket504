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
    public class TicketsController : ControllerBase
    {
        private readonly TicketDataContext _context;

        public TicketsController(TicketDataContext context)
        {
            _context = context;
        }

        // GET: api/Tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            return await _context.Tickets.Include(q => q.Categorias).Include(q => q.Usuarios).ToListAsync();
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Tickets.Include(q => q.Categorias).Include(q => q.Usuarios).FirstOrDefaultAsync(q => q.Id==id);

            if (ticket == null)
            {
                return NotFound();
            }

            return ticket;
        }

        // PUT: api/Tickets/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicket(int id, Ticket ticket)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(q => q.Id == ticket.UsuarioId);
            Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(q => q.Id == ticket.IdCategoria);

            ticket.HoraFechaGenerado = DateTime.Today;
            ticket.Status = false; //El boleto no fue escaneado

            if (id != ticket.Id)
            {
                return BadRequest();
            }
            else if (usuario == null)
            {
                return NotFound("Debe de ingresar un Id de Usuario valido");
            }
            if (categoria == null)
            {
                return NotFound("Debe de ingresar un Id de Categoria valido");
            }
            
            else
            {
                _context.Entry(ticket).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }

           
        }

        // POST: api/Tickets
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ticket>> PostTicket(Ticket ticket)
        {
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(q => q.Id==ticket.UsuarioId);
            Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(q => q.Id == ticket.IdCategoria);

            ticket.HoraFechaGenerado = DateTime.Today;
            if (usuario==null)
            {
                return NotFound("Debe de ingresar un Id de Usuario valido");
            }
            if (categoria==null)
            {
                return NotFound("Debe de ingresar un Id de Categoria valido");
            }
            ticket.Status = false; //El boleto no fue escaneado
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTicket", new { id = ticket.Id }, ticket);
        }

        // DELETE: api/Tickets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ticket>> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }
    }
}
