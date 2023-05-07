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
    public class tbl_kategorilerController : ControllerBase
    {
        private readonly ApplicationDbContextApp _context;

        public tbl_kategorilerController(ApplicationDbContextApp context)
        {
            _context = context;
        }


        /// <summary>
        /// TÜM KATEGORİLERİ GETİRME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/tbl_kategoriler
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tbl_kategoriler>>> Gettbl_kategoriler()
        {
          if (_context.tbl_kategoriler == null)
          {
              return NotFound();
          }
            return await _context.tbl_kategoriler.ToListAsync();
        }

        /// <summary>
        /// KATEGORİ BULMA İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/tbl_kategoriler/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_kategoriler>> Gettbl_kategoriler(int id)
        {
          if (_context.tbl_kategoriler == null)
          {
              return NotFound();
          }
            var tbl_kategoriler = await _context.tbl_kategoriler.FindAsync(id);

            if (tbl_kategoriler == null)
            {
                return NotFound();
            }

            return tbl_kategoriler;
        }


        /// <summary>
        /// KATEGORİ DÜZENLEME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PUT: api/tbl_kategoriler/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_kategoriler(int id, tbl_kategoriler tbl_kategoriler)
        {
            if (id != tbl_kategoriler.Id)
            {
                return BadRequest();
            }

            _context.Entry(tbl_kategoriler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_kategorilerExists(id))
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
        /// KATEGORİ EKLEME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST: api/tbl_kategoriler
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tbl_kategoriler>> Posttbl_kategoriler(tbl_kategoriler tbl_kategoriler)
        {
          if (_context.tbl_kategoriler == null)
          {
              return Problem("Entity set 'ApplicationDbContextApp.tbl_kategoriler'  is null.");
          }
            _context.tbl_kategoriler.Add(tbl_kategoriler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettbl_kategoriler", new { id = tbl_kategoriler.Id }, tbl_kategoriler);
        }


        /// <summary>
        /// KATEGORİ SİLME İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/tbl_kategoriler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetbl_kategoriler(int id)
        {
            if (_context.tbl_kategoriler == null)
            {
                return NotFound();
            }
            var tbl_kategoriler = await _context.tbl_kategoriler.FindAsync(id);
            if (tbl_kategoriler == null)
            {
                return NotFound();
            }

            _context.tbl_kategoriler.Remove(tbl_kategoriler);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tbl_kategorilerExists(int id)
        {
            return (_context.tbl_kategoriler?.Any(e => e.Id == id)).GetValueOrDefault();
        }


        /// <summary>
        /// VERİLEN KATEGORİDEKİ İLANLARIN GETİRİLMESİ İŞLEMİ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Ilan/ByKategori/{kategoriId}
        [HttpGet("ByKategori/{kategoriId}")]
        public async Task<ActionResult<IEnumerable<tbl_ilanlar>>> GetIlanlarByKategori(int kategoriId)
        {
            var ilanlar = await _context.tbl_ilanlar.Where(i => i.ilan_kategori_Id == kategoriId).ToListAsync();
            return ilanlar;
        }
    }
}
