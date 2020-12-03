using BlueModas.Web.Core.DTO.Product;
using BlueModas.Web.Core.HttpClientAddres;
using BlueModas.Web.Core.ViewModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BlueModas.Web.Core.Service
{
    public class SaleService
    {
        public async Task<SaleDTO> AddSale(SaleViewModel sale)
        {
            var url = new BaseAddress();
            var client = new HttpClient();
            client.BaseAddress = new Uri(url.BASE_URL);
            client.DefaultRequestHeaders.Accept.Add(new
                MediaTypeWithQualityHeaderValue("application/json"));
            var response = await client.PostAsJsonAsync($"sale/create", sale);
            return JsonConvert.DeserializeObject<SaleDTO>(await response.Content.ReadAsStringAsync());
        }
    }
}
