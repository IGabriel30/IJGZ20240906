using IJGZ20240906.DTOs.ProductIJGZDTOs;
using IJGZ20240906.Models.DAL;
using IJGZ20240906.Models.EN;

namespace IJGZ20240906.Endpoints
{
    public static class ProductIJGZEndpoint
    {
        // Método para configurar los endpoints relacionados con los productos
        public static void AddCustomerEndpoints(this WebApplication app)
        {
            // Configurar un endpoint de tipo POST para buscar productos
            app.MapPost("/product/search", async (SearchQueryProductIJGZDTO productIJGZDTO, ProductIJGZDAL productIJGZDAL) =>
            {
                // Crear un objeto 'ProductoIJGZ' a partir de los datos proporcionados
                var producto = new ProductIJGZ
                {
                    NombreIJGZ = !string.IsNullOrWhiteSpace(productIJGZDTO.Nombre_Like) ? productIJGZDTO.Nombre_Like : string.Empty,
                    PrecioIJGZ = productIJGZDTO.Precio ?? decimal.Zero  // Usar el precio específico si se proporcionó
                };

                // Inicializar una lista de productos y una variable para contar las filas
                var productos = new List<ProductIJGZ>();
                int countRow = 0;

                // Verificar si se debe enviar la cantidad de filas
                if (productIJGZDTO.SendRowCount == 2)
                {
                    // Realizar una búsqueda de productos y contar las filas
                    productos = await productIJGZDAL.Search(producto, skip: productIJGZDTO.Skip, take: productIJGZDTO.Take);
                    if (productos.Count > 0)
                        countRow = await productIJGZDAL.CountSearch(producto);
                }
                else
                {
                    // Realizar una búsqueda de productos sin contar las filas
                    productos = await productIJGZDAL.Search(producto, skip: productIJGZDTO.Skip, take: productIJGZDTO.Take);
                }

                // Crear el objeto de resultado de la búsqueda
                var productResult = new SearchResultProductIJGZDTO
                {
                    Data = new List<SearchResultProductIJGZDTO.ProductIJGZDTO>(),
                    CountRow = countRow
                };

                // Mapear los resultados a objetos 'ProductIJGZDTO' y agregarlos al resultado
                productos.ForEach(s =>
                {
                    productResult.Data.Add(new SearchResultProductIJGZDTO.ProductIJGZDTO
                    {
                        Id = s.Id,
                        NombreIJGZ = s.NombreIJGZ,
                        DescripcionIJGZ = s.DescripcionIJGZ,
                        PrecioIJGZ = s.PrecioIJGZ
                    });
                });

                // Devolver los resultados
                return productResult;
            });

            // Configurar un endpoint de tipo GET para obtener un producto por ID
            app.MapGet("/product/{id}", async (int id, ProductIJGZDAL productIJGZDAL) =>
            {
                // Obtener un cliente por ID
                var product = await productIJGZDAL.GetById(id);

                // Crear un objeto 'GetIdResultCustomerDTO' para almacenar el resultado
                var productResult = new GetIdResultProductIJGZDTO
                {
                    Id = product.Id,
                    NombreIJGZ = product.NombreIJGZ,
                    DescripcionIJGZ = product.DescripcionIJGZ,
                    PrecioIJGZ = product.PrecioIJGZ
                };

                // Verificar si se encontró el producto y devolver la respuesta correspondiente
                if (productResult.Id > 0)
                    return Results.Ok(productResult);
                else
                    return Results.NotFound(productResult);
            });

            // Configurar un endpoint de tipo POST para crear un nuevo producto
            app.MapPost("/product", async (CreateProductIJGZDTO productoIJGZDTO, ProductIJGZDAL productIJGZDAL) =>
            {
                // Crear un objeto 'productoIJGZ' a partir de los datos proporcionados
                var producto = new ProductIJGZ
                {
                    NombreIJGZ = productoIJGZDTO.NombreIJGZ,
                    DescripcionIJGZ = productoIJGZDTO.DescripcionIJGZ,
                    PrecioIJGZ = productoIJGZDTO.PrecioIJGZ
                };

                // Intentar crear el producto y devolver el resultado correspondiente
                int result = await productIJGZDAL.Create(producto);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            // Configurar un endpoint de tipo PUT para editar un cliente existente
            app.MapPut("/product", async (EditProductIJGZDTO productIJGZDTO, ProductIJGZDAL productIJGZDAL) =>
            {
                // Crear un objeto 'Customer' a partir de los datos proporcionados
                var product = new ProductIJGZ
                {
                    Id = productIJGZDTO.Id,
                    NombreIJGZ = productIJGZDTO.NombreIJGZ,
                    DescripcionIJGZ = productIJGZDTO.DescripcionIJGZ,
                    PrecioIJGZ = productIJGZDTO.PrecioIJGZ
                };

                // Intentar editar el cliente y devolver el resultado correspondiente
                int result = await productIJGZDAL.Edit(product);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });

            // Configurar un endpoint de tipo DELETE para eliminar un cliente por ID
            app.MapDelete("/product/{id}", async (int id, ProductIJGZDAL productIJGZDAL) =>
            {
                // Intentar eliminar el cliente y devolver el resultado correspondiente
                int result = await productIJGZDAL.Delete(id);
                if (result != 0)
                    return Results.Ok(result);
                else
                    return Results.StatusCode(500);
            });
        }
    }
}
