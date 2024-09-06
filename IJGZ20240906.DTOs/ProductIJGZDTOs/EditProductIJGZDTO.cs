using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJGZ20240906.DTOs.ProductIJGZDTOs
{
    public class EditProductIJGZDTO
    {
        //constructor que recibe un GetIdResultProductIJGZDTO para mapear sus datos
        public EditProductIJGZDTO(GetIdResultProductIJGZDTO getIdResultProductIJGZDTO)
        {
            Id = getIdResultProductIJGZDTO.Id;
            NombreIJGZ = getIdResultProductIJGZDTO.NombreIJGZ;
            DescripcionIJGZ = getIdResultProductIJGZDTO.DescripcionIJGZ;
            PrecioIJGZ = getIdResultProductIJGZDTO.PrecioIJGZ;
        }
        public EditProductIJGZDTO()
        {
            NombreIJGZ = string.Empty;
            DescripcionIJGZ = string.Empty;
            PrecioIJGZ = 0;
        }

        [Required(ErrorMessage = "El campo Id es obligatorio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo nombre es requerido")]
        [StringLength(50, ErrorMessage = "El campo nombre no puede tener más de 50 caracteres")]
        [Display(Name = "Nombre")]
        public string NombreIJGZ { get; set; }

        [StringLength(100, ErrorMessage = "El campo descripción debe contener 100 carácteres")]
        [Display(Name = "Descripcion")]
        public string DescripcionIJGZ { get; set; }


        [Required(ErrorMessage = "El campo precio es requerido")]
        [Range(0, 9999999999.99)]
        [Display(Name = "Precio")]
        public decimal PrecioIJGZ { get; set; }
    }
}
