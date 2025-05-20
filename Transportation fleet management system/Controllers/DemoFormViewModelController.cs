using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FleetHub.Models;
using Transportation_fleet_management_system.Data;

namespace Transportation_fleet_management_system.Controllers
{
    public class DemoFormViewModelController : Controller
    {
        private readonly Transportation_fleet_management_systemContext _context;

        public DemoFormViewModelController(Transportation_fleet_management_systemContext context)
        {
            _context = context;
        }

        // GET: DemoFormViewModel
        public async Task<IActionResult> Index()
        {
            return View(await _context.DemoFormViewModel.ToListAsync());
        }

        // GET: DemoFormViewModel/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demoFormViewModel = await _context.DemoFormViewModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (demoFormViewModel == null)
            {
                return NotFound();
            }

            return View(demoFormViewModel);
        }

        // GET: DemoFormViewModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DemoFormViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Email,PhoneNumber,Country,City,CompanyName,FleetSize,SelectedProduct")] DemoFormViewModel demoFormViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(demoFormViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(demoFormViewModel);
        }

        // GET: DemoFormViewModel/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demoFormViewModel = await _context.DemoFormViewModel.FindAsync(id);
            if (demoFormViewModel == null)
            {
                return NotFound();
            }
            return View(demoFormViewModel);
        }

        // POST: DemoFormViewModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Name,Email,PhoneNumber,Country,City,CompanyName,FleetSize,SelectedProduct")] DemoFormViewModel demoFormViewModel)
        {
            if (id != demoFormViewModel.Name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(demoFormViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DemoFormViewModelExists(demoFormViewModel.Name))
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
            return View(demoFormViewModel);
        }

        // GET: DemoFormViewModel/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var demoFormViewModel = await _context.DemoFormViewModel
                .FirstOrDefaultAsync(m => m.Name == id);
            if (demoFormViewModel == null)
            {
                return NotFound();
            }

            return View(demoFormViewModel);
        }

        // POST: DemoFormViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var demoFormViewModel = await _context.DemoFormViewModel.FindAsync(id);
            if (demoFormViewModel != null)
            {
                _context.DemoFormViewModel.Remove(demoFormViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DemoFormViewModelExists(string id)
        {
            return _context.DemoFormViewModel.Any(e => e.Name == id);
        }
    }
}
