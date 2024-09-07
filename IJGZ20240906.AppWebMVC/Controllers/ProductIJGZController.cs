using IJGZ20240906.DTOs.ProductIJGZDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IJGZ20240906.AppWebMVC.Controllers
{
    public class ProductIJGZController : Controller
    {
        private readonly HttpClient _httpClientIJGZAPI;

        public ProductIJGZController(IHttpClientFactory httpClientFactory)
        {
            _httpClientIJGZAPI = httpClientFactory.CreateClient("IJGZAPI");
        }

        // Método para mostrar la lista de productos
        public async Task<IActionResult> Index(SearchQueryProductIJGZDTO searchQueryProduct, int CountRow = 0)
        {
            // Configuración de valores por defecto para la búsqueda
            if (searchQueryProduct.SendRowCount == 0)
                searchQueryProduct.SendRowCount = 2;
            if (searchQueryProduct.Take == 0)
                searchQueryProduct.Take = 10;

            var result = new SearchResultProductIJGZDTO();

            // Realizar una solicitud HTTP POST para buscar productos en el servicio web
            var response = await _httpClientIJGZAPI.PostAsJsonAsync("/product/search", searchQueryProduct);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<SearchResultProductIJGZDTO>();

            result = result != null ? result : new SearchResultProductIJGZDTO();

            // Configuración de valores para la vista
            if (result.CountRow == 0 && searchQueryProduct.SendRowCount == 1)
                result.CountRow = CountRow;

            ViewBag.CountRow = result.CountRow;
            searchQueryProduct.SendRowCount = 0;
            ViewBag.SearchQuery = searchQueryProduct;

            return View(result);
        }


        // Método para mostrar los detalles de un cliente
        public async Task<IActionResult> Details(int id)
        {
            var result = new GetIdResultProductIJGZDTO();

            // Realizar una solicitud HTTP GET para obtener los detalles del product por ID
            var response = await _httpClientIJGZAPI.GetAsync("/product/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductIJGZDTO>();

            return View(result ?? new GetIdResultProductIJGZDTO());
        }

        // GET: ProductIJGZController/Create
        public ActionResult Create()
        {
            return View();
        }

        // Método para procesar la creación de un cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductIJGZDTO createProductIJGZDTO)
        {
            try
            {
                // Realizar una solicitud HTTP POST para crear un nuevo cliente
                var response = await _httpClientIJGZAPI.PostAsJsonAsync("/product", createProductIJGZDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar guardar el registro";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // Método para mostrar el formulario de edición de un producto
        public async Task<IActionResult> Edit(int id)
        {
            var result = new GetIdResultProductIJGZDTO();
            var response = await _httpClientIJGZAPI.GetAsync("/product/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductIJGZDTO>();

            return View(new EditProductIJGZDTO(result ?? new GetIdResultProductIJGZDTO()));
        }

        // Método para procesar la edición de un cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditProductIJGZDTO editProductIJGZDTO)
        {
            try
            {
                // Realizar una solicitud HTTP PUT para editar el cliente
                var response = await _httpClientIJGZAPI.PutAsJsonAsync("/product", editProductIJGZDTO);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar editar el registro";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        // Método para mostrar la página de confirmación de eliminación de un cliente
        public async Task<IActionResult> Delete(int id)
        {
            var result = new GetIdResultProductIJGZDTO();
            var response = await _httpClientIJGZAPI.GetAsync("/product/" + id);

            if (response.IsSuccessStatusCode)
                result = await response.Content.ReadFromJsonAsync<GetIdResultProductIJGZDTO>();

            return View(result ?? new GetIdResultProductIJGZDTO());
        }

        // Método para procesar la eliminación de un cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, GetIdResultProductIJGZDTO getIdResultProduct)
        {
            try
            {
                // Realizar una solicitud HTTP DELETE para eliminar el cliente por ID
                var response = await _httpClientIJGZAPI.DeleteAsync("/product/" + id);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }

                ViewBag.Error = "Error al intentar eliminar el registro";
                return View(getIdResultProduct);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(getIdResultProduct);
            }
        }
    }
}
