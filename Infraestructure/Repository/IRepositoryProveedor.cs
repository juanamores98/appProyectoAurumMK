﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryProveedor
    {
        Proveedor GetProveedorByID(int id);
        IEnumerable<Proveedor> GetProveedor();
        IEnumerable<Proveedor> GetProveedorByNombre(string nombre);
        IEnumerable<Proveedor> GetProveedorByProductoID(int id);
        IEnumerable<Proveedor> GetProveedorByEstadoSistemaID(int id);
        void DeleteProveedorByID(int id);
        Proveedor Save(Proveedor proveedor, int idEstadoSistema);
    }
}
