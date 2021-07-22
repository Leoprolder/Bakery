using Bakery.Core.Model.Bun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Core.Services
{
    public interface IBunService
    {
        public void Add(BunBase bun);

        public IEnumerable<BunBase> GetAll();

        public BunBase Get(int id);

        public void Delete(int id);

        public void Update(BunBase bun);
    }
}
