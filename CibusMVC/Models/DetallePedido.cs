using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CibusMVC.Models
{
    public partial class DetallePedido
    {
        [Key]
        public int IdDetallePedido { get; set; }
        public int IdComboRestaurante { get; set; }
        public int IdPedido { get; set; }
        public Nullable<int> Cantidad { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
    
        public virtual ComboRestaurante ComboRestaurante { get; set; }
        public virtual Pedido Pedido { get; set; }
    }
}
