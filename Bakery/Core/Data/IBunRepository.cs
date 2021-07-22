using Bakery.Core.Model.Bun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Core.Data
{
    public interface IBunRepository : IDisposable
    {
        IEnumerable<BunBase> GetBuns();

        BunBase GetBun(int id);

        void CreateBun(BunBase bun);

        void Update(BunBase bun);

        void Delete(int id);

        void Save();
    }
}
