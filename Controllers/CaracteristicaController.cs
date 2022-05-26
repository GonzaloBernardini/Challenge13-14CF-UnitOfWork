using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Challenge13Kiosco.Data;
using Challenge13Kiosco.Models;
using Challenge13Kiosco.Interfaces;

namespace Challenge13Kiosco.Controllers
{
    public class CaracteristicaController : Controller
    {
        //private readonly KioscoContext _context;

        readonly IUnitOfWork _unitOfWork;

        public CaracteristicaController(IUnitOfWork ouw)
        {
            _unitOfWork = ouw;
        }

        // GET: Caracteristica
        public  IActionResult Index()
        {
            //var kioscoContext = _context.Caracteristicas.Include(c => c.Producto);
            //await kioscoContext.ToListAsync()
            return View(_unitOfWork.Caracteristica.GetAll());
        }

        // GET: Caracteristica/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caracteristica = _unitOfWork.Caracteristica.Find(id);
                
            if (caracteristica == null)
            {
                return NotFound();
            }

            return View(caracteristica);
        }

        // GET: Caracteristica/Create
        public IActionResult Create()
        {
            ViewData["NombreProducto"] = new SelectList(_unitOfWork.Producto.GetAll(), "IdProducto", "Nombre");
            return View();
        }

        // POST: Caracteristica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("IdCaracteristica,Precio,Ancho,Largo,Peso,IdProducto")] Caracteristica caracteristica)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Caracteristica.Add(caracteristica);
                 _unitOfWork.Caracteristica.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_unitOfWork.Producto.GetAll(), "IdProducto", "IdProducto", caracteristica.IdProducto);
            return View(caracteristica);
        }

        // GET: Caracteristica/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caracteristica =  _unitOfWork.Caracteristica.Find(id);
            if (caracteristica == null)
            {
                return NotFound();
            }
            //Chequear si esta bien!
            ViewData["IdProducto"] = new SelectList(_unitOfWork.Producto.GetAll(), "IdProducto", "IdProducto", caracteristica.IdProducto);
            return View(caracteristica);
        }

        // POST: Caracteristica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("IdCaracteristica,Precio,Ancho,Largo,Peso,IdProducto")] Caracteristica caracteristica)
        {
            if (id != caracteristica.IdCaracteristica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Caracteristica.Update(caracteristica);
                     _unitOfWork.Caracteristica.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (caracteristica == null)
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
            ViewData["IdProducto"] = new SelectList(_unitOfWork.Producto.GetAll(), "IdProducto", "IdProducto", caracteristica.IdProducto);
            return View(caracteristica);
        }

        // GET: Caracteristica/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var caracteristica = _unitOfWork.Caracteristica.Find(id);
                
            if (caracteristica == null)
            {
                return NotFound();
            }

            return View(caracteristica);
        }

        // POST: Caracteristica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var caracteristica =  _unitOfWork.Caracteristica.Find(id);
            _unitOfWork.Caracteristica.Delete(id);
             _unitOfWork.Caracteristica.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool CaracteristicaExists(int id)
        //{
        //    return _unitOfWork.Caracteristica.Find(e => e.IdCaracteristica == id);
        //}
    }
}
