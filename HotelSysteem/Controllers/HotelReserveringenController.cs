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
    public class HotelReserveringenController : Controller
    {
        private readonly HotelContext _context;

        public HotelReserveringenController(HotelContext context)
        {
            _context = context;
        }

        // GET: HotelReserveringen
        public async Task<IActionResult> Index()
        {
            var hotelContext = _context.HotelReserveringen.Include(h => h.Rekening);
            return View(await hotelContext.ToListAsync());
        }

        // GET: HotelReserveringen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelReservering = await _context.HotelReserveringen
                .Include(h => h.Rekening)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelReservering == null)
            {
                return NotFound();
            }

            return View(hotelReservering);
        }

        // GET: HotelReserveringen/Create
        public IActionResult Create()
        {
            ViewData["RekeningId"] = new SelectList(_context.HotelRekeningen, "Id", "Id");
            return View();
        }

        // POST: HotelReserveringen/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RekeningId,Naam,Emailaddres,TelefoonNummer,BeginDatum,EindDatum")] HotelReservering hotelReservering)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hotelReservering);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RekeningId"] = new SelectList(_context.HotelRekeningen, "Id", "Id", hotelReservering.RekeningId);
            return View(hotelReservering);
        }

        // GET: HotelReserveringen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelReservering = await _context.HotelReserveringen.FindAsync(id);
            if (hotelReservering == null)
            {
                return NotFound();
            }
            ViewData["RekeningId"] = new SelectList(_context.HotelRekeningen, "Id", "Id", hotelReservering.RekeningId);
            return View(hotelReservering);
        }

        // POST: HotelReserveringen/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RekeningId,Naam,Emailaddres,TelefoonNummer,BeginDatum,EindDatum")] HotelReservering hotelReservering)
        {
            if (id != hotelReservering.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hotelReservering);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelReserveringExists(hotelReservering.Id))
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
            ViewData["RekeningId"] = new SelectList(_context.HotelRekeningen, "Id", "Id", hotelReservering.RekeningId);
            return View(hotelReservering);
        }

        // GET: HotelReserveringen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hotelReservering = await _context.HotelReserveringen
                .Include(h => h.Rekening)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hotelReservering == null)
            {
                return NotFound();
            }

            return View(hotelReservering);
        }

        // POST: HotelReserveringen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotelReservering = await _context.HotelReserveringen.FindAsync(id);
            if (hotelReservering != null)
            {
                _context.HotelReserveringen.Remove(hotelReservering);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelReserveringExists(int id)
        {
            return _context.HotelReserveringen.Any(e => e.Id == id);
        }
    }
}
