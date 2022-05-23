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
        private KioscoContext _context;
        public ProductoRepository(KioscoContext context) : base(context)
        {
            
        }

        public void BorrarProducto(int IdProducto)
        {
            Delete(IdProducto);
            
        }

        public List<Producto> BuscarProducto(int IdProducto)
        {
            //probar si esta bien.
            return Find(x => x.IdProducto == IdProducto).ToList();
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
