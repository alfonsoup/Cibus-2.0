using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CibusMVC.Models
{
    
    public partial class Cart
    {
        [Key]
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int IdComboRestaurante { get; set; }
        public int Cantidad { get; set; }
        public Nullable<System.DateTime> FechaCreacion { get; set; }
    
        public virtual ComboRestaurante ComboRestaurante { get; set; }
    }
}
