using Microsoft.AspNetCore.Mvc;
using url_shortner.Helpers;
using url_shortner.Models;
using url_shortner.Services;

namespace url_shortner.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlsApiController : ControllerBase
    {
        private readonly IUrlShortnerService _urlShortnerService;

        public ShortUrlsApiController(IUrlShortnerService urlShortnerService)
        {
            _urlShortnerService = urlShortnerService;
        }

        // GET: api/ShortUrlsApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShortUrls>>> GetShortUrls()
        {
            return await _urlShortnerService.GetAll(); 
        }

        // GET: api/ShortUrlsApi/asd
        [HttpGet("{id}")]
        public async Task<ActionResult<ShortUrls?>> GetShortUrls(string id)
        {
           return  await _urlShortnerService.GetByPath(id);
        }

        // POST: api/ShortUrlsApi
        [HttpPost]
        public async Task<ActionResult<string>> PostShortUrls(ShortUrls shortUrls)
        {

            int id = await _urlShortnerService.Save(shortUrls);
            string code = UrlShortnerHelper.Encode(id);
            return code;
        }

        // DELETE: api/ShortUrlsApi/5
        [HttpDelete("{id}")]
        public IActionResult DeleteShortUrls(string id)
        {
            _urlShortnerService.DeleteById(UrlShortnerHelper.Decode(id));
            return NoContent();
        }

    }
}
