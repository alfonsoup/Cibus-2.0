using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CibusMVC.Models
{  
    public partial class ComboRestaurante
    {

        public ComboRestaurante()
        {
            this.Cart = new HashSet<Cart>();
            this.DetallePedido = new HashSet<DetallePedido>();
        }
    
        [Key]
        public int IdComboRestaurante { get; set; }
        public int IdRestaurante { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
    

        public virtual ICollection<Cart> Cart { get; set; }
        public virtual Restaurante Restaurante { get; set; }
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}
