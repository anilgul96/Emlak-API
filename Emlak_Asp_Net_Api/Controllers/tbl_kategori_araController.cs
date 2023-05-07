using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Emlak_Asp_Net_Api.Data;
using Emlak_Asp_Net_Api.Models;

namespace Emlak_Asp_Net_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tbl_kategori_araController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public tbl_kategori_araController(ApplicationDbContextApp context)
        {
            _context = context;
        }

        // GET: api/tbl_kategori_ara
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_kategori_ara>>> Gettbl_kategori_ara()
        {
          if (_context.tbl_kategori_ara == null)
          {
              return NotFound();
          }
            return await _context.tbl_kategori_ara.ToListAsync();
        }

        // GET: api/tbl_kategori_ara/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_kategori_ara>> Gettbl_kategori_ara(int id)
        {
          if (_context.tbl_kategori_ara == null)
          {
              return NotFound();
          }
            var tbl_kategori_ara = await _context.tbl_kategori_ara.FindAsync(id);

            if (tbl_kategori_ara == null)
            {
                return NotFound();
            }

            return tbl_kategori_ara;
        }

        // PUT: api/tbl_kategori_ara/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_kategori_ara(int id, tbl_kategori_ara tbl_kategori_ara)
        {
            if (id != tbl_kategori_ara.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_kategori_ara).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_kategori_araExists(id))
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

        // POST: api/tbl_kategori_ara
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_kategori_ara>> Posttbl_kategori_ara(tbl_kategori_ara tbl_kategori_ara)
        {
          if (_context.tbl_kategori_ara == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.tbl_kategori_ara'  is null.");
          }
            _context.tbl_kategori_ara.Add(tbl_kategori_ara);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_kategori_ara", new { id = tbl_kategori_ara.Id }, tbl_kategori_ara);
        }

        // DELETE: api/tbl_kategori_ara/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_kategori_ara(int id)
        {
            if (_context.tbl_kategori_ara == null)
            {
                return NotFound();
            }
            var tbl_kategori_ara = await _context.tbl_kategori_ara.FindAsync(id);
            if (tbl_kategori_ara == null)
            {
                return NotFound();
            }

            _context.tbl_kategori_ara.Remove(tbl_kategori_ara);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_kategori_araExists(int id)
        {
            return (_context.tbl_kategori_ara?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
