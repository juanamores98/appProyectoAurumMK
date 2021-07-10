using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceCategoriaProducto
    {
        CategoriaProducto GetCategoriaProductoByID(int id);
        IEnumerable<CategoriaProducto> GetCategoriaProducto();
        IEnumerable<CategoriaProducto> GetCategoriaProductoByProductoID(int id);
        void DeleteCategoriaProductoByID(int id);
        CategoriaProducto Save(CategoriaProducto categoriaProducto);
    }
}
