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
    [Route("Fuels")]
    public class FuelsController : Controller
    {
        private readonly Transportation_fleet_management_systemContext _context;

        public FuelsController(Transportation_fleet_management_systemContext context)
        {
            _context = context;
        }

        // GET: Fuels
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fuelsWithVehicles = _context.Fuel.Include(f => f.Vehicle);
            return View(await fuelsWithVehicles.ToListAsync());
        }

        // GET: Fuels/Details/5
        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuel
                .Include(f => f.Vehicle)
                .FirstOrDefaultAsync(m => m.FuelId == id);
            if (fuel == null)
            {
                return NotFound();
            }

            return View(fuel);
        }

        // GET: Fuels/Create
        [HttpGet("Create")]
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber");
            return View();
        }

        // POST: Fuels/Create
        [HttpPost("Create")]
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuelId,VehicleId,Date,FuelQuantity,Cost")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fuel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", fuel.VehicleId);
            return View(fuel);
        }

        // GET: Fuels/Edit/5
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuel.FindAsync(id);
            if (fuel == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", fuel.VehicleId);
            return View(fuel);
        }

        // POST: Fuels/Edit/5
        [HttpPost("Edit/{id}")]
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuelId,VehicleId,Date,FuelQuantity,Cost")] Fuel fuel)
        {
            if (id != fuel.FuelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelExists(fuel.FuelId))
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
            ViewData["VehicleId"] = new SelectList(_context.Vehicle, "VehicleId", "RegistrationNumber", fuel.VehicleId);
            return View(fuel);
        }

        // GET: Fuels/Delete/5
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuel = await _context.Fuel
                .Include(f => f.Vehicle)
                .FirstOrDefaultAsync(m => m.FuelId == id);
            if (fuel == null)
            {
                return NotFound();
            }

            return View(fuel);
        }

        // POST: Fuels/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")]
        //[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuel = await _context.Fuel.FindAsync(id);
            if (fuel != null)
            {
                _context.Fuel.Remove(fuel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelExists(int id)
        {
            return _context.Fuel.Any(e => e.FuelId == id);
        }
    }
}
