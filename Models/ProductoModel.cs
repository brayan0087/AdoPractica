using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdoPractica.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        [Required] [StringLength (20)]
        public string Nombre { get; set; }
        [Required] [StringLength(30)]
        public string Descripcion { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
    
}