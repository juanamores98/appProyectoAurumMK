﻿using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryInventario
    {
        Inventario GetInventarioByID(int id);
        IEnumerable<Inventario> GetInventario();
        IEnumerable<Inventario> GetInventarioBySucursalID(int id);
        void DeleteInventarioByID(int id);
        Inventario Save(Inventario inventario);
    }
}
