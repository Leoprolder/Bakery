using Bakery.Core.Model.Bun;
using System;
using System.Collections.Generic;

namespace Bakery.Core.Data
{
    public interface IBunRepository : IDisposable
    {
        IEnumerable<Bun> GetBuns();

        T GetBun<T>(int id) 
            where T : Bun;

        void CreateBun(Bun bun);

        void Update(Bun bun);

        void Delete(Bun bun);

        void Save();
    }
}
