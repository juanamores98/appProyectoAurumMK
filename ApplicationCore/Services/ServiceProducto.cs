using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceProducto : IServiceProducto
    {
        public void DeleteProductoByID(int id)
        {
            IRepositoryProducto repository = new RepositoryProducto();
            repository.DeleteProductoByID(id);
        }

        public IEnumerable<Producto> GetProducto()
        {
            IRepositoryProducto repository = new RepositoryProducto();
            return repository.GetProducto();
        }

        public IEnumerable<Producto> GetProductoByColorID(int id)
        {
            IRepositoryProducto repository = new RepositoryProducto();
            return repository.GetProductoByColorID(id);
        }

        public IEnumerable<Producto> GetProductoByEstadoSistemaID(int id)
        {
            IRepositoryProducto repository = new RepositoryProducto();
            return repository.GetProductoByEstadoSistemaID(id);
        }

        public Producto GetProductoByID(int id)
        {
            IRepositoryProducto repository = new RepositoryProducto();
            return repository.GetProductoByID(id);
        }

        public IEnumerable<Producto> GetProductoByNombre(string nombre)
        {
            IRepositoryProducto repository = new RepositoryProducto();
            return repository.GetProductoByNombre(nombre);
        }

        public IEnumerable<Producto> GetProductoByProveedorID(int id)
        {
            IRepositoryProducto repository = new RepositoryProducto();
            return repository.GetProductoByProveedorID(id);
        }

        public Producto Save(Producto producto, string[] seleccionInventarios, string[] seleccionProveedores, string[] seleccionColores, int idEstadoSistema)
        {
            IRepositoryProducto repository = new RepositoryProducto();
            return repository.Save(producto,seleccionInventarios,  seleccionProveedores, seleccionColores,idEstadoSistema);
        }
    }
}
