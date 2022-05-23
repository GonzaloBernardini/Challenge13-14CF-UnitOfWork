using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge13Kiosco.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public DateTime FechaBaja { get; set; }

        //Relationship:
        public Caracteristica Caracteristica { get; set; }
    }
}
