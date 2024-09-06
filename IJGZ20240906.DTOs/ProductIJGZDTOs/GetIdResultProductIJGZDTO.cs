using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJGZ20240906.DTOs.ProductIJGZDTOs
{
    public class GetIdResultProductIJGZDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string? NombreIJGZ { get; set; }

        [Display(Name = "Descripcion")]
        public string? DescripcionIJGZ { get; set; }

        [Display(Name = "Precio")]
        public decimal PrecioIJGZ { get; set; }
    }
}
