using System.Linq;
using Aircraft.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using DB = PN.Storage.EF.SimpleRepository;

namespace Aircraft.Web.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : Controller
    {
        [HttpGet("GetFlights")]
        public ActionResult GetFlights()
        {
            return Json(DB.Get<Flight>());
        }

        [HttpGet("GetFlight")]
        public ActionResult GetFlight(string flightId)
        {
            if (string.IsNullOrWhiteSpace(flightId))
                return BadRequest();
            return Ok(DB.Get<Flight>().Where(p => p.Id.ToString() == flightId));
        }

        [HttpGet("DeleteFlight")]
        public ActionResult DeleteFlight(string flightId)
        {
            var flight = DB.Single<Plane>(p => p.Id.ToString() == flightId);
            DB.Delete(flight);
            return Ok();
        }

        [HttpPost("AddOrUpdate")]
        public ActionResult AddOrUpdate([FromBody] Flight flight)
        {
            DB.Upsert(flight);
            return Ok(new ResponseStatus() {Status = "200", Message = ""});
        }
    }
}