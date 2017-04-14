using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CibusMVC.Models
{
    public class Algo
    {


        //public List<String> nombreCombo = new List<string>();
        //public List<decimal?> precioTotal=new List<decimal?>();
        //public List<decimal?> precioUnitario=new List<decimal?>();
        //public List<int?> cantidad=new List<int?>();
        //public decimal? TotalPedido;


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