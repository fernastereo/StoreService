using Microsoft.Extensions.Logging;
using ServiceStore.Api.Shop.RemoteInterface;
using ServiceStore.Api.Shop.RemoteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.RemoteService
{
    public class BooksService : IBooksService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BooksService> _logger;
        public BooksService(IHttpClientFactory httpClient, ILogger<BooksService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<(bool result, RemoteBook Book, string ErrorMessage)> GetBook(Guid BookId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/book/{BookId}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<RemoteBook>(content, options);
                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
