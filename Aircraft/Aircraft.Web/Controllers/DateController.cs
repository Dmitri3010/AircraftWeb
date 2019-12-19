using System;
using Microsoft.AspNetCore.Mvc;

namespace Aircraft.Web.Controllers
{
    [Route("api/{controller}")]
    public class DateController : Controller
    {
        [HttpGet("GetCurrentDate")]
        public DateTimeOffset GetCurrentDate()
        {
            return DateTimeOffset.Now;
        }
    }
}