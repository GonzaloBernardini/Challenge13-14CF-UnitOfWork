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
    public class ProductoController : Controller
    {
        readonly IUnitOfWork _unitOfWork;
        public ProductoController(IUnitOfWork uow)
        {
            _unitOfWork = uow;
        }

        // GET: Producto
        public  IActionResult Index()
        {
            return View(_unitOfWork.Producto.GetAll());
        }

        // GET: Producto/Details/5
        public  IActionResult Details(int? id)
        {



            if (id == null)
            {
                return NotFound();
            }

            var producto = _unitOfWork.Producto.Find(id);
                //.FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("IdProducto,Nombre,Categoria,FechaBaja")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Producto.Add(producto);
                _unitOfWork.Producto.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var producto = _unitOfWork.Producto.Find(id);
            //var producto = _unitOfWork.Producto.Find(x=>x.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("IdProducto,Nombre,Categoria,FechaBaja")] Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Producto.Update(producto);
                     _unitOfWork.Producto.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //probar si esta bien!
                    if (producto == null)
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
            return View(producto);
        }

        // GET: Producto/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _unitOfWork.Producto.Find(id);
                
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var producto =  _unitOfWork.Producto.Find(id);
            _unitOfWork.Producto.Delete(id);
             _unitOfWork.Producto.Save();
            return RedirectToAction(nameof(Index));
        }

        //private bool ProductoExists(int id)
        //{
            
        //}
    }
}
