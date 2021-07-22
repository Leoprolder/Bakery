using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery.Core.Data;
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

        [HttpGet]
        public IEnumerable<Bun> Get()
        {
            return _bunService.GetAll();
        }

        [HttpGet("{id}")]
        public T Get<T>(int id)
            where T : Bun
        {
            return _bunService.Get<T>(id);
        }

        [HttpPost]
        public void Create([FromBody]Bun bun)
        {
            _bunService.Add(bun);
        }

        [HttpPost]
        public void Update([FromBody]Bun bun)
        {
            _bunService.Update(bun);
        }

        [HttpGet("{id}")]
        public void Delete(int id)
        {
            _bunService.Delete(id);
        }
    }
}
