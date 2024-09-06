using IJGZ20240906.Models.EN;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace IJGZ20240906.Models.DAL
{
    // esta clase  se usa para interactuar
    // con los datos de los productos en la base de datos.
    public class ProductIJGZDAL
    {
        readonly IJGZ20240906Context _context;

        // Constructor que recibe un objeto IJGZ20240906Context para
        // interactuar con la base de datos.
        public ProductIJGZDAL(IJGZ20240906Context iJGZContext)
        {
            _context = iJGZContext;
        }

        // Método para crear un nuevo producto en la base de datos.
        public async Task<int> Create(ProductIJGZ productIJGZ)
        {
            _context.Add(productIJGZ);
            return await _context.SaveChangesAsync();
        }

        // Método para obtener un producto por su ID.
        public async Task<ProductIJGZ> GetById(int id)
        {
            var producto = await _context.productsIJGZ.FirstOrDefaultAsync(s => s.Id == id);
            return producto != null ? producto : new ProductIJGZ();
        }

        // Método para editar un product existente en la base de datos.
        public async Task<int> Edit(ProductIJGZ productIJGZ)
        {
            int result = 0;
            var productUpdate = await GetById(productIJGZ.Id);
            if (productUpdate.Id != 0)
            {
                
                productUpdate.NombreIJGZ = productIJGZ.NombreIJGZ;
                productUpdate.DescripcionIJGZ = productIJGZ.DescripcionIJGZ;
                productUpdate.PrecioIJGZ = productIJGZ.PrecioIJGZ;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método para eliminar un producto de la base de datos por su ID.
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var productDelete = await GetById(id);
            if (productDelete.Id > 0)
            {
                // Elimina el producto de la base de datos.
                _context.productsIJGZ.Remove(productDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        // Método privado para construir una consulta IQueryable para buscar productos con filtros.
        private IQueryable<ProductIJGZ> Query(ProductIJGZ productIJGZ)
        {
            var query = _context.productsIJGZ.AsQueryable();
            if (!string.IsNullOrWhiteSpace(productIJGZ.NombreIJGZ))
                query = query.Where(s => s.NombreIJGZ.Contains(productIJGZ.NombreIJGZ));

            //filtrar por precio
            if (productIJGZ.PrecioIJGZ > 0)  //se erificar que el precio es mayor que 0
                query = query.Where(s => s.PrecioIJGZ == productIJGZ.PrecioIJGZ);

            return query;
        }

        // Método para contar la cantidad de resultados de búsqueda con filtros.
        public async Task<int> CountSearch(ProductIJGZ productIJGZ)
        {
            return await Query(productIJGZ).CountAsync();
        }

        // Método para buscar productos con filtros, paginación y ordenamiento.
        public async Task<List<ProductIJGZ>> Search(ProductIJGZ productIJGZ, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(productIJGZ);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
