using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJGZ20240906.DTOs.ProductIJGZDTOs
{
    public class CreateProductIJGZDTO
    {

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public string? NombreIJGZ { get; set; }

        
        [StringLength(100, ErrorMessage = "El campo descripción debe contener 100 carácteres")]
        [Display(Name = "Descripcion")]
        public string? DescripcionIJGZ { get; set; }

        [Required(ErrorMessage = "El campo precio es requerido")]
        [Range(0, 9999999999.99)]
        [Display(Name = "Precio")]
        public decimal PrecioIJGZ { get; set; }
    }
}
