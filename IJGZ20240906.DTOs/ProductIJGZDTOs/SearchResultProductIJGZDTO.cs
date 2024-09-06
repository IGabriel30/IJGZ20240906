using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJGZ20240906.DTOs.ProductIJGZDTOs
{
    public class SearchResultProductIJGZDTO
    {
        // Cantidad de filas totales para la búsqueda (si se solicitó el conteo)
        public int CountRow { get; set; }

        // Lista de productos devueltos como resultado de la búsqueda
        public List<ProductIJGZDTO> Data { get; set; }

        public class ProductIJGZDTO
        {
            // Identificador único del producto
            public int Id { get; set; }

            // Nombre del producto
            [Display(Name = "Nombre")]
            public string NombreIJGZ { get; set; }

            // Descripción del producto (puede ser opcional)
            [Display(Name = "Descripción")]
            public string? DescripcionIJGZ { get; set; }

            // Precio del producto
            [Display(Name = "Precio")]
            public decimal PrecioIJGZ { get; set; }
        }
        }
}
