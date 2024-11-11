using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Inventaris.Data;
using Inventaris.Models;

namespace Inventaris.Controllers
{
    [Authorize]

    public class DataController : Controller
    {
        private readonly InventarisContext _context;

        public DataController(InventarisContext context)
        {
            _context = context;
        }

        // GET: Data
        public async Task<IActionResult> Index()
        {
            var datapusat = await _context.Datapusat
                                        .OrderByDescending(d => d.Id) 
                                        .ToListAsync();

            return View(datapusat);
        }


        // GET: Data/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datapusat = await _context.Datapusat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datapusat == null)
            {
                return NotFound();
            }

            return View(datapusat);
        }

        // GET: Data/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Data/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Stock,Merek")] Datapusat datapusat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datapusat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datapusat);
        }

        // GET: Data/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datapusat = await _context.Datapusat.FindAsync(id);
            if (datapusat == null)
            {
                return NotFound();
            }
            return View(datapusat);
        }

        // POST: Data/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Stock,Merek")] Datapusat datapusat)
        {
            if (id != datapusat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datapusat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatapusatExists(datapusat.Id))
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
            return View(datapusat);
        }

        // GET: Data/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datapusat = await _context.Datapusat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (datapusat == null)
            {
                return NotFound();
            }

            return View(datapusat);
        }

        // POST: Data/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datapusat = await _context.Datapusat.FindAsync(id);
            if (datapusat != null)
            {
                _context.Datapusat.Remove(datapusat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatapusatExists(int id)
        {
            return _context.Datapusat.Any(e => e.Id == id);
        }
    }
}
