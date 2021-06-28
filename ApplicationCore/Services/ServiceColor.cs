﻿using Infraestructure.Models;
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
            throw new NotImplementedException();
        }

        public Color GetColorByID(int id)
        {
            IRepositoryColor repository = new RepositoryColor();
            return repository.GetColorByID(id);
        }

        public IEnumerable<Color> GetColorByProductoID(int id)
        {
            IRepositoryColor repository = new RepositoryColor();
            return repository.GetColorByProductoID(id);
        }

        public Color Save()
        {
            throw new NotImplementedException();
        }
    }
}