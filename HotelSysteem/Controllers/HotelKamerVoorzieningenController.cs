using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelSysteem.Data;
using HotelSysteem.Models;

namespace HotelSysteem.Controllers
{
    public class HotelKamerVoorzieningenController : Controller
    {
        private readonly HotelContext _context;

        public HotelKamerVoorzieningenController(HotelContext context)
        {
            _context = context;
        }

        // GET: HotelKamerVoorzieningen
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Voorzieningens.Include(h => h.Kamer);
            return View(await hotelContext.ToListAsync());
        }

        // GET: HotelKamerVoorzieningen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerVoorzieningen = await _context.Voorzieningens
                .Include(h => h.Kamer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerVoorzieningen == null)
            {
                return NotFound();
            }

            return View(hotelKamerVoorzieningen);
        }

        // GET: HotelKamerVoorzieningen/Create
        public IActionResult Create()
        {
            ViewData["KamerId"] = new SelectList(_context.HotelKamers, "Id", "Id");
            return View();
        }

        // POST: HotelKamerVoorzieningen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KamerId,Oppervlakte,Balkon,Badkamers,Slaapkamers")] HotelKamerVoorzieningen hotelKamerVoorzieningen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelKamerVoorzieningen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KamerId"] = new SelectList(_context.HotelKamers, "Id", "Id", hotelKamerVoorzieningen.KamerId);
            return View(hotelKamerVoorzieningen);
        }

        // GET: HotelKamerVoorzieningen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerVoorzieningen = await _context.Voorzieningens.FindAsync(id);
            if (hotelKamerVoorzieningen == null)
            {
                return NotFound();
            }
            ViewData["KamerId"] = new SelectList(_context.HotelKamers, "Id", "Id", hotelKamerVoorzieningen.KamerId);
            return View(hotelKamerVoorzieningen);
        }

        // POST: HotelKamerVoorzieningen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KamerId,Oppervlakte,Balkon,Badkamers,Slaapkamers")] HotelKamerVoorzieningen hotelKamerVoorzieningen)
        {
            if (id != hotelKamerVoorzieningen.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelKamerVoorzieningen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelKamerVoorzieningenExists(hotelKamerVoorzieningen.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KamerId"] = new SelectList(_context.HotelKamers, "Id", "Id", hotelKamerVoorzieningen.KamerId);
            return View(hotelKamerVoorzieningen);
        }

        // GET: HotelKamerVoorzieningen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerVoorzieningen = await _context.Voorzieningens
                .Include(h => h.Kamer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerVoorzieningen == null)
            {
                return NotFound();
            }

            return View(hotelKamerVoorzieningen);
        }

        // POST: HotelKamerVoorzieningen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelKamerVoorzieningen = await _context.Voorzieningens.FindAsync(id);
            if (hotelKamerVoorzieningen != null)
            {
                _context.Voorzieningens.Remove(hotelKamerVoorzieningen);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelKamerVoorzieningenExists(int id)
        {
            return _context.Voorzieningens.Any(e => e.Id == id);
        }
    }
}
