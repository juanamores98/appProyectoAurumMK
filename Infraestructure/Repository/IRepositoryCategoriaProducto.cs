using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public interface IRepositoryCategoriaProducto
    {
        CategoriaProducto GetCategoriaProductoByID(int id);
        IEnumerable<CategoriaProducto> GetCategoriaProducto();
        IEnumerable<CategoriaProducto> GetCategoriaProductoByProductoID(int id);
        void DeleteCategoriaProductoByID(int id);
        CategoriaProducto Save(CategoriaProducto categoriaProducto);
    }
}
