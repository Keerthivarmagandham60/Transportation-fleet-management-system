using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TFMS.Models;
using Transportation_fleet_management_system.Data;

namespace Transportation_fleet_management_system.Controllers
{
    public class TripsController : Controller
    {
        private readonly Transportation_fleet_management_systemContext _context;

        public TripsController(Transportation_fleet_management_systemContext context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var transportation_fleet_management_systemContext = _context.Trip.Include(t => t.Driver).Include(t => t.Vehicle);
            return View(await transportation_fleet_management_systemContext.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.Driver)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["DriverId"] = new SelectList(_context.Set<Driver>(), "DriverId", "Address");
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TripId,VehicleId,DriverId,StartLocation,EndLocation,StartTime,EndTime")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = new SelectList(_context.Set<Driver>(), "DriverId", "Address", trip.DriverId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", trip.VehicleId);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Set<Driver>(), "DriverId", "Address", trip.DriverId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", trip.VehicleId);
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TripId,VehicleId,DriverId,StartLocation,EndLocation,StartTime,EndTime")] Trip trip)
        {
            if (id != trip.TripId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripId))
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
            ViewData["DriverId"] = new SelectList(_context.Set<Driver>(), "DriverId", "Address", trip.DriverId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", trip.VehicleId);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .Include(t => t.Driver)
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.Trip.FindAsync(id);
            if (trip != null)
            {
                _context.Trip.Remove(trip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trip.Any(e => e.TripId == id);
        }
    }
}
