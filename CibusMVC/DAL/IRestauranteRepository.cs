using CibusMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CibusMVC.DAL
{
    public interface IRestauranteRepository : IDisposable
    {
        IEnumerable<Restaurante> GetRestaurantes();
        IEnumerable<Restaurante> GetRestaurantesByTipo(string tipo);
        Restaurante GetRestauranteByID(int restauranteId);
        void InsertRestaurante(Restaurante restaurante);
        void DeleteRestaurante(int restauranteID);
        void UpdateRestaurante(Restaurante restaurante);
        void Save();
    }
}