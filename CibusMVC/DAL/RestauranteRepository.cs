using CibusMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CibusMVC.DAL
{
    public class RestauranteRepository :IRestauranteRepository, IDisposable
    {
        private ApplicationDbContext context;

        public RestauranteRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Restaurante> GetRestaurantes()
        {
           
            return context.Restaurantes.ToList();
        }

        public Restaurante GetRestauranteByID(int id)
        {
            return context.Restaurantes.Find(id);
        }

        public void InsertRestaurante(Restaurante restaurante)
        {
            context.Restaurantes.Add(restaurante);
        }

        public void DeleteRestaurante(int restauranteID)
        {
            Restaurante restaurante = context.Restaurantes.Find(restauranteID);
            context.Restaurantes.Remove(restaurante);
        }

        public void UpdateRestaurante(Restaurante restaurante)
        {
            context.Entry(restaurante).State = EntityState.Modified;
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

        public IEnumerable<Restaurante> GetRestaurantesByTipo(string tipo)
        {
            var rest = from b in context.Restaurantes
                        where b.Tipo.Equals(tipo)
                        select b;

            return rest;
        }
    }
}