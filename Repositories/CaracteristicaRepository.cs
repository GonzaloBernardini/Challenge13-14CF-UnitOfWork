using Challenge13Kiosco.Data;
using Challenge13Kiosco.Interfaces;
using Challenge13Kiosco.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge13Kiosco.Repositories
{
    public class CaracteristicaRepository : GenericRepository<Caracteristica>, ICaracteristicaRepository
    {
        private readonly KioscoContext _context;

        public CaracteristicaRepository(KioscoContext context) : base(context)
        {
            _context = context;
        }

        public void BorrarCaracteristica(int IdCaracteristica)
        {
            Delete(IdCaracteristica);

        }

        public Caracteristica BuscarCaracteristica(int IdCaracteristica)
        {
            //probar si esta bien.
            return _context.Caracteristicas.Find(IdCaracteristica);
        }

        public List<Caracteristica> GetCaracteristica()
        {
            /*_context.Productos.ToList();*/
            //Probar si esta bien.
            return GetAll().ToList();
        }

        public void InsertProducto(Caracteristica caracteristica)
        {
            Add(caracteristica);
        }

        public void GuardarCambios()
        {
            Save();
        }
    }
}
