using IJGZ20240906.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace IJGZ20240906.Models.DAL
{
    public class IJGZ20240906Context : DbContext
    {
        // Constructor que toma DbContextOptions como parámetro para configurar la conexión a la base de datos.
        public IJGZ20240906Context(DbContextOptions<IJGZ20240906Context> options) : base(options)
        {
        }

        // Define un DbSet
        // que representa una tabla de productos en la base de datos.
        public DbSet<ProductIJGZ> productsIJGZ { get; set; }
    }
}
