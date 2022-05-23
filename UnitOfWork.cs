using Challenge13Kiosco.Data;
using Challenge13Kiosco.Interfaces;
using Challenge13Kiosco.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge13Kiosco
{
    public class UnitOfWork : IUnitOfWork
    {
        

        //Repositorio para clase especifica1
        //Repositorio para clase especifica1

        private KioscoContext _context;
        public UnitOfWork(KioscoContext context)
        {
            _context = context;
            Producto = new ProductoRepository(_context);
        }

        

        public IProductoRepository Producto { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
