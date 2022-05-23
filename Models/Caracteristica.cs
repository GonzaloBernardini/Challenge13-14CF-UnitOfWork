using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge13Kiosco.Models
{
    public class Caracteristica
    {
        
        [Key]
        public int IdCaracteristica { get; set; }
        public decimal Precio { get; set; }
        public decimal Ancho { get; set; }
        public decimal Largo { get; set; }
        public decimal Peso { get; set; }

        //Relationship:
        public int IdProducto { get; set; }
        public Producto Producto { get; set; }

    }
}
