using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EProducts.Data;
using EProducts.Model;

namespace EProducts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductssesController : ControllerBase
    {
        private readonly EProductsContext _context;

        public ProductssesController(EProductsContext context)
        {
            _context = context;
        }

        // GET: api/Productsses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productss>>> GetProductss()
        {
          if (_context.Productss == null)
          {
              return NotFound();
          }
            return await _context.Productss.ToListAsync();
        }

        // GET: api/Productsses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Productss>> GetProductss(int id)
        {
          if (_context.Productss == null)
          {
              return NotFound();
          }
            var productss = await _context.Productss.FindAsync(id);

            if (productss == null)
            {
                return NotFound();
            }

            return productss;
        }

        // PUT: api/Productsses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductss(int id, Productss productss)
        {
            if (id != productss.id)
            {
                return BadRequest();
            }

            _context.Entry(productss).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductssExists(id))
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

        // POST: api/Productsses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Productss>> PostProductss(Productss productss)
        {
          if (_context.Productss == null)
          {
              return Problem("Entity set 'EProductsContext.Productss'  is null.");
          }
            _context.Productss.Add(productss);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductss", new { id = productss.id }, productss);
        }

        // DELETE: api/Productsses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductss(int id)
        {
            if (_context.Productss == null)
            {
                return NotFound();
            }
            var productss = await _context.Productss.FindAsync(id);
            if (productss == null)
            {
                return NotFound();
            }

            _context.Productss.Remove(productss);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductssExists(int id)
        {
            return (_context.Productss?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
