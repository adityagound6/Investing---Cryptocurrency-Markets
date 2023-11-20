using CryptoNews.Domain.Model;

namespace CryptoNews.Services.Interfaces
{
    public interface INewsService
    {
        Task<List<NewsItem>> GetNews();
    }
}
