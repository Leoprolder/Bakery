using Bakery.Core.Model.Bun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Core.Data
{
    public interface IBunRepository<T> : IDisposable
        where T : BunBase
    {
        IEnumerable<T> GetBuns();

        T GetBun(int id);

        void CreateBun(T bun);

        void Update(T bun);

        void Delete(int id);

        void Save();
    }
}
