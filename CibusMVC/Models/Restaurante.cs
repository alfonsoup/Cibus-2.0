using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CibusMVC.Models
{
    public partial class Restaurante
    {
        [Key]
        public int IdRestaurante { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Logo { get; set; }
        public string Tipo { get; set; }
        public virtual ICollection<ComboRestaurante> ComboRestaurante { get; set; }

        //Usuario
    }
}
