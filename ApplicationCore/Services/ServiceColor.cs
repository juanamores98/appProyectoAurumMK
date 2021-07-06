using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceColor : IServiceColor
    {
        public void DeleteColorByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Color> GetColor()
        {
            IRepositoryColor repository = new RepositoryColor();
            return repository.GetColor();
        }

        public IEnumerable<Color> GetColorByEstadoSistemaID(int id)
        {
            IRepositoryColor repository = new RepositoryColor();
            return repository.GetColorByEstadoSistemaID(id);
        }

        public Color GetColorByID(int id)
        {
            IRepositoryColor repository = new RepositoryColor();
            return repository.GetColorByID(id);
        }
        public Color GetColorByCodigo(string codigo)
        {
            IRepositoryColor repository = new RepositoryColor();
            return repository.GetColorByCodigo(codigo);
        }

        public IEnumerable<Color> GetColorByProductoID(int id)
        {
            IRepositoryColor repository = new RepositoryColor();
            return repository.GetColorByProductoID(id);
        }

        public Color Save(Color color, int idEstadoSistema)
        {
            IRepositoryColor repository = new RepositoryColor();
            return repository.Save(color, idEstadoSistema);
        }
    }
}
