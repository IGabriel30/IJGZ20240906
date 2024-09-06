using System.ComponentModel.DataAnnotations;

namespace IJGZ20240906.Models.EN
{
    public class ProductIJGZ
    {
        public int Id { get; set; }
        public string NombreIJGZ { get; set; }
        public string DescripcionIJGZ { get; set; }
        public decimal PrecioIJGZ { get; set; }
    }
}
