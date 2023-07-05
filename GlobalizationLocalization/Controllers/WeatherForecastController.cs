using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;

namespace GlobalizationLocalization.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IHtmlLocalizer<WeatherForecastController> _localizer;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IHtmlLocalizer<WeatherForecastController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_localizer["ApiSuccessMessage"].Value);
        }
        [HttpGet("culture/{culture}")]
        public IActionResult CultureManageMent(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),new CookieOptions(){Expires = DateTimeOffset.Now.AddDays(30)});
            return RedirectToAction(nameof(Get));
        }
    }

   
}
