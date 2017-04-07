using CibusMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CibusMVC.DAL
{
    public class PedidoRepository :IPedidoRepository, IDisposable
    {
        private ApplicationDbContext context;
        

        public PedidoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pedido> GetPedidos()
        {
            return context.Pedidos.ToList();
        }
        public IEnumerable<Pedido> GetTodosPedidosByIdPedido(int idPedido)
        {
            var pedidos = from b in context.Pedidos
                          where b.IdPedido.Equals(idPedido)
                          select b;

            return pedidos;
        }

        public Pedido GetPedidoByID(int id)
        {
            return context.Pedidos.Find(id);
        }

        public void InsertPedido(Pedido pedido)
        {
            context.Pedidos.Add(pedido);
        }

        public void DeletePedido(int pedidoID)
        {
            Pedido pedido = context.Pedidos.Find(pedidoID);
            context.Pedidos.Remove(pedido);
        }

        public void UpdatePedido(Pedido pedido)
        {
            context.Entry(pedido).State = EntityState.Modified;
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