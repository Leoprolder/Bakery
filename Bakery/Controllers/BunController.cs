using Bakery.Core.Model.Bun;
using Bakery.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    public class BunController : Controller
    {
        private readonly IBunService _bunService;

        public BunController(IBunService bunService)
        {
            _bunService = bunService;
        }

        [HttpGet("[action]")]
        public JsonResult GetAll()
        {
            var buns = new List<Bun>();
            foreach (var bun in _bunService.GetAll())
            {
                if (System.DateTime.Now >= bun.SellUntil)
                {
                    _bunService.Delete(bun);
                    continue;
                }
                buns.Add(BunBuilder.Build(bun));
            }

            return Json(buns);
        }

        [HttpPost("[action]")]
        public ActionResult Create([FromBody]Bun bun)
        {
            _bunService.Add(bun);

            return Ok();
        }

        [HttpPost("[action]")]
        public ActionResult Delete([FromBody]Bun bun)
        {
            _bunService.Delete(bun);

            return Ok();
        }
    }
}
