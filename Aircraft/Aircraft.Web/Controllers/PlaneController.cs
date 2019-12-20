using System.Collections.Generic;
using System.Linq;
using Aircraft.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DB = PN.Storage.EF.SimpleRepository;

namespace Aircraft.Web.Controllers
{
    [Route("api/[controller]")]
    public class PlaneController : BaseController
    {
        [HttpGet("GetPlanes")]
        public ActionResult GetPlanes()
        {
            return Json(DB.Get<Plane>());
        }

        [HttpGet("GetPlane")]
        public ActionResult GetPlane(string planeId)
        {
            if (string.IsNullOrWhiteSpace(planeId))
                return BadRequest();
            return Ok(DB.Get<Plane>().Where(p => p.Id.ToString() == planeId));
        }

        [HttpGet("DeletePlane")]
        public ActionResult DeletePlane(string planeId)
        {
            var plane = DB.Single<Plane>(p => p.Id.ToString() == planeId);
            DB.Delete(plane);
            return Ok();
        }

        [HttpPost("AddOrUpdate")]
        public ActionResult AddOrUpdate([FromBody] Plane plane)
        {
            DB.Upsert(plane);
            return Ok(new ResponseStatus() {Status = "200", Message = ""});
        }
    }
}