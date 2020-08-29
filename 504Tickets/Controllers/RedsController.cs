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
    public class RedsController : ControllerBase
    {
        private readonly TicketDataContext _context;

        public RedsController(TicketDataContext context)
        {
            _context = context;
        }

        // GET: api/Reds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Red>>> GetRedes()
        {
            return await _context.Redes.ToListAsync();
        }

        // GET: api/Reds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Red>> GetRed(int id)
        {
            var red = await _context.Redes.FindAsync(id);

            if (red == null)
            {
                return NotFound();
            }

            return red;
        }

        // PUT: api/Reds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRed(int id, Red red)
        {
            if (id != red.Id)
            {
                return BadRequest();
            }
            else if (red.Nombre == null || red.Nombre.Length <= 0)
            {
                return NotFound("Se debe de ingresar el nombre de la red");
            }
            if (red.Link == null || red.Link.Length <= 0)
            {
                return NotFound("Se debe de ingresar el link de la red");
            }

            bool isUri = Uri.IsWellFormedUriString(red.Link, UriKind.RelativeOrAbsolute);
            if (isUri == false)
            {
                return NotFound("Se debe de ingresar un link valido");
            }
            else
            {
                _context.Entry(red).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }

            
        }

        // POST: api/Reds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Red>> PostRed(Red red)
        {

            if (red.Nombre == null || red.Nombre.Length <= 0)
            {
                return NotFound("Se debe de ingresar el nombre de la red");
            }
            if (red.Link == null || red.Link.Length <= 0)
            {
                return NotFound("Se debe de ingresar el link de la red");
            }

           bool isUri = Uri.IsWellFormedUriString(red.Link, UriKind.RelativeOrAbsolute);
            if (isUri == false)
            {
                return NotFound("Se debe de ingresar un link valido");
            }

            _context.Redes.Add(red);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRed", new { id = red.Id }, red);
        }

        // DELETE: api/Reds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Red>> DeleteRed(int id)
        {
            var red = await _context.Redes.FindAsync(id);
            if (red == null)
            {
                return NotFound();
            }

            _context.Redes.Remove(red);
            await _context.SaveChangesAsync();

            return red;
        }
    }
}
