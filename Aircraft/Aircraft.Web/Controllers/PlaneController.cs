using System.Linq;
using Aircraft.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;
using DB = PN.Storage.EF.SimpleRepository;

namespace Aircraft.Web.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    public class PlaneController : BaseController
    {
        [HttpGet("GetPlanes")]
        public ActionResult GetPlanes()
        {
            return Ok(DB.Get<Plane>());
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
    }
}