using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IServiceColor
    {
        Color GetColorByID(int id);
        IEnumerable<Color> GetColor();
        IEnumerable<Color> GetColorByProductoID(int id);
        IEnumerable<Color> GetColorByEstadoSistemaID(int id);
        void DeleteColorByID(int id);
        Color Save();
    }
}
