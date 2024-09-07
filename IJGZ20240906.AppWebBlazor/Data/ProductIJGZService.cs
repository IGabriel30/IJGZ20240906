using IJGZ20240906.DTOs.ProductIJGZDTOs;

namespace IJGZ20240906.AppWebBlazor.Data
{
    public class ProductIJGZService
    {
        readonly HttpClient _httpClientIJGZAPI;

        // Constructor que recibe una instancia de IHttpClientFactory para crear el cliente HTTP
        public ProductIJGZService(IHttpClientFactory httpClientFactory)
        {
            _httpClientIJGZAPI = httpClientFactory.CreateClient("IJGZAPI");
        }

        // Método para buscar productos utilizando una solicitud HTTP POST
        public async Task<SearchResultProductIJGZDTO> Search(SearchQueryProductIJGZDTO searchQueryProductDTO)
        {
            var response = await _httpClientIJGZAPI.PostAsJsonAsync("/product/search", searchQueryProductDTO);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<SearchResultProductIJGZDTO>();
                return result ?? new SearchResultProductIJGZDTO();
            }
            return new SearchResultProductIJGZDTO(); // Devolver un objeto vacío en caso de error o respuesta no exitosa
        }

        // Método para obtener un producto por su ID utilizando una solicitud HTTP GET
        public async Task<GetIdResultProductIJGZDTO> GetById(int id)
        {
            var response = await _httpClientIJGZAPI.GetAsync("/product/" + id);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<GetIdResultProductIJGZDTO>();
                return result ?? new GetIdResultProductIJGZDTO();
            }
            return new GetIdResultProductIJGZDTO(); // Devolver un objeto vacío en caso de error o respuesta no exitosa
        }

        // Método para crear un nuevo product utilizando una solicitud HTTP POST
        public async Task<int> Create(CreateProductIJGZDTO createProductDTO)
        {
            int result = 0;
            var response = await _httpClientIJGZAPI.PostAsJsonAsync("/product", createProductDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        // Método para editar un product existente utilizando una solicitud HTTP PUT
        public async Task<int> Edit(EditProductIJGZDTO editProductDTO)
        {
            int result = 0;
            var response = await _httpClientIJGZAPI.PutAsJsonAsync("/product", editProductDTO);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }

        // Método para eliminar un product por su ID utilizando una solicitud HTTP DELETE
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var response = await _httpClientIJGZAPI.DeleteAsync("/product/" + id);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (int.TryParse(responseBody, out result) == false)
                    result = 0;
            }
            return result;
        }
    }
}
