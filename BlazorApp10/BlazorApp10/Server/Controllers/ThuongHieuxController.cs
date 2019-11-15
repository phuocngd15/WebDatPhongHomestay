using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorApp10.Server.Models;
using BlazorApp10.Shared.Model;

namespace BlazorApp10.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThuongHieuxController : ControllerBase
    {
        private readonly TodoContext _context;

        public ThuongHieuxController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/ThuongHieux
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThuongHieu>>> GetThuongHieu()
        {
            return await _context.ThuongHieu.ToListAsync();
        }

        // GET: api/ThuongHieux/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThuongHieu>> GetThuongHieu(int id)
        {
            var thuongHieu = await _context.ThuongHieu.FindAsync(id);

            if (thuongHieu == null)
            {
                return NotFound();
            }

            return thuongHieu;
        }

        // PUT: api/ThuongHieux/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThuongHieu(int id, ThuongHieu thuongHieu)
        {
            if (id != thuongHieu.ThuongHieuId)
            {
                return BadRequest();
            }

            _context.Entry(thuongHieu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThuongHieuExists(id))
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

        // POST: api/ThuongHieux
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ThuongHieu>> PostThuongHieu(ThuongHieu thuongHieu)
        {
            _context.ThuongHieu.Add(thuongHieu);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThuongHieu", new { id = thuongHieu.ThuongHieuId }, thuongHieu);
        }

        // DELETE: api/ThuongHieux/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThuongHieu>> DeleteThuongHieu(int id)
        {
            var thuongHieu = await _context.ThuongHieu.FindAsync(id);
            if (thuongHieu == null)
            {
                return NotFound();
            }

            _context.ThuongHieu.Remove(thuongHieu);
            await _context.SaveChangesAsync();

            return thuongHieu;
        }

        private bool ThuongHieuExists(int id)
        {
            return _context.ThuongHieu.Any(e => e.ThuongHieuId == id);
        }
    }
}
