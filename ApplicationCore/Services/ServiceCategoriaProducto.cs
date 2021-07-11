using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceCategoriaProducto : IServiceCategoriaProducto
    {
        public void DeleteCategoriaProductoByID(int id)
        {
            IRepositoryCategoriaProducto repository = new RepositoryCategoriaProducto();
             repository.DeleteCategoriaProductoByID(id);
        }

        public IEnumerable<CategoriaProducto> GetCategoriaProducto()
        {
            IRepositoryCategoriaProducto repository = new RepositoryCategoriaProducto();
            return repository.GetCategoriaProducto();
        }

        public CategoriaProducto GetCategoriaProductoByID(int id)
        {
            IRepositoryCategoriaProducto repository = new RepositoryCategoriaProducto();
            return repository.GetCategoriaProductoByID(id);
        }

        public IEnumerable<CategoriaProducto> GetCategoriaProductoByProductoID(int id)
        {
            IRepositoryCategoriaProducto repository = new RepositoryCategoriaProducto();
            return repository.GetCategoriaProductoByProductoID(id);
        }

        public CategoriaProducto Save(CategoriaProducto categoriaP)
        {
            IRepositoryCategoriaProducto repository = new RepositoryCategoriaProducto();
            return repository.Save(categoriaP);
        }
    }
}
