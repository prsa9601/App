 using AppRazorPage.Models.Product;
 using Eshop.RazorPage.Models;
 using Shop.Query.Products.DTOs;

namespace AppRazorPage.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _client;
        private const string ModuleName = "Product";

        public ProductService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ApiResult> AddProduct(AddProductCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Price.ToString()), "Price");
            formData.Add(new StringContent(command.Title.ToString()), "Title");
            var result = await _client.PostAsJsonAsync("product/add", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
         
        public async Task<ApiResult> EditProduct(EditProductCommand command)
        {
            var formData = new MultipartFormDataContent();
            formData.Add(new StringContent(command.Price.ToString()), "Price");
            formData.Add(new StringContent(command.Title.ToString()), "Title");
            formData.Add(new StringContent(command.ProductId.ToString()), "ProductId");
            var result = await _client.PutAsJsonAsync("product/edit", formData);
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }

        public async Task<ProductDto?> GetProductById(long productId)
        {
            var result = await _client.GetFromJsonAsync<ApiResult<ProductDto>>($"product/GetById{productId}");
            return result.Data;
        }

        public async Task<ProductFilterResult> GetProductByFilter(ProductFilterParams filterParams)
        {
            var url = $"{ModuleName}?pageId={filterParams.PageId}&take={filterParams.Take}" +
                      $"title={filterParams.Title}";
            if (filterParams.ProductId != null)
                url += $"&productId={filterParams.ProductId}";
            var result = await _client.GetFromJsonAsync<ApiResult<ProductFilterResult>>(url);
            return result?.Data;
        }

        public async Task<ApiResult> DeleteProduct(long productId)
        {
            var result = await _client.DeleteAsync($"{ModuleName}/{productId}");
            return await result.Content.ReadFromJsonAsync<ApiResult>();
        }
    }
}
