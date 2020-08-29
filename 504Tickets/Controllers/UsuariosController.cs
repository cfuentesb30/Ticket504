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
    public class UsuariosController : ControllerBase
    {
        private readonly TicketDataContext _context;

        public UsuariosController(TicketDataContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.Include(q=>q.Tarjetas).Include(w=>w.Carritos).Include(e=>e.Tickets).ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.Include(q => q.Tarjetas).Include(w => w.Carritos).Include(e => e.Tickets).FirstOrDefaultAsync(q => q.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }
            DateTime hora = DateTime.Today;
            usuario.Status = true;
            if (usuario.Nombre.Length < 1 || usuario.Apellido.Length < 1 || usuario.Correo.Length < 1 || usuario.Password.Length < 1 || usuario.FechaNacimiento.ToString().Length < 1 || usuario.Foto.Length < 1 || usuario.Telefono.ToString().Length < 1)
            {
                return NotFound("Se debe ingresar la informacion de todos los campos");
            }
            else if (usuario.FechaNacimiento < hora)
            {
                return NotFound("La fecha de nacimiento ingresada no es una fecha valida");
            }
            else
            {
                _context.Entry(usuario).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            DateTime hora = DateTime.Today;
            usuario.Status = true;
            if (usuario.Nombre.Length <1 || usuario.Apellido.Length <1 || usuario.Correo.Length <1 || usuario.Password.Length <1 || usuario.FechaNacimiento.ToString().Length <1 || usuario.Foto.Length < 1 || usuario.Telefono.ToString().Length <1)
            {
                return NotFound("Se debe ingresar la informacion de todos los campos");
            }
            else if (usuario.FechaNacimiento < hora)
            {
                return NotFound("La fecha de nacimiento ingresada no es una fecha valida");
            }
            else
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
            }            
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
