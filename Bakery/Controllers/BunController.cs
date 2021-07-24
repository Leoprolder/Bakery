using Bakery.Core.Model.Bun;
using Bakery.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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
                buns.Add(BunConcretizer.Concretize(bun));
            }

            return Json(buns);
        }

        [HttpGet("[action]")]
        public JsonResult Get(int id)
        {
            return Json(_bunService.Get<Bun>(id));
        }

        [HttpPost("[action]")]
        public ActionResult Create([FromBody]Bun bun)
        {
            _bunService.Add(bun);

            return Ok();
        }

        [HttpPost("[action]")]
        public ActionResult Update([FromBody]Bun bun)
        {
            _bunService.Update(bun);

            return Ok();
        }

        [HttpPost("[action]")]
        public ActionResult Delete([FromBody]Bun bun)
        {
            _bunService.Delete(bun);

            return Ok();
        }

        [HttpGet("[action]")]
        public JsonResult GetCurrentPrice(int id)
        {
            var bun = _bunService.Get<Bun>(id);
            bun = BunConcretizer.Concretize(bun);

            return Json(bun.CurrentPrice);
        }

        [HttpGet("[action]")]
        public JsonResult GetNextPrice(int id)
        {
            var bun = _bunService.Get<Bun>(id);
            bun = BunConcretizer.Concretize(bun);

            return Json(bun.NextPrice);
        }

        [HttpGet("[action]")]
        public JsonResult GetPriceChangeTime(int id)
        {
            var bun = _bunService.Get<Bun>(id);
            bun = BunConcretizer.Concretize(bun);

            return Json(bun.NextPriceChangeTime);
        }
    }
}
