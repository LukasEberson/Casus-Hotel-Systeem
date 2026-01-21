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
    public class HotelKamerReserveringenController : Controller
    {
        private readonly HotelContext _context;

        public HotelKamerReserveringenController(HotelContext context)
        {
            _context = context;
        }

        // GET: HotelKamerReserveringen
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.HotelKamerReserveringen.Include(h => h.Kamer).Include(h => h.Reservering).Include(h => h.Tarief);
            return View(await hotelContext.ToListAsync());
        }

        // GET: HotelKamerReserveringen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerReservering = await _context.HotelKamerReserveringen
                .Include(h => h.Kamer)
                .Include(h => h.Reservering)
                .Include(h => h.Tarief)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerReservering == null)
            {
                return NotFound();
            }

            return View(hotelKamerReservering);
        }

        // GET: HotelKamerReserveringen/Create
        public IActionResult Create()
        {
            ViewData["ReserveringId"] = new SelectList(_context.HotelKamers, "Id", "Id");
            ViewData["ReserveringId"] = new SelectList(_context.HotelReserveringen, "Id", "Id");
            ViewData["TariefId"] = new SelectList(_context.HotelKamerTarieven, "Id", "Id");
            return View();
        }

        // POST: HotelKamerReserveringen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReserveringId,KamerId,TariefId,AantalPersonen")] HotelKamerReservering hotelKamerReservering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelKamerReservering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReserveringId"] = new SelectList(_context.HotelKamers, "Id", "Id", hotelKamerReservering.ReserveringId);
            ViewData["ReserveringId"] = new SelectList(_context.HotelReserveringen, "Id", "Id", hotelKamerReservering.ReserveringId);
            ViewData["TariefId"] = new SelectList(_context.HotelKamerTarieven, "Id", "Id", hotelKamerReservering.TariefId);
            return View(hotelKamerReservering);
        }

        // GET: HotelKamerReserveringen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerReservering = await _context.HotelKamerReserveringen.FindAsync(id);
            if (hotelKamerReservering == null)
            {
                return NotFound();
            }
            ViewData["ReserveringId"] = new SelectList(_context.HotelKamers, "Id", "Id", hotelKamerReservering.ReserveringId);
            ViewData["ReserveringId"] = new SelectList(_context.HotelReserveringen, "Id", "Id", hotelKamerReservering.ReserveringId);
            ViewData["TariefId"] = new SelectList(_context.HotelKamerTarieven, "Id", "Id", hotelKamerReservering.TariefId);
            return View(hotelKamerReservering);
        }

        // POST: HotelKamerReserveringen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ReserveringId,KamerId,TariefId,AantalPersonen")] HotelKamerReservering hotelKamerReservering)
        {
            if (id != hotelKamerReservering.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelKamerReservering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelKamerReserveringExists(hotelKamerReservering.Id))
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
            ViewData["ReserveringId"] = new SelectList(_context.HotelKamers, "Id", "Id", hotelKamerReservering.ReserveringId);
            ViewData["ReserveringId"] = new SelectList(_context.HotelReserveringen, "Id", "Id", hotelKamerReservering.ReserveringId);
            ViewData["TariefId"] = new SelectList(_context.HotelKamerTarieven, "Id", "Id", hotelKamerReservering.TariefId);
            return View(hotelKamerReservering);
        }

        // GET: HotelKamerReserveringen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelKamerReservering = await _context.HotelKamerReserveringen
                .Include(h => h.Kamer)
                .Include(h => h.Reservering)
                .Include(h => h.Tarief)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelKamerReservering == null)
            {
                return NotFound();
            }

            return View(hotelKamerReservering);
        }

        // POST: HotelKamerReserveringen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelKamerReservering = await _context.HotelKamerReserveringen.FindAsync(id);
            if (hotelKamerReservering != null)
            {
                _context.HotelKamerReserveringen.Remove(hotelKamerReservering);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelKamerReserveringExists(int id)
        {
            return _context.HotelKamerReserveringen.Any(e => e.Id == id);
        }
    }
}
