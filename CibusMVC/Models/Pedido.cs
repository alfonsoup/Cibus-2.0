using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CibusMVC.Models
{
    public partial class Pedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedido()
        {
            this.DetallePedido = new HashSet<DetallePedido>();
        }

        [Key]
        public int IdPedido { get; set; }
        public string IdCliente { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public Nullable<decimal> Total { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
