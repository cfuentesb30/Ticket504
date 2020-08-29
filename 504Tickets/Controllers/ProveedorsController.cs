using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _504Tickets.DataContext;
using _504Tickets.Models;
using System.Text.RegularExpressions;

namespace _504Tickets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorsController : ControllerBase
    {
        private readonly TicketDataContext _context;

        public ProveedorsController(TicketDataContext context)
        {
            _context = context;
        }

        // GET: api/Proveedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores()
        {
            return await _context.Proveedores.Include(q => q.Eventos).ToListAsync();
        }

        // GET: api/Proveedors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(int id)
        {
            var proveedor = await _context.Proveedores.Include(q => q.Eventos).FirstOrDefaultAsync(q => q.Id==id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        // PUT: api/Proveedors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest();
            }
            else if (proveedor.Nombre.Length <= 0 || proveedor.Nombre == null)
            {
                return NotFound("Debe de ingresar el nombre del Proveedor");
            }
            if (proveedor.NombreEmpresa.Length <= 0 || proveedor.NombreEmpresa == null)
            {
                return NotFound("Debe de ingresar el nombre de la empresa");
            }
            if (proveedor.RTN.ToString().Length <= 0 || proveedor.RTN <= 0)
            {
                return NotFound("Debe de ingresar el RTN");
            }
            if (proveedor.Correo.Length <= 0 || proveedor.Correo == null)
            {
                return NotFound("Debe de ingresar el correo");
            }
            if (proveedor.Password.Length <= 0 || proveedor.Password == null)
            {
                return NotFound("Debe de ingresar una contraseña");
            }
            if (proveedor.Logo.Length <= 0 || proveedor.Logo == null)
            {
                return NotFound("Debe de ingresar una imagen del proveedor");
            }
            if (proveedor.Telefono.ToString().Length <= 0 || proveedor.Telefono <= 0)
            {
                return NotFound("Debe de ingresar el telefono");
            }
            else
            {
                _context.Entry(proveedor).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return NoContent();
            }

           
        }

        // POST: api/Proveedors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {

            if (proveedor.Nombre.Length <= 0 || proveedor.Nombre == null)
            {
                return NotFound("Debe de ingresar el nombre del Proveedor");
            }
            if (proveedor.NombreEmpresa.Length <= 0 || proveedor.NombreEmpresa == null)
            {
                return NotFound("Debe de ingresar el nombre de la empresa");
            }
            if (proveedor.RTN.ToString().Length <= 0 || proveedor.RTN <= 0)
            {
                return NotFound("Debe de ingresar el RTN");
            }
            if (proveedor.Correo.Length <= 0 || proveedor.Correo == null)
            {
                return NotFound("Debe de ingresar el correo");
            }
            if (proveedor.Password.Length <= 0 || proveedor.Password == null)
            {
                return NotFound("Debe de ingresar una contraseña");
            }
            if (proveedor.Logo.Length <= 0 || proveedor.Logo == null)
            {
                return NotFound("Debe de ingresar una imagen del proveedor");
            }
            if (proveedor.Telefono.ToString().Length <= 0 || proveedor.Telefono <= 0)
            {
                return NotFound("Debe de ingresar el telefono");
            }
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedor", new { id = proveedor.Id }, proveedor);
        }

        // DELETE: api/Proveedors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Proveedor>> DeleteProveedor(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return proveedor;
        }
    }
}
