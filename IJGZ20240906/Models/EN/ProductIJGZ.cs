using System.ComponentModel.DataAnnotations;

namespace IJGZ20240906.Models.EN
{
    public class ProductIJGZ
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es requerido")]
        [StringLength(50)]
        public string NombreIJGZ { get; set; }

        // Descripción es opcional, por lo tanto no es requerido
        [StringLength(100, ErrorMessage ="La descripción debe contener 100 carácteres")]
        public string DescripcionIJGZ { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [Range(0, 9999999999.99)]
        public decimal PrecioIJGZ { get; set; }
    }
}
