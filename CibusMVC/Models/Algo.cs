using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CibusMVC.Models
{
    public class Algo
    {
       public string ResName { get;set;}
        public int IdDetallePedido { get; set; }
        public int IdComboRestaurante { get; set; }
        public int IdPedido { get; set; }
        public int? Cantidad { get; set; }
        public decimal? PrecioUnitario { get; set; }
        public string ComboResNombre { get; set; }
        public string IdCliente { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Total { get; set; }

    }
}