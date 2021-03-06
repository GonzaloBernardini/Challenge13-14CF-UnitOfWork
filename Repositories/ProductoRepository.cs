using Challenge13Kiosco.Data;
using Challenge13Kiosco.Interfaces;
using Challenge13Kiosco.Models;
using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Challenge13Kiosco.Repositories
{
    public class ProductoRepository : GenericRepository<Producto>,IProductoRepository
    {
        private readonly KioscoContext _context;
        public ProductoRepository(KioscoContext context) : base(context)
        {
            _context = context;
        }

        public void BorrarProducto(int IdProducto)
        {
            Delete(IdProducto);
           
        }

        public  Producto BuscarProducto(int IdProducto)
        {
            //probar si esta bien.
            return _context.Productos.Find(IdProducto);
        }

        public List<Producto> GetProductos()
        {
            /*_context.Productos.ToList();*/
            //Probar si esta bien.
            return GetAll().ToList();
        }

        public void InsertProducto(Producto producto_)
        {
            Add(producto_);
        }

        public void GuardarCambios()
        {
            Save();
        }

        
    }
}
