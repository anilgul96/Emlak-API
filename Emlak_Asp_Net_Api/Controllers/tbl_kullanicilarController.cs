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
    public class tbl_kullanicilarController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public tbl_kullanicilarController(ApplicationDbContextApp context)
        {
            _context = context;
        }

        /// <summary>
        /// TÜM KULLANICILARI GETİRME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/tbl_kullanicilar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_kullanicilar>>> Gettbl_kullanicilar()
        {
          if (_context.tbl_kullanicilar == null)
          {
              return NotFound();
          }
            return await _context.tbl_kullanicilar.ToListAsync();
        }


        /// <summary>
        /// KULLANICI BULMA İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/tbl_kullanicilar/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_kullanicilar>> Gettbl_kullanicilar(int id)
        {
          if (_context.tbl_kullanicilar == null)
          {
              return NotFound();
          }
            var tbl_kullanicilar = await _context.tbl_kullanicilar.FindAsync(id);

            if (tbl_kullanicilar == null)
            {
                return NotFound();
            }

            return tbl_kullanicilar;
        }

        /// <summary>
        /// KULLANICI DÜZENLEME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT: api/tbl_kullanicilar/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_kullanicilar(int id, tbl_kullanicilar tbl_kullanicilar)
        {
            if (id != tbl_kullanicilar.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_kullanicilar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_kullanicilarExists(id))
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
        /// KULLANICI EKLEME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: api/tbl_kullanicilar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_kullanicilar>> Posttbl_kullanicilar(tbl_kullanicilar tbl_kullanicilar)
        {
          if (_context.tbl_kullanicilar == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.tbl_kullanicilar'  is null.");
          }
            _context.tbl_kullanicilar.Add(tbl_kullanicilar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_kullanicilar", new { id = tbl_kullanicilar.Id }, tbl_kullanicilar);
        }


        /// <summary>
        /// KULLANICI SİLME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/tbl_kullanicilar/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_kullanicilar(int id)
        {
            if (_context.tbl_kullanicilar == null)
            {
                return NotFound();
            }
            var tbl_kullanicilar = await _context.tbl_kullanicilar.FindAsync(id);
            if (tbl_kullanicilar == null)
            {
                return NotFound();
            }

            _context.tbl_kullanicilar.Remove(tbl_kullanicilar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_kullanicilarExists(int id)
        {
            return (_context.tbl_kullanicilar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
