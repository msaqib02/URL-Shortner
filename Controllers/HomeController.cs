using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using url_shortner.Models;
using url_shortner.Services;

namespace url_shortner.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUrlShortnerService _service;
        public HomeController(IUrlShortnerService service)
        {
            _service = service;
        }

        public IActionResult Index(string id)
        {
            if (id != null)
            {
                var shortUrl = _service.GetByPath(id).Result;
                if (shortUrl != null)
                {
                    return RedirectPermanent(shortUrl.OriginalUrl);
                }
            }
            return NoContent();
        }
    }
}