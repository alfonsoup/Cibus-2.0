using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CibusMVC.Models;

namespace CibusMVC.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private GenericRepository<Restaurante> restauranteRepository;
        private GenericRepository<ComboRestaurante> comboRestauranteRepository ;
        private GenericRepository<DetallePedido> detallePedidoRepository ;
        private GenericRepository<Pedido> pedidoRepository ;
       // private GenericRepository<Size> sizeRepository;
      //  private GenericRepository<Usuario> usuarioRepository;

        public GenericRepository<Restaurante> RestauranteRepository
        {
            get
            {
                if(this.restauranteRepository == null)
                {
                    this.restauranteRepository = new GenericRepository<Restaurante>(context);
                }
                return restauranteRepository;
            }
        }
        public GenericRepository<ComboRestaurante> ComboRestauranteRepository
        {
            get
            {
                if (this.comboRestauranteRepository == null)
                {
                    this.comboRestauranteRepository = new GenericRepository<ComboRestaurante>(context);
                }
                return comboRestauranteRepository;
            }
        }
        public GenericRepository<DetallePedido> DetallePedidoRepository
        {
            get
            {
                if (this.detallePedidoRepository == null)
                {
                    this.detallePedidoRepository = new GenericRepository<DetallePedido>(context);
                }
                return detallePedidoRepository;
            }
        }
        public GenericRepository<Pedido> PedidoRepository
        {
            get
            {
                if (this.pedidoRepository == null)
                {
                    this.pedidoRepository = new GenericRepository<Pedido>(context);
                }
                return pedidoRepository;
            }
        }
        //public GenericRepository<Size> SizeRepository
        //{
        //    get
        //    {
        //        if (this.sizeRepository == null)
        //        {
        //            this.sizeRepository = new GenericRepository<Size>(context);
        //        }
        //        return sizeRepository;
        //    }
        //}

        //public GenericRepository<Usuario> UsuarioRepository
        //{
        //    get
        //    {
        //        if (this.usuarioRepository == null)
        //        {
        //            this.usuarioRepository = new GenericRepository<Usuario>(context);
        //        }
        //        return usuarioRepository;
        //    }
        //}

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