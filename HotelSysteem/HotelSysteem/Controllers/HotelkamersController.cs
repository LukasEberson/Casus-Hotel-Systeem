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
    public class HotelkamersController : Controller
    {
        private readonly HotelContext _context;

        public HotelkamersController(HotelContext context)
        {
            _context = context;
        }

        // GET: Hotelkamers
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotelKamers.ToListAsync());
        }

        // GET: Hotelkamers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelkamer = await _context.HotelKamers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelkamer == null)
            {
                return NotFound();
            }

            return View(hotelkamer);
        }

        // GET: Hotelkamers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hotelkamers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KamerNummer,AantalPersonen,PrijsPerNacht,Omschrijving")] Hotelkamer hotelkamer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelkamer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelkamer = await _context.HotelKamers.FindAsync(id);
            if (hotelkamer == null)
            {
                return NotFound();
            }
            return View(hotelkamer);
        }

        // POST: Hotelkamers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KamerNummer,AantalPersonen,PrijsPerNacht,Omschrijving")] Hotelkamer hotelkamer)
        {
            if (id != hotelkamer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelkamer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelkamerExists(hotelkamer.Id))
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
            return View(hotelkamer);
        }

        // GET: Hotelkamers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelkamer = await _context.HotelKamers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelkamer == null)
            {
                return NotFound();
            }

            return View(hotelkamer);
        }

        // POST: Hotelkamers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelkamer = await _context.HotelKamers.FindAsync(id);
            if (hotelkamer != null)
            {
                _context.HotelKamers.Remove(hotelkamer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelkamerExists(int id)
        {
            return _context.HotelKamers.Any(e => e.Id == id);
        }
    }
}
