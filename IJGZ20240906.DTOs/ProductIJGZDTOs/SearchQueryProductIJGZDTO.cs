using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJGZ20240906.DTOs.ProductIJGZDTOs
{
    public class SearchQueryProductIJGZDTO
    {
        [Display(Name = "Nombre")]
        public string? Nombre_Like { get; set; }

        [Display(Name = "Precio")]
        [Range(0, 9999999999.99, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal? Precio { get; set; }

        //pp   aginación: página inicial a omitir
        [Display(Name = "Página")]
        public int Skip { get; set; }


        // paginación: cantidad de registros por página
        [Display(Name = "CantReg X Página")]
        public int Take { get; set; }

        /// <summary>
        /// 1 = No se cuenta los resultados de la búsqueda
        /// 2 = Se cuenta los resultados de la búsqueda
        /// </summary>
        public byte SendRowCount { get; set; }
    }
}
