using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _504Tickets.DataContext;
using _504Tickets.Models;
using System.Security.AccessControl;

namespace _504Tickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritosController : ControllerBase
    {
        private readonly TicketDataContext _context;

        public CarritosController(TicketDataContext context)
        {
            _context = context;
        }

        // GET: api/Carritos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrito>>> GetCarritos()
        {
            return await _context.Carritos.Include(q => q.Categorias).Include(e => e.Usuarios).ToListAsync();
        }

        // GET: api/Carritos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrito>> GetCarrito(int id)
        {
            var carrito = await _context.Carritos.Include(q => q.Categorias).Include(e => e.Usuarios).FirstOrDefaultAsync(q=>q.Id == id);
           
            if (carrito == null)
            {
                return NotFound();
            }
            

            return carrito;
        }

        // PUT: api/Carritos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrito(int id, Carrito carrito)
        {
            Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(q => q.Id == carrito.IdCategoria);
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(e => e.Id == carrito.IdUsuario);
            if (id != carrito.Id)
            {
                return BadRequest();
            }
            else if (categoria == null)
            {
                return NotFound("La Categoria No Existe");
            }
            else if (usuario == null)
            {
                return NotFound("El Usuario No Existe");
            }

            _context.Entry(carrito).State = EntityState.Modified;

            
                await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Carritos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Carrito>> PostCarrito(Carrito carrito)
        {
            Categoria categoria = await _context.Categorias.FirstOrDefaultAsync(q => q.Id == carrito.IdCategoria);
            Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(e => e.Id == carrito.IdUsuario);
             if (categoria == null)
            {
                return NotFound("La Categoria no existe");
            }
             else if (usuario == null)
            {
                return NotFound("El Usuario no Existe");
            }
            _context.Carritos.Add(carrito);
            await _context.SaveChangesAsync();


            return CreatedAtAction("GetCarrito", new { id = carrito.Id }, carrito);
        }

        // DELETE: api/Carritos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Carrito>> DeleteCarrito(int id)
        {
            var carrito = await _context.Carritos.FindAsync(id);
            if (carrito == null)
            {
                return NotFound();
            }

            _context.Carritos.Remove(carrito);
            await _context.SaveChangesAsync();

            return carrito;
        }

       /* private bool CarritoExists(int id)
        {
            return _context.Carritos.Any(e => e.Id == id);
        }*/
    }
}
