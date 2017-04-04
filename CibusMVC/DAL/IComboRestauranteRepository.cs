using CibusMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CibusMVC.DAL
{
    public interface IComboRestauranteRepository : IDisposable
    {
        IEnumerable<ComboRestaurante> GetComboRestaurantes();
        ComboRestaurante GetComboRestauranteByID(int comboRestauranteId);
        void InsertComboRestaurante(ComboRestaurante comboRestaurante);
        void DeleteComboRestaurante(int comboRestauranteID);
        void UpdateComboRestaurante(ComboRestaurante comboRestaurante);
        void Save();
        IEnumerable<ComboRestaurante> GetByIDRestaurante(int id);
    }
}