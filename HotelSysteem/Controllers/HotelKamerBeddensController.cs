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
    public class HotelKamerBeddensController : Controller
    {
        private readonly HotelContext _context;

        public HotelKamerBeddensController(HotelContext context)
        {
            _context = context;
        }

        // GET: HotelKamerBeddens
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.Beddens.Include(h => h.Bed);
            return View(await hotelContext.ToListAsync());
        }

        // GET: HotelKamerBeddens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerBedden = await _context.Beddens
                .Include(h => h.Bed)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerBedden == null)
            {
                return NotFound();
            }

            return View(hotelKamerBedden);
        }

        // GET: HotelKamerBeddens/Create
        public IActionResult Create()
        {
            ViewData["BedId"] = new SelectList(_context.Bedden, "Id", "Id");
            return View();
        }

        // POST: HotelKamerBeddens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BedId,Aantal")] HotelKamerBedden hotelKamerBedden)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelKamerBedden);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BedId"] = new SelectList(_context.Bedden, "Id", "Id", hotelKamerBedden.BedId);
            return View(hotelKamerBedden);
        }

        // GET: HotelKamerBeddens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerBedden = await _context.Beddens.FindAsync(id);
            if (hotelKamerBedden == null)
            {
                return NotFound();
            }
            ViewData["BedId"] = new SelectList(_context.Bedden, "Id", "Id", hotelKamerBedden.BedId);
            return View(hotelKamerBedden);
        }

        // POST: HotelKamerBeddens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BedId,Aantal")] HotelKamerBedden hotelKamerBedden)
        {
            if (id != hotelKamerBedden.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelKamerBedden);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelKamerBeddenExists(hotelKamerBedden.Id))
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
            ViewData["BedId"] = new SelectList(_context.Bedden, "Id", "Id", hotelKamerBedden.BedId);
            return View(hotelKamerBedden);
        }

        // GET: HotelKamerBeddens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerBedden = await _context.Beddens
                .Include(h => h.Bed)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerBedden == null)
            {
                return NotFound();
            }

            return View(hotelKamerBedden);
        }

        // POST: HotelKamerBeddens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelKamerBedden = await _context.Beddens.FindAsync(id);
            if (hotelKamerBedden != null)
            {
                _context.Beddens.Remove(hotelKamerBedden);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelKamerBeddenExists(int id)
        {
            return _context.Beddens.Any(e => e.Id == id);
        }
    }
}
