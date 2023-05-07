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
    public class tbl_ilanlarController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public tbl_ilanlarController(ApplicationDbContextApp context)
        {
            _context = context;
        }


        /// <summary>
        /// TÜM İLANLARI GETİRME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/tbl_ilanlar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_ilanlar>>> Gettbl_ilanlar()
        {
          if (_context.tbl_ilanlar == null)
          {
              return NotFound();
          }
            return await _context.tbl_ilanlar.ToListAsync();
        }


        /// <summary>
        /// İLAN BULMA İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/tbl_ilanlar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_ilanlar>> Gettbl_ilanlar(int id)
        {
          if (_context.tbl_ilanlar == null)
          {
              return NotFound();
          }
            var tbl_ilanlar = await _context.tbl_ilanlar.FindAsync(id);

            if (tbl_ilanlar == null)
            {
                return NotFound();
            }

            return tbl_ilanlar;
        }

        /// <summary>
        /// İLAN DÜZENLEME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT: api/tbl_ilanlar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_ilanlar(int id, tbl_ilanlar tbl_ilanlar)
        {
            if (id != tbl_ilanlar.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_ilanlar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_ilanlarExists(id))
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
        /// İLAN EKLEME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: api/tbl_ilanlar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_ilanlar>> Posttbl_ilanlar(tbl_ilanlar tbl_ilanlar)
        {
          if (_context.tbl_ilanlar == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.tbl_ilanlar'  is null.");
          }
            _context.tbl_ilanlar.Add(tbl_ilanlar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_ilanlar", new { id = tbl_ilanlar.Id }, tbl_ilanlar);
        }


        /// <summary>
        /// İLAN SİLME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/tbl_ilanlar/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_ilanlar(int id)
        {
            if (_context.tbl_ilanlar == null)
            {
                return NotFound();
            }
            var tbl_ilanlar = await _context.tbl_ilanlar.FindAsync(id);
            if (tbl_ilanlar == null)
            {
                return NotFound();
            }

            _context.tbl_ilanlar.Remove(tbl_ilanlar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_ilanlarExists(int id)
        {
            return (_context.tbl_ilanlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
