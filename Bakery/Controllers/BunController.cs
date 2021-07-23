using Bakery.Core.Model.Bun;
using Bakery.Core.Services;
using Microsoft.AspNetCore.Mvc;

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
            return Json(_bunService.GetAll());
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

        [HttpGet("[action]")]
        public ActionResult Delete(int id)
        {
            _bunService.Delete(id);

            return Ok();
        }
    }
}
