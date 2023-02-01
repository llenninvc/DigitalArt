using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DigitalArt.Models;

namespace DigitalArt.Controllers
{
    public class ArtesController : Controller
    {
        private readonly DigitalartIiContext _context;

        public ArtesController(DigitalartIiContext context)
        {
            _context = context;
        }

        // GET: Artes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Artes.ToListAsync());
        }

        // GET: Artes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artes == null)
            {
                return NotFound();
            }

            var arte = await _context.Artes
                .FirstOrDefaultAsync(m => m.IdArte == id);
            if (arte == null)
            {
                return NotFound();
            }

            return View(arte);
        }

        // GET: Artes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Artes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArte,NombreArte,DescripcionArte,LinkArte,Img,FechaRegistro")] Arte arte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arte);
        }

        // GET: Artes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Artes == null)
            {
                return NotFound();
            }

            var arte = await _context.Artes.FindAsync(id);
            if (arte == null)
            {
                return NotFound();
            }
            return View(arte);
        }

        // POST: Artes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArte,NombreArte,DescripcionArte,LinkArte,Img,FechaRegistro")] Arte arte)
        {
            if (id != arte.IdArte)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArteExists(arte.IdArte))
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
            return View(arte);
        }

        // GET: Artes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Artes == null)
            {
                return NotFound();
            }

            var arte = await _context.Artes
                .FirstOrDefaultAsync(m => m.IdArte == id);
            if (arte == null)
            {
                return NotFound();
            }

            return View(arte);
        }

        // POST: Artes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Artes == null)
            {
                return Problem("Entity set 'DigitalartIiContext.Artes'  is null.");
            }
            var arte = await _context.Artes.FindAsync(id);
            if (arte != null)
            {
                _context.Artes.Remove(arte);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArteExists(int id)
        {
          return _context.Artes.Any(e => e.IdArte == id);
        }
    }
}
