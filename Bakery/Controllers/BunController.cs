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
        public IEnumerable<BunBase> Get()
        {
            return _bunService.GetAll();
        }

        [HttpGet("{id}")]
        public BunBase Get(int id)
        {
            return _bunService.Get(id);
        }

        [HttpPost]
        public void Create([FromBody]BunBase bun)
        {
            _bunService.Add(bun);
        }

        [HttpPost]
        public void Update([FromBody]BunBase bun)
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
