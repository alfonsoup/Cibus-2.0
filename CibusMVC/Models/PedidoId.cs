using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CibusMVC.Models
{
    public class PedidoId
    {
        public int idPedido { get; set; }
        public string IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
    }
}