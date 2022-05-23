using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Challenge13Kiosco.Data;
using Challenge13Kiosco.Models;

namespace Challenge13Kiosco.Controllers
{
    public class CaracteristicaController : Controller
    {
        private readonly KioscoContext _context;

        public CaracteristicaController(KioscoContext context)
        {
            _context = context;
        }

        // GET: Caracteristica
        public async Task<IActionResult> Index()
        {
            var kioscoContext = _context.Caracteristicas.Include(c => c.Producto);
            return View(await kioscoContext.ToListAsync());
        }

        // GET: Caracteristica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caracteristica = await _context.Caracteristicas
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.IdCaracteristica == id);
            if (caracteristica == null)
            {
                return NotFound();
            }

            return View(caracteristica);
        }

        // GET: Caracteristica/Create
        public IActionResult Create()
        {
            ViewData["NombreProducto"] = new SelectList(_context.Productos, "IdProducto", "Nombre");
            return View();
        }

        // POST: Caracteristica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCaracteristica,Precio,Ancho,Largo,Peso,IdProducto")] Caracteristica caracteristica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(caracteristica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", caracteristica.IdProducto);
            return View(caracteristica);
        }

        // GET: Caracteristica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caracteristica = await _context.Caracteristicas.FindAsync(id);
            if (caracteristica == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", caracteristica.IdProducto);
            return View(caracteristica);
        }

        // POST: Caracteristica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCaracteristica,Precio,Ancho,Largo,Peso,IdProducto")] Caracteristica caracteristica)
        {
            if (id != caracteristica.IdCaracteristica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(caracteristica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CaracteristicaExists(caracteristica.IdCaracteristica))
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
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "IdProducto", caracteristica.IdProducto);
            return View(caracteristica);
        }

        // GET: Caracteristica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caracteristica = await _context.Caracteristicas
                .Include(c => c.Producto)
                .FirstOrDefaultAsync(m => m.IdCaracteristica == id);
            if (caracteristica == null)
            {
                return NotFound();
            }

            return View(caracteristica);
        }

        // POST: Caracteristica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caracteristica = await _context.Caracteristicas.FindAsync(id);
            _context.Caracteristicas.Remove(caracteristica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CaracteristicaExists(int id)
        {
            return _context.Caracteristicas.Any(e => e.IdCaracteristica == id);
        }
    }
}
