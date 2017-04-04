using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CibusMVC.DAL;
using CibusMVC.Models;

namespace CibusMVC.ViewModels
{
    public class DetallePedidoViewModel
    {
        public List<DetallePedido> DetallesPedidosAll { get; set; }
        public List<Pedido> PedidosAll { get; set; }
    }
}