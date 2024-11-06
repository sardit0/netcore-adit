using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inventaris.Data;
using Inventaris.Models;

namespace Inventaris.Controllers
{
    public class ItemsController : Controller
    {
        private readonly InventarisContext _context;

        public ItemsController(InventarisContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            var inventarisContext = _context.Item.Include(i => i.Category).Include(i => i.Supplier);
            return View(await inventarisContext.ToListAsync());
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "SupplierName");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
                [HttpPost]
                [ValidateAntiForgeryToken]
                public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Description,DateAdded,ImagePath,CategoryId,SupplierId")] Item item, IFormFile ImagePath)
                {
                   if (ModelState.IsValid)
                    {
                        // if (ImagePath != null && ImagePath.Length > 0)
                        // {
                        //     var fileName = Path.GetFileName(ImagePath.FileName);
                        //     var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                        //     using (var stream = new FileStream(filePath, FileMode.Create))
                        //     {
                        //         await ImagePath.CopyToAsync(stream);
                        //     }

                        //     item.ImagePath = "/images/" + fileName;
                        // }

                            if (ImagePath != null && ImagePath.Length > 0)
                            {
                                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
                                var fileExtension = Path.GetExtension(ImagePath.FileName).ToLower();

                                if (!allowedExtensions.Contains(fileExtension))
                                {
                                    throw new Exception("Only image files are allowed.");
                                }

                                var fileName = Path.GetFileName(ImagePath.FileName);
                                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                                using (var stream = new FileStream(filePath, FileMode.Create))
                                {
                                    await ImagePath.CopyToAsync(stream);
                                }

                                item.ImagePath = "/images/" + fileName;
                            }

                        _context.Add(item);
                        await _context.SaveChangesAsync();

                        return RedirectToAction("Index"); 
                    }

                    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "CategoryName", item.CategoryId);
                    ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "SupplierName", item.SupplierId);

                    TempData["SuccessMessage"] = "Item has been successfully created!";
                    return View(item);

                        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "CategoryName", item.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "SupplierName", item.SupplierId);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
      [HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Description,DateAdded,CategoryId,SupplierId,ImagePath")] Item item, IFormFile ImagePath)
{
    if (id != item.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            if (ImagePath != null && ImagePath.Length > 0)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", ImagePath.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImagePath.CopyToAsync(stream);
                }

                item.ImagePath = "/images/" + ImagePath.FileName;
            }
            else
            {
                var existingItem = await _context.Item.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
                item.ImagePath = existingItem?.ImagePath;
            }
            _context.Update(item);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ItemExists(item.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        // TempData untuk menampilkan pesan sukses
        TempData["SuccessMessage"] = "Item has been successfully edited!";
        return RedirectToAction(nameof(Index));
    }

    // Jika ada error pada model, kembalikan form dengan data dropdown yang sesuai
    ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "Id", "CategoryName", item.CategoryId);
    ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "Id", "SupplierName", item.SupplierId);
    return View(item);
}


        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.Category)
                .Include(i => i.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Item.FindAsync(id);
            if (item != null)
            {
                _context.Item.Remove(item);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.Id == id);
        }
    }
}
