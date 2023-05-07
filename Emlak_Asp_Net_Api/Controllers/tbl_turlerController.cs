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
    public class tbl_turlerController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public tbl_turlerController(ApplicationDbContextApp context)
        {
            _context = context;
        }


        /// <summary>
        /// TÜM TÜRLERİ ALMA İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/tbl_turler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_turler>>> Gettbl_turler()
        {
          if (_context.tbl_turler == null)
          {
              return NotFound();
          }
            return await _context.tbl_turler.ToListAsync();
        }


        /// <summary>
        /// TÜR BULMA İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/tbl_turler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_turler>> Gettbl_turler(int id)
        {
          if (_context.tbl_turler == null)
          {
              return NotFound();
          }
            var tbl_turler = await _context.tbl_turler.FindAsync(id);

            if (tbl_turler == null)
            {
                return NotFound();
            }

            return tbl_turler;
        }


        /// <summary>
        /// İLAN DÜZENLEME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT: api/tbl_turler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_turler(int id, tbl_turler tbl_turler)
        {
            if (id != tbl_turler.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_turler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_turlerExists(id))
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


        /// <summary>
        /// TÜR EKLEME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: api/tbl_turler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_turler>> Posttbl_turler(tbl_turler tbl_turler)
        {
          if (_context.tbl_turler == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.tbl_turler'  is null.");
          }
            _context.tbl_turler.Add(tbl_turler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_turler", new { id = tbl_turler.Id }, tbl_turler);
        }


        /// <summary>
        /// TÜR SİLME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/tbl_turler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_turler(int id)
        {
            if (_context.tbl_turler == null)
            {
                return NotFound();
            }
            var tbl_turler = await _context.tbl_turler.FindAsync(id);
            if (tbl_turler == null)
            {
                return NotFound();
            }

            _context.tbl_turler.Remove(tbl_turler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_turlerExists(int id)
        {
            return (_context.tbl_turler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
