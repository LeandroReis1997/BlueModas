using BlueModas.Web.Core.DTO.Product;
using BlueModas.Web.Core.HttpClientAddres;
using BlueModas.Web.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlueModas.Web.Core.Service
{
    public class ProductService
    {
        public async Task<ProductDTO> AddProduct(ProductViewModel product)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync($"product/create", product);
            return JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ProductDTO> DeleteProduct(Guid id)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.DeleteAsync($"product/delete/{id}");
            return JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ProductDTO> EditProduct(Guid id, ProductViewModel product)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PutAsJsonAsync($"product/update/{id}", product);
            return JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<ProductListDTO>> GetAllProduct()
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"product/");
            return JsonConvert.DeserializeObject<List<ProductListDTO>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<ProductListDTO> GetByProductId(Guid id)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"product/{id}");
            return JsonConvert.DeserializeObject<ProductListDTO>(await response.Content.ReadAsStringAsync());
        }

        public async Task<List<ProductListDTO>> GetByProductName(string name)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.GetAsync($"product/{name}");
            return JsonConvert.DeserializeObject<List<ProductListDTO>>(await response.Content.ReadAsStringAsync());
        }
    }
}
