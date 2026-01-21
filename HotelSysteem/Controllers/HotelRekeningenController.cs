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
    public class HotelRekeningenController : Controller
    {
        private readonly HotelContext _context;

        public HotelRekeningenController(HotelContext context)
        {
            _context = context;
        }

        // GET: HotelRekeningen
        public async Task<IActionResult> Index()
        {
            return View(await _context.HotelRekeningen.ToListAsync());
        }

        // GET: HotelRekeningen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRekening = await _context.HotelRekeningen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelRekening == null)
            {
                return NotFound();
            }

            return View(hotelRekening);
        }

        // GET: HotelRekeningen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HotelRekeningen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ToeristenBelasting,Korting,Betaald")] HotelRekening hotelRekening)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelRekening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hotelRekening);
        }

        // GET: HotelRekeningen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRekening = await _context.HotelRekeningen.FindAsync(id);
            if (hotelRekening == null)
            {
                return NotFound();
            }
            return View(hotelRekening);
        }

        // POST: HotelRekeningen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ToeristenBelasting,Korting,Betaald")] HotelRekening hotelRekening)
        {
            if (id != hotelRekening.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelRekening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelRekeningExists(hotelRekening.Id))
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
            return View(hotelRekening);
        }

        // GET: HotelRekeningen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelRekening = await _context.HotelRekeningen
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelRekening == null)
            {
                return NotFound();
            }

            return View(hotelRekening);
        }

        // POST: HotelRekeningen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelRekening = await _context.HotelRekeningen.FindAsync(id);
            if (hotelRekening != null)
            {
                _context.HotelRekeningen.Remove(hotelRekening);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelRekeningExists(int id)
        {
            return _context.HotelRekeningen.Any(e => e.Id == id);
        }
    }
}
