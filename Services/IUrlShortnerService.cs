using url_shortner.Models;

namespace url_shortner.Services
{
    public interface IUrlShortnerService
    {
        Task<List<ShortUrls>> GetAll();
        Task<ShortUrls?> GetById(int id);
        Task<ShortUrls?> GetByPath(string path);
        Task<int> Save(ShortUrls shortUrl);
        void DeleteById(int id);
    }
}
