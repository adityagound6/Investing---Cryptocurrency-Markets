using CryptoNews.Domain.DTO;
using CryptoNews.Services.Interfaces;
using CryptoNews.Domain.Model;
using Microsoft.AspNetCore.Components;
using System.Text.Json;
using CryptoNews.Domain.Constant;

namespace CryptoNews.Services
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(HttpClient httpClient) => _httpClient = httpClient;

        public async Task<List<NewsItem>> GetNews()
        {
            ConfigureHttpClient();

            var response = await _httpClient.GetAsync(APIConfigConstant._newsEndpoint);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();

            var dto = await JsonSerializer.DeserializeAsync<NewsDto>(stream);
            return dto.data.FirstOrDefault().screen_data.news.Select(n => new NewsItem 
            {
                Headline = n.HEADLINE,
                Body = (MarkupString)n.BODY,
                ImageUrl = n.related_image
            }).ToList();
        }

        private void ConfigureHttpClient()
        {
            _httpClient.BaseAddress = new Uri(APIConfigConstant._baseUrl);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", APIConfigConstant._host);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", APIConfigConstant._key);
        }
    }
}
