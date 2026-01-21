using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HotelSysteem.Data;
using HotelSysteem.Models;

namespace HotelSysteem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelKamersApiController : ControllerBase
    {
        private readonly HotelContext _context;

        public HotelKamersApiController(HotelContext context)
        {
            _context = context;
        }

        // GET: api/HotelKamersApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelKamer>>> GetHotelKamers()
        {
            return await _context.HotelKamers.ToListAsync();
        }

        // GET: api/HotelKamersApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelKamer>> GetHotelkamer(int id)
        {
            var hotelkamer = await _context.HotelKamers.FindAsync(id);

            if (hotelkamer == null)
            {
                return NotFound();
            }

            return hotelkamer;
        }

        // PUT: api/HotelKamersApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelkamer(int id, HotelKamer hotelkamer)
        {
            if (id != hotelkamer.Id)
            {
                return BadRequest();
            }

            _context.Entry(hotelkamer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelkamerExists(id))
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

        // POST: api/HotelKamersApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelKamer>> PostHotelkamer(HotelKamer hotelkamer)
        {
            _context.HotelKamers.Add(hotelkamer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHotelkamer", new { id = hotelkamer.Id }, hotelkamer);
        }

        // DELETE: api/HotelKamersApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelkamer(int id)
        {
            var hotelkamer = await _context.HotelKamers.FindAsync(id);
            if (hotelkamer == null)
            {
                return NotFound();
            }

            _context.HotelKamers.Remove(hotelkamer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HotelkamerExists(int id)
        {
            return _context.HotelKamers.Any(e => e.Id == id);
        }
    }
}
