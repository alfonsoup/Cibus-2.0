using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CibusMVC.Models;
using CibusMVC.DAL;
using CibusMVC.ViewModels;

namespace CibusMVC.Controllers
{
    
    public class PedidoController : Controller
    {
        private IPedidoRepository pedidoRepository;
        private IDetallePedidoRepository detallePedidoRepository;
        public PedidoController( )
        {
            this.pedidoRepository = new PedidoRepository(new ApplicationDbContext());
            this.detallePedidoRepository = new DetallePedidoRepository(new ApplicationDbContext());
        }




        //GET: Pedido
        public ActionResult Index(int id)
        {
            DetallePedidoViewModel dpv = new DetallePedidoViewModel();
            var pedidos = pedidoRepository.GetTodosPedidosByIdPedido(id);
            var detallesPedidos = detallePedidoRepository.GetTodosDetallesPedidosByIdPedido(id);
            dpv.PedidosAll = pedidos.ToList();
            dpv.DetallesPedidosAll = detallesPedidos.ToList();

            return View(dpv);
        }
        //public ActionResult Index(int id)
        //{
            //var pedido =    SELECT
            //                Restaurante.Nombre,IdDetallePedido,DetallePedido.IdComboRestaurante,DetallePedido.IdPedido,
            //                Cantidad,PrecioUnitario,ComboRestaurante.Nombre,Pedido.IdCliente,Pedido.Fecha, Pedido.Total
            //                from Restaurante
            //                INNER JOIN ComboRestaurante ON Restaurante.IdRestaurante = ComboRestaurante.IdRestaurante
            //                INNER JOIN DetallePedido ON ComboRestaurante.IdComboRestaurante = DetallePedido.IdComboRestaurante
            //                INNER JOIN Pedido ON Pedido.IdPedido = DetallePedido.IdPedido
            //                 where ComboRestaurante.IdRestaurante = 1

                //from s in detallePedidoRepository.GetDetallePedidos() select s;
        //    return View(pedido);
        //}

        //   public ActionResult AddPedido(int idComboRestaurante, )
        // {

        //}


    }
}