using CibusMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CibusMVC.DAL
{
    public class ComboRestauranteRepository : IComboRestauranteRepository, IDisposable
    {
        private ApplicationDbContext context;

        public ComboRestauranteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ComboRestaurante> GetComboRestaurantes()
        {
            return context.ComboRestaurantes.ToList();
        }

        public ComboRestaurante GetComboRestauranteByID(int id)
        {
            return context.ComboRestaurantes.Find(id);
        }

        public void InsertComboRestaurante(ComboRestaurante comboRestaurante)
        {
            context.ComboRestaurantes.Add(comboRestaurante);
        }

        public void DeleteComboRestaurante(int comboRestauranteID)
        {
            ComboRestaurante comboRestaurante = context.ComboRestaurantes.Find(comboRestauranteID);
            context.ComboRestaurantes.Remove(comboRestaurante);
        }

        public void UpdateComboRestaurante(ComboRestaurante comboRestaurante)
        {
            context.Entry(comboRestaurante).State = EntityState.Modified;
        }
        public IEnumerable<ComboRestaurante> GetByIDRestaurante(int idRestaurante)
        {
            return context.ComboRestaurantes.Where(c => c.IdRestaurante == idRestaurante);
            
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}