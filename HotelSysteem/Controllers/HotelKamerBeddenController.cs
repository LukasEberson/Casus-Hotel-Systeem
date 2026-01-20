using HotelSysteem.Data;
using HotelSysteem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HotelSysteem.Controllers
{
    public class HotelKamerBeddenController : Controller
    {
        private readonly HotelContext _context;

        public HotelKamerBeddenController(HotelContext context)
        {
            _context = context;
        }

        // GET: HotelKamerBedden
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bedden.ToListAsync());
        }

        // GET: HotelKamerBedden/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerBed = await _context.Bedden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerBed == null)
            {
                return NotFound();
            }

            return View(hotelKamerBed);
        }

        // GET: HotelKamerBedden/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelKamerBedden/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Omschrijving")] HotelKamerBed hotelKamerBed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelKamerBed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelKamerBed);
        }

        // GET: HotelKamerBedden/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerBed = await _context.Bedden.FindAsync(id);
            if (hotelKamerBed == null)
            {
                return NotFound();
            }
            return View(hotelKamerBed);
        }

        // POST: HotelKamerBedden/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Omschrijving")] HotelKamerBed hotelKamerBed)
        {
            if (id != hotelKamerBed.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelKamerBed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelKamerBedExists(hotelKamerBed.Id))
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
            return View(hotelKamerBed);
        }

        // GET: HotelKamerBedden/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerBed = await _context.Bedden
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerBed == null)
            {
                return NotFound();
            }

            return View(hotelKamerBed);
        }

        // POST: HotelKamerBedden/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelKamerBed = await _context.Bedden.FindAsync(id);
            if (hotelKamerBed != null)
            {
                _context.Bedden.Remove(hotelKamerBed);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelKamerBedExists(int id)
        {
            return _context.Bedden.Any(e => e.Id == id);
        }
    }
}
