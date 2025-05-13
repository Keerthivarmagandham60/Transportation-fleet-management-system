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
    [Route("Driver")] // Add this line here
    public class DriversController : Controller
    {
        private readonly Transportation_fleet_management_systemContext _context;

        public DriversController(Transportation_fleet_management_systemContext context)
        {
            _context = context;
        }

        // GET: /Drivers (This will now map to the Index action)
        [HttpGet] // Add this to explicitly map GET requests to /Driver to the Index action
        public async Task<IActionResult> Index()
        {
            return View(await _context.Driver.ToListAsync());
        }

        // GET: /Drivers/Details/5
        [HttpGet("Details/{id}")] // Keep this - it specifies the route for the Details action
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // GET: /Drivers/Create
        [HttpGet("Create")] // Keep this - specifies the route for the Create action
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Drivers/Create
        [HttpPost("Create")] // Keep this - specifies the route for the POST Create action
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DriverId,FirstName,LastName,LicenseNumber,ContactNumber,Email,Status,Address")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(driver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        // GET: /Drivers/Edit/5
        [HttpGet("Edit/{id}")] // Keep this - specifies the route for the Edit action
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        // POST: /Drivers/Edit/5
        [HttpPost("Edit/{id}")] // Keep this - specifies the route for the POST Edit action
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DriverId,FirstName,LastName,LicenseNumber,ContactNumber,Email,Status,Address")] Driver driver)
        {
            if (id != driver.DriverId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(driver);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.DriverId))
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
            return View(driver);
        }

        // GET: /Drivers/Delete/5
        [HttpGet("Delete/{id}")] // Keep this - specifies the route for the Delete action
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await _context.Driver
                .FirstOrDefaultAsync(m => m.DriverId == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: /Drivers/Delete/5
        [HttpPost("Delete/{id}"), ActionName("Delete")] // Keep this - specifies the route for the POST Delete action
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var driver = await _context.Driver.FindAsync(id);
            if (driver != null)
            {
                _context.Driver.Remove(driver);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(int id)
        {
            return _context.Driver.Any(e => e.DriverId == id);
        }
    }
}