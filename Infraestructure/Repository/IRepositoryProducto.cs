﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryProducto
    {
        Producto GetProductoByID(int id);
        IEnumerable<Producto> GetProducto();
        IEnumerable<Producto> GetProductoByNombre(String nombre);
        IEnumerable<Producto> GetProductoByEstadoSistemaID(int id);
        IEnumerable<Producto> GetProductoByColorID(int id);
        IEnumerable<Producto> GetProductoByProveedorID(int id);
        void DeleteProductoByID(int id);
        Producto Save(Producto producto, string[] seleccionInventarios, string[] seleccionProveedores, string[] seleccionColores);
    }
}
