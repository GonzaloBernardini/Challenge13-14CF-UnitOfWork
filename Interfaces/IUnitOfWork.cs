﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge13Kiosco.Interfaces
{
    public interface IUnitOfWork
    {
        
     IProductoRepository Producto{ get; } 
     int Complete();


    }
}
