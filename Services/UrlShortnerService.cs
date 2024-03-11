using Microsoft.EntityFrameworkCore;
using url_shortner.Helpers;
using url_shortner.Models;

namespace url_shortner.Services
{
    public class UrlShortnerService : IUrlShortnerService
    {
        private readonly UrlShortnerContext _context;

        public UrlShortnerService(UrlShortnerContext context)
        {
            _context = context;
        }
        public async Task<List<ShortUrls>> GetAll()
        {
            return await _context.ShortUrls.ToListAsync();
        }
        public async Task<ShortUrls?> GetById(int id)
        {
            return await _context.ShortUrls.FindAsync(id);
        }

        public async Task<ShortUrls?> GetByPath(string path)
        {
            return await _context.ShortUrls.FindAsync(UrlShortnerHelper.Decode((path)));
        }

        public async Task<int> Save(ShortUrls shortUrl)
        {
            var urlObj = _context.ShortUrls.Where(g => g.OriginalUrl == shortUrl.OriginalUrl).FirstOrDefault();
            if (urlObj != null)
            {
                return urlObj.Id;
            }
            await _context.ShortUrls.AddAsync(shortUrl);
            await _context.SaveChangesAsync();
            return shortUrl.Id;
        }

        public void DeleteById(int id)
        {
            var shortUrls =  _context.ShortUrls.Find(id);
            if (shortUrls != null)
            {
                _context.ShortUrls.Remove(shortUrls);
                _context.SaveChangesAsync();
            }
        }
    }
}
