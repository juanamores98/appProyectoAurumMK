﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceInventarioProducto
    {
        IEnumerable<InventarioProducto> GetInventarioProducto();
        InventarioProducto GetInventarioProductoByID(int idInventario, int idProducto);
        IEnumerable<InventarioProducto> GetInventarioProductoByInventarioID(int id);
        IEnumerable<InventarioProducto> GetInventarioProductoByProductoID(int id);
        void DeleteInventarioProductoByID(int id);
        InventarioProducto Save();
    }
}
