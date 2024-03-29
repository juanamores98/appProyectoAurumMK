﻿using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceInventarioProducto : IServiceInventarioProducto
    {
        public void DeleteInventarioProductoByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<InventarioProducto> GetInventarioProducto()
        {
            IRepositoryInventarioProducto repository = new RepositoryInventarioProducto();
            return repository.GetInventarioProducto();
        }
        public InventarioProducto GetInventarioProductoByID(int idInventario, int idProducto)
        {
            IRepositoryInventarioProducto repository = new RepositoryInventarioProducto();
            return repository.GetInventarioProductoByID(idInventario, idProducto);
        }
        public IEnumerable<InventarioProducto> GetInventarioProductoByInventarioID(int id)
        {
            IRepositoryInventarioProducto repository = new RepositoryInventarioProducto();
            return repository.GetInventarioProductoByInventarioID(id);
        }

        public IEnumerable<InventarioProducto> GetInventarioProductoByProductoID(int id)
        {
            IRepositoryInventarioProducto repository = new RepositoryInventarioProducto();
            return repository.GetInventarioProductoByProductoID(id);
        }
        public IEnumerable<InventarioProducto> GetInventarioProductoByEstadoSistemaID(int id)
        {
            IRepositoryInventarioProducto repository = new RepositoryInventarioProducto();
            return repository.GetInventarioProductoByEstadoSistemaID(id);
        }
        public InventarioProducto Save(InventarioProducto inventarioProducto, int idEstadoSistema)
        {
            IRepositoryInventarioProducto repository = new RepositoryInventarioProducto();
            return repository.Save(inventarioProducto, idEstadoSistema);
        }
        public void DeactivateInventarioProductoByInventarioID(int idInventario)
        {
            IRepositoryInventarioProducto repository = new RepositoryInventarioProducto();
            repository.DeactivateInventarioProductoByInventarioID(idInventario);
        }
        public void DeleteAllSotckZeroInventarioProducto()
        {
            IRepositoryInventarioProducto repository = new RepositoryInventarioProducto();
            repository.DeleteAllSotckZeroInventarioProducto();
        }
    }
}
