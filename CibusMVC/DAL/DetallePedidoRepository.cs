using CibusMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CibusMVC.DAL
{
    public class DetallePedidoRepository : IDetallePedidoRepository, IDisposable
    {

        private ApplicationDbContext context;

        public DetallePedidoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<DetallePedido> GetDetallePedidos()
        {
            return context.DetallePedidos.ToList();
        }

        public DetallePedido GetDetallePedidoByID(int id)
        {
            return context.DetallePedidos.Find(id);
        }
        public IEnumerable<DetallePedido> GetTodosDetallesPedidosByIdPedido(int idPedido)
        {
            var pedidos = from b in context.DetallePedidos
                       where b.IdPedido.Equals(idPedido)
                       select b;

            return pedidos;
        }

        public void InsertDetallePedido(DetallePedido detallePedido)
        {
            context.DetallePedidos.Add(detallePedido);
        }

        public void DeleteDetallePedido(int detallePedidoID)
        {
            DetallePedido detallePedido = context.DetallePedidos.Find(detallePedidoID);
            context.DetallePedidos.Remove(detallePedido);
        }

        public void UpdateDetallePedido(DetallePedido detallePedido)
        {
            context.Entry(detallePedido).State = EntityState.Modified;
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