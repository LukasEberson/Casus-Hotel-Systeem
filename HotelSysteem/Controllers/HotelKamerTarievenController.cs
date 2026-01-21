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
    public class HotelKamerTarievenController : Controller
    {
        private readonly HotelContext _context;

        public HotelKamerTarievenController(HotelContext context)
        {
            _context = context;
        }

        // GET: HotelKamerTarieven
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.HotelKamerTarieven.Include(h => h.Kamer);
            return View(await hotelContext.ToListAsync());
        }

        // GET: HotelKamerTarieven/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerTarief = await _context.HotelKamerTarieven
                .Include(h => h.Kamer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerTarief == null)
            {
                return NotFound();
            }

            return View(hotelKamerTarief);
        }

        // GET: HotelKamerTarieven/Create
        public IActionResult Create()
        {
            ViewData["KamerId"] = new SelectList(_context.HotelKamers, "Id", "Id");
            return View();
        }

        // POST: HotelKamerTarieven/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KamerId,GeldingVan,GeldigTot,Tarief")] HotelKamerTarief hotelKamerTarief)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelKamerTarief);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KamerId"] = new SelectList(_context.HotelKamers, "Id", "Id", hotelKamerTarief.KamerId);
            return View(hotelKamerTarief);
        }

        // GET: HotelKamerTarieven/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerTarief = await _context.HotelKamerTarieven.FindAsync(id);
            if (hotelKamerTarief == null)
            {
                return NotFound();
            }
            ViewData["KamerId"] = new SelectList(_context.HotelKamers, "Id", "Id", hotelKamerTarief.KamerId);
            return View(hotelKamerTarief);
        }

        // POST: HotelKamerTarieven/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KamerId,GeldingVan,GeldigTot,Tarief")] HotelKamerTarief hotelKamerTarief)
        {
            if (id != hotelKamerTarief.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelKamerTarief);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelKamerTariefExists(hotelKamerTarief.Id))
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
            ViewData["KamerId"] = new SelectList(_context.HotelKamers, "Id", "Id", hotelKamerTarief.KamerId);
            return View(hotelKamerTarief);
        }

        // GET: HotelKamerTarieven/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerTarief = await _context.HotelKamerTarieven
                .Include(h => h.Kamer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerTarief == null)
            {
                return NotFound();
            }

            return View(hotelKamerTarief);
        }

        // POST: HotelKamerTarieven/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelKamerTarief = await _context.HotelKamerTarieven.FindAsync(id);
            if (hotelKamerTarief != null)
            {
                _context.HotelKamerTarieven.Remove(hotelKamerTarief);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelKamerTariefExists(int id)
        {
            return _context.HotelKamerTarieven.Any(e => e.Id == id);
        }
    }
}
